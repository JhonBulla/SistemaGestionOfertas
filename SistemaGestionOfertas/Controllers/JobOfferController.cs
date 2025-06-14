using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaGestionOfertas.Models.DTO;
using SistemaGestionOfertas.Models.Interfaces;
using SistemaGestionOfertas.Models.JobOffers;
using SistemaGestionOfertas.Models.Users;
using System.Security.Claims;

namespace SistemaGestionOfertas.Controllers
{
    /// <summary>
    /// Representa el controlador de acciones para gestionar usuarios
    /// </summary>
    public class JobOfferController : Controller
    {
        #region Properties
        /// <summary>
        /// Instancias de acceso a los repositorios de datos para las entidades JobOffer, City, Salary, ContractType y ExpirationTime
        /// </summary>
        private IJobOfferRepository jobOfferRepository;
        private readonly ICityRepository cityRepository;
        private readonly ISalaryRepository salaryRepository;
        private readonly IContractTypeRepository contractTypeRepository;
        private readonly IExpirationTimeRepository expirationTimeRepository;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor que inicializa una nueva instancia de JobOfferController.
        /// </summary>
        /// <param name="jobOfferRepository">Instancia de acceso al repositorio de ofertas</param>
        /// <param name="cityRepository">Instancia de acceso al repositorio de ciudades</param>
        /// <param name="salaryRepository">Instancia de acceso al repositorio de salarios</param>
        /// <param name="contractTypeRepository">Instancia de acceso al repositorio tipos de contrato de ofertas</param>
        /// <param name="expirationTimeRepository">Instancia de acceso al repositorio de tiempos de expiración de las ofertas</param>
        public JobOfferController(IJobOfferRepository jobOfferRepository, ICityRepository cityRepository,
            ISalaryRepository salaryRepository, IContractTypeRepository contractTypeRepository,
            IExpirationTimeRepository expirationTimeRepository)
        {
            this.jobOfferRepository = jobOfferRepository;
            this.cityRepository = cityRepository;
            this.salaryRepository = salaryRepository;
            this.contractTypeRepository = contractTypeRepository;
            this.expirationTimeRepository = expirationTimeRepository;
        }
        #endregion

        #region Methods

        #region FillViewBags
        private void FillViewBags(JobOfferDto? jobOfferDto = null)
        {
            ViewBag.Cities = new SelectList(this.cityRepository.GetCities(), "Id", "Name", jobOfferDto?.IdCity);
            ViewBag.Salaries = new SelectList(this.salaryRepository.GetSalaries(), "Id", "Name", jobOfferDto?.IdSalary);
            ViewBag.ContractTypes = new SelectList(this.contractTypeRepository.GetContractType(), "Id", "Name", jobOfferDto?.IdContractType);
            ViewBag.ExpirationTimes = new SelectList(this.expirationTimeRepository.GetExpirationTimes(), "Id", "Name", jobOfferDto?.IdExpirationTime);
        }
        #endregion

        #region GetJobOffers
        /// <summary>
        /// Acción GET que devuelve la vista principal de ofertas para candidatos.
        /// </summary>
        /// <remarks>
        /// Esta acción obtiene todas las ofertas validas del repositorio de ofertas,
        /// los convierte en objetos JobOfferDto y los envía a la vista principal para su visualización.
        /// </remarks>
        /// <returns>La vista principal de ofertas con la lista de ofertas a traves de JobOfferDto.</returns>
        public IActionResult Index()
        {
            var jobOffers = jobOfferRepository.GetJobOffers();
            var jobOfferDto = jobOffers.Select(offer => JobOfferToDto(offer, true)).ToList();

            return View(jobOfferDto);
        }

        /// <summary>
        /// Acción GET que devuelve la vista principal de ofertas para usuarios administrador y reclutadores.
        /// </summary>
        /// <remarks>
        /// Esta acción obtiene todas las ofertas validas del repositorio de ofertas,
        /// los convierte en objetos JobOfferDto y los envía a la vista principal para su visualización.
        /// </remarks>
        /// <returns>La vista principal de ofertas con la lista de ofertas a traves de JobOfferDto.</returns>
        public IActionResult Admin()
        {
            var jobOffers = jobOfferRepository.GetJobOffers();
            var jobOfferDto = jobOffers.Select(offer => JobOfferToDto(offer)).ToList();

            return View(jobOfferDto);
        }

        /// <summary>
        /// Metodo que mapea una oferta en un dto.
        /// </summary>
        /// <remarks>
        /// Este metodo convierte una oferta en un objeto JobOfferDto.
        /// </remarks>
        /// <returns>Una oferta como objeto JobOfferDto.</returns>
        private static JobOfferDto JobOfferToDto(JobOffer joboffer, bool user = false)
        {
            var jobOfferDto = new JobOfferDto
            {
                Id = joboffer.Id,
                Title = joboffer.Title,
                Description = joboffer.Description,
                Address = joboffer.Address,
                HideSalary = joboffer.HideSalary,
                IdCity = joboffer.IdCity,
                IdSalary = joboffer.IdSalary,
                IdContractType = joboffer.IdContractType,
                IdExpirationTime = joboffer.IdExpirationTime,
                CityName = joboffer.City?.Name,
                SalaryRange = joboffer.Salary?.Name,
                ContractTypeName = joboffer.ContractType?.Name,
                ExpirationTimeName = joboffer.ExpirationTime?.Name,
                IdUserWhoRegisteredIt = joboffer.Id,
                PublishedAt = joboffer.PublishedAt,
                ExpiredAt = joboffer.ExpiredAt
            };

            if (user)
            {
                jobOfferDto.Address = joboffer.Address + " " + joboffer.City?.Name + ", " + joboffer.City?.Department?.Name;
                jobOfferDto.SalaryRange = joboffer.HideSalary ? "Confidencial" : joboffer.Salary?.Name;
            }

            return jobOfferDto;
        }
        #endregion

        #region CreateJobOffer
        /// <summary>
        /// Acción GET para mostrar el formulario de creación de una nueva oferta.
        /// </summary>
        /// <remarks>
        /// Esta acción se utiliza para mostrar el formulario de creación de una nueva oferta.
        /// Este método prepara los datos necesarios (como listas desplegables) mediante el método <c>FillViewBags</c>
        /// Solo puede ser accedido por usuarios con los roles <c>Admin</c> o <c>Recruiter</c>.
        /// </remarks>
        /// <returns>La vista de formulario de creación de oferta.</returns>
        [Authorize(Roles = "Admin,Recruiter")]
        public IActionResult Create()
        {
            FillViewBags();
            return View();
        }

        /// <summary>
        /// Acción HTTP POST para crear una nueva oferta.
        /// </summary>
        /// <remarks>
        /// Este método valida el modelo recibido desde el formulario. Si el modelo es válido, construye una instancia de <c>JobOffer</c>,
        /// asigna valores adicionales como el usuario creador y fechas, e intenta guardarla en la base de datos.
        /// Si la creación es exitosa, redirige a la vista de administración.
        /// En caso contrario, muestra un mensaje de error y retorna nuevamente la vista con los datos ingresados.
        /// Se utiliza el atributo [ValidateAntiForgeryToken] para proteger la acción contra ataques de falsificación de solicitudes entre sitios (CSRF).
        /// Solo puede ser accedido por usuarios con los roles <c>Admin</c> o <c>Recruiter</c>.
        /// </remarks>
        /// <param name="jobOfferDto">Objeto JobOfferDto que contiene los datos de la nueva oferta.</param>
        /// <returns>
        /// Si la creación de la oferta se realiza correctamente, la acción redirecciona a la vista principal de las ofertas.
        /// Si la creación de la oferta no se realiza correctamente, se devuelve la vista de formulario de crear oferta con un mensaje de error.
        /// </returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Recruiter")]
        public IActionResult Create(JobOfferDto jobOfferDto)
        {
            if (ModelState.IsValid)
            {
                var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

                var jobOffer = new JobOffer
                {
                    Title = jobOfferDto.Title,
                    Description = jobOfferDto.Description,
                    IsDeleted = false,
                    Address = jobOfferDto.Address,
                    IdCity = jobOfferDto.IdCity,
                    IdSalary = jobOfferDto.IdSalary,
                    HideSalary = jobOfferDto.HideSalary,
                    IdContractType = jobOfferDto.IdContractType,
                    IdExpirationTime = jobOfferDto.IdExpirationTime,
                    IdUserWhoRegisteredIt = userId,
                    IdUserWhoModifiedIt = null,
                    PublishedAt = DateTime.Now,
                    ExpiredAt = DateTime.Now.AddDays(jobOfferDto.ExpirationTimeRange),
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };

                if (jobOfferRepository.AddJobOffer(jobOffer))
                {
                    return RedirectToAction(nameof(Admin));
                }
                else
                {
                    ViewData["ErrorMessage"] = "Error al crear la oferta.";
                }
            }
            ViewData["ErrorMessage"] = "Error al crear la oferta, modelo invalido";
            FillViewBags();
            return View(jobOfferDto);
        }
        #endregion

        #region EditJobOffer
        /// <summary>
        /// Acción GET que Muestra la vista de edición para una oferta existente.
        /// </summary>
        /// <remarks>
        /// Este método busca una oferta por su identificador. Si se encuentra, convierte el modelo a un DTO
        /// y carga los datos necesarios para los elementos de selección de la vista mediante <c>FillViewBags</c>.
        /// Solo accesible por usuarios con roles <c>Admin</c> o <c>Recruiter</c>.
        /// </remarks>
        /// <param name="id">Identificador único de la oferta a editar.</param>
        /// <returns>
        /// Si la oferta se encuentra, retorna una vista con los datos de la oferta en formato DTO para ser editada.
        /// Si la oferta no se encuentra, retorna un resultado <c>NotFound</c>.
        /// </returns>
        [Authorize(Roles = "Admin,Recruiter")]
        public IActionResult Edit(int id)
        {
            var jobOffer = jobOfferRepository.GetJobOfferById(id);

            if (jobOffer == null)
            {
                return NotFound();
            }

            var jobOfferDto = JobOfferToDto(jobOffer);

            FillViewBags(jobOfferDto);

            return View(jobOfferDto);
        }

        /// <summary>
        /// Acción HTTP POST que actualiza los datos enviados desde el formulario de edición de una oferta.
        /// </summary>
        /// <remarks>
        /// Este método recibe un <see cref="JobOfferDto"/> con los datos actualizados. Si el modelo es válido,
        /// se actualiza la oferta en la base de datos. El campo <c>IdUserWhoModifiedIt</c> se asigna automáticamente
        /// con el ID del usuario autenticado. Solo pueden acceder usuarios con roles <c>Admin</c> o <c>Recruiter</c>.
        /// </remarks>
        /// <param name="jobOfferDto">Objeto DTO con los datos de la oferta editada.</param>
        /// <returns>
        /// Si la actualización de la oferta se realiza correctamente, la acción redirige a la vista de administración de ofertas. 
        /// Si la actualización de la oferta no se realiza correctamente, retorna la misma vista con los datos y un mensaje de error.
        /// </returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Recruiter")]
        public IActionResult Edit(JobOfferDto jobOfferDto)
        {
            if (ModelState.IsValid)
            {
                var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

                var jobOffer = new JobOffer
                {
                    Id = jobOfferDto.Id,
                    Title = jobOfferDto.Title,
                    Description = jobOfferDto.Description,
                    IsDeleted = false,
                    Address = jobOfferDto.Address,
                    IdCity = jobOfferDto.IdCity,
                    IdSalary = jobOfferDto.IdSalary,
                    HideSalary = jobOfferDto.HideSalary,
                    IdContractType = jobOfferDto.IdContractType,
                    IdExpirationTime = jobOfferDto.IdExpirationTime,
                    IdUserWhoRegisteredIt = jobOfferDto.IdUserWhoRegisteredIt != null ? (int)jobOfferDto.IdUserWhoRegisteredIt : userId,
                    IdUserWhoModifiedIt = userId,
                    ExpiredAt = (jobOfferDto.PublishedAt ?? DateTime.Now).AddDays(jobOfferDto.ExpirationTimeRange),
                    UpdatedAt = DateTime.Now
                };

                if (jobOfferRepository.UpdateJobOffer(jobOffer))
                {
                    return RedirectToAction(nameof(Admin));
                }
                else
                {
                    ViewData["ErrorMessage"] = "Error al editar la oferta.";
                }
            }
            ViewData["ErrorMessage"] = "Error al editar la oferta, modelo invalido";

            FillViewBags(jobOfferDto);

            return View(jobOfferDto);
        }
        #endregion

        #region DeleteJobOffer

        /// <summary>
        /// Acción HTTP POST que elimina una oferta de forma lógica (soft delete).
        /// </summary>
        /// <remarks>
        /// Este método marca la oferta como eliminada utilizando el Id de oferta proporcionado, y registra qué usuario realizó la acción.
        /// Solo los usuarios con roles <c>Admin</c> o <c>Recruiter</c> tienen permiso para ejecutar esta acción.
        /// La eliminación es lógica, no se elimina físicamente de la base de datos.
        /// </remarks>
        /// <param name="id">Identificador único de la oferta que se desea eliminar.</param>
        /// <returns>
        /// Si la eliminación de la oferta es correcta, redirige a la vista de administración si la eliminación fue exitosa. 
        /// Si la eliminación de la oferta no es correcta, retorna la misma vista con un mensaje de error.
        /// </returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Recruiter")]
        public IActionResult Delete(int id)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            if (jobOfferRepository.DeleteJobOffer(id, userId))
            {
                return RedirectToAction(nameof(Admin));
            }
            else
            {
                ViewData["ErrorMessage"] = "Error al eliminar la oferta.";
                return View();
            }
        }
        #endregion

        #region JobOfferApply

        /// <summary>
        /// Acción POST que procesa la solicitud de postulación a una oferta.
        /// </summary>
        /// <remarks>
        /// Este método recibe una solicitud de tipo POST para aplicar a una oferta.
        /// Actualmente devuelve una respuesta OK sin procesar datos adicionales.
        /// Puede extenderse para registrar la postulación del usuario o validar condiciones.
        /// </remarks>
        /// <returns>
        /// Respuesta HTTP 200 (OK).
        /// </returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Apply()
        {
            return Ok();
        }
        #endregion

        #endregion

    }

}

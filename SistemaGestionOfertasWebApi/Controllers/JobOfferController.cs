using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaGestionOfertas.Models.DTO;
using SistemaGestionOfertas.Models.Interfaces;
using SistemaGestionOfertas.Models.JobOffers;
using SistemaGestionOfertas.Models.Repository;
using SistemaGestionOfertas.Models.Users;
using System.Net;

namespace SistemaGestionOfertasWebApi.Controllers
{
    /// <summary>
    /// Representa el controlador de acciones para gestionar usuarios desde web api
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class JobOfferController : ControllerBase
    {

        #region Properties
        /// <summary>
        /// Instancia de acceso al repositorio de datos para la entidad JobOffer
        /// </summary>
        private IJobOfferRepository jobOfferRepository;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor que inicializa una nueva instancia de JobOfferController.
        /// </summary>
        /// <param name="jobOfferRepository">Instancia de acceso al repositorio de ofertas</param>
        public JobOfferController(IJobOfferRepository jobOfferRepository)
        {
            this.jobOfferRepository = jobOfferRepository;
        }
        #endregion

        #region Methods

        #region GET

        #region GetJobOffers

        private JobOfferDto JobOfferToDto(JobOffer joboffer)
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
                ExpiredAt = joboffer.ExpiredAt,
                CreatedAt = joboffer.CreatedAt,
                UpdatedAt = joboffer.UpdatedAt
            };

            return jobOfferDto;
        }

        /// <summary>
        /// Metodo GET que obtiene todas las ofertas validas.
        /// </summary>
        /// <remarks>
        /// Devuelve una lista de todas las ofertas validas disponibles en el sistema.
        /// </remarks>
        /// <returns>
        /// Un objeto IActionResult que representa la respuesta HTTP.
        /// Si la operación se realiza correctamente, devuelve un código de estado 200 (OK) con la lista de ofertas en el cuerpo de la respuesta.
        /// Si la oferta no se encuentra, devuelve un código de estado 404 (No encontrado) con un mensaje de error en el cuerpo de la respuesta.
        /// Si se produce un error durante la operación, devuelve un código de estado 500 (Error interno del servidor) con un mensaje de error en el cuerpo de la respuesta.
        /// </returns>
        [HttpGet]
        public IActionResult GetJobOffers()
        {
            try
            {
                var jobOfferDto = jobOfferRepository.GetJobOffers()
                .Select(x => JobOfferToDto(x)).ToList();

                if (jobOfferDto == null)
                {
                    return NotFound("No se encontraron ofertas");
                }
                return Ok(jobOfferDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error al obtener las ofertas: " + ex.Message);
            }
        }
        #endregion

        #region GetJobOfferById

        /// <summary>
        /// Metodo GET que obtiene a una oferta por el Id.
        /// </summary>
        /// <remarks>
        /// Devuelve la informacion de una oferta del sistema.
        /// </remarks>
        /// <returns>
        /// Un objeto IActionResult que representa la respuesta HTTP.
        /// Si la operación se realiza correctamente, devuelve un código de estado 200 (OK) con la informacion de la oferta en el cuerpo de la respuesta.
        /// Si la oferta no se encuentra, devuelve un código de estado 404 (No encontrado) con un mensaje de error en el cuerpo de la respuesta.
        /// Si se produce un error durante la operación, devuelve un código de estado 500 (Error interno del servidor) con un mensaje de error en el cuerpo de la respuesta.
        /// </returns>
        [HttpGet("{Id}")]
        public IActionResult GetJobOfferById(int Id)
        {
            try
            {
                var jobOffer = jobOfferRepository.GetJobOfferById(Id);
                if (jobOffer == null)
                {
                    return NotFound("No se encontró la oferta: " + Id);
                }
                var jobOfferDto = JobOfferToDto(jobOffer);
                return Ok(jobOfferDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error al obtener la oferta: " + ex.Message);
            }
        }
        #endregion

        #endregion

        #region CreateJobOffer

        /// <summary>
        /// Metodo POST para la creacion de una oferta nueva.
        /// </summary>
        /// <remarks>
        /// Este método permite crear una oferta nueva en el sistema.
        /// </remarks>
        /// <param name="jobOfferDto">Los datos de la oferta a crear.</param>
        /// <param name="IdUser">El identificador único del usuario que crea la oferta</param>
        /// <returns>
        /// Un objeto IActionResult que representa la respuesta HTTP.
        /// Si la operación se realiza correctamente, devuelve un código de estado 200 (OK) con un mensaje de éxito en el cuerpo de la respuesta.
        /// Si se produce un error durante la operación, devuelve un código de estado 500 (Error interno del servidor) con un mensaje de error en el cuerpo de la respuesta.
        /// </returns>
        [HttpPost("{IdUser}")]
        public IActionResult Create(int IdUser, JobOfferDto jobOfferDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
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
                        IdUserWhoRegisteredIt = IdUser,
                        IdUserWhoModifiedIt = null,
                        PublishedAt = DateTime.Now,
                        ExpiredAt = DateTime.Now.AddDays(jobOfferDto.ExpirationTimeRange),
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    };

                    if (jobOfferRepository.AddJobOffer(jobOffer))
                    {
                        return Ok("¡La oferta se creó exitosamente!");
                    }
                }
                return StatusCode(500, "Error al crear la oferta.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error al crear la oferta: " + ex.Message);
            }
        }
        #endregion

        #region EditUser

        /// <summary>
        /// Metodo PUT que actualiza la información de una oferta existente.
        /// </summary>
        /// <remarks>
        /// Este método actualiza la información de una oferta existente en el sistema.
        /// </remarks>
        /// <param name="Id">El identificador único de la oferta que se desea actualizar.</param>
        /// <param name="IdUser">El identificador único del usuario que actualiza la oferta.</param>
        /// <param name="jobOfferDto">Los datos actualizados de la oferta.</param>
        /// <returns>
        /// Un objeto IActionResult que representa la respuesta HTTP.
        /// Si la operación se realiza correctamente, devuelve un código de estado 200 (OK) con un mensaje de éxito en el cuerpo de la respuesta.
        /// Si la oferta no se encuentra, devuelve un código de estado 404 (No encontrado) con un mensaje de error en el cuerpo de la respuesta.
        /// Si se produce un error durante la operación, devuelve un código de estado 500 (Error interno del servidor) con un mensaje de error en el cuerpo de la respuesta.
        /// </returns>
        [HttpPut("{Id}/{IdUser}")]
        public IActionResult EditUser(int Id, int IdUser, JobOfferDto jobOfferDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var jobOffer = jobOfferRepository.GetJobOfferById(Id);

                    if (jobOffer == null)
                    {
                        return NotFound("No se encontró la oferta: " + Id);
                    }

                    jobOffer.Id = jobOfferDto.Id;
                    jobOffer.Title = jobOfferDto.Title;
                    jobOffer.Description = jobOfferDto.Description;
                    jobOffer.Address = jobOfferDto.Address;
                    jobOffer.IdCity = jobOfferDto.IdCity;
                    jobOffer.IdSalary = jobOfferDto.IdSalary;
                    jobOffer.HideSalary = jobOfferDto.HideSalary;
                    jobOffer.IdContractType = jobOfferDto.IdContractType;
                    jobOffer.IdExpirationTime = jobOfferDto.IdExpirationTime;
                    jobOffer.IdUserWhoModifiedIt = IdUser;
                    jobOffer.ExpiredAt = (jobOfferDto.PublishedAt ?? DateTime.Now).AddDays(jobOfferDto.ExpirationTimeRange);
                    jobOffer.UpdatedAt = DateTime.Now;

                    if (jobOfferRepository.UpdateJobOffer(jobOffer))
                    {
                        return Ok("¡La oferta se actualizó exitosamente!");
                    }
                }
                return StatusCode(500, "Error al actualizar la oferta: " + Id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error al actualizar la oferta: " + ex.Message);
            }
        }
        #endregion

        #region DeleteUser

        /// <summary>
        /// Metodo DELETE que elimina una oferta existente.
        /// </summary>
        /// <remarks>
        /// Este método elimina una oferta existente en el sistema.
        /// Este método realiza un soft delete o borrado logico en vez de un remove para mantener la oferta en el sistema en caso de necesitarla nuevamente.
        /// </remarks>
        /// <param name="Id">El identificador único de la oferta que se desea eliminar.</param>
        /// <param name="UserId">El identificador único del usuario que elimina la oferta.</param>
        /// <returns>
        /// Un objeto IActionResult que representa la respuesta HTTP.
        /// Si la operación se realiza correctamente, devuelve un código de estado 200 (OK) con un mensaje de éxito en el cuerpo de la respuesta.
        /// Si la oferta no se encuentra, devuelve un código de estado 404 (No encontrado) con un mensaje de error en el cuerpo de la respuesta.
        /// Si se produce un error durante la operación, devuelve un código de estado 500 (Error interno del servidor) con un mensaje de error en el cuerpo de la respuesta.
        /// </returns>
        [HttpDelete("{Id}/{UserId}")]
        public IActionResult DeleteUser(int Id, int UserId)
        {
            try
            {
                var jobOffer = jobOfferRepository.GetJobOfferById(Id);
                if (jobOffer == null)
                {
                    return NotFound("No se encontró la oferta: " + Id);
                }

                if (jobOfferRepository.DeleteJobOffer(Id, UserId))
                {
                    return Ok("¡La oferta se eliminó exitosamente!");
                }
                return StatusCode(500, "Error al eliminar la oferta: " + Id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error al eliminar la oferta: " + ex.Message);
            }
        }
        #endregion

        #endregion
    }
}

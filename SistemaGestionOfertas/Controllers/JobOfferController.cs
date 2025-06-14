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
        private IJobOfferRepository jobOfferRepository;
        private readonly ICityRepository cityRepository;
        private readonly ISalaryRepository salaryRepository;
        private readonly IContractTypeRepository contractTypeRepository;
        private readonly IExpirationTimeRepository expirationTimeRepository;
        #endregion

        #region Constructor

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
        // GET: JobOffers
        public IActionResult Index()
        {
            var jobOffers = jobOfferRepository.GetJobOffers();
            var jobOfferDto = jobOffers.Select(offer => JobOfferToDto(offer, true)).ToList();

            return View(jobOfferDto);
        }

        public IActionResult Admin()
        {
            var jobOffers = jobOfferRepository.GetJobOffers();
            var jobOfferDto = jobOffers.Select(offer => JobOfferToDto(offer)).ToList();

            return View(jobOfferDto);
        }

        public JobOfferDto JobOfferToDto(JobOffer joboffer, bool user = false)
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
        // GET: JobOffers/Create
        [Authorize(Roles = "Admin,Recruiter")]
        public IActionResult Create()
        {
            FillViewBags();
            return View();
        }

        // POST: JobOffers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Recruiter")]
        public IActionResult Create(JobOfferDto jobOfferDto)
        {
            if (ModelState.IsValid)
            {
                var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

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
        // GET: JobOffers/Edit
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

        // POST: JobOffers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Recruiter")]
        public IActionResult Edit(JobOfferDto jobOfferDto)
        {
            if (ModelState.IsValid)
            {
                var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

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
                    IdUserWhoRegisteredIt = (int)jobOfferDto.IdUserWhoRegisteredIt,
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Recruiter")]
        public IActionResult Delete(int id)
        {
            if (jobOfferRepository.DeleteJobOffer(id))
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

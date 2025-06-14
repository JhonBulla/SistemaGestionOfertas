using Microsoft.EntityFrameworkCore;
using SistemaGestionOfertas.Data;
using SistemaGestionOfertas.Models.Interfaces;
using SistemaGestionOfertas.Models.JobOffers;

namespace SistemaGestionOfertas.Models.Repository
{
    /// <summary>
    /// Gestiona el acceso y la manipulación de los datos de las ofertas en la base de datos.
    /// </summary>
    public class JobOfferRepository : IJobOfferRepository
    {
        #region Properties
        /// <summary>
        /// Contexto de la base de datos utilizada.
        /// </summary>
        private readonly ModelContext modelContext;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor que inicializa una nueva instancia de JobOfferRepository.
        /// </summary>
        /// <param name="modelContext">Contexto de base de datos.</param>
        public JobOfferRepository(ModelContext modelContext)
        {
            this.modelContext = modelContext;
        }
        #endregion

        #region Methods

        #region GetJoboffers
        /// <summary>
        /// Obtiene todas los ofertas en la base de datos.
        /// </summary>
        /// <returns>Colección de ofertas de la base de datos.</returns>
        public IEnumerable<JobOffer> GetJobOffers()
        {
            return modelContext.JobOffers.Include(x => x.City).ThenInclude(c => c.Department)
                 .Include(x => x.Salary).Include(x => x.ContractType)
                 .Include(x => x.ExpirationTime).Where(x => !x.IsDeleted).ToList();
        }
        #endregion

        #region GetJobOfferById
        /// <summary>
        /// Obtiene una oferta de la base de datos por el Id.
        /// </summary>
        /// <returns>Oferta de la base de datos.</returns>
        public JobOffer? GetJobOfferById(int Id)
        {
            return modelContext.JobOffers.ToList().FirstOrDefault(x => x.Id == Id && !x.IsDeleted);
        }
        #endregion

        #region AddJobOffer
        /// <summary>
        /// Agrega una nueva oferta en la base de datos.
        /// </summary>
        /// <param name="jobOffer">Objeto con la informacion de la oferta</param>
        /// <returns><c>True</c> si realiza la insercion de forma exitosa</returns>
        public bool AddJobOffer(JobOffer jobOffer)
        {
            try
            {
                modelContext.JobOffers.Add(jobOffer);
                modelContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion

        #region UpdateJobOffer
        /// <summary>
        /// Actualiza la informacion de una oferta en la base de datos.
        /// </summary>
        /// <param name="jobOffer">Objeto con la informacion de la oferta</param>
        /// <returns><c>True</c> si realiza la actualizacion de forma exitosa</returns>
        public bool UpdateJobOffer(JobOffer jobOffer)
        {
            try
            {
                modelContext.JobOffers.Update(jobOffer);
                modelContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion

        #region DeleteJobOffer
        /// <summary>
        /// Elimina una oferta de la base de datos.
        /// </summary>
        /// <param name="id">Identificador de la oferta</param>
        /// <returns><c>True</c> si realiza la eliminacion de forma exitosa</returns>
        public bool DeleteJobOffer(int id)
        {
            var jobOffer = modelContext.JobOffers.Find(id);
            if (jobOffer != null)
            {
                try
                {
                    jobOffer.IsDeleted = true;
                    jobOffer.UpdatedAt = DateTime.Now;
                    modelContext.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            return false;
        }
        #endregion

        #endregion
    }
}


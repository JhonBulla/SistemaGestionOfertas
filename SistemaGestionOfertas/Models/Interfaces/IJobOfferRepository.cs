using SistemaGestionOfertas.Models.JobOffers;

namespace SistemaGestionOfertas.Models.Interfaces
{
    /// <summary>
    /// Interfaz que define las operaciones disponibles para acceder y manipular los datos de la oferta en el repositorio.
    /// </summary>
    public interface IJobOfferRepository
    {
        #region GetJobOffers
        /// <summary>
        /// Obtiene todas las ofertas de la base de datos.
        /// </summary>
        /// <returns>Colección de ofertas de la base de datos.</returns>
        IEnumerable<JobOffer> GetJobOffers();
        #endregion

        #region GetJobOfferById
        /// <summary>
        /// Obtiene una oferta de la base de datos por el Id.
        /// </summary>
        /// <returns>Oferta de la base de datos.</returns>
        JobOffer? GetJobOfferById(int id);
        #endregion

        #region AddJobOffer
        /// <summary>
        /// Agrega una nueva oferta en la base de datos.
        /// </summary>
        /// <param name="jobOffer">Objeto con la informacion de la oferta</param>
        /// <returns><c>True</c> si realiza la insercion de forma exitosa</returns>
        bool AddJobOffer(JobOffer jobOffer);
        #endregion

        #region UpdateJobOffer
        /// <summary>
        /// Actualiza la informacion de una oferta en la base de datos.
        /// </summary>
        /// <param name="jobOffer">Objeto con la informacion de la oferta</param>
        /// <returns><c>True</c> si realiza la actualizacion de forma exitosa</returns>
        bool UpdateJobOffer(JobOffer jobOffer);
        #endregion

        #region DeleteJobOffer
        /// <summary>
        /// Elimina una oferta de la base de datos.
        /// </summary>
        /// <param name="id">Identificador de la oferta</param>
        /// <returns><c>True</c> si realiza la eliminacion de forma exitosa</returns>
        bool DeleteJobOffer(int id);
        #endregion
    }
}

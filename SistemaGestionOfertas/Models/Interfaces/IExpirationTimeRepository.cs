using SistemaGestionOfertas.Models.JobOffers;

namespace SistemaGestionOfertas.Models.Interfaces
{
    /// <summary>
    /// Define las operaciones de acceso a datos para la entidad tiempo de expiración de las ofertas.
    /// </summary>
    public interface IExpirationTimeRepository
    {
        #region GetExpirationTimes
        /// <summary>
        /// Obtiene todos los tiempos de expiración activos.
        /// </summary>
        /// <returns>Una colección de ExpirationTime.</returns>
        IEnumerable<ExpirationTime> GetExpirationTimes();
        #endregion

        #region GetExpirationTimeById
        /// <summary>
        /// Obtiene un tiempo de expiración por su identificador.
        /// </summary>
        /// <param name="id">Identificador del tiempo de expiración.</param>
        /// <returns>Objeto ExpirationTime o null si no existe.</returns>
        ExpirationTime? GetExpirationTimeById(int id);
        #endregion
    }
}

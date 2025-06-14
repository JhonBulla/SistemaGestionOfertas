using SistemaGestionOfertas.Data;
using SistemaGestionOfertas.Models.Interfaces;
using SistemaGestionOfertas.Models.JobOffers;

namespace SistemaGestionOfertas.Models.Repository
{
    /// <summary>
    /// Gestiona el acceso de los datos de tiempo de expiracion de las ofertas en la base de datos.
    /// </summary>
    public class ExpirationTimeRepository : IExpirationTimeRepository
    {
        #region Properties
        /// <summary>
        /// Contexto de la base de datos utilizada.
        /// </summary>
        private readonly ModelContext modelContext;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor que inicializa una nueva instancia de ExpirationTimeRepository.
        /// </summary>
        /// <param name="modelContext">Contexto de base de datos.</param>
        public ExpirationTimeRepository(ModelContext modelContext)
        {
            this.modelContext = modelContext;
        }
        #endregion

        #region GetExpirationTimes
        /// <summary>
        /// Obtiene todos los tiempos de expiración activos.
        /// </summary>
        /// <returns>Una colección de ExpirationTime.</returns>
        public IEnumerable<ExpirationTime> GetExpirationTimes()
        {
            return modelContext.ExpirationTimes.Where(x => !x.IsDeleted).ToList();
        }
        #endregion

        #region GetExpirationTimeById
        /// <summary>
        /// Obtiene un tiempo de expiración por su identificador.
        /// </summary>
        /// <param name="id">Identificador del tiempo de expiración.</param>
        /// <returns>Objeto ExpirationTime o null si no existe.</returns>
        public ExpirationTime? GetExpirationTimeById(int id)
        {
            return modelContext.ExpirationTimes.FirstOrDefault(x => x.Id == id && !x.IsDeleted);
        }
        #endregion
    }
}

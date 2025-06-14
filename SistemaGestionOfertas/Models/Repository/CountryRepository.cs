using SistemaGestionOfertas.Data;
using SistemaGestionOfertas.Models.Interfaces;
using SistemaGestionOfertas.Models.JobOffers;

namespace SistemaGestionOfertas.Models.Repository
{
    /// <summary>
    /// Gestiona el acceso de los datos de los paises en la base de datos.
    /// </summary>
    public class CountryRepository : ICountryRepository
    {
        #region Properties
        /// <summary>
        /// Contexto de la base de datos utilizada.
        /// </summary>
        private readonly ModelContext modelContext;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor que inicializa una nueva instancia de CountryRepository.
        /// </summary>
        /// <param name="modelContext">Contexto de base de datos.</param>
        public CountryRepository(ModelContext modelContext)
        {
            this.modelContext = modelContext;
        }
        #endregion

        #region GetCountry
        /// <summary>
        /// Obtiene todos los paises que no están marcados como eliminados.
        /// </summary>
        /// <returns>Una colección de paises.</returns>
        public IEnumerable<Country> GetCountries()
        {
            return modelContext.Countries.Where(x => !x.IsDeleted).OrderBy(x => x.Name).ToList();
        }
        #endregion

        #region GetCountryById
        /// <summary>
        /// Obtiene un país por su identificador.
        /// </summary>
        /// <param name="id">Identificador único del país.</param>
        /// <returns>El país correspondiente al identificador, o null si no se encuentra.</returns>
        public Country? GetCountryById(int id)
        {
            return modelContext.Countries.FirstOrDefault(x => x.Id == id && !x.IsDeleted);
        }
        #endregion
    }
}

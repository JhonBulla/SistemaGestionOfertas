using Microsoft.EntityFrameworkCore;
using SistemaGestionOfertas.Data;
using SistemaGestionOfertas.Models.Interfaces;
using SistemaGestionOfertas.Models.JobOffers;

namespace SistemaGestionOfertas.Models.Repository
{
    /// <summary>
    /// Gestiona el acceso de los datos de las ciudades en la base de datos.
    /// </summary>
    public class CityRepository : ICityRepository
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
        public CityRepository(ModelContext modelContext)
        {
            this.modelContext = modelContext;
        }
        #endregion

        #region GetCities
        /// <summary>
        /// Obtiene todas las ciudades que no están marcadas como eliminadas.
        /// </summary>
        /// <returns>Una colección de ciudades.</returns>
        public IEnumerable<City> GetCities()
        {
            return modelContext.Cities.Include(x => x.Department).Where(x => !x.IsDeleted).OrderBy(x => x.Name).ToList();
        }
        #endregion

        #region GetCityById
        /// <summary>
        /// Obtiene una ciudad por su identificador.
        /// </summary>
        /// <param name="id">Identificador único de la ciudad.</param>
        /// <returns>La ciudad correspondiente al identificador, o null si no se encuentra.</returns>
        public City? GetCityById(int id)
        {
            return modelContext.Cities.Include(x => x.Department).FirstOrDefault(x => x.Id == id && !x.IsDeleted);
        }
        #endregion

        #region GetByDepartmentId
        /// <summary>
        /// Obtiene las ciudades por el identificador del departamento.
        /// </summary>
        /// <param name="idDepartment">Identificador del departamento.</param>
        /// <returns>Lista de ciudades que pertenecen al departamento.</returns>
        public IEnumerable<City> GetByDepartmentId(int idDepartment)
        {
            return modelContext.Cities.Where(x => x.IdDepartment == idDepartment && !x.IsDeleted).OrderBy(d => d.Name).ToList();
        }
        #endregion
    }
}

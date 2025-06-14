using Microsoft.EntityFrameworkCore;
using SistemaGestionOfertas.Data;
using SistemaGestionOfertas.Models.Interfaces;
using SistemaGestionOfertas.Models.JobOffers;

namespace SistemaGestionOfertas.Models.Repository
{
    /// <summary>
    /// Gestiona el acceso de los datos de los departamentos en la base de datos.
    /// </summary>
    public class DepartmentRepository : IDepartmentRepository
    {
        #region Properties
        /// <summary>
        /// Contexto de la base de datos utilizada.
        /// </summary>
        private readonly ModelContext modelContext;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor que inicializa una nueva instancia de DepartmentRepository.
        /// </summary>
        /// <param name="modelContext">Contexto de base de datos.</param>
        public DepartmentRepository(ModelContext modelContext)
        {
            this.modelContext = modelContext;
        }
        #endregion

        #region GetDepartments
        /// <summary>
        /// Obtiene todos los departamentos que no están marcados como eliminadas.
        /// </summary>
        /// <returns>Una colección de ciudades.</returns>
        public IEnumerable<Department> GetDepartments()
        {
            return modelContext.Departments.Include(x => x.Country).Where(x => !x.IsDeleted).OrderBy(x => x.Name).ToList();
        }
        #endregion

        #region GetDepartmentById
        /// <summary>
        /// Obtiene un departamento por su identificador.
        /// </summary>
        /// <param name="id">Identificador único del departamento.</param>
        /// <returns>El departamento correspondiente al identificador, o null si no se encuentra.</returns>
        public Department? GetDepartmentById(int id)
        {
            return modelContext.Departments.Include(x => x.Country).FirstOrDefault(x => x.Id == id && !x.IsDeleted);
        }
        #endregion

        #region GetByCountryId
        /// <summary>
        /// Obtiene los departamentos por el identificador del país.
        /// </summary>
        /// <param name="idCountry">Identificador del país.</param>
        /// <returns>Lista de departamentos que pertenecen al país.</returns>
        public IEnumerable<Department> GetByCountryId(int idCountry)
        {
            return modelContext.Departments.Where(x => x.Idcountry == idCountry && !x.IsDeleted).OrderBy(d => d.Name).ToList();
        }
        #endregion
    }
}

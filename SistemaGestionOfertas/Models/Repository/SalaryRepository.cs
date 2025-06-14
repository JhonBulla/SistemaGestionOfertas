using Microsoft.EntityFrameworkCore;
using SistemaGestionOfertas.Data;
using SistemaGestionOfertas.Models.Interfaces;
using SistemaGestionOfertas.Models.JobOffers;

namespace SistemaGestionOfertas.Models.Repository
{
    /// <summary>
    /// Gestiona el acceso de los datos de salario en la base de datos.
    /// </summary>
    public class SalaryRepository : ISalaryRepository
    {
        #region Properties
        /// <summary>
        /// Contexto de la base de datos utilizada.
        /// </summary>
        private readonly ModelContext modelContext;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor que inicializa una nueva instancia de SalaryRepository.
        /// </summary>
        /// <param name="modelContext">Contexto de base de datos.</param>
        public SalaryRepository(ModelContext modelContext)
        {
            this.modelContext = modelContext;
        }
        #endregion

        #region GetSalaries
        /// <summary>
        /// Obtiene todos los rangos salariales no eliminados.
        /// </summary>
        /// <returns>Lista de rangos salariales válidos.</returns>
        public IEnumerable<Salary> GetSalaries()
        {
            return modelContext.Salaries.Where(x => !x.IsDeleted).ToList();
        }
        #endregion

        #region GetBySalaryId
        /// <summary>
        /// Obtiene un rango salarial por su identificador.
        /// </summary>
        /// <param name="id">Identificador único del rango salarial.</param>
        /// <returns>El rango salarial correspondiente, o null si no se encuentra.</returns>
        public Salary? GetBySalaryId(int id)
        {
            return modelContext.Salaries.FirstOrDefault(x => x.Id == id && !x.IsDeleted);
        }
        #endregion
    }
}

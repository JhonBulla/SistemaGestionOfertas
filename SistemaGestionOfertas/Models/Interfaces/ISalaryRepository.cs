using SistemaGestionOfertas.Models.JobOffers;

namespace SistemaGestionOfertas.Models.Interfaces
{
    /// <summary>
    /// Define las operaciones de acceso a datos para la entidad Salary.
    /// </summary>
    public interface ISalaryRepository
    {
        #region GetSalaries
        /// <summary>
        /// Obtiene todos los rangos salariales no eliminados.
        /// </summary>
        /// <returns>Lista de rangos salariales válidos.</returns>
        IEnumerable<Salary> GetSalaries();
        #endregion

        #region GetBySalaryId
        /// <summary>
        /// Obtiene un rango salarial por su identificador.
        /// </summary>
        /// <param name="id">Identificador único del rango salarial.</param>
        /// <returns>El rango salarial correspondiente, o null si no se encuentra.</returns>
        Salary? GetBySalaryId(int id);
        #endregion
    }
}

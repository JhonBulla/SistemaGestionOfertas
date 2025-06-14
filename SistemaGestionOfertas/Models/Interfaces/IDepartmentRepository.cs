using SistemaGestionOfertas.Models.JobOffers;

namespace SistemaGestionOfertas.Models.Interfaces
{
    /// <summary>
    /// Interfaz que define las operaciones de acceso a datos para la entidad Department.
    /// </summary>
    public interface IDepartmentRepository
    {
        #region GetDepartments
        /// <summary>
        /// Obtiene todos los departamentos que no están marcados como eliminados.
        /// </summary>
        /// <returns>Una colección de departamentos.</returns>
        IEnumerable<Department> GetDepartments();
        #endregion

        #region GetDepartmentById
        /// <summary>
        /// Obtiene un departamento por su identificador.
        /// </summary>
        /// <param name="id">Identificador único del departamento.</param>
        /// <returns>El departamento correspondiente al identificador, o null si no se encuentra.</returns>
        Department? GetDepartmentById(int id);
        #endregion

        #region GetByCountryId
        /// <summary>
        /// Obtiene los departamentos por el identificador del país.
        /// </summary>
        /// <param name="idCountry">Identificador del país.</param>
        /// <returns>Lista de departamentos que pertenecen al país.</returns>
        IEnumerable<Department> GetByCountryId(int idCountry);
        #endregion
    }
}

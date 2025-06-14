using SistemaGestionOfertas.Models.JobOffers;

namespace SistemaGestionOfertas.Models.Interfaces
{
    /// <summary>
    /// Interfaz que define las operaciones de acceso a datos para la entidad City.
    /// </summary>
    public interface ICityRepository
    {
        #region GetCities
        /// <summary>
        /// Obtiene todas las ciudades que no están marcadas como eliminadas.
        /// </summary>
        /// <returns>Una colección de ciudades.</returns>
        IEnumerable<City> GetCities();
        #endregion

        #region GetCityById
        /// <summary>
        /// Obtiene una ciudad por su identificador.
        /// </summary>
        /// <param name="id">Identificador único de la ciudad.</param>
        /// <returns>La ciudad correspondiente al identificador, o null si no se encuentra.</returns>
        City? GetCityById(int id);
        #endregion

        #region GetByDepartmentId
        /// <summary>
        /// Obtiene las ciudades por el identificador del departamento.
        /// </summary>
        /// <param name="idDepartment">Identificador del departamento.</param>
        /// <returns>Lista de ciudades que pertenecen al departamento.</returns>
        IEnumerable<City> GetByDepartmentId(int idDepartment);
        #endregion
    }
}

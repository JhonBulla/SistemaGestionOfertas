using SistemaGestionOfertas.Models.JobOffers;

namespace SistemaGestionOfertas.Models.Interfaces
{
    /// <summary>
    /// Interfaz que define las operaciones de acceso a datos para la entidad Country.
    /// </summary>
    public interface ICountryRepository
    {
        #region GetCountry
        /// <summary>
        /// Obtiene todos los paises que no están marcados como eliminados.
        /// </summary>
        /// <returns>Una colección de paises.</returns>
        IEnumerable<Country> GetCountries();
        #endregion

        #region GetCountryById
        /// <summary>
        /// Obtiene un país por su identificador.
        /// </summary>
        /// <param name="id">Identificador único del país.</param>
        /// <returns>El país correspondiente al identificador, o null si no se encuentra.</returns>
        Country? GetCountryById(int id);
        #endregion
    }
}

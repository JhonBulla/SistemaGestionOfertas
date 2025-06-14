using SistemaGestionOfertas.Models.JobOffers;

namespace SistemaGestionOfertas.Models.Interfaces
{
    /// <summary>
    /// Define las operaciones de acceso a datos para la entidad ContractType.
    /// </summary>
    public interface IContractTypeRepository
    {
        #region GetContractType
        /// <summary>
        /// Obtiene todos los tipos de contrato que no están marcados como eliminados.
        /// </summary>
        /// <returns>Una colección de tipos de contrato.</returns>
        IEnumerable<ContractType> GetContractType();
        #endregion

        #region GetContractTypeById
        /// <summary>
        /// Obtiene un tipo de contrato por su identificador.
        /// </summary>
        /// <param name="id">Identificador único del tipo de contrato.</param>
        /// <returns>El tipo de contrato correspondiente al identificador, o null si no se encuentra.</returns>
        ContractType? GetContractTypeById(int id);
        #endregion
    }
}

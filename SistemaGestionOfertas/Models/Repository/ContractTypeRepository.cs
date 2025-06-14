using SistemaGestionOfertas.Data;
using SistemaGestionOfertas.Models.Interfaces;
using SistemaGestionOfertas.Models.JobOffers;

namespace SistemaGestionOfertas.Models.Repository
{
    /// <summary>
    /// Gestiona el acceso de los datos de los tipos de contrato en la base de datos.
    /// </summary>
    public class ContractTypeRepository : IContractTypeRepository
    {
        #region Properties
        /// <summary>
        /// Contexto de la base de datos utilizada.
        /// </summary>
        private readonly ModelContext modelContext;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor que inicializa una nueva instancia de ContractTypeRepository.
        /// </summary>
        /// <param name="modelContext">Contexto de base de datos.</param>
        public ContractTypeRepository(ModelContext modelContext)
        {
            this.modelContext = modelContext;
        }
        #endregion

        #region GetContractType
        /// <summary>
        /// Obtiene todos los tipos de contrato que no están marcados como eliminados.
        /// </summary>
        /// <returns>Una colección de tipos de contrato.</returns>
        public IEnumerable<ContractType> GetContractType()
        {
            return this.modelContext.ContractTypes.Where(x => !x.IsDeleted).OrderBy(x => x.Name).ToList();
        }
        #endregion

        #region GetContractTypeById
        /// <summary>
        /// Obtiene un tipo de contrato por su identificador.
        /// </summary>
        /// <param name="id">Identificador único del tipo de contrato.</param>
        /// <returns>El tipo de contrato correspondiente al identificador, o null si no se encuentra.</returns>
        public ContractType? GetContractTypeById(int id)
        {
            return modelContext.ContractTypes.FirstOrDefault(x => x.Id == id && !x.IsDeleted);
        }
        #endregion
    }
}

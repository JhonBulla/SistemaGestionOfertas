using Microsoft.EntityFrameworkCore;
using SistemaGestionOfertas.Models.DTO;
using SistemaGestionOfertas.Models.JobOffers;
using SistemaGestionOfertas.Models.Users;

namespace SistemaGestionOfertas.Data
{
    /// <summary>
    /// Contexto de base de datos para el sistema de gestión de usuarios.
    /// </summary>
    public class ModelContext : DbContext
    {
        /// <summary>
        /// Constructor de la clase ModelContext.
        /// </summary>
        /// <param name="options">Opciones de configuración del contexto de base de datos.</param>
        public ModelContext(DbContextOptions<ModelContext> options) : base(options)
        {
        }

        /// <summary>
        /// Conjunto de entidades de usuarios en la base de datos.
        /// </summary>
        public virtual DbSet<User> Users { get; set; }

        /// <summary>
        /// Representa el conjunto de entidades de tipo UserDto en el contexto de la base de datos.
        /// </summary>
        public DbSet<SistemaGestionOfertas.Models.DTO.UserDto> UserDto { get; set; } = default!;

        /// <summary>
        /// Conjunto de entidades de paises en la base de datos.
        /// </summary>
        public DbSet<Country> Countries { get; set; }
        /// <summary>
        /// Conjunto de entidades de departamentos en la base de datos.
        /// </summary>
        public DbSet<Department> Departments { get; set; }
        /// <summary>
        /// Conjunto de entidades de ciudades en la base de datos.
        /// </summary>
        public DbSet<City> Cities { get; set; }
        /// <summary>
        /// Conjunto de entidades de tipo de contrato de la oferta en la base de datos.
        /// </summary>
        public DbSet<ContractType> ContractTypes { get; set; }
        /// <summary>
        /// Conjunto de entidades de tiempo de expiracion de la oferta en la base de datos.
        /// </summary>
        public DbSet<ExpirationTime> ExpirationTimes { get; set; }
        /// <summary>
        /// Conjunto de entidades de salarios en la base de datos.
        /// </summary>
        public DbSet<Salary> Salaries { get; set; }

        /// <summary>
        /// Conjunto de entidades de ofertas en la base de datos.
        /// </summary>
        public virtual DbSet<JobOffer> JobOffers { get; set; }

        /// <summary>
        /// Representa el conjunto de entidades de tipo JobOfferDto en el contexto de la base de datos.
        /// </summary>
        public DbSet<SistemaGestionOfertas.Models.DTO.JobOfferDto> jobOfferDto { get; set; } = default!;
    }
}

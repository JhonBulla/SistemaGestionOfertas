using SistemaGestionOfertas.Data;
using SistemaGestionOfertas.Models.Users;

namespace SistemaGestionOfertas.Models.Interfaces
{
    /// <summary>
    /// Interfaz que define las operaciones disponibles para acceder y manipular los datos de usuarios en el repositorio.
    /// </summary>
    public interface IUserRepository
    {
        #region GetUsers
        /// <summary>
        /// Obtiene todos los usuarios en la base de datos.
        /// </summary>
        /// <returns>Coleccion de usuarios de la base de datos.</returns>
        public IEnumerable<User> GetUsers();
        #endregion

        #region GetUserById
        /// <summary>
        /// Obtiene un usuario de la base de datos por el Id.
        /// </summary>
        /// <returns>Usuario de la base de datos.</returns>
        public User? GetUserById(int Id);
        #endregion

        #region ValidateUser
        /// <summary>
        /// Obtiene un usuario valido por correeo y contraseña de la base de datos.
        /// </summary>
        /// <returns>Usuario de la base de datos.</returns>
        public User? ValidateUser(string Email, string Password);
        #endregion

        #region AddUser
        /// <summary>
        /// Agrega a un nuevo usuario en la base de datos.
        /// </summary>
        /// <param name="userdata">Objeto con la informacion del usuario</param>
        /// <returns><c>True</c> si realiza la insercion de forma exitosa</returns>
        public bool AddUser(User userdata);
        #endregion

        #region UpdateUser
        /// <summary>
        /// Actualiza la informacion de un usuario en la base de datos.
        /// </summary>
        /// <param name="userdata">Objeto con la informacion del usuario</param>
        /// <returns><c>True</c> si realiza la actualizacion de forma exitosa</returns>
        public bool UpdateUser(User userdata);
        #endregion

        #region DeleteUser
        /// <summary>
        /// Elimina a un usuario de la base de datos.
        /// </summary>
        /// <param name="iduser">Identificador del usuario</param>
        /// <returns><c>True</c> si realiza la eliminacion de forma exitosa</returns>
        public bool DeleteUser(int iduser);
        #endregion

    }
}

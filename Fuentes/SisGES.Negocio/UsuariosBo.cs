namespace SisGES.Negocio
{
    using System.Collections.Generic;
    using Entidades;
    using Datos;

    /// <summary>
    /// Clase de negocio para usuarios
    /// </summary>
    public class UsuariosBo
    {
        /// <summary>
        /// Método que almacena un usuario
        /// </summary>
        /// <param name="usuario">Datos del usuario</param>
        /// <returns>Id de ingreso</returns>
        public int CrearUsuario(GEN_Usuarios usuario)
        {
            return new UsuariosDa().CrearUsuario(usuario);
        }

        /// <summary>
        /// Método que obtiene un usuario
        /// </summary>
        /// <param name="rutUsuario">RUT del usuario</param>
        /// <returns>Usuario</returns>
        public GEN_Usuarios ObtenerUsuario(int rutUsuario)
        {
            return new UsuariosDa().ObtenerUsuario(rutUsuario);            
        }

        /// <summary>
        /// Método que obtiene todos los usuarios
        /// </summary>
        /// <returns>Lista de usuarios</returns>
        public List<GEN_Usuarios> ObtenerUsuarios()
        {
            return new UsuariosDa().ObtenerUsuarios();            
        }

        /// <summary>
        /// Método que actualiza un usuario
        /// </summary>
        /// <param name="usuario">Datos del usuario</param>
        /// <returns>Id de actualización</returns>
        public int ActualizarUsuario(GEN_Usuarios usuario)
        {
            return new UsuariosDa().ActualizarUsuario(usuario);            
        }

        /// <summary>
        /// Método que elimina un usuario
        /// </summary>
        /// <param name="rutUsuario">RUT del usuario</param>
        /// <returns>Id de confirmación</returns>
        public int EliminarUsuario(int rutUsuario)
        {
            return new UsuariosDa().EliminarUsuario(rutUsuario);            
        }

        public bool ValidarAcceso(string rut, string clave)
        {
            rut = rut.ToUpper();
            rut = rut.Replace(".", "");
            rut = rut.Replace("-", "");
            return clave.Equals(ObtenerUsuario(int.Parse(rut.Substring(0, rut.Length - 1))).Clave);
        }
    }
}

namespace SisGES.Negocio
{
    using System.Collections.Generic;
    using Entidades;
    using Datos;

    /// <summary>
    /// Clase de negocio para roles
    /// </summary>
    public class RolesBo
    {
        /// <summary>
        /// Método que almacena un rol
        /// </summary>
        /// <param name="rol">Datos del rol</param>
        /// <returns>Id de ingreso</returns>
        public int CrearRol(GEN_Rol rol)
        {
            return new RolesDa().CrearRol(rol);
        }

        /// <summary>
        /// Método que obtiene un rol
        /// </summary>
        /// <param name="idRol">ID del rol</param>
        /// <returns>Rol</returns>
        public GEN_Rol ObtenerRol(int idRol)
        {
            return new RolesDa().ObtenerRol(idRol);            
        }

        /// <summary>
        /// Método que obtiene todos los roles
        /// </summary>
        /// <returns>Lista de roles</returns>
        public List<GEN_Rol> ObtenerRoles()
        {
            return new RolesDa().ObtenerRoles();            
        }

        /// <summary>
        /// Método que actualiza un rol
        /// </summary>
        /// <param name="rol">Datos del rol</param>
        /// <returns>Id de actualización</returns>
        public int ActualizarRol(GEN_Rol rol)
        {
            return new RolesDa().ActualizarRol(rol);            
        }

        /// <summary>
        /// Método que elimina un rol
        /// </summary>
        /// <param name="idRol">ID del rol</param>
        /// <returns>Id de confirmación</returns>
        public int EliminarRol(int idRol)
        {
            return new RolesDa().EliminarRol(idRol);            
        }
    }
}

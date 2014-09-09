using System.Data.Entity.Migrations;

namespace SisGES.Datos
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Entidades;

    /// <summary>
    /// Clase de datos para roles
    /// </summary>
    public class RolesDa
    {
        /// <summary>
        /// Entidades de SisGEN
        /// </summary>
        private readonly SisGENEntities _sisGESEntities;

        /// <summary>
        /// Método que inicializa las entidades
        /// </summary>
        public RolesDa()
        {
            if (_sisGESEntities == null)
                _sisGESEntities = new SisGENEntities();
        }

        /// <summary>
        /// Método que almacena un rol
        /// </summary>
        /// <param name="rol">Datos del role</param>
        /// <returns>Id de ingreso</returns>
        public int CrearRol(GEN_Rol rol)
        {
            var idRetorno = 0;
            try
            {
                _sisGESEntities.GEN_Rol.AddOrUpdate(rol);
                idRetorno = _sisGESEntities.SaveChanges();
                _sisGESEntities.Dispose();
                return idRetorno;
            }
            catch (Exception)
            {
                return idRetorno;
            }
        }

        /// <summary>
        /// Método que obtiene un rol
        /// </summary>
        /// <param name="idRol">Id del role</param>
        /// <returns>Role</returns>
        public GEN_Rol ObtenerRol(int idRol)
        {
            var retorno = new GEN_Rol();
            try
            {
                retorno = _sisGESEntities.GEN_Rol.Single(tc => tc.IdRol == idRol);
                _sisGESEntities.Dispose();
                return retorno;
            }
            catch (Exception)
            {
                return retorno;
            }
        }

        /// <summary>
        /// Método que obtiene todos los roles
        /// </summary>
        /// <returns>Lista de roles</returns>
        public List<GEN_Rol> ObtenerRoles()
        {
            var listaRetorno = new List<GEN_Rol>();
            try
            {
                listaRetorno = _sisGESEntities.GEN_Rol.ToList();
                _sisGESEntities.Dispose();
                return listaRetorno;
            }
            catch (Exception)
            {
                return listaRetorno;
            }
        }

        /// <summary>
        /// Método que actualiza un rol
        /// </summary>
        /// <param name="rol">Datos del rol</param>
        /// <returns>Id de actualización</returns>
        public int ActualizarRol(GEN_Rol rol)
        {
            var idRetorno = 0;
            try
            {
                _sisGESEntities.GEN_Rol.AddOrUpdate(rol);
                idRetorno = _sisGESEntities.SaveChanges();
                _sisGESEntities.Dispose();
                return idRetorno;
            }
            catch (Exception)
            {
                return idRetorno;
            }
        }

        /// <summary>
        /// Método que elimina un rol
        /// </summary>
        /// <param name="idRol">Id del rol</param>
        /// <returns>Id de confirmación</returns>
        public int EliminarRol(int idRol)
        {
            var idRetorno = 0;
            try
            {
                var rolEliminar = new GEN_Rol { IdRol = idRetorno };
                _sisGESEntities.GEN_Rol.Attach(rolEliminar);
                _sisGESEntities.GEN_Rol.Remove(rolEliminar);
                idRetorno = _sisGESEntities.SaveChanges();
                _sisGESEntities.Dispose();
                return idRetorno;
            }
            catch (Exception)
            {
                return idRetorno;
            }
        }
    }
}

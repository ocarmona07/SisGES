namespace SisGES.Datos
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Entidades;

    /// <summary>
    /// Clase de datos para usuarios
    /// </summary>
    public class UsuariosDa
    {
        /// <summary>
        /// Entidades de SisGES
        /// </summary>
        private readonly SisGENEntities _sisGESEntities;

        /// <summary>
        /// Método que inicializa las entidades
        /// </summary>
        public UsuariosDa()
        {
            if (_sisGESEntities == null)
                _sisGESEntities = new SisGENEntities();
        }

        /// <summary>
        /// Método que almacena un usuario
        /// </summary>
        /// <param name="usuario">Datos del usuario</param>
        /// <returns>Id de ingreso</returns>
        public int CrearUsuario(GEN_Usuarios usuario)
        {
            var idRetorno = 0;
            try
            {
                _sisGESEntities.GEN_Usuarios.AddOrUpdate(usuario);
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
        /// Método que obtiene un usuario
        /// </summary>
        /// <param name="rutUsuario">RUT del usuario</param>
        /// <returns>Usuario</returns>
        public GEN_Usuarios ObtenerUsuario(int rutUsuario)
        {
            var retorno = new GEN_Usuarios();
            try
            {
                retorno = _sisGESEntities.GEN_Usuarios.Single(tc => tc.RUT == rutUsuario);
                _sisGESEntities.Dispose();
                return retorno;
            }
            catch (Exception)
            {
                return retorno;
            }
        }

        /// <summary>
        /// Método que obtiene todos los usuarios
        /// </summary>
        /// <returns>Lista de usuarios</returns>
        public List<GEN_Usuarios> ObtenerUsuarios()
        {
            var listaRetorno = new List<GEN_Usuarios>();
            try
            {
                listaRetorno = _sisGESEntities.GEN_Usuarios.Include("GEN_Rol").ToList();
                _sisGESEntities.Dispose();
                return listaRetorno;
            }
            catch (Exception)
            {
                return listaRetorno;
            }
        }

        /// <summary>
        /// Método que actualiza un usuario
        /// </summary>
        /// <param name="usuario">Datos del usuario</param>
        /// <returns>Id de actualización</returns>
        public int ActualizarUsuario(GEN_Usuarios usuario)
        {
            var idRetorno = 0;
            try
            {
                _sisGESEntities.GEN_Usuarios.AddOrUpdate(usuario);
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
        /// Método que elimina un usuario
        /// </summary>
        /// <param name="rutUsuario">RUT del usuario</param>
        /// <returns>Id de confirmación</returns>
        public int EliminarUsuario(int rutUsuario)
        {
            var idRetorno = 0;
            try
            {
                var datosEliminar = new GEN_Usuarios { RUT = rutUsuario };
                _sisGESEntities.GEN_Usuarios.Attach(datosEliminar);
                _sisGESEntities.GEN_Usuarios.Remove(datosEliminar);
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

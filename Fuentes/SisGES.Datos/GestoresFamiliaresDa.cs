namespace SisGES.Datos
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Entidades;

    /// <summary>
    /// Clase de datos para Gestores Familiares
    /// </summary>
    public class GestoresFamiliaresDa
    {
        /// <summary>
        /// Entidades de SisGEN
        /// </summary>
        private readonly SisGENEntities _sisGESEntities;

        /// <summary>
        /// Método que inicializa las entidades
        /// </summary>
        public GestoresFamiliaresDa()
        {
            if (_sisGESEntities == null)
                _sisGESEntities = new SisGENEntities();
        }

        /// <summary>
        /// Método que almacena un gestor familiar
        /// </summary>
        /// <param name="gestorFamiliar">Datos del gestor</param>
        /// <returns>Id de ingreso</returns>
        public int CrearGestorFamiliar(GEN_GestoresFamiliares gestorFamiliar)
        {
            var idRetorno = 0;
            try
            {
                _sisGESEntities.GEN_GestoresFamiliares.AddOrUpdate(gestorFamiliar);
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
        /// Método que obtiene un gestor familiar
        /// </summary>
        /// <param name="idGestorFamiliar">Id del gestor</param>
        /// <returns>Gestor Familiar</returns>
        public GEN_GestoresFamiliares ObtenerGestorFamiliar(int idGestorFamiliar)
        {
            var retorno = new GEN_GestoresFamiliares();
            try
            {
                retorno = _sisGESEntities.GEN_GestoresFamiliares.Single(tc => tc.IdGestorFamiliar == idGestorFamiliar);
                _sisGESEntities.Dispose();
                return retorno;
            }
            catch (Exception)
            {
                return retorno;
            }
        }

        /// <summary>
        /// Método que obtiene todos los gestores familiares
        /// </summary>
        /// <returns>Lista de gestores</returns>
        public List<GEN_GestoresFamiliares> ObtenerGestoresFamiliares()
        {
            var listaRetorno = new List<GEN_GestoresFamiliares>();
            try
            {
                listaRetorno = _sisGESEntities.GEN_GestoresFamiliares.ToList();
                _sisGESEntities.Dispose();
                return listaRetorno;
            }
            catch (Exception)
            {
                return listaRetorno;
            }
        }

        /// <summary>
        /// Método que actualiza un gestor familiar
        /// </summary>
        /// <param name="gestorFamiliar">Datos del gestor</param>
        /// <returns>Id de actualización</returns>
        public int ActualizarGestorFamiliar(GEN_GestoresFamiliares gestorFamiliar)
        {
            var idRetorno = 0;
            try
            {
                _sisGESEntities.GEN_GestoresFamiliares.AddOrUpdate(gestorFamiliar);
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
        /// Método que elimina un gestor familiar
        /// </summary>
        /// <param name="idGestorFamiliar">Id del gestor familiar</param>
        /// <returns>Id de confirmación</returns>
        public int EliminarGestorFamiliar(int idGestorFamiliar)
        {
            var idRetorno = 0;
            try
            {
                var datosEliminar = new GEN_GestoresFamiliares { IdGestorFamiliar = idGestorFamiliar };
                _sisGESEntities.GEN_GestoresFamiliares.Attach(datosEliminar);
                _sisGESEntities.GEN_GestoresFamiliares.Remove(datosEliminar);
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

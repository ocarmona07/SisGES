namespace SisGES.Datos
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Entidades;

    /// <summary>
    /// Clase de datos para Estado Civil
    /// </summary>
    public class EstadoCivilDa
    {
        /// <summary>
        /// Entidades de SisGEN
        /// </summary>
        private readonly SisGENEntities _sisGESEntities;

        /// <summary>
        /// Método que inicializa las entidades
        /// </summary>
        public EstadoCivilDa()
        {
            if (_sisGESEntities == null)
                _sisGESEntities = new SisGENEntities();
        }

        /// <summary>
        /// Método que almacena un Estado Civil
        /// </summary>
        /// <param name="estadoCivil">Datos Estado Civil</param>
        /// <returns>Id de ingreso</returns>
        public int CrearEstadoCivil(GEN_EstadoCivil estadoCivil)
        {
            var idRetorno = 0;
            try
            {
                _sisGESEntities.GEN_EstadoCivil.AddOrUpdate(estadoCivil);
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
        /// Método que obtiene un parentesco
        /// </summary>
        /// <param name="idEstadoCivil">Id Estado Civil</param>
        /// <returns>EstadoCivil</returns>
        public GEN_EstadoCivil ObtenerEstadoCivil(int idEstadoCivil)
        {
            var retorno = new GEN_EstadoCivil();
            try
            {
                retorno = _sisGESEntities.GEN_EstadoCivil.Single(o => o.IdEstadoCivil == idEstadoCivil);
                _sisGESEntities.Dispose();
                return retorno;
            }
            catch (Exception)
            {
                return retorno;
            }
        }

        /// <summary>
        /// Método que obtiene todos los Estados Civiles
        /// </summary>
        /// <returns>Lista de parentescos</returns>
        public List<GEN_EstadoCivil> ObtenerEstadosCiviles()
        {
            var listaRetorno = new List<GEN_EstadoCivil>();
            try
            {
                listaRetorno = _sisGESEntities.GEN_EstadoCivil.ToList();
                _sisGESEntities.Dispose();
                return listaRetorno;
            }
            catch (Exception)
            {
                return listaRetorno;
            }
        }

        /// <summary>
        /// Método que actualiza un Estado Civil
        /// </summary>
        /// <param name="estadoCivil">Datos Estado Civil</param>
        /// <returns>Id de actualización</returns>
        public int ActualizarEstadoCivil(GEN_EstadoCivil estadoCivil)
        {
            var idRetorno = 0;
            try
            {
                _sisGESEntities.GEN_EstadoCivil.AddOrUpdate(estadoCivil);
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
        /// Método que elimina un Estado Civil
        /// </summary>
        /// <param name="idEstadoCivil">Id Estado Civil</param>
        /// <returns>Id de confirmación</returns>
        public int EliminarEstadoCivil(int idEstadoCivil)
        {
            var idRetorno = 0;
            try
            {
                var datosEliminar = new GEN_EstadoCivil { IdEstadoCivil = idEstadoCivil };
                _sisGESEntities.GEN_EstadoCivil.Attach(datosEliminar);
                _sisGESEntities.GEN_EstadoCivil.Remove(datosEliminar);
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

namespace SisGES.Datos
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Entidades;

    /// <summary>
    /// Clase de datos para Ocupaciones
    /// </summary>
    public class OcupacionesDa
    {
        /// <summary>
        /// Entidades de SisGEN
        /// </summary>
        private readonly SisGENEntities _sisGESEntities;

        /// <summary>
        /// Método que inicializa las entidades
        /// </summary>
        public OcupacionesDa()
        {
            if (_sisGESEntities == null)
                _sisGESEntities = new SisGENEntities();
        }

        /// <summary>
        /// Método que almacena una ocupacion
        /// </summary>
        /// <param name="ocupacion">Datos Ocupaciones</param>
        /// <returns>Id de ingreso</returns>
        public int CrearOcupacion(INT_Ocupaciones ocupacion)
        {
            var idRetorno = 0;
            try
            {
                _sisGESEntities.INT_Ocupaciones.AddOrUpdate(ocupacion);
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
        /// Método que obtiene una ocupacion
        /// </summary>
        /// <param name="idOcupacion">Id ocupación</param>
        /// <returns>Ocupación</returns>
        public INT_Ocupaciones ObtenerOcupacion(int idOcupacion)
        {
            var retorno = new INT_Ocupaciones();
            try
            {
                retorno = _sisGESEntities.INT_Ocupaciones.Single(o => o.IdOcupacion == idOcupacion);
                _sisGESEntities.Dispose();
                return retorno;
            }
            catch (Exception)
            {
                return retorno;
            }
        }

        /// <summary>
        /// Método que obtiene todas las Ocupaciones
        /// </summary>
        /// <returns>Lista de Ocupaciones</returns>
        public List<INT_Ocupaciones> ObtenerOcupaciones()
        {
            var listaRetorno = new List<INT_Ocupaciones>();
            try
            {
                listaRetorno = _sisGESEntities.INT_Ocupaciones.ToList();
                _sisGESEntities.Dispose();
                return listaRetorno;
            }
            catch (Exception)
            {
                return listaRetorno;
            }
        }

        /// <summary>
        /// Método que actualiza una Ocupación
        /// </summary>
        /// <param name="ocupacion">Datos Ocupación</param>
        /// <returns>Id de actualización</returns>
        public int ActualizarOcupacion(INT_Ocupaciones ocupacion)
        {
            var idRetorno = 0;
            try
            {
                _sisGESEntities.INT_Ocupaciones.AddOrUpdate(ocupacion);
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
        /// Método que elimina una ocupacion
        /// </summary>
        /// <param name="idOcupacion">Id Ocupacion</param>
        /// <returns>Id de confirmación</returns>
        public int EliminarOcupacion(int idOcupacion)
        {
            var idRetorno = 0;
            try
            {
                var datosEliminar = new INT_Ocupaciones { IdOcupacion = idOcupacion };
                _sisGESEntities.INT_Ocupaciones.Attach(datosEliminar);
                _sisGESEntities.INT_Ocupaciones.Remove(datosEliminar);
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

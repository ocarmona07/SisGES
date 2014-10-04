namespace SisGES.Datos
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Entidades;

    /// <summary>
    /// Clase de datos para Niveles de Escolaridad
    /// </summary>
    public class NivelesEscolaridadDa
    {
        /// <summary>
        /// Entidades de SisGEN
        /// </summary>
        private readonly SisGENEntities _sisGESEntities;

        /// <summary>
        /// Método que inicializa las entidades
        /// </summary>
        public NivelesEscolaridadDa()
        {
            if (_sisGESEntities == null)
                _sisGESEntities = new SisGENEntities();
        }

        /// <summary>
        /// Método que almacena un Nivel Escolar
        /// </summary>
        /// <param name="nivelesEscolaridad">Datos Nivel Escolar</param>
        /// <returns>Id de ingreso</returns>
        public int CrearNivelEscolar(INT_NivelesEscolaridad nivelesEscolaridad)
        {
            var idRetorno = 0;
            try
            {
                _sisGESEntities.INT_NivelesEscolaridad.AddOrUpdate(nivelesEscolaridad);
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
        /// Método que obtiene un Nivel Escolar
        /// </summary>
        /// <param name="idNivelEscolar">Id Nivel Escolar</param>
        /// <returns>Nivel de Escolaridad</returns>
        public INT_NivelesEscolaridad ObtenerNivelEscolar(int idNivelEscolar)
        {
            var retorno = new INT_NivelesEscolaridad();
            try
            {
                retorno = _sisGESEntities.INT_NivelesEscolaridad.Single(o => o.IdNivelEscolar == idNivelEscolar);
                _sisGESEntities.Dispose();
                return retorno;
            }
            catch (Exception)
            {
                return retorno;
            }
        }

        /// <summary>
        /// Método que obtiene todos los Niveles Escolaridad
        /// </summary>
        /// <returns>Lista de Niveles de Escolaridad</returns>
        public List<INT_NivelesEscolaridad> ObtenerNivelesEscolaridad()
        {
            var listaRetorno = new List<INT_NivelesEscolaridad>();
            try
            {
                listaRetorno = _sisGESEntities.INT_NivelesEscolaridad.ToList();
                _sisGESEntities.Dispose();
                return listaRetorno;
            }
            catch (Exception)
            {
                return listaRetorno;
            }
        }

        /// <summary>
        /// Método que actualiza un Nivel Escolar
        /// </summary>
        /// <param name="nivelesEscolaridad">Datos Nivel Escolar</param>
        /// <returns>Id de actualización</returns>
        public int ActualizarNivelEscolar(INT_NivelesEscolaridad nivelesEscolaridad)
        {
            var idRetorno = 0;
            try
            {
                _sisGESEntities.INT_NivelesEscolaridad.AddOrUpdate(nivelesEscolaridad);
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
        /// Método que elimina un Nivel Escolar
        /// </summary>
        /// <param name="idNivelEscolar">Id Nivel Escolar</param>
        /// <returns>Id de confirmación</returns>
        public int EliminarNivelEscolar(int idNivelEscolar)
        {
            var idRetorno = 0;
            try
            {
                var datosEliminar = new INT_NivelesEscolaridad { IdNivelEscolar = idNivelEscolar };
                _sisGESEntities.INT_NivelesEscolaridad.Attach(datosEliminar);
                _sisGESEntities.INT_NivelesEscolaridad.Remove(datosEliminar);
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

namespace SisGES.Datos
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Entidades;

    /// <summary>
    /// Clase de datos para integrantes
    /// </summary>
    public class IntegrantesDa
    {
        /// <summary>
        /// Entidades de SisGES
        /// </summary>
        private readonly SisGENEntities _sisGESEntities;

        /// <summary>
        /// Método que inicializa las entidades
        /// </summary>
        public IntegrantesDa()
        {
            if (_sisGESEntities == null)
                _sisGESEntities = new SisGENEntities();
        }

        /// <summary>
        /// Método que almacena un integrante
        /// </summary>
        /// <param name="integrante">Datos del integrante</param>
        /// <returns>Id de ingreso</returns>
        public int CrearIntegrante(INT_Integrantes integrante)
        {
            var idRetorno = 0;
            try
            {
                _sisGESEntities.INT_Integrantes.AddOrUpdate(integrante);
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
        /// Método que obtiene un integrante
        /// </summary>
        /// <param name="rutIntegrante">RUT del integrante</param>
        /// <returns>Integrante</returns>
        public INT_Integrantes ObtenerIntegrante(int rutIntegrante)
        {
            var retorno = new INT_Integrantes();
            try
            {
                retorno = _sisGESEntities.INT_Integrantes.Single(tc => tc.RUT == rutIntegrante);
                _sisGESEntities.Dispose();
                return retorno;
            }
            catch (Exception)
            {
                return retorno;
            }
        }

        /// <summary>
        /// Método que obtiene todos los integrantes
        /// </summary>
        /// <returns>Lista de integrantes</returns>
        public List<INT_Integrantes> ObtenerIntegrantes()
        {
            var listaRetorno = new List<INT_Integrantes>();
            try
            {
                listaRetorno = _sisGESEntities.INT_Integrantes.ToList();
                _sisGESEntities.Dispose();
                return listaRetorno;
            }
            catch (Exception)
            {
                return listaRetorno;
            }
        }

        /// <summary>
        /// Método que actualiza un integrante
        /// </summary>
        /// <param name="integrante">Datos del integrante</param>
        /// <returns>Id de actualización</returns>
        public int ActualizarIntegrante(INT_Integrantes integrante)
        {
            var idRetorno = 0;
            try
            {
                _sisGESEntities.INT_Integrantes.AddOrUpdate(integrante);
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
        /// Método que elimina un integrante
        /// </summary>
        /// <param name="rutIntegrante">RUT del integrante</param>
        /// <returns>Id de confirmación</returns>
        public int EliminarIntegrante(int rutIntegrante)
        {
            var idRetorno = 0;
            try
            {
                var datosEliminar = new INT_Integrantes { RUT = rutIntegrante };
                _sisGESEntities.INT_Integrantes.Attach(datosEliminar);
                _sisGESEntities.INT_Integrantes.Remove(datosEliminar);
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

namespace SisGES.Datos
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Entidades;

    /// <summary>
    /// Clase de datos para Parentescos
    /// </summary>
    public class ParentescosDa
    {
        /// <summary>
        /// Entidades de SisGEN
        /// </summary>
        private readonly SisGENEntities _sisGESEntities;

        /// <summary>
        /// Método que inicializa las entidades
        /// </summary>
        public ParentescosDa()
        {
            if (_sisGESEntities == null)
                _sisGESEntities = new SisGENEntities();
        }

        /// <summary>
        /// Método que almacena un parentesco
        /// </summary>
        /// <param name="parentesco">Datos parentescos</param>
        /// <returns>Id de ingreso</returns>
        public int CrearParentesco(GEN_Parentescos parentesco)
        {
            var idRetorno = 0;
            try
            {
                _sisGESEntities.GEN_Parentescos.AddOrUpdate(parentesco);
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
        /// <param name="idParentesco">Id parentesco</param>
        /// <returns>Parentesco</returns>
        public GEN_Parentescos ObtenerParentesco(int idParentesco)
        {
            var retorno = new GEN_Parentescos();
            try
            {
                retorno = _sisGESEntities.GEN_Parentescos.Single(o => o.IdParentesco == idParentesco);
                _sisGESEntities.Dispose();
                return retorno;
            }
            catch (Exception)
            {
                return retorno;
            }
        }

        /// <summary>
        /// Método que obtiene todos los parentescos
        /// </summary>
        /// <returns>Lista de parentescos</returns>
        public List<GEN_Parentescos> ObtenerParentescos()
        {
            var listaRetorno = new List<GEN_Parentescos>();
            try
            {
                listaRetorno = _sisGESEntities.GEN_Parentescos.ToList();
                _sisGESEntities.Dispose();
                return listaRetorno;
            }
            catch (Exception)
            {
                return listaRetorno;
            }
        }

        /// <summary>
        /// Método que actualiza un Parentesco
        /// </summary>
        /// <param name="parentesco">Datos Parentesco</param>
        /// <returns>Id de actualización</returns>
        public int ActualizarParentesco(GEN_Parentescos parentesco)
        {
            var idRetorno = 0;
            try
            {
                _sisGESEntities.GEN_Parentescos.AddOrUpdate(parentesco);
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
        /// Método que elimina un parentesco
        /// </summary>
        /// <param name="idParentesco">Id Parentesco</param>
        /// <returns>Id de confirmación</returns>
        public int EliminarParentesco(int idParentesco)
        {
            var idRetorno = 0;
            try
            {
                var datosEliminar = new GEN_Parentescos { IdParentesco = idParentesco };
                _sisGESEntities.GEN_Parentescos.Attach(datosEliminar);
                _sisGESEntities.GEN_Parentescos.Remove(datosEliminar);
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

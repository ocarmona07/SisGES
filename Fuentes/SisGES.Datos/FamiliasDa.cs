namespace SisGES.Datos
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Entidades;

    /// <summary>
    /// Clase de datos para Familias
    /// </summary>
    public class FamiliasDa
    {
        /// <summary>
        /// Entidades de SisGEN
        /// </summary>
        private readonly SisGENEntities _sisGESEntities;

        /// <summary>
        /// Método que inicializa las entidades
        /// </summary>
        public FamiliasDa()
        {
            if (_sisGESEntities == null)
                _sisGESEntities = new SisGENEntities();
        }

        /// <summary>
        /// Método que almacena una familia
        /// </summary>
        /// <param name="familia">Datos Familias</param>
        /// <returns>Id de ingreso</returns>
        public int CrearFamilia(FAM_Familias familia)
        {
            var idRetorno = 0;
            try
            {
                _sisGESEntities.FAM_Familias.AddOrUpdate(familia);
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
        /// Método que obtiene una familia
        /// </summary>
        /// <param name="idFamilia">Id familia</param>
        /// <returns>Familia</returns>
        public FAM_Familias ObtenerFamilia(int idFamilia)
        {
            var retorno = new FAM_Familias();
            try
            {
                retorno = _sisGESEntities.FAM_Familias.Single(o => o.IdFamilia == idFamilia);
                _sisGESEntities.Dispose();
                return retorno;
            }
            catch (Exception)
            {
                return retorno;
            }
        }

        /// <summary>
        /// Método que obtiene todas las Familias
        /// </summary>
        /// <returns>Lista de Familias</returns>
        public List<FAM_Familias> ObtenerFamilias()
        {
            var listaRetorno = new List<FAM_Familias>();
            try
            {
                listaRetorno = _sisGESEntities.FAM_Familias.ToList();
                _sisGESEntities.Dispose();
                return listaRetorno;
            }
            catch (Exception)
            {
                return listaRetorno;
            }
        }

        /// <summary>
        /// Método que actualiza una Familia
        /// </summary>
        /// <param name="familia">Datos Familia</param>
        /// <returns>Id de actualización</returns>
        public int ActualizarFamilia(FAM_Familias familia)
        {
            var idRetorno = 0;
            try
            {
                _sisGESEntities.FAM_Familias.AddOrUpdate(familia);
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
        /// Método que elimina una familia
        /// </summary>
        /// <param name="idFamilia">Id Familia</param>
        /// <returns>Id de confirmación</returns>
        public int EliminarFamilia(int idFamilia)
        {
            var idRetorno = 0;
            try
            {
                var datosEliminar = new FAM_Familias { IdFamilia = idFamilia };
                _sisGESEntities.FAM_Familias.Attach(datosEliminar);
                _sisGESEntities.FAM_Familias.Remove(datosEliminar);
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

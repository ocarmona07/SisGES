using System.Collections.Generic;
using System.Data;
using SisGES.Entidades;

namespace SisGES.Datos
{
    using System;
    using System.Configuration;
    using System.Data.SqlClient;

    /// <summary>
    /// Clase de datos para uso general del sistema
    /// </summary>
    public class GeneralDa
    {
        private const string Conexion = "data source=localhost;initial catalog=SisGEN;integrated security=True;MultipleActiveResultSets=True;";

        /// <summary>
        /// Método que asocia un integrante a la familia
        /// </summary>
        /// <param name="idFamilia">Id Familia</param>
        /// <param name="rutIntegrante">RUT Integrante</param>
        /// <returns>Confirmación</returns>
        public bool AgregarIntegrantesFamilia(int idFamilia, int rutIntegrante)
        {
            try
            {
                var sql = string.Format("INSERT INTO FAM_IntegrantesFamilia (IdFamilia, RUT) VALUES ({0}, {1});", idFamilia, rutIntegrante);
                var comandoSql = new SqlCommand(sql, new SqlConnection(Conexion));
                comandoSql.Connection.Open();
                return comandoSql.ExecuteNonQuery() > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Método que obtiene los integrantes de una familia
        /// </summary>
        /// <param name="idFamilia">Id Familia</param>
        /// <returns>Lista integrantes</returns>
        public List<INT_Integrantes> ObtenerIntegrantesFamilia(int idFamilia)
        {
            var listaIntegrantes = new List<INT_Integrantes>();
            try
            {
                var sql = string.Format("SELECT IdFamilia, RUT FROM FAM_IntegrantesFamilia WHERE IdFamilia = {0};", idFamilia);
                var comandoSql = new SqlCommand(sql, new SqlConnection(Conexion));
                comandoSql.Connection.Open();
                var drIntegrantes = comandoSql.ExecuteReader(CommandBehavior.CloseConnection);
                while (drIntegrantes.Read())
                {
                    var integrante = new IntegrantesDa().ObtenerIntegrante(Convert.ToInt32(drIntegrantes["RUT"]));
                    if (string.IsNullOrEmpty(integrante.Nombres)) continue;
                    listaIntegrantes.Add(integrante);
                }

                return listaIntegrantes;
            }
            catch (Exception)
            {
                return listaIntegrantes;
            }
        }
    }
}

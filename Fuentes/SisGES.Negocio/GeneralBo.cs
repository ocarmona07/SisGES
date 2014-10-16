using System.Collections.Generic;
using SisGES.Entidades;

namespace SisGES.Negocio
{
    using System;
    using Datos;

    /// <summary>
    /// Clase de negocio para métodos de uso general
    /// </summary>
    public class GeneralBo
    {/// <summary>
        /// Retorna el copyright del sitio
        /// </summary>
        public string Copyright = "SisGES&copy; " + DateTime.Today.Year
            + " <a rel=\"nofollow\" href=\"http://www.ocrinnovaciones.cl\" target=\"_blank\">OCR innovaciones</a>";

        /// <summary>
        /// Método que valida un RUT
        /// </summary>
        /// <param name="rut">RUT</param>
        /// <returns>Respuesta de validación</returns>
        public bool ValidarRut(string rut)
        {
            try
            {
                rut = rut.ToUpper();
                rut = rut.Replace(".", "");
                rut = rut.Replace("-", "");
                var rutAux = int.Parse(rut.Substring(0, rut.Length - 1));
                var dv = char.Parse(rut.Substring(rut.Length - 1, 1));

                int m = 0, s = 1;
                for (; rutAux != 0; rutAux /= 10)
                {
                    s = (s + rutAux % 10 * (9 - m++ % 6)) % 11;
                }
                return dv == (char)(s != 0 ? s + 47 : 75);
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Método que asocia un integrante a la familia
        /// </summary>
        /// <param name="idFamilia">Id Familia</param>
        /// <param name="rutIntegrante">RUT Integrante</param>
        /// <returns>Confirmación</returns>
        public bool AgregarIntegrantesFamilia(int idFamilia, int rutIntegrante)
        {
            return new GeneralDa().AgregarIntegrantesFamilia(idFamilia, rutIntegrante);
        }

        /// <summary>
        /// Método que obtiene los integrantes de una familia
        /// </summary>
        /// <param name="idFamilia">Id Familia</param>
        /// <returns>Lista integrantes</returns>
        public List<INT_Integrantes> ObtenerIntegrantesFamilia(int idFamilia)
        {
            return new GeneralDa().ObtenerIntegrantesFamilia(idFamilia);
        }
    }
}

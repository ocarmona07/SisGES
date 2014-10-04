
namespace SisGES.Negocio
{
    using System.Collections.Generic;
    using Entidades;
    using Datos;

    /// <summary>
    /// Clase de negocio para integrantes
    /// </summary>
    public class IntegrantesBo
    {
        /// <summary>
        /// Método que almacena un integrante
        /// </summary>
        /// <param name="integrante">Datos del integrante</param>
        /// <returns>Id de ingreso</returns>
        public int CrearIntegrante(INT_Integrantes integrante)
        {
            return new IntegrantesDa().CrearIntegrante(integrante);
        }

        /// <summary>
        /// Método que obtiene un integrante
        /// </summary>
        /// <param name="rutIntegrante">RUT del integrante</param>
        /// <returns>Integrante</returns>
        public INT_Integrantes ObtenerIntegrante(int rutIntegrante)
        {
            return new IntegrantesDa().ObtenerIntegrante(rutIntegrante);            
        }

        /// <summary>
        /// Método que obtiene todos los integrantes
        /// </summary>
        /// <returns>Lista de integrantes</returns>
        public List<INT_Integrantes> ObtenerIntegrantes()
        {
            return new IntegrantesDa().ObtenerIntegrantes();            
        }

        /// <summary>
        /// Método que actualiza un integrante
        /// </summary>
        /// <param name="integrante">Datos del integrante</param>
        /// <returns>Id de actualización</returns>
        public int ActualizarIntegrante(INT_Integrantes integrante)
        {
            return new IntegrantesDa().ActualizarIntegrante(integrante);            
        }

        /// <summary>
        /// Método que elimina un integrante
        /// </summary>
        /// <param name="rutIntegrante">RUT del integrante</param>
        /// <returns>Id de confirmación</returns>
        public int EliminarIntegrante(int rutIntegrante)
        {
            return new IntegrantesDa().EliminarIntegrante(rutIntegrante);            
        }
    }
}

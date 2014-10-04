namespace SisGES.Negocio
{
    using System.Collections.Generic;
    using Entidades;
    using Datos;

    /// <summary>
    /// Clase de negocio para Ocupaciones
    /// </summary>
    public class OcupacionesBo
    {
        /// <summary>
        /// Método que almacena una ocupación
        /// </summary>
        /// <param name="ocupacion">Datos de la ocupación</param>
        /// <returns>Id de ingreso</returns>
        public int CrearOcupacion(INT_Ocupaciones ocupacion)
        {
            return new OcupacionesDa().CrearOcupacion(ocupacion);
        }

        /// <summary>
        /// Método que obtiene una ocupación
        /// </summary>
        /// <param name="idOcupacion">ID de la ocupación</param>
        /// <returns>Ocupacione</returns>
        public INT_Ocupaciones ObtenerOcupacion(int idOcupacion)
        {
            return new OcupacionesDa().ObtenerOcupacion(idOcupacion);            
        }

        /// <summary>
        /// Método que obtiene todas las ocupaciones
        /// </summary>
        /// <returns>Lista de ocupacions</returns>
        public List<INT_Ocupaciones> ObtenerOcupaciones()
        {
            return new OcupacionesDa().ObtenerOcupaciones();            
        }

        /// <summary>
        /// Método que actualiza una ocupación
        /// </summary>
        /// <param name="ocupacion">Datos del ocupación</param>
        /// <returns>Id de actualización</returns>
        public int ActualizarOcupacion(INT_Ocupaciones ocupacion)
        {
            return new OcupacionesDa().ActualizarOcupacion(ocupacion);            
        }

        /// <summary>
        /// Método que elimina una ocupación
        /// </summary>
        /// <param name="idOcupacion">ID de la ocupación</param>
        /// <returns>Id de confirmación</returns>
        public int EliminarOcupacion(int idOcupacion)
        {
            return new OcupacionesDa().EliminarOcupacion(idOcupacion);            
        }
    }
}

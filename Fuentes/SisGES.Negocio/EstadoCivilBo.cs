namespace SisGES.Negocio
{
    using System.Collections.Generic;
    using Entidades;
    using Datos;

    /// <summary>
    /// Clase de negocio para Estado Civil
    /// </summary>
    public class EstadoCivilBo
    {
        /// <summary>
        /// Método que almacena un estado civil
        /// </summary>
        /// <param name="estadoCivil">Datos del estado civil</param>
        /// <returns>Id de ingreso</returns>
        public int CrearEstadoCivil(GEN_EstadoCivil estadoCivil)
        {
            return new EstadoCivilDa().CrearEstadoCivil(estadoCivil);
        }

        /// <summary>
        /// Método que obtiene un Estado Civil
        /// </summary>
        /// <param name="idEstadoCivil">ID del Estado Civil</param>
        /// <returns>Estado Civil</returns>
        public GEN_EstadoCivil ObtenerEstadoCivil(int idEstadoCivil)
        {
            return new EstadoCivilDa().ObtenerEstadoCivil(idEstadoCivil);            
        }

        /// <summary>
        /// Método que obtiene todos los Estado Civil
        /// </summary>
        /// <returns>Lista de Estado Civil</returns>
        public List<GEN_EstadoCivil> ObtenerEstadosCiviles()
        {
            return new EstadoCivilDa().ObtenerEstadosCiviles();            
        }

        /// <summary>
        /// Método que actualiza un Estado Civil
        /// </summary>
        /// <param name="estadoCivil">Datos del Estado Civil</param>
        /// <returns>Id de actualización</returns>
        public int ActualizarEstadoCivil(GEN_EstadoCivil estadoCivil)
        {
            return new EstadoCivilDa().ActualizarEstadoCivil(estadoCivil);            
        }

        /// <summary>
        /// Método que elimina un Estado Civil
        /// </summary>
        /// <param name="idEstadoCivil">ID del Estado Civil</param>
        /// <returns>Id de confirmación</returns>
        public int EliminarEstadoCivil(int idEstadoCivil)
        {
            return new EstadoCivilDa().EliminarEstadoCivil(idEstadoCivil);            
        }
    }
}

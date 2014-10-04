namespace SisGES.Negocio
{
    using System.Collections.Generic;
    using Entidades;
    using Datos;

    /// <summary>
    /// Clase de negocio para Nivel Escolar
    /// </summary>
    public class NivelEscolarBo
    {
        /// <summary>
        /// Método que almacena un Nivel Escolar
        /// </summary>
        /// <param name="parentesco">Datos del Nivel Escolar</param>
        /// <returns>Id de ingreso</returns>
        public int CrearNivelEscolar(INT_NivelesEscolaridad parentesco)
        {
            return new NivelesEscolaridadDa().CrearNivelEscolar(parentesco);
        }

        /// <summary>
        /// Método que obtiene un Nivel Escolar
        /// </summary>
        /// <param name="idNivelEscolar">ID del parentesco</param>
        /// <returns>NivelEscolar</returns>
        public INT_NivelesEscolaridad ObtenerNivelEscolar(int idNivelEscolar)
        {
            return new NivelesEscolaridadDa().ObtenerNivelEscolar(idNivelEscolar);            
        }

        /// <summary>
        /// Método que obtiene todos los Niveles Escolares
        /// </summary>
        /// <returns>Lista de Niveles Escolares</returns>
        public List<INT_NivelesEscolaridad> ObtenerNivelesEscolaridad()
        {
            return new NivelesEscolaridadDa().ObtenerNivelesEscolaridad();            
        }

        /// <summary>
        /// Método que actualiza un Nivel Escolar
        /// </summary>
        /// <param name="parentesco">Datos del Nivel Escolar</param>
        /// <returns>Id de actualización</returns>
        public int ActualizarNivelEscolar(INT_NivelesEscolaridad parentesco)
        {
            return new NivelesEscolaridadDa().ActualizarNivelEscolar(parentesco);            
        }

        /// <summary>
        /// Método que elimina un Nivel Escolar
        /// </summary>
        /// <param name="idNivelEscolar">ID del Nivel Escolar</param>
        /// <returns>Id de confirmación</returns>
        public int EliminarNivelEscolar(int idNivelEscolar)
        {
            return new NivelesEscolaridadDa().EliminarNivelEscolar(idNivelEscolar);            
        }
    }
}

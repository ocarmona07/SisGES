namespace SisGES.Negocio
{
    using System.Collections.Generic;
    using Entidades;
    using Datos;

    /// <summary>
    /// Clase de negocio para parentescos
    /// </summary>
    public class ParentescosBo
    {
        /// <summary>
        /// Método que almacena un parentesco
        /// </summary>
        /// <param name="parentesco">Datos del parentesco</param>
        /// <returns>Id de ingreso</returns>
        public int CrearParentesco(GEN_Parentescos parentesco)
        {
            return new ParentescosDa().CrearParentesco(parentesco);
        }

        /// <summary>
        /// Método que obtiene un parentesco
        /// </summary>
        /// <param name="idParentesco">ID del parentesco</param>
        /// <returns>Parentesco</returns>
        public GEN_Parentescos ObtenerParentesco(int idParentesco)
        {
            return new ParentescosDa().ObtenerParentesco(idParentesco);            
        }

        /// <summary>
        /// Método que obtiene todos los parentescos
        /// </summary>
        /// <returns>Lista de parentescos</returns>
        public List<GEN_Parentescos> ObtenerParentescos()
        {
            return new ParentescosDa().ObtenerParentescos();            
        }

        /// <summary>
        /// Método que actualiza un parentesco
        /// </summary>
        /// <param name="parentesco">Datos del parentesco</param>
        /// <returns>Id de actualización</returns>
        public int ActualizarParentesco(GEN_Parentescos parentesco)
        {
            return new ParentescosDa().ActualizarParentesco(parentesco);            
        }

        /// <summary>
        /// Método que elimina un parentesco
        /// </summary>
        /// <param name="idParentesco">ID del parentesco</param>
        /// <returns>Id de confirmación</returns>
        public int EliminarParentesco(int idParentesco)
        {
            return new ParentescosDa().EliminarParentesco(idParentesco);            
        }
    }
}

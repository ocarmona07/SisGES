namespace SisGES.Negocio
{
    using System.Collections.Generic;
    using Entidades;
    using Datos;

    /// <summary>
    /// Clase de negocio para familias
    /// </summary>
    public class FamiliasBo
    {
        /// <summary>
        /// Método que almacena un familia
        /// </summary>
        /// <param name="familia">Datos del familia</param>
        /// <returns>Id de ingreso</returns>
        public int CrearFamilia(FAM_Familias familia)
        {
            return new FamiliasDa().CrearFamilia(familia);
        }

        /// <summary>
        /// Método que obtiene una familia
        /// </summary>
        /// <param name="idFamilia">ID del familia</param>
        /// <returns>Familia</returns>
        public FAM_Familias ObtenerFamilia(int idFamilia)
        {
            return new FamiliasDa().ObtenerFamilia(idFamilia);
        }

        /// <summary>
        /// Método que obtiene todos los familias
        /// </summary>
        /// <returns>Lista de familias</returns>
        public List<FAM_Familias> ObtenerFamilias()
        {
            return new FamiliasDa().ObtenerFamilias();
        }

        /// <summary>
        /// Método que actualiza un familia
        /// </summary>
        /// <param name="familia">Datos del familia</param>
        /// <returns>Id de actualización</returns>
        public int ActualizarFamilia(FAM_Familias familia)
        {
            return new FamiliasDa().ActualizarFamilia(familia);
        }

        /// <summary>
        /// Método que elimina un familia
        /// </summary>
        /// <param name="idFamilia">ID del familia</param>
        /// <returns>Id de confirmación</returns>
        public int EliminarFamilia(int idFamilia)
        {
            return new FamiliasDa().EliminarFamilia(idFamilia);
        }
    }
}

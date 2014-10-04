namespace SisGES.Negocio
{
    using System.Collections.Generic;
    using Datos;
    using Entidades;

    /// <summary>
    /// Clase de Gestores Familiares
    /// </summary>
    public class GestoresFamiliaresBo
    {
        /// <summary>
        /// Método que almacena un gestor familiar
        /// </summary>
        /// <param name="gestorFamiliar">Datos del gestor</param>
        /// <returns>Id de confirmación</returns>
        public int CrearGestorFamiliar(GEN_GestoresFamiliares gestorFamiliar)
        {
            return new GestoresFamiliaresDa().CrearGestorFamiliar(gestorFamiliar);
        }

        /// <summary>
        /// Método que obtiene los datos de un gestor familiar
        /// </summary>
        /// <param name="idGestorFamiliar">Id del gestor familiar</param>
        /// <returns>Datos del gestor</returns>
        public GEN_GestoresFamiliares ObtenerGestorFamiliar(int idGestorFamiliar)
        {
            return new GestoresFamiliaresDa().ObtenerGestorFamiliar(idGestorFamiliar);
        }

        /// <summary>
        /// Método que obtiene una lista de gestores familiares
        /// </summary>
        /// <returns>Lista de gestores familiares</returns>
        public List<GEN_GestoresFamiliares> ObtenerGestoresFamiliares()
        {
            return new GestoresFamiliaresDa().ObtenerGestoresFamiliares();
        }

        /// <summary>
        /// Método que actualiza un gestor familiar
        /// </summary>
        /// <param name="gestorFamiliar">Datos del gestor familiar</param>
        /// <returns>Id de confirmación</returns>
        public int ActualizarGestorFamiliar(GEN_GestoresFamiliares gestorFamiliar)
        {
            return new GestoresFamiliaresDa().ActualizarGestorFamiliar(gestorFamiliar);
        }

        /// <summary>
        /// Método que elimina un gestor familiar
        /// </summary>
        /// <param name="idGestorFamiliar">Id del gestor familiar</param>
        /// <returns>Id de confirmación</returns>
        public int EliminarGestorFamiliar(int idGestorFamiliar)
        {
            return new GestoresFamiliaresDa().EliminarGestorFamiliar(idGestorFamiliar);
        }
    }
}

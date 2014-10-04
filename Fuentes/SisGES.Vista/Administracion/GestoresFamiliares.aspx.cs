namespace SisGES.Vista.Administracion
{
    using System;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using Entidades;
    using Negocio;

    /// <summary>
    /// Clase de gestores familiares
    /// </summary>
    public partial class GestoresFamiliares : Page
    {
        /// <summary>
        /// Método que se llama al iniciar la vista
        /// </summary>
        /// <param name="sender">Objeto del evento</param>
        /// <param name="e">Argumentos del evento</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            gvGestoresFamiliares.DataSource = new GestoresFamiliaresBo().ObtenerGestoresFamiliares();
            gvGestoresFamiliares.DataBind();
        }

        /// <summary>
        /// Método que limpia los controles del formulario
        /// </summary>
        /// <param name="sender">Objeto del evento</param>
        /// <param name="e">Argumentos del evento</param>
        protected void LimpiarControles(object sender, EventArgs e)
        {
            btnIngresar.CommandArgument = string.Empty;
            tbNombres.Text = string.Empty;
            tbApPaterno.Text = string.Empty;
            tbApMaterno.Text = string.Empty;
            tbTelefono.Text = string.Empty;
            tbEmail.Text = string.Empty;
            btnIngresar.Text = "Guardar";
        }

        /// <summary>
        /// Método que almacena o actualiza un registro
        /// </summary>
        /// <param name="sender">Objeto del evento</param>
        /// <param name="e">Argumentos del evento</param>
        protected void IngresarGestor(object sender, EventArgs e)
        {
            string mensaje;
            var gestorFamiliar = new GEN_GestoresFamiliares
            {
                Nombres = tbNombres.Text,
                ApPaterno = tbApPaterno.Text,
                ApMaterno = tbApMaterno.Text,
                Telefono = int.Parse(tbTelefono.Text),
                Email = tbEmail.Text
            };

            if (string.IsNullOrEmpty(btnIngresar.CommandArgument))
            {
                mensaje = new GestoresFamiliaresBo().CrearGestorFamiliar(gestorFamiliar) > 0 ?
                    "Se ha almacenado el registro correctamente" :
                    "Error al guardar el registro!";
            }
            else
            {
                int idGestor;
                int.TryParse(btnIngresar.CommandArgument, out idGestor);
                gestorFamiliar.IdGestorFamiliar = idGestor;

                mensaje = new GestoresFamiliaresBo().ActualizarGestorFamiliar(gestorFamiliar) > 0 ?
                    "Se ha actualizado el registro correctamente" :
                    "Error al actualizar el registro!";
            }

            LimpiarControles(null, null);
            gvGestoresFamiliares.DataSource = new GestoresFamiliaresBo().ObtenerGestoresFamiliares();
            gvGestoresFamiliares.DataBind();
            if (Master != null) ((Label)Master.FindControl("lblMensaje")).Text = mensaje;
            ScriptManager.RegisterStartupScript(this, GetType(), "Javascript", "javascript:MostrarAlert();", true);
        }

        /// <summary>
        /// Método que realiza acciones en la grilla de Gestores Familiares
        /// </summary>
        /// <param name="sender">Objeto del evento</param>
        /// <param name="e">Argumentos de la grilla</param>
        protected void GestoresFamiliaresRowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Editar":
                    LimpiarControles(null, null);
                    var datosGestor = new GestoresFamiliaresBo().ObtenerGestorFamiliar(int.Parse(e.CommandArgument.ToString()));
                    btnIngresar.CommandArgument = datosGestor.IdGestorFamiliar.ToString("D");
                    tbNombres.Text = datosGestor.Nombres;
                    tbApPaterno.Text = datosGestor.ApPaterno;
                    tbApMaterno.Text = datosGestor.ApMaterno;
                    tbTelefono.Text = datosGestor.Telefono + "";
                    tbEmail.Text = datosGestor.Email;
                    btnIngresar.Text = "Modificar";
                    MostrarIngresoGestores(null, null);
                    break;

                case "Eliminar":
                    var mensaje = new GestoresFamiliaresBo().EliminarGestorFamiliar(int.Parse(e.CommandArgument.ToString())) > 0
                        ? "Gestor Familiar eliminado correctamente"
                        : "Error al eliminar Gestor Familiar";
                    if (Master != null) ((Label)Master.FindControl("lblMensaje")).Text = mensaje;
                    ScriptManager.RegisterStartupScript(this, GetType(), "Javascript", "javascript:MostrarAlert();", true);

                    LimpiarControles(null, null);
                    gvGestoresFamiliares.DataSource = new GestoresFamiliaresBo().ObtenerGestoresFamiliares();
                    gvGestoresFamiliares.DataBind();
                    break;

                default:
                    return;
            }
        }

        /// <summary>
        /// Método que muestra la vista de lista de gestores y oculta la de ingreso.
        /// </summary>
        /// <param name="sender">Objeto del evento</param>
        /// <param name="e">Argumentos del evento</param>
        protected void MostrarIngresoGestores(object sender, EventArgs e)
        {
            tblListaGestores.Visible = false;
            tblIngresoGestor.Visible = true;
        }

        /// <summary>
        /// Método que alterna la vista entre la lista de gestores y la de ingreso de gestores.
        /// </summary>
        /// <param name="sender">Objeto del evento</param>
        /// <param name="e">Argumentos del evento</param>
        protected void MostrarListaGestores(object sender, EventArgs e)
        {
            tblIngresoGestor.Visible = false;
            tblListaGestores.Visible = true;
        }
    }
}
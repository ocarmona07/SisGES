namespace SisGES.Vista.Administracion
{
    using System;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using Entidades;
    using Negocio;

    /// <summary>
    /// Clase de usuarios
    /// </summary>
    public partial class Usuarios : Page
    {
        /// <summary>
        /// Método que se llama al iniciar la vista
        /// </summary>
        /// <param name="sender">Objeto del evento</param>
        /// <param name="e">Argumentos del evento</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            ddlRol.DataSource = new RolesBo().ObtenerRoles();
            ddlRol.DataTextField = "Rol";
            ddlRol.DataValueField = "IdRol";
            ddlRol.DataBind();
            chkEstado.Checked = true;
            CargarGrilla();
        }

        /// <summary>
        /// Método que limpia los controles del formulario
        /// </summary>
        /// <param name="sender">Objeto del evento</param>
        /// <param name="e">Argumentos del evento</param>
        protected void LimpiarControles(object sender, EventArgs e)
        {
            btnIngresar.CommandArgument = string.Empty;
            tbRUT.Text = string.Empty;
            tbRUT.Enabled = true;
            tbDV.Text = string.Empty;
            tbDV.Enabled = true;
            ddlRol.SelectedIndex = -1;
            tbNombres.Text = string.Empty;
            tbApPaterno.Text = string.Empty;
            tbApMaterno.Text = string.Empty;
            tbTelefono.Text = string.Empty;
            tbCelular.Text = string.Empty;
            tbEmail.Text = string.Empty;
            rfvClave.Enabled = true;
            tbClaveUno.Text = string.Empty;
            tbClaveDos.Text = string.Empty;
            chkEstado.Checked = true;
            btnIngresar.Text = "Guardar";
        }

        /// <summary>
        /// Método que almacena o actualiza un registro
        /// </summary>
        /// <param name="sender">Objeto del evento</param>
        /// <param name="e">Argumentos del evento</param>
        protected void IngresarUsuario(object sender, EventArgs e)
        {
            if (!new GeneralBo().ValidarRut(tbRUT.Text.Trim() + tbDV.Text))
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Mensaje", @"<script language='javascript' type='text/javascript'>alert('El RUT ingresado no es válido!');</script>", false);
                return;
            }

            string mensaje;
            var usuario = new GEN_Usuarios
            {
                RUT = int.Parse(tbRUT.Text),
                DV = tbDV.Text,
                Nombres = tbNombres.Text,
                ApPaterno = tbApPaterno.Text,
                ApMaterno = tbApMaterno.Text,
                Fono = int.Parse(tbTelefono.Text),
                Celular = int.Parse(tbCelular.Text),
                Email = tbEmail.Text,
                Imagen = string.Empty,
                IdRol = int.Parse(ddlRol.SelectedValue),
                Estado = chkEstado.Checked
            };

            if (string.IsNullOrEmpty(btnIngresar.CommandArgument))
            {
                usuario.Clave = tbClaveUno.Text;
                mensaje = new UsuariosBo().CrearUsuario(usuario) > 0 ?
                    "Se ha almacenado el registro correctamente" :
                    "Error al guardar el registro!";
            }
            else
            {
                int idRegistro;
                int.TryParse(btnIngresar.CommandArgument, out idRegistro);
                usuario.RUT = idRegistro;
                usuario.Clave = string.IsNullOrEmpty(tbClaveUno.Text) ?
                    new UsuariosBo().ObtenerUsuario(idRegistro).Clave :
                    tbClaveUno.Text;

                mensaje = new UsuariosBo().ActualizarUsuario(usuario) > 0 ?
                        "Se ha actualizado el registro correctamente" :
                        "Error al actualizar el registro!";
            }

            LimpiarControles(null, null);
            CargarGrilla();
            if (Master != null) ((Label)Master.FindControl("lblMensaje")).Text = mensaje;
            ScriptManager.RegisterStartupScript(this, GetType(), "Javascript", "javascript: MostrarAlert();", true);
        }

        /// <summary>
        /// Método que realiza acciones en la grilla
        /// </summary>
        /// <param name="sender">Objeto del evento</param>
        /// <param name="e">Argumentos de la grilla</param>
        protected void UsuariosRowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Editar":
                    LimpiarControles(null, null);
                    var datos = new UsuariosBo().ObtenerUsuario(int.Parse(e.CommandArgument.ToString()));
                    btnIngresar.CommandArgument = datos.RUT.ToString("D");
                    tbRUT.Enabled = false;
                    tbDV.Enabled = false;
                    tbRUT.Text = datos.RUT.ToString("D");
                    tbDV.Text = datos.DV;
                    ddlRol.SelectedValue = datos.IdRol.ToString("D");
                    tbNombres.Text = datos.Nombres;
                    tbApPaterno.Text = datos.ApPaterno;
                    tbApMaterno.Text = datos.ApMaterno;
                    tbTelefono.Text = datos.Fono.ToString();
                    tbCelular.Text = datos.Celular.ToString("D");
                    tbEmail.Text = datos.Email;
                    rfvClave.Enabled = false;
                    chkEstado.Checked = datos.Estado;
                    btnIngresar.Text = "Modificar";
                    MostrarIngresoUsuario(null, null);
                    break;

                case "Eliminar":
                    var mensaje = new UsuariosBo().EliminarUsuario(int.Parse(e.CommandArgument.ToString())) > 0
                        ? "Registro eliminado correctamente"
                        : "Error al eliminar el registro";
                    if (Master != null) ((Label)Master.FindControl("lblMensaje")).Text = mensaje;
                    ScriptManager.RegisterStartupScript(this, GetType(), "Javascript", "javascript: MostrarAlert();", true);
                    LimpiarControles(null, null);
                    CargarGrilla();
                    break;

                default:
                    return;
            }
        }

        /// <summary>
        /// Método que alterna la vista entre la lista y el formulario de ingreso.
        /// </summary>
        /// <param name="sender">Objeto del evento</param>
        /// <param name="e">Argumentos del evento</param>
        protected void MostrarIngresoUsuario(object sender, EventArgs e)
        {
            tblListaUsuarios.Visible = false;
            tblIngresoUsuario.Visible = true;
        }

        /// <summary>
        /// Método que alterna la vista entre la lista y el formulario de ingreso.
        /// </summary>
        /// <param name="sender">Objeto del evento</param>
        /// <param name="e">Argumentos del evento</param>
        protected void MostrarListaUsuarios(object sender, EventArgs e)
        {
            tblIngresoUsuario.Visible = false;
            tblListaUsuarios.Visible = true;
        }

        /// <summary>
        /// Método que carga la grilla
        /// </summary>
        private void CargarGrilla()
        {
            gvUsuarios.DataSource = new UsuariosBo().ObtenerUsuarios();
            gvUsuarios.DataBind();
        }
    }
}
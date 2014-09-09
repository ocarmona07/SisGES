namespace SisGES.Vista
{
    using System;
    using System.Web.UI;
    using Negocio;

    /// <summary>
    /// Clase de inicio del sitio
    /// </summary>
    public partial class Index : Page
    {
        /// <summary>
        /// Método que se llama al iniciar la vista
        /// </summary>
        /// <param name="sender">Objeto del evento</param>
        /// <param name="e">Argumentos del evento</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            //divCopyright.Controls.Add(new LiteralControl(new GeneralBo().Copyright));
            if (IsPostBack) return;
            Session["RUTUsuario"] = string.Empty;
            lblMensaje.Text = string.Empty;

        }

        /// <summary>
        /// Método que valida el inicio de sesión
        /// </summary>
        /// <param name="sender">Objeto del evento</param>
        /// <param name="e">Argumentos del evento</param>
        protected void ValidarIngreso(object sender, EventArgs e)
        {
            if (new GeneralBo().ValidarRut(tbRut.Text))
            {
                if (new UsuariosBo().ValidarAcceso(tbRut.Text, tbClave.Text))
                {
                    Session["RUTUsuario"] = tbRut.Text.Substring(0, tbRut.Text.Length - 1).Replace(".", "").Replace("-", "");
                    Response.Redirect("Inicio.aspx");
                }
                else
                    lblMensaje.Text = "RUT o Contraseña incorrecta.";
            }
            else
                lblMensaje.Text = "El RUT ingresado no es válido.";
        }
    }
}
namespace SisGES.Vista
{
    using System;
    using System.Web.UI;
    using Negocio;

    /// <summary>
    /// Clase principal de la MasterPage
    /// </summary>
    public partial class Base : MasterPage
    {
        /// <summary>
        /// Método que se llama al iniciar la vista de la master page
        /// </summary>
        /// <param name="sender">Objeto del evento</param>
        /// <param name="e">Argumentos del evento</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            lblCopyright.Text = new GeneralBo().Copyright;
            if (IsPostBack) return;

            if (string.IsNullOrEmpty(Session["RUTUsuario"] + ""))
            {
                Response.Redirect("~/Index.aspx");
            }
        }

        /// <summary>
        /// Método que cierra la sesión y redirecciona al inicio
        /// </summary>
        /// <param name="sender">Objeto del evento</param>
        /// <param name="e">Argumentos del evento</param>
        protected void CerrarSesion(object sender, EventArgs e)
        {
            Session["RUTUsuario"] = string.Empty;
            Response.Redirect("~/Index.aspx");
        }
    }
}
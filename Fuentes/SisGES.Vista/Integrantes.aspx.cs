namespace SisGES.Vista
{
    using System;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using Entidades;
    using Negocio;

    /// <summary>
    /// Clase de integrantes
    /// </summary>
    public partial class Integrantes : Page
    {
        /// <summary>
        /// Método que se llama al iniciar la vista
        /// </summary>
        /// <param name="sender">Objeto del evento</param>
        /// <param name="e">Argumentos del evento</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
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
            tbNombres.Text = string.Empty;
            tbApPaterno.Text = string.Empty;
            tbApMaterno.Text = string.Empty;
            tbFechaNac.Text = string.Empty;
            tbDescOcupacion.Text = string.Empty;
            rbgSexo.SelectedValue = "1";
            ddlParentesco.SelectedIndex = -1;
            ddlEstadoCivil.SelectedIndex = -1;
            ddlNivelEscolar.SelectedIndex = -1;
            ddlOcupacion.SelectedIndex = -1;
            btnIngresar.Text = "Guardar";
        }

        /// <summary>
        /// Método que almacena o actualiza un registro
        /// </summary>
        /// <param name="sender">Objeto del evento</param>
        /// <param name="e">Argumentos del evento</param>
        protected void IngresarIntegrante(object sender, EventArgs e)
        {
            string mensaje;
            var integrante = new INT_Integrantes
            {
                RUT = int.Parse(tbRUT.Text),
                DV = tbDV.Text,
                Nombres = tbNombres.Text,
                ApPaterno = tbApPaterno.Text,
                ApMaterno = tbApMaterno.Text,
                IdParentesco = int.Parse(ddlParentesco.SelectedValue),
                Sexo = "1".Equals(rbgSexo.SelectedValue),
                FechaNac = DateTime.Parse(tbFechaNac.Text),
                IdEstadoCivil = int.Parse(ddlEstadoCivil.SelectedValue),
                IdNivelEscolar = int.Parse(ddlNivelEscolar.SelectedValue),
                IdOcupacion = int.Parse(ddlOcupacion.SelectedValue),
                DescOcupacion = tbDescOcupacion.Text
            };

            if (string.IsNullOrEmpty(btnIngresar.CommandArgument))
            {
                mensaje = new IntegrantesBo().CrearIntegrante(integrante) > 0 ?
                    "Se ha almacenado el registro correctamente" :
                    "Error al guardar el registro!";
            }
            else
            {
                int idRegistro;
                int.TryParse(btnIngresar.CommandArgument, out idRegistro);
                integrante.RUT = idRegistro;

                mensaje = new IntegrantesBo().ActualizarIntegrante(integrante) > 0 ?
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
        protected void IntegrantesRowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Editar":
                    LimpiarControles(null, null);
                    var datos = new IntegrantesBo().ObtenerIntegrante(int.Parse(e.CommandArgument.ToString()));
                    btnIngresar.CommandArgument = datos.RUT.ToString("D");
                    tbRUT.Enabled = false;
                    tbDV.Enabled = false;
                    tbRUT.Text = datos.RUT.ToString("D");
                    tbDV.Text = datos.DV;
                    tbNombres.Text = datos.Nombres;
                    tbApPaterno.Text = datos.ApPaterno;
                    tbApMaterno.Text = datos.ApMaterno;
                    rbgSexo.SelectedValue = datos.Sexo ? "1" : "0";
                    ddlParentesco.SelectedValue = datos.IdParentesco.ToString("D");
                    ddlEstadoCivil.SelectedValue = datos.IdEstadoCivil.ToString("D");
                    ddlNivelEscolar.SelectedValue = datos.IdNivelEscolar.ToString("D");
                    ddlOcupacion.SelectedValue = datos.IdOcupacion.ToString("D");
                    tbDescOcupacion.Text = datos.DescOcupacion;
                    btnIngresar.Text = "Modificar";
                    MostrarIngresoIntegrante(null, null);
                    break;

                case "Eliminar":
                    var mensaje = new IntegrantesBo().EliminarIntegrante(int.Parse(e.CommandArgument.ToString())) > 0
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
        protected void MostrarIngresoIntegrante(object sender, EventArgs e)
        {
            tblListaIntegrantes.Visible = false;
            tblIngresoIntegrante.Visible = true;
        }

        /// <summary>
        /// Método que alterna la vista entre la lista y el formulario de ingreso.
        /// </summary>
        /// <param name="sender">Objeto del evento</param>
        /// <param name="e">Argumentos del evento</param>
        protected void MostrarListaIntegrantes(object sender, EventArgs e)
        {
            tblIngresoIntegrante.Visible = false;
            tblListaIntegrantes.Visible = true;
        }

        /// <summary>
        /// Método que carga la grilla
        /// </summary>
        private void CargarGrilla()
        {
            gvIntegrantes.DataSource = new IntegrantesBo().ObtenerIntegrantes();
            gvIntegrantes.DataBind();
        }
    }
}
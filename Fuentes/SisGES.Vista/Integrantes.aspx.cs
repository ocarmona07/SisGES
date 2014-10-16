namespace SisGES.Vista
{
    using System;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using PdfSharp.Drawing;
    using PdfSharp.Pdf;
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
            tbFechaNac.Attributes.Add("readonly", "readonly");

            ddlParentesco.DataSource = new ParentescosBo().ObtenerParentescos();
            ddlParentesco.DataTextField = "Parentesco";
            ddlParentesco.DataValueField = "IdParentesco";
            ddlParentesco.DataBind();

            ddlEstadoCivil.DataSource = new EstadoCivilBo().ObtenerEstadosCiviles();
            ddlEstadoCivil.DataTextField = "EstadoCivil";
            ddlEstadoCivil.DataValueField = "IdEstadoCivil";
            ddlEstadoCivil.DataBind();

            ddlNivelEscolar.DataSource = new NivelEscolarBo().ObtenerNivelesEscolaridad();
            ddlNivelEscolar.DataTextField = "NivelEscolar";
            ddlNivelEscolar.DataValueField = "IdNivelEscolar";
            ddlNivelEscolar.DataBind();

            ddlOcupacion.DataSource = new OcupacionesBo().ObtenerOcupaciones();
            ddlOcupacion.DataTextField = "Ocupacion";
            ddlOcupacion.DataValueField = "IdOcupacion";
            ddlOcupacion.DataBind();
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
            tbBuscaRUT.Text = string.Empty;
            tbBuscaDV.Text = string.Empty;
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
            if (!new GeneralBo().ValidarRut(tbRUT.Text.Trim() + tbDV.Text))
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Mensaje", @"<script language='javascript' type='text/javascript'>alert('El RUT ingresado no es válido!');</script>", false);
                return;
            }

            string mensaje;
            var integrante = new INT_Integrantes
            {
                RUT = int.Parse(tbRUT.Text),
                DV = tbDV.Text,
                Nombres = tbNombres.Text.Trim(),
                ApPaterno = tbApPaterno.Text.Trim(),
                ApMaterno = tbApMaterno.Text.Trim(),
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
            MostrarListaIntegrantes(null, null);
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
                case "DescargaPdf":
                    var integrante = new IntegrantesBo().ObtenerIntegrante(int.Parse(e.CommandArgument.ToString()));

                    var document = new PdfDocument();
                    document.Info.Title = "Información Integrante: " + integrante.Nombres + " " + integrante.ApPaterno;
                    document.Info.Author = "SisGES";
                    document.Info.Subject = "Fecha Creación: " + document.Info.CreationDate.ToShortDateString();
                    var pagina = document.AddPage();
                    pagina.Width = XUnit.FromCentimeter(21.59);
                    pagina.Height = XUnit.FromCentimeter(27.94);
                    var gfx = XGraphics.FromPdfPage(pagina);
                    const string nombreFuente = "Arial";
                    var colorLetras = XBrushes.Black;

                    var fuenteTitulo = new XFont(nombreFuente, 20, XFontStyle.Bold);
                    var rectTitulo = new XRect(0, 0, pagina.Width, XUnit.FromCentimeter(12));
                    gfx.DrawString("SisGES - Información del integrante", fuenteTitulo, colorLetras, rectTitulo, XStringFormats.Center);

                    const double altoDatos = 9.5;
                    var i = 0;
                    var campos = new[]
                    {
                        "RUT:",
                        "Nombre(s):",
                        "Apellido(s):",
                        "Fecha de Nac.:",
                        "Sexo:",
                        "Parentesco:",
                        "Estado civil:",
                        "Nivel Escolar:",
                        "Ocupación:",
                        "Detalle Ocupación:"
                    };
                    var fuenteDatos = new XFont(nombreFuente, 14, XFontStyle.Bold);
                    foreach (var campo in campos)
                    {
                        var rectDatos = new XRect(XUnit.FromCentimeter(3.2), XUnit.FromCentimeter(altoDatos + i), 0, 0);
                        gfx.DrawString(campo, fuenteDatos, colorLetras, rectDatos, XStringFormats.Default);
                        i++;
                    }

                    i = 0;
                    var datosCampos = new[]
                    {
                        integrante.RUT.ToString("N0") + "-" + integrante.DV,
                        integrante.Nombres,
                        integrante.ApPaterno + " " + integrante.ApMaterno,
                        integrante.FechaNac.ToShortDateString(),
                        integrante.Sexo ? "Masculino" : "Femenino",
                        new ParentescosBo().ObtenerParentesco(integrante.IdParentesco).Parentesco,
                        new EstadoCivilBo().ObtenerEstadoCivil(integrante.IdEstadoCivil).EstadoCivil,
                        new NivelEscolarBo().ObtenerNivelEscolar(integrante.IdNivelEscolar).NivelEscolar,
                        new OcupacionesBo().ObtenerOcupacion(integrante.IdOcupacion).Ocupacion,
                        integrante.DescOcupacion
                    };
                    var fuenteDatosCampos = new XFont(nombreFuente, 14, XFontStyle.Regular);
                    foreach (var datosCampo in datosCampos)
                    {
                        var rectDatos = new XRect(XUnit.FromCentimeter(9), XUnit.FromCentimeter(altoDatos + i), 0, 0);
                        gfx.DrawString(datosCampo, fuenteDatosCampos, XBrushes.Black, rectDatos, XStringFormats.Default);
                        i++;
                    }

                    var rectPie = new XRect(XUnit.FromCentimeter(11.5), XUnit.FromCentimeter(23), 0, 0);
                    gfx.DrawString(DateTime.Today.ToLongDateString(), fuenteDatos, colorLetras, rectPie, XStringFormats.TopLeft);

                    var nombreArchivo = "Integrante_" + integrante.RUT + "-" + integrante.DV;
                    var stream = new System.IO.MemoryStream();
                    document.Save(stream, false);
                    Response.Clear();
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("Content-Length", stream.Length.ToString("D"));
                    Response.AddHeader("Content-Disposition", "attachment; filename=" + nombreArchivo + ".pdf");
                    Response.BinaryWrite(stream.ToArray());
                    Response.Flush();
                    stream.Close();
                    Response.End();
                    break;

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
                    tbFechaNac.Text = datos.FechaNac.ToShortDateString();
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
        /// Método que alterna entre las vistas.
        /// </summary>
        /// <param name="sender">Objeto del evento</param>
        /// <param name="e">Argumentos del evento</param>
        protected void MostrarIngresoIntegrante(object sender, EventArgs e)
        {
            tblBuscarIntegrante.Visible = false;
            tblListaIntegrantes.Visible = false;
            tblIngresoIntegrante.Visible = true;
        }

        /// <summary>
        /// Método que alterna entre las vistas.
        /// </summary>
        /// <param name="sender">Objeto del evento</param>
        /// <param name="e">Argumentos del evento</param>
        protected void MostrarListaIntegrantes(object sender, EventArgs e)
        {
            tblBuscarIntegrante.Visible = false;
            tblIngresoIntegrante.Visible = false;
            tblListaIntegrantes.Visible = true;
        }

        /// <summary>
        /// Método que alterna entre las vistas.
        /// </summary>
        /// <param name="sender">Objeto del evento</param>
        /// <param name="e">Argumentos del evento</param>
        protected void MostrarBuscarIntegrante(object sender, EventArgs e)
        {
            tblIngresoIntegrante.Visible = false;
            tblListaIntegrantes.Visible = false;
            tblBuscarIntegrante.Visible = true;
        }

        /// <summary>
        /// Método que carga la grilla
        /// </summary>
        private void CargarGrilla()
        {
            gvIntegrantes.DataSource = new IntegrantesBo().ObtenerIntegrantes();
            gvIntegrantes.DataBind();
        }

        /// <summary>
        /// Método que busca un registro por su RUT
        /// </summary>
        /// <param name="sender">Objeto del evento</param>
        /// <param name="e">Argumentos del evento</param>
        protected void BuscarPorRut(object sender, EventArgs e)
        {
            if (!new GeneralBo().ValidarRut(tbBuscaRUT.Text.Trim() + tbBuscaDV.Text))
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Mensaje", @"<script language='javascript' type='text/javascript'>alert('El RUT ingresado no es válido!');</script>", false);
                return;
            }

            var datos = new IntegrantesBo().ObtenerIntegrante(int.Parse(tbBuscaRUT.Text.Trim()));

            if (string.IsNullOrEmpty(datos.Nombres))
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Mensaje", @"<script language='javascript' type='text/javascript'>alert('No se encontraron registros!');</script>", false);
                return;
            }

            LimpiarControles(null, null);
            btnIngresar.CommandArgument = datos.RUT.ToString("D");
            tbRUT.Enabled = false;
            tbDV.Enabled = false;
            tbRUT.Text = datos.RUT.ToString("D");
            tbDV.Text = datos.DV;
            tbNombres.Text = datos.Nombres;
            tbApPaterno.Text = datos.ApPaterno;
            tbApMaterno.Text = datos.ApMaterno;
            tbFechaNac.Text = datos.FechaNac.ToShortDateString();
            rbgSexo.SelectedValue = datos.Sexo ? "1" : "0";
            ddlParentesco.SelectedValue = datos.IdParentesco.ToString("D");
            ddlEstadoCivil.SelectedValue = datos.IdEstadoCivil.ToString("D");
            ddlNivelEscolar.SelectedValue = datos.IdNivelEscolar.ToString("D");
            ddlOcupacion.SelectedValue = datos.IdOcupacion.ToString("D");
            tbDescOcupacion.Text = datos.DescOcupacion;
            btnIngresar.Text = "Modificar";
            MostrarIngresoIntegrante(null, null);
        }
    }
}
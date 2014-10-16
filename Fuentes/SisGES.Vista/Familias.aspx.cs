namespace SisGES.Vista
{
    using System;
    using System.Linq;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using PdfSharp.Drawing;
    using PdfSharp.Pdf;
    using Entidades;
    using Negocio;

    /// <summary>
    /// Clase de integrantes
    /// </summary>
    public partial class Familias : Page
    {
        /// <summary>
        /// Método que se llama al iniciar la vista
        /// </summary>
        /// <param name="sender">Objeto del evento</param>
        /// <param name="e">Argumentos del evento</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            var dsGestores = from gestor in new GestoresFamiliaresBo().ObtenerGestoresFamiliares()
                             select new
                             {
                                 gestor.IdGestorFamiliar,
                                 NombreGestor = gestor.Nombres + " " + gestor.ApPaterno + " " + gestor.ApMaterno
                             };
            ddlGestorFamiliar.DataSource = dsGestores;
            ddlGestorFamiliar.DataTextField = "NombreGestor";
            ddlGestorFamiliar.DataValueField = "IdGestorFamiliar";
            ddlGestorFamiliar.DataBind();

            var filtro = from integrante in new IntegrantesBo().ObtenerIntegrantes()
                         select new
                         {
                             integrante.RUT,
                             NombreIntegrante = integrante.Nombres + " " + integrante.ApPaterno + " " + integrante.ApMaterno
                         };
            lbxIntegrantes.DataSource = filtro.ToList();
            lbxIntegrantes.DataTextField = "NombreIntegrante";
            lbxIntegrantes.DataValueField = "RUT";
            lbxIntegrantes.DataBind();

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
            tbIdFamilia.Text = string.Empty;
            tbFolio.Text = string.Empty;
            tbNombreFamilia.Text = string.Empty;
            tbDireccion.Text = string.Empty;
            tbReferenciaDir.Text = string.Empty;
            tbTelefonoUno.Text = string.Empty;
            tbTelefonoDos.Text = string.Empty;
            ddlGestorFamiliar.SelectedIndex = -1;

            lbxFamilia.Items.Clear();
            lbxIntegrantes.Items.Clear();
            var filtro = from integrante in new IntegrantesBo().ObtenerIntegrantes()
                         select new
                         {
                             integrante.RUT,
                             NombreIntegrante = integrante.Nombres + " " + integrante.ApPaterno + " " + integrante.ApMaterno
                         };
            lbxIntegrantes.DataSource = filtro.ToList();
            lbxIntegrantes.DataTextField = "NombreIntegrante";
            lbxIntegrantes.DataValueField = "RUT";
            lbxIntegrantes.DataBind();

            btnIngresar.Text = "Guardar";
        }

        /// <summary>
        /// Método que almacena o actualiza un registro
        /// </summary>
        /// <param name="sender">Objeto del evento</param>
        /// <param name="e">Argumentos del evento</param>
        protected void IngresarFamilia(object sender, EventArgs e)
        {
            string mensaje;
            int rutUsuario;
            int.TryParse(Session["RUTUsuario"].ToString(), out rutUsuario);
            var familia = new FAM_Familias
            {
                IdFamilia = int.Parse(tbIdFamilia.Text),
                Folio = int.Parse(tbFolio.Text),
                RUTUsuario = rutUsuario,
                NombreFamilia = tbNombreFamilia.Text,
                Telefono1 = int.Parse(tbTelefonoUno.Text),
                Telefono2 = int.Parse(tbTelefonoDos.Text),
                Direccion = tbDireccion.Text,
                ReferenciaDir = tbReferenciaDir.Text,
                IdGestorFamiliar = int.Parse(ddlGestorFamiliar.SelectedValue),
                EstadoApoLaboral = false
            };

            if (string.IsNullOrEmpty(btnIngresar.CommandArgument))
            {
                var idFamilia = new FamiliasBo().CrearFamilia(familia);
                mensaje = idFamilia > 0 ?
                    "Se ha almacenado el registro correctamente" :
                    "Error al guardar el registro!";

                if (idFamilia > 0 && lbxFamilia.Items.Count > 0)
                {
                    foreach (ListItem item in lbxFamilia.Items)
                    {
                        new GeneralBo().AgregarIntegrantesFamilia(idFamilia, int.Parse(item.Value));
                    }
                }
            }
            else
            {
                int idRegistro;
                int.TryParse(btnIngresar.CommandArgument, out idRegistro);
                familia.IdFamilia = idRegistro;

                mensaje = new FamiliasBo().ActualizarFamilia(familia) > 0 ?
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
        protected void FamiliasRowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "DescargaPdf":
                    var familia = new FamiliasBo().ObtenerFamilia(int.Parse(e.CommandArgument.ToString()));

                    var document = new PdfDocument();
                    document.Info.Title = "Información Familia " + familia.NombreFamilia;
                    document.Info.Author = "SisGES";
                    document.Info.Subject = "Fecha Creación: " + document.Info.CreationDate.ToShortDateString();
                    var pagina = document.AddPage();
                    pagina.Width = XUnit.FromCentimeter(21.59);
                    pagina.Height = XUnit.FromCentimeter(27.94);
                    var gfx = XGraphics.FromPdfPage(pagina);
                    const string nombreFuente = "Arial";
                    var colorLetras = XBrushes.Black;

                    var fuenteTitulo = new XFont(nombreFuente, 20, XFontStyle.Bold);
                    var rectTitulo = new XRect(0, 0, pagina.Width, XUnit.FromCentimeter(9));
                    gfx.DrawString("SisGES - Información de la familia", fuenteTitulo, colorLetras, rectTitulo, XStringFormats.Center);

                    const double altoDatos = 7.5;
                    var i = 0;
                    var campos = new[]
                    {
                        "ID Familia:",
                        "Folio:",
                        "Ingresado por:",
                        "Nombre Familia:",
                        "Dirección:",
                        "Referencias:",
                        "Teléfono 1:",
                        "Teléfono 2:",
                        "Gestor Familiar:"
                    };
                    var fuenteDatos = new XFont(nombreFuente, 14, XFontStyle.Bold);
                    foreach (var campo in campos)
                    {
                        var rectDatos = new XRect(XUnit.FromCentimeter(3.2), XUnit.FromCentimeter(altoDatos + i), 0, 0);
                        gfx.DrawString(campo, fuenteDatos, colorLetras, rectDatos, XStringFormats.Default);
                        i++;
                    }

                    i = 0;
                    var nombreUsuario = new UsuariosBo().ObtenerUsuario(familia.RUTUsuario);
                    var gestor = new GestoresFamiliaresBo().ObtenerGestorFamiliar(familia.IdGestorFamiliar);
                    var datosCampos = new[]
                    {
                        familia.IdFamilia.ToString("D"),
                        familia.Folio.ToString("D"),
                        nombreUsuario.Nombres + " " + nombreUsuario.ApPaterno + " " + nombreUsuario.ApMaterno,
                        familia.NombreFamilia,
                        familia.Direccion,
                        familia.ReferenciaDir,
                        familia.Telefono1.ToString("D"),
                        familia.Telefono2.ToString(),
                        gestor.Nombres + " " + gestor.ApPaterno + " " + gestor.ApMaterno
                    };
                    var fuenteDatosCampos = new XFont(nombreFuente, 14, XFontStyle.Regular);
                    foreach (var datosCampo in datosCampos)
                    {
                        var rectDatos = new XRect(XUnit.FromCentimeter(9), XUnit.FromCentimeter(altoDatos + i), 0, 0);
                        gfx.DrawString(datosCampo, fuenteDatosCampos, XBrushes.Black, rectDatos, XStringFormats.Default);
                        i++;
                    }

                    var rectCabezeraLista = new XRect(0, XUnit.FromCentimeter(18), pagina.Width, 0);
                    gfx.DrawString("   RUT            /                     Nombre                     /      Sexo      /    Fecha Nac.", fuenteDatos, colorLetras, rectCabezeraLista, XStringFormats.TopCenter);
                    gfx.DrawRectangle(new XPen(XColor.FromName("black")), XUnit.FromCentimeter(2.2), XUnit.FromCentimeter(17.7), pagina.Width - 120, 30);
                    var integrantes = new GeneralBo().ObtenerIntegrantesFamilia(familia.IdFamilia);
                    i = 0;
                    foreach (var integrante in integrantes)
                    {
                        var rut = integrante.RUT.ToString("N0") + "-" + integrante.DV;
                        var nombre = integrante.Nombres + " " + integrante.ApPaterno + " " + integrante.ApMaterno;
                        var sexo = integrante.Sexo ? "Masculino" : "Femenino";
                        var fechaNac = integrante.FechaNac.ToShortDateString();
                        var rectLista = new XRect(0, XUnit.FromCentimeter(19 + i), pagina.Width, 0);
                        gfx.DrawString(rut + "  /  " + nombre + "  /  " + sexo + "  /  " + fechaNac, fuenteDatosCampos, colorLetras, rectLista, XStringFormats.TopCenter);
                        i++;
                    }

                    var rectPie = new XRect(XUnit.FromCentimeter(11.5), XUnit.FromCentimeter(25), 0, 0);
                    gfx.DrawString(DateTime.Today.ToLongDateString(), fuenteDatos, colorLetras, rectPie, XStringFormats.TopLeft);

                    var nombreArchivo = "Familia_" + familia.IdFamilia;
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
                    var datos = new FamiliasBo().ObtenerFamilia(int.Parse(e.CommandArgument.ToString()));
                    btnIngresar.CommandArgument = datos.IdFamilia.ToString("D");
                    tbIdFamilia.Text = datos.IdFamilia.ToString("D");
                    tbFolio.Text = datos.Folio.ToString("D");
                    tbNombreFamilia.Text = datos.NombreFamilia;
                    tbDireccion.Text = datos.Direccion;
                    tbReferenciaDir.Text = datos.ReferenciaDir;
                    tbTelefonoUno.Text = datos.Telefono1.ToString("D");
                    tbTelefonoDos.Text = datos.Telefono2.ToString();
                    ddlGestorFamiliar.SelectedValue = datos.IdGestorFamiliar.ToString("D");
                    btnIngresar.Text = "Modificar";
                    MostrarIngresoFamilia(null, null);
                    break;

                case "Eliminar":
                    var mensaje = new FamiliasBo().EliminarFamilia(int.Parse(e.CommandArgument.ToString())) > 0
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
        protected void MostrarIngresoFamilia(object sender, EventArgs e)
        {
            tblListaFamilias.Visible = false;
            tblIngresoFamilia.Visible = true;
        }

        /// <summary>
        /// Método que alterna entre las vistas.
        /// </summary>
        /// <param name="sender">Objeto del evento</param>
        /// <param name="e">Argumentos del evento</param>
        protected void MostrarListaFamilias(object sender, EventArgs e)
        {
            tblIngresoFamilia.Visible = false;
            tblListaFamilias.Visible = true;
        }

        /// <summary>
        /// Método que carga la grilla
        /// </summary>
        private void CargarGrilla()
        {
            gvFamilias.DataSource = new FamiliasBo().ObtenerFamilias();
            gvFamilias.DataBind();
        }

        /// <summary>
        /// Método que filtra la lista de integrantes
        /// </summary>
        /// <param name="sender">Objeto del evento</param>
        /// <param name="e">Argumentos del evento</param>
        protected void FiltrarIntegrantes(object sender, EventArgs e)
        {
            if (lbxIntegrantes.Items.Count <= 0) return;
            //var texto = tbFiltroIntegrantes.Text.Trim().ToLower();
            //var integrantes = lbxIntegrantes.Items;
            var filtro = from integrante in new IntegrantesBo().ObtenerIntegrantes()
                         //where integrante.Nombres.ToLower().Contains(texto) ||
                         //      integrante.ApPaterno.ToLower().Contains(texto) ||
                         //      integrante.ApMaterno.ToLower().Contains(texto)
                         select new
                         {
                             integrante.RUT,
                             NombreIntegrante = integrante.Nombres + " " + integrante.ApPaterno + " " + integrante.ApMaterno
                         };
            lbxIntegrantes.DataSource = filtro;
            lbxIntegrantes.DataTextField = "NombreIntegrante";
            lbxIntegrantes.DataValueField = "RUT";
            lbxIntegrantes.DataBind();
        }

        /// <summary>
        /// Método que agrega un integrante a la familia
        /// </summary>
        /// <param name="sender">Objeto del evento</param>
        /// <param name="e">Argumentos del evento</param>
        protected void AgregarIntegrante(object sender, EventArgs e)
        {
            MoverItems(true);
        }

        /// <summary>
        /// Método que quita un integrante de la familia
        /// </summary>
        /// <param name="sender">Objeto del evento</param>
        /// <param name="e">Argumentos del evento</param>
        protected void QuitarIntegrante(object sender, EventArgs e)
        {
            MoverItems(false);
        }

        /// <summary>
        /// Método que agrega o quita integrantes de la familia
        /// </summary>
        /// <param name="agregar">Agregar o Quitar</param>
        private void MoverItems(bool agregar)
        {
            var lbxAgrega = agregar ? lbxFamilia : lbxIntegrantes;
            var lbxQuita = agregar ? lbxIntegrantes : lbxFamilia;
            for (var i = lbxQuita.Items.Count - 1; i >= 0; i--)
            {
                if (!lbxQuita.Items[i].Selected) continue;

                lbxAgrega.Items.Add(lbxQuita.Items[i]);
                lbxAgrega.ClearSelection();
                lbxQuita.Items.Remove(lbxQuita.Items[i]);
            }
        }
    }
}
<%@ Page Title="" Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="Familias.aspx.cs" Inherits="SisGES.Vista.Familias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <section id="content" class="clearfix">
        <!-- Title -->
        <div id="content-title">Familias</div>

        <!-- BEGIN PAGE -->
        <section id="page">
            <!-- BEGIN PAGE CONTENT -->
            <div id="pg-content" class="clearfix">
                <asp:Table runat="server" Width="100%" HorizontalAlign="Center">
                    <asp:TableRow runat="server">
                        <asp:TableCell runat="server" HorizontalAlign="Right">
                            <asp:Button runat="server" ID="btnListaFamilias" Width="120px" Height="30px" Text="Lista de Familias"
                                OnClick="MostrarListaFamilias" CausesValidation="False" />
                        </asp:TableCell>
                        <asp:TableCell runat="server" Width="100px" />
                        <asp:TableCell runat="server" HorizontalAlign="Left">
                            <asp:Button runat="server" ID="btnIngresoFamilia" Width="120px" Height="30px" Text="Crear Familia"
                                OnClick="MostrarIngresoFamilia" CausesValidation="False" />
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
                <br />
                <asp:Table runat="server" ID="tblListaFamilias" HorizontalAlign="Center" Width="100%">
                    <asp:TableRow runat="server">
                        <asp:TableCell runat="server" HorizontalAlign="Center" VerticalAlign="Middle">
                            <br />
                            <asp:GridView runat="server" ID="gvFamilias" HorizontalAlign="Center" GridLines="Both"
                                AutoGenerateColumns="False" OnRowCommand="FamiliasRowCommand" CssClass="TablaDatos">
                                <Columns>
                                    <asp:BoundField HeaderText="ID Familia" DataField="IdFamilia" HeaderStyle-Width="80px" />
                                    <asp:BoundField HeaderText="Folio" DataField="Folio" HeaderStyle-Width="80px" />
                                    <asp:BoundField HeaderText="Familia" DataField="NombreFamilia" HeaderStyle-Width="120px" />
                                    <asp:TemplateField HeaderText="Gestor Familiar" HeaderStyle-Width="100px">
                                        <ItemTemplate>
                                            <asp:Label runat="server" Text='<%# Eval("GEN_GestoresFamiliares.Nombres") + " " + Eval("GEN_GestoresFamiliares.ApPaterno") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Acciones" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:ImageButton runat="server" ID="ibDescargaPdf" ImageUrl="~/images/pdf.png" CommandName="DescargaPdf"
                                                CommandArgument='<%# Eval("IdFamilia")%>' ToolTip="Descargar PDF" />
                                            <asp:ImageButton runat="server" ID="ibEditar" ImageUrl="~/images/edit.png" CommandName="Editar"
                                                CommandArgument='<%# Eval("IdFamilia")%>' ToolTip="Editar" />
                                            <asp:ImageButton runat="server" ID="ibEliminar" ImageUrl="~/images/delete.png" CommandName="Eliminar"
                                                CommandArgument='<%# Eval("IdFamilia") %>' ToolTip="Eliminar" OnClientClick="return confirm('¿Está seguro que desea ELIMINAR la familia?');" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <br />
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
                <asp:Table runat="server" ID="tblIngresoFamilia" HorizontalAlign="Center" Width="100%" Visible="False">
                    <asp:TableRow>
                        <asp:TableCell runat="server">
                            <br />
                            <asp:Table runat="server" CssClass="comment-form-ingreso" Width="100%">
                                <asp:TableRow>
                                    <asp:TableCell runat="server" Height="40px" HorizontalAlign="Right">
                                        <asp:RequiredFieldValidator runat="server" ControlToValidate="tbIdFamilia" InitialValue="" Text="*" CssClass="Mensaje" Style="margin-right: 5px;" />
                                        <asp:Label runat="server" Text="ID Familia:" Style="padding-right: 5px;" />
                                    </asp:TableCell>
                                    <asp:TableCell runat="server">
                                        <asp:TextBox runat="server" ID="tbIdFamilia" Width="90px" MaxLength="9" />
                                    </asp:TableCell>
                                    <asp:TableCell runat="server" Width="100px" HorizontalAlign="Right">
                                        <asp:Label runat="server" Text="Folio:" Style="padding-right: 5px;" />
                                    </asp:TableCell>
                                    <asp:TableCell runat="server">
                                        <asp:TextBox runat="server" ID="tbFolio" Width="90px" MaxLength="9" />
                                    </asp:TableCell>
                                    <asp:TableCell runat="server" HorizontalAlign="Right">
                                        <asp:Label runat="server" Text="Gestor Familiar:" Style="padding-right: 5px;" />
                                    </asp:TableCell>
                                    <asp:TableCell runat="server">
                                        <asp:DropDownList runat="server" ID="ddlGestorFamiliar" Width="150px" Height="30px" />
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableCell runat="server" Width="120px" Height="40px" HorizontalAlign="Right">
                                        <asp:RequiredFieldValidator runat="server" ControlToValidate="tbNombreFamilia" InitialValue="" Text="*" CssClass="Mensaje" Style="margin-right: 5px;" />
                                        <asp:Label runat="server" Text="Nombre Familia:" Style="padding-right: 5px;" />
                                    </asp:TableCell>
                                    <asp:TableCell runat="server" Width="200px">
                                        <asp:TextBox runat="server" ID="tbNombreFamilia" Width="200px" />
                                    </asp:TableCell>
                                    <asp:TableCell runat="server" Height="40px" HorizontalAlign="Right">
                                        <asp:RequiredFieldValidator runat="server" ControlToValidate="tbTelefonoUno" InitialValue="" Text="*" CssClass="Mensaje" Style="margin-right: 5px;" />
                                        <asp:Label runat="server" Text="Telefono 1:" Style="padding-right: 5px;" />
                                    </asp:TableCell>
                                    <asp:TableCell runat="server" Width="140px">
                                        <asp:TextBox runat="server" ID="tbTelefonoUno" Width="100px" />
                                    </asp:TableCell>
                                    <asp:TableCell runat="server" HorizontalAlign="Right">
                                        <asp:Label runat="server" Text="Telefono 2:" Style="padding-right: 5px;" />
                                    </asp:TableCell>
                                    <asp:TableCell runat="server">
                                        <asp:TextBox runat="server" ID="tbTelefonoDos" Width="100px" />
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableCell runat="server" Height="40px" HorizontalAlign="Right">
                                        <asp:RequiredFieldValidator runat="server" ControlToValidate="tbDireccion" InitialValue="" Text="*" CssClass="Mensaje" Style="margin-right: 5px;" />
                                        <asp:Label runat="server" Text="Dirección:" Style="padding-right: 5px;" />
                                    </asp:TableCell>
                                    <asp:TableCell runat="server" ColumnSpan="2">
                                        <asp:TextBox runat="server" ID="tbDireccion" Width="300px" />
                                    </asp:TableCell>
                                    <asp:TableCell runat="server" HorizontalAlign="Right">
                                        <asp:RequiredFieldValidator runat="server" ControlToValidate="tbReferenciaDir" InitialValue="" Text="*" CssClass="Mensaje" Style="margin-right: 5px;" />
                                        <asp:Label runat="server" Text="Referencia:" Style="padding-right: 5px;" />
                                    </asp:TableCell>
                                    <asp:TableCell runat="server" ColumnSpan="2">
                                        <asp:TextBox runat="server" ID="tbReferenciaDir" Width="300px" />
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableCell runat="server" HorizontalAlign="Center" VerticalAlign="Middle" ColumnSpan="6">
                                        <br />
                                        <asp:UpdatePanel runat="server">
                                            <ContentTemplate>
                                                <asp:Table runat="server" Width="100%" BorderWidth="1px">
                                                    <asp:TableRow>
                                                        <asp:TableCell runat="server" HorizontalAlign="Center" VerticalAlign="Bottom">
                                                            <asp:Label runat="server" Text="Integrantes de la Familia" />
                                                        </asp:TableCell>
                                                        <asp:TableCell runat="server" Width="70px" Height="25px" />
                                                        <asp:TableCell runat="server" HorizontalAlign="Center" VerticalAlign="Bottom">
                                                            <asp:Label runat="server" Text="Integrantes Disponibles" />
                                                        </asp:TableCell>
                                                    </asp:TableRow>
                                                    <asp:TableRow>
                                                        <asp:TableCell runat="server" HorizontalAlign="Center" VerticalAlign="Middle">
                                                            <asp:ListBox runat="server" ID="lbxFamilia" Width="350px" Height="200px" />
                                                        </asp:TableCell>
                                                        <asp:TableCell runat="server" Height="230px" HorizontalAlign="Center" VerticalAlign="Middle">
                                                            <asp:Button runat="server" ID="btnAgregarIntegrante" Text="<<" Width="50px" CausesValidation="False"
                                                                OnClick="AgregarIntegrante" />
                                                            <br />
                                                            <br />
                                                            <br />
                                                            <asp:Button runat="server" ID="btnQuitarIntegrante" Text=">>" Width="50px" CausesValidation="False"
                                                                OnClick="QuitarIntegrante" />
                                                        </asp:TableCell>
                                                        <asp:TableCell runat="server" HorizontalAlign="Center" VerticalAlign="Middle">
                                                            <%--asp:TextBox runat="server" ID="tbFiltroIntegrantes" Width="280px" BorderWidth="1px" />
                                                            <asp:Button runat="server" ID="btnFiltrar" Text="Filtrar" Width="70px" CausesValidation="False"
                                                                OnClick="FiltrarIntegrantes" />
                                                            <br /--%>
                                                            <asp:ListBox runat="server" ID="lbxIntegrantes" Width="350px" Height="200px" />
                                                        </asp:TableCell>
                                                    </asp:TableRow>
                                                </asp:Table>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <br />
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableCell runat="server" ColumnSpan="3" HorizontalAlign="Right" Height="60px">
                                        <asp:Button runat="server" ID="btnIngresar" Text="Guardar" Width="120px" Height="25px"
                                            OnClick="IngresarFamilia" CausesValidation="True" />
                                    </asp:TableCell>
                                    <asp:TableCell runat="server" ColumnSpan="3" HorizontalAlign="Left">
                                        <asp:Button runat="server" ID="btnLimpiar" Text="Limpiar" Width="120px" Height="25px"
                                            OnClick="LimpiarControles" CausesValidation="False" Style="margin-left: 70px;" />
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                            <div runat="server" id="divMensajes" style="text-align: center;">
                                <asp:Label runat="server" ID="tbMensajes" />
                            </div>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
            </div>
            <!-- end #pg-content -->
            <!-- END PAGE CONTENT -->
        </section>
        <!-- END PAGE -->
    </section>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="GestoresFamiliares.aspx.cs" Inherits="SisGES.Vista.Administracion.GestoresFamiliares" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <section id="content" class="clearfix">
        <!-- Title -->
        <div id="content-title">Gestores Familiares</div>

        <!-- BEGIN PAGE -->
        <section id="page">
            <!-- BEGIN PAGE CONTENT -->
            <div id="pg-content" class="clearfix">
                <asp:Table runat="server" Width="100%" HorizontalAlign="Center">
                    <asp:TableRow runat="server">
                        <asp:TableCell runat="server" HorizontalAlign="Right">
                            <asp:Button runat="server" ID="btnListaGestores" Width="120px" Height="30px" Text="Lista Gestores"
                                OnClick="MostrarListaGestores" CausesValidation="False" />
                        </asp:TableCell>
                        <asp:TableCell runat="server" Width="100px" />
                        <asp:TableCell runat="server" HorizontalAlign="Left">
                            <asp:Button runat="server" ID="btnIngresoGestor" Width="120px" Height="30px" Text="Ingresar Gestor"
                                OnClick="MostrarIngresoGestores" CausesValidation="False" />
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
                <br />
                <asp:Table runat="server" ID="tblListaGestores" HorizontalAlign="Center" Width="100%">
                    <asp:TableRow runat="server">
                        <asp:TableCell runat="server" HorizontalAlign="Center" VerticalAlign="Middle">
                            <br />
                            <asp:GridView runat="server" ID="gvGestoresFamiliares" HorizontalAlign="Center" GridLines="Both"
                                AutoGenerateColumns="False" OnRowCommand="GestoresFamiliaresRowCommand" CssClass="TablaDatos">
                                <Columns>
                                    <asp:BoundField HeaderText="Nombres" DataField="Nombres" HeaderStyle-Width="120px" />
                                    <asp:BoundField HeaderText="Apellido Paterno" DataField="ApPaterno" HeaderStyle-Width="110px" />
                                    <asp:BoundField HeaderText="Apellido Materno" DataField="ApMaterno" HeaderStyle-Width="110px" />
                                    <asp:BoundField HeaderText="Teléfono" DataField="Telefono" HeaderStyle-Width="70px" />
                                    <asp:BoundField HeaderText="Email" DataField="Email" HeaderStyle-Width="130px" />
                                    <asp:TemplateField HeaderText="Acciones" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:ImageButton runat="server" ID="ibEditar" ImageUrl="~/images/edit.png" CommandName="Editar"
                                                CommandArgument='<%# Eval("IdGestorFamiliar")%>' />
                                            <asp:ImageButton runat="server" ID="ibEliminar" ImageUrl="~/images/delete.png"
                                                CommandName="Eliminar" CommandArgument='<%# Eval("IdGestorFamiliar") %>' OnClientClick="return confirm('¿Está seguro que desea ELIMINAR el gestor?');" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <br />
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
                <asp:Table runat="server" ID="tblIngresoGestor" HorizontalAlign="Center" Width="100%" Visible="False">
                    <asp:TableRow>
                        <asp:TableCell runat="server" ID="tbcDatosGestor">
                            <br />
                            <asp:Table runat="server" CssClass="comment-form-ingreso">
                                <asp:TableRow>
                                    <asp:TableCell runat="server" Width="80px" Height="40px">
                                        <asp:RequiredFieldValidator runat="server" ControlToValidate="tbNombres" InitialValue="" Text="*" CssClass="Mensaje" Style="margin-right: 5px;" />
                                        <asp:Label runat="server" Text="Nombres:" Style="padding-right: 5px;" />
                                    </asp:TableCell>
                                    <asp:TableCell runat="server" Width="200px">
                                        <asp:TextBox runat="server" ID="tbNombres" Width="170px" />
                                    </asp:TableCell>
                                    <asp:TableCell runat="server" Width="130px">
                                        <asp:RequiredFieldValidator runat="server" ControlToValidate="tbApPaterno" InitialValue="" Text="*" CssClass="Mensaje" Style="margin-right: 5px;" />
                                        <asp:Label runat="server" Text="Apellido Paterno:" Style="padding-right: 5px;" />
                                    </asp:TableCell>
                                    <asp:TableCell runat="server" Width="180px">
                                        <asp:TextBox runat="server" ID="tbApPaterno" Width="150px" />
                                    </asp:TableCell>
                                    <asp:TableCell runat="server" Width="130px">
                                        <asp:Label runat="server" Text="Apellido Materno:" Style="padding-right: 5px;" />
                                    </asp:TableCell>
                                    <asp:TableCell runat="server" Width="180px">
                                        <asp:TextBox runat="server" ID="tbApMaterno" Width="150px" />
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableCell runat="server" Height="40px">
                                        <asp:RequiredFieldValidator runat="server" ControlToValidate="tbTelefono" InitialValue="" Text="*" CssClass="Mensaje" Style="margin-right: 5px;" />
                                        <asp:Label runat="server" Text="Telefono:" Style="padding-right: 5px;" />
                                    </asp:TableCell>
                                    <asp:TableCell runat="server">
                                        <asp:TextBox runat="server" ID="tbTelefono" MaxLength="9" Width="120px" />
                                    </asp:TableCell>
                                    <asp:TableCell runat="server">
                                        <asp:RequiredFieldValidator runat="server" ControlToValidate="tbEmail" InitialValue="" Text="*" CssClass="Mensaje" Style="margin-right: 5px;" />
                                        <asp:Label runat="server" Text="Email:" Style="padding-right: 5px;" />
                                    </asp:TableCell>
                                    <asp:TableCell runat="server" ColumnSpan="3">
                                        <asp:TextBox runat="server" ID="tbEmail" Width="200px" />
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableCell runat="server" ColumnSpan="3" HorizontalAlign="Right" Height="60px">
                                        <asp:Button runat="server" ID="btnIngresar" Text="Guardar" Width="120px" Height="25px"
                                            OnClick="IngresarGestor" Style="margin-right: 35px;" />
                                    </asp:TableCell>
                                    <asp:TableCell runat="server" ColumnSpan="3" HorizontalAlign="Left">
                                        <asp:Button runat="server" ID="btnLimpiar" Text="Limpiar" Width="120px" Height="25px"
                                            OnClick="LimpiarControles" CausesValidation="False" Style="margin-left: 35px;" />
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                            <br />
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

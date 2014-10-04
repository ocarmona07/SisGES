<%@ Page Title="" Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="SisGES.Vista.Administracion.Usuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <section id="content" class="clearfix">
        <!-- Title -->
        <div id="content-title">Usuarios</div>

        <!-- BEGIN PAGE -->
        <section id="page">
            <!-- BEGIN PAGE CONTENT -->
            <div id="pg-content" class="clearfix">
                <asp:Table runat="server" Width="100%" HorizontalAlign="Center">
                    <asp:TableRow runat="server">
                        <asp:TableCell runat="server" HorizontalAlign="Right">
                            <asp:Button runat="server" ID="btnListaUsuarios" Width="120px" Height="30px" Text="Lista Usuarios"
                                OnClick="MostrarListaUsuarios" CausesValidation="False" />
                        </asp:TableCell>
                        <asp:TableCell runat="server" Width="100px" />
                        <asp:TableCell runat="server" HorizontalAlign="Left">
                            <asp:Button runat="server" ID="btnIngresoUsuario" Width="120px" Height="30px" Text="Ingresar Usuario"
                                OnClick="MostrarIngresoUsuario" CausesValidation="False" />
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
                <br />
                <asp:Table runat="server" ID="tblListaUsuarios" HorizontalAlign="Center" Width="100%">
                    <asp:TableRow runat="server">
                        <asp:TableCell runat="server" HorizontalAlign="Center" VerticalAlign="Middle">
                            <br />
                            <asp:GridView runat="server" ID="gvUsuarios" HorizontalAlign="Center" GridLines="Both"
                                AutoGenerateColumns="False" OnRowCommand="UsuariosRowCommand" CssClass="TablaDatos">
                                <Columns>
                                    <asp:TemplateField HeaderText="RUT" HeaderStyle-Width="90px" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label runat="server" Text='<%# Eval("RUT", "{0:N0}") + "-" + Eval("DV") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Nombre" HeaderStyle-Width="180px" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label runat="server" Text='<%# Eval("Nombres") + " " + Eval("ApPaterno") + " " + Eval("ApMaterno") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="Celular" DataField="Celular" HeaderStyle-Width="70px" />
                                    <asp:BoundField HeaderText="Email" DataField="Email" HeaderStyle-Width="130px" />
                                    <asp:BoundField HeaderText="ROL" DataField="GEN_ROL.Rol" HeaderStyle-Width="80px" />
                                    <asp:TemplateField HeaderText="Acciones" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:ImageButton runat="server" ID="ibImagen" ImageUrl="~/images/user.png" CommandName="ImagenUsuario"
                                                CommandArgument='<%# Eval("Imagen")%>' ToolTip="Ver imagen" Visible='<%# Eval("Imagen").ToString() != "" %>' />
                                            <asp:ImageButton runat="server" ID="ibEditar" ImageUrl="~/images/edit.png" CommandName="Editar"
                                                CommandArgument='<%# Eval("RUT")%>' ToolTip="Editar" />
                                            <asp:ImageButton runat="server" ID="ibEliminar" ImageUrl="~/images/delete.png" CommandName="Eliminar"
                                                CommandArgument='<%# Eval("RUT") %>' ToolTip="Eliminar" OnClientClick="return confirm('¿Está seguro que desea ELIMINAR el usuario?');" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <br />
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
                <asp:Table runat="server" ID="tblIngresoUsuario" HorizontalAlign="Center" Width="100%" Visible="False">
                    <asp:TableRow>
                        <asp:TableCell runat="server">
                            <br />
                            <asp:Table runat="server" CssClass="comment-form-ingreso">
                                <asp:TableRow>
                                    <asp:TableCell runat="server" Height="40px" HorizontalAlign="Right">
                                        <asp:Label runat="server" Text="RUT:" Style="padding-right: 5px;" />
                                    </asp:TableCell>
                                    <asp:TableCell runat="server">
                                        <asp:TextBox runat="server" ID="tbRUT" Width="76px" MaxLength="8" />
                                        <span>- </span>
                                        <asp:TextBox runat="server" ID="tbDV" Width="20px" MaxLength="1" Enabled="False" />
                                    </asp:TableCell>
                                    <asp:TableCell runat="server" HorizontalAlign="Right">
                                        <asp:Label runat="server" Text="Rol:" Style="padding-right: 5px;" />
                                    </asp:TableCell>
                                    <asp:TableCell runat="server" ColumnSpan="3">
                                        <asp:DropDownList runat="server" ID="ddlRol" Width="150px" Height="30px" />
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableCell runat="server" Width="80px" Height="40px" HorizontalAlign="Right">
                                        <asp:RequiredFieldValidator runat="server" ControlToValidate="tbNombres" InitialValue="" Text="*" CssClass="Mensaje" Style="margin-right: 5px;" />
                                        <asp:Label runat="server" Text="Nombres:" Style="padding-right: 5px;" />
                                    </asp:TableCell>
                                    <asp:TableCell runat="server" Width="180px">
                                        <asp:TextBox runat="server" ID="tbNombres" Width="170px" />
                                    </asp:TableCell>
                                    <asp:TableCell runat="server" Width="170px" HorizontalAlign="Right">
                                        <asp:RequiredFieldValidator runat="server" ControlToValidate="tbApPaterno" InitialValue="" Text="*" CssClass="Mensaje" Style="margin-right: 5px;" />
                                        <asp:Label runat="server" Text="Apellido Paterno:" Style="padding-right: 5px;" />
                                    </asp:TableCell>
                                    <asp:TableCell runat="server" Width="180px">
                                        <asp:TextBox runat="server" ID="tbApPaterno" Width="130px" />
                                    </asp:TableCell>
                                    <asp:TableCell runat="server" Width="140px" HorizontalAlign="Right">
                                        <asp:RequiredFieldValidator runat="server" ControlToValidate="tbApMaterno" InitialValue="" Text="*" CssClass="Mensaje" Style="margin-right: 5px;" />
                                        <asp:Label runat="server" Text="Apellido Materno:" Style="padding-right: 5px;" />
                                    </asp:TableCell>
                                    <asp:TableCell runat="server" Width="160px">
                                        <asp:TextBox runat="server" ID="tbApMaterno" Width="130px" />
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableCell runat="server" Height="40px" HorizontalAlign="Right">
                                        <asp:Label runat="server" Text="Telefono:" Style="padding-right: 5px;" />
                                    </asp:TableCell>
                                    <asp:TableCell runat="server">
                                        <asp:TextBox runat="server" ID="tbTelefono" MaxLength="9" Width="130px" />
                                    </asp:TableCell>
                                    <asp:TableCell runat="server" HorizontalAlign="Right">
                                        <asp:RequiredFieldValidator runat="server" ControlToValidate="tbCelular" InitialValue="" Text="*" CssClass="Mensaje" Style="margin-right: 5px;" />
                                        <asp:Label runat="server" Text="Celular:" Style="padding-right: 5px;" />
                                    </asp:TableCell>
                                    <asp:TableCell runat="server">
                                        <asp:TextBox runat="server" ID="tbCelular" MaxLength="9" Width="130px" />
                                    </asp:TableCell>
                                    <asp:TableCell runat="server" HorizontalAlign="Right">
                                        <asp:RequiredFieldValidator runat="server" ControlToValidate="tbEmail" InitialValue="" Text="*" CssClass="Mensaje" Style="margin-right: 5px;" />
                                        <asp:Label runat="server" Text="Email:" Style="padding-right: 5px;" />
                                    </asp:TableCell>
                                    <asp:TableCell runat="server">
                                        <asp:TextBox runat="server" ID="tbEmail" Width="190px" />
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableCell runat="server" Height="40px" HorizontalAlign="Right">
                                        <asp:RequiredFieldValidator runat="server" ID="rfvClave" ControlToValidate="tbClaveUno" InitialValue="" Text="*" CssClass="Mensaje" Style="margin-right: 5px;" />
                                        <asp:Label runat="server" Text="Contraseña:" Style="padding-right: 5px;" />
                                    </asp:TableCell>
                                    <asp:TableCell runat="server">
                                        <asp:TextBox runat="server" ID="tbClaveUno" MaxLength="9" Width="130px" TextMode="Password" />
                                    </asp:TableCell>
                                    <asp:TableCell runat="server" HorizontalAlign="Right">
                                        <asp:CompareValidator runat="server" ControlToValidate="tbClaveUno" ControlToCompare="tbClaveDos" Text="*" CssClass="Mensaje" Style="margin-right: 5px;" />
                                        <asp:Label runat="server" Text="Reingrese Contraseña:" Style="padding-right: 5px;" />
                                    </asp:TableCell>
                                    <asp:TableCell runat="server">
                                        <asp:TextBox runat="server" ID="tbClaveDos" MaxLength="9" Width="130px" TextMode="Password" />
                                    </asp:TableCell>
                                    <asp:TableCell runat="server" HorizontalAlign="Right">
                                        <asp:Label runat="server" Text="Estado:" Style="padding-right: 5px;" />
                                    </asp:TableCell>
                                    <asp:TableCell runat="server">
                                        <asp:CheckBox runat="server" ID="chkEstado" Width="30px" Checked="True" />
                                        <span>Activo</span>
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableCell runat="server" ColumnSpan="3" HorizontalAlign="Right" Height="60px">
                                        <asp:Button runat="server" ID="btnIngresar" Text="Guardar" Width="120px" Height="25px"
                                            OnClick="IngresarUsuario" CausesValidation="True" Style="margin-right: 35px;" />
                                    </asp:TableCell>
                                    <asp:TableCell runat="server" ColumnSpan="3" HorizontalAlign="Left">
                                        <asp:Button runat="server" ID="btnLimpiar" Text="Limpiar" Width="120px" Height="25px"
                                            OnClick="LimpiarControles" CausesValidation="False" Style="margin-left: 35px;" />
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

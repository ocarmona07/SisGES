<%@ Page Title="" Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="Integrantes.aspx.cs" Inherits="SisGES.Vista.Integrantes" %>

<%@ Register TagPrefix="act" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=4.1.7.1213, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <section id="content" class="clearfix">
        <!-- Title -->
        <div id="content-title">Integrantes</div>

        <!-- BEGIN PAGE -->
        <section id="page">
            <!-- BEGIN PAGE CONTENT -->
            <div id="pg-content" class="clearfix">
                <asp:Table runat="server" Width="100%" HorizontalAlign="Center">
                    <asp:TableRow runat="server">
                        <asp:TableCell runat="server" HorizontalAlign="Right">
                            <asp:Button runat="server" ID="btnBuscarIntegrante" Width="120px" Height="30px" Text="Buscar Integrante"
                                OnClick="MostrarBuscarIntegrante" CausesValidation="False" />
                        </asp:TableCell>
                        <asp:TableCell runat="server" Width="50px" />
                        <asp:TableCell runat="server" HorizontalAlign="Center">
                            <asp:Button runat="server" ID="btnListaIntegrantes" Width="120px" Height="30px" Text="Lista Integrantes"
                                OnClick="MostrarListaIntegrantes" CausesValidation="False" />
                        </asp:TableCell>
                        <asp:TableCell runat="server" Width="50px" />
                        <asp:TableCell runat="server" HorizontalAlign="Left">
                            <asp:Button runat="server" ID="btnIngresoIntegrante" Width="120px" Height="30px" Text="Ingresar Integrante"
                                OnClick="MostrarIngresoIntegrante" CausesValidation="False" />
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
                <br />
                <asp:Table runat="server" ID="tblListaIntegrantes" HorizontalAlign="Center" Width="100%">
                    <asp:TableRow runat="server">
                        <asp:TableCell runat="server" HorizontalAlign="Center" VerticalAlign="Middle">
                            <br />
                            <asp:GridView runat="server" ID="gvIntegrantes" HorizontalAlign="Center" GridLines="Both"
                                AutoGenerateColumns="False" OnRowCommand="IntegrantesRowCommand" CssClass="TablaDatos">
                                <Columns>
                                    <asp:TemplateField HeaderText="RUT" HeaderStyle-Width="90px" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label runat="server" Text='<%# Eval("RUT", "{0:N0}") + "-" + Eval("DV") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Nombre" HeaderStyle-Width="200px" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label runat="server" Text='<%# Eval("Nombres") + " " + Eval("ApPaterno") + " " + Eval("ApMaterno") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Sexo" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label runat="server" Text='<%# bool.Parse(Eval("Sexo").ToString()) ? "Masculino" : "Femenino"  %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="Fecha Nac." DataField="FechaNac" DataFormatString="{0:dd/MM/yyyy}" HeaderStyle-Width="100px" />
                                    <asp:TemplateField HeaderText="Acciones" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:ImageButton runat="server" ID="ibDescargaPdf" ImageUrl="~/images/pdf.png" CommandName="DescargaPdf"
                                                CommandArgument='<%# Eval("RUT")%>' ToolTip="Descargar PDF" />
                                            <asp:ImageButton runat="server" ID="ibEditar" ImageUrl="~/images/edit.png" CommandName="Editar"
                                                CommandArgument='<%# Eval("RUT")%>' ToolTip="Editar" />
                                            <asp:ImageButton runat="server" ID="ibEliminar" ImageUrl="~/images/delete.png" CommandName="Eliminar"
                                                CommandArgument='<%# Eval("RUT") %>' ToolTip="Eliminar" OnClientClick="return confirm('¿Está seguro que desea ELIMINAR el integrante?');" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <br />
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
                <asp:Table runat="server" ID="tblBuscarIntegrante" HorizontalAlign="Center" Width="100%" Visible="False">
                    <asp:TableRow>
                        <asp:TableCell runat="server" HorizontalAlign="Center">
                            <br />
                            <asp:Table runat="server" CssClass="comment-form-ingreso">
                                <asp:TableRow>
                                    <asp:TableCell runat="server" Width="150px" Height="40px" HorizontalAlign="Right">
                                        <asp:Label runat="server" Text="Buscar por RUT:" Style="padding-right: 5px;" />
                                    </asp:TableCell>
                                    <asp:TableCell runat="server" Width="150px">
                                        <asp:TextBox runat="server" ID="tbBuscaRUT" Width="76px" MaxLength="8" />
                                        <span>- </span>
                                        <asp:TextBox runat="server" ID="tbBuscaDV" Width="20px" MaxLength="1" />
                                    </asp:TableCell>
                                    <asp:TableCell runat="server" Width="130px">
                                        <asp:Button runat="server" ID="btnBuscar" Text="Buscar" Width="120px" Height="25px"
                                            CausesValidation="False" OnClick="BuscarPorRut" />
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                            <br />
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
                <asp:Table runat="server" ID="tblIngresoIntegrante" HorizontalAlign="Center" Width="100%" Visible="False">
                    <asp:TableRow>
                        <asp:TableCell runat="server">
                            <br />
                            <asp:Table runat="server" CssClass="comment-form-ingreso">
                                <asp:TableRow>
                                    <asp:TableCell runat="server" Height="40px" HorizontalAlign="Right">
                                        <asp:Label runat="server" Text="RUT:" Style="padding-right: 5px;" />
                                    </asp:TableCell>
                                    <asp:TableCell runat="server" ColumnSpan="5">
                                        <asp:TextBox runat="server" ID="tbRUT" Width="76px" MaxLength="8" />
                                        <span>- </span>
                                        <asp:TextBox runat="server" ID="tbDV" Width="20px" MaxLength="1" />
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
                                        <asp:Label runat="server" Text="Parentesco:" Style="padding-right: 5px;" />
                                    </asp:TableCell>
                                    <asp:TableCell runat="server">
                                        <asp:DropDownList runat="server" ID="ddlParentesco" Width="150px" Height="30px" />
                                    </asp:TableCell>
                                    <asp:TableCell runat="server" HorizontalAlign="Right">
                                        <asp:RequiredFieldValidator runat="server" ControlToValidate="tbFechaNac" InitialValue="" Text="*" CssClass="Mensaje" Style="margin-right: 5px;" />
                                        <asp:Label runat="server" Text="Fecha Nacimiento:" Style="padding-right: 5px;" />
                                    </asp:TableCell>
                                    <asp:TableCell runat="server">
                                        <asp:TextBox runat="server" ID="tbFechaNac" Width="100px" />
                                        <asp:ImageButton runat="server" ID="ibFechaNac" ImageUrl="~/images/calendar.png" Width="24px" CausesValidation="False"
                                            OnClientClick="return false;" Style="margin-left: 5px; background-color: transparent; margin: -10px 5px" />
                                        <act:CalendarExtender ID="calFechaNac" runat="server" TargetControlID="tbFechaNac" PopupButtonID="ibFechaNac" />
                                    </asp:TableCell>
                                    <asp:TableCell runat="server" HorizontalAlign="Right">
                                        <asp:Label runat="server" Text="Sexo:" Style="padding-right: 5px;" />
                                    </asp:TableCell>
                                    <asp:TableCell runat="server">
                                        <asp:RadioButtonList runat="server" ID="rbgSexo" RepeatDirection="Horizontal" Width="110px">
                                            <Items>
                                                <asp:ListItem Text="Masculino" Value="1" Selected="True" />
                                                <asp:ListItem Text="Femenino" Value="0" />
                                            </Items>
                                        </asp:RadioButtonList>
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableCell runat="server" Height="40px" HorizontalAlign="Right">
                                        <asp:Label runat="server" Text="Estado Civil:" Style="padding-right: 5px;" />
                                    </asp:TableCell>
                                    <asp:TableCell runat="server">
                                        <asp:DropDownList runat="server" ID="ddlEstadoCivil" Width="130px" Height="30px" />
                                    </asp:TableCell>
                                    <asp:TableCell runat="server" HorizontalAlign="Right">
                                        <asp:Label runat="server" Text="Nivel Escolar:" Style="padding-right: 5px;" />
                                    </asp:TableCell>
                                    <asp:TableCell runat="server">
                                        <asp:DropDownList runat="server" ID="ddlNivelEscolar" Width="150px" Height="30px" />
                                    </asp:TableCell>
                                    <asp:TableCell runat="server" HorizontalAlign="Right">
                                        <asp:Label runat="server" Text="Ocupación:" Style="padding-right: 5px;" />
                                    </asp:TableCell>
                                    <asp:TableCell runat="server">
                                        <asp:DropDownList runat="server" ID="ddlOcupacion" Width="130px" Height="30px" />
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableCell runat="server" Height="60px" HorizontalAlign="Right">
                                        <asp:Label runat="server" Text="Descripción Ocupación:" Style="padding-right: 5px;" />
                                    </asp:TableCell>
                                    <asp:TableCell runat="server" ColumnSpan="5">
                                        <asp:TextBox runat="server" ID="tbDescOcupacion" Width="500px" Height="60px" TextMode="MultiLine" />
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableCell runat="server" ColumnSpan="3" HorizontalAlign="Right" Height="60px">
                                        <asp:Button runat="server" ID="btnIngresar" Text="Guardar" Width="120px" Height="25px"
                                            OnClick="IngresarIntegrante" CausesValidation="True" />
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

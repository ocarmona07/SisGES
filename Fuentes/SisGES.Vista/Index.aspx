<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="SisGES.Vista.Index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SisGES - Sistema de Gestión de Familias IEF</title>
    <link href="~/Css/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="frmPrincipal" runat="server">
        <asp:Table runat="server" Width="100%" Height="100%" Style="position: absolute;">
            <asp:TableRow>
                <asp:TableCell runat="server" HorizontalAlign="Center" VerticalAlign="Middle">
                    <div id="bodypat">
                        <asp:Table runat="server" BackColor="black" Style="margin: 0 auto; position: absolute; top: 20%; left: 35%;">
                            <asp:TableRow runat="server" Height="120px">
                                <asp:TableCell runat="server" HorizontalAlign="Center" VerticalAlign="Bottom" Width="400px" ColumnSpan="2">
                                    <asp:Image runat="server" ImageUrl="~/images/logo.png"/>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow runat="server" Height="120px">
                                <asp:TableCell runat="server" HorizontalAlign="Center" VerticalAlign="Top" Width="400px" ColumnSpan="2">
                                    <span id="sitename">SisGES</span>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow runat="server" Height="20px">
                                <asp:TableCell runat="server" HorizontalAlign="Right" VerticalAlign="Top">
                                    <h5>
                                        <asp:Label runat="server" Text="RUT:" Style="padding-right: 5px;" />
                                    </h5>
                                </asp:TableCell>
                                <asp:TableCell runat="server" VerticalAlign="Middle" HorizontalAlign="Left">
                                    <p class="contact-form-sender">
                                        <asp:TextBox ID="tbRut" runat="server" Width="120px" />
                                    </p>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow runat="server" Height="20px">
                                <asp:TableCell runat="server" HorizontalAlign="Right" VerticalAlign="Top">
                                    <h5>
                                        <asp:Label runat="server" Text="Contraseña:" Style="padding-right: 5px;" />                                
                                    </h5>
                                </asp:TableCell>
                                <asp:TableCell runat="server" VerticalAlign="Top" HorizontalAlign="Left">
                                    <p class="contact-form-sender">
                                        <asp:TextBox ID="tbClave" runat="server" Width="120px" TextMode="Password" />
                                    </p>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow runat="server" Height="50px">
                                <asp:TableCell runat="server" HorizontalAlign="Center" ColumnSpan="2">
                                    <asp:Button runat="server" ID="btnIngresar" Text="Ingresar" Width="130px" Height="30px"
                                        OnClick="ValidarIngreso" />
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow runat="server" Height="50px">
                                <asp:TableCell runat="server" HorizontalAlign="Center" VerticalAlign="Top" ColumnSpan="2">
                                    <br />
                                    <asp:Label runat="server" ID="lblMensaje" CssClass="Mensaje" />
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                    </div>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </form>
</body>
</html>

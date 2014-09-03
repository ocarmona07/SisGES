<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="SisGES.Vista.Index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SisGES - Sistema de Gestión de Familias IEF</title>
    <link href="~/Css/Estilo.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="frmPrincipal" runat="server">
    <div>
        <asp:Table runat="server">
            <asp:TableRow runat="server" Height="120px">
                <asp:TableCell runat="server" HorizontalAlign="Right" VerticalAlign="Bottom" Width="440px">
                                    <asp:Label runat="server" Text="RUT:" Style="padding-right: 5px;" />
                </asp:TableCell>
                <asp:TableCell runat="server" VerticalAlign="Bottom" Width="500px">
                    <asp:TextBox ID="tbRut" runat="server" Width="120px" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server" Height="50px">
                <asp:TableCell runat="server" HorizontalAlign="Right" VerticalAlign="Middle">
                                    <asp:Label runat="server" Text="Contraseña:" Style="padding-right: 5px;" />                                
                </asp:TableCell>
                <asp:TableCell runat="server" VerticalAlign="Middle">
                    <asp:TextBox ID="tbClave" runat="server" Width="120px" TextMode="Password" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server" Height="50px">
                <asp:TableCell runat="server" HorizontalAlign="Center" ColumnSpan="2">
                    <asp:Button runat="server" ID="btnIngresar" Text="Ingresar" Width="130px" Height="30px"
                        OnClick="ValidarIngreso" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server" Height="150px">
                <asp:TableCell runat="server" HorizontalAlign="Center" VerticalAlign="Top" ColumnSpan="2">
                    <br />
                    <asp:Label runat="server" ID="lblMensaje" CssClass="Mensaje" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </div>
    </form>
</body>
</html>

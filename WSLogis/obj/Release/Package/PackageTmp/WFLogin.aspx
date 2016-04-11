<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WFLogin.aspx.cs" Inherits="WSLogis.WFLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Login</title>
    <link href="~/Content/Site.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table cellspacing="20" cellpadding="20" style="width: 800px; border: 0px; padding: 0px;
            border-collapse: collapse" align="center">
            <tr>
                <td style="width: 150px">
                </td>
                                <td style="width: 150px">
                </td>

                <td style="width: 150px">
                </td>
            </tr>
            <tr>
                <td style="width: 150px">
                </td>
                <td style="width: 500px" align="center">
                    <table style="width: 400px; border: 0px; padding: 4px; border-collapse: collapse">
                        <tr>
                            <td align="center">
                                <table style="border: 0px; padding: 0px; width: 380px; border-collapse: separate">
                                    <tr align="center">
                                        <td colspan="2">
                                            <asp:Label ID="lblTitulo" runat="server" Text="SEIS LOGISTICA" CssClass="TitulitoLog"></asp:Label><br />
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="height: 26px">
                                            <asp:Label CssClass="body_textLog" ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Usuario:</asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="UserName" runat="server" CssClass="textboxLog"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="height: 26px">
                                            <asp:Label CssClass="body_textLog" ID="PasswordLabel" runat="server" AssociatedControlID="Password">Contraseña:</asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="Password" runat="server"   CssClass="textboxLog" TextMode="Password"
                                                AutoPostBack="true" OnTextChanged="Password_TextChanged"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="height: 26px">
                                            &nbsp;</td>
                                        <td align="left">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="2" style="color: red">
                                            <asp:Label ID="lblMensaje" runat="server" Font-Bold="True" ForeColor="Black"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="2">
                                            <asp:LinkButton ID="LoginButton" runat="server" Font-Bold="True" SkinID="label_link"
                                                CommandName="Login" ValidationGroup="logeo" OnClick="LoginButton_Click">Inicio</asp:LinkButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="2" style="color: red">
                                            <asp:LinkButton ID="imbResetear" SkinID="link_grilla" runat="server" AlternateText="Resetear"
                                                CausesValidation="False" CommandArgument='<%# Eval("CodigoUsuario") %>' CommandName="Resetar"
                                                ToolTip="Resetear Clave" OnClientClick="return confirm('¿Esta seguro que desea resetear la clave?')"
                                                OnClick="imbResetear_Click">¿Olvidó su contraseña?</asp:LinkButton>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
                <td style="width: 150px">
                </td>
            </tr>
            <tr>
                <td style="width: 150px">
                </td>
                <td style="width: 500px">
                </td>
                <td style="width: 150px">
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>

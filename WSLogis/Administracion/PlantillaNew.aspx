<%@ Page Title="Registro xxx"  Language="C#" AutoEventWireup="true" CodeBehind="PlantillaNew.aspx.cs" Inherits="WSLogis.Administracion.PlantillaNew" %>

<!DOCTYPE html>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Registro de Empresas</title>
    <link href="~/Content/Site.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"
            EnableScriptLocalization="false">
        </asp:ScriptManager>
        <table style="width: 450px">
            <tr>
                <td>
                    <asp:UpdatePanel ID="updActualizar" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:Panel ID="Panel1" runat="server" Width="450px">
                                <table border="0" style="width: 450px">
                                    <tr>
                                        <td colspan="2">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:Label ID="Label1" runat="server" CssClass="Titulitos" Text="Registro de Empresas"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 145px;">
                                            &nbsp;
                                            <asp:Label ID="lblIdP" runat="server" Text="Label" Visible="False"></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 145px;">
                                            <asp:Label ID="Label2" runat="server" CssClass="TitulitosSub" Text="Nombre corto:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtNombre" runat="server" CssClass="textbox1" MaxLength="50" Width="200px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvNombres" runat="server" ControlToValidate="txtNombre"
                                                ErrorMessage="Ingresar nombre corto" ForeColor="Red" ValidationGroup="Paciente">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 145px;">
                                            <asp:Label ID="Label3" runat="server" CssClass="TitulitosSub" Text="Razon Social"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtRazonSocial" runat="server" CssClass="textbox1" MaxLength="50"
                                                Width="250px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvAP" runat="server" ErrorMessage="Ingrese la Razón Social"
                                                ControlToValidate="txtRazonSocial" ForeColor="Red" ValidationGroup="Paciente">*</asp:RequiredFieldValidator>
                                    </tr>
                                    <tr>
                                        <td style="width: 145px;">
                                            <asp:Label ID="lblEmpresa0" runat="server" CssClass="TitulitosSub" Text="RUC:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtRUC" runat="server" CssClass="textbox1" MaxLength="50" Width="100px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 145px;">
                                            <asp:Label ID="lblPY" runat="server" CssClass="TitulitosSub" Text="Departamento:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlDepartamento" runat="server" AutoPostBack="True" CssClass="textbox1"
                                                OnSelectedIndexChanged="ddlDepartamento_SelectedIndexChanged" Width="250px">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 145px;">
                                            <asp:Label ID="lblPY0" runat="server" CssClass="TitulitosSub" Text="Provincia:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlProvincia" runat="server" AutoPostBack="True" CssClass="textbox1"
                                                OnSelectedIndexChanged="ddlProvincia_SelectedIndexChanged" Width="250px">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 145px;">
                                            <asp:Label ID="lblPY1" runat="server" CssClass="TitulitosSub" Text="Distrito:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlDistrito" runat="server" CssClass="textbox1" Width="250px">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 145px;">
                                            <asp:Label ID="Label6" runat="server" CssClass="TitulitosSub" Text="Dirección:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDireccion" runat="server" CssClass="textbox1" Width="250px" Height="35px"
                                                TextMode="MultiLine"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 145px;">
                                            <asp:Label ID="Label7" runat="server" CssClass="TitulitosSub" 
                                                Text="Actividad económica:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtActividad" runat="server" CssClass="textbox1" 
                                                MaxLength="50" Width="250px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 145px;">
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 145px;">
                                            &nbsp;
                                        </td>
                                        <td>
                                            <asp:LinkButton ID="btnAceptar" runat="server" OnClick="btnAceptar_Click" Text="Aceptar"
                                                ValidationGroup="Paciente">Aceptar</asp:LinkButton>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            &nbsp; &nbsp; &nbsp; &nbsp;
                                        </td>
                                    </tr>
                                </table>
                                <asp:Label ID="lblMensaje" runat="server" EnableViewState="False" SkinID="label_vacio"></asp:Label>
                                <br />
                            </asp:Panel>
                        </ContentTemplate>
                        <Triggers>
                        </Triggers>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>

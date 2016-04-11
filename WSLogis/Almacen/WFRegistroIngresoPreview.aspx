<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WFRegistroIngresoPreview.aspx.cs" Inherits="WSLogis.Almacen.WFRegistroIngresoPreview" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <link href="../Content/Site.css" rel="stylesheet" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Registro Ingreso</title>
    <style>
        td {
            padding-top: 5px;
            padding-bottom: 5px;
        }
    </style>
    <script>
        function refreshGridParent() {
            window.opener.RefreshGrid();
            window.close();

        };

    </script>
    <script type="text/javascript">
        function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("¿Desea registrar  el ingreso?")) {
                confirm_value.value = "Si";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                <asp:ScriptManager EnableScriptGlobalization="true" EnableScriptLocalization="false" runat="server"></asp:ScriptManager>
                <asp:UpdatePanel runat="server">

                    <ContentTemplate>
                        <style>
                            td { <!-- -->
                                padding: 3px 3px 3px 3px;
                            }

                            .aligntextRight { <!-- -->
                                text-align: right;
                            }
                        </style>
                        <asp:Panel runat="server" Width="100%">
                            <div style="width: 800px; margin-left: auto; margin-right: auto">


                                <table>
                                    <tr>
                                        <td colspan="4" style="text-align: center">
                                            <div style="margin-bottom: 15px; margin-top: 15px">
                                                <asp:Label CssClass="Titulitos" runat="server" Text="Registro de Ingreso"></asp:Label>
                                            </div>

                                        </td>

                                    </tr>
                                    <tr>
                                        <td style="text-align: right;">
                                            <asp:Label runat="server" Text="Nro. Orden: "></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="00001" Font-Bold="true" ID="lblNroOrden"></asp:Label>
                                        </td>

                                        <td style="text-align: right;">
                                            <asp:Label runat="server" Text="Proveedor: "></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Font-Bold="true" Text="00001" ID="lblProveedor"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: right;">
                                            <asp:Label runat="server" Text="Codigo Producto: "></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Font-Bold="true" Text="00001" ID="lblCodProducto"></asp:Label>
                                        </td>
                                        <td style="text-align: right;">
                                            <asp:Label runat="server" Text="Producto : "></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Font-Bold="true" Text="00001" ID="lblProductoNom"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: right;">
                                            <asp:Label runat="server" Text="Local: "></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList CssClass="textbox1" runat="server" ID="ddLocal" Width="200px"></asp:DropDownList>
                                        </td>
                                        <td style="text-align: right;">
                                            <asp:Label runat="server" Text="Proyecto: "></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList CssClass="textbox1" runat="server" ID="ddProyecto" Width="200px"></asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>

                                        <td style="text-align: right;">
                                            <asp:Label runat="server" Text="Usuario Responsable: "></asp:Label>
                                        </td>
                                        <td colspan="3">
                                            <asp:DropDownList CssClass="textbox1" runat="server" ID="ddUsuarioResponsable" Width="200px"></asp:DropDownList>
                                        </td>

                                    </tr>
                                    <tr>
                                        <td style="text-align: right;">
                                            <asp:Label runat="server" Text="Fecha Ingreso: "></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox CssClass="textbox1" runat="server" ID="txtFechaIngreso" Width="150px"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" TargetControlID="txtFechaIngreso" runat="server" />
                                        </td>
                                        <td style="text-align: right;">
                                            <asp:Label runat="server" Text="Fecha Expiracion: "></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox CssClass="textbox1" runat="server" ID="txtFechaExpiracion" Width="150px"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" TargetControlID="txtFechaExpiracion" Format="dd/MM/yyyy" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>

                                        <td style="text-align: right;">
                                            <asp:Label runat="server" Text="Nro. Lote: "></asp:Label>
                                            <asp:HiddenField runat="server" ID="hideValue" />
                                        </td>

                                        <td>
                                            <asp:TextBox CssClass="textbox1" ID="txtNroLoteo" runat="server" Width="150px"></asp:TextBox>
                                        </td>
                                        <td style="text-align: right;">
                                            <asp:Label runat="server" Text="Temperatura Almac. : "></asp:Label>
                                        </td>

                                        <td>
                                            <asp:TextBox CssClass="textbox1" ID="txtTemperaturaAlmc" runat="server" TextMode="Number" Width="150px"></asp:TextBox>
                                            <ajaxToolkit:FilteredTextBoxExtender TargetControlID="txtTemperaturaAlmc" runat="server" ID="FilteredTextBoxExtender1" FilterMode="ValidChars" ValidChars="1234567890" />
                                        </td>
                                    </tr>
                                    <tr>

                                        <td style="text-align: right;">
                                            <asp:Label runat="server" Text="Fabricante: "></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList CssClass="textbox1" runat="server" ID="ddlFabricante" Width="200px"></asp:DropDownList>
                                        </td>
                                        <td style="text-align: right;">
                                            <asp:Label runat="server" Text="Modelo: "></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox CssClass="textbox1" ID="txtModelo" runat="server" Width="150px"></asp:TextBox>
                                        </td>

                                    </tr>

                                    <tr>

                                        <td style="text-align: right;">
                                            <asp:Label runat="server" Text="Tipo Existencia: "></asp:Label>
                                        </td>
                                        <td colspan="3">
                                            <asp:DropDownList CssClass="textbox1" runat="server" ID="ddTipExistencia" Width="200px"></asp:DropDownList>
                                        </td>

                                    </tr>
                                    <tr>

                                        <td>
                                            <asp:Label runat="server" Text="Tipo Comprobante: "></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList AutoPostBack="true" CssClass="textbox1" runat="server" ID="ddTipComprobante" Width="200px" OnSelectedIndexChanged="ddTipComprobante_SelectedIndexChanged"></asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="Otro Comprobante: " Visible="false" ID="lblOtroComprobante"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox CssClass="textbox1" ID="txtOtroComprobante" Visible="false" runat="server" Width="150px"></asp:TextBox>
                                        </td>

                                    </tr>
                                    <tr>
                                        <td style="text-align: right;">
                                            <asp:Label runat="server" Text="Serie : "></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox CssClass="textbox1" runat="server" Width="150px" ID="txtSerie"></asp:TextBox>
                                        </td>
                                        <td style="text-align: right;">
                                            <asp:Label runat="server" Text="Numero : "></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox CssClass="textbox1" runat="server" Width="150px" ID="txtNumero"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: right;">
                                            <asp:Label runat="server" Text="Tipo Oper. : "></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList AutoPostBack="true" runat="server" Width="200px" CssClass="textbox1" ID="ddTipOperacion" OnSelectedIndexChanged="ddTipOperacion_SelectedIndexChanged"></asp:DropDownList><div style="width: 230px; height: 1px"></div>
                                        </td>
                                        <td style="text-align: right;">
                                            <asp:Label ID="lblOtraOper" runat="server" Visible="false" Text="Otro : "></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox CssClass="textbox1" runat="server" Visible="false" Width="150px" ID="txtOtraOperacion"></asp:TextBox>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td style="text-align: right;">
                                            <asp:Label runat="server" Text="Cantidad(Unid.): "></asp:Label>
                                        </td>

                                        <td colspan="3">
                                            <asp:TextBox CssClass="textbox1" ID="txtCantIngreso" runat="server" Width="150px" TextMode="Number"></asp:TextBox>
                                            <ajaxToolkit:FilteredTextBoxExtender TargetControlID="txtCantIngreso" runat="server" ID="filterNumber" FilterMode="ValidChars" ValidChars="1234567890" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4" style="text-align: center; background-color: #FAFAFA">
                                            <div style="margin-top: 15px;">
                                                <asp:LinkButton runat="server" OnClientClick="Confirm()" Text="Grabar" ID="lkbtnGrabar" OnClick="lkbtnGrabar_Click"></asp:LinkButton>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </div>


                        </asp:Panel>
                    </ContentTemplate>

                </asp:UpdatePanel>

            </div>
        </div>
    </form>
</body>
</html>

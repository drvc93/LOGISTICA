<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WFRecepcionPreview.aspx.cs" Inherits="WSLogis.Almacen.WFRecepcionPreview" Title="Orden de Compra" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../Content/Site.css" rel="stylesheet" />
    <link href="../Styles/jquery.jnotify.css" rel="stylesheet" />
    <script src="../Scripts/jquery-1.4.2.min.js"></script>
    <script src="../Scripts/jquery.jnotify.js"></script>

    <script>
        function refreshGridParent() {
            window.opener.RefreshGrid();
            window.close();

        };

    </script>



    <script type="text/javascript">
        function Confirm(estado) {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("¿Desea " + estado + " orden de compra?")) {
                confirm_value.value = "Si";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }
    </script>
    <script>
        window.onunload = refreshParent;
        function ClosePopup() {

            window.close();
        }
    </script>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager runat="server"></asp:ScriptManager>
            <asp:UpdatePanel runat="server">
                <Triggers>
                    <asp:PostBackTrigger ControlID="lkbtnRecepcionar" />
                </Triggers>
                <ContentTemplate>

                    <asp:Panel runat="server">


                        <table style="width: 700px;">
                            <tr>
                                <td colspan="2" style="background-color: #F6BE00; text-align: center; font-weight: bold;">
                                    <asp:Label runat="server" Text="Orden de compra"></asp:Label>

                                </td>

                            </tr>
                            <tr>
                                <td colspan="2" style="text-align: center; font-weight: bold; background-color: #F2F2F2;">
                                    <asp:Label runat="server" Text="Datos Recepcion"> </asp:Label>
                                </td>
                            </tr>

                            <tr>

                                <td class="tdIzq">
                                    <asp:Label runat="server" Text="Guia Remisión : "> </asp:Label>
                                </td>
                                <td class="FontBold">
                                    <asp:TextBox runat="server" ID="txtGuiaRemision" CssClass="textbox1" Width="150px"> </asp:TextBox>
                                </td>

                            </tr>

                            <tr>

                                <td class="tdIzq">
                                    <asp:Label runat="server" Text="Fecha de Remisión : "> </asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtfechaRemision" CssClass="textbox1" Width="100px"> </asp:TextBox>
                                    <ajaxToolkit:CalendarExtender runat="server" TargetControlID="txtfechaRemision" Format="dd/MM/yyyy" />
                                </td>

                            </tr>
                            <tr>

                                <td class="tdIzq">
                                    <asp:Label runat="server" Text="Número Factura : "> </asp:Label>
                                </td>
                                <td class="FontBold">
                                    <asp:TextBox runat="server" ID="txtNrpFactura" CssClass="textbox1" Width="100px"> </asp:TextBox>
                                </td>

                            </tr>

                            <tr>

                                <td class="tdIzq">
                                    <asp:Label runat="server" Text="Observaciones : "> </asp:Label>
                                </td>
                                <td class="FontBold">
                                    <asp:TextBox runat="server" ID="txtObservaciones" CssClass="textbox1" Width="150px"> </asp:TextBox>
                                </td>

                            </tr>

                            <tr>
                                <td colspan="2" style="text-align: center; font-weight: bold; background-color: #F2F2F2;">
                                    <asp:Label runat="server" Text="Datos Orden Compra"> </asp:Label>
                                </td>
                            </tr>


                            <tr>

                                <td class="tdIzq">
                                    <asp:Label runat="server" Text="Nro. O.C. : "> </asp:Label>
                                </td>
                                <td class="FontBold">
                                    <asp:Label runat="server" ID="lblNroOrden" Text="--"></asp:Label>
                                </td>

                            </tr>
                            <tr>

                                <td class="tdIzq">
                                    <asp:Label runat="server" Text="Tipo de Compra: "> </asp:Label>
                                </td>
                                <td class="FontBold">
                                    <asp:Label runat="server" ID="lblTipoCompra" Text="--"></asp:Label>
                                </td>

                            </tr>
                            <tr>

                                <td class="tdIzq">
                                    <asp:Label runat="server" Text="Proyecto : "> </asp:Label>
                                </td>
                                <td class="FontBold">
                                    <asp:Label runat="server" ID="lblPoryecto" Text="--"></asp:Label>
                                </td>

                            </tr>

                            <tr>

                                <td class="tdIzq">
                                    <asp:Label runat="server" Text="Local Entrega: "> </asp:Label>
                                </td>
                                <td class="FontBold">
                                    <asp:Label runat="server" ID="lblLocalEntrega" Text="--"></asp:Label>
                                </td>

                            </tr>

                            <tr>

                                <td class="tdIzq">
                                    <asp:Label runat="server" Text="Proveedor : "> </asp:Label>
                                </td>
                                <td class="FontBold">
                                    <asp:Label runat="server" ID="lblProveedor" Text="--"></asp:Label>
                                </td>

                            </tr>
                            <tr>

                                <td class="tdIzq">
                                    <asp:Label runat="server" Text="Fecha Orden Compra"> </asp:Label>
                                </td>
                                <td class="FontBold">
                                    <asp:Label runat="server" ID="lblFechaOC" Text="--"></asp:Label>
                                </td>

                            </tr>

                            <tr>

                                <td class="tdIzq">
                                    <asp:Label runat="server" Text="Moneda : "> </asp:Label>
                                </td>
                                <td class="FontBold">
                                    <asp:Label runat="server" ID="lblMoneda" Text="--"></asp:Label>
                                </td>

                            </tr>

                            <tr>

                                <td class="tdIzq">
                                    <asp:Label runat="server" Text="Importe : "> </asp:Label>
                                </td>
                                <td class="FontBold">
                                    <asp:Label runat="server" ID="lblImporte" Text="--"></asp:Label>
                                </td>

                            </tr>
                            <tr>

                                <td class="tdIzq">
                                    <asp:Label runat="server" Text="Conformidad por Sistemas : "> </asp:Label>
                                </td>
                                <td class="FontBold">
                                    <asp:CheckBox runat="server" Text=" " ID="chkSistemas" />
                                </td>

                            </tr>


                            <tr>
                                <td colspan="2">

                                    <div style="margin-top: 15px">
                                        <asp:GridView ID="GridOCDetalle" runat="server" EmptyDataText="No se encontro resultados" CssClass=" Grilla2" AutoGenerateColumns="false" ViewStateMode="Enabled" DataKeyNames="CodigoOCDetalle" Width="100%">
                                            <Columns>

                                                <asp:BoundField DataField="CodigoOCDetalle" HeaderText="CodigoOCDetalle" ItemStyle-Width="65px" Visible="false">
                                                    <HeaderStyle CssClass="Header2" />
                                                    <ItemStyle CssClass="Item2" />
                                                </asp:BoundField>




                                                <asp:BoundField DataField="IdArticulo" HeaderText="IdArticulo" ItemStyle-Width="80px">
                                                    <HeaderStyle CssClass="Header2" />
                                                    <ItemStyle CssClass="Item2" HorizontalAlign="Center" />
                                                </asp:BoundField>




                                                <asp:BoundField DataField="UDM" HeaderText="Unidad Medida" ItemStyle-Width="80px">
                                                    <HeaderStyle CssClass="Header2" />
                                                    <ItemStyle CssClass="Item2" HorizontalAlign="Center" />
                                                </asp:BoundField>

                                                <asp:BoundField DataField="Articulo" HeaderText="Articulo" ItemStyle-Width="230px">
                                                    <HeaderStyle CssClass="Header2" />
                                                    <ItemStyle CssClass="Item2" HorizontalAlign="Center" />
                                                </asp:BoundField>

                                                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" ItemStyle-Width="50px">
                                                    <HeaderStyle CssClass="Header2" />
                                                    <ItemStyle CssClass="Item2" HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Precio" HeaderText="Precio" ItemStyle-Width="90px">
                                                    <HeaderStyle CssClass="Header2" />
                                                    <ItemStyle CssClass="Item2" HorizontalAlign="Center" />
                                                </asp:BoundField>

                                                <asp:BoundField DataField="Importe" HeaderText="Importe" ItemStyle-Width="100px">
                                                    <HeaderStyle CssClass="Header2" />
                                                    <ItemStyle CssClass="Item2" HorizontalAlign="Center" />
                                                </asp:BoundField>

                                                <asp:TemplateField HeaderText="Cantidad Recibida" ItemStyle-CssClass="alingRowButons" ItemStyle-Width="80px">
                                                    <ItemTemplate>
                                                        <asp:TextBox runat="server" ID="txtrowCantidadRecibida" Width="50px" CssClass="textbox1" TextMode="Number"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <HeaderStyle CssClass="Header2" />
                                                    <ItemStyle CssClass="Item2" HorizontalAlign="Center"></ItemStyle>
                                                </asp:TemplateField>

                                            </Columns>
                                        </asp:GridView>


                                    </div>

                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <div style="text-align: center; margin-top: 15px;">
                                        <div style="float: left; margin-left: 35%;">
                                            <asp:LinkButton runat="server" Text="Recepcionar" ID="lkbtnRecepcionar" OnClick="lkbtnRecepcionar_Click" OnClientClick="Confirm(' recepcionar la ')"></asp:LinkButton>
                                        </div>
                                        <div style="float: left; margin-left: 5%;">
                                            <asp:LinkButton runat="server" Text="Rechazar" ID="lkbtnRechazar" OnClientClick="Confirm(' rechazar la recepcion de la ')"></asp:LinkButton>
                                        </div>

                                    </div>



                                </td>

                            </tr>

                        </table>
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>

        </div>
    </form>
</body>
</html>

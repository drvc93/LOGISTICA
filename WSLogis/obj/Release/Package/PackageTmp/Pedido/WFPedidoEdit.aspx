<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WFPedidoEdit.aspx.cs" Inherits="WSLogis.Pedido.WFPedidoEdit" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="../Scripts/SoloNumeros.js"></script>

    <style>
        .RedColor {
            color: red;
        }
    </style>
    <script>

        function popitup(url) {
            newwindow = window.open(url, 'name', 'height=500,width=810,navigationtoolbar=no,toolbar=no,menubar=no,left=150,top=180');/**/
        }
    </script>
    <script>

        function showCodigos(url) {
            newwindow = window.open(url, 'name', 'height=300,width=450,navigationtoolbar=no,toolbar=no,menubar=no,left=150,top=180');/**/
        }
    </script>

    <!--  Script -->
    <link href="../Styles/jquery.jnotify.css" rel="stylesheet" />
    <script src="../Scripts/jquery-1.4.2.min.js"></script>
    <script src="../Scripts/jquery.jnotify.js"></script>
    <link href="../Content/Site.css" rel="stylesheet" />
    <script type="text/javascript">
        function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("¿Desea registrar el pedido?")) {
                confirm_value.value = "Si";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }
    </script>

    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <script src="../Scripts/SoloNumeros.js"></script>
    <script>
        function RefreshGrid() {/**/

            document.getElementById("<%=btnFunction.ClientID %>").click();



        }



        function RefreshGridCodigos() {/**/

            document.getElementById("<%=btnFuncCodigos.ClientID %>").click();



        }

        function refreshGridParent() {
            window.opener.RefreshGrid();
            window.close();

        };

    </script>
    <form id="form1" runat="server">
        <div style="width: 800px; background-color: white">
            <asp:ScriptManager runat="server" EnablePartialRendering="true"></asp:ScriptManager>
            <div style="margin-left: auto; margin-right: auto">
                <asp:UpdatePanel ID="upPanelCAB" runat="server">
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnAddItem" />
                        <asp:AsyncPostBackTrigger ControlID="btnFunction" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="btnFuncCodigos" EventName="Click" />
                    </Triggers>

                    <ContentTemplate>
                        <asp:Panel ID="panelCab" runat="server">

                            <table style="border: solid 1px thin; width: 650px;">
                                <tr style="border: solid 1px black; height: 10px;">
                                    <td colspan="2" style="border-bottom: solid 1px thin; height: 15px;">
                                        <div style="background-color: #F6BE00;">
                                            <h3 style="margin-left: 25%; font-weight: 600;">Registro Prelimiar de Pedido </h3>
                                        </div>
                                    </td>


                                </tr>

                                <tr>
                                    <td class=" tdIzq">

                                        <asp:Label runat="server" Text="Tipo:" CssClass="label"></asp:Label>
                                    </td>

                                    <td class="tdDerecha">
                                        <asp:RadioButton runat="server" ID="rbtnCompra" AutoPostBack="true" GroupName="tipo" Checked="true" Text="Bienes" /><asp:RadioButton AutoPostBack="true" runat="server" ID="rbtnServicio" Text="Servicio" GroupName="tipo" />
                                    </td>
                                </tr>

                                <tr>
                                    <td class="tdIzq">

                                        <asp:Label runat="server" Text="Local de entrega:" CssClass="label"></asp:Label>

                                    </td>
                                    <td class="tdDerecha">
                                        <asp:DropDownList ViewStateMode="Enabled" runat="server" ID="ddLocal" CssClass=" comboClass"></asp:DropDownList>

                                    </td>

                                </tr>


                                <tr>
                                    <td class="tdIzq">

                                        <asp:Label runat="server" Text="Proyecto:" CssClass="label"></asp:Label>

                                    </td>
                                    <td class="tdDerecha">
                                        <asp:DropDownList Width="200" runat="server" ID="ddProyecto" CssClass=" comboClass" OnSelectedIndexChanged="ddProyecto_SelectedIndexChanged" ViewStateMode="Enabled" EnableViewState="true" AutoPostBack="true"></asp:DropDownList>
                                    </td>

                                </tr>

                                <tr>

                                    <td class="tdIzq">

                                        <asp:Label runat="server" Text="Moneda:" CssClass="label"></asp:Label>

                                    </td>
                                    <td class="tdDerecha">
                                        <asp:DropDownList runat="server" ID="ddMoneda" CssClass=" comboClass"></asp:DropDownList>
                                    </td>

                                </tr>



                                <tr>

                                    <td class="tdIzq">

                                        <asp:Label runat="server" Text="Codigos Presup. :" CssClass="label"></asp:Label>

                                    </td>
                                    <td class="tdDerecha">
                                        <telerik:RadComboBox ID="radComboCodigos" LabelCssClass="RadComboBoxDropDown" runat="server" CssClass="comboClass" AutoPostBack="true" EmptyMessage="No se selecciono proyecto" Width="250">
                                        </telerik:RadComboBox>
                                        <asp:LinkButton ID="lkbtnSeleccionarCodigo" OnClick="lkbtnSeleccionarCodigo_Click" runat="server" Text="Agregar"></asp:LinkButton>
                                    </td>

                                </tr>
                                <tr>
                                    <td></td>
                                    <td>
                                        <telerik:RadGrid CssClass="Grilla2" ItemStyle-CssClass="Item2" HeaderStyle-CssClass="Header2" Width="220px"  EnableAjaxSkinRendering="false" EnableEmbeddedSkins="false"  Visible="false" ID="radGirdCodigosSeleccionados" runat="server" OnItemCommand="radGirdCodigosSeleccionados_ItemCommand">

                                            <MasterTableView Width="200px" ItemStyle-CssClass="Item2" ItemStyle-BorderColor="#F6BE00" ItemStyle-BorderWidth="1px" AutoGenerateColumns="false">

                                                <Columns>
                                                    <telerik:GridBoundColumn ItemStyle-Wrap="true"  Display="false"  ItemStyle-Width="50px" HeaderText="Proyecto" DataField="Proyecto">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn ItemStyle-Wrap="true" ItemStyle-Width="50px" HeaderText="Presupuesto" DataField="Presupuesto">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridTemplateColumn HeaderText="Porcentaje" ItemStyle-Width="40px">
                                                        <ItemTemplate>
                                                            <asp:TextBox AutoPostBack="true"   OnTextChanged="txtPorcentItem_TextChanged" Text='<%#Eval("Procentaje") %>' runat="server" Width="40px" ID="txtPorcentItem" CssClass="textbox1"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn HeaderText="" ItemStyle-Width="40px">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lkbtnQuitarCod" CommandName="DeleteCodigo" runat="server" Text="Quitar"></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                </Columns>
                                            </MasterTableView>
                                        </telerik:RadGrid>

                                    </td>

                                </tr>
                                <tr>
                                    <td class="tdIzq">

                                        <asp:Label runat="server" Text="Descripción:" CssClass="label"></asp:Label>

                                    </td>
                                    <td class="tdDerecha">
                                        <asp:TextBox runat="server" ID="txtDescripcion" TextMode="MultiLine" CssClass=" textbox1" Width="200px" Height="40px"></asp:TextBox>
                                    </td>

                                </tr>
                                <tr>
                                    <td class="tdIzq">

                                        <asp:Label runat="server" Text="Donación:" CssClass="label"></asp:Label>

                                    </td>
                                    <td class="tdDerecha">
                                        <asp:CheckBox  ID="chkDonacion" runat="server" Text=""/>
                                    </td>

                                </tr>



                                <tr>

                                    <td class="tdIzq">


                                        <asp:LinkButton runat="server" ID="btnAddItem" Text="Agregar" OnClick="btnAddItem_Click" OnClientClick="popitup('../Administracion/WFAgregarDetallePedido.aspx')"> </asp:LinkButton>

                                    </td>
                                    <td class="tdDerecha">
                                        <asp:LinkButton runat="server" ID="btnSiguiente" Text="Siguiente" OnClick="btnSiguiente_Click" OnClientClick="Confirm()" CssClass=" margenizquiero"> </asp:LinkButton>
                                    </td>

                                </tr>

                                <tr>
                                    <td colspan="2">
                                        <div style="margin-left:15px;">
                                            <asp:GridView Width="770px" ID="GridItems" runat="server" CssClass=" GridMargin" AutoGenerateColumns="False" EmptyDataText="El pedido no contiene items." ViewStateMode="Enabled" DataKeyNames="IdProducto">
                                                <Columns>
                                                    <asp:BoundField DataField="IdProducto" HeaderText="IdProducto" Visible="false">
                                                        <HeaderStyle BackColor="#FFFFCC" />
                                                        <ItemStyle Font-Bold="True" Font-Size="Larger" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Producto" ItemStyle-Width="250px" ItemStyle-HorizontalAlign="Left" HeaderText="Producto">
                                                        <HeaderStyle CssClass="Header2" />
                                                        <ItemStyle CssClass="Item2" Width="100px" Wrap="False" />
                                                    </asp:BoundField>
                                                    <asp:TemplateField HeaderText="Precio"  ItemStyle-HorizontalAlign="Center"  ItemStyle-Width="60px"  >
                                                        <ItemTemplate>
                                                            <asp:TextBox Width="50px" runat="server" ID="txtPrecioRow" CssClass=" textbox1" onkeypress="return validateQty(this, event);" AutoPostBack="true"></asp:TextBox>
                                                        </ItemTemplate>
                                                        <HeaderStyle CssClass="Header2" />
                                                        <ItemStyle CssClass="Item2"></ItemStyle>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Cantidad" >
                                                        <ItemTemplate>
                                                            <asp:TextBox Width="50px" runat="server" ID="txtRowCantidad" CssClass="textbox1" onkeypress="return validateQty(this, event);" TextMode="Number" OnTextChanged="txtRowCantidad_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                        </ItemTemplate>
                                                        <HeaderStyle CssClass="Header2" />
                                                        <ItemStyle CssClass=" Item2"  Width="60px"  HorizontalAlign="Center"></ItemStyle>
                                                    </asp:TemplateField>
                                                    <asp:BoundField ItemStyle-Width="80px" DataField="SubTotal" HeaderText="SubTotal">
                                                        <HeaderStyle CssClass="Header2" />
                                                        <ItemStyle CssClass="Item2" />
                                                    </asp:BoundField>


                                                    <asp:TemplateField HeaderText="Imgen  1" ItemStyle-CssClass="alingRowButons">
                                                        <ItemTemplate>

                                                            <asp:FileUpload runat="server" ToolTip="Imagen 1" ID="ruta1" CssClass="textbox1" />

                                                        </ItemTemplate>
                                                        <ControlStyle Width="130px" />
                                                        <HeaderStyle CssClass="Header2" Width="80px" />
                                                        <ItemStyle CssClass=" Item2" Width="80px" Wrap="False"></ItemStyle>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Imgen 2" ItemStyle-CssClass=" Item2">
                                                        <ItemTemplate>

                                                            <asp:FileUpload runat="server" ToolTip="Imagen 2" ID="ruta2" CssClass=" textbox1" />

                                                        </ItemTemplate>
                                                        <ControlStyle Width="130px" />
                                                        <HeaderStyle CssClass="Header2" />
                                                        <ItemStyle CssClass="Item2" Width="80px" Wrap="true"></ItemStyle>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText=" " ItemStyle-CssClass=" Item2">
                                                        <ItemTemplate>

                                                            <asp:LinkButton runat="server" ID="lkbtnEliminarItem" Text="(-)" OnClick="lkbtnEliminarItem_Click"></asp:LinkButton>

                                                        </ItemTemplate>
                                                        <ControlStyle Width="15px" />
                                                        <HeaderStyle CssClass="Header2" />
                                                        <ItemStyle CssClass="Item2" Width="15px" Wrap="true" HorizontalAlign="Center"></ItemStyle>
                                                    </asp:TemplateField>






                                                </Columns>
                                            </asp:GridView>
                                        </div>



                                    </td>
                                </tr>

                            </table>

                            <div style="display: none;">
                                <asp:Button runat="server" ID="btnFunction" Text="prueba" OnClick="btnFunction_Click" OnClientClick="RefreshGrid()" />
                                <asp:Button runat="server" ID="btnFuncCodigos" OnClick="btnFuncCodigos_Click" />
                            </div>
                        </asp:Panel>

                    </ContentTemplate>

                </asp:UpdatePanel>

            </div>


        </div>
    </form>
</body>
</html>

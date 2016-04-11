<%@ Page Title="Registrar Pedido" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistrarPedido.aspx.cs" Inherits="WSLogis.Administracion.RegistrarPedido" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="../Styles/jquery.jnotify.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery-1.4.2.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery.jnotify.js" type="text/javascript"></script>
    <link href="../Styles/radStyles.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    
    <script src="../Scripts/SoloNumeros.js"></script>
    <script>
        function RefreshGrid() {/**/

            document.getElementById("<%=btnFunction.ClientID %>").click();



        }

        function RefreshGridCodigos() {/**/

            document.getElementById("<%=btnFuncCodigos.ClientID %>").click();



        }
    </script>

    <script>

        function popitup(url) {
            newwindow = window.open(url, 'name', 'height=500,width=600,navigationtoolbar=no,toolbar=no,menubar=no,left=150,top=180');/**/
        }
    </script>
     <script>

         function showCodigos(url) {
             newwindow = window.open(url, 'name', 'height=250,width=250,navigationtoolbar=no,toolbar=no,menubar=no,left=150,top=180');/**/
         }
    </script>

    <!--  Script -->
    <link href="../Styles/jquery.jnotify.css" rel="stylesheet" />
    <script src="../Scripts/jquery-1.4.2.min.js"></script>
    <script src="../Scripts/jquery.jnotify.js"></script>
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

    <!--  Script -->






    <div class="Conteiner" style="margin-left: 15%;">
        <asp:ScriptManager runat="server"  EnablePartialRendering="true"></asp:ScriptManager>

        <asp:UpdatePanel ID="upPanelCAB" runat="server">
            <Triggers>
                <asp:PostBackTrigger ControlID="btnAddItem" />
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
                                <telerik:RadComboBox ID="radComboCodigos" LabelCssClass="RadComboBoxDropDown" runat="server" CssClass="comboClass"  AutoPostBack="true" EmptyMessage="No se selecciono proyecto" Width="250">
                                    

                                </telerik:RadComboBox>
                                <asp:LinkButton  ID="lkbtnSeleccionarCodigo" OnClick="lkbtnSeleccionarCodigo_Click" runat="server" Text="Agregar"></asp:LinkButton>
                            </td>

                        </tr>
                        <tr>
                            <td></td>
                            <td>
                                <telerik:RadGrid  Width="270px" Visible="false" ID="radGirdCodigosSeleccionados" runat="server" OnItemCommand="radGirdCodigosSeleccionados_ItemCommand">
                                    
                                    <MasterTableView    AutoGenerateColumns="false">
                                        
                                        <Columns>
                                            <telerik:GridBoundColumn ItemStyle-Wrap="true" ItemStyle-Width="50px" HeaderText="Proyecto" DataField="Proyecto">

                                            </telerik:GridBoundColumn>
                                              <telerik:GridBoundColumn ItemStyle-Wrap="true" ItemStyle-Width="50px" HeaderText="Presupuesto" DataField="Presupuesto">

                                            </telerik:GridBoundColumn>
                                            <telerik:GridTemplateColumn HeaderText="Porcentaje" ItemStyle-Width="50px">
                                                <ItemTemplate>
                                                    <asp:TextBox AutoPostBack="true" OnTextChanged="txtPorcentItem_TextChanged" Text='<%#Eval("Procentaje") %>'  runat="server" Width="30px" ID="txtPorcentItem"  CssClass="textbox1"></asp:TextBox>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn HeaderText="Quitar" ItemStyle-Width="50px">
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

                                <asp:Label runat="server" Text="Descripcion:" CssClass="label"></asp:Label>

                            </td>
                            <td class="tdDerecha">
                                <asp:TextBox runat="server" ID="txtDescripcion" TextMode="MultiLine" CssClass=" textbox1" Width="200px" Height="40px"></asp:TextBox>
                            </td>

                        </tr>



                        <tr>

                            <td class="tdIzq">


                                <asp:LinkButton runat="server" ID="btnAddItem" Text="Agregar" OnClick="btnAddItem_Click" OnClientClick="popitup('WFAgregarDetallePedido.aspx')"> </asp:LinkButton>

                            </td>
                            <td class="tdDerecha">
                                <asp:LinkButton runat="server" ID="btnSiguiente" Text="Siguiente" OnClick="btnSiguiente_Click" OnClientClick="Confirm()" CssClass=" margenizquiero"> </asp:LinkButton>
                            </td>

                        </tr>

                        <tr>
                            <td colspan="2">

                                <asp:GridView ID="GridItems" runat="server" CssClass=" GridMargin" AutoGenerateColumns="False" EmptyDataText="El pedido no contiene items." ViewStateMode="Enabled" DataKeyNames="IdProducto">
                                    <Columns>
                                        <asp:BoundField DataField="IdProducto" HeaderText="IdProducto" Visible="false">
                                            <HeaderStyle BackColor="#FFFFCC" />
                                            <ItemStyle Font-Bold="True" Font-Size="Larger" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Producto" HeaderText="Producto">
                                            <HeaderStyle CssClass="Header2" />
                                            <ItemStyle CssClass="Item2" Width="100px" Wrap="False" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Precio" ItemStyle-CssClass="alingRowButons">
                                            <ItemTemplate>
                                                <asp:TextBox Width="50px" runat="server" ID="txtPrecioRow" CssClass=" textbox1" onkeypress="return validateQty(this, event);" AutoPostBack="true"></asp:TextBox>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="Header2" />
                                            <ItemStyle CssClass="Item2"></ItemStyle>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Cantidad" ItemStyle-CssClass="alingRowButons">
                                            <ItemTemplate>
                                                <asp:TextBox Width="50px" runat="server" ID="txtRowCantidad" CssClass="textbox1" onkeypress="return validateQty(this, event);" TextMode="Number" OnTextChanged="txtRowCantidad_TextChanged" AutoPostBack="true"></asp:TextBox>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="Header2" />
                                            <ItemStyle CssClass=" Item2"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="SubTotal" HeaderText="SubTotal">
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



                            </td>
                        </tr>

                    </table>

                    <div style="display: none;">
                        <asp:Button runat="server" ID="btnFunction" Text="prueba" OnClick="btnFunction_Click" OnClientClick="RefreshGrid()" />
                        <asp:Button  runat="server" ID="btnFuncCodigos" OnClick="btnFuncCodigos_Click"/>
                    </div>
                </asp:Panel>

            </ContentTemplate>

        </asp:UpdatePanel>


    </div>




</asp:Content>

<%@ Page Title="Registrar Orden de Compra" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WFOrdenDeCompra.aspx.cs" Inherits="WSLogis.Orden.WFOrdenDeCompra" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

    <link href="../Content/Site.css" rel="stylesheet" />

    <link href="../Styles/jquery.jnotify.css" rel="stylesheet" />
    <script src="../Scripts/jquery-1.4.2.min.js"></script>
    <script src="../Scripts/jquery.jnotify.js"></script>

    <script type="text/javascript">
        function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("¿Desea registrar  la orden de compra?")) {
                confirm_value.value = "Si";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <asp:ScriptManager runat="server" ID="ScripManag1" EnableScriptGlobalization="true" EnableScriptLocalization="false" ></asp:ScriptManager>
    <div class="Conteiner" style="margin-left: 20%">
        <asp:UpdatePanel runat="server">
            <Triggers>
                <asp:PostBackTrigger ControlID="lkbtnGenerar" />
                <asp:AsyncPostBackTrigger EventName="CheckedChanged" ControlID="chkFechaEntrega" />
            </Triggers>
            <ContentTemplate>

                <asp:Panel runat="server">


                    <table style="border: solid 1px  thin; width: 650px;">
                        <tr style="border: solid 1px black;">
                            <td colspan="2" style="border-bottom: solid 1px thin; text-align: center;">
                                <div style="background-color: #FFCC00; height: 28px;">
                                    <h2>Registro de orden de compra </h2>
                                </div>
                            </td>


                        </tr>

                        <tr>
                            <td class=" tdIzq">
                                <asp:Label runat="server" Text="ID Pedido:" CssClass="label"></asp:Label>
                            </td>

                            <td class="tdDerecha">
                                <asp:Label runat="server" Text="-----" CssClass="comboClass" ID="lblIdPedido"></asp:Label>
                            </td>
                        </tr>

                        <tr>
                            <td class="tdIzq">

                                <asp:Label runat="server" Text="Proyecto:" CssClass="label"></asp:Label>

                            </td>
                            <td class="tdDerecha">
                                <asp:Label runat="server" Text="-----" CssClass="comboClass" ID="lblProyecto"></asp:Label>
                            </td>

                        </tr>


                        <tr>
                            <td class="tdIzq">

                                <asp:Label runat="server" Text="Descripcion:" CssClass="label"></asp:Label>

                            </td>
                            <td class="tdDerecha">
                                <asp:Label runat="server" Text="-----" CssClass="comboClass" ID="lblDescripcion"></asp:Label>
                            </td>

                        </tr>

                        <tr>

                            <td class="tdIzq">

                                <asp:Label runat="server" Text="Moneda:" CssClass="label"></asp:Label>

                            </td>
                            <td class="tdDerecha">
                                <asp:Label runat="server" Text="-----" CssClass="comboClass" ID="lblMoneda"></asp:Label>
                                <asp:Label ID="lblEtiquetaCambio" runat="server" Text="    Tipo de cambio: " CssClass="comboClass" Visible="false"></asp:Label>
                                <asp:TextBox ID="txtCambioMoneda" runat="server" Width="60" CssClass=" textbox1" Visible="false" AutoPostBack="true"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender TargetControlID="txtCambioMoneda" runat="server" ID="filterNumber" FilterMode="ValidChars" ValidChars="1234567890." />
                            </td>

                        </tr>


                        <tr>

                            <td class="tdIzq">

                                <asp:Label runat="server" Text="Incluye IGV:" CssClass="label"></asp:Label>

                            </td>
                            <td class="tdDerecha">
                                <asp:CheckBox runat="server" CssClass="comboClass" ID="chkIgv" Text="" />
                            </td>

                        </tr>


                        <tr>

                            <td class="tdIzq">

                                <asp:Label runat="server" Text="Fecha de Entrega:" CssClass="label"></asp:Label>

                            </td>
                            <td class="tdDerecha">

                                <asp:TextBox runat="server" CssClass=" textbox1" ID="txtFechaEntrega" Enabled="false"> </asp:TextBox>
                                <ajaxToolkit:CalendarExtender runat="server" TargetControlID="txtFechaEntrega" Format="dd/MM/yyyy" StartDate="<%# DateTime.Now %>" />
                                <asp:CheckBox runat="server" AutoPostBack="true" TextAlign="Right" Text="Aplicar a todo" ID="chkFechaEntrega" Checked="false" OnCheckedChanged="chkFechaEntrega_CheckedChanged" />

                            </td>

                        </tr>

                        <tr>

                            <td class="tdIzq">

                                <asp:Label runat="server" Text="Proveedor:" CssClass="label"></asp:Label>

                            </td>
                            <td class="tdDerecha">
                                <asp:TextBox runat="server" ID="textProveedor" CssClass=" textbox1" AutoPostBack="true" Width="230"> </asp:TextBox>
                                <ajaxToolkit:AutoCompleteExtender ServiceMethod="FillTextBox" ServicePath="~/AutocompletService.asmx" TargetControlID="textProveedor" runat="server" ID="autoTextbox" MinimumPrefixLength="1" CompletionInterval="10" CompletionSetCount="1" EnableCaching="false" FirstRowSelected="false"></ajaxToolkit:AutoCompleteExtender>

                            </td>

                        </tr>

                        <tr>

                            <td class="tdIzq">

                                <asp:Label runat="server" Text="Tipo de Pago:" CssClass="label"></asp:Label>

                            </td>
                            <td class="tdDerecha">
                                <asp:DropDownList runat="server" ID="ddlTipoDePago" CssClass="  textbox1"></asp:DropDownList>

                            </td>

                        </tr>

                        <tr>

                            <td class="tdIzq">

                                <asp:Label runat="server" Text="Observaciones:" CssClass="label"></asp:Label>

                            </td>
                            <td class="tdDerecha">
                                <asp:TextBox runat="server" ID="txtObservOrden" Width="200px" TextMode="MultiLine" CssClass="textbox1"></asp:TextBox>
                            </td>

                        </tr>

                        <tr>
                            <td runat="server" id="tdDatosServicios" colspan="2" style="width: 100%;">

                                <div>
                                    <table style="width: 100%;">
                                        <tr>
                                            <td class="tdIzq">

                                                <asp:Label runat="server" Text="Fecha Inicio:" CssClass="label"></asp:Label>

                                            </td>
                                            <td class="tdDerecha">

                                                <asp:TextBox runat="server" CssClass=" textbox1" ID="txtFechaInicio"> </asp:TextBox>
                                                <ajaxToolkit:CalendarExtender StartDate="<%# DateTime.Now %>" runat="server" TargetControlID="txtFechaInicio" Format="dd/MM/yyyy" />

                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="tdIzq">

                                                <asp:Label runat="server" Text="Fecha Fin:" CssClass="label"></asp:Label>

                                            </td>
                                            <td class="tdDerecha">

                                                <asp:TextBox runat="server" CssClass=" textbox1" ID="txtFechaFin"> </asp:TextBox>
                                                <ajaxToolkit:CalendarExtender runat="server" TargetControlID="txtFechaFin" Format="dd/MM/yyyy" />

                                            </td>
                                        </tr>

                                        <tr>
                                            <td class="tdIzq">

                                                <asp:Label runat="server" Text="Responsable :" CssClass="label"></asp:Label>

                                            </td>
                                            <td class="tdDerecha">

                                                <asp:TextBox runat="server" CssClass=" textbox1" ID="txtResponsable" Width="200px"> </asp:TextBox>


                                            </td>
                                        </tr>
                                    </table>

                                </div>

                            </td>
                        </tr>

                        <tr>
                            <td colspan="2" style="margin-top: 20px;">
                                <asp:GridView ID="GridItems" runat="server" CssClass=" Grilla2" AutoGenerateColumns="False" ViewStateMode="Enabled" DataKeyNames="IdDetalle" Width="100%">
                                    <Columns>
                                        <asp:BoundField DataField="IdDetalle" HeaderText="IdDetalle" Visible="false">
                                            <ControlStyle Width="40px" />
                                            <HeaderStyle />
                                            <ItemStyle Font-Bold="True" Font-Size="Larger" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="IdProducto" HeaderText="IdProducto" ItemStyle-CssClass=" hide" HeaderStyle-CssClass=" hide">
                                            <HeaderStyle BackColor="#FFFFCC" />
                                            <ItemStyle Font-Bold="True" Font-Size="Larger" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Producto" HeaderText="Producto" ItemStyle-CssClass="Item2" HeaderStyle-CssClass="Header2">
                                            <ControlStyle Width="150px" />

                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Garantia" ItemStyle-CssClass="Item2" HeaderStyle-CssClass="Header2">
                                            <ItemTemplate>
                                                <asp:DropDownList runat="server" Width="80" ID="ddlGarantia" CssClass="textbox1" AutoPostBack="true"></asp:DropDownList>
                                            </ItemTemplate>

                                            <ItemStyle CssClass=" Item2" HorizontalAlign="Center"></ItemStyle>
                                        </asp:TemplateField>


                                        <asp:TemplateField HeaderText="Precio" ItemStyle-CssClass="Item2" HeaderStyle-CssClass="Header2">
                                            <ItemTemplate>
                                                <asp:TextBox runat="server" ID="txtPrecioRow" CssClass=" textbox1" Width="55px" ReadOnly="true"></asp:TextBox>
                                            </ItemTemplate>

                                            <ItemStyle CssClass=" Item2" HorizontalAlign="Center"></ItemStyle>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Cantidad" ItemStyle-CssClass="Item2" HeaderStyle-CssClass="Header2" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:TextBox runat="server" ID="txtRowCantidad" CssClass=" textbox1" ReadOnly="true" Width="60px"></asp:TextBox>
                                            </ItemTemplate>


                                        </asp:TemplateField>
                                        <asp:BoundField DataField="SubTotal" HeaderText="SubTotal" ItemStyle-CssClass="Item2" HeaderStyle-CssClass="Header2" ItemStyle-HorizontalAlign="Center"></asp:BoundField>




                                        <asp:TemplateField HeaderText="" ItemStyle-CssClass=" Item2">
                                            <HeaderTemplate>
                                                <asp:CheckBox runat="server" ID="chekheader" AutoPostBack="true" OnCheckedChanged="chekheader_CheckedChanged" />

                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox runat="server" ID="chkItem" AutoPostBack="true" CssClass=" textbox1" OnCheckedChanged="chkItem_CheckedChanged" />
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="Header2" />
                                            <ItemStyle CssClass="Item2" HorizontalAlign="Center"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Fecha Entrega" ItemStyle-CssClass=" Item2" Visible="true">

                                            <ItemTemplate>
                                                <asp:TextBox runat="server" CssClass=" textbox1" ID="itemTextFecha" Width="80px"> </asp:TextBox>
                                                <ajaxToolkit:CalendarExtender StartDate="<%# DateTime.Now %>" runat="server" TargetControlID="itemTextFecha" Format="dd/MM/yyyy" />
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="Header2" />
                                            <ItemStyle CssClass="Item2" HorizontalAlign="Center"></ItemStyle>
                                        </asp:TemplateField>

                                    </Columns>
                                </asp:GridView>
                                <div style="display: none;">
                                    <asp:Button runat="server" ID="btnShoPopup" CssClass=" btnhide" />
                                </div>


                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <div style="float: right; width: 150px; margin-right: 35px; position: relative;">
                                    <asp:Panel ID="PanelSoles" runat="server" Width="150" CssClass="classCenter">
                                        <div style="text-align: right;">
                                            <asp:Label runat="server" Text="Nuevos Soles"></asp:Label>
                                        </div>

                                        <div style="text-align: right; font-weight: normal;">
                                            <asp:Label runat="server" Text="Valor Venta : "></asp:Label>
                                            <asp:Label ID="lblValorVentaSL" runat="server" Text="0.00" ForeColor="Black"></asp:Label><br />
                                            <asp:Label runat="server" Text="IGV: "></asp:Label>
                                            <asp:Label ID="lblIGVSL" runat="server" Text="0.00" ForeColor="Black"></asp:Label><br />
                                            <asp:Label runat="server" Text="Total: "></asp:Label>
                                            <asp:Label ID="lblMontoTotalSL" runat="server" Text="0.00" ForeColor="Black"></asp:Label>
                                        </div>
                                    </asp:Panel>


                                </div>

                                <div style="float: right; width: 150px; margin-right: 5px; position: relative;">
                                    <asp:Panel ID="PanelMonedaExt" runat="server" Width="150" CssClass="classCenter" Visible="false">

                                        <div style="text-align: right;">
                                            <asp:Label runat="server" Text="Moneda Ext" ID="lblNombreMoneda"></asp:Label>
                                        </div>


                                        <div style="text-align: right; font-weight: normal;">
                                            <asp:Label runat="server" Text="Valor Venta : "></asp:Label>
                                            <asp:Label ID="lblValorVentaEX" runat="server" Text="0,00" ForeColor="Black"></asp:Label><br />
                                            <asp:Label runat="server" Text="IGV: "></asp:Label>
                                            <asp:Label ID="lblIGVEX" runat="server" Text="0,00" ForeColor="Black"></asp:Label><br />
                                            <asp:Label runat="server" Text="Total: "></asp:Label>
                                            <asp:Label ID="lblMontoTotalExt" runat="server" Text="0,00" ForeColor="Black"></asp:Label>
                                        </div>
                                    </asp:Panel>


                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <div style="margin-left: 25%;">
                                    <asp:LinkButton ID="lkbtnGenerar" runat="server" CssClass="linkbuttonClass" Text="Generar Orden" OnClientClick="Confirm()" OnClick="lkbtnGenerar_Click"></asp:LinkButton>
                                </div>
                            </td>
                        </tr>

                    </table>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>

    </div>
</asp:Content>

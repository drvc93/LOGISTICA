<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WFOrdenCompraSearch.aspx.cs" Inherits="WSLogis.Administracion.WFOrdenCompraSearch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

    <link href="../Content/Site.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager runat="server" ID="scripManager2"></asp:ScriptManager>
    <h2 style="margin-left: 16%;">Buscar Orden de Compra </h2>
    <div style="margin-top: 10px;">

        <asp:Label CssClass="labelclass" runat="server" Text="Buscar"></asp:Label>
        <asp:TextBox runat="server" CssClass=" textbox1"></asp:TextBox>

    </div>
    <div>

        <asp:GridView runat="server" ID="GridOrdenes" AutoGenerateColumns="False" ViewStateMode="Enabled" DataKeyNames="CodigoOC" CssClass="Grilla2">
            <Columns>
                <asp:BoundField DataField="CodigoOC" HeaderText="Codigo Pedido" HeaderStyle-HorizontalAlign="Center" Visible="false" HeaderStyle-CssClass="Header2" ItemStyle-CssClass="Item2">

                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>

                <asp:BoundField DataField="Proveedor" HeaderText="Proveedor" HeaderStyle-CssClass="Header2" ItemStyle-CssClass="Item2">
                    <HeaderStyle />
                    <ItemStyle Font-Bold="False" />
                </asp:BoundField>

                <asp:BoundField DataField="FormaPago" HeaderText="Forma Pago" HeaderStyle-CssClass="Header2" ItemStyle-CssClass="Item2">

                    <ItemStyle Font-Bold="False" />
                </asp:BoundField>
                <asp:BoundField DataField="FechaOrden" HeaderText="Fecha Orden" HeaderStyle-CssClass="Header2" ItemStyle-CssClass="Item2">

                    <ItemStyle Font-Bold="False" />
                </asp:BoundField>
                <asp:BoundField DataField="Monto" HeaderText="Monto" HeaderStyle-CssClass="Header2" ItemStyle-CssClass="Item2">

                    <ItemStyle Font-Bold="False" Width="80px" />
                </asp:BoundField>
                <asp:BoundField DataField="Moneda" HeaderText="Moneda" HeaderStyle-CssClass="Header2" ItemStyle-CssClass="Item2">

                    <ItemStyle Font-Bold="False" />
                </asp:BoundField>

                <asp:TemplateField HeaderText="IGV" ItemStyle-CssClass="alingRowButons">
                    <ItemTemplate>
                        <asp:CheckBox runat="server" ID="chekIGVRow" />

                    </ItemTemplate>
                    <HeaderStyle CssClass="Header2" Width="30" />

                    <ItemStyle CssClass=" Item2" Width="30px" HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="" ShowHeader="false" ItemStyle-CssClass="alingRowButons">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="lkVerRow" Text="Detalle" OnClick="lkVerRow_Click"></asp:LinkButton>

                    </ItemTemplate>
                    <HeaderStyle CssClass="Header2" Width="40px" />

                    <ItemStyle CssClass=" Item2" Width="50px" HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:Button runat="server" ID="btnShoPopup" Style="display: none" />
    </div>


    <ajaxToolkit:ModalPopupExtender runat="server" ID="ModalPopUp2" BackgroundCssClass="popUpModal" TargetControlID="btnShoPopup" PopupControlID="modal2"
        CancelControlID="lkbtnCerrar" PopupDragHandleControlID="panel2">
    </ajaxToolkit:ModalPopupExtender>
    <div id="modal2" style="width: 500px;">
        <asp:Panel Height="100%" Width="100%" CssClass="modalBG" runat="server" ID="panel2" ViewStateMode="Enabled" EnableViewState="true">
            <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel2">

                <ContentTemplate>

                    <table style="width: 100%; height: 50%;">
                        <tr>
                            <td colspan="2" style="margin-bottom: 5px;">
                                <asp:Label runat="server" Text="Detalle de la Orden de Compra
                               "
                                    CssClass=" tittleclass"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <div style="margin-top: 5px;">
                                    <asp:GridView runat="server" ID="GridDetalleOrden" AutoGenerateColumns="False" ViewStateMode="Enabled">
                                        <Columns>
                                            <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" HeaderStyle-CssClass="Header2" ItemStyle-CssClass="Item2">
                                                <ControlStyle Width="300px" />
                                                <HeaderStyle />
                                                <ItemStyle Font-Bold="False" Width="300px" />
                                            </asp:BoundField>

                                            <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" HeaderStyle-CssClass="Header2" ItemStyle-CssClass="Item2">
                                                <HeaderStyle />
                                                <ItemStyle Font-Bold="False" HorizontalAlign="Center" Width="60px" />
                                            </asp:BoundField>

                                            <asp:BoundField DataField="Precio" HeaderText="Precio" ItemStyle-CssClass="Item2" HeaderStyle-CssClass="Header2">

                                                <ItemStyle HorizontalAlign="Center" Width="60px" />
                                            </asp:BoundField>

                                            <asp:BoundField DataField="SubTotal" HeaderText="SubTotal" ItemStyle-CssClass="Item2" HeaderStyle-CssClass="Header2">

                                                <ItemStyle HorizontalAlign="Center" Width="60px" />
                                            </asp:BoundField>


                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="margin-bottom: 5px; text-align: right;">
                                <div style="margin-right: 5px;">

                                    <asp:Label runat="server" Text="Precio Venta: " ForeColor="Black"></asp:Label>
                                    <asp:Label runat="server" ID="lblPrecioVent" Text="--" ForeColor="Blue"></asp:Label>
                                    <br />
                                    <asp:Label runat="server" Text="Igv: " ForeColor="Black"></asp:Label>
                                    <asp:Label runat="server" ID="lblIgvTotal" Text="--" ForeColor="Blue"></asp:Label>
                                    <br />
                                    <asp:Label runat="server" Text="Monto Total: " ForeColor="Black"></asp:Label>
                                    <asp:Label runat="server" ID="lblMontoTotal" Text="--" ForeColor="Blue"></asp:Label>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="align-content: center; text-align: center;">

                                <asp:LinkButton runat="server" ID="lkbtnCerrar" Text="Cerrar" CssClass="  linkbtnAgregar"></asp:LinkButton>

                            </td>



                        </tr>



                    </table>
                </ContentTemplate>

            </asp:UpdatePanel>

        </asp:Panel>

    </div>


</asp:Content>

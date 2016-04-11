<%@ Page Title="Aprobacion Orden de Compra" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WFAprobacionNivel1.aspx.cs" Inherits="WSLogis.Aprobaciones.WFAprobacionNivel1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="../Styles/jquery.jnotify.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery-1.4.2.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery.jnotify.js" type="text/javascript"></script>
    <script type="text/javascript">
        function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("¿Esta seguro de aprobar la orden de compra?")) {
                confirm_value.value = "Si";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div style="margin-left: 10%;">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"
            EnableScriptLocalization="false">
        </asp:ScriptManager>
        <table style="width: 800px">
            <tr>
                <td>
                    <asp:UpdatePanel ID="updActualizar" runat="server">
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="ddLocal" EventName="SelectedIndexChanged" />
                            <asp:AsyncPostBackTrigger ControlID="ddlProyecto" EventName="SelectedIndexChanged" />

                        </Triggers>
                        <ContentTemplate>
                            <asp:Panel ID="Panel1" runat="server" HorizontalAlign="Left">
                                <table style="width: 710px;">
                                    <tr>
                                        <td colspan="4" style="text-align: center;">
                                            <asp:Label ID="Label1" runat="server" CssClass="Titulitos" Text="Aprobacion Orden De Compra"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr style="margin-top: 10px;">

                                        <td style="text-align: right">

                                            <asp:Label runat="server" Text="Local: " CssClass="comboClass"></asp:Label>
                                        </td>
                                        <td style="margin-top: 10px;">
                                            <asp:DropDownList runat="server" AutoPostBack="true" CssClass=" textbox1" ID="ddLocal" Width="140" OnSelectedIndexChanged="ddLocal_SelectedIndexChanged"></asp:DropDownList>
                                        </td>
                                        <td style="text-align: right">
                                            <asp:Label runat="server" Text="Proyecto: " CssClass="comboClass"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList runat="server" CssClass=" textbox1" ID="ddlProyecto" Width="150" AutoPostBack="true" OnSelectedIndexChanged="ddlProyecto_SelectedIndexChanged"></asp:DropDownList>
                                        </td>

                                    </tr>
                                    <tr style="margin-top: 10px;">

                                        <td style="text-align: right">

                                            <asp:Label runat="server" Text="Fecha Desde : " CssClass=""></asp:Label>
                                        </td>
                                        <td style="margin-top: 10px;">
                                            <asp:TextBox ID="txtFechaIni" runat="server" CssClass=" textbox1" AutoPostBack="true"></asp:TextBox><ajaxToolkit:CalendarExtender runat="server" TargetControlID="txtFechaIni" Format="dd/MM/yyyy" />
                                        </td>
                                        <td style="text-align: right">

                                            <asp:Label runat="server" Text="Fecha hasta: " CssClass=""></asp:Label>
                                        </td>
                                        <td style="margin-top: 10px;">
                                            <asp:TextBox runat="server" ID="txtFechaHasta" CssClass=" textbox1" AutoPostBack="true"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender runat="server" TargetControlID="txtFechaHasta" Format="dd/MM/yyyy" />
                                        </td>

                                    </tr>

                                    <tr style="margin-top: 10px;">

                                        <td style="text-align: right">

                                            <asp:Label runat="server" Text=" ID Pedido : " CssClass="comboClass"></asp:Label>
                                        </td>
                                        <td style="margin-top: 10px;">
                                            <asp:TextBox runat="server" CssClass=" textbox1" ID="txtIdPedido" AutoPostBack="true"></asp:TextBox>
                                            <ajaxToolkit:TextBoxWatermarkExtender runat="server" ID="waterMark1" TargetControlID="txtIdPedido" WatermarkText="ID Orden" />
                                        </td>
                                        <td style="text-align: right">

                                            <asp:Label runat="server" Text="Estado: " CssClass="comboClass"></asp:Label>
                                        </td>
                                        <td style="margin-top: 10px;">
                                            <asp:DropDownList runat="server" ID="ddlEstado" CssClass=" textbox1" Width="150" AutoPostBack="true"></asp:DropDownList>
                                            <asp:LinkButton runat="server" ID="lkbtnBuscar" CssClass=" lkbtnSpace" Text="Buscar" OnClick="lkbtnBuscar_Click"></asp:LinkButton>

                                        </td>

                                    </tr>

                                    <tr>
                                        <td>&nbsp;
                                        </td>
                                        <td>&nbsp;
                                        </td>
                                        <td>&nbsp;
                                        </td>
                                        <td>&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <asp:HyperLink ID="hlkAddEmpresa" runat="server" CssClass="TitulitosSub"
                                                Text="Nueva Orden de compra(+)" ToolTip="Agregar Orden de compra"></asp:HyperLink>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <asp:GridView ID="gvListadoAP" runat="server" AutoGenerateColumns="False" DataKeyNames="IdOrden"
                                                CssClass="Grilla2" Width="700px" BorderStyle="None" BorderWidth="1px" AllowPaging="True"
                                                GridLines="Vertical" PageSize="20">
                                                <EmptyDataTemplate>
                                                    <asp:Label ID="lblVacio" runat="server" Text="No se encontraron registros" SkinID="label_vacio"></asp:Label>
                                                </EmptyDataTemplate>
                                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                <HeaderStyle CssClass="Header2" />
                                                <Columns>
                                                    <asp:BoundField DataField="IdOrden" HeaderText="IdOrden" HeaderStyle-CssClass="Header2" Visible="false" ItemStyle-CssClass="Item2">
                                                        <ControlStyle Width="40px" />

                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Local" HeaderText="Local" HeaderStyle-CssClass="Header2" ItemStyle-CssClass="Item2">
                                                        <HeaderStyle />
                                                        <ItemStyle HorizontalAlign="Center" Width="60px" Wrap="False" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Proyecto" HeaderText="Proyecto" HeaderStyle-CssClass="Header2" ItemStyle-CssClass="Item2">
                                                        <ControlStyle Width="150px" />
                                                        <HeaderStyle />
                                                        <ItemStyle HorizontalAlign="Center" Width="100px" Wrap="False" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Usuario" HeaderText="Usuario" HeaderStyle-CssClass="Header2" ItemStyle-CssClass="Item2">

                                                        <ItemStyle HorizontalAlign="Center" Width="120px" />
                                                    </asp:BoundField>

                                                    <asp:BoundField DataField="FechaOrden" HeaderText="Fecha Orden" HeaderStyle-CssClass="Header2" ItemStyle-CssClass="Item2">

                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>

                                                    <asp:BoundField DataField="MontoSoles" HeaderText="Monto Soles" HeaderStyle-CssClass="Header2" ItemStyle-CssClass="Item2">

                                                        <ItemStyle HorizontalAlign="Center" Width="180px" />
                                                    </asp:BoundField>

                                                    <asp:BoundField DataField="Estatus" HeaderText="Estatus" HeaderStyle-CssClass="Header2" ItemStyle-CssClass="Item2">

                                                        <ItemStyle HorizontalAlign="Center" Width="200px" />
                                                    </asp:BoundField>

                                                    <asp:TemplateField HeaderText="" HeaderStyle-CssClass="Header2" ItemStyle-CssClass="Item2">
                                                        <ItemTemplate>
                                                            <asp:LinkButton runat="server" Text="Ver" ID="lkbtnVer" OnClick="lkbtnVer_Click"> </asp:LinkButton>
                                                        </ItemTemplate>
                                                        <HeaderStyle />
                                                        <ItemStyle CssClass="Item2" HorizontalAlign="Center" Width="30px" Wrap="False"></ItemStyle>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <PagerStyle CssClass="Pie2" ForeColor="White" HorizontalAlign="center" />
                                                <AlternatingRowStyle BackColor="#FFFFFF" />
                                            </asp:GridView>

                                            <br />
                                            <div style="text-align: center">
                                                <asp:Label ID="lblMensaje" runat="server" Text="" EnableViewState="false" SkinID="label_vacio"></asp:Label>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <div style="text-align: center">
                            </div>
                        </ContentTemplate>
                        <Triggers>
                        </Triggers>
                    </asp:UpdatePanel>
                    <div style="display: none;">
                        <asp:Button runat="server" ID="btnShoPopup" /></div>
                    <div style="display: none;">
                        <asp:Button runat="server" ID="btnShoPopup4" /></div>
                </td>
            </tr>
        </table>
    </div>

    <ajaxToolkit:ModalPopupExtender runat="server" ID="ModalPopUp2" BackgroundCssClass=" popUpModal" TargetControlID="btnShoPopup" PopupControlID="modal2" DropShadow="true" Drag="false"
        CancelControlID="lkbtnCancel" PopupDragHandleControlID="panel2">
    </ajaxToolkit:ModalPopupExtender>
    <div id="modal2" style="width: 450px; background-color: white; border: 2px solid; margin-left: 10%;">
        <asp:Panel Height="100%" Width="100%" CssClass=" modalBG" runat="server" ID="panel2" ViewStateMode="Enabled" EnableViewState="true">
            <asp:UpdatePanel runat="server" ID="UpdatePanel2">
                <Triggers>
                    <%--  <asp:PostBackTrigger  ControlID="lkbtnRechazarPed"/>--%>
                    <asp:AsyncPostBackTrigger EventName="Click" ControlID="lkbtnRechazarPed" />
                    <asp:AsyncPostBackTrigger ControlID="lkbtnAcepRazRechazo" EventName="Click" />

                </Triggers>

                <ContentTemplate>

                    <table style="width: 100%; height: 50%; text-align: left;">

                        <tr>
                            <td colspan="2" style="background-color: #FFCC00; text-align: center; font-weight: bold;">
                                <asp:Label runat="server" Text="Detalle Orden" CssClass="tittleclass2"></asp:Label>
                            </td>
                        </tr>


                        <tr>
                            <td style="text-align: left;">
                                <div style="margin-left: 10px;">
                                    <asp:Label runat="server" Text=" IDOrden: " CssClass="labelCss"></asp:Label>


                                    <asp:Label runat="server" Text="--" ID="lblIdOrden" CssClass="font-bold"></asp:Label>
                                </div>
                            </td>



                            <td style="text-align: left;">
                                <div style="margin-left: 10px;">
                                    <asp:Label runat="server" Text="Moneda: " CssClass="labelCss"></asp:Label>


                                    <asp:Label runat="server" Text="--" ID="lblMoneda"></asp:Label>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left;">
                                <div style="margin-left: 10px;">
                                    <asp:Label runat="server" CssClass="labelCss" Text="Proyecto: "></asp:Label>

                                    <asp:Label CssClass="font-bold" ID="lblProyecto" runat="server" Text="--"></asp:Label>
                                </div>
                            </td>

                            <td style="text-align: left;">
                                <div style="margin-left: 10px;">
                                    <asp:Label runat="server" CssClass="labelCss" Text="Descripcion: "></asp:Label>

                                    <asp:Label CssClass="font-bold" ID="lblDescripcion" runat="server" Text="--"></asp:Label>
                                </div>
                            </td>

                        </tr>
                        <tr>
                            <td style="text-align: left;">
                                <div style="margin-left: 10px;">
                                    <asp:Label runat="server" CssClass="labelCss" Text="Tipo: "></asp:Label>

                                    <asp:Label CssClass="font-bold" ID="lblTipoBien" runat="server" Text="--"></asp:Label>
                                </div>
                            </td>
                        </tr>
                        <tr>

                            <td colspan="2">
                                <div>
                                    <asp:GridView ID="GridDetalleOrden" runat="server" AutoGenerateColumns="False" ViewStateMode="Enabled" Width="440px">
                                        <Columns>

                                            <asp:BoundField DataField="Producto" HeaderStyle-CssClass="Header2" HeaderText="Producto" ItemStyle-CssClass="Item2">
                                                <HeaderStyle />
                                                <ItemStyle Font-Size="Larger" HorizontalAlign="Center" Wrap="False" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Precio" HeaderStyle-CssClass="Header2" HeaderText="Precio" ItemStyle-CssClass="Item2">
                                                <HeaderStyle />
                                                <ItemStyle Font-Size="Larger" HorizontalAlign="Center" Wrap="False" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Cantidad" HeaderStyle-CssClass="Header2" HeaderText="Cantidad" ItemStyle-CssClass="Item2">
                                                <HeaderStyle />
                                                <ItemStyle Font-Size="Larger" HorizontalAlign="Center" Wrap="False" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="SubTotal" HeaderStyle-CssClass="Header2" HeaderText="SubTotal" ItemStyle-CssClass="Item2">
                                                <HeaderStyle />
                                                <ItemStyle Font-Size="Larger" HorizontalAlign="Center" Wrap="False" />
                                            </asp:BoundField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align: center;">
                                <div style="position: relative; text-align: center;">
                                    <style>
                                        .lkbtns {
                                            margin-left: 8px;
                                        }
                                    </style>
                                    &nbsp;&nbsp;<asp:LinkButton runat="server" ID="lkbtnAprobarPedido" CssClass="lkbtns" Text="Aprobar" OnClientClick="Confirm()" OnClick="lkbtnAprobarPedido_Click"></asp:LinkButton>
                                    <asp:LinkButton runat="server" CssClass="lkbtns" Text="Rechazar" ID="lkbtnRechazarPed" OnClick="lkbtnRechazarPed_Click"></asp:LinkButton>
                                    <asp:LinkButton ID="lkbtnCancel" runat="server" CssClass="lkbtns" Text="Cerrar" OnClick="lkbtnCancel_Click"></asp:LinkButton>
                                </div>
                            </td>
                        </tr>



                    </table>


                </ContentTemplate>

            </asp:UpdatePanel>

        </asp:Panel>

    </div>

    <ajaxToolkit:ModalPopupExtender runat="server" ID="ModalPopupExtender3" BackgroundCssClass=" popUpModal" TargetControlID="btnShoPopup4" PopupControlID="modal3" DropShadow="true" Drag="false"
        CancelControlID="lkbtnCancelRazon" PopupDragHandleControlID="panel3">
    </ajaxToolkit:ModalPopupExtender>
    <div id="modal3" style="width: 210px; background-color: white; border: 2px solid; margin-left: 10%;">
        <asp:Panel Height="100%" Width="100%" CssClass=" modalBG" runat="server" ID="panel3" ViewStateMode="Enabled" EnableViewState="true">
            <asp:UpdatePanel runat="server" ID="UpdatePanel1">
                <Triggers>
                    <%-- <asp:PostBackTrigger  ControlID="lkbtnAcepRazRechazo"/>--%>
                    <%--<asp:PostBackTrigger ControlID="lkbtnAcepRazRechazo"  />--%>
                </Triggers>
                <ContentTemplate>

                    <table style="width: 200px; height: 50%; text-align: left;">

                        <tr>
                            <td colspan="2" style="background-color: #FFCC00; text-align: center; font-weight: bold;">
                                <asp:Label runat="server" Text="Razon de rechazo" CssClass="tittleclass2"></asp:Label>
                            </td>
                        </tr>


                        <tr>
                            <td colspan="2" style="text-align: center;">
                                <div style="margin-left: 10px;">
                                    <asp:TextBox runat="server" Width="190px" Height="50px" ID="txtMotivoRechazo" TextMode="MultiLine"></asp:TextBox>
                                </div>
                            </td>



                        </tr>


                        <tr>
                            <td colspan="2" style="text-align: center;">
                                <div style="position: relative; text-align: center;">
                                    <style>
                                        .lkbtns {
                                            margin-left: 8px;
                                        }
                                    </style>
                                    &nbsp;&nbsp;<asp:LinkButton runat="server" ID="lkbtnAcepRazRechazo" CssClass="lkbtns" Text="Aceptar" OnClick="lkbtnAcepRazRechazo_Click"></asp:LinkButton>
                                    <asp:LinkButton runat="server" ID="lkbtnCancelRazon" CssClass="lkbtns" Text="Cancelar"></asp:LinkButton>

                                </div>
                            </td>
                        </tr>



                    </table>


                </ContentTemplate>

            </asp:UpdatePanel>

        </asp:Panel>

    </div>
</asp:Content>

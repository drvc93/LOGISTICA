<%@ Page Title="Aprobacion Coord. Logistica" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WFAprobacionCoordLogistica.aspx.cs" UICulture="Auto" Culture="Auto" Inherits="WSLogis.Aprobaciones.WFAprobacionCoordLogistica" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="../Styles/jquery.jnotify.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery-1.4.2.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery.jnotify.js" type="text/javascript"></script>

    <script>

        function popitup(url) {
            newwindow = window.open(url, 'name', 'height=300px,width=456px,navigationtoolbar=no,toolbar=no,menubar=no,left=150,top=180');/**/
        }
    </script>


    <script type="text/javascript">
        function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("¿Esta seguro de aprobar el pedido?")) {
                confirm_value.value = "Si";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager runat="server" ID="srciptManager1" EnableScriptGlobalization="true"
        EnableScriptLocalization="true">
    </asp:ScriptManager>

    <div>
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <asp:Panel runat="server">
                    <table style="margin-left: 15%; margin-top: 35px; width: 700px;">
                        <tr>
                            <td colspan="4" style="text-align: center;">
                                <div style="background-color: #FFCC00; height: 28px;">
                                    <h2>Aprobacion Coord. Logistica </h2>
                                </div>
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
                                <asp:DropDownList runat="server" CssClass="textbox1" ID="ddlProyecto" Width="150" AutoPostBack="true" OnSelectedIndexChanged="ddlProyecto_SelectedIndexChanged"></asp:DropDownList>
                            </td>

                        </tr>

                        <tr style="margin-top: 10px;">

                            <td>

                                <asp:Label runat="server" Text="Fecha Desde : " CssClass="comboClass"></asp:Label>
                            </td>
                            <td style="margin-top: 10px;">
                                <asp:TextBox ID="txtFechaIni" runat="server" CssClass="textbox1"></asp:TextBox><ajaxToolkit:CalendarExtender runat="server" TargetControlID="txtFechaIni" Format="dd/MM/yyyy" />
                            </td>
                            <td style="text-align: right">

                                <asp:Label runat="server" Text="Fecha hasta : " CssClass="comboClass"></asp:Label>
                            </td>
                            <td style="margin-top: 10px;">
                                <asp:TextBox runat="server" ID="txtFechaHasta" CssClass="textbox1"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender runat="server" TargetControlID="txtFechaHasta" Format="dd/MM/yyyy" />
                            </td>

                        </tr>

                        <tr style="margin-top: 10px;">

                            <td style="text-align: right">

                                <asp:Label runat="server" Text=" ID Pedido : " CssClass="comboClass"></asp:Label>
                            </td>
                            <td style="margin-top: 10px;">
                                <asp:TextBox runat="server" CssClass="textbox1" ID="txtIdPedido"></asp:TextBox>
                                <ajaxToolkit:TextBoxWatermarkExtender   runat="server" ID="waterMark1" TargetControlID="txtIdPedido" WatermarkText="ID Pedido" />
                            </td>
                            <td style="text-align: right">

                                <asp:Label runat="server" Text="Estado: " CssClass="comboClass"></asp:Label>
                            </td>
                            <td style="margin-top: 10px;">
                                <asp:DropDownList runat="server" ID="ddlEstado" CssClass="textbox1" Width="150" AutoPostBack="true" OnSelectedIndexChanged="ddlEstado_SelectedIndexChanged"></asp:DropDownList>
                                <asp:LinkButton runat="server" ID="lkbtnBuscar" CssClass=" linkbuttonClass2" Text="Buscar" OnClick="lkbtnBuscar_Click"></asp:LinkButton>

                            </td>

                        </tr>
                        <tr>
                            <td colspan="4">
                                <div style="margin-left: 10px; margin-right: 10px; margin-top: 10px; margin-bottom: 10px;">

                                    <asp:GridView ID="GridPedidosProceso" runat="server" CssClass="Grilla2" AutoGenerateColumns="False" ViewStateMode="Enabled" Width="650px" DataKeyNames="IdPedido">
                                        <Columns>
                                            <asp:BoundField DataField="IdPedido" HeaderText="IdPedido" HeaderStyle-CssClass="Header2" ItemStyle-CssClass="Item2">
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

                                            <asp:BoundField DataField="FechaPedido" HeaderText="Fecha Pedido" HeaderStyle-CssClass="Header2" ItemStyle-CssClass="Item2">

                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>

                                            <asp:BoundField DataField="Estatus" HeaderText="Estatus" HeaderStyle-CssClass="Header2" ItemStyle-CssClass="Item2">

                                                <ItemStyle HorizontalAlign="Center" Width="200px" />
                                            </asp:BoundField>

                                            <asp:TemplateField HeaderText="" HeaderStyle-CssClass="Header2" ItemStyle-CssClass="Item2">
                                                <ItemTemplate>
                                                    <asp:LinkButton runat="server" Text="Ver" ID="lkbtnVer" OnClick="lkbtnVer_Click" OnClientClick="popitup('WFPedidoDetalle.aspx')"> </asp:LinkButton>
                                                </ItemTemplate>
                                                <HeaderStyle />
                                                <ItemStyle CssClass="Item2" HorizontalAlign="Center" Width="30px" Wrap="False"></ItemStyle>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>


                                </div>

                            </td>

                        </tr>
                    </table>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div style="display: none;">
            <asp:Button runat="server" ID="btnShoPopup" /></div>
        <div style="display: none;">
            <asp:Button runat="server" ID="btnShoPopup2" /></div>
    </div>

</asp:Content>

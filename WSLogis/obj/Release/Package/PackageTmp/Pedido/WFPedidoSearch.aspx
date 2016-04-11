<%@ Page Title="Lista de Pedidos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WFPedidoSearch.aspx.cs" Inherits="WSLogis.Pedido.WFPedidoSearch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script>

        function popitup(url) {
            newwindow = window.open(url, 'other', 'height=800,width=820px,navigationtoolbar=no,toolbar=no,menubar=no,left=150,top=180');/**/
        }

        function RefreshGrid() {/**/

            document.getElementById("<%=btnFuncionRefresh.ClientID %>").click();



        }
    </script>
     <link href="../Styles/jquery.jnotify.css" rel="stylesheet" />
    <script src="../Scripts/jquery-1.4.2.min.js"></script>
    <script src="../Scripts/jquery.jnotify.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div style="margin-top: 35px">

        <asp:ScriptManager EnableScriptGlobalization="true" EnableScriptLocalization="false" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel runat="server">
            <Triggers>
            </Triggers>
            <ContentTemplate>

                <asp:Panel runat="server" Style="width: 1000px">



                    <div style="width: 810px; margin-left: 20%">
                        <table style="width: 740px">
                            <tr>
                                <td colspan="4" style="text-align: center">
                                    <div style="width: 100%; margin-bottom: 20px">
                                        <asp:Label runat="server" CssClass="Titulitos" Text="Listado de Pedidos"></asp:Label>
                                    </div>

                                </td>
                            </tr>

                            <tr style="margin-top: 10px;">

                                <td style="padding-bottom: 5px; padding-top: 5px; text-align: right">

                                    <asp:Label runat="server" Text="Local: " CssClass="comboClass"></asp:Label>
                                </td>
                                <td style="padding-bottom: 5px; padding-top: 5px; margin-top: 10px;">
                                    <asp:DropDownList runat="server" AutoPostBack="true" CssClass=" textbox1" ID="ddLocal" Width="140"></asp:DropDownList>
                                </td>
                                <td style="text-align: right">
                                    <asp:Label runat="server" Text="Proyecto: " CssClass="comboClass"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList runat="server" CssClass=" textbox1" ID="ddlProyecto" Width="150" AutoPostBack="true"></asp:DropDownList>
                                </td>

                            </tr>
                            <tr style="margin-top: 10px;">

                                <td style="padding-bottom: 5px; padding-top: 5px; text-align: right">

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

                                <td style="padding-bottom: 5px; padding-top: 5px; text-align: right">

                                    <asp:Label runat="server" Text=" ID Pedido : " CssClass="comboClass"></asp:Label>
                                </td>
                                <td style="margin-top: 10px;">
                                    <asp:TextBox runat="server" CssClass=" textbox1" ID="txtIdPedido" AutoPostBack="true"></asp:TextBox>
                                    <ajaxToolkit:TextBoxWatermarkExtender runat="server" ID="waterMark1" TargetControlID="txtIdPedido" WatermarkText="ID Pedido" />
                                </td>
                                <td style="text-align: right">

                                    <asp:Label runat="server" Text="Estado: " CssClass="comboClass"></asp:Label>
                                </td>
                                <td style="margin-top: 10px;">
                                    <asp:DropDownList runat="server" ID="ddlEstado" CssClass=" textbox1" Width="150" AutoPostBack="true"></asp:DropDownList>
                                    <asp:LinkButton runat="server" ID="lkbtnBuscar" CssClass=" lkbtnSpace" Text="Buscar"></asp:LinkButton>

                                </td>

                            </tr>
                            <tr>
                                <td colspan="4">

                                    <asp:LinkButton OnClientClick="popitup('WFPedidoEdit.aspx')" ID="lkNewPedido" Text="Nuevo Pedido" Style="margin-left: 10px" runat="server"></asp:LinkButton>

                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <div>
                                        <asp:GridView AutoGenerateColumns="false" Width="790px" Style="margin-left: 10px" runat="server"  HeaderStyle-CssClass="Header2" ID="gvPedidosProceso" CssClass="Grilla2" OnDataBound="gvPedidosProceso_DataBound">

                                            <Columns>
                                                <asp:TemplateField HeaderText="FechaPedido">
                                                    <ItemTemplate >
                                                    
                                                        <asp:Label runat="server" Text='<%#Eval("FechaPedido").ToString().Substring(0,10)%>' > </asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle  CssClass="Item2"/>
                                                </asp:TemplateField>
                                               <%-- <asp:BoundField DataField="FechaPedido" HeaderText="FechaPedido"  ItemStyle-CssClass="Item2"  />--%>
                                                <asp:BoundField DataField="NroPedido" HeaderText="NroPedido" ItemStyle-CssClass="Item2" />
                                                <asp:BoundField DataField="Proyecto" HeaderText="Proyecto"  ItemStyle-Width="300px" ItemStyle-CssClass="Item2" ItemStyle-Wrap="true" />
                                                <asp:BoundField DataField="Monto" HeaderText="Monto" ItemStyle-CssClass="Item2" />
                                                <asp:BoundField DataField="Moneda" HeaderText="Moneda" ItemStyle-CssClass="Item2" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center" />
                                                <asp:BoundField DataField="Estado" HeaderText="Estado" ItemStyle-Width="200px" ItemStyle-CssClass="Item2" />
                                                <asp:BoundField  DataField="AprobadoPor" HeaderText= "Aprob./Rechazado Por"  HeaderStyle-Wrap="true" HeaderStyle-Width="50px" ItemStyle-Width="50px" ItemStyle-CssClass="Item2" />
                                                <asp:TemplateField ItemStyle-CssClass="Item2" HeaderStyle-Width="70px" ItemStyle-HorizontalAlign="Center">
                                                  
                                                    <ItemTemplate>
                                                        <asp:LinkButton runat="server" Text="Editar" ID="lkEditar" Visible='<%#Eval("LkbtnEditable") %>'></asp:LinkButton>
                                                    </ItemTemplate>

                                                </asp:TemplateField>
                                            </Columns>

                                        </asp:GridView>
                                    </div>
                                </td>
                            </tr>

                        </table>

                    </div>
                    <asp:Button  ID="btnFuncionRefresh" runat="server" style =" display:none;" OnClick="btnFuncionRefresh_Click" />
                    
                </asp:Panel>

            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>

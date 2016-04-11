<%@ Page Title="Registrar Ingreso" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WFRegistroIngreso.aspx.cs" Inherits="WSLogis.Almacen.WFRegistroIngreso" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script>
        function popitup(url) {
            newwindow = window.open(url, 'name', 'height=600,width=800,navigationtoolbar=no,toolbar=no,menubar=no,left=150,top=180');/**/
        }

        function RefreshGrid() {/**/

            document.getElementById("<%=btnrefreshGrid.ClientID %>").click();



        }
    </script>
     <link href="../Styles/jquery.jnotify.css" rel="stylesheet" />
     <script src="../Scripts/jquery-1.4.2.min.js"></script>
     <script src="../Scripts/jquery.jnotify.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div style="width: 100%">
        <asp:ScriptManager runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="false"></asp:ScriptManager>
        <asp:UpdatePanel runat="server">
            <ContentTemplate>


                <div style="width: 930px; margin-left: auto; margin-right: auto">

                    <table style="width: 910px">
                        <tr>
                            <td colspan="4" style="text-align: center">

                                <h2>Registro Ingreso</h2>

                            </td>


                        </tr>



                        <tr style="margin-top: 10px;">

                            <td style="text-align: right">

                                <asp:Label runat="server" Text="Local de entrega: " CssClass="comboClass"></asp:Label>
                            </td>
                            <td style="margin-top: 10px; text-align: left;">
                                <asp:DropDownList runat="server" AutoPostBack="true" CssClass=" textbox1" ID="ddLocal" Width="140"></asp:DropDownList>
                            </td>
                            <td style="text-align: right">
                                <asp:Label runat="server" Text="Proyecto: " CssClass="comboClass"></asp:Label>
                            </td>
                            <td style="text-align: left;">
                                <asp:DropDownList runat="server" CssClass=" textbox1" ID="ddlProyecto" Width="150" AutoPostBack="true"></asp:DropDownList>
                            </td>

                        </tr>
                        <tr style="margin-top: 10px;">

                            <td style="text-align: right">

                                <asp:Label runat="server" Text="Fecha Desde : " CssClass=""></asp:Label>
                            </td>
                            <td style="margin-top: 10px; text-align: left;">
                                <asp:TextBox ID="txtFechaIni" runat="server" CssClass=" textbox1" AutoPostBack="true"></asp:TextBox><ajaxToolkit:CalendarExtender runat="server" TargetControlID="txtFechaIni" Format="dd/MM/yyyy" />
                            </td>
                            <td style="text-align: right;">

                                <asp:Label runat="server" Text="Fecha hasta: " CssClass=""></asp:Label>
                            </td>
                            <td style="margin-top: 10px; text-align: left;">
                                <asp:TextBox runat="server" ID="txtFechaHasta" CssClass=" textbox1" AutoPostBack="true"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender runat="server" TargetControlID="txtFechaHasta" Format="dd/MM/yyyy" />
                            </td>

                        </tr>

                        <tr style="margin-top: 10px;">

                            <td style="text-align: right">

                                <asp:Label runat="server" Text=" ID Recepción : " CssClass="comboClass"></asp:Label>
                            </td>
                            <td style="margin-top: 10px; text-align: left;">
                                <asp:TextBox runat="server" CssClass=" textbox1" ID="txtIDrecepcion" AutoPostBack="true"></asp:TextBox>
                                <ajaxToolkit:TextBoxWatermarkExtender runat="server" ID="waterMark1" TargetControlID="txtIDrecepcion" WatermarkText="ID Recepción" />
                            </td>
                            <td style="text-align: right">

                                <asp:Label runat="server" Text="Estado: " CssClass="comboClass"></asp:Label>
                            </td>
                            <td style="margin-top: 10px; text-align: left;">
                                <asp:DropDownList runat="server" ID="ddlEstado" CssClass=" textbox1" Width="150" AutoPostBack="true"></asp:DropDownList>
                                <asp:LinkButton runat="server" ID="lkbtnBuscar" Text="Buscar"></asp:LinkButton>

                            </td>

                        </tr>
                        <tr>
                            <td colspan="4">
                                <div style="margin-top:15px;">
                                    <asp:GridView ID="GridIngresos"  runat="server" EmptyDataText="No se encontro resultados" CssClass=" Grilla2" AutoGenerateColumns="false" ViewStateMode="Enabled" DataKeyNames="CodigoRC" Width="900">
                                        <Columns>

                                             <asp:BoundField DataField="CodigoRC" HeaderText="Nro. RC" ItemStyle-Width="65px" Visible="false"  >
                                                <HeaderStyle CssClass="Header2" />
                                                <ItemStyle CssClass="Item2" />
                                            </asp:BoundField>

                                            <asp:BoundField DataField="CodigoOC" HeaderText="Nro. Orden" ItemStyle-Width="60px">
                                                <HeaderStyle CssClass="Header2" />
                                                <ItemStyle CssClass="Item2" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="NroFactura" HeaderText="Nro. Fact." ItemStyle-Width="60px">
                                                <HeaderStyle CssClass="Header2" />
                                                <ItemStyle CssClass="Item2" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="IdProducto" HeaderText="IDProducto" ItemStyle-Width="50px">
                                                <HeaderStyle CssClass="Header2" />
                                                <ItemStyle CssClass="Item2" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Producto" HeaderText="Producto" ItemStyle-Width="350px">
                                                <HeaderStyle CssClass="Header2" />
                                                <ItemStyle CssClass="Item2" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Local" HeaderText="Local Entrega" ItemStyle-Width="80px">
                                                <HeaderStyle CssClass="Header2" />
                                                <ItemStyle CssClass="Item2" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Proyecto" HeaderText="Proyecto" ItemStyle-Width="300px">
                                                <HeaderStyle CssClass="Header2" />
                                                <ItemStyle CssClass="Item2" />
                                            </asp:BoundField>

                                            <asp:BoundField DataField="Proveedor" HeaderText="Proveedor"  ItemStyle-Width="300px">
                                                <HeaderStyle CssClass="Header2" />
                                                <ItemStyle CssClass="Item2" Wrap="true" />
                                            </asp:BoundField>


                                            <asp:BoundField DataField="FechaRecepcion" HeaderText="FechaRecepción" ItemStyle-Width="100px">
                                                <HeaderStyle CssClass="Header2" />
                                                <ItemStyle CssClass="Item2" />
                                            </asp:BoundField>

                                            <asp:BoundField DataField="Estado" HeaderText="Estado" ItemStyle-Width="180px">
                                                <HeaderStyle CssClass="Header2" />
                                                <ItemStyle CssClass="Item2" Wrap="true" />
                                            </asp:BoundField>

                                            <asp:TemplateField HeaderText="" ItemStyle-CssClass="alingRowButons" ItemStyle-Width="50px">
                                                <ItemTemplate>
                                                    <asp:LinkButton runat="server" OnClick="lkbtnIngresar_Click" Visible='<%#Eval("LinkVisible") %>' Text="Ingresar" ID="lkbtnIngresar" ></asp:LinkButton>
                                                </ItemTemplate>
                                                <HeaderStyle CssClass="Header2" />
                                                <ItemStyle CssClass="Item2"></ItemStyle>
                                            </asp:TemplateField>

                                        </Columns>
                                    </asp:GridView>

                                </div>

                            </td>

                        </tr>

                    </table>

                </div>
                <asp:Button runat="server"  ID="btnrefreshGrid" style="display:none" OnClick="btnrefreshGrid_Click" />
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

</asp:Content>

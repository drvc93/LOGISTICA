<%@ Page Title="Registro de Productos" Language="C#" AutoEventWireup="true" CodeBehind="WFProductoSearch.aspx.cs" Inherits="WSLogis.Administracion.WFProductoSearch" MasterPageFile="~/Site.Master" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">

    <link href="../Styles/jquery.jnotify.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery-1.4.2.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery.jnotify.js" type="text/javascript"></script>

    <script>

        function popitup(url) {
            newwindow = window.open(url, 'name', 'height=500,width=700,navigationtoolbar=no,toolbar=no,menubar=no,left=150,top=180');/**/
        }
        function RefreshUpdatePanel() {
            __doPostBack('<%= txtBuscar.ClientID %>', '');
        };
    </script>

</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">







    <div style="margin-top: 20px">
        <asp:ScriptManager runat="server" ID="idScripm" EnablePartialRendering="true"></asp:ScriptManager>
        <asp:UpdatePanel runat="server">
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnNuevoProduct" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="txtBuscar" EventName="TextChanged" />
                <asp:AsyncPostBackTrigger ControlID="ddlCategoria" EventName="SelectedIndexChanged" />
                  <asp:AsyncPostBackTrigger ControlID="ddlSubCategoria" EventName="SelectedIndexChanged" />
            </Triggers>
            <ContentTemplate>
                <table>
                    <tr>
                        <td colspan=" 4">
                            <h2 style="color: black;">Buscar Producto </h2>

                        </td>

                    </tr>

                    <tr>
                        <td colspan="4">

                            <table>
                                <tr>
                                    <td>
                                        <asp:Label runat="server" Text="Categoria:"></asp:Label>

                                    </td>

                                    <td>
                                        <asp:DropDownList AutoPostBack="true" OnSelectedIndexChanged="ddlCategoria_SelectedIndexChanged" Width="200px" runat="server" CssClass="textbox1" ID="ddlCategoria"></asp:DropDownList>
                                    </td>


                                    <td>
                                        <asp:Label runat="server" Text="Categoria:"></asp:Label>
                                    </td>

                                    <td>
                                        <asp:DropDownList  AutoPostBack="true" Width="200px" runat="server" CssClass="textbox1" ID="ddlSubCategoria" OnSelectedIndexChanged="ddlSubCategoria_SelectedIndexChanged" ></asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:TextBox Style="margin-left: 10px" runat="server" onkeyup="RefreshUpdatePanel();" ID="txtBuscar" CssClass="textbox1" Width="250px" AutoPostBack="True" OnTextChanged="txtBuscar_TextChanged"></asp:TextBox><ajaxToolkit:TextBoxWatermarkExtender WatermarkCssClass="hintText" runat="server" ID="waterMark1" TargetControlID="txtBuscar" WatermarkText="Nombre Producto" />



                                        <asp:LinkButton Style="margin-left: 10px" runat="server" ID="btnBuscarProducto" Text="Buscar" CssClass=" linkbuttonClass" OnClick="btnBuscarProducto_Click">  </asp:LinkButton>



                                        <asp:LinkButton Style="margin-left: 10px" runat="server" ID="btnNuevoProduct" Text="Nuevo" CssClass=" linkbuttonClass" OnClick="btnNuevoProduct_Click" OnClientClick="return popitup('WFProductoNew.aspx')"></asp:LinkButton>
                                    </td>
                                </tr>
                            </table>
                        </td>


                    </tr>
                    <tr>
                        <td colspan="4">
                            <div>
                                <asp:GridView ID="gridProductos" runat="server" AutoGenerateColumns="False" ViewStateMode="Enabled" Width="700px" DataKeyNames="CodigoProducto" PageSize="12" AllowPaging="True" OnPageIndexChanging="gridProductos_PageIndexChanging" CssClass="Grilla2">
                                    <Columns>
                                        <asp:BoundField DataField="Categoria" HeaderText="Categoria">
                                            <HeaderStyle CssClass="Header2" Width="150px" />
                                            <ItemStyle CssClass="Item2" Width="150px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="subcategoria" HeaderText="Sub Categoria">
                                            <HeaderStyle CssClass="Header2" Width="150px" />
                                            <ItemStyle CssClass="Item2" Width="150px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Descripcion" HeaderText="Descripción">
                                            <HeaderStyle CssClass="Header2" Width="320px" />
                                            <ItemStyle CssClass="Item2" Width="320px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="StockMinimo" HeaderText="Stock Minimo">
                                            <HeaderStyle CssClass="Header2" Width="70px" />
                                            <ItemStyle CssClass="Item2" Width="70px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="CodigoProducto" HeaderText="Codigo" Visible="false"></asp:BoundField>
                                        <asp:TemplateField HeaderText="" ShowHeader="false" ItemStyle-CssClass="Item2" HeaderStyle-CssClass="Header2">
                                            <ItemTemplate>
                                                <asp:LinkButton runat="server" ID="btnEditP" OnClick="btnEditP_Click" Text="Editar" OnClientClick="return popitup('WFProductoNew.aspx')" CssClass=" linkbuttonClass"></asp:LinkButton>
                                            </ItemTemplate>
                                            <ItemStyle CssClass="Item2" Width="10px"></ItemStyle>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>

                            </div>

                        </td>

                    </tr>

                </table>
                </div>
       





        
            </ContentTemplate>
        </asp:UpdatePanel>






    </div>


</asp:Content>

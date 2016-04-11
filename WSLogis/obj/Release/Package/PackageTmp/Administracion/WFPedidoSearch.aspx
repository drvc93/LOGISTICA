<%@ Page Title="Buscar Pedido" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WFPedidoSearch.aspx.cs" Inherits="WSLogis.Administracion.WFPedidoSearch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="../Styles/jquery.jnotify.css" rel="stylesheet" />
    <script src="../Scripts/jquery-1.4.2.min.js"></script>
    <script src="../Scripts/jquery.jnotify.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div style="margin-left: 10%;">

        <h2>Buscar Pedido </h2>

        <div style="margin-bottom: 10px;">
            <asp:TextBox runat="server" CssClass=" textbox1" Width="200px"></asp:TextBox>
            <asp:LinkButton runat="server" Text="Buscar"></asp:LinkButton>
        </div>



        <asp:GridView runat="server" ID="GridPedidos" AutoGenerateColumns="False" ViewStateMode="Enabled" DataKeyNames="CodigoPedido" CssClass="Grilla2">
            <Columns>
                <asp:BoundField DataField="CodigoPedido" HeaderText="Codigo Pedido" ItemStyle-VerticalAlign="Middle" HeaderStyle-HorizontalAlign="Center">
                    <HeaderStyle CssClass="Header2" />
                    <ItemStyle CssClass="Item2" HorizontalAlign="Center" />
                </asp:BoundField>

                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" ItemStyle-CssClass="Item2" HeaderStyle-CssClass="Header2">
                    <HeaderStyle />

                </asp:BoundField>

                <asp:BoundField DataField="Proyecto" HeaderText="Proyecto" ItemStyle-CssClass="Item2" HeaderStyle-CssClass="Header2">
                    <HeaderStyle />
                    <ItemStyle Font-Bold="False" />
                </asp:BoundField>
                <asp:BoundField DataField="FechaPedido" HeaderText="Fecha Pedido" ItemStyle-CssClass="Item2" HeaderStyle-CssClass="Header2">
                    <HeaderStyle />
                    <ItemStyle Font-Bold="False" />
                </asp:BoundField>
                <asp:BoundField DataField="Monto" HeaderText="Monto" ItemStyle-CssClass="Item2" HeaderStyle-CssClass="Header2">
                    <HeaderStyle />
                    <ItemStyle Font-Bold="False" />
                </asp:BoundField>
                <asp:BoundField DataField="Moneda" HeaderText="Moneda" ItemStyle-CssClass="Item2" HeaderStyle-CssClass="Header2">
                    <HeaderStyle />
                    <ItemStyle Font-Bold="False" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="" ShowHeader="false" ItemStyle-CssClass="alingRowButons">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="lkRowGenerar" Text="Generar Orden" OnClick="lkRowGenerar_Click"></asp:LinkButton>

                    </ItemTemplate>
                    <HeaderStyle CssClass="Header2" Width="60px" />

                    <ItemStyle CssClass=" Item2" Width="100px"></ItemStyle>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>


    </div>


</asp:Content>

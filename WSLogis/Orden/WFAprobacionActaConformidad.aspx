<%@ Page Title="Acta Conformidad" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WFAprobacionActaConformidad.aspx.cs" Inherits="WSLogis.Orden.WFAprobacionActaConformidad" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script>

        function popitup(url) {
            var w = 1000;
            var h = screen.availHeight-50
            newwindow = window.open(url, 'other', 'height=' + h + ',width=' + w + ',navigationtoolbar=no,toolbar=no,menubar=no,left=150,top=180');/**/
        }
    </script>
    <style>

        thead{
            background-color:#FFCC00;

        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <asp:ScriptManager runat="server"></asp:ScriptManager>
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div style="margin-left: 15%">
                    <asp:Panel runat="server">
                        <table>
                            <tr>
                                <td>
                                
                                    <asp:Label runat="server" CssClass="Titulitos" Text="Acta de conformidad"></asp:Label>
                                </td>
                            </tr>

                            <tr>
                                <td>
                                    <div>

                                        <telerik:RadSkinManager ID="RadSkinManager1" runat="server" />
                                        <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server"></telerik:RadAjaxLoadingPanel>
                                        <telerik:RadAjaxPanel runat="server">
                                            <telerik:RadGrid EnableAjaxSkinRendering="false" EnableEmbeddedSkins="false"  ID="radGridPedidos" CssClass="Grilla2"  AllowSorting="true" OnItemCommand="radGridPedidos_ItemCommand" AutoGenerateColumns="false" runat="server" OnNeedDataSource="radGridPedidos_NeedDataSource">
                                               
                                                <MasterTableView HeaderStyle-CssClass="Header2" AllowSorting="true" CssClass="Grilla2"  DataKeyNames="CodigoOC">
                                                    <NoRecordsTemplate>
                                                        <h4 style="font-weight:bold; color:black">No se encontro información</h4>
                                                    </NoRecordsTemplate>
                                                    <Columns>
                                                        <telerik:GridBoundColumn ItemStyle-CssClass="Item2" Display="false" FilterCheckListEnableLoadOnDemand="true" HeaderStyle-CssClass="Header2" DataField="CodigoOC" AllowFiltering="true" HeaderText="CodigoOC" HeaderStyle-Width="50px">
                                                         
                                                            <HeaderStyle ForeColor="Black"  BorderWidth="1px"  CssClass="Header2"/>
                                                            <ItemStyle  CssClass=" Item2" />
                                                            
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn  FilterCheckListEnableLoadOnDemand="true" HeaderStyle-CssClass="Header2" DataField="NroPedido" AllowFiltering="true" HeaderText="NroPedido" HeaderStyle-Width="50px">
                                                           
                                                            <HeaderStyle BorderWidth="1px"   ForeColor="Black"  CssClass="Header2"/>
                                                            <ItemStyle  CssClass=" Item2" />
                                                            
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn CurrentFilterFunction="EqualTo" FilterCheckListEnableLoadOnDemand="true" HeaderStyle-CssClass="Header2" DataField="Descripcion" AllowFiltering="true" HeaderText="Descripcion" HeaderStyle-Width="100px">
                                                       
                                                             <HeaderStyle  BorderWidth="1px"  ForeColor="Black" CssClass="Header2"/>
                                                            <ItemStyle  CssClass=" Item2" />
                                                            

                                                        </telerik:GridBoundColumn>

                                                        
                                                        <telerik:GridBoundColumn  DataField="FechaPedido" CurrentFilterFunction="Contains" ShowFilterIcon="false" HeaderText="FechaPedido" HeaderStyle-Width="100px">
                                                          <HeaderStyle  ForeColor="Black"  CssClass="Header2"/>
                                                            <ItemStyle  CssClass=" Item2" />
                                                        </telerik:GridBoundColumn>

                                                        <telerik:GridBoundColumn CurrentFilterFunction="EqualTo" FilterCheckListEnableLoadOnDemand="true" HeaderStyle-CssClass="Header2" DataField="GLOSA" AllowFiltering="true" HeaderText="Estado" HeaderStyle-Width="180px">
                                                       
                                                             <HeaderStyle  ForeColor="Black"  CssClass="Header2"/>
                                                            <ItemStyle  CssClass=" Item2" />
                                                            

                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridTemplateColumn HeaderStyle-Width="40px" HeaderStyle-CssClass="Header2" HeaderText="Conformidad">
                                                             <HeaderStyle   CssClass="Header2"/>
                                                            <ItemStyle  CssClass=" Item2" />
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lkbtnActa" Visible='<%#Eval("LkbtnEnable") %>' runat="server" CommandName="ActaConford" Text="Ver"></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                         <telerik:GridTemplateColumn HeaderStyle-Width="40px" HeaderStyle-CssClass="Header2" HeaderText="Editar">
                                                              <HeaderStyle   CssClass="Header2" ForeColor="Black"/>
                                                            <ItemStyle  CssClass=" Item2" />
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="LkbtnEdit" Visible='<%#Eval("LkbtnEditable") %>' runat="server" CommandName="ActaConford" Text="Editar"></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>

                                                    </Columns>
                                                </MasterTableView>
                                            </telerik:RadGrid>
                                        </telerik:RadAjaxPanel>
                                    </div>
                                </td>
                            </tr>
                        </table>

                    </asp:Panel>
                </div>
            </ContentTemplate>

        </asp:UpdatePanel>

    </div>

</asp:Content>

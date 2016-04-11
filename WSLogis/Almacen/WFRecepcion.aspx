<%@ Page Title="Recepcion de Orden de compra" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WFRecepcion.aspx.cs" Inherits="WSLogis.Almacen.WFRecepcion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script>
        function popitup(url) {
            newwindow = window.open(url, 'name', 'height=500,width=710,navigationtoolbar=no,toolbar=no,menubar=no,left=150,top=180');/**/
        }
    </script>
    <link href="../Styles/jquery.jnotify.css" rel="stylesheet" />
     <script src="../Scripts/jquery-1.4.2.min.js"></script>
     <script src="../Scripts/jquery.jnotify.js"></script>
    <script>
        function RefreshGrid() {/**/

            document.getElementById("<%=btnUpdateGrid.ClientID %>").click();



        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div style=" text-align:center; width:850px;margin-left:15%;  margin-top:20px;">
        <asp:ScriptManager runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="false" ></asp:ScriptManager>
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <asp:Panel runat="server">

               
         <table style=" text-align:center;">
                                   <tr>
                                     <td colspan="4" style="text-align:center;">
                                        <asp:Label ID="Label1" runat="server" CssClass="Titulitos" Text="Recepcion  Orden De Compra"></asp:Label>
                                     </td>
                                   </tr>

                                     <tr style="margin-top:10px;">

                                            <td style="text-align:right">
                
                                                <asp:Label runat="server" Text="Local de entrega: " CssClass="comboClass"></asp:Label>
                                            </td>
                                            <td style="margin-top:10px; text-align:left;">
                                                <asp:DropDownList runat="server"  AutoPostBack="true" CssClass=" textbox1" ID="ddLocal" Width="140"  OnSelectedIndexChanged="ddLocal_SelectedIndexChanged" ></asp:DropDownList>
                                            </td>
                                             <td style="text-align:right">
                                                <asp:Label runat="server" Text="Proyecto: "  CssClass="comboClass"></asp:Label>
                                            </td>
                                            <td style=" text-align:left;">
                                                <asp:DropDownList runat="server" CssClass=" textbox1" ID="ddlProyecto" Width="150" AutoPostBack="true"  OnSelectedIndexChanged="ddlProyecto_SelectedIndexChanged" ></asp:DropDownList>
                                            </td>

                                     </tr>
                                    <tr style="margin-top:10px;">

                                            <td  style="text-align:right">
                
                                                <asp:Label runat="server" Text="Fecha Desde : " CssClass=""></asp:Label>
                                            </td>
                                            <td style="margin-top:10px; text-align:left;">
                                              <asp:TextBox  ID="txtFechaIni" runat="server" CssClass=" textbox1" AutoPostBack="true"  ></asp:TextBox><ajaxToolkit:CalendarExtender  runat="server" TargetControlID="txtFechaIni" Format="dd/MM/yyyy"/>
                                            </td>
                                             <td  style="text-align:right;">
                
                                                <asp:Label runat="server" Text="Fecha hasta: " CssClass="" ></asp:Label>
                                            </td>
                                            <td style="margin-top:10px; text-align:left;">
                                              <asp:TextBox runat="server" ID="txtFechaHasta" CssClass=" textbox1" AutoPostBack="true"  ></asp:TextBox> <ajaxToolkit:CalendarExtender  runat="server" TargetControlID="txtFechaHasta" Format="dd/MM/yyyy"/>
                                            </td>

                                    </tr>

                                     <tr style="margin-top:10px;">

                                            <td style="text-align:right">
                
                                                <asp:Label runat="server" Text=" ID Orden : " CssClass="comboClass"></asp:Label>
                                            </td>
                                            <td style="margin-top:10px;  text-align:left;">
                                              <asp:TextBox runat="server" CssClass=" textbox1"  ID="txtIdPedido" AutoPostBack="true" ></asp:TextBox>
                                                  <ajaxToolkit:TextBoxWatermarkExtender runat="server" ID="waterMark1" TargetControlID="txtIdPedido"  WatermarkText="ID Orden" />
                                            </td>
                                             <td style="text-align:right">
                
                                                <asp:Label runat="server" Text="Estado: " CssClass="comboClass" ></asp:Label>
                                            </td>
                                            <td style="margin-top:10px;text-align:left;">
                                             <asp:DropDownList runat="server" ID="ddlEstado" CssClass=" textbox1" Width="150"  AutoPostBack="true" > </asp:DropDownList>
                                                 <asp:LinkButton runat="server" ID="lkbtnBuscar" CssClass=" lkbtnSpace" Text="Buscar" ></asp:LinkButton>
              
                                            </td>

                                     </tr>
                                     <tr>

                                         <td colspan="4">
                                             <div style="margin-top:15px;">

                                                 <asp:GridView ID="GridOCRecepcionar"  runat="server"   EmptyDataText="No se encontro resultados" CssClass=" Grilla2" AutoGenerateColumns="false" ViewStateMode="Enabled"  DataKeyNames="CodigoOC"  Width="100%" >
                                                    <Columns>
                                                       
                                                         <asp:BoundField DataField="CodigoOC" HeaderText="CodigoOC" ItemStyle-Width="65px"   >
                                                           <HeaderStyle  CssClass="Header2" />
                                                        <ItemStyle  CssClass="Item2" />
                                                        </asp:BoundField>

                                                         <asp:BoundField DataField="TipoPedido" HeaderText="Tipo"   ItemStyle-Width="50px" >
                                                           <HeaderStyle  CssClass="Header2" />
                                                        <ItemStyle CssClass="Item2" />
                                                        </asp:BoundField>

                                                        <asp:BoundField DataField="Local" HeaderText="Local Entrega"   ItemStyle-Width="80px" >
                                                           <HeaderStyle  CssClass="Header2" />
                                                        <ItemStyle CssClass="Item2" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Proyecto" HeaderText="Proyecto"   ItemStyle-Width="80px" >
                                                           <HeaderStyle  CssClass="Header2" />
                                                        <ItemStyle CssClass="Item2" />
                                                        </asp:BoundField>

                                                        <asp:BoundField DataField="Proveedor" HeaderText="Proveedor"   ItemStyle-Width="200px" >
                                                           <HeaderStyle  CssClass="Header2" />
                                                        <ItemStyle CssClass="Item2" />
                                                        </asp:BoundField>

                                                        
                                                        <asp:BoundField DataField="FechaEntrega" HeaderText="FechaEntrega"   ItemStyle-Width="100px" >
                                                           <HeaderStyle  CssClass="Header2" />
                                                        <ItemStyle CssClass="Item2" />
                                                        </asp:BoundField>

                                                        <asp:BoundField DataField="Estado" HeaderText="Estado"   ItemStyle-Width="180px" >
                                                           <HeaderStyle  CssClass="Header2" />
                                                        <ItemStyle CssClass="Item2" />
                                                        </asp:BoundField>

                                                         <asp:TemplateField  HeaderText=""  ItemStyle-CssClass="alingRowButons" ItemStyle-Width="80px" >
                                                        <ItemTemplate>
                                                           <asp:LinkButton runat="server" Text="Recepcionar"  ID="lkbtnRecepcion" OnClick="lkbtnRecepcion_Click" OnClientClick="popitup('WFRecepcionPreview.aspx')"></asp:LinkButton>
                                                        </ItemTemplate>
                                                         <HeaderStyle  CssClass="Header2" />
                                                         <ItemStyle  CssClass="Item2"></ItemStyle>
                                                        </asp:TemplateField>

                                                    </Columns>
                                                </asp:GridView>

                                             </div>

                                         </td>
                                            
                                     </tr>

                    </table>
                    <div style="display:none">
                        <asp:Button runat="server"  ID="btnUpdateGrid"  OnClick="btnUpdateGrid_Click"/>
                    </div>
              </asp:Panel>
        </ContentTemplate>
      </asp:UpdatePanel>
    </div>

</asp:Content>

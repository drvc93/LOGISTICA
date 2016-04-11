<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WFPedidoDetalle.aspx.cs" Inherits="WSLogis.Aprobaciones.WFPedidoDetalle" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../Content/Site.css" rel="stylesheet" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script>
       
        function refreshParent() {
            
            window.close();

        }
    </script>
    <script type = "text/javascript">



        function Confirm(estado) {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("¿Desea "+estado+" el pedido?")) {
                confirm_value.value = "Si";
                window.opener.location.reload();
                window.close();
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }
    </script>
    <link href="../Styles/jquery.jnotify.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery-1.4.2.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery.jnotify.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server"></asp:ScriptManager>
    <div>
      <div id="modal2" style ="width:450px; background-color:white; border:1px solid ">
       <asp:Panel  Height="100%" Width="100%" CssClass=" modalBG" runat="server" ID="panel2" ViewStateMode="Enabled" EnableViewState="true" > 
        <asp:UpdatePanel  runat="server" ID="UpdatePanel2" >
            <Triggers > <asp:AsyncPostBackTrigger  ControlID="lkbtnRechazarPed"  EventName="Click"/></Triggers>
            <ContentTemplate>

                <table style="width:100%; height:50%;  text-align:left;"  >
                  
                    <tr>
                        <td colspan="2"  style="background-color:#FFCC00; text-align:center; font-weight:bold;">
                           <asp:Label runat="server" Text="Detalle Pedido" CssClass="tittleclass2"></asp:Label>
                        </td>
                    </tr>

                      
                          <tr>
                        <td  style="text-align: left;  " >
                          <div style="margin-left:10px;">
                              <asp:Label runat="server" Text=" IDPedido: " CssClass="labelCss"></asp:Label>
                        
                              
                            <asp:Label runat="server" Text="--" ID="lblCodPedido" CssClass="font-bold"></asp:Label>
                              </div>
                        </td>
                       

                    
                        <td   style="text-align:left;" >
                            <div style="margin-left:10px;">
                            <asp:Label runat="server" Text="Moneda: " CssClass="labelCss"></asp:Label>
                        
                            
                            <asp:Label runat="server" Text="--" ID="lblMoneda"></asp:Label>
                           </div>
                        </td>
                        </tr>
                    <tr>
                         <td  style="text-align:left;" >
                             <div style="margin-left:10px;">
                             <asp:Label runat="server" CssClass="labelCss" Text="Proyecto: "></asp:Label>
                         
                             <asp:Label CssClass="font-bold" ID="lblProyecto" runat="server" Text="--"></asp:Label>
                                 </div>
                         </td>
                    
                        <td  style="text-align:left;">
                          <div style="margin-left:10px;">
                              <asp:Label runat="server" CssClass="labelCss" Text="Descripcion: "></asp:Label>
                       
                            <asp:Label CssClass="font-bold" ID="lblDescripcion" runat="server"   Text="--"></asp:Label>
                              </div>
                        </td>
                        
                    </tr>
                    <tr>
                        <td  style="text-align:left;" >
                            <div style="margin-left:10px;">
                            <asp:Label runat="server" CssClass="labelCss" Text="Tipo: "></asp:Label>
                       
                            <asp:Label CssClass="font-bold" ID="lblTipoBien" runat="server" Text="--"></asp:Label>
                                </div>
                        </td>
                    </tr>
                     <tr>

                            <td colspan="2">
                                <div>
                                    <asp:GridView ID="GridDetallePedido" runat="server" AutoGenerateColumns="False" DataKeyNames="IdDetallePedido" ViewStateMode="Enabled" Width="440px">
                                        <Columns>
                                            <asp:BoundField DataField="IdDetallePedido" HeaderText="" Visible="false">
                                            <HeaderStyle BackColor="#FFFFCC" />
                                            <ItemStyle Font-Size="Larger" />
                                            </asp:BoundField>
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
                            <tr id="tdBotenesDetalle" runat="server">
                                <td colspan="2" style="text-align:center;">
                                    <div style="position:relative; text-align:center;">
                                        <style>.lkbtns{ margin-left:8px;}</style>
                                        &nbsp;&nbsp;<asp:LinkButton runat="server" ID="lkbtnAprobarPedido" CssClass="lkbtns" Text="Aprobar"   OnClick="lkbtnAprobarPedido_Click" OnClientClick="Confirm('Aprobar')" ></asp:LinkButton>
                                        <asp:LinkButton runat="server" CssClass="lkbtns" Text="Rechazar" ID="lkbtnRechazarPed" OnClick="lkbtnRechazarPed_Click" ></asp:LinkButton>
                                        <asp:LinkButton ID="lkbtnCancel" runat="server" CssClass="lkbtns" Text="Cerrar" OnClientClick="refreshParent()" ></asp:LinkButton>
                                    </div>
                                </td>
                            </tr>
                         
                       <tr runat="server" id="razTexttBox">
                           
                            <td colspan="2">
                                <h5 style="text-align:center; color:black;font-weight:bold;" > Razon de rechazo :</h5>
                                <div id="divrazon" runat="server" style="text-align:center;margin-top:5px;" >
                                  
                                    <asp:TextBox runat="server" ID="txtComentario" CssClass="textbox1"  TextMode="MultiLine" Height="40px" Width="200px"></asp:TextBox>

                                </div>

                            </td>
                        </tr>
                    <tr runat="server" id="razBotones">
                        <td colspan="2" style="text-align:center;">
                            <asp:LinkButton runat="server" CssClass="lkbtns" Text="Aceptar" ID="lkbtnAcepRazon"  OnClick="lkbtnAcepRazon_Click"  OnClientClick="Confirm('rechazar')"  ></asp:LinkButton>
                             <asp:LinkButton runat="server" CssClass="lkbtns" Text="Cancelar" ID="lkbtnCancelRazon" OnClick="lkbtnCancelRazon_Click" ></asp:LinkButton>
                        </td>
                    </tr>

                </table>
              
             
            </ContentTemplate>

        </asp:UpdatePanel>

       </asp:Panel>

    </div>

    </div>
    </form>
</body>
</html>

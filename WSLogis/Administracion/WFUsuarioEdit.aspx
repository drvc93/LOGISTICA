<%@   Page Language="C#" AutoEventWireup="true" CodeBehind="WFUsuarioEdit.aspx.cs" Inherits="WSLogis.Administracion.WFUsuarioEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../Content/Site.css" rel="stylesheet" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="../Styles/jquery.jnotify.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery-1.4.2.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery.jnotify.js" type="text/javascript"></script>
     <script>
         window.onunload = refreshParent;
    function refreshParent() {
        window.opener.location.reload();
        
    }
    </script>

    <script>
       
        function ClosePopup() {
            
            window.close();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
   
    <asp:ScriptManager runat="server"></asp:ScriptManager>
  <div    id="PopEdit1" style="width:450px;border-radius:initial;border-style:solid; border-color:transparent; text-align:center;" class="borderForm">
      
    <asp:Panel  Height="100%" Width="450px" CssClass=" modalBG" runat="server" ID="panel1" ViewStateMode="Enabled" EnableViewState="true" > 
        <asp:UpdatePanel   runat="server"  ID="uppanel1" > 
            <Triggers>
                <asp:AsyncPostBackTrigger  ControlID="lkbtnGrabar" EventName="Click"/>
                  <asp:AsyncPostBackTrigger  ControlID="lkbtnCerrar" EventName="Click"/>
            </Triggers>
            <ContentTemplate   > 
                <div runat="server" >
        
            <table style="width:450px; height:50%;"  >
                <tr>
                    <td colspan="2"  style="padding-bottom:15px; background-color:#F6BE00;text-align:center;font-weight:bold;  " > <asp:Label runat="server"   ID="titlePopup"  Text="Editar Usuario"  CssClass=" tittleclass"></asp:Label>
                </td>

               </tr>
                <tr>
                    <td class=" tdIzq" ><asp:Label runat="server" ID="labelCategoria"  Text="Local"></asp:Label></td>
                    <td class="tdDerecha">
                       <asp:DropDownList ID="ddLocal"  CssClass="textbox1" runat ="server"  Width="180px"   ViewStateMode="Enabled" EnableViewState="true" AutoPostBack="true" > </asp:DropDownList>

                    </td>

                </tr>

                <tr>
                    <td class="tdIzq" ><asp:Label runat="server" ID="label1" CssClass="labelCss" Text="Login"></asp:Label></td>
                    <td class="tdDerecha">
                      <asp:TextBox CssClass="textbox1" ToolTip="Nombre" runat="server" ID="txtLogin"    Width="180px"  ></asp:TextBox>

                    </td>
                </tr>

                 <tr>
                    <td class="tdIzq" ><asp:Label runat="server" ID="label5" CssClass="labelCss" Text="Nombres "></asp:Label></td>
                    <td class="tdDerecha">
                      <asp:TextBox CssClass="textbox1" ToolTip="Nombre" runat="server" ID="txtNombre"  Width="180px"   ></asp:TextBox>

                    </td>
                </tr>

                <tr>
                    <td class="tdIzq" ><asp:Label runat="server" ID="label6" CssClass="labelCss" Text="Iniciales"></asp:Label></td>
                    <td class="tdDerecha">
                      <asp:TextBox CssClass="textbox1" runat="server" ID="txtIniciales" Width="180px" ></asp:TextBox >
                    

                    </td>
                </tr>

                 <tr>
                    <td class="tdIzq" ><asp:Label runat="server" ID="label2" CssClass="labelCss" Text="Cargo"></asp:Label></td>
                    <td class="tdDerecha">
                       <asp:DropDownList ID="ddlCargo"  CssClass=" textbox1" runat ="server" AutoPostBack="true" Width="180px"> </asp:DropDownList>

                    </td>

                </tr>

                  <tr>
                    <td class="tdIzq" ><asp:Label runat="server" ID="label7" CssClass="labelCss" Text="Correo"></asp:Label></td>
                    <td class="tdDerecha">
                      <asp:TextBox CssClass=" textbox1" runat="server" ID="txtCorreo" TextMode="Email"  Width="180px" >   </asp:TextBox>
                                    
                    </td>
                </tr>

            
                <tr>
                    <td class="tdIzq" ><asp:Label runat="server" ID="label13" CssClass="labelCss" Text="Estado"></asp:Label></td>
                    <td class="tdDerecha">
                     <asp:CheckBox runat="server"  ID="checkEstado" CssClass="rbtnMargin" Text=" "/>

                    </td>
                </tr>

           

               <tr>  
                   <td  colspan="2"   style="align-content:center;text-align:center" >
               
                <div style="text-align:center;margin-bottom:5%"> 
                        <div style="margin-left:40%;  float:left;">
                            <asp:LinkButton  ID="lkbtnGrabar" runat="server" Text="Grabar" OnClick="lkbtnGrabar_Click" OnClientClick="refreshParent()"></asp:LinkButton>
                        </div>
                     <div style="margin-left:5%;  float:left;">
                         <asp:LinkButton  runat="server"  ID="lkbtnCerrar" Text="Cerrar" OnClientClick="ClosePopup()"></asp:LinkButton>
                     </div>

                </div>  
                    
                    </td>

               </tr>
                </table>
           
            </div>

               </ContentTemplate> </asp:UpdatePanel>
         
   </asp:Panel> 
           
       </div>


   
    </form>
</body>
</html>

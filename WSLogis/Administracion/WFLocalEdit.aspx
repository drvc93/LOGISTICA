<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WFLocalEdit.aspx.cs" Inherits="WSLogis.Administracion.WFLocalEdit" %>

<!DOCTYPE html>

    <script>
    window.onunload = refreshParent;
    function refreshParent() {
        window.opener.location.reload();
        
    }
    </script>

    <script>
      //  window.onunload = refreshParent;
        function ClosePopup() {
            
            window.close();
        }
    </script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../Content/Site.css" rel="stylesheet" />

    <link href="../Styles/jquery.jnotify.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery-1.4.2.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery.jnotify.js" type="text/javascript"></script>

<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server"></asp:ScriptManager>
    <div id="PopEdit1" style="width:500px; border-radius: initial; border-style: solid;border-color:transparent;" class="borderForm">

            <asp:Panel Height="100%" Width="100%" CssClass=" modalBG" runat="server" ID="panel1" ViewStateMode="Enabled" EnableViewState="true">
                <asp:UpdatePanel runat="server"  ID="uppanel1">
                  <Triggers>
                      <asp:AsyncPostBackTrigger  ControlID="lkbtnGrabar" EventName="Click" />
                         <asp:AsyncPostBackTrigger  ControlID="lkbtnCancelEdit" EventName="Click" />
                  </Triggers>

                    <ContentTemplate>
                        <div runat="server" style="align-content:center;text-align:center;">

                            <table style="width: 100%; height: 50%;">
                                <tr>
                                    <td colspan="2" style="padding-bottom: 5px; background-color: #F6BE00 ; text-align:center;font-weight:bold;">
                                        <asp:Label runat="server" ID="titlePopup" Text="Editar Local" CssClass=" tittleclass"></asp:Label>
                                    </td>

                                </tr>
                                <tr>
                                    <td class=" tdIzq">
                                        <asp:Label runat="server" ID="labelCategoria" CssClass="labelCss" Text="Empresa: "></asp:Label></td>
                                    <td class="tdDerecha">
                                        <asp:DropDownList ID="ddlEmpresa" runat="server" ViewStateMode="Enabled" EnableViewState="true" AutoPostBack="true" Width="150px">
                                        </asp:DropDownList>

                                    </td>

                                </tr>


                                <tr>
                                    <td class="tdIzq">
                                        <asp:Label runat="server" ID="label5" CssClass="labelCss" Text="Nombre: "></asp:Label></td>
                                    <td class="tdDerecha">
                                        <asp:TextBox CssClass=" textbox1" ToolTip="Nombre" runat="server" ID="txtNombre" Width="230px"></asp:TextBox>

                                    </td>
                                </tr>

                                <tr>
                                    <td class="tdIzq">
                                        <asp:Label runat="server" ID="label6" CssClass="labelCss" Text="Descripcion: "></asp:Label></td>
                                    <td class="tdDerecha">
                                        <asp:TextBox CssClass=" textbox1" Width="230px" Height="40px" runat="server" ID="txtDescripcion" TextMode="MultiLine"></asp:TextBox>


                                    </td>
                                </tr>
                                <tr>
                                    <td class="tdIzq">
                                        <asp:Label runat="server" ID="label2" CssClass="labelCss" Text="Direccion: "></asp:Label></td>
                                    <td class="tdDerecha">
                                        <asp:TextBox CssClass=" textbox1" Width="230px" runat="server" ID="txtDireccion"></asp:TextBox>
                                    </td>

                                </tr>
                                <tr>
                                    <td class="tdIzq">
                                        <asp:Label runat="server" ID="label1" CssClass="labelCss" Text="Distrito: "></asp:Label></td>
                                    <td class="tdDerecha">
                                        <asp:TextBox Width="230px" CssClass=" textbox1" runat="server" ID="txtDistrito"></asp:TextBox>
                                    </td>

                                </tr>






                                <tr>
                                    <td class="tdIzq">
                                        <asp:Label runat="server" ID="label12" CssClass="labelCss" Text="Telefono: "></asp:Label></td>
                                    <td class="tdDerecha">
                                        <asp:TextBox Width="230px" CssClass=" textbox1" runat="server" ID="txtTelefono"></asp:TextBox>

                                    </td>
                                </tr>

                                <tr>
                                    <td class="tdIzq">
                                        <asp:Label runat="server" ID="label13" CssClass="labelCss" Text="Estatus"></asp:Label></td>
                                    <td class="tdDerecha">
                                        <asp:CheckBox runat="server" ID="chckEstatus" Text=" " />

                                    </td>
                                </tr>



                                <tr>
                                    <td colspan="2" style="align-content: center; text-align: center"></td>

                                </tr>
                            </table>

                        </div>

                    </ContentTemplate>
                </asp:UpdatePanel>
               

                <div style="text-align: center; margin-bottom: 5%">
                    <div style="float:left; margin-left:40%">
                         <asp:LinkButton runat="server" ID="lkbtnGrabar"  Text="Grabar" OnClientClick="refreshParent()" OnClick="lkbtnGrabar_Click" ></asp:LinkButton>
                    </div>
                     <div style="float:left; margin-left:5%">
                         <asp:LinkButton runat="server" ID="lkbtnCancelEdit" Text="Cerrar"      OnClientClick=" ClosePopup()"  ></asp:LinkButton>
                    </div>

                </div>
            </asp:Panel>

        </div>
    </form>
</body>
</html>

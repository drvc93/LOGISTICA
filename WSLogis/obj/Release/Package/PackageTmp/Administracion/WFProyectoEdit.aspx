<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WFProyectoEdit.aspx.cs" Inherits="WSLogis.Administracion.WFProyectoEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../Content/Site.css" rel="stylesheet" />
    <link href="../Styles/jquery.jnotify.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery-1.4.2.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery.jnotify.js" type="text/javascript"></script>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

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


</head>
<body>
    <form id="form1" runat="server" style="text-align: center; align-content: center;">
        <asp:ScriptManager runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="false"></asp:ScriptManager>
        <div id="PopEdit1" style="width: 450px; border-radius: initial; border-style: solid; background-color: white; border-color: transparent;" class="borderForm">

            <asp:Panel Height="100%" Width="100%" CssClass=" modalBG" runat="server" ID="panel1" ViewStateMode="Enabled" EnableViewState="true">
                <asp:UpdatePanel runat="server" ID="uppanel1">
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="lkbtnGrabar" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="lkbtnCancelP" EventName="Click" />
                    </Triggers>

                    <ContentTemplate>
                        <div runat="server" style="background-color: white; text-align: center;">

                            <table style="width: 100%; height: 50%;">
                                <tr>
                                    <td colspan="2" style="padding-bottom: 15px; background-color: #F6BE00; text-align: center; font-weight: bold;">
                                        <asp:Label runat="server" ID="titlePopup" Text="Editar Proyecto"></asp:Label>
                                    </td>

                                </tr>
                                <tr>
                                    <td class=" tdIzq">
                                        <asp:Label runat="server" ID="labelCategoria" CssClass="labelCss" Text="Grupo: "></asp:Label></td>
                                    <td class="tdDerecha">
                                        <asp:DropDownList ID="ddlGrupoPoryecto" CssClass=" textbox1" runat="server" AutoPostBack="true">
                                        </asp:DropDownList>

                                    </td>

                                </tr>


                                <tr>
                                    <td class="tdIzq">
                                        <asp:Label runat="server" ID="label5" Text="Nombre: "></asp:Label></td>
                                    <td class="tdDerecha">
                                        <asp:TextBox CssClass=" textbox1" ToolTip="Nombre" runat="server" ID="txtNombre"></asp:TextBox>

                                    </td>
                                </tr>

                                <tr>
                                    <td class="tdIzq">
                                        <asp:Label runat="server" ID="label6" CssClass="labelCss" Text="Descripcion: "></asp:Label></td>
                                    <td class="tdDerecha">
                                        <asp:TextBox Width="200px" Height="40px" CssClass=" textbox1" runat="server" ID="txtDescripcion" TextMode="MultiLine"></asp:TextBox>


                                    </td>
                                </tr>
                                <tr>
                                    <td class="tdIzq">
                                        <asp:Label runat="server" ID="label2" CssClass="labelCss" Text="Fecha Inicio: "></asp:Label></td>
                                    <td class="tdDerecha">
                                        <asp:TextBox CssClass=" textbox1" runat="server" ID="txtFechaInicio"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender runat="server" TargetControlID="txtFechaInicio" Format="dd/MM/yyyy" />
                                    </td>

                                </tr>
                                <tr>
                                    <td class="tdIzq">
                                        <asp:Label runat="server" ID="label1" CssClass="labelCss" Text="Fecha Fin: "></asp:Label></td>
                                    <td class="tdDerecha">
                                        <asp:TextBox CssClass=" textbox1" runat="server" ID="txtFechaFin"></asp:TextBox><ajaxToolkit:CalendarExtender runat="server" Format="dd/MM/yyyy" TargetControlID="txtFechaFin" />
                                    </td>

                                </tr>








                                <tr>
                                    <td class="tdIzq">
                                        <asp:Label runat="server" ID="label13" CssClass="labelCss" Text="Estado: "></asp:Label></td>
                                    <td class="tdDerecha">
                                        <asp:CheckBox runat="server" ID="chckEstado" Text=" " />

                                    </td>
                                </tr>



                                <tr>
                                    <td colspan="2" style="align-content: center; text-align: center"></td>

                                </tr>
                                <tr>
                                    <td colspan="2">

                                        <div style="text-align: center; margin-bottom: 5%">
                                            <div style="float: left; margin-left: 40%">
                                                <asp:LinkButton runat="server" Text="Grabar" ID="lkbtnGrabar" OnClientClick="refreshParent()" OnClick="lkbtnGrabar_Click"> </asp:LinkButton>
                                            </div>
                                            <div style="float: left; margin-left: 5%">
                                                <asp:LinkButton runat="server" Text="Cerrar" ID="lkbtnCancelP" OnClientClick="ClosePopup()"> </asp:LinkButton>
                                            </div>

                                        </div>
                                    </td>
                                </tr>

                            </table>

                        </div>

                    </ContentTemplate>
                </asp:UpdatePanel>


            </asp:Panel>

        </div>
    </form>
</body>
</html>

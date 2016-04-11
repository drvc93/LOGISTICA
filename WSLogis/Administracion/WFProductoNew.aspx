<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WFProductoNew.aspx.cs" Inherits="WSLogis.Administracion.WFProductoNew" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

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
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../Content/Site.css" rel="stylesheet" />
    <link href="../Styles/jquery.jnotify.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery-1.4.2.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery.jnotify.js" type="text/javascript"></script>
    <script src="../Scripts/SoloNumeros.js"></script>
</head>
<body style="height: 90%; text-align: center;">

    <form id="form1" runat="server">
        <asp:ScriptManager runat="server"></asp:ScriptManager>
        <div id="PopEdit1" style="width: 100%; border-radius: initial; border-style: solid; border-color: transparent;" class="borderForm">

            <asp:Panel Height="100%" Width="100%" CssClass=" modalBG" runat="server" ID="panel1" ViewStateMode="Enabled" EnableViewState="true">
                <asp:UpdatePanel runat="server" ID="uppanel1">
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="lkbtnCancel" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="lkbtnGrabar" EventName="Click" />
                    </Triggers>
                    <ContentTemplate>
                        <div runat="server" style="text-align: center;">
                            <div style="text-align: center; font-weight: bold; width: 100%; background-color: #F6BE00; margin-bottom: 10px;">
                                <td colspan="2" style="text-align: center; font-weight: bold; padding-bottom: 15px; background-color: #F6BE00;">
                                    <asp:Label runat="server" ID="titlePopup" Text="Registro Bienes / Servicios"></asp:Label>
                            </div>
                            <table style="width: 100%; height: 50%; table-layout: fixed; max-width: 500px; min-width: 340px;">

                                <tr>
                                    <td style="text-align: right;" class="auto-style1">
                                        <asp:Label runat="server" ID="labelCategoria" CssClass="TitulitosSub" Text="Categoria"></asp:Label></td>
                                    <td class="tdDerecha">
                                        <asp:DropDownList ID="ddlCategoria" CssClass="textbox1" runat="server" ViewStateMode="Enabled" EnableViewState="true" AutoPostBack="true" Width="150px" OnSelectedIndexChanged="ddlCategoria_SelectedIndexChanged"></asp:DropDownList>

                                    </td>

                                </tr>

                                <tr>
                                    <td style="text-align: right" class="auto-style1">
                                        <asp:Label runat="server" ID="label1" CssClass="TitulitosSub" Text="Sub Categoria "></asp:Label></td>
                                    <td class=" tdDerecha">
                                        <asp:DropDownList ID="ddSubCategoria" AutoPostBack="true" CssClass="textbox1" runat="server" Width="150px">
                                        </asp:DropDownList>

                                    </td>

                                </tr>

                                <tr>
                                    <td style="text-align: right" class="auto-style1">
                                        <asp:Label runat="server" ID="label2" CssClass="TitulitosSub" Text="Presentacion"></asp:Label></td>
                                    <td class="tdDerecha">
                                        <asp:DropDownList ID="ddPresentacion" CssClass="textbox1" AutoPostBack="true" runat="server" Width="200px">
                                        </asp:DropDownList>

                                    </td>

                                </tr>

                                <tr>
                                    <td style="text-align: right" class="auto-style1">
                                        <asp:Label runat="server" ID="label3" CssClass="TitulitosSub" Text="Concentración"></asp:Label></td>
                                    <td class="tdDerecha">
                                        <asp:DropDownList ID="ddConcentracion" CssClass="textbox1" AutoPostBack="true" runat="server" Width="200px">
                                        </asp:DropDownList>

                                    </td>

                                </tr>

                                <tr>
                                    <td style="text-align: right" class="auto-style1">
                                        <asp:Label runat="server" ID="label4" CssClass="TitulitosSub" Text="Unid. Medida"></asp:Label></td>
                                    <td class="tdDerecha">
                                        <asp:DropDownList AutoPostBack="true" ID="ddUnidadMedida" CssClass="textbox1" runat="server" Width="200px">
                                        </asp:DropDownList>

                                    </td>
                                </tr>

                                <tr>
                                    <td style="text-align: right" class="auto-style1">
                                        <asp:Label runat="server" ID="label5" CssClass="TitulitosSub" Text="Nombre"></asp:Label></td>
                                    <td class="tdDerecha">
                                        <asp:TextBox CssClass="textbox1" ToolTip="Nombre" runat="server" ID="txtNombre" Width="150px"></asp:TextBox>

                                    </td>
                                </tr>

                                <tr>
                                    <td style="text-align: right" class="auto-style1">
                                        <asp:Label runat="server" ID="label6" CssClass="TitulitosSub" Text="Descripcion"></asp:Label></td>
                                    <td class="tdDerecha">
                                        <asp:TextBox CssClass="textbox1" runat="server" ID="txtDescripcion" TextMode="MultiLine" Height="50px" Width="200px"></asp:TextBox>


                                    </td>
                                </tr>

                                <tr>
                                    <td style="text-align: right" class="auto-style1">
                                        <asp:Label runat="server" ID="label7" CssClass="TitulitosSub" Text="Stock Minimo"></asp:Label></td>
                                    <td class="tdDerecha">
                                        <asp:TextBox onkeypress='return validateQty(this, event);' CssClass="textbox1" runat="server" ID="txtStockMin" TextMode="Number" Width="50px"></asp:TextBox>



                                    </td>
                                </tr>

                                <tr>
                                    <td style="text-align: right" class="auto-style1">
                                        <asp:Label runat="server" ID="label8" CssClass="TitulitosSub" Text="Tipo"></asp:Label></td>
                                    <td class="tdDerecha">
                                        <asp:RadioButtonList ID="rbtTipoPedido" runat="server" RepeatDirection="Horizontal">
                                            <asp:ListItem Selected="True" Value="1">Bienes</asp:ListItem>
                                            <asp:ListItem Value="2">Servicio</asp:ListItem>
                                        </asp:RadioButtonList>

                                    </td>
                                </tr>

                                <tr>
                                    <td style="text-align: right" class="auto-style1">
                                        <asp:Label runat="server" ID="label9" CssClass="TitulitosSub" Text="Expira"></asp:Label></td>
                                    <td class="tdDerecha">
                                        <asp:CheckBox runat="server" ID="checkExpira" Text=" " />

                                    </td>
                                </tr>

                                <tr>
                                    <td style="text-align: right" class="auto-style1">
                                        <asp:Label runat="server" ID="label10" CssClass="TitulitosSub" Text="Imagen 1"></asp:Label></td>
                                    <td class="tdDerecha">
                                        <asp:FileUpload ID="fileUp1" runat="server" CssClass="textbox1" Width="250px" onchange="PreviewImg(this)" />
                                        <div id="newPreview" runat="server"></div>
                                    </td>
                                </tr>


                                <tr>
                                    <td style="text-align: right" class="auto-style1">
                                        <asp:Label runat="server" ID="label11" CssClass="TitulitosSub" Text="Imagen 2"></asp:Label></td>
                                    <td class="tdDerecha">
                                        <asp:FileUpload ID="fileUp2" runat="server" CssClass="textbox1" Width="250px" />

                                    </td>
                                </tr>

                                <tr>
                                    <td style="text-align: right" class="auto-style1">
                                        <asp:Label runat="server" ID="label12" CssClass="TitulitosSub" Text="Imagen 3"></asp:Label></td>
                                    <td class="tdDerecha">
                                        <asp:FileUpload ID="fileUp3" runat="server" CssClass="textbox1" Width="250px" />

                                    </td>
                                </tr>

                                <tr>
                                    <td style="text-align: right" class="auto-style1">
                                        <asp:Label runat="server" ID="label13" CssClass="TitulitosSub" Text="Estado"></asp:Label></td>
                                    <td class="tdDerecha">
                                        <asp:CheckBox runat="server" ID="checkEstado" Text=" " />

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
                    <asp:LinkButton runat="server" ID="lkbtnGrabar" Text="Grabar" OnClick="lkbtnGrabar_Click" OnClientClick="refreshParent()"></asp:LinkButton>
                    <asp:LinkButton runat="server" ID="lkbtnCancel" Text="Cerrar" CssClass="lkbtnSpace" OnClientClick="ClosePopup()"></asp:LinkButton>
                </div>
            </asp:Panel>

        </div>


    </form>
</body>
</html>

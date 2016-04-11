<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WFAgregarDetallePedido.aspx.cs" Inherits="WSLogis.Administracion.WFAgregarDetallePedido" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <link href="../Styles/jquery.jnotify.css" rel="stylesheet" />
    <script src="../Scripts/jquery-1.4.2.min.js"></script>
    <script src="../Scripts/jquery.jnotify.js"></script>
    <link href="../Content/Site.css" rel="stylesheet" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script>
        window.onunload = refreshParent;
        function Close() {

            window.close();

        }
    </script>
    <script>
        function refreshGridParent() {
            window.opener.RefreshGrid();
            window.close();

        };

    </script>

    <script>
        function validateQty(el, evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode != 45 && charCode != 8 && (charCode != 46) && (charCode < 48 || charCode > 57))
                return false;
            if (charCode == 46) {
                if ((el.value) && (el.value.indexOf('.') >= 0))
                    return false;
                else
                    return true;
            }
            return true;
            var charCode = (evt.which) ? evt.which : event.keyCode;
            var number = evt.value.split('.');
            if (charCode != 46 && charCode > 31 && (charCode < 48 || charCode > 57)) {
                return false;
            }
        };

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server"></asp:ScriptManager>
        <div>

            <div id="PopEdit1" style="width: 1000px;">

                <asp:Panel Height="100%" Width="800px" CssClass=" modalBG" runat="server" ID="panel1" ViewStateMode="Enabled" EnableViewState="true">
                    <asp:UpdatePanel runat="server" ID="uppanel1">
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="ddlCategoria" EventName="SelectedIndexChanged" />
                            <asp:AsyncPostBackTrigger ControlID="lkbtnAgregarProd" EventName="Click" />
                        </Triggers>
                        <ContentTemplate>
                            <div runat="server" style="background-color: white; border: solid 1px">

                                <table style="width: 790px; height: 50%; max-height: 650px; overflow-y: scroll;">
                                    <tr>
                                        <td colspan="2" style="padding-bottom: 15px; background-color: #F6BE00; color: black; font-weight: bold; text-align: center;">
                                            <asp:Label runat="server" ID="titlePopup" Text="Seleccionar Producto"></asp:Label>
                                        </td>

                                    </tr>
                                    <tr>
                                        <td class=" tdIzq">
                                            <asp:Label runat="server" ID="labelCategoria" CssClass=" label" Text="Categoria"></asp:Label></td>
                                        <td class="tdDerecha">
                                            <asp:DropDownList ID="ddlCategoria" CssClass=" textbox1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCategoria_SelectedIndexChanged"></asp:DropDownList>

                                        </td>

                                    </tr>

                                    <tr>
                                        <td class="tdIzq">
                                            <asp:Label runat="server" ID="label2" CssClass="label" Text="Sub Categoria"></asp:Label></td>
                                        <td class="tdDerecha">
                                            <asp:DropDownList ID="ddlSubCategoria" CssClass=" textbox1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlSubCategoria_SelectedIndexChanged"></asp:DropDownList>

                                        </td>

                                    </tr>

                                    <tr>
                                        <td class=" tdIzq">
                                            <asp:Label runat="server" ID="label7" CssClass="label" Text="Descripcion"></asp:Label></td>
                                        <td class="tdDerecha">
                                            <asp:TextBox CssClass=" textbox1" runat="server" OnTextChanged="txtDescripBuscar_TextChanged" ID="txtDescripBuscar" AutoPostBack="true" Width="220">   </asp:TextBox>

                                        </td>
                                    </tr>

                                    <tr>
                                        <td colspan="2" style="align-content: center; text-align: center;">
                                            <div runat="server" style="width: auto; height: 300px; overflow: auto; margin-left: 5px; margin-right: 5px;">
                                                <asp:GridView   PageSize="10" AllowPaging="true"  OnPageIndexChanging="GridSelectItems_PageIndexChanging"  ID="GridSelectItems" runat="server" EmptyDataText="No se encontro resultados" CssClass=" Grilla2" AutoGenerateColumns="false" ViewStateMode="Enabled" DataKeyNames="CodigoProducto" Width="100%">
                                                    <Columns>
                                                        <asp:BoundField DataField="CodigoProducto" HeaderText="CodigoProducto" Visible="false">
                                                            <HeaderStyle BackColor="#FFFFCC" />
                                                            <ItemStyle  Font-Bold="True" Font-Size="Larger" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Descripcion" HeaderText="Descripción" ItemStyle-Width="350px">
                                                            <HeaderStyle CssClass="Header2" />
                                                            <ItemStyle HorizontalAlign="Left"  CssClass="Item2" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="UnidadMedida" HeaderText="Uni.Medida" ItemStyle-Width="120px">
                                                            <HeaderStyle CssClass="Header2" />
                                                            <ItemStyle CssClass="Item2" />
                                                        </asp:BoundField>
                                                        <asp:TemplateField ItemStyle-Width="55px" HeaderText="Precio Referencial" ItemStyle-CssClass="alingRowButons">
                                                            <ItemTemplate>
                                                                <asp:TextBox runat="server" Text='<%#Eval("Precio") %>' ID="txtRowPrecioPopUp" CssClass=" textbox1" Width="50px" onkeypress='return validateQty(this, event);'></asp:TextBox>
                                                            </ItemTemplate>
                                                            <HeaderStyle CssClass="Header2" />
                                                            <ItemStyle CssClass="Item2"></ItemStyle>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Cantidad" ItemStyle-Width="55px" ItemStyle-CssClass="alingRowButons">
                                                            <ItemTemplate>
                                                                <asp:TextBox runat="server" ID="txtRowCantidadPopUp" Text='<%#Eval("Cantidad") %>'  CssClass=" textbox1" AutoPostBack="true" TextMode="Number" Width="40px" OnTextChanged="txtRowCantidadPopUp_TextChanged" onkeypress="return validateQty(this, event);"></asp:TextBox>
                                                            </ItemTemplate>
                                                            <HeaderStyle CssClass="Header2" />
                                                            <ItemStyle CssClass=" Item2"></ItemStyle>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField ItemStyle-Width="20px"  HeaderText="" ItemStyle-CssClass="alingRowButons">
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="checkCantidadRowPopUp" AutoPostBack="true" OnCheckedChanged="checkCantidadRowPopUp_CheckedChanged" runat="server" />
                                                            </ItemTemplate>
                                                            <HeaderStyle CssClass="Header2" />
                                                            <ItemStyle CssClass=" Item2"></ItemStyle>
                                                        </asp:TemplateField>


                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </td>

                                    </tr>
                                    <tr>

                                        <td colspan="2">
                                            <div style="float: left; margin-left: 40%;">
                                                <asp:LinkButton runat="server" Text="Agregar " ID="lkbtnAgregarProd" CssClass=" lkbtnSpace" OnClick="lkbtnAgregarProd_Click"></asp:LinkButton>
                                            </div>
                                            <div style="float: left; margin-left: 5%;">
                                                <asp:LinkButton runat="server" Text="Cerrar" ID="lkbtnCancel" CssClass="lkbtnSpace" OnClientClick="Close()"></asp:LinkButton>
                                            </div>

                                        </td>
                                    </tr>
                                </table>

                            </div>

                        </ContentTemplate>
                    </asp:UpdatePanel>



                </asp:Panel>

            </div>
        </div>
    </form>
</body>
</html>

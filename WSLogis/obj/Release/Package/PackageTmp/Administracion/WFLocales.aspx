<%@ Page Title="Registro de Locales" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WFLocales.aspx.cs" Inherits="WSLogis.Administracion.WFLocales" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

    <script>

        function popitup(url) {
            newwindow = window.open(url, 'Page', 'height=350,width=500,navigationtoolbar=no,toolbar=no,menubar=no,left=150,top=180,resizable=no');/**/
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Styles/jquery.jnotify.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery-1.4.2.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery.jnotify.js" type="text/javascript"></script>



    <div>
        <h2>Buscar Local </h2>
        <asp:ScriptManager runat="server" ID="idScripm2" EnablePartialRendering="true"></asp:ScriptManager>
        <div style="margin-top: 10px">
            <asp:TextBox Width="250px" ID="txtNombreLocal" runat="server" CssClass=" textbox1" OnTextChanged="txtNombreLocal_TextChanged"></asp:TextBox><ajaxToolkit:TextBoxWatermarkExtender WatermarkCssClass="hintText" runat="server" ID="waterMark1" TargetControlID="txtNombreLocal" WatermarkText="Buscar por nombre" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:LinkButton runat="server" ID="lkBtnBuscar" OnClick="btnBuscarLocal_Click" Text="Buscar" CssClass="linkbuttonClass"></asp:LinkButton>
            &nbsp;&nbsp;&nbsp;<asp:LinkButton runat="server" CssClass="linkbuttonClass" Text="Nuevo" ID="lkBtnNuevo" OnClick="btnNuevoLocal_Click" OnClientClick="popitup('WFLocalEdit.aspx')"></asp:LinkButton>
        </div>
        <div>
            <p>
                <asp:UpdatePanel runat="server" UpdateMode="Conditional">
                    <ContentTemplate>


                        <asp:GridView runat="server" ID="GridLocales" AutoGenerateColumns="False" ViewStateMode="Enabled" DataKeyNames="CodigoLocal" CssClass="Grilla2">
                            <Columns>
                                <asp:BoundField DataField="Nomb.Empresa" HeaderText="Nomb.Empresa" HeaderStyle-CssClass="Header2" ItemStyle-CssClass="Item2"></asp:BoundField>

                                <asp:BoundField DataField="CodigoLocal" HeaderText="CodigoLocal" Visible="false"></asp:BoundField>

                                <asp:BoundField DataField="Nombre" HeaderText="Nombre" HeaderStyle-CssClass="Header2" ItemStyle-CssClass="Item2"></asp:BoundField>

                                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" HeaderStyle-CssClass="Header2" ItemStyle-CssClass="Item2"></asp:BoundField>

                                <asp:BoundField DataField="Direccion" HeaderText="Direccion" HeaderStyle-CssClass="Header2" ItemStyle-CssClass="Item2"></asp:BoundField>

                                <asp:BoundField DataField="Distrito" HeaderText="Distrito" HeaderStyle-CssClass="Header2" ItemStyle-CssClass="Item2"></asp:BoundField>

                                <asp:BoundField DataField="Telefono" HeaderText="Telefono" HeaderStyle-CssClass="Header2" ItemStyle-CssClass="Item2"></asp:BoundField>

                                <asp:BoundField DataField="Estado" HeaderText="Estado" HeaderStyle-CssClass="Header2" ItemStyle-CssClass="Item2"></asp:BoundField>

                                <asp:TemplateField HeaderText="" ShowHeader="false" ItemStyle-CssClass=" Item2">
                                    <ItemTemplate>
                                        <asp:LinkButton Text="Editar" runat="server" ID="btnEdiLocal" OnClick="btnEdiLocal_Click" OnClientClick="return popitup('WFLocalEdit.aspx')"></asp:LinkButton>

                                    </ItemTemplate>
                                    <HeaderStyle CssClass="Header2" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="" ShowHeader="false" ItemStyle-CssClass=" Item2">
                                    <ItemTemplate>
                                        <asp:LinkButton Text="Niveles Aprobacion" runat="server" ID="btnAsigNivelesAprob" OnClick="btnAsigNivelesAprob_Click"></asp:LinkButton>

                                    </ItemTemplate>
                                    <HeaderStyle CssClass="Header2" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>

                    </ContentTemplate>

                </asp:UpdatePanel>
            </p>
        </div>
        <asp:Label runat="server" ID="lblResult"></asp:Label>
        <div style="display: none;">
            <asp:Button runat="server" ID="btnShoPopup" />
            <asp:Button runat="server" ID="btnShoPopup2" />
        </div>







        <ajaxToolkit:ModalPopupExtender runat="server" ID="ModalPopUp2" BackgroundCssClass=" popUpModal" TargetControlID="btnShoPopup2" PopupControlID="modal2" DropShadow="true"
            CancelControlID="lkbtnCancel" PopupDragHandleControlID="panel2">
        </ajaxToolkit:ModalPopupExtender>
        <div id="modal2" style="width: 350px;">
            <asp:Panel Height="100%" Width="100%" CssClass=" modalBG" runat="server" ID="panel2" ViewStateMode="Enabled" EnableViewState="true">
                <asp:UpdatePanel runat="server" ID="UpdatePanel2">

                    <ContentTemplate>

                        <table style="width: 100%; height: 50%;">
                            <tr>
                                <td colspan="2" style="background-color: #F5F5F5; text-align: center;">
                                    <asp:Label runat="server" Text="Asignar Niveles de aprobacion" CssClass=" tittleclass2"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <div>
                                        <asp:GridView runat="server" ID="GridNivelesAprobacion" AutoGenerateColumns="False" ViewStateMode="Enabled" DataKeyNames="CodigoNivel" CssClass="Grilla2" Width="100%">
                                            <Columns>
                                                <asp:BoundField DataField="CodigoNivel" HeaderText="CodigoNivel" Visible="false">
                                                    <HeaderStyle BackColor="#FFFFCC" />
                                                    <ItemStyle Font-Bold="True" Font-Size="Larger" />
                                                </asp:BoundField>

                                                <asp:BoundField DataField="Glosa" HeaderText="Descripcion" HeaderStyle-CssClass="Header2" ItemStyle-CssClass="Item2" ItemStyle-HorizontalAlign="Center"></asp:BoundField>

                                                <asp:TemplateField HeaderText="Estado" ShowHeader="false" ItemStyle-CssClass=" Item2" ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:CheckBox runat="server" ID="chkEstadoNivel" />

                                                    </ItemTemplate>
                                                    <HeaderStyle CssClass="Header2" />
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">

                                    <div style="float: left; margin-left: 40%">
                                        <asp:LinkButton runat="server" ID="lkbtnAgregarNivel" Text="Agregar" OnClick="lkbtnAgregarNivel_Click"></asp:LinkButton>
                                    </div>
                                    <div style="float: left; margin-left: 5%">
                                        <asp:LinkButton runat="server" ID="lkbtnCancel" Text="Cancelar" OnClick="lkbtnCancel_Click"></asp:LinkButton>
                                    </div>
                                </td>



                            </tr>

                        </table>
                    </ContentTemplate>

                </asp:UpdatePanel>

            </asp:Panel>

        </div>
    </div>

</asp:Content>

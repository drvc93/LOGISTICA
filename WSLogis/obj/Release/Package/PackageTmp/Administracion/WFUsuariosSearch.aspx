<%@ Page Title="Buscar Usuario" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WFUsuariosSearch.aspx.cs" Inherits="WSLogis.Administracion.WFUsuariosSearch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <script>

        function popitup(url) {
            newwindow = window.open(url, 'name', 'height=300,width=450,navigationtoolbar=no,toolbar=no,menubar=no,left=150,top=180');/**/
        }

        function RefreshUpdatePanel() {
            __doPostBack('<%= txtNombreUsuario.ClientID %>', '');
        };
    </script>

    <link href="../Styles/jquery.jnotify.css" rel="stylesheet" />
    <script src="../Scripts/jquery-1.4.2.min.js"></script>
    <script src="../Scripts/jquery.jnotify.js"></script>



    <link href="../Styles/jquery.jnotify.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery-1.4.2.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery.jnotify.js" type="text/javascript"></script>
    <div style="align-content: center; margin-left: 10%;">
        <h2 style="margin-left: 10px;">Buscar Usuario
        </h2>


        <asp:TextBox runat="server" onkeyup="RefreshUpdatePanel();" CssClass="   textbox1" Width="200px" OnTextChanged="txtNombreUsuario_TextChanged" AutoPostBack="true" ID="txtNombreUsuario"></asp:TextBox>
        <span></span>
        <ajaxToolkit:TextBoxWatermarkExtender WatermarkCssClass="hintText" runat="server" ID="waterMark1" TargetControlID="txtNombreUsuario" WatermarkText="Nombres/Login" />
        <asp:LinkButton runat="server" ID="btnBuscarUsuario" Text="Buscar" CssClass="  lkbtnSpace"></asp:LinkButton>
        <asp:LinkButton runat="server" ID="btnNuevoUsuario" Text="Nuevo" CssClass="  lkbtnSpace" OnClick="btnNuevoUsuario_Click" OnClientClick="popitup('WFUsuarioEdit.aspx')"></asp:LinkButton>
        <p>
            <asp:ScriptManager runat="server" ID="idScripm" EnablePartialRendering="true"></asp:ScriptManager>
            <asp:UpdatePanel ID="updatePGen" runat="server" UpdateMode="Conditional">
                <Triggers>
                    <asp:AsyncPostBackTrigger EventName="TextChanged" ControlID="txtNombreUsuario" />
                </Triggers>
                <ContentTemplate>
                    <asp:GridView ID="gridUsuarios" runat="server" AutoGenerateColumns="False" ViewStateMode="Enabled" Width="600px" DataKeyNames="Codigo" CssClass="Grilla2">
                        <Columns>
                            <asp:BoundField DataField="Local" HeaderText="Local" HeaderStyle-CssClass="Header2" ItemStyle-CssClass="Item2">
                                <ControlStyle Width="50px" />
                                <HeaderStyle />
                                <ItemStyle Font-Bold="False" HorizontalAlign="Center" Width="40px" Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Nombres" HeaderText="Nombres" HeaderStyle-CssClass="Header2" ItemStyle-Wrap="true" ItemStyle-CssClass="Item2">
                                <ControlStyle Width="180px" />
                                <HeaderStyle />
                                <ItemStyle HorizontalAlign="Center" Width="60px" Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="LoginUsuario" HeaderText="LoginUsuario" HeaderStyle-CssClass="Header2" ItemStyle-CssClass="Item2">
                                <ControlStyle Width="50px" />
                                <HeaderStyle />
                                <ItemStyle HorizontalAlign="Center" Width="60px" Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Iniciales" HeaderText="Iniciales" HeaderStyle-CssClass="Header2" ItemStyle-CssClass="Item2">
                                <HeaderStyle />
                                <ItemStyle HorizontalAlign="Center" Width="50px" Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Cargo" HeaderText="Cargo" HeaderStyle-CssClass="Header2" ItemStyle-CssClass="Item2">
                                <HeaderStyle />
                                <ItemStyle HorizontalAlign="Center" Width="100px" Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Estado" HeaderText="Estado" HeaderStyle-CssClass="Header2" ItemStyle-CssClass="Item2">
                                <HeaderStyle />
                                <ItemStyle Font-Bold="False" HorizontalAlign="Center" Width="80px" Wrap="False" />
                            </asp:BoundField>

                            <asp:BoundField DataField="Codigo" HeaderText="Codigo" Visible="false">
                                <HeaderStyle />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="" ShowHeader="false" ItemStyle-CssClass=" Item2">
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" ID="btnEditP" Text="Editar" OnClientClick="popitup('WFUsuarioEdit.aspx')" OnClick="btnEditP_Click"></asp:LinkButton>


                                </ItemTemplate>
                                <HeaderStyle CssClass="Header2" />

                                <ItemStyle CssClass=" Item2" Width="40px" Wrap="False"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="" ShowHeader="false" ItemStyle-CssClass="alingRowButons">
                                <ItemTemplate>

                                    <asp:LinkButton runat="server" ID="btnAsigProyecto" Text="Proyecto" CssClass=" linkbuttonClass" OnClick="btnAsigProyecto_Click"></asp:LinkButton>


                                </ItemTemplate>
                                <HeaderStyle CssClass="Header2" />

                                <ItemStyle CssClass=" Item2" Width="40px"></ItemStyle>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderStyle-CssClass="Header2" HeaderText="" ShowHeader="false" ItemStyle-CssClass="Item2">
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" ID="btnAsigRol" Text="Rol" CssClass=" linkbuttonClass" OnClick="btnAsigRol_Click"></asp:LinkButton>


                                </ItemTemplate>


                                <ItemStyle CssClass="Item2" Width="30px"></ItemStyle>

                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="" ShowHeader="false" ItemStyle-CssClass=" Item2" HeaderStyle-CssClass="Header2">
                                <HeaderStyle CssClass="Header2" />
                                <ItemTemplate>

                                    <asp:LinkButton runat="server" ID="lkbtnVistoB" Text="VB" CssClass=" linkbuttonClass" OnClick="lkbtnVistoB_Click"></asp:LinkButton>
                                </ItemTemplate>


                                <ItemStyle CssClass=" Item2" Width="30px"></ItemStyle>
                            </asp:TemplateField>

                        </Columns>
                    </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>
        </p>

        <asp:Label runat="server" ID="lblResult"></asp:Label>
        <div style="display: none">
            <asp:Button runat="server" ID="btnShoPopup" />
            <asp:Button runat="server" ID="btnShoPopup2" />
            <asp:Button runat="server" ID="btnShoPopup3" />
            <asp:Button runat="server" ID="btnShoPopup4" />
        </div>

        <p></p>

    </div>







    <ajaxToolkit:ModalPopupExtender runat="server" ID="ModalPopUp2" BackgroundCssClass="  hide" TargetControlID="btnShoPopup2" PopupControlID="modal2" DropShadow="true"
        CancelControlID="lkbtnCancel" PopupDragHandleControlID="panel2">
    </ajaxToolkit:ModalPopupExtender>
    <div id="modal2" style="width: 350px; background-color: white;">
        <asp:Panel Height="100%" Width="100%" CssClass=" modalBG" runat="server" ID="panel2" ViewStateMode="Enabled" EnableViewState="true">
            <asp:UpdatePanel runat="server" ID="UpdatePanel2">

                <ContentTemplate>

                    <table style="width: 100%; height: 50%;">
                        <tr>
                            <td colspan="2" style="background-color: #F5F5F5; text-align: center;">
                                <asp:Label runat="server" Text="Asignar Proyectos" CssClass="tittleclass2"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <div>
                                    <asp:GridView runat="server" ID="GridProyectos" AutoGenerateColumns="False" ViewStateMode="Enabled" DataKeyNames="Codigo" CssClass="Grilla2" Width="340px">
                                        <Columns>
                                            <asp:BoundField DataField="Codigo" HeaderText="Codigo" Visible="false">
                                                <HeaderStyle BackColor="#FFFFCC" />
                                                <ItemStyle Font-Bold="True" />
                                            </asp:BoundField>

                                            <asp:BoundField DataField="Proyecto" HeaderText="Proyecto" HeaderStyle-CssClass="Header2" ItemStyle-CssClass="Item2">
                                                <HeaderStyle />
                                                <ItemStyle Font-Size="Larger" HorizontalAlign="Center" Wrap="true" />
                                            </asp:BoundField>

                                            <asp:TemplateField HeaderText="Estado" ShowHeader="false" ItemStyle-CssClass=" Item2">
                                                <ItemTemplate>
                                                    <asp:CheckBox runat="server" ID="chkProyecto" />

                                                </ItemTemplate>
                                                <HeaderStyle CssClass="Header2" />
                                                <ItemStyle CssClass="Item2" Wrap="False" HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="position: relative; text-align: center;">
                                    <asp:LinkButton runat="server" ID="lkbtnAgregarProyecto" Text="Agregar" CssClass="  linkbtnAgregar" OnClick="lkbtnAgregarProyecto_Click"></asp:LinkButton>
                                    <asp:LinkButton runat="server" ID="lkbtnCancel" Text="Cancelar" CssClass="linkbtnAgregar" OnClick="lkbtnCancel_Click"></asp:LinkButton>
                                </div>

                            </td>



                        </tr>

                    </table>
                </ContentTemplate>

            </asp:UpdatePanel>

        </asp:Panel>

    </div>


    <ajaxToolkit:ModalPopupExtender runat="server" ID="ModalPopupExtender3" BackgroundCssClass=" popUpModal" TargetControlID="btnShoPopup3" PopupControlID="modal3" DropShadow="true"
        CancelControlID="lkbtnCancelRol" PopupDragHandleControlID="panel3">
    </ajaxToolkit:ModalPopupExtender>
    <div id="modal3" style="width: 350px; background-color: white;">
        <asp:Panel Height="100%" Width="100%" CssClass=" modalBG" runat="server" ID="panel3" ViewStateMode="Enabled" EnableViewState="true">
            <asp:UpdatePanel runat="server" ID="UpdatePanel1">

                <ContentTemplate>

                    <table style="width: 100%; height: 50%;">
                        <tr>
                            <td colspan="2" style="background-color: #F5F5F5; text-align: center;">
                                <asp:Label runat="server" Text="Asignar Rol" CssClass="tittleclass2"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <div>
                                    <asp:GridView runat="server" ID="GridRoles" AutoGenerateColumns="False" ViewStateMode="Enabled" DataKeyNames="CodigoRol" CssClass="Grilla2" Width="340px">
                                        <Columns>
                                            <asp:BoundField DataField="CodigoRol" HeaderText="CodigoRol" Visible="false">
                                                <HeaderStyle BackColor="#FFFFCC" />
                                                <ItemStyle Font-Size="Larger" />
                                            </asp:BoundField>

                                            <asp:BoundField DataField="Descripcion" HeaderText="Rol" HeaderStyle-CssClass="Header2" ItemStyle-CssClass="Item2">
                                                <HeaderStyle />
                                                <ItemStyle HorizontalAlign="Center" Wrap="False" />
                                            </asp:BoundField>

                                            <asp:TemplateField HeaderText="Estado" ShowHeader="false" ItemStyle-CssClass="alingRowButons">
                                                <ItemTemplate>
                                                    <asp:CheckBox runat="server" ID="chkRol" />

                                                </ItemTemplate>
                                                <HeaderStyle CssClass="Header2" />
                                                <ItemStyle CssClass=" Item2" Wrap="False" HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="position: relative; text-align: center;">
                                    <asp:LinkButton runat="server" ID="lkbtnAsigRol" Text="Agregar" CssClass="  linkbtnAgregar" OnClick="lkbtnAsigRol_Click"></asp:LinkButton>
                                    <asp:LinkButton runat="server" ID="lkbtnCancelRol" Text="Cancelar" CssClass="linkbtnAgregar" OnClick="lkbtnCancelRol_Click"></asp:LinkButton>
                                </div>

                            </td>



                        </tr>

                    </table>
                </ContentTemplate>

            </asp:UpdatePanel>

        </asp:Panel>
    </div>

    <ajaxToolkit:ModalPopupExtender runat="server" ID="ModalPopupExtender4" BackgroundCssClass="popUpModal" TargetControlID="btnShoPopup4" PopupControlID="modal4" DropShadow="true"
        CancelControlID="lkbtnCancelNivel" PopupDragHandleControlID="panel5">
    </ajaxToolkit:ModalPopupExtender>
    <div id="modal4" style="width: 350px; background-color: white;">
        <asp:Panel Height="100%" Width="100%" CssClass=" modalBG" runat="server" ID="panel5" ViewStateMode="Enabled" EnableViewState="true">
            <asp:UpdatePanel runat="server" ID="UpdatePanel3">

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
                                    <asp:GridView runat="server" ID="GridNivelesAprobacion" AutoGenerateColumns="False" ViewStateMode="Enabled" DataKeyNames="CodigoNivel" CssClass=" Grilla2" Width="340px">
                                        <Columns>
                                            <asp:BoundField DataField="CodigoNivel" HeaderText="CodigoNivel" Visible="false">
                                                <HeaderStyle BackColor="#FFFFCC" />
                                                <ItemStyle Font-Bold="True" Font-Size="Larger" Wrap="false" />
                                            </asp:BoundField>

                                            <asp:BoundField DataField="Glosa" HeaderText="Descripcion" HeaderStyle-CssClass="Header2" ItemStyle-CssClass="Item2">
                                                <HeaderStyle />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>

                                            <asp:TemplateField HeaderText="Estado" ShowHeader="false" ItemStyle-CssClass=" Item2">
                                                <ItemTemplate>
                                                    <asp:CheckBox runat="server" ID="chkEstadoNivel" />

                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                                <HeaderStyle CssClass="Header2" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align: center;">

                                <asp:LinkButton runat="server" ID="lkbtnAgregarNivel" Text="Agregar  " CssClass="  linkbtnAgregar" OnClick="lkbtnAgregarNivel_Click"></asp:LinkButton>
                                <asp:LinkButton runat="server" ID="lkbtnCancelNivel" Text="Cancelar" CssClass="  linkbtnAgregar" OnClick="lkbtnCancelNivel_Click"></asp:LinkButton>
                            </td>



                        </tr>

                    </table>
                </ContentTemplate>

            </asp:UpdatePanel>

        </asp:Panel>



    </div>
</asp:Content>

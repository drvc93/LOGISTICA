<%@ Page Title="Registro de Proyectos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WFProyectosSearch.aspx.cs" Inherits="WSLogis.Administracion.WFProyectosSearch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <link href="../Styles/jquery.jnotify.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery-1.4.2.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery.jnotify.js" type="text/javascript"></script>


    <script>

        function popitup(url) {
            newwindow = window.open(url, 'name', 'height=300,width=450,navigationtoolbar=no,toolbar=no,menubar=no,left=150,top=180');/**/
        }
    </script>

    <div>
        <h2 style="margin-top: 5px;">Buscar Proyecto</h2>
        <asp:ScriptManager runat="server" ID="idScripm2" EnablePartialRendering="true"></asp:ScriptManager>
        <div style="margin-top: 10px">
            <asp:TextBox ID="txtNombreLocal" runat="server" CssClass=" textbox1" Width="250px"></asp:TextBox><ajaxToolkit:TextBoxWatermarkExtender WatermarkCssClass="hintText" runat="server" ID="waterMark1" TargetControlID="txtNombreLocal" WatermarkText="Buscar por nombre de proyecto" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:LinkButton runat="server" Text="Buscar" CssClass="linkbuttonClass"></asp:LinkButton>&nbsp;&nbsp;&nbsp;
            <asp:LinkButton runat="server" CssClass="linkbuttonClass" ID="btnNuevoPro" Text="Nuevo" OnClick="btnNuevoPro_Click" OnClientClick="popitup('WFProyectoEdit.aspx')" />
        </div>
        <div style="margin-top: 5px;">
            <p>

                <asp:UpdatePanel runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:GridView runat="server" ID="GridProyectos" AutoGenerateColumns="False" ViewStateMode="Enabled" CssClass="Grilla2" DataKeyNames="Codigo" Width="700px">
                            <Columns>
                                <asp:BoundField DataField="Codigo" HeaderText="Codigo" Visible="false">
                                    <HeaderStyle />
                                    <ItemStyle Font-Bold="True" Font-Size="Larger" />
                                </asp:BoundField>

                                <asp:BoundField DataField="Tipo Proyecto" HeaderText="Tipo Proyecto" HeaderStyle-CssClass="Header2" ItemStyle-CssClass="Item2">
                                    <HeaderStyle />
                                    <ItemStyle />
                                </asp:BoundField>
                                <asp:BoundField DataField="Nombre" HeaderText="Nombre" HeaderStyle-CssClass="Header2" ItemStyle-CssClass="Item2">
                                    <HeaderStyle />
                                    <ItemStyle />
                                </asp:BoundField>
                                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" HeaderStyle-CssClass="Header2" ItemStyle-CssClass="Item2">
                                    <HeaderStyle />
                                    <ItemStyle />
                                </asp:BoundField>
                                <asp:BoundField DataField="FechaInicio" HeaderText="FechaInicio" HeaderStyle-CssClass="Header2" ItemStyle-CssClass="Item2">
                                    <HeaderStyle />
                                    <ItemStyle />
                                </asp:BoundField>
                                <asp:BoundField DataField="FechaTermino" HeaderText="FechaTermino" HeaderStyle-CssClass="Header2" ItemStyle-CssClass="Item2">
                                    <HeaderStyle />
                                    <ItemStyle />
                                </asp:BoundField>
                                <asp:BoundField DataField="Estado" HeaderText="Estado" HeaderStyle-CssClass="Header2" ItemStyle-CssClass="Item2">
                                    <HeaderStyle />
                                    <ItemStyle />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="" ShowHeader="false" ItemStyle-CssClass=" Item2">
                                    <ItemTemplate>
                                        <asp:LinkButton runat="server" ID="btnEdit" Text="Editar" OnClick="btnEdit_Click" OnClientClick="popitup('WFProyectoEdit.aspx')" />

                                    </ItemTemplate>
                                    <HeaderStyle CssClass="Header2" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="" ShowHeader="false" ItemStyle-CssClass="Item2">
                                    <ItemTemplate>
                                        <asp:LinkButton runat="server" ID="lkbtnCodigoPre" Text="Presupuesto" OnClick="lkbtnCodigoPre_Click" />

                                    </ItemTemplate>
                                    <HeaderStyle CssClass="Header2" />
                                </asp:TemplateField>
                            </Columns>

                        </asp:GridView>

                    </ContentTemplate>
                </asp:UpdatePanel>
            </p>
            <div style="display: none">
                <asp:Button runat="server" ID="btnShoPopup" CssClass="ModalWIND" /></div>
            <div style="display: none">
                <asp:Button runat="server" ID="btnShoPopup2" CssClass="ModalWIND" /></div>
        </div>
        <p></p>

        <ajaxToolkit:ModalPopupExtender runat="server" ID="ModalPopup1Ext" BackgroundCssClass=" popUpModal" TargetControlID="btnShoPopup" PopupControlID="PopEdit1"
            CancelControlID="lkbtnCancelP" PopupDragHandleControlID="panel1">
        </ajaxToolkit:ModalPopupExtender>

        <div id="PopEdit1" style="width: 22%; border-radius: initial; border-style: solid; background-color: white;" class="borderForm">

            <asp:Panel Height="100%" Width="100%" CssClass=" modalBG" runat="server" ID="panel1" ViewStateMode="Enabled" EnableViewState="true">
                <asp:UpdatePanel runat="server" ID="uppanel1">
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnNuevoPro" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="ddlGrupoPoryecto" EventName="SelectedIndexChanged" />
                    </Triggers>

                    <ContentTemplate>
                        <div runat="server" style="background-color: white;">

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
                            </table>

                        </div>

                    </ContentTemplate>
                </asp:UpdatePanel>

                <div style="text-align: center; margin-bottom: 5%">
                    <div style="float: left; margin-left: 40%">
                        <asp:LinkButton runat="server" Text="Grabar" ID="lkbtnGrabar" OnClick="lkbtnGrabar_Click"> </asp:LinkButton>
                    </div>
                    <div style="float: left; margin-left: 5%">
                        <asp:LinkButton runat="server" Text="Cerrar" ID="lkbtnCancelP"> </asp:LinkButton>
                    </div>

                </div>
            </asp:Panel>

        </div>

    </div>

    <ajaxToolkit:ModalPopupExtender runat="server" ID="ModalPopUp2" BackgroundCssClass=" popUpModal" TargetControlID="btnShoPopup2" PopupControlID="modal2" DropShadow="true"
        CancelControlID="lkbtnCancel" PopupDragHandleControlID="panel2">
    </ajaxToolkit:ModalPopupExtender>
    <div id="modal2" style="width: 480px; background-color: white;">
        <asp:Panel Height="100%" Width="100%" CssClass=" modalBG" runat="server" ID="panel2" ViewStateMode="Enabled" EnableViewState="true">
            <asp:UpdatePanel runat="server" ID="UpdatePanel2">
                <Triggers>
                    <asp:PostBackTrigger ControlID="lkbtnAgregarPre" />

                </Triggers>
                <ContentTemplate>

                    <table style="width: 470px; height: 50%; overflow-x: hidden;">

                        <tr>
                            <td colspan="2" style="background-color: #F6BE00; text-align: center;">
                                <asp:Label runat="server" Text="Agregar Codigo Presupuestal" CssClass="tittleclass2"></asp:Label>
                            </td>
                        </tr>


                        </tr>

                          <tr>
                              <td style="width: 30%; text-align: right;">
                                  <asp:Label runat="server" Text="Archivo Excel: " CssClass="labelCss"></asp:Label>
                              </td>

                              <td>
                                  <asp:FileUpload Width="98%" runat="server" ID="fileUploadExcel" AllowMultiple="false" />
                              </td>

                          </tr>
                        <tr>
                            <td colspan="2" style="text-align: center;">
                                <asp:LinkButton runat="server" ID="lkbtnAgregarPre" Text="Cargar" CssClass="  linkbtnAgregar" OnClientClick="Confirm()" OnClick="lkbtnAgregarPre_Click"></asp:LinkButton>


                            </td>

                        </tr>

                        <tr>

                            <td colspan="2">
                                <div style="width: 475px;  max-height:600px; overflow-x:hidden; overflow-y: scroll;">
                                    <asp:GridView runat="server" ID="GridCodigosProyecto" AutoGenerateColumns="False" ViewStateMode="Enabled" Width="460px">
                                        <Columns>


                                            <asp:BoundField DataField="Codigo" HeaderText="Codigo" ControlStyle-Width="50px">
                                                <HeaderStyle CssClass="Header2" />
                                                <ItemStyle CssClass="Item2"  Wrap="False" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" ItemStyle-Width="280px" HeaderStyle-Width="280px" ItemStyle-Wrap="false">
                                                <HeaderStyle CssClass="Header2" />
                                                <ItemStyle CssClass="Item2"  Wrap="true" />
                                            </asp:BoundField>
                                           


                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align: center;">
                                <div style="position: relative; text-align: center;">
                                    <asp:LinkButton runat="server" ID="lkbtnGrabarCodPresp" Text="Grabar" CssClass="linkbtnAgregar" OnClick="lkbtnGrabarCodPresp_Click"></asp:LinkButton>
                                    <asp:LinkButton runat="server" ID="lkbtnCancel" Text="Cerrar" CssClass="linkbtnAgregar" Style="margin-left: 10px;" OnClick="lkbtnCancel_Click"></asp:LinkButton>

                                </div>

                            </td>



                        </tr>

                    </table>
                </ContentTemplate>

            </asp:UpdatePanel>

        </asp:Panel>

    </div>
</asp:Content>

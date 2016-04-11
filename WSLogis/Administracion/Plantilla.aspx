<%@ Page Title="Registro de xxxx" MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" CodeBehind="Plantilla.aspx.cs" Inherits="WSLogis.Administracion.Plantilla" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"
            EnableScriptLocalization="false">
        </asp:ScriptManager>
        <table style="width: 800px">
            <tr>
                <td>
                    <asp:UpdatePanel ID="updActualizar" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:Panel ID="Panel1" runat="server" HorizontalAlign="Left">
                                <table>
                                    <tr>
                                        <td colspan="3">
                                            <asp:Label ID="Label1" runat="server" CssClass="Titulitos" Text="Lista de Empresas"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <asp:HyperLink ID="hlkAddEmpresa" runat="server" CssClass="TitulitosSub" 
                                                Text="Nueva Empresa (+)" ToolTip="Agregar Empresas"></asp:HyperLink>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <asp:GridView ID="gvListado" runat="server" AutoGenerateColumns="False" DataKeyNames="CodigoEmpresa"
                                                CssClass="Grilla2" Width="700px" BorderStyle="None" BorderWidth="1px" AllowPaging="True"
                                                GridLines="Vertical" PageSize="20" 
                                                onpageindexchanging="gvListado_PageIndexChanging" 
                                                onrowdatabound="gvListado_RowDataBound">
                                                <EmptyDataTemplate>
                                                    <asp:Label ID="lblVacio" runat="server" Text="No se encontraron registros" SkinID="label_vacio"></asp:Label>
                                                </EmptyDataTemplate>
                                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                <HeaderStyle CssClass="Header2" />
                                                <Columns>
                                                    <asp:BoundField DataField="CodigoEmpresa" Visible="False" />
                                                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre">
                                                        <HeaderStyle CssClass="header2" />
                                                        <ItemStyle CssClass="Item2" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Denominacion" HeaderText="Denominación" SortExpression="Descripcion">
                                                        <HeaderStyle CssClass="header2" />
                                                        <ItemStyle CssClass="Item2" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="RUC" HeaderText="RUC" SortExpression="RUC">
                                                        <HeaderStyle CssClass="header2" />
                                                        <ItemStyle CssClass="Item2" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Direccion" HeaderText="Dirección" SortExpression="Direccion">
                                                        <HeaderStyle CssClass="header2" />
                                                        <ItemStyle CssClass="Item2" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="DescripcionUbigeo" HeaderText="Distrito" SortExpression="DistritoLocal">
                                                        <HeaderStyle CssClass="header2" />
                                                        <ItemStyle CssClass="Item2" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado" Visible="false">
                                                        <HeaderStyle CssClass="header2" />
                                                        <ItemStyle CssClass="Item2" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="EstadoName" HeaderText="Estado" SortExpression="Estado">
                                                        <HeaderStyle CssClass="header2" />
                                                        <ItemStyle CssClass="Item2" />
                                                    </asp:BoundField>
                                                    <asp:TemplateField HeaderText="" ShowHeader="False">
                                                        <ItemTemplate>
                                                            <asp:HyperLink ID="hypEdit" runat="server" NavigateUrl='<%# String.Format("WFEmpresaEdit.aspx?CodigoEmpresa={0}", Eval("CodigoEmpresa")) %>'
                                                                Text="Editar" ToolTip="Modificar datos de empresa"> 
                                                            </asp:HyperLink>
                                                        </ItemTemplate>
                                                        <HeaderStyle CssClass="header2" />
                                                        <ItemStyle CssClass="Item2" Width="30px" />
                                                    </asp:TemplateField>
                                                </Columns>
                                                <PagerStyle CssClass="Pie2" ForeColor="White" HorizontalAlign="center" />
                                                <AlternatingRowStyle BackColor="#FFFFFF" />
                                            </asp:GridView>
                                            <br />
                                            <div style="text-align: center">
                                                <asp:Label ID="lblMensaje" runat="server" Text="" EnableViewState="false" SkinID="label_vacio"></asp:Label></div>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <div style="text-align: center">
                            </div>
                        </ContentTemplate>
                        <Triggers>
                        </Triggers>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

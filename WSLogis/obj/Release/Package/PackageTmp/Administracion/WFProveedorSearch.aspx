<%@ Page Title="Registro de Proveedores" MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" CodeBehind="WFProveedorSearch.aspx.cs" Inherits="WSLogis.Administracion.WFProveedorSearch" %>
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
                                <table width="800px">
                                    <tr>
                                        <td>
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

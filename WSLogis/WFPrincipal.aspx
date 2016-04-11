<%@ Page Title="Pagina Principal" Language="C#" AutoEventWireup="true" CodeBehind="WFPrincipal.aspx.cs" Inherits="WSLogis.WFPrincipal"  MasterPageFile="~/Site.Master" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:ScriptManager runat="server"></asp:ScriptManager>
    <h2>
        Bienvenido al Sistema de Administración de Proyectos de Socios en Salud.
    </h2>
    <p></p>
     <%--<table style="width:100%">
         <tr>
             <td>

                <div>
                   <telerik:RadGrid ID="grdiPedidos"  AutoGenerateColumns="false"  runat="server">
                       <MasterTableView>
                           <Columns>
                               <telerik:GridTemplateColumn HeaderText="Image">
                           <ItemTemplate>
                               <telerik:RadBinaryImage runat="server" DataValue='<%#Eval("Imagen") %>' />
                           </ItemTemplate>
                               </telerik:GridTemplateColumn>
                           </Columns>
                       </MasterTableView>

                   </telerik:RadGrid>

                </div>
             </td>
         </tr>
     </table>--%>
      
    
    <p>  </p>
</asp:Content>

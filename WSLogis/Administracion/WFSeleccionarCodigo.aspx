<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WFSeleccionarCodigo.aspx.cs" Inherits="WSLogis.Administracion.WFSeleccionarCodigo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script>
        function Close() {

            window.close();
         
        }
        function refreshGridCodParent() {
            window.opener.RefreshGridCodigos();
            window.close();

        };
    </script>
    <style>
        .nodisplay{

            display:none;
        }

    </style>
    <link href="../Content/Site.css" rel="stylesheet" />
    <meta http-equiv="Content-Type" content="text/html; charset=ISO-8859-1" />
    <title>Seleccionar Codigos</title>
</head>
<body>
    <form id="form1" runat="server"  >
        <asp:ScriptManager runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="false" ></asp:ScriptManager>

        <div>
            <asp:UpdatePanel runat="server">
                <ContentTemplate>

                    <div style="width: 430px;">

                        <table style="width: 420px;">
                            <tr>
                                <td colspan="2" style="text-align:center">
                                    <asp:Label runat="server" ID="lblTITULO" CssClass=" Titulitos" Text="Codigos Proyecto"></asp:Label>

                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:GridView Style="width: 400px;" runat="server" CssClass="Grilla2" ID="gvCodigosProyecto" HeaderStyle-CssClass="Header2" AutoGenerateColumns="false">

                                        <Columns>
                                            <asp:BoundField DataField="CodPresp"  ControlStyle-CssClass="nodisplay"  ItemStyle-CssClass="nodisplay" HeaderStyle-CssClass="nodisplay" />
                                            
                                            <asp:BoundField DataField="Codigo" HeaderText="Codigo" HeaderStyle-Width="100px" ItemStyle-CssClass="Item2" ItemStyle-HorizontalAlign="Center" />
                                            <asp:TemplateField HeaderText="" HeaderStyle-Width="40px" ItemStyle-CssClass="Item2">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>

                                                    <asp:CheckBox ID="chkCodigo" runat="server" />

                                                </ItemTemplate>

                                            </asp:TemplateField>
                                        </Columns>

                                    </asp:GridView>


                                </td>


                            </tr>
                            <tr>

                                <td style="text-align: right">
                                    <asp:LinkButton ID="lkAgregarCod" OnClick="lkAgregarCod_Click" Style="margin-right: 10px;" runat="server" Text="Agregar"></asp:LinkButton>
                                </td>
                                <td style="text-align: left">
                                    <asp:LinkButton ID="lkCerrar" OnClientClick="Close()" runat="server" Text="Cerrar"></asp:LinkButton>
                                </td>

                            </tr>


                        </table>

                    </div>

                </ContentTemplate>
            </asp:UpdatePanel>

        </div>
    </form>
</body>
</html>

<%@ Page Title="Imprimir" Language="C#" AutoEventWireup="true" CodeBehind="WFActaConformidad.aspx.cs" Inherits="WSLogis.Almacen.WFActaConformidad" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>



<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../Styles/radStyles.css" rel="stylesheet" />
    <script>
        function funExport(type) {
            if (type == 'PDF') {
                document.getElementById('<%= btnExoprtPDF.ClientID %>').click();
            }
            else {
                document.getElementById('<%= btnExportWord.ClientID %>').click();

            }
        }
    </script>

    <style>
        .fullWidth { <!-- -->
            width: 100%;
        }
    </style>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body style="width: 100%">
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server"></asp:ScriptManager>
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div style="margin-bottom: 10px;">
                    <table style="/*width: 800px*/">
                        <tr>
                            <td style="background-color: #d2deec">
                                <div style="float: left;">
                                    <button class=" button_example" runat="server" onclick="funExport('PDF')">
                                        <img src="../Images/PDF.png" />
                                        Exportar  a PDF</button>
                                </div>

                                <div style="float: left;">
                                    <button runat="server" class="button_example" onclick="funExport('Word')">
                                        <img src="../Images/word.png" />
                                        Exportar  a WORD</button>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <div style="width: 100%">

                                    <CR:CrystalReportViewer ID="CrystalReportViewer1" CssClass=" fullWidth" HasToggleParameterPanelButton="false" ToolPanelView="None" runat="server" AutoDataBind="true" EnableParameterPrompt="False" HasCrystalLogo="False" EnableDrillDown="False" />
                                </div>

                            </td>

                        </tr>

                    </table>

                </div>



            </ContentTemplate>

        </asp:UpdatePanel>
        <asp:Button runat="server" Style="display: none;" ID="btnExoprtPDF" OnClick="btnExoprtPDF_Click" />
        <asp:Button runat="server" Style="display: none;" ID="btnExportWord" OnClick="btnExportWord_Click" />


    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WFRegistroIngresoPreview.aspx.cs" Inherits="WSLogis.Almacen.WFRegistroIngresoPreview" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../Content/Site.css" rel="stylesheet" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Registro Ingreso</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <div>
        <asp:ScriptManager EnableScriptGlobalization="true" EnableScriptLocalization="false" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel runat="server">

            <ContentTemplate >
                <style>
                    td{<!---->
                       padding:3px 3px 3px 3px ;
                      
                    }
                    .aligntextRight{<!---->

                               text-align:right;
                    }
                   
                </style>
                <asp:Panel runat="server" Width="100%">
                    <div style="width:800px; margin-left:auto;margin-right:auto" >


                        <table>
                            <tr>
                                <td colspan="4" style="text-align:center">
                                    <div style="margin-bottom:15px; margin-top:15px">                              
                                    <asp:Label CssClass="Titulitos" runat="server" Text="Registro de Ingreso"></asp:Label>
                                    </div>

                                </td>

                            </tr>
                            <tr>
                                <td style="text-align:right; ">
                                    <asp:Label runat="server" Text="Nro. Orden: "></asp:Label>
                                </td>
                                <td  >
                                    <asp:Label runat="server" Text="00001" ID="lblNroOrden"></asp:Label>
                                </td>
                                
                                <td style="text-align:right; " >
                                    <asp:Label runat="server" Text="Proveedor: "></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" Text="00001" ID="lblProveedor"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align:right;">
                                    <asp:Label runat="server" Text="Codigo Producto: "></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" Text="00001" ID="lblCodProducto"></asp:Label>
                                </td>
                                <td style="text-align:right;">
                                    <asp:Label runat="server" Text="Producto : "></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" Text="00001" ID="lblProductoNom"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align:right;">
                                    <asp:Label runat="server" Text="Local: "></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList CssClass="textbox1" runat="server" ID="ddLocal" Width="200px"></asp:DropDownList>
                                </td>
                                <td style="text-align:right;">
                                    <asp:Label runat="server" Text="Proyecto: "></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList CssClass="textbox1" runat="server" ID="ddProyecto" Width="200px"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align:right;">
                                    <asp:Label runat="server" Text="Fecha Ingreso: "></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox CssClass="textbox1" runat="server" ID="txtFechaIngreso" Width="150px"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" TargetControlID="txtFechaIngreso" runat="server" />
                                </td>
                                <td style="text-align:right;">
                                    <asp:Label runat="server" Text="Fecha Expiracion: "></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox CssClass="textbox1" runat="server" ID="txtFechaExpiracion"  Width="150px"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender2" TargetControlID="txtFechaExpiracion" Format="dd/MM/yyyy" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                
                                <td style="text-align:right;">
                                    <asp:Label runat="server" Text="Nro. Lote: "></asp:Label>
                                </td>

                                <td>
                                    <asp:TextBox CssClass="textbox1" ID="txtNroLoteo" runat="server" Width="150px" ></asp:TextBox>
                                </td>
                                <td style="text-align:right;">
                                    <asp:Label runat="server" Text="Temperatura Almac. : "></asp:Label>
                                </td>

                                <td>
                                    <asp:TextBox CssClass="textbox1" ID="txtTemperaturaAlmc" runat="server" Width="150px" ></asp:TextBox>
                                </td>
                            </tr>
                            <tr>

                                <td style="text-align:right;">
                                    <asp:Label runat="server" Text="Tipo Existencia: "></asp:Label>
                                </td>
                                <td  colspan="3">
                                    <asp:DropDownList CssClass="textbox1" runat="server" ID="ddTipExistencia" Width="200px"></asp:DropDownList>
                                </td>

                            </tr>
                            <tr>

                                 <td>
                                    <asp:Label runat="server" Text="Tipo Comprobante: "></asp:Label>
                                </td>
                                <td  >
                                    <asp:DropDownList CssClass="textbox1" runat="server" ID="ddTipComprobante" Width="200px"></asp:DropDownList>
                                </td>
                                 <td>
                                    <asp:Label runat="server" Text="Otro Comprobante: "></asp:Label>
                                </td>
                                 <td >
                                    <asp:TextBox CssClass="textbox1" runat="server" Width="150px"></asp:TextBox>
                                </td>

                            </tr>
                            <tr>
                                <td style="text-align:right;">
                                    <asp:Label runat="server" Text="Serie : "></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox CssClass="textbox1" runat="server"  Width="150px" ID="txtSerie"></asp:TextBox>
                                </td>
                                <td style="text-align:right;">
                                    <asp:Label runat="server" Text="Numero : "></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox CssClass="textbox1" runat="server"  Width="150px" ID="txtNumero"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                 <td style="text-align:right;">
                                    <asp:Label runat="server" Text="Tipo Oper. : "></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList runat="server" Width="200px" CssClass="textbox1" ID="ddTipOperacion"></asp:DropDownList><div style="width:230px;height:1px"></div>
                                </td>
                                 <td style="text-align:right;">
                                    <asp:Label runat="server" Text="Otro : "></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox CssClass="textbox1" runat="server"  Width="150px" ID="txtOtraOperacion"></asp:TextBox>
                                </td>
                            </tr>
                            
                            <tr>
                                  <td style="text-align:right;">
                                    <asp:Label runat="server" Text="Cantidad(Unid.): "></asp:Label>
                                </td>

                                <td colspan="3">
                                    <asp:TextBox CssClass="textbox1" ID="TextBox1" runat="server" Width="150px" TextMode="Number" ></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td  colspan="4" style=" text-align:center;background-color:#FAFAFA">
                                    <div  style=" margin-top:15px;">
                                    <asp:LinkButton runat="server" Text="Grabar"></asp:LinkButton>
                                        </div>
                                </td>
                            </tr>
                        </table>
                    </div>


                </asp:Panel>
            </ContentTemplate>

        </asp:UpdatePanel>

    </div>
    </div>
    </form>
</body>
</html>

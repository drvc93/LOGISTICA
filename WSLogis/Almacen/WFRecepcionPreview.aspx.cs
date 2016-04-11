using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassBusiness;
using System.Data;
using WSLogis.Helper;

namespace WSLogis.Almacen
{
    public partial class WFRecepcionPreview : System.Web.UI.Page
    {
        CBOrdenDeCompra objOrdenCompra;
        CBRecepcion objRecepcion;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {/**/
                if (Session["ParCodOc"] != null) { /**/

                    CargarCabecera(Convert.ToInt32(Session["ParCodOc"]));
                
                }

            }

        }

        public void CargarCabecera(int codOC) { /**/
            objOrdenCompra = new CBOrdenDeCompra();
            DataTable dtCabcera = objOrdenCompra.GetCabecerDetalleOCRecepcion("2", codOC);
            lblNroOrden.Text = dtCabcera.Rows[0]["NumeroOC"].ToString();
            lblTipoCompra.Text = dtCabcera.Rows[0]["TipoOC"].ToString();
            lblPoryecto.Text = dtCabcera.Rows[0]["Proyecto"].ToString();
            lblLocalEntrega.Text = dtCabcera.Rows[0]["Local"].ToString();
            lblProveedor.Text = dtCabcera.Rows[0]["Proveedor"].ToString();
            lblFechaOC.Text = dtCabcera.Rows[0]["FechaOrden"].ToString();
            lblMoneda.Text = dtCabcera.Rows[0]["Moneda"].ToString();
            lblImporte.Text = dtCabcera.Rows[0]["Monto"].ToString();
            CargarDetalle(codOC);
        
        }


         public int InsertarCabecera ()
        { /**/

            objRecepcion = new CBRecepcion();
            int res = 0;
            // variables para inserccion 
            int codOc = Convert.ToInt32(Session["ParCodOc"].ToString());
            int userRecep = Convert.ToInt32(Session["CodigoUsuario"].ToString());
            string NroFact = txtNrpFactura.Text;
            string nroGuia = txtGuiaRemision.Text;
            DateTime fechaRemision = Convert.ToDateTime(txtfechaRemision.Text);
            string observ = txtObservaciones.Text;
            int UserReg = userRecep;
            int recepSistemas = GetValueIntCheckSistemas();
             int estatus = GetEstatus("SI");

             res = objRecepcion.InsertarCabeceraRecepcion(codOc, userRecep, NroFact, nroGuia, fechaRemision, observ, recepSistemas, estatus, UserReg);

             return res;
        }

         public bool InsertarDetalle(int codRecep ) { /**/
             bool result = false;
            
             int cont = 0;
             int userReg = Convert.ToInt32(Session["CodigoUsuario"].ToString());
             
             for (int i = 0 ; i<GridOCDetalle.Rows.Count;i++){/**/
                 objRecepcion = new CBRecepcion();
                 int codOCDetalle = Convert.ToInt32(GridOCDetalle.DataKeys[i].Values[0].ToString());
                 TextBox cantidadRecibida = GridOCDetalle.Rows[i].FindControl("txtrowCantidadRecibida") as TextBox;
                 int cantRecibida = Convert.ToInt32(cantidadRecibida.Text);

                 objRecepcion.InsertarDetalleRecepcion(codRecep, codOCDetalle, cantRecibida, 1, userReg);
                 cont = cont + 1;
             }

             if (cont == GridOCDetalle.Rows.Count) { /**/

                 result = true;

             }

             else { /**/

                result =  false;
             }


             return result;
         
         }
        public void CargarDetalle(int codOC) {

            objOrdenCompra = new CBOrdenDeCompra();
            DataTable dtDetalle = objOrdenCompra.GetCabecerDetalleOCRecepcion("3", codOC);
            GridOCDetalle.DataSource = dtDetalle;
            GridOCDetalle.DataBind();
            AsignarCantidadTextRows(dtDetalle);
        
        }


        public void AsignarCantidadTextRows(DataTable dtrows) 
        {
            for (int i = 0; i < dtrows.Rows.Count; i++) { /**/


                TextBox cantidadRecibida = GridOCDetalle.Rows[i].FindControl("txtrowCantidadRecibida") as TextBox;
                string cant = dtrows.Rows[i]["Cantidad"].ToString();
                cantidadRecibida.Text = cant;
            
            }      
                               
         }

        public int GetValueIntCheckSistemas() { /**/
            int result = -1;
            if (chkSistemas.Checked == true) { /**/

                result = 1;
            
            }

            else { /**/

                result = 0;
            }

            return result;
        
        }


        public int GetEstatus(string Aprobado) {
            int res = -1;

            if (Aprobado == "NO") { /**/

                res = 0;
            
            }
            else if (Aprobado == "SI"){/**/

                if (chkSistemas.Checked == true) { /**/

                    res = 1;
                
                }
                else if (chkSistemas.Checked==false) {/**/

                    res = 2;

                }
            
            }

            return res;
         
        
        }
        protected void lkbtnRecepcionar_Click(object sender, EventArgs e)
        {
             string confirmValue = Request.Form["confirm_value"];
             if (confirmValue == "Si")
             { /**/

                 if (txtNrpFactura.Text != "") { /**/

                     int codRecep = InsertarCabecera();
                     if (codRecep > 0)
                     { /**/
                         bool res_det = InsertarDetalle(codRecep);

                         if (res_det == true) 
                         {
                             ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "refreshGridParent();", true);

                         //ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "ClosePopup();", true);

                         }
                     }
                 }

                 else
                 {

                     this.ShowErrorNotification("Debe ingresar el numero de factura para continuar", 2000);
 
                 }
             
             }
        }


    }
}
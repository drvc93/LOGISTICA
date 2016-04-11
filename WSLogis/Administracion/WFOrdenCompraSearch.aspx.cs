using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassBusiness;
using System.Data;

namespace WSLogis.Administracion
{
    public partial class WFOrdenCompraSearch : System.Web.UI.Page
    {
        CBOrdenDeCompra objOrdenes;
        CBCombo objCombo;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {


                CargarListaOrdenes();

            }


        }

        public void CargarListaOrdenes() { 
        
             objOrdenes = new CBOrdenDeCompra();
             DataTable dtListaOrd = objOrdenes.GetListaOrdenes("1");
             GridOrdenes.DataSource = dtListaOrd;
             GridOrdenes.DataBind();

             for (int i = 0; i < dtListaOrd.Rows.Count; i++) {

                 // TextBox txtPrecio = GridItems.Rows[i].FindControl("txtPrecioRow") as TextBox;
                 CheckBox chkIgv = GridOrdenes.Rows[i].FindControl("chekIGVRow") as CheckBox;

                 chkIgv.Checked = Convert.ToBoolean(dtListaOrd.Rows[i]["Igv"]);
                 chkIgv.Enabled = false;


             }
        
        }

        protected void lkVerRow_Click(object sender, EventArgs e)
        {
            LinkButton boton = sender as LinkButton;
            GridViewRow gridview = (GridViewRow)boton.NamingContainer;
             int codOC =  Convert.ToInt32( GridOrdenes.DataKeys[gridview.RowIndex].Value.ToString());
             string moneda = Convert.ToString(GridOrdenes.Rows[gridview.RowIndex].Cells[5].Text);
             CheckBox chkIgv = GridOrdenes.Rows[gridview.RowIndex].FindControl("chekIGVRow") as CheckBox;

             bool igv = Convert.ToBoolean(chkIgv.Checked);
             
             CargarPopUpDetalle(codOC, moneda,igv);
             this.ModalPopUp2.Show();
        }

        public void CargarPopUpDetalle(int cod ,string moneda, bool igv ) {

            objOrdenes = new CBOrdenDeCompra();
            DataTable dtDetalleOrden = objOrdenes.GetListaOrdenDetalle("1", cod);
            GridDetalleOrden.DataSource = dtDetalleOrden;
            GridDetalleOrden.DataBind();
            decimal MontoTotal =  ObtenerMontototalDetalle(dtDetalleOrden);
            decimal var_igv = GetValorIgv();
            lblPrecioVent.Text= Convert.ToString(MontoTotal) + " " + moneda;
            decimal monto_igv = 0;
            if (igv == true)
            {

                monto_igv = MontoTotal * var_igv / 100;

                string display = String.Format("{0:0.00}", monto_igv);

                lblIgvTotal.Text = display + " " + moneda;
                
            }
            else if (igv==false) {

                monto_igv = 0;
                lblIgvTotal.Text = "0.00"+ " "+ moneda;
               
            }

            string MontoDisplay = String.Format("{0:0.00}", (monto_igv + MontoTotal));

            lblMontoTotal.Text = MontoDisplay+ " " + moneda;
            
            
        
        }

        public decimal ObtenerMontototalDetalle(DataTable dtDetalle) {

            decimal result = 0;

            if (dtDetalle != null)
            {

                for (int i = 0; i < dtDetalle.Rows.Count; i++)
                {

                    decimal var = Convert.ToDecimal(dtDetalle.Rows[i]["SubTotal"]);

                    result = result + var;
                }
            }

            else { }
            return result;

        }

        public Decimal GetValorIgv() {
            Decimal res = 0;
            objCombo = new CBCombo();
            DataTable dtigv = objCombo.GetValorIgv();

             if (dtigv!=null ){
             
              res = Decimal.Parse( dtigv.Rows[0]["GlosaDetalle"].ToString());

             }

            return res;

        }
    }
}
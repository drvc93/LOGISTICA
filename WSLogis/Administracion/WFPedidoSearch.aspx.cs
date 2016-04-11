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
    public partial class WFPedidoSearch : System.Web.UI.Page
    {



        CBPedido objPedido;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) {

                CargarGrillaPedidos();

            
            }
        }

        public void CargarGrillaPedidos() {

            objPedido = new CBPedido();
            DataTable dtPedidos = objPedido.GetPedidoCabeceraDetalle("3", 0);
            GridPedidos.DataSource = dtPedidos;
            GridPedidos.DataBind();

            
         }

        protected void lkRowGenerar_Click(object sender, EventArgs e)
        {
            LinkButton lkbtnIr = sender as LinkButton;
            GridViewRow gridview = (GridViewRow)lkbtnIr.NamingContainer;
            Session["ParametroIdPedido"] = GridPedidos.DataKeys[gridview.RowIndex].Value.ToString();
            Response.Redirect("~/Orden/WFOrdenDeCompra.aspx");

        }
    }
}
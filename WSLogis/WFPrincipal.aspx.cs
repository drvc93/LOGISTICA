using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassBusiness;

namespace WSLogis
{
    public partial class WFPrincipal : System.Web.UI.Page
    {
        CBPedido objPedido;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack) {
                //objPedido = new CBPedido();
                //grdiPedidos.DataSource = objPedido.GetPedidosEnProceso();
                //grdiPedidos.DataBind();

            }

        }
    }
}
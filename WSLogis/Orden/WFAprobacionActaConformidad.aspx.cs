using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassBusiness;
using System.Data;
using Telerik.Web.UI;

namespace WSLogis.Orden
  
{
    public partial class WFAprobacionActaConformidad : System.Web.UI.Page
    {
        CBPedido objPedido;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) {

                LoadGrid();
                DataTable dtGet = Session["PedidosProceso"] as DataTable ;
                AsigignarValorLinkButon(dtGet);
            }
            
        }

        public void LoadGrid() {
            objPedido = new CBPedido();
            int codUser = Convert.ToInt32(Session["CodigoUsuario"].ToString());
            DataTable dtget = objPedido.GetPedidosEnProceso("1", codUser);
            objPedido = new CBPedido();
            DataTable dtPedido = objPedido.GetPedidosEnProceso("2", codUser);
            dtget.Merge(dtPedido);

            radGridPedidos.DataSource = dtget;
            radGridPedidos.DataBind();
          //  AsigignarValorLinkButon(dtget);
            Session["PedidosProceso"] = dtget;

        }

        public void AsigignarValorLinkButon( DataTable  dtAsgin) {

            for (int i = 0; i< dtAsgin.Rows.Count ;i++) {

                LinkButton lkbtn =  radGridPedidos.Items[i].FindControl("lkbtnActa") as LinkButton;
             //   string varrres = radGridPedidos.Items[i].Cells.
               // string other = varrres;
                string tipo = dtAsgin.Rows[i]["Tipo"].ToString();
                int estatus = Convert.ToInt32(dtAsgin.Rows[i]["Estatus"]);
                if (tipo== "Orden") {

                    if (estatus == 4 || estatus == 5) {

                        lkbtn.Visible = true;

                    }
                    else
                    {

                        lkbtn.Visible = false;
                    }


                }
                else
                {
                    lkbtn.Visible = false;
                }



            }
        }

        protected void radGridPedidos_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if (e.CommandName == "ActaConford") {

                GridDataItem item = e.Item as GridDataItem;
                //int indx = e.Item.ItemIndex;
               // string nroPed = item.GetDataKeyValue("NroPedido").ToString();
                int nroOrden =  Convert.ToInt32(item.GetDataKeyValue("CodigoOC").ToString());
                Session["CodOCReport"] = Convert.ToString(nroOrden);
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "popitup('../Almacen/WFActaConformidad.aspx');", true);
            }
        }


        public int getOrdenNumber(int index) {
            int res = 0;
           // int nroPed = Convert.ToInt32(nroPedido);
            DataTable dtsession = Session["PedidosProceso"] as DataTable;
            

               

                

                    res = Convert.ToInt32(dtsession.Rows[index]["CodigoOC"]);

               

            return res;

        }

        protected void radGridPedidos_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {

            objPedido = new CBPedido();
            int codUser = Convert.ToInt32(Session["CodigoUsuario"].ToString());
            DataTable dtget = objPedido.GetPedidosEnProceso("1", codUser);
            objPedido = new CBPedido();
            DataTable dtPedido = objPedido.GetPedidosEnProceso("2", codUser);
            dtget.Merge(dtPedido);

            radGridPedidos.DataSource = dtget;
           
        }
    }
}
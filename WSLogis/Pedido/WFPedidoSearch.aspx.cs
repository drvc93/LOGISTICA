using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using ClassBusiness;
using WSLogis.Helper;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WSLogis.Pedido
{
    public partial class WFPedidoSearch : System.Web.UI.Page
    {
        CBPedido objPedido;
        CBProyecto objProyecto;
        CBCombo objCombo;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            { /**/
                CargarGrilla();
                CargarComboLocales();
                CargarComboProyecto();
                CargarComboEstado();
                
            }
        }

        public void CargarComboProyecto()
        {
            txtFechaHasta.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtFechaIni.Text = DateTime.Now.ToString("dd/MM/yyyy");
            objProyecto = new CBProyecto();
            int codUser = Convert.ToInt32(Session["CodigoUsuario"].ToString());
            ddlProyecto.DataSource = objProyecto.GetProyectos("3", codUser);
            ddlProyecto.DataValueField = "Codigo";
            ddlProyecto.DataTextField = "Proyecto";
            ddlProyecto.DataBind();
           


        }

        public void CargarComboEstado() { /**/

            objCombo = new CBCombo();
            ddlEstado.DataSource= objCombo.GetComboEstados("1");
            ddlEstado.DataValueField = "Codigo";
            ddlEstado.DataTextField = "Glosa";
            ddlEstado.DataBind();
            ddlEstado.Items.Insert(0, "--Seleccionar estado ---");

         }
        public void CargarComboLocales()
        {

            objPedido = new CBPedido();
            ddLocal.DataSource = objPedido.GetPedidos("4");
            ddLocal.DataValueField = "CodigoLocal";
            ddLocal.DataTextField = "Nombre";
            ddLocal.DataBind();
            ddLocal.Items.Insert(0, "--Seleccionar todo ---");



        }

        public void CargarGrilla() {
            int codUser = Convert.ToInt32(Session["CodigoUsuario"].ToString());
            objPedido = new CBPedido();
           DataTable dtPedidos = objPedido.GetPedidosEnProceso("3", codUser);
           objPedido = new CBPedido();
           DataTable var = objPedido.GetPedidosEnProceso("4", codUser);
           dtPedidos.Merge(var);

           if (dtPedidos != null && dtPedidos.Rows.Count>0) { /**/
            
           IEnumerable<DataRow> orderedRows = dtPedidos.AsEnumerable()
             .OrderByDescending(r => r.Field<DateTime>("FechaPedido"));
           dtPedidos = orderedRows.CopyToDataTable();
             gvPedidosProceso.DataSource = dtPedidos;
             gvPedidosProceso.DataBind();
           }
        }

       

        protected void gvPedidosProceso_DataBound(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gvPedidosProceso.Rows)
            {/**/
                string txtNroPedido = row.Cells[1].Text;
                LinkButton lkbtn = (LinkButton)row.FindControl("lkEditar");
                lkbtn.Attributes.Add("onclick", "window.open('WFPedidoEdit.aspx?NroPedido="+txtNroPedido+"', 'other', 'height=800,width=800px,navigationtoolbar=no,toolbar=no,menubar=no,left=150,top=180')");
            }
        }

        protected void btnFuncionRefresh_Click(object sender, EventArgs e)
        {
            if (Session["PedidoRegistrado"] != null) {

                this.ShowSuccessfulNotification("Pedido Registrado", 2000);
                Session["PedidoRegistrado"] = null;
                CargarGrilla();
                
                /**/}
            else {
                this.ShowErrorNotification("Error al registrar pedido", 2000);
                
                /**/}
        }
    }
}
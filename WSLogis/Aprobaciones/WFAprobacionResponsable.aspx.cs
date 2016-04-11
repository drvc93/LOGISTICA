using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ClassBusiness;
using WSLogis.Helper;

namespace WSLogis.Administracion
{
    public partial class WFAprobacionResponsable : System.Web.UI.Page
    {

        CBProyecto objProyecto;
        CBPedido objPedido;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) {

                CargarComboProyecto();
                CargarComboLocales();
                CargarComboEstado();
                CargarDataTable();

                if (Session["VarReload"] ==null) { /**/

                    CargarDataTable();
                }
                else if (  Convert.ToInt32( Session["VarReload"].ToString()) == 1) { /**/
                    CargarDataTable();
                    MostrarData();

                }

                if( Session["PedidoActualizado"]!=null){/**/

                    ShowNotification();
                    CargarDataTable();
                }


                
                

            
            }
        }

        public void CargarComboProyecto() {
            txtFechaHasta.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtFechaIni.Text = DateTime.Now.ToString("dd/MM/yyyy");
            objProyecto = new CBProyecto();
            int   codUser =   Convert.ToInt32( Session["CodigoUsuario"].ToString());
            ddlProyecto.DataSource= objProyecto.GetProyectos("3", codUser);
            ddlProyecto.DataValueField = "Codigo";
            ddlProyecto.DataTextField = "Proyecto";
            ddlProyecto.DataBind();
            

        }


        public void ShowNotification() { /**/
            this.ShowSuccessfulNotification("Se actualizo el estado del pedido", 2500);
            Session["PedidoActualizado"] = null;
        
        }
        public void CargarComboLocales() {

            objPedido = new CBPedido();
            ddLocal.DataSource = objPedido.GetPedidos("4");
            ddLocal.DataValueField = "CodigoLocal";
            ddLocal.DataTextField = "Nombre";
            ddLocal.DataBind();
            ddLocal.Items.Insert(0, "--Seleccionar todo ---");
          

        
        }

        public void CargarComboEstado() {

            objPedido = new CBPedido();
            ddlEstado.DataSource = objPedido.GetPedidos("5");
            ddlEstado.DataValueField = "CodigoEstatus";
            ddlEstado.DataTextField = "Estatus";
            ddlEstado.DataBind();
            ddlEstado.Items.Insert(0,"---Seleccionar Todos---");

        
        }


        

        public void CargarDataTable() {
            objPedido = new CBPedido();
            DataTable dtAllPedidos = objPedido.GetPedidosAprobacion("1", Session["CodigoUsuario"].ToString());
            Session["dtPedidosAprobacion"] = dtAllPedidos;
        
        }

        protected void ddLocal_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (ddLocal.SelectedIndex > 0) { /**/
            string query = "CodigoLocal=" + ddLocal.SelectedValue;
            SelectQueryDataTable(query);

            }
        }

        public void SelectQueryDataTable(string query ) {

            DataTable dtAllPedido = Session["dtPedidosAprobacion"] as DataTable;
            DataRow[] rows = dtAllPedido.Select(query);
            if (rows != null && rows.Count() > 0)
            {
                DataTable fileterDataTable = dtAllPedido.Select(query).CopyToDataTable();
                GridPedidosProceso.DataSource = fileterDataTable;
                GridPedidosProceso.DataBind();

                for (int i = 0; i < fileterDataTable.Rows.Count; i++)
                {/**/

                    int var = Convert.ToInt32(fileterDataTable.Rows[i]["Estatus_val"].ToString());
                    if (var == 0)
                    {/**/

                        LinkButton linkVer = GridPedidosProceso.Rows[i].FindControl("lkbtnVer") as LinkButton;
                        linkVer.Visible = false;
                    }

                }


            }

            else {
                this.ShowErrorNotification("No se encontro resultados con los parametros enviados", 2500);
            
            }
        }

        protected void ddlProyecto_SelectedIndexChanged(object sender, EventArgs e)
        {
           string query = "CodigoLocal="+ddLocal.SelectedValue + "AND CodigoProyecto=" +ddlProyecto.SelectedValue;
           SelectQueryDataTable(query);
        }

        protected void lkbtnVer_Click(object sender, EventArgs e)
        {   
            LinkButton lkbtnIr = sender as LinkButton;
            GridViewRow gridview = (GridViewRow)lkbtnIr.NamingContainer;
            Session["ParametroIdPedido"] = GridPedidosProceso.DataKeys[gridview.RowIndex].Value.ToString();
            //CargarPopupCabecera(Convert.ToInt32(Session["ParametroIdPedido"]));
            //ModalPopUp2.Show();

        }


        public void MostrarData() { /**/
            Session["VarReload"] = null;
            objPedido = new CBPedido();
            DataTable dtAllPedidos = objPedido.GetPedidosAprobacion("1", Session["CodigoUsuario"].ToString());
            Session["dtPedidosAprobacion"] = dtAllPedidos;
            GridPedidosProceso.DataSource = dtAllPedidos;
            GridPedidosProceso.DataBind();

            for (int i = 0; i < dtAllPedidos.Rows.Count; i++)
            {/**/

                int var = Convert.ToInt32(dtAllPedidos.Rows[i]["Estatus_val"].ToString());
                if (var == 0)
                {/**/

                    LinkButton linkVer = GridPedidosProceso.Rows[i].FindControl("lkbtnVer") as LinkButton;
                    linkVer.Visible = false;
                }

            }

            this.ShowSuccessfulNotification("Se actualizo  datos ", 2500);

        }

        public void ReloadDataGrid() { /**/
            Session["VarReload"] = 1;
            Response.Redirect(Request.RawUrl);

           
        }

        

       

        public int NextNivelAprobacion()
        { /**/
            int resNexNivel = -1;
            objPedido = new CBPedido();
            DataTable dtResul = objPedido.GetPedidosAprobacion("4", Session["CodigoUsuario"].ToString());
            int nivAproUser = GetNivelAprobacionUsuario();
             /**/

                if (dtResul != null && dtResul.Rows.Count > 0) { /**/


                    for (int i = 1; i < dtResul.Rows.Count; i++)
                    {/**/

                        if (Convert.ToInt32(dtResul.Rows[i-1]["CodigoNivelAprobacion"])==nivAproUser && i<dtResul.Rows.Count)
                        {/**/
                        
                            resNexNivel = Convert.ToInt32(dtResul.Rows[i]["CodigoNivelAprobacion"]);
                        
                        }

                        if (Convert.ToInt32(dtResul.Rows[i-1]["CodigoNivelAprobacion"]) == nivAproUser && i == dtResul.Rows.Count)
                        {/**/

                            resNexNivel = 4;

                        }

                    }
                }

                return resNexNivel;
            


        }

        public int GetNivelAprobacionUsuario()
        { /**/

            int res = -1;
            objPedido = new CBPedido();
            DataTable dtResul = objPedido.GetPedidosAprobacion("5", Session["CodigoUsuario"].ToString());
            if (dtResul != null && dtResul.Rows.Count > 0)
            { /**/

                res = Convert.ToInt32(dtResul.Rows[0]["CodigoNivelAprobacion"]);
        
            }

            return res;

        }


        
        

        

        public void ActualizarVB(int  codPed ,int VBresponsable ,string motivo,int sgtEstado) { /**/

            //int codPed = Convert.ToInt32(Session["ParametroIdPedido"]);
            //string motivo = txtComentario.Text;
            int userVB = Convert.ToInt32(Session["CodigoUsuario"].ToString());

            objPedido = new CBPedido();
            bool res =objPedido.ActualizarVBResponsable(codPed, VBresponsable, motivo, userVB,sgtEstado);



            if (res == true) { /**/

                if (VBresponsable == 1) { /**/

                    this.ShowSuccessfulNotification("Se aprobo el pedido", 2500);
                }

                else if (VBresponsable == 0) { /**/


                    this.ShowSuccessfulNotification("Se rechazo el pedido ", 2500);

                }

               
            }

            
        }

        protected void ddlEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlEstado.SelectedIndex > 0) { /**/
            string query = "Estatus_val=" + ddlEstado.SelectedValue;
            SelectQueryDataTable(query);
            }
        }

        protected void lkbtnBuscar_Click(object sender, EventArgs e)
        {
            if (txtIdPedido.Text.Length > 0) { /**/

                string query = "IdPedido=" + txtIdPedido.Text;
                    //"IdPedido like '%" + txtIdPedido.Text + "%'";
                SelectQueryDataTable(query);


            }


            else  if (txtFechaIni.Text != "" && txtFechaHasta.Text != "")
            {/**/
                int user = Convert.ToInt32(Session["CodigoUsuario"].ToString());
                objPedido = new CBPedido();
                DateTime fechaIni = Convert.ToDateTime(txtFechaIni.Text);
                DateTime fechaFin = Convert.ToDateTime(txtFechaHasta.Text);
                DataTable dtFilter = objPedido.GetPedidosAprobacionPorFechas("6", user, fechaIni, fechaFin);
                GridPedidosProceso.DataSource = dtFilter;
                GridPedidosProceso.DataBind();
                if (dtFilter != null || dtFilter.Rows.Count > 0)
                { /**/
                    for (int i = 0; i < dtFilter.Rows.Count; i++)
                    {/**/

                        int var = Convert.ToInt32(dtFilter.Rows[i]["Estatus_val"].ToString());
                        if (var == 0)
                        {/**/

                            LinkButton linkVer = GridPedidosProceso.Rows[i].FindControl("lkbtnVer") as LinkButton;
                            linkVer.Visible = false;
                        }

                    }

                }

            }
        }

        protected void lkbtnAprobarPedido_Click(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Si")
            {   /**/


                int codPed = Convert.ToInt32(Session["ParametroIdPedido"]);
                string motivo = "";
                int nEstatus = NextNivelAprobacion();
                ActualizarVB(codPed, 1, motivo, nEstatus);
                ReloadDataGrid();
                //this.ModalPopupExtender3.Hide();


            }
            //int codPed = Convert.ToInt32(Session["ParametroIdPedido"]);
            //string motivo = txtComentario.Text;
            //ActualizarVB(codPed, 0, motivo, 0);
            //ReloadDataGrid();
            //this.ModalPopupExtender3.Hide();
        }

        protected void lkbtnCancel_Click(object sender, EventArgs e)
        {
            
        }

        
        
    }
}
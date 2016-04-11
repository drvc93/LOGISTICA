using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ClassBusiness;
using WSLogis.Helper;
namespace WSLogis.Aprobaciones
{
    public partial class WFAprobacionNivel2 : System.Web.UI.Page
    {
        CBProyecto objProyecto;
        CBOrdenDeCompra objOrdenes;
        CBLocal objLocal;
        CBCombo objCombo;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                txtFechaIni.Text = DateTime.Now.ToString("dd/MM/yyyy");
                txtFechaHasta.Text = DateTime.Now.ToString("dd/MM/yyyy");
                CargarComboProyecto();
                CargarDatatable();
                CargarComboLocales();
                /**/

                if (Session["VarReload"] != null)
                { /**/

                    MostrarData();

                }
                else { /**/}

            }
        }

        public void CargarComboProyecto()
        { /**/
            objProyecto = new CBProyecto();
            int codUser = Convert.ToInt32(Session["CodigoUsuario"].ToString());
            ddlProyecto.DataSource = objProyecto.GetProyectos("3", codUser);
            ddlProyecto.DataValueField = "Codigo";
            ddlProyecto.DataTextField = "Proyecto";
            ddlProyecto.DataBind();
            ddlProyecto.Items.Insert(0, "--Seleccionar Proyecto ---");

        }

        public void CargarDatatable()
        { /**/

            objOrdenes = new CBOrdenDeCompra();
            int codUser = Convert.ToInt32(Session["CodigoUsuario"].ToString());
            DataTable dtOrdenes = objOrdenes.GetOrdenesPorAprobar("1", codUser);
            Session["dtOrdenesAll"] = dtOrdenes;

        }

        public void CargarComboEstado()
        { /**/

            objCombo = new CBCombo();
            ddlEstado.DataSource = objCombo.GetComboEstados("2");
            ddlEstado.DataValueField = "Codigo";
            ddlEstado.DataTextField = "Glosa";
            ddlEstado.DataBind();
            ddlEstado.Items.Insert(0, "--Seleccionar estado ---");

        }


        public void MostrarData()
        { /**/
            Session["VarReload"] = null;
            DataTable dtRes = Session["dtOrdenesAll"] as DataTable;
            gvListadoAP.DataSource = dtRes;
            gvListadoAP.DataBind();

            ValidarOdenesGVlistado(dtRes);
            this.ShowSuccessfulNotification("Se realizo la operacion correctamente", 2500);
        }

        public void CargarComboLocales()
        {

            objLocal = new CBLocal();
            DataTable dtLocal = objLocal.GetLocales("1", "0");
            ddLocal.DataSource = dtLocal;
            ddLocal.DataValueField = "CodigoLocal";
            ddLocal.DataTextField = "Nombre";
            ddLocal.DataBind();
            ddLocal.Items.Insert(0, "---Seleccionar Todos ---");
        }

        public void SelectQueryDataTable(string query)
        {

            DataTable dtAllPedido = Session["dtOrdenesAll"] as DataTable;
            DataRow[] rows = dtAllPedido.Select(query);
            if (rows != null && rows.Count() > 0)
            {
                DataTable fileterDataTable = dtAllPedido.Select(query).CopyToDataTable();
                gvListadoAP.DataSource = fileterDataTable;
                gvListadoAP.DataBind();
                ValidarOdenesGVlistado(fileterDataTable);



            }

            else
            {
                this.ShowErrorNotification("No se encontro resultados con los parametros enviados", 2500);

            }
        }

        public void ValidarOdenesGVlistado(DataTable dtOrdenes)
        {/**/

            for (int i = 0; i < dtOrdenes.Rows.Count; i++)
            {/**/

                int var = Convert.ToInt32(dtOrdenes.Rows[i]["Estatus_val"].ToString());
                LinkButton linkVer = gvListadoAP.Rows[i].FindControl("lkbtnVer") as LinkButton;
                if (var == 1)
                {/**/


                    linkVer.Visible = true;
                }
                else
                {
                    linkVer.Visible = false;
                }

            }

        }

        protected void ddLocal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddLocal.SelectedIndex > 0)
            { /**/
                string query = "CodigoLocal=" + ddLocal.SelectedValue;
                SelectQueryDataTable(query);

            }

        }

        protected void ddlProyecto_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (ddLocal.SelectedIndex > 0)
            { /**/
                string query = "CodigoProyecto=" + ddlProyecto.SelectedValue;
                SelectQueryDataTable(query);

            }

        }

        protected void lkbtnBuscar_Click(object sender, EventArgs e)
        {
            if (txtFechaIni.Text != "" && txtFechaHasta.Text != "")
            { /**/

                DateTime fechaIni = Convert.ToDateTime(txtFechaIni.Text);
                DateTime fechaFin = Convert.ToDateTime(txtFechaHasta.Text);
                int codUser = Convert.ToInt32(Session["CodigoUsuario"].ToString());
                objOrdenes = new CBOrdenDeCompra();
                DataTable dtOrd = objOrdenes.GetOrdenesPorAprobar("2", codUser, fechaIni, fechaFin);
                gvListadoAP.DataSource = dtOrd;
                gvListadoAP.DataBind();
                ValidarOdenesGVlistado(dtOrd);

            }
        }

        protected void lkbtnVer_Click(object sender, EventArgs e)
        {
            LinkButton lkbtnIr = sender as LinkButton;
            GridViewRow gridview = (GridViewRow)lkbtnIr.NamingContainer;
            Session["ParamIdOrden"] = gvListadoAP.DataKeys[gridview.RowIndex].Value.ToString();
            int codOrd = Convert.ToInt32(Session["ParamIdOrden"].ToString());
            CargarPopupCabecera(codOrd);
            CargarPopUpDetalle(codOrd);
            this.ModalPopUp2.Show();
        }


        public void CargarPopupCabecera(int codOrden)
        { /**/

            objOrdenes = new CBOrdenDeCompra();
            DataTable dtOrd = objOrdenes.GetCabceraOrden("3", codOrden);
            lblDescripcion.Text = dtOrd.Rows[0]["Descripcion"].ToString();
            lblIdOrden.Text = dtOrd.Rows[0]["IdOrden"].ToString();
            lblMoneda.Text = dtOrd.Rows[0]["Moneda"].ToString();
            lblProyecto.Text = dtOrd.Rows[0]["Proyecto"].ToString();
            lblTipoBien.Text = dtOrd.Rows[0]["Tipo"].ToString();
        }

        public void CargarPopUpDetalle(int codOrden)
        {

            objOrdenes = new CBOrdenDeCompra();
            GridDetalleOrden.DataSource = objOrdenes.GetOrdenDetalle("4", codOrden);
            GridDetalleOrden.DataBind();

        }

        protected void lkbtnCancel_Click(object sender, EventArgs e)
        {
            this.ModalPopUp2.Hide();
        }

        protected void lkbtnRechazarPed_Click(object sender, EventArgs e)
        {
            this.ModalPopupExtender3.Show();
        }

        protected void lkbtnAprobarPedido_Click(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Si")
            {
                int codOc = Convert.ToInt32(Session["ParamIdOrden"]);
                string motivoVB = "";

                string msj = VistoBueno(codOc, 1, motivoVB);

                this.ShowSuccessfulNotification(msj, 2500);

                this.ModalPopupExtender3.Hide();
                this.ModalPopUp2.Hide();
                ReloadDataGrid();
            }

        }


        public string VistoBueno(int codOrden, int vistoB, string motivoVB)
        { /**/
            string var = "";
            objOrdenes = new CBOrdenDeCompra();
            int codUser = Convert.ToInt32(Session["CodigoUsuario"].ToString());
            bool res = objOrdenes.VistoBuenoOrden(codOrden, vistoB, motivoVB, codUser);
            if (res == true)
            {

                var = "La operacion fue realizada";

            }

            else
            {/**/

                var = "No se pudo realizar la operacion";
            }

            return var;

        }

        protected void lkbtnAcepRazRechazo_Click(object sender, EventArgs e)
        {
            int codOc = Convert.ToInt32(Session["ParamIdOrden"]);
            string motivoVB = txtMotivoRechazo.Text;

            string msj = VistoBueno(codOc, 0, motivoVB);
            //this.ShowSuccessfulNotification(msj, 2500);
            this.ModalPopUp2.Hide();
            ReloadDataGrid();


        }

        public void ReloadDataGrid()
        { /**/
            Session["VarReload"] = 1;
            Response.Redirect(Request.RawUrl);


        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using WSLogis.Helper;
using ClassBusiness;

namespace WSLogis.Almacen
{
    public partial class WFRegistroIngresoPreview : System.Web.UI.Page
    {
        CBLocal objLocal;
        CBCombo objCombo;
        CBProyecto objProyecto;
        CBRecepcion objRecepcion;
        CBIngreso objIngreso;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            { /**/
                // Session["ParamCodigoOC"]
                //   Session["ParamCodRC"] = GridIngresos.DataKeys[gridview.RowIndex].Value.ToString();
                     //Session["ParamCodProducto"]
                if (Session["ParamCodRC"] != null && Session["ParamCodProducto"] != null)
                {
                    int codRC = Convert.ToInt32(Session["ParamCodRC"].ToString());
                    int codProd = Convert.ToInt32(Session["ParamCodProducto"].ToString());
                    GetDatosPreCargados(codRC, codProd);
                }

                txtFechaIngreso.Text = DateTime.Now.ToString("dd/MM/yyyy");
                CargarComboLocal();
                CargarComboProyecto();
                CargarComboComrpobante();
                CargarComboTipoExistencia();
                CargarComboOperacion();
                CargarComboFabricante();
                CargarComboUsuarios();
            }
        }


        public void CargarComboUsuarios()
        {

            objRecepcion = new CBRecepcion();
            DataTable dtComboUser = objRecepcion.OrdenesPorIngresar("3");
            ddUsuarioResponsable.DataSource = dtComboUser;
            ddUsuarioResponsable.DataValueField = "Codigo";
            ddUsuarioResponsable.DataTextField = "Descripcion";
            ddUsuarioResponsable.DataBind();
            ddUsuarioResponsable.Items.Insert(0, "Seleccione Usuario");
        }
        public void CargarComboLocal()
        { /**/

            objLocal = new CBLocal();

            DataTable dtLocal = objLocal.GetLocales("1", "0");
            ddLocal.DataSource = dtLocal;
            ddLocal.DataValueField = "CodigoLocal";
            ddLocal.DataTextField = "Nombre";
            ddLocal.DataBind();
            ddLocal.Items.Insert(0, "Seleccione local");


        }

        public void CargarComboProyecto()
        { /**/

            objProyecto = new CBProyecto();
            ddProyecto.DataSource = objProyecto.GetAllProyectos("4");
            ddProyecto.DataValueField = "Codigo";
            ddProyecto.DataTextField = "Proyecto";
            ddProyecto.DataBind();
            ddProyecto.Items.Insert(0, "Seleccione proyecto");

        }

        public void CargarComboComrpobante()
        { /**/

            objCombo = new CBCombo();
            ddTipComprobante.DataSource = objCombo.GetComboTipoComprobante();
            ddTipComprobante.DataValueField = "Codigo";
            ddTipComprobante.DataTextField = "Descripcion";
            ddTipComprobante.DataBind();
            ddTipComprobante.Items.Insert(0, "Seleccione Tipo de comprobante");


        }

        public void CargarComboTipoExistencia()
        { /**/

            objCombo = new CBCombo();
            ddTipExistencia.DataSource = objCombo.getCombos("1");
            ddTipExistencia.DataValueField = "Codigo";
            ddTipExistencia.DataTextField = "Descripcion";
            ddTipExistencia.DataBind();
            ddTipExistencia.Items.Insert(0, "Seleccione Tipo de existencia");

        }

        public void CargarComboOperacion()
        { /**/

            objCombo = new CBCombo();
            ddTipOperacion.DataSource = objCombo.getCombos("2");
            ddTipOperacion.DataValueField = "Codigo";
            ddTipOperacion.DataTextField = "Descripcion";
            ddTipOperacion.DataBind();
            ddTipOperacion.Items.Insert(0, "Seleccione Tipo de operacion");
          

        }

        public void CargarComboFabricante()
        {   
            objCombo = new CBCombo();
            ddlFabricante.DataSource = objCombo.getCombos("3");
            ddlFabricante.DataValueField = "Codigo";
            ddlFabricante.DataTextField = "Descripcion";
            ddlFabricante.DataBind();
            ddlFabricante.Items.Insert(0, "Seleccione Fabricante");
        }

        public void GetDatosPreCargados(int codRC, int codPro) {
            objRecepcion = new CBRecepcion();
            DataTable dtPrecargados = objRecepcion.OrdenesPorIngresar("2", codRC, codPro);
            lblNroOrden.Text = dtPrecargados.Rows[0]["NroOrden"].ToString();
            lblCodProducto.Text = dtPrecargados.Rows[0]["IdProducto"].ToString();
            lblProductoNom.Text = dtPrecargados.Rows[0]["Producto"].ToString();
            lblProveedor.Text = dtPrecargados.Rows[0]["Proveedor"].ToString();
            hideValue.Value = dtPrecargados.Rows[0]["CodigoProveedor"].ToString();

        }

        protected void ddTipComprobante_SelectedIndexChanged(object sender, EventArgs e)
        {
            int sizeCombo = ddTipComprobante.Items.Count;
            if(ddTipComprobante.SelectedIndex==sizeCombo-1)
            {

                txtOtroComprobante.Visible = true;
                lblOtroComprobante.Visible = true;
               
            }

            else 
            {
                txtOtroComprobante.Visible = false;
                lblOtroComprobante.Visible = false;
            
            }
        }

        protected void ddTipOperacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            int sizeCombo = ddTipOperacion.Items.Count;
            if (ddTipOperacion.SelectedIndex == sizeCombo - 1)
            {
               
                lblOtraOper.Visible = true;
                txtOtraOperacion.Visible = true;

            }

            else
            {
                txtOtraOperacion.Visible = false;
                lblOtraOper.Visible = false;

            }
        }

        public void InsertarIngreso()
        {
            string otroCompro = " ";
            string OtraOperacion = " ";

            int codOc = Convert.ToInt32(Session["ParamCodigoOC"].ToString());
            int codProduc = Convert.ToInt32(Session["ParamCodProducto"].ToString());
            int codLocal = Convert.ToInt32(ddLocal.SelectedValue);
            int codProy = Convert.ToInt32(ddProyecto.SelectedValue);
            int CodProveedor = Convert.ToInt32(hideValue.Value);
            int codFabricante = Convert.ToInt32(ddlFabricante.SelectedValue);
            string modelo = txtModelo.Text;
            string lote = txtNroLoteo.Text;
            int tempert = Convert.ToInt32(txtTemperaturaAlmc.Text);
            DateTime fechaIngres = Convert.ToDateTime(txtFechaIngreso.Text);
            DateTime fechaVenc = Convert.ToDateTime(txtFechaExpiracion.Text);
            int codTipExistenc = Convert.ToInt32(ddTipExistencia.SelectedValue);
            int codComprobante = Convert.ToInt32(ddTipComprobante.SelectedValue);
            otroCompro = txtOtroComprobante.Text;
            string serie = txtSerie.Text;
            string num = txtNumero.Text;
            int codTipoOpe = Convert.ToInt32(ddTipOperacion.SelectedValue);
            OtraOperacion = txtOtraOperacion.Text;
            int cantIngreso = Convert.ToInt32(txtCantIngreso.Text);
            int cantEgreso = cantIngreso;
            int codUsuario = Convert.ToInt32(ddUsuarioResponsable.SelectedValue);
            int UserReg = Convert.ToInt32(Session["CodigoUsuario"].ToString()); 
            
             objIngreso = new CBIngreso();

             string msj = objIngreso.InsertarIngreso(codOc, codProduc, codLocal, codProy, CodProveedor, codFabricante, modelo, lote, tempert, fechaIngres, fechaVenc, codTipExistenc, codComprobante, otroCompro, serie
                                                    , num, codTipoOpe, OtraOperacion, cantIngreso, cantEgreso, codUsuario, UserReg);
             Session["RegistroIngreso"] = msj;
             ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "refreshGridParent();", true);
             
        }

        protected void lkbtnGrabar_Click(object sender, EventArgs e)
        {

            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Si")
            {
                InsertarIngreso();
            }
           
        }
    }
}
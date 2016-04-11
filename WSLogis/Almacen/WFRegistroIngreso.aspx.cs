using System;
using System.Collections.Generic;
using System.Linq;
using ClassBusiness;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassBusiness;
using WSLogis.Helper;
using System.Data;

namespace WSLogis.Almacen
{
    public partial class WFRegistroIngreso : System.Web.UI.Page
    {

        CBProyecto objProyecto;
        CBLocal objLocal;
        CBCombo objCombo;
        CBRecepcion objRecepcion;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) { /**/
                CargarGrillaIngresos();
                CargarComboLocal();
                CargarComboProyecto();
                CargarComboEstado();
            }
        }

        public void CargarComboProyecto()
        { /**/


            objProyecto = new CBProyecto();
            ddlProyecto.DataSource = objProyecto.GetProyectos("3", Convert.ToInt32(Session["CodigoUsuario"]));
            ddlProyecto.DataValueField = "Codigo";
            ddlProyecto.DataTextField = "Proyecto";
            ddlProyecto.DataBind();
            ddlProyecto.Items.Insert(0, "-- Seleccionar todo --");


        }

        public void CargarComboLocal()
        { /**/

            objLocal = new CBLocal();
            ddLocal.DataSource = objLocal.GetLocales("1", "0");
            ddLocal.DataValueField = "CodigoLocal";
            ddLocal.DataTextField = "Nombre";
            ddLocal.DataBind();
            ddLocal.Items.Insert(0, " -- Seleccionar todo --");

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

        public void CargarGrillaIngresos()
        {
            objRecepcion = new CBRecepcion();
            GridIngresos.DataSource = objRecepcion.OrdenesPorIngresar("1");
            GridIngresos.DataBind();
        
        }

        protected void lkbtnIngresar_Click(object sender, EventArgs e)
        {
            LinkButton btnAsig = sender as LinkButton;
            GridViewRow gridview = (GridViewRow)btnAsig.NamingContainer;
            Session["ParamCodRC"] = GridIngresos.DataKeys[gridview.RowIndex].Value.ToString();
            Session["ParamCodProducto"] = GridIngresos.Rows[gridview.RowIndex].Cells[3].Text;
            Session["ParamCodigoOC"] = GridIngresos.Rows[gridview.RowIndex].Cells[1].Text;
           
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "popitup('WFRegistroIngresoPreview.aspx');", true);
        }

        protected void btnrefreshGrid_Click(object sender, EventArgs e)
        {
            if (Session["RegistroIngreso"].ToString() !=null) 
            {
                this.ShowSuccessfulNotification(Session["RegistroIngreso"].ToString(), 2000);
                Session["RegistroIngreso"] = null;
            }
            //this.ShowSuccessfulNotification(msj, 2000);
            CargarGrillaIngresos();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ClassBusiness;
using WSLogis.Helper;

namespace WSLogis.Almacen
{
    public partial class WFRecepcion : System.Web.UI.Page
    {

        CBProyecto objProyecto;
        CBLocal objLocal;
        CBOrdenDeCompra objOrdenCompra;
        CBCombo objCombo;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarComboProyecto();
                CargarComboLocal();
                CargarOCRecepcion();
                CargarComboEstado();
                Page.GetPostBackEventReference(Page);
                /**/
            }
        }

        public void CargarComboProyecto() { /**/

            
            objProyecto = new CBProyecto();
            ddlProyecto.DataSource = objProyecto.GetProyectos("3", Convert.ToInt32(Session["CodigoUsuario"]));
            ddlProyecto.DataValueField = "Codigo";
            ddlProyecto.DataTextField = "Proyecto";
            ddlProyecto.DataBind();
            ddlProyecto.Items.Insert(0, "-- Seleccionar todo --");

        
        }

        public void CargarComboLocal ()
        { /**/

            objLocal = new CBLocal();
            ddLocal.DataSource = objLocal.GetLocales("1", "0");
            ddLocal.DataValueField = "CodigoLocal";
            ddLocal.DataTextField = "Nombre";
            ddLocal.DataBind();
            ddLocal.Items.Insert(0, " -- Seleccionar todo --");
        
        }

        public void CargarOCRecepcion() { /**/

            objOrdenCompra = new CBOrdenDeCompra();
            DataTable dtOc = objOrdenCompra.GetOrdenesDeCompraRecepcion();
            GridOCRecepcionar.DataSource = dtOc;
            GridOCRecepcionar.DataBind();
            AsiganarValoresTemplateRows(dtOc);
        
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

        public void AsiganarValoresTemplateRows(DataTable dtable)
        {

            if (dtable != null && dtable.Rows.Count > 0)
            {/**/

                for (int i = 0; i < dtable.Rows.Count; i++)
                {
                        LinkButton lkbtnRecep = GridOCRecepcionar.Rows[i].FindControl("lkbtnRecepcion") as LinkButton;
                        int val =  Convert.ToInt32( dtable.Rows[i]["EstatusVal"].ToString());
                        if (val != 2) { /**/

                            lkbtnRecep.Visible = false;
                        
                        }

                   

                }

            }


        }

        protected void ddLocal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddLocal.SelectedIndex > 0) { /**/

                objOrdenCompra = new CBOrdenDeCompra();
                DataTable dtRes = objOrdenCompra.GetOrdenesDeCompraRecepcion("4", Convert.ToInt32(ddLocal.SelectedValue), 0);

                if (dtRes.Rows.Count == 0 || dtRes == null)
                { /**/

                    this.ShowErrorNotification("No se encontro resultados con los parametros enviados", 2000);

                }

                else
                
                {
                    GridOCRecepcionar.DataSource = dtRes;
                    GridOCRecepcionar.DataBind();
                    AsiganarValoresTemplateRows(dtRes);
                }

               

                 
            }
        }

        protected void ddlProyecto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlProyecto.SelectedIndex > 0)
            { /**/

                objOrdenCompra = new CBOrdenDeCompra();

                DataTable dtRes = objOrdenCompra.GetOrdenesDeCompraRecepcion("4",0, Convert.ToInt32(ddlProyecto.SelectedValue));

                if (dtRes.Rows.Count == 0 || dtRes == null) { /**/

                    this.ShowErrorNotification("No se encontro resultados con los parametros enviados", 2000);

                }

                else 
                { /**/
                GridOCRecepcionar.DataSource = dtRes;
                GridOCRecepcionar.DataBind();
                AsiganarValoresTemplateRows(dtRes);
                }

            }
        }

        protected void lkbtnRecepcion_Click(object sender, EventArgs e)
        {
            LinkButton boton = sender as LinkButton;
            GridViewRow gridview = (GridViewRow)boton.NamingContainer;
            Session["ParCodOc"] = GridOCRecepcionar.DataKeys[gridview.RowIndex].Value.ToString();
        }

        protected void btnUpdateGrid_Click(object sender, EventArgs e)
        {
            CargarOCRecepcion();
            this.ShowSuccessfulNotification("Se realizo la operacion correctamente ", 2500);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassBusiness;
using System.Data;
using System.Drawing;
using WSLogis.Helper;


namespace WSLogis.Administracion
{
    public partial class WFProductoSearch : System.Web.UI.Page
    {
        #region Atributos

        string  productoid = "";
        CBCategoria objCategoria = new CBCategoria();
        CBPresentacion objPresentacion = new CBPresentacion();
        CBConcentracion objConcetracion = new CBConcentracion();
        CBUnidad objUnidad = new CBUnidad();
        CBProducto objProducto = new CBProducto();
        string strCod;
        string strDes;

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Page.Title = "Productos";
                ListaProductos();
                CargarComboCategoria();
                

               // btnTest.Attributes.Add("onClick", "window.open('WFProductoNew.aspx','width=650,height=480,scrollbars=no");
            }
        }

       

       
        public void ReloadPage()
        {
            ListaProductos();
        }


        public void CargarComboCategoria()
        {


            if (ddlCategoria.Items.Count >= 0)
            {

                objCategoria = new CBCategoria();
                ddlCategoria.DataSource = objCategoria.GetCategoria();

                ddlCategoria.DataValueField = "Codigo";
                ddlCategoria.DataTextField = "Descripcion";
                ddlCategoria.DataBind();
                ddlCategoria.Items.Insert(0, "Seleccione Categoria");
                ddlSubCategoria.Items.Insert(0, "----- Selecionar Todo ------");

            }

           }
        
       
        

        protected void gridProductos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridProductos.PageIndex = e.NewPageIndex;
            gridProductos.DataBind();
            ListaProductos();
        }

        
        protected void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            ListaProductos();
        }

        public void ListaProductos()
        {
            DataTable dtLista = objProducto.GetProductosPorNombre(txtBuscar.Text);

            if (dtLista.Rows.Count > 0)
            {
                gridProductos.Visible = true;
                gridProductos.DataSource = dtLista;
                gridProductos.DataBind();
                gridProductos.SelectedIndex = -1;

            }
            else
            {
              
                gridProductos.Visible = false;
            }
        }

        protected void btnEditP_Click(object sender, EventArgs e)
        {
            LinkButton boton = sender as LinkButton;
            GridViewRow gridview = (GridViewRow)boton.NamingContainer;
            productoid = gridProductos.DataKeys[gridview.RowIndex].Value.ToString();
            // ModalPopup1Ext.BackgroundCssClass = "modalBG";
            Session["ProductoID"] = productoid;
          
        }

        public void CargarSubCategoria (int cod)
        {
            objCategoria = new CBCategoria();
            ddlSubCategoria.DataSource = objCategoria.GetSubCategoria(cod);
            ddlSubCategoria.DataValueField = "Codigo";
            ddlSubCategoria.DataTextField = "Descripcion";
            ddlSubCategoria.DataBind();
            ddlSubCategoria.Items.Insert(0, "----- Selecionar Todo ------");

        }

       
        protected void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            ListaProductos();
        }

      
        protected void btnNuevoProduct_Click(object sender, EventArgs e)
        {
            
            
            
            Session["ProductoID"] = null;
          
            
          

           
        
        }

        protected void ddlCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCategoria.SelectedIndex>0)
            {

                CargarSubCategoria( Convert.ToInt32(ddlCategoria.SelectedValue));

            }


        }

        protected void ddlSubCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            objProducto = new CBProducto();
            if (ddlCategoria.SelectedIndex > 0 && ddlSubCategoria.SelectedIndex > 0) 
            { 

            int valueCategoria = Convert.ToInt32(ddlCategoria.SelectedValue);
            int valueSubCategoria = Convert.ToInt32(ddlSubCategoria.SelectedValue);
              gridProductos.DataSource = objProducto.GetProductosPorCategoria("7", valueCategoria, valueSubCategoria);
              gridProductos.DataBind();
            }


        }
    }
}
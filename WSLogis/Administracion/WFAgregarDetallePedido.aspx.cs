using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using ClassBusiness;
using System.Web.UI.WebControls;
using WSLogis.Helper;

namespace WSLogis.Administracion
{
    public partial class WFAgregarDetallePedido : System.Web.UI.Page
    {
        CBCategoria objCategoria;
        CBProducto objProducto;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarPopUpComboCategoria();
                lkbtnAgregarProd.Enabled = false;
                
            }
        }


        public void CargarPopUpComboCategoria()
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

        public void CargarPopUpSubCateg(int cod)
        {

            objCategoria = new CBCategoria();
            ddlSubCategoria.DataSource = objCategoria.GetSubCategoria(cod);
            ddlSubCategoria.DataValueField = "Codigo";
            ddlSubCategoria.DataTextField = "Descripcion";
            ddlSubCategoria.DataBind();
            ddlSubCategoria.Items.Insert(0, "----- Selecionar Todo ------");
            FiltrarProductos("4", cod, 0);

        }

        public void FiltrarProductos(string accion, int codCategoria, int codSubCate)
        {

            objProducto = new CBProducto();
            GridSelectItems.DataSource = objProducto.GetProductosPorCategoria(accion, codCategoria, codSubCate);
            GridSelectItems.DataBind();


        }

        protected void ddlCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCategoria.SelectedIndex > 0) { /**/

                CargarPopUpSubCateg(Convert.ToInt32(ddlCategoria.SelectedValue));
               
            }
            else if (ddlCategoria.SelectedIndex <= 0) {

                GridSelectItems.DataSource = null;
                GridSelectItems.DataBind();
                /**/}
        }

        protected void ddlSubCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlSubCategoria.SelectedIndex > 0 && ddlCategoria.SelectedIndex >0)
            {


                FiltrarProductos("4", Convert.ToInt32(ddlCategoria.SelectedItem.Value), Convert.ToInt32(ddlSubCategoria.SelectedItem.Value));
               
            } 
        }

        protected void lkbtnAgregarProd_Click(object sender, EventArgs e)
        {

            DataTable DTAll = null;
            DataTable dtSesion = Session["dtProductos"] as DataTable;



            if (dtSesion == null)
            {

                DTAll = DTItemsSeleccionados();

            }

            else if (dtSesion.Rows.Count >= 0)
            {

                DTAll = dtSesion;
                DTAll.Merge(DTItemsSeleccionados());

            }



           
            Session["dtProductos"] = DTAll;

            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "refreshGridParent();", true);
           // AsiganarValoresTextBox(DTAll);
       
        }

        

        public DataTable CrearDataTable()
        {


            DataTable dtDetalle = new DataTable();

            dtDetalle.Columns.AddRange(new DataColumn[5] { new DataColumn("IdProducto", typeof(int)), new DataColumn("Producto", typeof(string)), new DataColumn("SubTotal", typeof(string)), new DataColumn("Cantidad", typeof(string)), new DataColumn("Precio", typeof(string)) });


            return dtDetalle;

        }

        public DataTable DTItemsSeleccionados()
        {

            DataTable resultDT = CrearDataTable();

            foreach (GridViewRow row in GridSelectItems.Rows)
            {

                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox checkBox = row.FindControl("checkCantidadRowPopUp") as CheckBox;

                    if (checkBox.Checked == true)
                    {

                        TextBox texCantidad = row.FindControl("txtRowCantidadPopUp") as TextBox;
                        TextBox textPrecio = row.FindControl("txtRowPrecioPopUp") as TextBox;
                        string var_precio = String.Format("{0:0.00}", Convert.ToDouble( textPrecio.Text));
                        string IdProducto = GridSelectItems.DataKeys[row.RowIndex].Values[0].ToString();// GridSelectItems.Rows[row.RowIndex].Cells[0].Text;
                        string Descripcion = GridSelectItems.Rows[row.RowIndex].Cells[1].Text;
                         decimal var_calc = Convert.ToInt32(texCantidad.Text) * Convert.ToDecimal(var_precio);
                         string subtotal = String.Format("{0:0.00}", Convert.ToString(var_calc));
                            
                        resultDT.Rows.Add(Convert.ToInt32(IdProducto), Descripcion, subtotal, texCantidad.Text, var_precio);

                        //dt.Rows.Add(idpro, descrip, subtotal,cant,precio);



                    }
                    // do somthing with the text box textBox
                }


            }


            return resultDT;


        }

     

        protected void txtRowCantidadPopUp_TextChanged(object sender, EventArgs e)
        {
            TextBox texcant = sender as TextBox;
            int outnum = 0;
             bool res =Int32.TryParse(texcant.Text, out outnum);

             if (res == true) { /**/
                 if (outnum <= 0) { /**/

                     this.ShowErrorNotification("La cantidad ingresada debe ser mayor a 0", 2000);
                     texcant.Text = "1";
                 
                 }
              
             }
             else { /**/

                 this.ShowErrorNotification("Ingrese una cantidad correcta", 2000);
                 
             }

             
        }

        public int ValidarSeleccionDeItem() { 
              
             int cont =0;
             if (GridSelectItems.Rows.Count>0){/**/

                 for (int i = 0; i < GridSelectItems.Rows.Count; i++) { /**/

                   CheckBox chkSelected =   GridSelectItems.Rows[i].FindControl("checkCantidadRowPopUp") as CheckBox;
                   if (chkSelected.Checked == true) {

                       cont = cont + 1;
                        
                       /**/}

                 }
             
             }

             return cont;
        }

        protected void checkCantidadRowPopUp_CheckedChanged(object sender, EventArgs e)
        {

            int var_result = ValidarSeleccionDeItem();

            if(var_result>0){

                lkbtnAgregarProd.Enabled = true;

                }
            else if (var_result <= 0) {

                lkbtnAgregarProd.Enabled = false;
                
                /**/}
        }

        protected void GridSelectItems_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DataTable dt = GridSelectItems.DataSource as DataTable;
            GridSelectItems.PageIndex = e.NewPageIndex;
            GridSelectItems.DataBind();
            LoadDataPagin();
            
          

        }

        public void  LoadDataPagin(){


             if(ddlCategoria.SelectedIndex>0 &&  ddlSubCategoria.SelectedIndex <= 0)
             { /**/

                 FiltrarProductos("4", Convert.ToInt32(ddlCategoria.SelectedValue), 0);
             }
             else if (ddlSubCategoria.SelectedIndex > 0 && ddlCategoria.SelectedIndex > 0) {

                 FiltrarProductos("4", Convert.ToInt32(ddlCategoria.SelectedValue), Convert.ToInt32(ddlSubCategoria.SelectedIndex));

             }

             else if (ddlSubCategoria.SelectedIndex <= 0 && ddlCategoria.SelectedIndex <= 0 && txtDescripBuscar.Text.Length > 0) {

                 FiltrarPorDescripcion();
                   
                 /**/}



       /**/}

        protected void txtDescripBuscar_TextChanged(object sender, EventArgs e)
        {
             
            FiltrarPorDescripcion();
        }

        public void FiltrarPorDescripcion() {

            objProducto = new CBProducto();
            GridSelectItems.DataSource = objProducto.GetProductosPorDescripcion("6", txtDescripBuscar.Text.ToUpper());
            GridSelectItems.DataBind();
          
        }

        
    }
}
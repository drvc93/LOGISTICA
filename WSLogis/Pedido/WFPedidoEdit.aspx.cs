using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI;
using AjaxControlToolkit;
using System.Data;
using ClassBusiness;
using Telerik.Web.UI;
using WSLogis.Helper;//using System.Web.Mail;
using System.Net;
using System.Net.Mail;


namespace WSLogis.Pedido
{
	public partial class WFPedidoEdit : System.Web.UI.Page
	{
        CBPedido objPedido;
        CBProyecto objProyecto;
        CBLocal objLocal;
        CBCategoria objCategoria;
        CBProducto objProducto;
        CBCombo objCombo;


        protected void Page_Load(object sender, EventArgs e)
        {
            //btnFunction.Attributes.Add("onclick", "return MyConfirmMethod();");
            if (!Page.IsPostBack)
            {


                Page.Title = "Registro de Pedido";
                CargarMonedas();
                CarcarLocales();
                CargarProyectos();
                // EnviarCorreo();
                Page.GetPostBackEventReference(Page);


                if (Request.QueryString["NroPedido"]!=null)
                {

                    string nroped = Request.QueryString["NroPedido"].ToString();
                    Page.Title = "Editar Pedido Nro. :" + nroped;
                    CargarDatosPedidoEdit(Convert.ToInt32(nroped));
                 }
                else {
                    Page.Title = "Nuevo Pedido";
                 
                }

                if (Session["PedidoRegistrado"] != null)
                { /**/

                    this.ShowSuccessfulNotification("Pedido Registrado", 2000);
                    Session["PedidoRegistrado"] = null;

                }
                else { /**/}


            }


        }




        public void CargarDataTableSession()
        { /**/

            DataTable dtsession = Session["dtProductos"] as DataTable;

            GridItems.DataSource = dtsession;
            GridItems.DataBind();
            AsiganarValoresTextBox(dtsession);


        }

        public void CargarMonedas()
        {


            objPedido = new CBPedido();
            ddMoneda.DataSource = objPedido.GetMonedas();
            ddMoneda.DataValueField = "Codigo";
            ddMoneda.DataTextField = "Descripcion";
            ddMoneda.DataBind();
            ddMoneda.Items.Insert(0, "Seleccione Moneda");

        }

        public void CargarProyectos()
        {

            objProyecto = new CBProyecto();
            DataTable dtProyectos = objProyecto.GetProyectos("3", Convert.ToInt32(Session["CodigoUsuario"]));
            ddProyecto.DataSource = dtProyectos;
            ddProyecto.DataValueField = "Codigo";
            ddProyecto.DataTextField = "Proyecto";
            ddProyecto.DataBind();
            ddProyecto.Items.Insert(0, "Seleccione Proyecto");
            // radComboCodigos.Items.Insert(0 ," No hay proyecto seleccionado");
            //radComboCodigos.DataBind();
            radComboCodigos.DataSource = dtProyectos;
            radComboCodigos.DataValueField = "Codigo";
            radComboCodigos.DataTextField = "Proyecto";
            radComboCodigos.DataBind();
           
        }

        public void CarcarLocales()
        {

            objLocal = new CBLocal();
            ddLocal.DataSource = objLocal.GetLocales("1", "0");
            ddLocal.DataValueField = "CodigoLocal";
            ddLocal.DataTextField = "Nombre";
            ddLocal.DataBind();
            ddLocal.Items.Insert(0, "Seleccione Local");

        }

        protected void btnAddItem_Click(object sender, EventArgs e)
        {

           
        }



        public bool VerificardatosCompletos() {
            bool res = false;
            if (ddLocal.SelectedIndex == 0) 
            { /**/

                res = false;
            }
            else if (ddMoneda.SelectedIndex==0) 
            {/**/
                res = false;
            }

            else if (ddProyecto.SelectedIndex == 0) { /**/

                res = false;
                 
             }

            else if (radGirdCodigosSeleccionados.Items.Count<=0)
            {
                res = false;
            }
            else if (GridItems.Rows.Count <= 0) {

                res = false;
            }

            else {
                res = true;
            }

            return res;
        
        }




        protected void GridSelectItems_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {



        }












        public void AsiganarValoresTextBox(DataTable dtable)
        {

            if (dtable != null && dtable.Rows.Count > 0)
            {/**/

                for (int i = 0; i < dtable.Rows.Count; i++)
                {

                    TextBox txtPrecio = GridItems.Rows[i].FindControl("txtPrecioRow") as TextBox;
                    txtPrecio.Text = dtable.Rows[i]["Precio"].ToString();
                    TextBox txtCantidad = GridItems.Rows[i].FindControl("txtRowCantidad") as TextBox;
                    txtCantidad.Text = dtable.Rows[i]["Cantidad"].ToString();
                    FilteredTextBoxExtender filtTex = new AjaxControlToolkit.FilteredTextBoxExtender();

                    filtTex.TargetControlID = txtPrecio.ID;
                    filtTex.FilterMode = FilterModes.ValidChars;
                    filtTex.ValidChars = "1234567890.";

                }

            }


        }

        public DataTable CrearDataTable()
        {


            DataTable dtDetalle = new DataTable();

            dtDetalle.Columns.AddRange(new DataColumn[5] { new DataColumn("IdProducto", typeof(int)), new DataColumn("Producto", typeof(string)), new DataColumn("SubTotal", typeof(string)), new DataColumn("Cantidad", typeof(string)), new DataColumn("Precio", typeof(string)) });


            return dtDetalle;

        }






        protected void btnSiguiente_Click(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            string char_var = confirmValue.Substring(confirmValue.Length - 2, 2);
            if (char_var == "Si")
            {
                if (VerificardatosCompletos() == true) 
                { /**/

                int cod = InsertarCabecera();
                if (cod > 0)
                {
                    InsertarDetalles(cod);
                    Session["dtProductos"] = null;
                    Session["PedidoRegistrado"] = 1;
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "refreshGridParent();", true);
                   // Response.Redirect("~/Administracion/RegistrarPedido.aspx");

                }

                }

                else { /**/

                    this.ShowErrorNotification("Faltan Registrar datos", 2000);
                }
            }
            else
            {
               
            }
        }


        public void EnviarCorreo()
        { /**/
            MailMessage o = new MailMessage("drvc93@gmail.com", "drvc_1993@hotmail.com", "Pedido ", "Se hizo una nueva solicitud de pedido");
            NetworkCredential netCred = new NetworkCredential("drvc93@gmail.com", "danivicr093");
            SmtpClient smtpobj = new SmtpClient("smtp.gmail.com", 587);
            smtpobj.EnableSsl = true;
            smtpobj.Credentials = netCred;
            smtpobj.Send(o);


        }

        protected void ddProyecto_SelectedIndexChanged(object sender, EventArgs e)
        {

        }




        public int InsertarCabecera()
        {

            int codTipoPedido = TipoPedido();
            int codLocal = Convert.ToInt32(Session["CodigoLocal"].ToString());
            int codLocalEntrega = Convert.ToInt32(ddLocal.SelectedValue);
            int codProyecto = Convert.ToInt32(ddProyecto.SelectedValue);
            int codMoneda = Convert.ToInt32(ddMoneda.SelectedValue);
            string descrip = txtDescripcion.Text;
            int codUser = Convert.ToInt32(Session["CodigoUsuario"].ToString());
            int donacion = IfIsDonacion();
            objPedido = new CBPedido();

            return objPedido.InsertarPedidoCabecera(codTipoPedido, codLocal, codLocalEntrega, codProyecto, codMoneda, descrip, 1, 1, codUser,donacion);


        }

        public int  IfIsDonacion() { /**/
            int res = -1;
            if (chkDonacion.Checked == true) {

                res = 1;
                /**/}

            else {
                res = 0;
            }

            return res;
        
        }

        public void InsertarDetalles(int cod)
        {

            int result = 0;

            for (int i = 0; i < GridItems.Rows.Count; i++)
            {

                int codProduc = Convert.ToInt32(GridItems.DataKeys[i].Values[0].ToString());
                TextBox precio = GridItems.Rows[i].FindControl("txtPrecioRow") as TextBox;
                TextBox cantidad = GridItems.Rows[i].FindControl("txtRowCantidad") as TextBox;
                FileUpload fileimg1 = GridItems.Rows[i].FindControl("ruta1") as FileUpload;
                string img1 = "--";// System.IO.Path.GetFullPath(fileimg1.PostedFile.FileName);
                FileUpload fileimg2 = GridItems.Rows[i].FindControl("ruta2") as FileUpload;

                string img2 = "--"; //System.IO.Path.GetFullPath(fileimg2.PostedFile.FileName);

                GuardarImagenes(fileimg1, fileimg1.FileName);
                GuardarImagenes(fileimg2, fileimg2.FileName);

                int codUser = Convert.ToInt32(Session["CodigoUsuario"].ToString());
                objPedido = new CBPedido();
                objPedido.InsertarDteallePedido(cod, codProduc, Convert.ToInt32(cantidad.Text), Decimal.Parse(precio.Text), img1, img2, 1, 1, codUser);
                result = result + 1;

            }

            if (result == GridItems.Rows.Count)
            {

                InsertarCodigosPresupuestal(cod);
                this.ShowSuccessfulNotification("Se registro correctamente el pedido ", 3000);

            }

            else
            {
                this.ShowErrorNotification("Error al registrar Pedido", 3000);
            }

        }


        public void InsertarCodigosPresupuestal(int codPedido)
        {
            int codUser = Convert.ToInt32(Session["CodigoUsuario"].ToString());

            for (int i = 0; i < radGirdCodigosSeleccionados.Items.Count;i++ )
            {/**/
                GridDataItem item = radGirdCodigosSeleccionados.Items[i];
                string codPresupuesto = item["Presupuesto"].Text;
                TextBox textrow = item.FindControl("txtPorcentItem") as TextBox;
                 decimal porcentcod = Convert.ToDecimal(textrow.Text);
                objPedido = new CBPedido();
                objPedido.InsertarCodigosPresupuestal(codPedido, codPresupuesto, codUser, porcentcod);

            }



        }




        public int TipoPedido()
        {


            int result = 3;

            if (rbtnCompra.Checked == true)
            {

                result = 1;
            }

            else if (rbtnServicio.Checked == true)
            {
                result = 2;

            }

            return result;
        }




        public void GuardarImagenes(FileUpload file1, string path)
        {

            if (path.Length > 1)
            {
                file1.SaveAs(MapPath("~/Images/" + file1.FileName));


            }

            else
            {


            }


        }

        protected void txtRowCantidad_TextChanged(object sender, EventArgs e)
        {
            TextBox btnCant = sender as TextBox;
            GridViewRow gridview = (GridViewRow)btnCant.NamingContainer;

            if (Convert.ToInt32(btnCant.Text) > 0)
            {
                int index = gridview.RowIndex;
                TextBox precio = GridItems.Rows[index].FindControl("txtPrecioRow") as TextBox;

                decimal newsubTotal = Convert.ToInt32(btnCant.Text) * Convert.ToDecimal(precio.Text);

                DataTable var_dtGrid = Session["dtProductos"] as DataTable;

                var_dtGrid.Rows[index]["SubTotal"] = Convert.ToString(newsubTotal);
                var_dtGrid.Rows[index]["Cantidad"] = Convert.ToString(btnCant.Text);
                var_dtGrid.Rows[index]["Precio"] = Convert.ToString(precio.Text);
                GridItems.DataSource = var_dtGrid;
                GridItems.DataBind();

                AsiganarValoresTextBox(var_dtGrid);
                Session["dtProductos"] = var_dtGrid;
            }


            else if (Convert.ToInt32(btnCant.Text) <= 0)
            {
                btnCant.Text = "1";
                this.ShowErrorNotification("Ingrese una cantidad mayor a 0", 2500);



            }


        }




        protected void lkbtnEliminarItem_Click(object sender, EventArgs e)
        {

            LinkButton boton = sender as LinkButton;
            GridViewRow gridview = (GridViewRow)boton.NamingContainer;
            DataTable dtrows = Session["dtProductos"] as DataTable;
            dtrows.Rows.RemoveAt(gridview.RowIndex);
            GridItems.DataSource = dtrows;
            GridItems.DataBind();
            AsiganarValoresTextBox(dtrows);
            Session["dtProductos"] = dtrows;

        }


        protected void btnFunction_Click(object sender, EventArgs e)
        {

            CargarDataTableSession();
            // ClientScript.GetPostBackEventReference(panelCab, "");
        }

        protected void txtItemPorcentajeRow_TextChanged(object sender, EventArgs e)
        {
            TextBox texpor = sender as TextBox;
            string var_texbox = "0";
            if (texpor.Text != "")
            { /**/

                var_texbox = texpor.Text;
            }


            decimal porcActual = VerificarPorcentajeCodigos();
            decimal porcIngresado = Convert.ToDecimal(var_texbox);
            if ((porcActual) > 100)
            {/**/

                this.ShowErrorNotification("La suma de porcentaje de los codigos no debe superar el 100%", 2500);

            }

            else if (porcActual > 0 && porcActual < 100)
            {/**/

                this.ShowErrorNotification("La suma de porcentaje de los codigos debe ser igual al 100%", 2000);
            }


        }



        public decimal VerificarPorcentajeCodigos()
        { /**/

            decimal porc = 0;

            string var_val = "0";
            foreach (RadComboBoxItem radcheked in radComboCodigos.CheckedItems)
            {/**/

                //TextBox myBox = (TextBox)myItem.FindControl("TextBox1");
                TextBox txtprocent = radcheked.FindControl("txtItemPorcentajeRow") as TextBox;
                if (txtprocent.Text == "")
                { /**/
                    var_val = "0";
                }
                else
                { /**/

                    var_val = txtprocent.Text;
                }
                porc = porc + Convert.ToDecimal(var_val); /**/

            }

            return porc;

        }

        protected void lkbtnSeleccionarCodigo_Click(object sender, EventArgs e)
        {
            Session["dtPersist"] = AsignarTexboxValuesDatatable();
            if (radComboCodigos.SelectedIndex != -1)
            { /**/
                int codProyecto = Convert.ToInt32(radComboCodigos.SelectedValue);
                Session["ValorCombo"] = codProyecto;
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "showCodigos('../Administracion/WFSeleccionarCodigo.aspx');", true);
            }

            else
            {
                Session["ValorCombo"] = null;
                this.ShowErrorNotification("Primero debe seleccionar un proyecto", 2000);
            }


        }

        protected void btnFuncCodigos_Click(object sender, EventArgs e)
        {
            if (Session["dtPersist"] == null)
            { /**/

                DataTable dtcodigosSelec = Session["dtCodigosSelect"] as DataTable;
                radGirdCodigosSeleccionados.DataSource = dtcodigosSelec;
                radGirdCodigosSeleccionados.DataBind();
                Session["dtPersist"] = dtcodigosSelec;

            }
            else if (Session["dtPersist"] != null)
            { /**/

                DataTable dtcodigosSelec = Session["dtCodigosSelect"] as DataTable;
                DataTable dtpersist = Session["dtPersist"] as DataTable;
                dtpersist.Merge(dtcodigosSelec);
                radGirdCodigosSeleccionados.DataSource = dtpersist;
                radGirdCodigosSeleccionados.DataBind();

            }
            radGirdCodigosSeleccionados.Visible = true;
        }

        public DataTable AsignarTexboxValuesDatatable()
        { /**/

            DataTable dtres = null;
            if (radGirdCodigosSeleccionados.Items.Count > 0)
            { /**/
                DataTable dtSession = Session["dtPersist"] as DataTable;

                for (int i = 0; i < radGirdCodigosSeleccionados.Items.Count; i++)
                {/**/
                    // LinkButton lkbtn =  radGridPedidos.Items[i].FindControl("lkbtnActa") as LinkButton;

                    TextBox textItem = radGirdCodigosSeleccionados.Items[i].FindControl("txtPorcentItem") as TextBox;
                    dtSession.Rows[i].SetField("Procentaje", textItem.Text);
                }

                dtres = dtSession;

            }


            return dtres;
        }

        protected void radGirdCodigosSeleccionados_ItemCommand(object sender, GridCommandEventArgs e)
        {

            if (e.CommandName == "DeleteCodigo")
            { /**/
                int index = e.Item.ItemIndex;
                DataTable dtSession = AsignarTexboxValuesDatatable();
                dtSession.Rows.RemoveAt(index);
                radGirdCodigosSeleccionados.DataSource = dtSession;
                radGirdCodigosSeleccionados.DataBind();
                Session["dtPersist"] = dtSession;

            }
        }

        protected void txtPorcentItem_TextChanged(object sender, EventArgs e)
        {
            decimal sum = 0;

            for (int i = 0; i < radGirdCodigosSeleccionados.Items.Count; i++)
            {/**/


                TextBox textItem = radGirdCodigosSeleccionados.Items[i].FindControl("txtPorcentItem") as TextBox;
                sum = sum + Convert.ToDecimal(textItem.Text);

            }

            if (sum > 100)
            {/**/

                this.ShowErrorNotification("La suma de porcentajes no debe exceder el 100%", 2000);

            }
        }

        public void CargarDatosPedidoEdit(int codPedido) 
        {
            objPedido = new CBPedido();
            DataTable dtCabecera = objPedido.GetPedidoCabeceraEdit("1", codPedido);
            AsignarValorTipoPedido( Convert.ToInt32( dtCabecera.Rows[0]["TipoPedido"]));
            ddLocal.SelectedValue = dtCabecera.Rows[0]["Local"].ToString();
            ddProyecto.SelectedValue = dtCabecera.Rows[0]["Proyecto"].ToString();
            ddMoneda.SelectedValue = dtCabecera.Rows[0]["Moneda"].ToString();
            txtDescripcion.Text = dtCabecera.Rows[0]["Descripcion"].ToString();
            chkDonacion.Checked = Convert.ToBoolean(dtCabecera.Rows[0]["Donacion"]);

            objPedido = new CBPedido();
            DataTable dtDetalle = objPedido.GetPedidoDetalleEdit("2", codPedido);
            GridItems.DataSource = dtDetalle;
            GridItems.DataBind();
            AsiganarValoresTextBox(dtDetalle);

            objPedido = new CBPedido();
            radGirdCodigosSeleccionados.Visible = true;
            DataTable dtCodigo = objPedido.GetPedidoCodigosEdit("3", codPedido);
            radGirdCodigosSeleccionados.DataSource = dtCodigo;
            radGirdCodigosSeleccionados.DataBind();
            Session["dtPersist"] = dtCodigo;
            


        }


        public void AsignarValorTipoPedido(int value) 
                
        {
            if (value == 1) {

                rbtnCompra.Checked = true; 

                /**/}
            else {

                rbtnServicio.Checked = true;
                    }
   
        }
        
	}
}
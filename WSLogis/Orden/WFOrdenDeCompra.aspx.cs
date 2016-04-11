using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassBusiness;
using System.Data;
using WSLogis.Helper;

namespace WSLogis.Orden
{
    public partial class WFOrdenDeCompra : System.Web.UI.Page
    {

        CBProveedor objProveedor;
        CBCombo objCombo;
        CBPedido objPedido;
        CBOrdenDeCompra objCompra;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {

                if (Session["ParametroIdPedido"] != null)
                {

                    CargarComboTipoPago();
                    GetPedidoCabecera(Convert.ToInt32(Session["ParametroIdPedido"].ToString()));
                    if (Session["ParamCodMoneda"].ToString() != "1")
                    {

                        PanelMonedaExt.Visible = true;
                        lblNombreMoneda.Text = lblMoneda.Text;
                        lblEtiquetaCambio.Visible = true;
                        txtCambioMoneda.Visible = true;


                    }

                    else if (Session["ParamCodMoneda"].ToString() == "1")
                    {

                        txtCambioMoneda.Text = "0";
                    
                    }
                    {
                    
                    }

                }
                else { 
                
                 
                }

              

            }

        }

      

        public void CargarComboTipoPago() {


            objCombo = new CBCombo();
            ddlTipoDePago.DataSource = objCombo.GetFormaTipoPago();
            ddlTipoDePago.DataValueField = "CodigoFormaPago";
            ddlTipoDePago.DataTextField = "Glosa";
            ddlTipoDePago.DataBind();
            ddlTipoDePago.Items.Insert(0, "Seleccione Forma de Pago");
        
        }

        protected void chekheader_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = sender as CheckBox;

            if (chk.Checked == true) {

                SelectItemsChekAll(true);
            
             }
            else if (chk.Checked == false)
            {
                SelectItemsChekAll(false);
            
            }
        }

        public void GetPedidoCabecera(int cod ) {

            objPedido = new CBPedido();
            DataTable dtCabecera = objPedido.GetPedidoCabeceraDetalle("1", cod);

            lblIdPedido.Text = dtCabecera.Rows[0]["CodigoPedido"].ToString();
            lblProyecto.Text = dtCabecera.Rows[0]["Proyecto"].ToString();
            lblDescripcion.Text = dtCabecera.Rows[0]["Descripcion"].ToString();
            lblMoneda.Text = dtCabecera.Rows[0]["Moneda"].ToString();
            Session["ParamCodMoneda"] = dtCabecera.Rows[0]["CodigoMoneda"].ToString();
            if (dtCabecera.Rows[0]["TipoPedido"].ToString() == "1")
            { /**/
                tdDatosServicios.Visible = false;
            
            }
            else { /**/
                tdDatosServicios.Visible = true;
            }
            GetPedidoDetalle(cod);
            
        }


        public void GetPedidoDetalle(int cod) {


            objPedido = new CBPedido();
            DataTable dtDetalle = objPedido.GetPedidoCabeceraDetalle("2", cod);
            GridItems.DataSource = dtDetalle;
            GridItems.DataBind();

            //  ---  FOOTER 
            //decimal total = dtDetalle.AsEnumerable().Sum(row => row.Field<decimal>("SubTotal"));
            //GridItems.FooterRow.Cells[2].Text = "Total";
            //GridItems.FooterRow.Cells[2].HorizontalAlign = HorizontalAlign.Right;
            //GridItems.FooterRow.Cells[3].Text = total.ToString("N2");

            objCombo = new CBCombo();
            DataTable dtgarantia = objCombo.GetTipoGarantia();

            for (int i = 0; i < GridItems.Rows.Count; i++)
            {
                TextBox cantidad = GridItems.Rows[i].FindControl("txtRowCantidad") as TextBox;
                cantidad.Text = dtDetalle.Rows[i]["Cantidad"].ToString();
                TextBox txtPrecio = GridItems.Rows[i].FindControl("txtPrecioRow") as TextBox;
                txtPrecio.Text = dtDetalle.Rows[i]["Precio"].ToString();
                DropDownList ddGarantia = GridItems.Rows[i].FindControl("ddlGarantia") as DropDownList;
                ddGarantia.DataSource = dtgarantia;
                ddGarantia.DataValueField = "Codigo";
                ddGarantia.DataTextField = "Glosa";
                ddGarantia.DataBind();
                
            }
        }

        public void SelectItemsChekAll(bool value) {

            decimal tot = 0;
            for (int i = 0; i < GridItems.Rows.Count; i++) {

                CheckBox chk = GridItems.Rows[i].FindControl("chkItem") as CheckBox;
                chk.Checked = value;

                 if (value==true){
                 tot =  tot + Convert.ToDecimal(GridItems.Rows[i].Cells[6].Text);
                     }
                 else
                 {
                     tot=0.00m ;
                 }

            
            }

            CalcularIGVyMontoTotal(tot);
           
          

        
        }

        protected void chekheaderigv_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chekigv = sender as CheckBox;
            bool valchecked = false;

            if (chekigv.Checked == true)
            {

                valchecked = true;

            }
            else {

                valchecked = false;
            }



            for (int i = 0; i < GridItems.Rows.Count; i++)
            {

                CheckBox chk = GridItems.Rows[i].FindControl("chkItemigv") as CheckBox;
                chk.Checked =  valchecked;

                


            }
        }

        protected void lkbtnGenerar_Click(object sender, EventArgs e)
        {
             string confirmValue = Request.Form["confirm_value"];
             if (confirmValue == "Si")        
             {
                 if (ddlTipoDePago.SelectedIndex == 0)
                 {

                     this.ShowErrorNotification("Seleccion un tipo de pago",3000);
                     Page.SetFocus(ddlTipoDePago);

                 }

                

                 else if (tdDatosServicios.Visible == true && txtResponsable.Text== "") { /**/

                     this.ShowErrorNotification("Falta ingresar el nombre del responsable del servicio", 2000);
                  
                 }
                


                 else if (ddlTipoDePago.SelectedIndex>0 )
                 {


                     int codOC = InsertarCabecera();

                     if (codOC > 0)
                     {

                         int var = InsertarDetalle(codOC);

                         if (var == 0)
                         {

                             this.ShowSuccessfulNotification("Se Registro Correctamente la orden de compra", 3000);

                         }

                     }

                 }

               
             }
        }


        public int InsertarCabecera() {

            int CodPedido = Convert.ToInt32(Session["ParametroIdPedido"].ToString());
            int codProv = GetCodProveedor();
            int codFormaPago = Convert.ToInt32(ddlTipoDePago.SelectedValue);
            int codUsuario = Convert.ToInt32(Session["CodigoUsuario"].ToString());
            objCompra = new CBOrdenDeCompra();
            int incluyeIGV = Convert.ToInt32(chkIgv.Checked);
            decimal tipoCambio =     Convert.ToDecimal(txtCambioMoneda.Text);
            decimal ExoMe = 0;
            decimal ExoSl = 0;
            decimal val_ventaMe = Convert.ToDecimal(lblValorVentaEX.Text);
            decimal val_igvME = Convert.ToDecimal(lblIGVEX.Text);
            decimal val_MontoTotalME = Convert.ToDecimal(lblMontoTotalExt.Text);
            decimal val_ventaSL = Convert.ToDecimal(lblValorVentaSL.Text);
            decimal val_igvSL = Convert.ToDecimal(lblIGVSL.Text);
            decimal val_MontoTotalSL = Convert.ToDecimal(lblMontoTotalSL.Text);
          
            string FechaInicio = txtFechaInicio.Text;
            string FechaFin = txtFechaFin.Text;
            string respon = txtResponsable.Text;
            string observac = txtObservOrden.Text;




            int  res = objCompra.InsertarOrdenCabecera("1", CodPedido, codProv, codFormaPago, 1, 1, codUsuario,incluyeIGV ,tipoCambio,ExoMe,val_ventaMe,val_igvME,val_MontoTotalME,ExoSl,val_ventaSL,val_igvSL,val_MontoTotalSL,FechaInicio,FechaFin,respon,observac);

            return res;
        }

        public bool ValidarFecha(DateTime time) {

              bool resultboool =false; 
            DateTime timenow = DateTime.Now;

            int res = DateTime.Compare(time, timenow);

            if (res<0) {

                resultboool = false;
            }

            else if (res >= 0) {


                resultboool = true;
            
            }

            return resultboool;
        }


        public int InsertarDetalle(int codCompra) {

            DateTime fechaEntrega = DateTime.Now;
            int erros = 0;
            int correct = 0; 
            for (int i = 0; i < GridItems.Rows.Count; i++) {

                CheckBox chk = GridItems.Rows[i].FindControl("chkItem") as CheckBox;

                 if (chk.Checked==true){

                     int codPedido = Convert.ToInt32(Session["ParametroIdPedido"].ToString());
                     int codPedidoDetalle = Convert.ToInt32(GridItems.DataKeys[i]["IdDetalle"].ToString());
                     
                        int codUser = Convert.ToInt32(Session["CodigoUsuario"].ToString());
                        DropDownList ddGarantia = GridItems.Rows[i].FindControl("ddlGarantia") as DropDownList;
                        int codGarantia = Convert.ToInt32(ddGarantia.SelectedValue);
                        if(chkFechaEntrega.Checked==false){/**/
                            TextBox texFech = GridItems.Rows[i].FindControl("itemTextFecha") as TextBox;
                            fechaEntrega = Convert.ToDateTime( texFech.Text);
                        }
                        else { /**/
                            fechaEntrega = Convert.ToDateTime(txtFechaEntrega.Text);
                           
                        }
                        objCompra = new CBOrdenDeCompra();
                         int  var = objCompra.InsertarOrdenDetalle("1", codCompra, codPedido, codPedidoDetalle, 1, 1, codUser,codGarantia,fechaEntrega);
                     if (var==1){
                     
                       correct=correct+1;
                     }
                     else if (var != 1) {

                         erros = erros + 1;
                       
                     }
                }

            }


            return erros;
           


        }

        public int GetCodProveedor() {

              



            int res = 0;
            objProveedor = new CBProveedor();
            DataTable dtProv = objProveedor.GetProveedores("2", textProveedor.Text);


            if (dtProv != null) {


                res = Convert.ToInt32(dtProv.Rows[0]["CodigoProveedor"].ToString());
            
            }


            return res;
        }

        protected void chkItem_CheckedChanged(object sender, EventArgs e)
        {
           // LinkButton boton = sender as LinkButton;
          //  GridViewRow gridview = (GridViewRow)boton.NamingContainer;
           // int codOC = Convert.ToInt32(GridOrdenes.DataKeys[gridview.RowIndex].Value.ToString());
           // string moneda = Convert.ToString(GridOrdenes.Rows[gridview.RowIndex].Cells[5].Text);
           CheckBox chekSelect =  sender as CheckBox;
           GridViewRow gridview = (GridViewRow)chekSelect.NamingContainer;
           decimal tot=0;

           if (chekSelect.Checked == false) {
               if (Session["ParamCodMoneda"].ToString() == "1")
               {
                   tot = Convert.ToDecimal(lblValorVentaSL.Text) - Convert.ToDecimal(GridItems.Rows[gridview.RowIndex].Cells[6].Text);
               }

               else {

                   tot = Convert.ToDecimal(lblValorVentaEX.Text) - Convert.ToDecimal(GridItems.Rows[gridview.RowIndex].Cells[6].Text);
                    
               }
           }

           else if (chekSelect.Checked == true) {

               if (Session["ParamCodMoneda"].ToString() == "1")
               {
                   tot = Convert.ToDecimal(lblValorVentaSL.Text) + Convert.ToDecimal(GridItems.Rows[gridview.RowIndex].Cells[6].Text);
               }

               else
               {

                   tot = Convert.ToDecimal(lblValorVentaEX.Text) + Convert.ToDecimal(GridItems.Rows[gridview.RowIndex].Cells[6].Text);

               }
           }
           string MontoDisplay = String.Format("{0:0.00}",Convert.ToString(tot));
           CalcularIGVyMontoTotal(tot);
         


        }

        public void CalcularIGVyMontoTotal(decimal valorVenta) {
            decimal igv = 0;
            if (chkIgv.Checked == true)
            {
                igv = GetValorIgv() * valorVenta / 100;
                igv = Decimal.Round(igv, 2);

            }

            else {

                igv = 0.00m;
            }
            string var_igv =String.Format("{0:0.00}", Convert.ToString(igv));
            string var_valorVenta = String.Format("{0:0.00}", Convert.ToString(valorVenta));
            string var_total  = String.Format("{0:0.00}", Convert.ToString(igv+valorVenta));

            if (Session["ParamCodMoneda"].ToString() == "1")
            {

                lblMontoTotalSL.Text = var_total;
                lblIGVSL.Text = var_igv;
                lblValorVentaSL.Text = var_valorVenta;
            }
            else {

                lblMontoTotalExt.Text = var_total;
                lblIGVEX.Text = var_igv;
                lblValorVentaEX.Text = var_valorVenta;
                ConvertirMoneda(valorVenta);
            }
        
        }

        public void ConvertirMoneda(decimal valorConvert) {

            if (txtCambioMoneda.Text.Length > 0)
            {

                string val_replace = txtCambioMoneda.Text;
                val_replace=  val_replace.Replace('.', '.');
                
                decimal cambio_val = Convert.ToDecimal(val_replace);
                decimal igv_converted = 0;
                decimal valor_converted = Decimal.Round( (valorConvert * cambio_val),2);
                lblValorVentaSL.Text = String.Format("{0:0.00}", Convert.ToString(valor_converted));
                if (chkIgv.Checked == true)
                {
                     igv_converted = Decimal.Round((valor_converted * GetValorIgv() / 100), 2);
                }
                else {
                    igv_converted = 0.00m;
                }

                lblIGVSL.Text = String.Format("{0:0.00}", Convert.ToString(igv_converted));

                lblMontoTotalSL.Text = String.Format("{0:0.00}", Convert.ToString(valor_converted + igv_converted));
            }

            else {

                
                this.ShowErrorNotification("Debe introducir el tipo de cambio de la moneda ", 2500);
                SetFocus(txtCambioMoneda);
            }

        
        }

        public Decimal GetValorIgv()
        {
            Decimal res = 0;
            objCombo = new CBCombo();
            DataTable dtigv = objCombo.GetValorIgv();

            if (dtigv != null)
            {
                string var = dtigv.Rows[0]["GlosaDetalle"].ToString();
                var = var.Replace(',', '.');
                res = Convert.ToDecimal(var);
                

            }

            return res;

        }

        protected void txtCambioMoneda_TextChanged(object sender, EventArgs e)
        {
           
        }

        protected void chkFechaEntrega_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFechaEntrega.Checked == false) { /**/
            GridItems.Columns[GridItems.Columns.Count - 1].Visible = true;
            txtFechaEntrega.Text="";
                txtFechaEntrega.Enabled=false;
            }

            else
            { /**/

                GridItems.Columns[GridItems.Columns.Count - 1].Visible = false;
               
                txtFechaEntrega.Enabled = true;
            }
        }
           
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassBusiness;
using System.Data;
using WSLogis.Helper;
namespace WSLogis.Administracion
{
    public partial class WFProductoNew : System.Web.UI.Page
    {
        
        #region Atributos

        string productoid = "";
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

              
               
                CargarComboCategoria();
                CargarComboPresentacion();
                CargarComboConcentracion();
                CargarComboUnidad();

                if (Session["ProductoID"]!= null) 
                { /**/
                    Page.Title = "Editar Producto";
                    this.LlenarCamposPopUp(Session["ProductoID"].ToString()); 
                    
                }

                else if (Session["ProductoID"]==null)
                { /**/
                    Page.Title = "Nuevo Producto";
                }
                
            }
        }


        public void LlenarCamposPopUp(string codProduct)
        {
            DataTable dtProducto = null;
            dtProducto = objProducto.GetProductos("2", codProduct);

            ddlCategoria.SelectedValue = dtProducto.Rows[0]["CodigoCategoria"].ToString();
            CargarComboSubCategoria();
            ddSubCategoria.SelectedValue = dtProducto.Rows[0]["CodigoSubCategoria"].ToString();
            ddPresentacion.SelectedValue = dtProducto.Rows[0]["CodigoPresentacion"].ToString();
            ddConcentracion.SelectedValue = dtProducto.Rows[0]["CodigoConcentracion"].ToString();
            ddUnidadMedida.SelectedValue = dtProducto.Rows[0]["CodigoUnidadMed"].ToString();
            txtNombre.Text = dtProducto.Rows[0]["NombreCorto"].ToString();
            txtDescripcion.Text = dtProducto.Rows[0]["DescripcionProducto"].ToString();
            checkExpira.Checked = Convert.ToBoolean(dtProducto.Rows[0]["Expira"]);
            // txtImagen1.Text = 
            fileUp1.ToolTip = dtProducto.Rows[0]["RutaImagen1"].ToString();
            fileUp2.ToolTip = dtProducto.Rows[0]["RutaImagen2"].ToString();
            txtStockMin.Text = dtProducto.Rows[0]["StockMinimo"].ToString();
            checkEstado.Checked = Convert.ToBoolean(dtProducto.Rows[0]["Estado"]);

            rbtTipoPedido.SelectedValue = dtProducto.Rows[0]["CodigoTipoPedido"].ToString();
            titlePopup.Text = "Editar Bienes/Servicios > " + txtDescripcion.Text;
        }
        public void CargarComboUnidad()
        {
            DataTable dtCombo = objUnidad.GetUnidadMedida();
            ddUnidadMedida.Items.Clear();
            ddUnidadMedida.Items.Add(new ListItem("-----Seleccione-----", "-1"));

            if (dtCombo.Rows.Count > 0)
            {
                for (int i = 0; i < dtCombo.Rows.Count; i++)
                {
                    strCod = dtCombo.Rows[i]["Codigo"].ToString();
                    strDes = dtCombo.Rows[i]["Descripcion"].ToString();
                    ddUnidadMedida.Items.Add(new ListItem(strDes, strCod));

                }
            }
        }

        public void CargarComboSubCategoria()
        {
            DataTable dtCombo = objCategoria.GetSubCategoria(int.Parse(ddlCategoria.SelectedValue));
            ddSubCategoria.Items.Clear();
            ddSubCategoria.Items.Add(new ListItem("-----Seleccione-----", "0"));

            if (dtCombo.Rows.Count > 0)
            {
                for (int i = 0; i < dtCombo.Rows.Count; i++)
                {
                    strCod = dtCombo.Rows[i]["Codigo"].ToString();
                    strDes = dtCombo.Rows[i]["Descripcion"].ToString();
                    ddSubCategoria.Items.Add(new ListItem(strDes, strCod));
                }
            }
            else
            {
                ddSubCategoria.Items.Clear();
                ddSubCategoria.Items.Add(new ListItem("No hay Sub Categorias registradas", "0"));
            }
        }


        public void CargarComboConcentracion()
        {
            DataTable dtCombo = objConcetracion.GetConcentracion();
            ddConcentracion.Items.Clear();
            ddConcentracion.Items.Add(new ListItem("-----Seleccione-----", "-1"));

            if (dtCombo.Rows.Count > 0)
            {
                for (int i = 0; i < dtCombo.Rows.Count; i++)
                {
                    strCod = dtCombo.Rows[i]["Codigo"].ToString();
                    strDes = dtCombo.Rows[i]["Descripcion"].ToString();
                    ddConcentracion.Items.Add(new ListItem(strDes, strCod));
                }
            }
        }

        public void CargarComboPresentacion()
        {
            DataTable dtCombo = objPresentacion.GetPresentacion();
            ddPresentacion.Items.Clear();
            ddPresentacion.Items.Add(new ListItem("-----Seleccione-----", "-1"));

            if (dtCombo.Rows.Count > 0)
            {
                for (int i = 0; i < dtCombo.Rows.Count; i++)
                {
                    strCod = dtCombo.Rows[i]["Codigo"].ToString();
                    strDes = dtCombo.Rows[i]["Descripcion"].ToString();
                    ddPresentacion.Items.Add(new ListItem(strDes, strCod));
                    ddPresentacion.DataBind();
                }
            }
        }

        public void CargarComboCategoria()
        {
            DataTable dtCombo = objCategoria.GetCategoria();
            ddlCategoria.Items.Clear();
            ddlCategoria.Items.Add(new ListItem("-----Seleccione-----", "0"));

            if (dtCombo.Rows.Count > 0)
            {
                for (int i = 0; i < dtCombo.Rows.Count; i++)
                {
                    strCod = dtCombo.Rows[i]["Codigo"].ToString();
                    strDes = dtCombo.Rows[i]["Descripcion"].ToString();
                    ddlCategoria.Items.Add(new ListItem(strDes, strCod));
                }

                CargarComboSubCategoria();
            }
        }

        protected void ddlCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (ddlCategoria.Items.Count > 0)
            {
                CargarComboSubCategoria();
            }

        }

        public int VerificarEstado()
        {

            int result = 3;

            if (checkEstado.Checked == true)
            {

                result = 1;
            }
            else if (checkEstado.Checked == false)
            {
                result = 0;

            }
            return result;

        }

        public string InsertarProducto()
        {
            string msj = "";
            int codCategoria = Convert.ToInt32(ddlCategoria.SelectedItem.Value.ToString());
            int codSubCateg = Convert.ToInt32(ddSubCategoria.SelectedItem.Value.ToString());
            int codPresent = Convert.ToInt32(ddPresentacion.SelectedItem.Value.ToString());
            int codConcentr = Convert.ToInt32(ddConcentracion.SelectedItem.Value.ToString());
            int codUnidad = Convert.ToInt32(ddUnidadMedida.SelectedItem.Value.ToString());
            string nomb = txtNombre.Text;
            string descripcion = txtDescripcion.Text;
            int stockmin = Convert.ToInt32(txtStockMin.Text);
            int estado = VerificarEstado();
            int userReg = Convert.ToInt32(Session["CodigoUsuario"].ToString());

            string pathImg1 = "--";
            string pathImg2 = "--";
            msj = objProducto.InsertarProducto(codCategoria, codSubCateg, int.Parse(rbtTipoPedido.SelectedValue), codPresent, codConcentr, codUnidad, nomb, descripcion, 1, stockmin, pathImg1, pathImg2, estado, userReg);
            return msj;
        }

        public int VerificarExpiracion()
        {
            int result = 3;
            if (checkExpira.Checked == true)
            {

                result = 1;
            }

            else if (checkExpira.Checked == false)
            {
                result = 0;
            }
            return result;
        }

        public string ActualizarProducto()
        {

            string resul = "";

            int codCategoria = Convert.ToInt32(ddlCategoria.SelectedItem.Value.ToString());
            int codSubCateg = Convert.ToInt32(ddSubCategoria.SelectedItem.Value.ToString());
            int codPresent = Convert.ToInt32(ddPresentacion.SelectedItem.Value.ToString());
            int codConcentr = Convert.ToInt32(ddConcentracion.SelectedItem.Value.ToString());
            int codUnidad = Convert.ToInt32(ddUnidadMedida.SelectedItem.Value.ToString());
            string nomb = txtNombre.Text;
            string descripcion = txtDescripcion.Text;
            int expira = VerificarExpiracion();
            int stockmin = Convert.ToInt32(txtStockMin.Text);
            int estado = VerificarEstado();
            int userReg = Convert.ToInt32(Session["CodigoUsuario"].ToString());
            int codProducto = Convert.ToInt32(Session["ProductoID"].ToString());
            string pathImg1 = "-";// fileUp1.PostedFile.FileName;
            
            string pathImg2 =  "-";// fileUp2.PostedFile.FileName;
            resul = objProducto.ActualizarProducto(codProducto, codCategoria, codSubCateg, int.Parse(rbtTipoPedido.SelectedValue), codPresent, codConcentr, codUnidad, nomb, descripcion, expira, stockmin, pathImg1, pathImg2, estado, userReg);
            return resul;
        }
        protected void lkbtnGrabar_Click(object sender, EventArgs e)
        {
            if (ddUnidadMedida.SelectedIndex != 0 && ddPresentacion.SelectedIndex != 0 && ddConcentracion.SelectedIndex != 0 && ddlCategoria.SelectedIndex != 0)
            {
                if (Session["ProductoID"]==null)
                {
                    string res = InsertarProducto();

                    if (res == "Se registro correctamente")
                    {
                        this.ShowSuccessfulNotification(res, 3000);
                       
                    }
                }

                else if (Session["ProductoID"] != null)
                {
                    string res = ActualizarProducto();

                    if (res == "Se actualizo correctamente")
                    {
                        this.ShowSuccessfulNotification(res, 3000);
                       
                    }
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Mensaje", "alert('Alguno(s) Campos no  fueron llenados correctamente , vuelva a intentar ')", true);

            }
        }

        

    }
}
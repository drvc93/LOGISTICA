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
    public partial class WFLocales : System.Web.UI.Page
    {
        
        CBLocal objLocal;
        CBEmpresa objEmpresa;
        CBNivelesAprobacion objNievelesAprobacion;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Page.Title = "Locales";        
                CargaGrilla();
                
            
            }
        }

        public void CargaGrilla() { 
           
            objLocal = new CBLocal();
            GridLocales.DataSource = objLocal.GetLocales("1", "0");
            GridLocales.DataBind();

          
        }

         

        protected void btnNuevoLocal_Click(object sender, EventArgs e)
        {
           
            Session["ParCodLocal"] = null;
           // LimpiarControles();
           // this.ModalPopup1Ext.Show();
        }

        


        

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Button boton = sender as Button;
            GridViewRow gridview = (GridViewRow)boton.NamingContainer;
            Session["ParCodLocal"] = GridLocales.DataKeys[gridview.RowIndex].Value.ToString();

           // LLenarCamposLocal(Convert.ToInt32(Session["ParCodLocal"]));

           // this.ModalPopup1Ext.Show();
        }

     

        

        

       
        

        protected void btnBuscarLocal_Click(object sender, EventArgs e)
        {
            if (txtNombreLocal.Text == "")
            {

                this.ShowErrorNotification("Ingrese un nombre de Local para realizar la busqueda", 3000);

            }

            else {

                objLocal = new CBLocal();
                 GridLocales.DataSource= objLocal.GetLocalesPorNombre("3", txtNombreLocal.Text);
                 GridLocales.DataBind();
            
            }
        }

        protected void txtNombreLocal_TextChanged(object sender, EventArgs e)
        {
            if (txtNombreLocal.Text=="") {

                CargaGrilla();
            
            }
        }

        protected void btnEdiLocal_Click(object sender, EventArgs e)
        {
            LinkButton boton = sender as LinkButton;
            GridViewRow gridview = (GridViewRow)boton.NamingContainer;
            Session["ParCodLocal"] = GridLocales.DataKeys[gridview.RowIndex].Value.ToString();

            //LLenarCamposLocal(Convert.ToInt32(Session["ParCodLocal"]));

           // this.ModalPopup1Ext.Show();
        }

        

        protected void btnAsigNivelesAprob_Click(object sender, EventArgs e)
        {
            LinkButton boton = sender as LinkButton;
            GridViewRow gridview = (GridViewRow)boton.NamingContainer;
            Session["CodLocalNivel"] = GridLocales.DataKeys[gridview.RowIndex].Value.ToString();
            int cod = Convert.ToInt32(Session["CodLocalNivel"].ToString());
            CargarGridNivelesPopUp(cod);
             this.ModalPopUp2.Show();
            
        }

        public void CargarGridNivelesPopUp(int codigo) {

            objNievelesAprobacion = new CBNivelesAprobacion();
            DataTable dtNiveles = objNievelesAprobacion.GetNivelesAprobacion(codigo);
            GridNivelesAprobacion.DataSource = dtNiveles;
            GridNivelesAprobacion.DataBind();


           for (int i = 0; i < dtNiveles.Rows.Count; i++) {
                CheckBox chk = GridNivelesAprobacion.Rows[i].FindControl("chkEstadoNivel") as CheckBox;
                

                     chk.Checked = Convert.ToBoolean(dtNiveles.Rows[i]["ESTADO"]);
                  
                 
           }
        }

        protected void lkbtnAgregarNivel_Click(object sender, EventArgs e)
        {
            bool  res=false;
            int codLocal = Convert.ToInt32(Session["CodLocalNivel"].ToString());
            int codUser = Convert.ToInt32(Session["CodigoUsuario"].ToString());
            objLocal = new CBLocal();

            for (int i = 0; i < GridNivelesAprobacion.Rows.Count; i++) {


                 int codNivel =  Convert.ToInt32  ( GridNivelesAprobacion.DataKeys[i].Value.ToString());
                // TextBox txtPrecio = GridItems.Rows[i].FindControl("txtPrecioRow") as TextBox;
                 CheckBox chk = GridNivelesAprobacion.Rows[i].FindControl("chkEstadoNivel") as CheckBox;
                 int estado = Convert.ToInt32(chk.Checked);
                  res=    objLocal.AsginarNiveles(codLocal, codNivel, estado, codUser);
                                 
               
            
            }

            if (res == true) { /**/
                this.ShowSuccessfulNotification("Se registro correctamente", 2500);

            }

            this.ModalPopUp2.Hide();
        }

       

        protected void lkbtnCancel_Click(object sender, EventArgs e)
        {
            this.ModalPopUp2.Hide();
        }
    }
}
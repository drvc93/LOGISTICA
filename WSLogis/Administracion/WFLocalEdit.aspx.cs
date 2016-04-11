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
     
	public partial class WFLocalEdit : System.Web.UI.Page
	{
        CBEmpresa objEmpresa;
        CBLocal objLocal;
		protected void Page_Load(object sender, EventArgs e)
		{

            if (!Page.IsPostBack)
            {
                
               
                CargarComboEmpresas();
                
                if (Session["ParCodLocal"] == null) { /**/

                    Page.Title = "Nuevo Local";
                }

                else if (Session["ParCodLocal"]!= null)
                {/**/

                    Page.Title = "Editar Local";
                    LLenarCamposLocal(Convert.ToInt32( Session["ParCodLocal"]));
                
                
                }

            }

		}

        

        public void LLenarCamposLocal(int cod)
        {

            DataTable dtLocal = null;
            objLocal = new CBLocal();
            dtLocal = objLocal.GetLocales("2", Convert.ToString(cod));
            // asign 

            ddlEmpresa.SelectedValue = dtLocal.Rows[0]["CodigoEmpresa"].ToString();
            txtNombre.Text = dtLocal.Rows[0]["Nombre"].ToString();
            txtDescripcion.Text = dtLocal.Rows[0]["Descripcion"].ToString();
            txtDireccion.Text = dtLocal.Rows[0]["DireccionLocal"].ToString();
            txtDistrito.Text = dtLocal.Rows[0]["DistritoLocal"].ToString();
            txtTelefono.Text = dtLocal.Rows[0]["Telefono"].ToString();
            chckEstatus.Checked = Convert.ToBoolean(dtLocal.Rows[0]["Estatus"]);
        }
        public void CargarComboEmpresas()
        {
            objEmpresa = new CBEmpresa();

            ddlEmpresa.DataSource = objEmpresa.GetEmpresas();

            ddlEmpresa.DataValueField = "Codigo";
            ddlEmpresa.DataTextField = "Descripcion";


            ddlEmpresa.DataBind();

            ddlEmpresa.Items.Insert(0, "Seleccione Empresa");

        }

        public int VerificarEstatus()
        {

            int resul = 3;

            if (chckEstatus.Checked == true)
            {

                resul = 1;

            }

            else if (chckEstatus.Checked == false)
            {
                resul = 0;

            }

            return resul;



        }

        public string ActualizarLocal()
        {

            int codEmpresa = Convert.ToInt32(ddlEmpresa.SelectedItem.Value);
            string nombre = txtNombre.Text;
            string descrip = txtDescripcion.Text;
            string direcc = txtDireccion.Text;
            string distrito = txtDistrito.Text;
            string telef = txtTelefono.Text;
            int estatus = VerificarEstatus();
            int userReg = Convert.ToInt32(Session["CodigoUsuario"].ToString());
            int codLocal = Convert.ToInt32(Session["ParCodLocal"].ToString());
            objLocal = new CBLocal();
            string msj = objLocal.ActualizarLocal(codLocal, codEmpresa, nombre, descrip, direcc, distrito, telef, estatus, userReg);

            return msj;
        }

        public string InsertarLocal()
        {


            int codEmpresa = Convert.ToInt32(ddlEmpresa.SelectedItem.Value);
            string nombre = txtNombre.Text;
            string descrip = txtDescripcion.Text;
            string direcc = txtDireccion.Text;
            string distrito = txtDistrito.Text;
            string telef = txtTelefono.Text;
            int estatus = VerificarEstatus();
            int userReg = Convert.ToInt32(Session["CodigoUsuario"].ToString());

            objLocal = new CBLocal();

            return objLocal.InsertarLocal(codEmpresa, nombre, descrip, direcc, distrito, telef, estatus, userReg);
        }

        protected void lkbtnGrabar_Click(object sender, EventArgs e)
        {
            string verif = "";

            if (ddlEmpresa.SelectedIndex > 0 && txtNombre.Text != "")
            {


                if (Session["ParCodLocal"]==null)
                {
                    verif = InsertarLocal();
                    if (verif == "Se registro correctamente")
                    {

                        this.ShowSuccessfulNotification(verif, 3000);

                       
                    }


                }

                else if (Session["ParCodLocal"] != null)
                {

                    verif = ActualizarLocal();

                    if (verif == "Se actualizo correctamente")
                    {
                        this.ShowSuccessfulNotification(verif, 3000);
                       

                    }


                }


            }

            else
            {




                this.ShowErrorNotification("No se llenaron algunos campo(s)  correctamente", 2500);


            }
        }

        
	}
}
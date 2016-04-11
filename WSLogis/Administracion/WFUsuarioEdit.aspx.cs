using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassBusiness;
using WSLogis.Helper;
using System.Data;

namespace WSLogis.Administracion
{
	public partial class WFUsuarioEdit : System.Web.UI.Page
	{
        CBLocal objLocal;
        CBCombo objCombo;
        CBUsuario objUsuario;
		protected void Page_Load(object sender, EventArgs e)
		{

            if (!Page.IsPostBack)
            {
                Page.Title = "Usuarios";
                CargarComboCargo();
                CargarComboLocales();

                if (Session["ParamCodUser"] != null) { /**/

                    AsignarValoresPopUp(Convert.ToInt32(Session["ParamCodUser"]));
                    titlePopup.Text = "Editar Usuario";
                }

                else { /**/
                 
                titlePopup.Text="Nuevo Usuario";
                }
            }
		}


        public void AsignarValoresPopUp(int codUser)
        {

            objUsuario = new CBUsuario();
            DataTable dtUsuarios = objUsuario.GetUsuarios("2", Convert.ToString(codUser));

            ddLocal.SelectedValue = dtUsuarios.Rows[0]["CodigoLocal"].ToString();
            txtLogin.Text = dtUsuarios.Rows[0]["LoginUsuario"].ToString();
            txtNombre.Text = dtUsuarios.Rows[0]["NombreUsuario"].ToString();
            txtIniciales.Text = dtUsuarios.Rows[0]["Iniciales"].ToString();
            ddlCargo.SelectedValue = dtUsuarios.Rows[0]["CodigoDet"].ToString();
            txtCorreo.Text = dtUsuarios.Rows[0]["Correo"].ToString();
            checkEstado.Checked = Convert.ToBoolean(dtUsuarios.Rows[0]["Estado"]);


        }

        public void CargarComboLocales()
        {

            objLocal = new CBLocal();

            DataTable dtLocal = objLocal.GetLocales("1", "0");
            ddLocal.DataSource = dtLocal;
            ddLocal.DataValueField = "CodigoLocal";
            ddLocal.DataTextField = "Nombre";
            ddLocal.DataBind();
            ddLocal.Items.Insert(0, "Seleccione local");
        }



        public void CargarComboCargo()
        {

            objCombo = new CBCombo();
            ddlCargo.DataSource = objCombo.GetComboDetalle(2);
            ddlCargo.DataValueField = "CodigoDet";
            ddlCargo.DataTextField = "GlosaDetalle";
            ddlCargo.DataBind();
            ddlCargo.Items.Insert(0, "Seleccione Cargo");


        }

        protected void lkbtnGrabar_Click(object sender, EventArgs e)
        {
            if (ddlCargo.SelectedIndex > 0 && ddLocal.SelectedIndex > 0 && txtLogin.Text != "")
            {
                string msj = "";
                if (Session["ParamCodUser"] == null)
                {

                    msj = InsertarUsuario();
                    this.ShowSuccessfulNotification(msj, 3000);
                  

                }

                else if (Session["ParamCodUser"] != null)
                {

                    msj = ActualizarUsuario();
                    this.ShowSuccessfulNotification(msj, 3000);
                   


                }


            }

            else
            {

                this.ShowErrorNotification("Algunos campos no fueron llenados correctamente", 3000);

            }
        }

        public int ObtenerEstado()
        {
            int resul = 3;
            if (checkEstado.Checked == true)
            {

                resul = 1;

            }

            else
            {

                resul = 0;
            }

            return resul;
        }

        public string ActualizarUsuario()
        {

            int codUser = Convert.ToInt32(Session["ParamCodUser"].ToString());
            int codLocal = Convert.ToInt32(ddLocal.SelectedItem.Value);
            string loginUser = txtLogin.Text;
            string nomUser = txtNombre.Text;
            string inic = txtIniciales.Text;
            string cargo = ddlCargo.SelectedItem.Text;
            string correo = txtCorreo.Text;
            int estado = ObtenerEstado();
            int userReg = Convert.ToInt32(Session["CodigoUsuario"].ToString());
            objUsuario = new CBUsuario();

            return objUsuario.ActualizarUsuario(codUser, "2", codLocal, loginUser, nomUser, inic, cargo, correo, estado, userReg);


        }




        public string InsertarUsuario()
        {

            int codLocal = Convert.ToInt32(ddLocal.SelectedItem.Value);
            string loginUser = txtLogin.Text;
            string nomUser = txtNombre.Text;
            string inic = txtIniciales.Text;
            string cargo = ddlCargo.SelectedItem.Text;
            string correo = txtCorreo.Text;
            string pass = loginUser;
            int estado = ObtenerEstado();
            int userReg = Convert.ToInt32(Session["CodigoUsuario"].ToString());

            objUsuario = new CBUsuario();

            return objUsuario.InsertarUsuario("1", codLocal, loginUser, nomUser, inic, cargo, correo, pass, estado, userReg);

        }


	}
}
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
	public partial class WFProyectoEdit : System.Web.UI.Page
	{
        CBProyecto objProyecto;
		protected void Page_Load(object sender, EventArgs e)
		{
            if (!Page.IsPostBack)
            {
                CargarComboGrupo();

                if (Session["ParmCodigoProyect"] != null)
                {
                    AsignarValoresControles(Session["ParmCodigoProyect"].ToString());
                    Page.Title = "Editar Proyecto";
                    titlePopup.Text = "Editar Proyecto";
                    /**/
                }

                else if (Session["ParmCodigoProyect"]==null)
                {/**/
                    Page.Title = "Nuevo Proyecto";
                    titlePopup.Text = "Nuevo Proyecto";
                }
            }
		}

        public string InsertarProyecto()
        {


            int codGrupo = Convert.ToInt32(ddlGrupoPoryecto.SelectedItem.Value);
            string nomb = txtNombre.Text;
            string descrip = txtDescripcion.Text;
            string fechIni = txtFechaInicio.Text;
            string fechaFin = txtFechaFin.Text;
            int estado = VerificarCheckEstado();
            int userReg = Convert.ToInt32(Session["CodigoUsuario"].ToString());
            objProyecto = new CBProyecto();


            return objProyecto.InsertarProyecto("1", codGrupo, nomb, descrip, fechIni, fechaFin, estado, userReg);


        }

        public int VerificarCheckEstado()
        {
            int result = 3;
            if (chckEstado.Checked == true)
            {

                result = 1;
            }

            else
            {

                result = 0;
            }

            return result;
        }



        public string ActualizarProyecto()
        {


            int codGrupo = Convert.ToInt32(ddlGrupoPoryecto.SelectedItem.Value);
            string nomb = txtNombre.Text;
            string descrip = txtDescripcion.Text;
            string fechIni = txtFechaInicio.Text;
            string fechaFin = txtFechaFin.Text;
            int estado = VerificarCheckEstado();
            int userReg = Convert.ToInt32(Session["CodigoUsuario"].ToString());
            objProyecto = new CBProyecto();
            int codProyec = Convert.ToInt32(Session["ParmCodigoProyect"].ToString());
            return objProyecto.ActualizarProyecto(codProyec, "2", codGrupo, nomb, descrip, fechIni, fechaFin, estado, userReg);

        }

        public void AsignarValoresControles(string codProy)
        {

            DataTable dtProyectos = null;
            objProyecto = new CBProyecto();
            dtProyectos = objProyecto.GetProyectos("2", codProy);
            // asign
            ddlGrupoPoryecto.SelectedValue = dtProyectos.Rows[0]["CodigoGrupoProyecto"].ToString();
            txtNombre.Text = dtProyectos.Rows[0]["NombreCortoProyecto"].ToString();
            txtDescripcion.Text = dtProyectos.Rows[0]["DescripcionProyecto"].ToString();
            DateTime dtime1 = Convert.ToDateTime(dtProyectos.Rows[0]["FechaInicio"]);
            DateTime dtime2 = Convert.ToDateTime(dtProyectos.Rows[0]["FechaTermino"]);
            txtFechaInicio.Text = dtime1.ToString("dd/MM/yyyy");
            txtFechaFin.Text = dtime2.ToString("dd/MM/yyyy");


            chckEstado.Checked = Convert.ToBoolean(dtProyectos.Rows[0]["Estado"]);

        }
        public void CargarComboGrupo()
        {

            objProyecto = new CBProyecto();
            ddlGrupoPoryecto.DataSource = objProyecto.GetGrupoProyectos();
            ddlGrupoPoryecto.DataValueField = "Codigo";
            ddlGrupoPoryecto.DataTextField = "Descripcion";
            ddlGrupoPoryecto.DataBind();
            ddlGrupoPoryecto.Items.Insert(0, "Seleccione Grupo ");
        }

        protected void lkbtnGrabar_Click(object sender, EventArgs e)
        {
            if (ddlGrupoPoryecto.SelectedIndex > 0)
            {
                string msj = "";

                if (Session["ParmCodigoProyect"] == null)
                {

                    msj = InsertarProyecto();

                    this.ShowSuccessfulNotification(msj, 3000);
                   

                }

                else if (Session["ParmCodigoProyect"]!= null)
                {

                    msj = ActualizarProyecto();

                    this.ShowSuccessfulNotification(msj, 3000);
                   

                }



            }

            else
            {

                this.ShowErrorNotification("Seleccione un Grupo correcto ", 3000);

            }
        }
	}
}
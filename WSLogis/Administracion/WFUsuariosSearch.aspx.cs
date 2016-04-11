using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ClassBusiness;
using WSLogis.Helper;

namespace WSLogis.Administracion
{
    public partial class WFUsuariosSearch : System.Web.UI.Page
    {

        CBUsuario objUsuario;
        CBLocal objLocal;
        CBCombo objCombo;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarGrillaUsuarios();
              

            }
        }



        public void CargarGrillaUsuarios()
        {

            objUsuario = new CBUsuario();

            gridUsuarios.DataSource = objUsuario.GetUsuarios("1", "0");
            gridUsuarios.DataBind();

            
        }


       
        protected void btnNuevoUsuario_Click(object sender, EventArgs e)
        {
           
            Session["ParamCodUser"] = null;
           // this.ModalPopup1Ext.Show();
        }



        protected void btnAsigProyecto_Click(object sender, EventArgs e)
        {
            LinkButton btnAsig = sender as LinkButton;
            GridViewRow gridview = (GridViewRow)btnAsig.NamingContainer;
            Session["ParamCodUser"] = gridUsuarios.DataKeys[gridview.RowIndex].Value.ToString();
            CargarGridProyectos(Convert.ToInt32(Session["ParamCodUser"].ToString()));

            this.ModalPopUp2.Show();
        }

        


        
        protected void btnEditP_Click(object sender, EventArgs e)
        {
            // ddlCategoria.Items.Clear();
            
            LinkButton boton = sender as LinkButton;
            GridViewRow gridview = (GridViewRow)boton.NamingContainer;
            Session["ParamCodUser"] = gridUsuarios.DataKeys[gridview.RowIndex].Value.ToString();
         
           
       
           
           // this.ModalPopup1Ext.Show();
        }

        public void CargarGridProyectos(int codUser) {


            objUsuario = new CBUsuario();
            DataTable dtUserProyectos = objUsuario.GetUsuarioProyecto(codUser);
            GridProyectos.DataSource = dtUserProyectos;
            GridProyectos.DataBind();

            for (int i = 0; i < dtUserProyectos.Rows.Count; i++)
            {

                CheckBox chek = GridProyectos.Rows[i].FindControl("chkProyecto") as CheckBox;
                chek.Checked = Convert.ToBoolean(dtUserProyectos.Rows[i]["Estado"]);

            }

        
        }

        protected void lkbtnAgregarProyecto_Click(object sender, EventArgs e)
        {
            string res = "";
            int codUser = Convert.ToInt32(Session["ParamCodUser"]);
            int userReg = Convert.ToInt32(Session["CodigoUsuario"].ToString());

            for (int i = 0; i < GridProyectos.Rows.Count; i++)
            {

                
                CheckBox chek = GridProyectos.Rows[i].FindControl("chkProyecto") as CheckBox;
                int estado = Convert.ToInt32(chek.Checked);
                int codProyecto = Convert.ToInt32(GridProyectos.DataKeys[i].Value.ToString());
                objUsuario = new CBUsuario();
               res = objUsuario.InsertarUsuarioProyecto(codUser, codProyecto, estado, userReg);
               

            }

            this.ShowSuccessfulNotification(res, 2500);
            this.ModalPopUp2.Hide();

        }

        protected void btnAsigRol_Click(object sender, EventArgs e)
        {
            LinkButton btnAsig = sender as LinkButton;
            GridViewRow gridview = (GridViewRow)btnAsig.NamingContainer;
            Session["ParamCodUser"] = gridUsuarios.DataKeys[gridview.RowIndex].Value.ToString();
            CargarGridRoles(Convert.ToInt32(Session["ParamCodUser"].ToString()));
            this.ModalPopupExtender3.Show();
        }

        public void CargarGridRoles(int codUser) {


            objUsuario = new CBUsuario();
            DataTable dtRoles = objUsuario.GetUsuarioRol(codUser);
            GridRoles.DataSource = dtRoles;
            GridRoles.DataBind();
            for (int i = 0; i < dtRoles.Rows.Count; i++)
            {

                CheckBox chek = GridRoles.Rows[i].FindControl("chkRol") as CheckBox;
                 chek.Checked = Convert.ToBoolean(dtRoles.Rows[i]["Estado"]);
               
             }
        }

        public void InsertarRolesUsuarios() {

            int codUser = Convert.ToInt32(Session["ParamCodUser"]);
            int userReg = Convert.ToInt32(Session["CodigoUsuario"].ToString());
            string res="";
            for (int i = 0; i < GridRoles.Rows.Count; i++)
            {


                CheckBox chek = GridRoles.Rows[i].FindControl("chkRol") as CheckBox;
                int estado = Convert.ToInt32(chek.Checked);
                int codRol = Convert.ToInt32(GridRoles.DataKeys[i].Value.ToString());
                objUsuario = new CBUsuario();
                res = objUsuario.InsertarUsuarioRol(codUser, codRol, estado, userReg);


        }
            this.ModalPopupExtender3.Hide();
            this.ShowSuccessfulNotification(res,2500);

        }

        protected void lkbtnAsigRol_Click(object sender, EventArgs e)
        {
            InsertarRolesUsuarios();
            

        }


        public void CargarNivelesArpobacion(int codUser) {

            objUsuario = new CBUsuario();           
           DataTable dtResul =  objUsuario.GetUsuarioNivelAprobacion(codUser);
           DataTable dtDisplay = dtResul.Select("ESTADO=1").CopyToDataTable();
           GridNivelesAprobacion.DataSource = dtDisplay;
           GridNivelesAprobacion.DataBind();

           for (int i = 0; i < GridNivelesAprobacion.Rows.Count; i++ )
           {/**/
               CheckBox chekN = GridNivelesAprobacion.Rows[i].FindControl("chkEstadoNivel") as CheckBox;
               chekN.Checked = Convert.ToBoolean(dtDisplay.Rows[i]["ESTADO_USER"]);
               //chkEstadoNivel
           }
          
        }

        protected void lkbtnVistoB_Click(object sender, EventArgs e)
        {
            LinkButton btnAsig = sender as LinkButton;
            GridViewRow gridview = (GridViewRow)btnAsig.NamingContainer;
            Session["ParamCodUser"] = gridUsuarios.DataKeys[gridview.RowIndex].Value.ToString();
            CargarNivelesArpobacion(Convert.ToInt32(Session["ParamCodUser"].ToString()));
            this.ModalPopupExtender4.Show();
        }

        protected void gridUsuarios_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lnk = e.Row.FindControl("btnEditP") as LinkButton;
                AsyncPostBackTrigger trigger = new AsyncPostBackTrigger();
                trigger.ControlID = lnk.UniqueID;
                trigger.EventName = "Click";
                 updatePGen.Triggers.Add(trigger);
                LinkButton lnk2 = e.Row.FindControl("btnAsigProyecto") as LinkButton;
                AsyncPostBackTrigger trigger2 = new AsyncPostBackTrigger();
                trigger.ControlID = lnk.UniqueID;
                trigger.EventName = "Click";
                updatePGen.Triggers.Add(trigger);

            }
        }

        protected void lkbtnCancelRol_Click(object sender, EventArgs e)
        {
            this.ModalPopupExtender3.Hide();
        }

        protected void lkbtnCancel_Click(object sender, EventArgs e)
        {
            this.ModalPopUp2.Hide();
        }

        protected void lkbtnAgregarNivel_Click(object sender, EventArgs e)
        {
            string res = "";
            int  codUsuario =  Convert.ToInt32( Session["ParamCodUser"].ToString());
            int userReg = Convert.ToInt32(Session["CodigoUsuario"].ToString());

            for (int i = 0; i < GridNivelesAprobacion.Rows.Count; i++) { /**/

                CheckBox chek = GridNivelesAprobacion.Rows[i].FindControl("chkEstadoNivel") as CheckBox;
            int estado = Convert.ToInt32(chek.Checked);
            int CodNivel = Convert.ToInt32(GridNivelesAprobacion.DataKeys[i].Value.ToString());
            objUsuario = new CBUsuario();
         //   res = objUsuario.InsertarUsuarioRol(codUser, codRol, estado, userReg);
            res =objUsuario.InsertarUsuarioNivelAprobacion(codUsuario, CodNivel, estado, userReg);

            }

            this.ShowSuccessfulNotification(res, 2000);
            this.ModalPopupExtender4.Hide();
        }

        protected void lkbtnCancelNivel_Click(object sender, EventArgs e)
        {
            this.ModalPopupExtender4.Hide();
        }

        protected void txtNombreUsuario_TextChanged(object sender, EventArgs e)
        {
            objUsuario = new CBUsuario();
            gridUsuarios.DataSource = objUsuario.GetUsuariosPorLogin("3", txtNombreUsuario.Text);
            gridUsuarios.DataBind();
           
        }
    }
}
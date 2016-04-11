using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using ClassData;
using ClassBusiness;

namespace WSLogis
{
    public partial class WFLogin : System.Web.UI.Page
    {
        CBUsuario objCBUsuario = new CBUsuario();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            string mensaje;

            DataTable dt = new DataTable();
            string login = UserName.Text;
            string pass = Password.Text;

            dt = objCBUsuario.GetValidarUsuario(login, pass);
            mensaje = dt.Rows[0]["Respuesta"].ToString();

            if (mensaje == "1")
            {
                lblMensaje.Text = "Usuario no Encontrado. Por favor, trate de nuevo.";
            }
            if (mensaje == "2")
            {
                lblMensaje.Text = "Contraseña errada. Por favor, trate de nuevo.";
            }
            if (mensaje == "3")
            {
                Session["CodigoLocal"] = dt.Rows[0]["CodigoLocal"].ToString();
                Session["CodigoUsuario"] = dt.Rows[0]["CodigoUsuario"].ToString();
                Session["CodigoEmpresa"] = dt.Rows[0]["CodigoEmpresa"].ToString();
                Session["LoginUsuario"] = dt.Rows[0]["LoginUsuario"].ToString();
                Session["NomLocal"] = dt.Rows[0]["Local"].ToString();
                Response.Redirect("~/WFCambiarClave.aspx");
            }
            if (mensaje == "4")
            {
                lblMensaje.Text = "";
                Session["CodigoLocal"] = dt.Rows[0]["CodigoLocal"].ToString();
                Session["LoginUsuario"] = dt.Rows[0]["LoginUsuario"].ToString();
                Session["CodigoUsuario"] = dt.Rows[0]["CodigoUsuario"].ToString();
                Session["CodigoEmpresa"] = dt.Rows[0]["CodigoEmpresa"].ToString();
                Session["NomLocal"] = dt.Rows[0]["Local"].ToString();
                Response.Redirect("~/WFPrincipal.aspx");
            }

        }

        protected void imbResetear_Click(object sender, EventArgs e)
        {

        }

        protected void Password_TextChanged(object sender, EventArgs e)
        {
            string mensaje;

            DataTable dt = new DataTable();
            string login = UserName.Text;
            string pass = Password.Text;

            dt = objCBUsuario.GetValidarUsuario(login, pass);
            mensaje = dt.Rows[0]["Respuesta"].ToString();

            if (mensaje == "1")
            {
                lblMensaje.Text = "Usuario no Encontrado. Por favor, trate de nuevo.";
            }
            if (mensaje == "2")
            {
                lblMensaje.Text = "Contraseña errada. Por favor, trate de nuevo.";
            }
            if (mensaje == "3")
            {
                Session["CodigoLocal"] = dt.Rows[0]["CodigoLocal"].ToString();
                Session["CodigoUsuario"] = dt.Rows[0]["CodigoUsuario"].ToString();
                Session["CodigoEmpresa"] = dt.Rows[0]["CodigoEmpresa"].ToString();
                Session["LoginUsuario"] = dt.Rows[0]["LoginUsuario"].ToString();
                Session["NomLocal"] = dt.Rows[0]["Local"].ToString();
                Response.Redirect("~/WFCambiarClave.aspx");
            }
            if (mensaje == "4")
            {
                lblMensaje.Text = "";
                Session["CodigoLocal"] = dt.Rows[0]["CodigoLocal"].ToString();
                Session["LoginUsuario"] = dt.Rows[0]["LoginUsuario"].ToString();
                Session["CodigoUsuario"] = dt.Rows[0]["CodigoUsuario"].ToString();
                Session["CodigoEmpresa"] = dt.Rows[0]["CodigoEmpresa"].ToString();
                Session["NomLocal"] = dt.Rows[0]["Local"].ToString();
                Response.Redirect("~/WFPrincipal.aspx");
            }
        }
    }
}
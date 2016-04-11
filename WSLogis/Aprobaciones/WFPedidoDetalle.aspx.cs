using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassBusiness;
using System.Data;
using WSLogis.Helper;

namespace WSLogis.Aprobaciones
{
    public partial class WFPedidoDetalle : System.Web.UI.Page
    {
        CBPedido objPedido;
        protected void Page_Load(object sender, EventArgs e)
        {
             if (!Page.IsPostBack)
              {
                  if (Session["ParametroIdPedido"] != null) { /**/

                      EanbleTextRaz(false);
                      CargarPopupCabecera(Convert.ToInt32(Session["ParametroIdPedido"]));

                  
                  }
              }
        }


        public void EanbleTextRaz(bool var) { /**/
          
            if ( var==true){
                /**/
                tdBotenesDetalle.Visible = false;
                razBotones.Visible = true;
                razTexttBox.Visible = true;
            }

            else
            {
                tdBotenesDetalle.Visible = true;
                razTexttBox.Visible = false;
                razBotones.Visible = false;


            }
        }

        public void CargarPopupCabecera(int codPedido)
        {

            objPedido = new CBPedido();
            DataTable dtCabecera = objPedido.GetPedidosAprobacion("2", codPedido);
            lblCodPedido.Text = dtCabecera.Rows[0]["CodigoPedido"].ToString();
            lblMoneda.Text = dtCabecera.Rows[0]["Moneda"].ToString();
            lblProyecto.Text = dtCabecera.Rows[0]["Proyecto"].ToString();
            lblTipoBien.Text = dtCabecera.Rows[0]["Tipo"].ToString();
            lblDescripcion.Text = dtCabecera.Rows[0]["Descripcion"].ToString();

            CargarPopupDetalle(codPedido);

        }

        public void CargarPopupDetalle(int codPedido)
        { /**/


            objPedido = new CBPedido();
            GridDetallePedido.DataSource = objPedido.GetPedidosAprobacion("3", codPedido);
            GridDetallePedido.DataBind();

        }

        public void ActualizarVB(int codPed, int VBresponsable, string motivo, int sgtEstado)
        { /**/

            //int codPed = Convert.ToInt32(Session["ParametroIdPedido"]);
            //string motivo = txtComentario.Text;
            int userVB = Convert.ToInt32(Session["CodigoUsuario"].ToString());

            objPedido = new CBPedido();
            bool res = objPedido.ActualizarVBResponsable(codPed, VBresponsable, motivo, userVB, sgtEstado);



            if (res == true)
            { /**/

                if (VBresponsable == 1)
                { /**/

                   // this.ShowSuccessfulNotification("Se aprobo el pedido", 2500);
                }

                else if (VBresponsable == 0)
                { /**/


                   // this.ShowSuccessfulNotification("Se rechazo el pedido ", 2500);

                }

                Session["PedidoActualizado"] = "1";

            }


        }

        public int NextNivelAprobacion()
        { /**/
            int resNexNivel = -1;
            objPedido = new CBPedido();
            DataTable dtResul = objPedido.GetPedidosAprobacion("4", Session["CodigoUsuario"].ToString());
            int nivAproUser = GetNivelAprobacionUsuario();
            /**/

            if (dtResul != null && dtResul.Rows.Count > 0)
            { /**/


                for (int i = 1; i < dtResul.Rows.Count; i++)
                {/**/

                    if (Convert.ToInt32(dtResul.Rows[i - 1]["CodigoNivelAprobacion"]) == nivAproUser && (i-1) < dtResul.Rows.Count)
                    {/**/

                        resNexNivel = Convert.ToInt32(dtResul.Rows[i]["CodigoNivelAprobacion"]);

                    }

                    if (Convert.ToInt32(dtResul.Rows[i - 1]["CodigoNivelAprobacion"]) == nivAproUser && (i - 1) == dtResul.Rows.Count)
                    {/**/

                        resNexNivel = 4;

                    }

                }
            }

            return resNexNivel;



        }

        public int GetNivelAprobacionUsuario()
        { /**/

            int res = -1;
            objPedido = new CBPedido();
            DataTable dtResul = objPedido.GetPedidosAprobacion("5", Session["CodigoUsuario"].ToString());
            if (dtResul != null && dtResul.Rows.Count > 0)
            { /**/

                res = Convert.ToInt32(dtResul.Rows[0]["CodigoNivelAprobacion"]);

            }

            return res;

        }

        protected void lkbtnAcepRazon_Click(object sender, EventArgs e)
        {

            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Si")
            {   /**/


                int codPed = Convert.ToInt32(Session["ParametroIdPedido"]);
                string motivo = txtComentario.Text;
                ActualizarVB(codPed, 0, motivo, 0);



            }

           
            
        }

        protected void lkbtnAprobarPedido_Click(object sender, EventArgs e)
        {
            //lkbtnAprobarPedido_Click
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Si")
            {   /**/


                int codPed = Convert.ToInt32(Session["ParametroIdPedido"]);
                string motivo = "";
                int nEstatus = NextNivelAprobacion();
                ActualizarVB(codPed, 1, motivo, nEstatus);
               


            }
        }

        protected void lkbtnRechazarPed_Click(object sender, EventArgs e)
        {

            EanbleTextRaz(true);

        }

        protected void lkbtnCancelRazon_Click(object sender, EventArgs e)
        {
            EanbleTextRaz(false);
        }
       
    }
}
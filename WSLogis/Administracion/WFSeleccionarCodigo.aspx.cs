using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using ClassBusiness;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WSLogis.Administracion
{
    public partial class WFSeleccionarCodigo : System.Web.UI.Page
    {
        CBCombo objCombo;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) { /**/

                if (Session["ValorCombo"] != null) { /**/
                
                 int codProy = Convert.ToInt32(Session["ValorCombo"]);
                 CargarGrillaCodigos(codProy);
                
                }
              

            }
        }

        public void CargarGrillaCodigos(int codProyecto) { /**/

            objCombo = new CBCombo();
            DataTable dtCodigos = objCombo.GetCodigoPresupuestal("1", codProyecto);
            if (dtCodigos.Rows.Count > 0) { /**/
            gvCodigosProyecto.DataSource = dtCodigos;
            gvCodigosProyecto.DataBind();

            string nomProyecto = dtCodigos.Rows[0]["Proyecto"].ToString();
            lblTITULO.Text = "Codigos de Proyecto : " + nomProyecto;
            lblTITULO.Font.Size = 14;
            Session["NomProy"] = nomProyecto;
            lkAgregarCod.Visible = true;

            }
            else {

                lkAgregarCod.Visible = false;
                lblTITULO.Text = "No se encontro codigos para este proyecto";
                lblTITULO.Font.Size = 14;
              
            }
        }

        public DataTable GetItemSeleccionados() {
            DataTable dtCodSelec = new DataTable();
            dtCodSelec.Columns.AddRange(new DataColumn[3] { new DataColumn("Proyecto", typeof(string)), new DataColumn("Presupuesto", typeof(string)), new DataColumn("Procentaje", typeof(string)) });
            string nomProy = Session["NomProy"].ToString();
            for (int i = 0; i < gvCodigosProyecto.Rows.Count; i++)
            { /**/
                CheckBox chkCod = gvCodigosProyecto.Rows[i].FindControl("chkCodigo") as CheckBox;
                string codigo = gvCodigosProyecto.Rows[i].Cells[0].Text;
                if (chkCod.Checked == true) {

                    dtCodSelec.Rows.Add(nomProy, codigo, "0");
                
                }
            }

            //Session["dtCodigosSelect"]
            return dtCodSelec;


        
        }

        protected void lkAgregarCod_Click(object sender, EventArgs e)
        {
            DataTable dtSession = GetItemSeleccionados();
            Session["dtCodigosSelect"] = dtSession;
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "refreshGridCodParent();", true);
        }
    }
}
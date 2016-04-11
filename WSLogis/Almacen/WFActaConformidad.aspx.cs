using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.ReportSource;
using CrystalDecisions.ReportSource;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Data;
using ClassBusiness;
namespace WSLogis.Almacen
{
    public partial class WFActaConformidad : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["CodOCReport"] != null) {
                    int cod = Convert.ToInt32(Session["CodOCReport"]);
                    LoadReport(cod);
                }

                else { }
                                     
            }
        }


        public void LoadReport(int cod) { /**/
            CrystalReportViewer1.EnableParameterPrompt = false;
            string reportPath = Server.MapPath("~/Report/ActaConformidad.rpt");
            ReportDocument reportDocument = new ReportDocument();
            reportDocument.Load(reportPath);
            reportDocument.SummaryInfo.ReportTitle = "Orden Nro " + Convert.ToString(cod);
          //  reportDocument.SetDatabaseLogon("testin", "$2@15%", "demo2.sociosensalud.org.pe","SEIS_LOGIS");
            CBOrdenDeCompra objOrden = new CBOrdenDeCompra();
            DataTable dt = objOrden.ActaConformidad(cod);
            reportDocument.SetDataSource(dt);
            
           
           
            //reportDocument.SetParameterValue("@CodigoOC", cod);
            Session["reportdoc"] = reportDocument;
            Session["nroOrden"] = cod;
           //  CrystalReportViewer1.ID = "Orden Nro " + Convert.ToString(cod);
           CrystalReportViewer1.ReportSource = reportDocument;
            DataBind();
           // reportDocument.ExportToHttpResponse(ExportFormatType.PortableDocFormat, this.Page.Response, true, "Orden Nro " + Convert.ToString(cod));
           
           

           
        }


      
        protected void btnExoprtPDF_Click(object sender, EventArgs e)
        {
            ReportDocument repor = Session["reportdoc"] as ReportDocument;
            int nro = Convert.ToInt32(Session["nroOrden"]);

            repor.ExportToHttpResponse(ExportFormatType.PortableDocFormat, this.Page.Response, true, "Orden Nro " + Convert.ToString(nro));

        }

        protected void btnExportWord_Click(object sender, EventArgs e)
        {
            ReportDocument repor = Session["reportdoc"] as ReportDocument;
            int nro = Convert.ToInt32(Session["nroOrden"]);

            repor.ExportToHttpResponse(ExportFormatType.WordForWindows, this.Page.Response, true, "Orden Nro " + Convert.ToString(nro));
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassBusiness;
using WSLogis.Helper;
using System.Data;
using System.Web.UI;
using System.IO;
using System.Data;
using System.Data.OleDb;

namespace WSLogis.Administracion
{
    public partial class WFProyectosSearch : System.Web.UI.Page
    {
        CBProyecto objProyecto;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) {
                Page.Title = "Proyectos";
                CargarGrillaProyecto();
                CargarComboGrupo();
            
            }
        }

        public void CargarGrillaProyecto() {

            objProyecto = new CBProyecto();

            GridProyectos.DataSource = objProyecto.GetProyectos("1", "0");
            GridProyectos.DataBind();

        
        }

        protected void btnNuevoPro_Click(object sender, EventArgs e)
        {
            titlePopup.Text = "Nuevo Proyecto";
            Session["ParmCodigoProyect"] = null;
            LimpiarContorles();
           // this.ModalPopup1Ext.Show();
        }

        public void AsignarValoresControles( string codProy) {

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

        public void CargarComboGrupo() {

            objProyecto = new CBProyecto();
            ddlGrupoPoryecto.DataSource = objProyecto.GetGrupoProyectos();
            ddlGrupoPoryecto.DataValueField = "Codigo";
            ddlGrupoPoryecto.DataTextField = "Descripcion";
            ddlGrupoPoryecto.DataBind();
            ddlGrupoPoryecto.Items.Insert(0, "Seleccione Grupo ");
        }

        public void LimpiarContorles() {


            ddlGrupoPoryecto.SelectedIndex = 0;
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            txtFechaInicio.Text = "";
            txtFechaFin.Text = "";
            chckEstado.Checked = true;
            
        
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {

            if (ddlGrupoPoryecto.SelectedIndex > 0)
            {
                string msj = "";
               
                if (Session["ParmCodigoProyect"].ToString() == "") {

                    msj = InsertarProyecto();

                    this.ShowSuccessfulNotification(msj , 3000);
                    CargarGrillaProyecto();
                
                }

                else if (Session["ParmCodigoProyect"].ToString() != ""){

                    msj = ActualizarProyecto();

                    this.ShowSuccessfulNotification(msj, 3000);
                    CargarGrillaProyecto();
                     
                }



            }

            else {

                this.ShowErrorNotification("Seleccione un Grupo correcto ", 3000);
            
            }


        }


        public void InsertarCodigosPresupuestal() {

            int codProyec = Convert.ToInt32(Session["ParmCodigoProyect"].ToString());
            int codUser = Convert.ToInt32(Session["CodigoUsuario"].ToString());
            string glosa = "";
            string codigo = "";
            string msj = "";

            for (int i = 0; i < GridCodigosProyecto.Rows.Count; i++) { /**/

                objProyecto = new CBProyecto();
                codigo = GridCodigosProyecto.Rows[i].Cells[0].Text;
                glosa = GridCodigosProyecto.Rows[i].Cells[1].Text; 
             msj = objProyecto.InsertarCodigoPresupuestal(codProyec, codigo, glosa, codUser);
           
            }
            CargarGridCodigosProyecto(codProyec);
            this.ShowSuccessfulNotification(msj, 2500);
            
          

        }

        public string InsertarProyecto() {


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

        public void LoadExcelTogrid() { /**/
           
            String strConnection = "ConnectionString";
            string connectionString = "";
            string fileName = Path.GetFileName(fileUploadExcel.PostedFile.FileName);
            string fileExtension = Path.GetExtension(fileUploadExcel.PostedFile.FileName);
            string fileLocation = Server.MapPath("~/App_Data/" + fileName);
            fileUploadExcel.SaveAs(fileLocation);
            if (fileExtension == ".xls")
            {
                connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" +
                  fileLocation + ";Extended Properties=\"Excel 8.0;HDR=No;IMEX=2\"";
            }
            else if (fileExtension == ".xlsx")
            {
                connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                  fileLocation + ";Extended Properties=\"Excel 12.0;HDR=No;IMEX=2\"";
            }
            OleDbConnection con = new OleDbConnection(connectionString);
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Connection = con;
            OleDbDataAdapter dAdapter = new OleDbDataAdapter(cmd);
            DataTable dtExcelRecords = new DataTable();
            DataTable dtExcelRecords2 = new DataTable();
            con.Open();
            DataTable dtExcelSheetName = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            string getExcelSheetName = dtExcelSheetName.Rows[2]["Table_Name"].ToString();
            cmd.CommandText = "SELECT F2 As Codigo , F3 As Descripcion FROM [" + getExcelSheetName + "]";
            //"SELECT F1 As FirstName, F2 As MiddleName, F3 As LastName FROM [Sheet1$] ORDER BY F3"
            dAdapter.SelectCommand = cmd;
            dAdapter.Fill(dtExcelRecords);

            // tabla de presupuestos y costo unitario 
            string getExcelSheetName2 = dtExcelSheetName.Rows[1]["Table_Name"].ToString();
            cmd.CommandText = "SELECT F6 As Cantidad , F7 As Codigo , F8 As CostoUnit FROM [" + getExcelSheetName2 + "]";
            //"SELECT F1 As FirstName, F2 As MiddleName, F3 As LastName FROM [Sheet1$] ORDER BY F3"
            dAdapter.SelectCommand = cmd;
            dAdapter.Fill(dtExcelRecords2);
            Session["dtCostoPresupuesto"] =  CleanDataTableCostosPresupuesto(dtExcelRecords2);
          //GridCodigosProyecto

            GridCodigosProyecto.DataSource = CleanDataTable(dtExcelRecords);
            GridCodigosProyecto.DataBind(); 
        }

        public DataTable CleanDataTable( DataTable dtexcel) { /**/

            DataTable dtvar = dtexcel;
            DataTable result = dtexcel.Clone();
            result.Clear();
            string num = "";
            bool var_res = false;
            int outnum = 0;

            dtvar.Rows.RemoveAt(0);
            for (int i = 0; i < dtvar.Rows.Count; i++) 
            { /**/
                num = dtvar.Rows[i]["Codigo"].ToString();

                if (num == "")
                {

                    num = "none";
                }
                else {

                    num = num.Substring(0, 3);
                }

                var_res = Int32.TryParse(num, out outnum);
                if (var_res==true)
                { /**/
                    string cod = dtvar.Rows[i]["Codigo"].ToString();
                    string descp = dtvar.Rows[i]["Descripcion"].ToString();
                    result.Rows.Add(cod, descp);
                    
                
                }
                else
                { /**/
                   // dtexcel.Rows.RemoveAt(i);
                
                }
            
            
            }

            
            return result;
        
        }

        public DataTable CleanDataTableCostosPresupuesto(DataTable dtCostosPre) { /**/

            DataTable result = dtCostosPre.Clone();
            result.Clear();

            dtCostosPre.Rows.RemoveAt(0);


            for (int i = 0; i < dtCostosPre.Rows.Count; i++)
            { /**/
                bool flag = false;
                int outnum = 0;
                if (dtCostosPre.Rows[i]["Codigo"] != null && dtCostosPre.Rows[i]["Codigo"].ToString() !="")
                { /**/
                 
                    string var_get = dtCostosPre.Rows[i]["Codigo"].ToString();
                    var_get = var_get.Substring(0, 3);
                    flag = Int32.TryParse(var_get, out outnum);
                }
                else {
                    flag = false;
                }


                if (flag == true)
                { /**/
                    string cant = dtCostosPre.Rows[i]["Cantidad"].ToString();
                    string cod = dtCostosPre.Rows[i]["Codigo"].ToString();
                    string costoU = dtCostosPre.Rows[i]["CostoUnit"].ToString();
                    result.Rows.Add(cant,cod, costoU);


                }
                else
                { /**/
                    // dtexcel.Rows.RemoveAt(i);

                }


            }

            return result;

        }
        public string ActualizarProyecto() {


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


        public int VerificarCheckEstado (){
            int result = 3;
            if (chckEstado.Checked == true)
            {

                result = 1;
            }

            else {

                result = 0;
            }

            return result;
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            LinkButton boton = sender as LinkButton; 
            GridViewRow gridview = (GridViewRow)boton.NamingContainer;
            Session["ParmCodigoProyect"] = GridProyectos.DataKeys[gridview.RowIndex].Value.ToString();
            AsignarValoresControles(Session["ParmCodigoProyect"].ToString());
            titlePopup.Text = "Editar Proyecto >" + txtNombre.Text; 
           // this.ModalPopup1Ext.Show();
        }

        protected void lkbtnCodigoPre_Click(object sender, EventArgs e)
        {
            LinkButton boton = sender as LinkButton;
            GridViewRow gridview = (GridViewRow)boton.NamingContainer;
            Session["ParmCodigoProyect"] = GridProyectos.DataKeys[gridview.RowIndex].Value.ToString();
           CargarGridCodigosProyecto(Convert.ToInt32(Session["ParmCodigoProyect"].ToString()));
            //txtCodPresp.Text = "";
            //txtCodDescripcion.Text = "";
            this.ModalPopUp2.Show();
        }

        protected void lkbtnAgregarPre_Click(object sender, EventArgs e)
        {
            LoadExcelTogrid();
            this.ModalPopUp2.Show();
        }

        public void CargarGridCodigosProyecto( int cod ) {

            objProyecto = new CBProyecto();
            GridCodigosProyecto.DataSource = objProyecto.GetProyectosCodigoPresupuesal(cod);
            GridCodigosProyecto.DataBind();
            
                   
        }

        protected void lkbtnCancel_Click(object sender, EventArgs e)
        {
            this.ModalPopUp2.Hide();
        }

        protected void lkbtnGrabar_Click(object sender, EventArgs e)
        {
            if (ddlGrupoPoryecto.SelectedIndex > 0)
            {
                string msj = "";

                if (Session["ParmCodigoProyect"].ToString() == "")
                {

                    msj = InsertarProyecto();

                    this.ShowSuccessfulNotification(msj, 3000);
                    CargarGrillaProyecto();

                }

                else if (Session["ParmCodigoProyect"].ToString() != "")
                {

                    msj = ActualizarProyecto();

                    this.ShowSuccessfulNotification(msj, 3000);
                    CargarGrillaProyecto();

                }



            }

            else
            {

                this.ShowErrorNotification("Seleccione un Grupo correcto ", 3000);

            }
        }

        protected void lkbtnGrabarCodPresp_Click(object sender, EventArgs e)
        {

            InsertDirectPresupuesto();
        }

        public void InsertDirectPresupuesto() { /**/
            if (GridCodigosProyecto.Rows.Count > 0)
            { /**/

                InsertarCodigosPresupuestal();
                DataTable vardtSession = Session["dtCostoPresupuesto"] as DataTable;
                AsignarCostoUnitarioPresupuesto(vardtSession);
            }
        
        }

        public void AsignarCostoUnitarioPresupuesto(DataTable dtSession) { /**/

            for (int i = 0; i < dtSession.Rows.Count; i++) { /**/
                objProyecto = new CBProyecto();
                int  cant =  Convert.ToInt32( dtSession.Rows[i]["Cantidad"].ToString());
                string cod = dtSession.Rows[i]["Codigo"].ToString();
                decimal  costoU = Convert.ToDecimal( dtSession.Rows[i]["CostoUnit"]);
                objProyecto.InsertarTableTemp(cod, cant, costoU);
            }

            InsertarCostoUnitarioPresupuesto();
        
        }

        public void InsertarCostoUnitarioPresupuesto() { /**/

            bool flag = false;
            objProyecto = new CBProyecto();
            DataTable dtRes = objProyecto.GetTempDataCosto();
            for (int i = 0; i < dtRes.Rows.Count; i++) 
            { /**/
                int codProyecto = Convert.ToInt32(Session["ParmCodigoProyect"]);
                int cantidad = Convert.ToInt32( dtRes.Rows[i]["Cantidad"].ToString());
                string codigo = dtRes.Rows[i]["Codigo"].ToString();
                decimal costoTotal = Convert.ToDecimal(dtRes.Rows[i]["CostoTotal"].ToString());
                decimal cosotoUnitario = costoTotal / cantidad;
                objProyecto = new CBProyecto();
                flag = objProyecto.InsertarCostosCodigosPresupuesto(codProyecto, codigo, cantidad, costoTotal, cosotoUnitario);
                
            }


            if (flag == true) { /**/

                this.ShowSuccessfulNotification("Se registro correctamente ", 2000);
            }


        }

       

        
    }
}
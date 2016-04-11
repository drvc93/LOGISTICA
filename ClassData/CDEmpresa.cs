using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ClassData
{
     public class CDEmpresa
    {
        string Conn;
        SqlConnection cn;
        string spSPS_LISTAR_EMPRSAS = "SPS_LISTAR_EMPRSAS";



        public CDEmpresa() {

            Conn = System.Configuration.ConfigurationManager.AppSettings["eConnectionString"];
            cn = new SqlConnection(Conn);
             
        }

        public DataTable GetEmpresas() {


            SqlDataAdapter dap = new SqlDataAdapter(spSPS_LISTAR_EMPRSAS, cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
         
            dap.Fill(dt);
            return dt;
          


        }
    }
}

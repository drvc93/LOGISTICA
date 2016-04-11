using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ClassData
{
     public class CDPresentacion
    {
         string spSPS_LISTAR_TIPO_PRESENTACION = "SPS_LISTAR_TIPO_PRESENTACION";
        string Conn;
        SqlConnection cn;

         


        public CDPresentacion() {

            Conn = System.Configuration.ConfigurationManager.AppSettings["eConnectionString"];
            cn = new SqlConnection(Conn);
        
        
        }


        public DataTable GetPresentacion() {

            SqlDataAdapter dap = new SqlDataAdapter(spSPS_LISTAR_TIPO_PRESENTACION, cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
         
            dap.Fill(dt);
            return dt;
        
        
        }

    }
}

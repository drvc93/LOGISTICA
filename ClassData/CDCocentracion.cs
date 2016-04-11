using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ClassData
{
     public class CDCocentracion
    {

        string Conn;
        SqlConnection cn;
        string spSPS_LISTAR_CONCENTRACION = "SPS_LISTAR_CONCENTRACION";


        public CDCocentracion() {

            Conn = System.Configuration.ConfigurationManager.AppSettings["eConnectionString"];
            cn = new SqlConnection(Conn);
        
        
        }


        public DataTable GetCocentracion() {

            SqlDataAdapter dap = new SqlDataAdapter(spSPS_LISTAR_CONCENTRACION, cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.Fill(dt);
            return dt;
          
        
        
        }



    }
}

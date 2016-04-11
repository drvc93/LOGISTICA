using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ClassData
{
     public class CDNivelesAprobacion
    {

        string Conn;
        SqlConnection cn;
        string spSPS_LOCAL_NIVELES_DE_APROBACION = "SPS_LOCAL_NIVELES_DE_APROBACION";

        public CDNivelesAprobacion() {


            Conn = System.Configuration.ConfigurationManager.AppSettings["eConnectionString"];
            cn = new SqlConnection(Conn);
        }


        public DataTable GetNivelesAprobacion(int codNieveles) {


            SqlDataAdapter dap = new SqlDataAdapter(spSPS_LOCAL_NIVELES_DE_APROBACION, cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@CodigoLocal", codNieveles);

            dap.Fill(dt);
            return dt;

        
        }

    }
}

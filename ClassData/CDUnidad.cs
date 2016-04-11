using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ClassData
{
     public class CDUnidad
    {
        string Conn;
        SqlConnection cn;
        string spSPS_LISTAR_UNIDAD_MEDIDA = "SPS_LISTAR_UNIDAD_MEDIDA";



        public CDUnidad() {

            Conn = System.Configuration.ConfigurationManager.AppSettings["eConnectionString"];
            cn = new SqlConnection(Conn);
        }


        public DataTable GetUnidadMedida() {

            SqlDataAdapter dap = new SqlDataAdapter(spSPS_LISTAR_UNIDAD_MEDIDA, cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.Fill(dt);
            return dt;


        
        }


    }
}

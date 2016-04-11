using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ClassData
{
     public class CDProveedor
    {


        string Conn;
        SqlConnection cn;
        string spSPS_LISTAR_PROVEEDOR = "SPS_LISTAR_PROVEEDOR";

        public CDProveedor() {
            Conn = System.Configuration.ConfigurationManager.AppSettings["eConnectionString"];
            cn = new SqlConnection(Conn);
        
        }

        public DataTable GetProveedor(string accion , string descripcion) {


            SqlDataAdapter dap = new SqlDataAdapter(spSPS_LISTAR_PROVEEDOR, cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@accion", accion);
            dap.SelectCommand.Parameters.AddWithValue("@descripcion", descripcion);
            dap.Fill(dt);
            return dt;
        
        }
    }
}

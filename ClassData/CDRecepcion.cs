using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace ClassData
{
     public class CDRecepcion
    {

         string spSPI_RECEPCION_OC_CABECERA = "SPI_RECEPCION_OC_CABECERA";
         string spSPI_RECEPCION_OC_DETALLE = "SPI_RECEPCION_OC_DETALLE";
         const string spSPS_ORDENES_POR_INGRESAR = "SPS_ORDENES_POR_INGRESAR";

        string Conn;
        SqlConnection cn;
         public CDRecepcion() { /**/

             Conn = System.Configuration.ConfigurationManager.AppSettings["eConnectionString"];
             cn = new SqlConnection(Conn);
         }


         public int InsertarCabeceraRecepcion(int codOC, int userRecepcion, string nroFactura, string nroGuiaRemision, DateTime FechaRemision, string observacion, int RecepcionSistemas,int estatus ,  int userReg)
         { /**/

             int result = 0;
             SqlCommand sqlcmd = new SqlCommand();
             sqlcmd.Connection = cn;
             try
             {
                 sqlcmd.CommandText = spSPI_RECEPCION_OC_CABECERA;
                 sqlcmd.CommandType = CommandType.StoredProcedure;
                 cn.Open();

                 sqlcmd.Parameters.AddWithValue("@codOC", codOC);

                 sqlcmd.Parameters.AddWithValue("@userRecepcion", userRecepcion);
                 sqlcmd.Parameters.AddWithValue("@nroFactura", nroFactura);

                 sqlcmd.Parameters.AddWithValue("@nroGuiaRemision", nroGuiaRemision);
                 sqlcmd.Parameters.AddWithValue("@FechaRemision", FechaRemision);
                 sqlcmd.Parameters.AddWithValue("@observacion", observacion);
                 sqlcmd.Parameters.AddWithValue("@recepcionSistemas", RecepcionSistemas);
                 sqlcmd.Parameters.AddWithValue("@estatus", estatus);         
                 sqlcmd.Parameters.AddWithValue("@userReg", userReg);
                 SqlParameter idPedido = sqlcmd.Parameters.Add("@codRecepcion", SqlDbType.BigInt);
                 idPedido.Direction = ParameterDirection.Output;

                 if (sqlcmd.ExecuteNonQuery() > 0)
                 {
                     string var = sqlcmd.Parameters["@codRecepcion"].Value.ToString(); 
                     result = Convert.ToInt32(var);



                 }
             }



             catch (SqlException ex)
             {

                 result = -1;
                 string msj = ex.Message;


             }

             return result;


         }


         public int InsertarDetalleRecepcion(int codRecepcion ,int codigoOCdetalle , int cantRecibida ,int estatus , int userReg) 
         { /**/

             int result = 0;
             SqlCommand sqlcmd = new SqlCommand();
             sqlcmd.Connection = cn;
             try
             {
                 sqlcmd.CommandText = spSPI_RECEPCION_OC_DETALLE;
                 sqlcmd.CommandType = CommandType.StoredProcedure;
                 cn.Open();

                 sqlcmd.Parameters.AddWithValue("@codigoRecepcion", codRecepcion);

                 sqlcmd.Parameters.AddWithValue("@codigoOCDetalle", codigoOCdetalle);
                 sqlcmd.Parameters.AddWithValue("@cantidadRecibida", cantRecibida);

                 sqlcmd.Parameters.AddWithValue("@estatus", 1);
                 sqlcmd.Parameters.AddWithValue("@userReg", userReg);
                

                 if (sqlcmd.ExecuteNonQuery() == 1)
                 {
                     
                     result = 1;



                 }
             }



             catch (SqlException ex)
             {

                 result = 0;
                 string msj = ex.Message;


             }

             return result;



         
         }

         public DataTable OrdenesPorIngresar( string accion  ) 
         {
             SqlDataAdapter dap = new SqlDataAdapter(spSPS_ORDENES_POR_INGRESAR, cn);
             DataTable dt = new DataTable();
             dap.SelectCommand.CommandType = CommandType.StoredProcedure;
             dap.SelectCommand.Parameters.AddWithValue("@accion", accion);
             

             dap.Fill(dt);
             return dt;
             
         }

         public DataTable OrdenesPorIngresar(string accion, int codRC, int codProd)
         {

             SqlDataAdapter dap = new SqlDataAdapter(spSPS_ORDENES_POR_INGRESAR, cn);
             DataTable dt = new DataTable();
             dap.SelectCommand.CommandType = CommandType.StoredProcedure;
             dap.SelectCommand.Parameters.AddWithValue("@accion", accion);
             dap.SelectCommand.Parameters.AddWithValue("@codRC", codRC);
             dap.SelectCommand.Parameters.AddWithValue("@CodProducto", codProd);


             dap.Fill(dt);
             return dt;
             
          }
    }
}

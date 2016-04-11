using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ClassData
{
     public class CDLocal
    {

        string Conn;
        SqlConnection cn;
        string spSPS_LISTAR_LOCALES = "SPS_LISTAR_LOCALES";
        string spSPI_LOCAL = "SPI_LOCAL";
        string spSPI_LOCAL_TIPO_NIVEL_APROBACION = "SPI_LOCAL_TIPO_NIVEL_APROBACION";


        public CDLocal() {

            Conn = System.Configuration.ConfigurationManager.AppSettings["eConnectionString"];
            cn = new SqlConnection(Conn);
         
        }


       

        public DataTable GetLocales(string accion, string param) {



            SqlDataAdapter dap = new SqlDataAdapter(spSPS_LISTAR_LOCALES, cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@accion", accion);
            dap.SelectCommand.Parameters.AddWithValue("@codLocal", Convert.ToInt32(param));
            dap.Fill(dt);
            return dt;
        
        
        }


        public DataTable GetLocalesPorNombre(string accion , string param) {


            SqlDataAdapter dap = new SqlDataAdapter(spSPS_LISTAR_LOCALES, cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@accion", accion);
            dap.SelectCommand.Parameters.AddWithValue("@nombre", param);
            dap.Fill(dt);
            return dt;
          
        
        }

        public string InsertarLocal( int codEmpresa , string nombre , string descripcion, string direccion , string distrito ,string telefono , int estatus , int userReg ) {

            string result = "" ;

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = cn;

            try
            {

                sqlcmd.CommandText = spSPI_LOCAL;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                // parameter 

                sqlcmd.Parameters.AddWithValue("@accion", "1");
                sqlcmd.Parameters.AddWithValue("@CodEmpresa", codEmpresa);
                sqlcmd.Parameters.AddWithValue("@nombre", nombre);
                sqlcmd.Parameters.AddWithValue("@descripcion", descripcion); 
                sqlcmd.Parameters.AddWithValue("@direccion", direccion);
                sqlcmd.Parameters.AddWithValue("@distrito", distrito);
                sqlcmd.Parameters.AddWithValue("@telefono", telefono);
                sqlcmd.Parameters.AddWithValue("@estatus", estatus);
                sqlcmd.Parameters.AddWithValue("@userReg", userReg);
                if (sqlcmd.ExecuteNonQuery() == 1)
                {
                    result = "Se registro correctamente";

                }

            }


            catch (Exception ex) {

                result = ex.Message;
            }


            return result;

        
        }

         


        public string ActualizarLocal( int codLocal , int codEmpresa, string nombre, string descripcion, string direccion, string distrito, string telefono, int estatus, int userReg)
        {

            string result = "";

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = cn;

            try
            {

                sqlcmd.CommandText = spSPI_LOCAL;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                // parameter 

                sqlcmd.Parameters.AddWithValue("@accion", "2");
                sqlcmd.Parameters.AddWithValue("@codLocal", codLocal);
                sqlcmd.Parameters.AddWithValue("@CodEmpresa", codEmpresa);
                sqlcmd.Parameters.AddWithValue("@nombre", nombre);
                sqlcmd.Parameters.AddWithValue("@descripcion", descripcion);
                sqlcmd.Parameters.AddWithValue("@direccion", direccion);
                sqlcmd.Parameters.AddWithValue("@distrito", distrito);
                sqlcmd.Parameters.AddWithValue("@telefono", telefono);
                sqlcmd.Parameters.AddWithValue("@estatus", estatus);
                sqlcmd.Parameters.AddWithValue("@userEdit", userReg);
                if (sqlcmd.ExecuteNonQuery() == 1)
                {
                    result = "Se actualizo correctamente";

                }

            }


            catch (Exception ex)
            {

                result = ex.Message;
            }


            return result;


        }

        public bool AsignarNieveles( int  codLocal ,  int codNivelAprobacion , int estado  , int UserReg ) {

             bool result =false;

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = cn;

            try
            {

                sqlcmd.CommandText = spSPI_LOCAL_TIPO_NIVEL_APROBACION;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                // parameter 

                sqlcmd.Parameters.AddWithValue("@codigoLocal", codLocal);
                sqlcmd.Parameters.AddWithValue("@codigoNivelAprobacion", codNivelAprobacion);
                sqlcmd.Parameters.AddWithValue("@estado", estado);
                sqlcmd.Parameters.AddWithValue("@userReg", UserReg);
                if (sqlcmd.ExecuteNonQuery() == 1)
                {
                    result = true;

                }

            }


            catch (Exception ex)
            {

                string msj = ex.Message;
                result = false;
            }

            finally {

                sqlcmd.Connection.Close();
            }


            return result;

        
         



        
        }


    }
}

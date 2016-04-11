using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ClassData
{
     public class CDProyecto
    {
        string Conn;
        SqlConnection cn;
        const string spSPS_LISTAR_PROYECTO = "SPS_LISTAR_PROYECTO";
        const string spSPS_LISTAR_GRUPO_PROYECTO = "SPS_LISTAR_GRUPO_PROYECTO";
        const string spSPI_PROYECTO = "SPI_PROYECTO";
        const string spSPS_LISTAR_PROYECTOS_CODIGOS_PRESUPUESTAL = "SPS_LISTAR_PROYECTOS_CODIGOS_PRESUPUESTAL";
        const string spSPI_PROYECTO_CODIGO_PRESUPUESTAL = "SPI_PROYECTO_CODIGO_PRESUPUESTAL";
        const string spSPI_INSERT_TEMP_TABLE = "SPI_INSERT_TEMP_TABLE";
        const string spSPS_COSTO_PRESUPUESTO_PROYECTO = "SPS_COSTO_PRESUPUESTO_PROYECTO";
        const string spSPI_COSTOS_CODIGO_PROYECTO = "SPI_COSTOS_CODIGO_PROYECTO";


        public CDProyecto() {

            Conn = System.Configuration.ConfigurationManager.AppSettings["eConnectionString"];
            cn = new SqlConnection(Conn);

        }
        public DataTable GetAllProyectos(string accion) { /**/
            SqlDataAdapter dap = new SqlDataAdapter(spSPS_LISTAR_PROYECTO, cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@accion", accion);        
            dap.Fill(dt);
            cn.Close();
            return dt;
        
        }
         
        public DataTable GetProyectos(string accion , string param ) {


            SqlDataAdapter dap = new SqlDataAdapter(spSPS_LISTAR_PROYECTO, cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@accion",accion );
            dap.SelectCommand.Parameters.AddWithValue("@codProyecto", Convert.ToInt32(param));
            dap.Fill(dt);
            cn.Close();
            return dt;

            
        
        }

        public DataTable GetProyectos(string accion, int codUser)
        {


            SqlDataAdapter dap = new SqlDataAdapter(spSPS_LISTAR_PROYECTO, cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@accion", accion);
            dap.SelectCommand.Parameters.AddWithValue("@codUsuario", codUser);
            dap.Fill(dt);
            cn.Close();
            return dt;



        }

        public DataTable GetGrupoProyectos() {
             
            SqlDataAdapter dap = new SqlDataAdapter(spSPS_LISTAR_GRUPO_PROYECTO, cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.Fill(dt);
            cn.Close();
            return dt;
        }


        public DataTable GetProyectosCodigoPresupuesal(int codProyecto) {

            SqlDataAdapter dap = new SqlDataAdapter(spSPS_LISTAR_PROYECTOS_CODIGOS_PRESUPUESTAL, cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@codProyecto", codProyecto);
           
            dap.Fill(dt);
            cn.Close();
            return dt;
            

        
        }

        public string InsertarCodigoPresupuestal(int codProyecto ,  string codigo , string glosa ,int codUserReg) {

            string result = "";

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = cn;

            try
            {

                sqlcmd.CommandText = spSPI_PROYECTO_CODIGO_PRESUPUESTAL;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                // parameter 

                sqlcmd.Parameters.AddWithValue("@CodProyecto", codProyecto);
                sqlcmd.Parameters.AddWithValue("@Codigo", codigo);
                sqlcmd.Parameters.AddWithValue("@glosa",  glosa);
                sqlcmd.Parameters.AddWithValue("@userReg", codUserReg);
               
                if (sqlcmd.ExecuteNonQuery() == 1)
                {
                    result = "Se registro correctamente";

                }

            }


            catch (Exception ex)
            {

                result = ex.Message;
            }
            finally { cn.Close(); }

            return result;

        }

         public string InsertarProyecto(string accion , int codGrupoProyect ,string nombre , string descripcion,string fechaIn , string fechaFin, int estado , int userReg ){


             string result = "";

             SqlCommand sqlcmd = new SqlCommand();
             sqlcmd.Connection = cn;

             try
             {

                 sqlcmd.CommandText = spSPI_PROYECTO;
                 sqlcmd.CommandType = CommandType.StoredProcedure;
                 cn.Open();
                 // parameter 

                 sqlcmd.Parameters.AddWithValue("@accion", accion);
                 sqlcmd.Parameters.AddWithValue("@codGrupoProyecto", codGrupoProyect);
                 sqlcmd.Parameters.AddWithValue("@nombreProyecto", nombre);
                 sqlcmd.Parameters.AddWithValue("@descripcion", descripcion);
                 sqlcmd.Parameters.AddWithValue("@fechaIni", Convert.ToDateTime(fechaIn));
                 sqlcmd.Parameters.AddWithValue("@fechaFin", Convert.ToDateTime(fechaFin));
                 sqlcmd.Parameters.AddWithValue("@estado", estado);
                 sqlcmd.Parameters.AddWithValue("@userReg", userReg);
                 if (sqlcmd.ExecuteNonQuery() == 1)
                 {
                     result = "Se registro correctamente";

                 }

             }


             catch (Exception ex)
             {

                 result = ex.Message;
             }


             return result;

         
         }


         public string ActualizarProyecto(int codProyecto ,string accion, int codGrupoProyect, string nombre, string descripcion, string fechaIn, string fechaFin, int estado, int userReg)
         {


             string result = "";

             SqlCommand sqlcmd = new SqlCommand();
             sqlcmd.Connection = cn;

             try
             {

                 sqlcmd.CommandText = spSPI_PROYECTO;
                 sqlcmd.CommandType = CommandType.StoredProcedure;
                 cn.Open();
                 // parameter 

                 sqlcmd.Parameters.AddWithValue("@accion", accion);
                 sqlcmd.Parameters.AddWithValue("@codProyecto",codProyecto);
                 sqlcmd.Parameters.AddWithValue("@codGrupoProyecto", codGrupoProyect);
                 sqlcmd.Parameters.AddWithValue("@nombreProyecto", nombre);
                 sqlcmd.Parameters.AddWithValue("@descripcion", descripcion);
                 sqlcmd.Parameters.AddWithValue("@fechaIni", Convert.ToDateTime(fechaIn));
                 sqlcmd.Parameters.AddWithValue("@fechaFin", Convert.ToDateTime(fechaFin));
                 sqlcmd.Parameters.AddWithValue("@estado", estado);
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

         public void InsertarTableTemp(string cod, int cant, decimal CostoUnit) 
         { /**/
            

             SqlCommand sqlcmd = new SqlCommand();
             sqlcmd.Connection = cn;

             try
             {

                 sqlcmd.CommandText = spSPI_INSERT_TEMP_TABLE;
                 sqlcmd.CommandType = CommandType.StoredProcedure;
                 cn.Open();
                 // parameter 

                 sqlcmd.Parameters.AddWithValue("@codigo", cod);
                 sqlcmd.Parameters.AddWithValue("@cantidad", cant);
                 sqlcmd.Parameters.AddWithValue("@costoUnit", CostoUnit );
                 sqlcmd.ExecuteNonQuery();
                 

             }



             catch (Exception ex)
             {

              
             }
             finally { /**/

                 cn.Close();
             }

         
             
         
         
         }

         public DataTable GetTempDataCosto ()
         { /**/

             SqlDataAdapter dap = new SqlDataAdapter(spSPS_COSTO_PRESUPUESTO_PROYECTO, cn);
             DataTable dt = new DataTable();
             dap.SelectCommand.CommandType = CommandType.StoredProcedure;
             dap.Fill(dt);
             cn.Close();
             return dt;
         }


         public bool InsertarCostosCodigosPresupuesto(int codProyecto , string codPresupuesto , int Cantidad , decimal MontoTotal , decimal montoUnitario) { /**/

             SqlCommand sqlcmd = new SqlCommand();
             sqlcmd.Connection = cn;
             bool res = false;

            

             try
             {

                 sqlcmd.CommandText = spSPI_COSTOS_CODIGO_PROYECTO;
                 sqlcmd.CommandType = CommandType.StoredProcedure;
                 cn.Open();
                 // parameter 

                 sqlcmd.Parameters.AddWithValue("@codProyecto", codProyecto);
                 sqlcmd.Parameters.AddWithValue("@codigoPresupuestal", codPresupuesto);
                 sqlcmd.Parameters.AddWithValue("@cantidad", Cantidad);
                 sqlcmd.Parameters.AddWithValue("@costoUnit", montoUnitario);
                 sqlcmd.Parameters.AddWithValue("@costoTotal", MontoTotal);

                 if (sqlcmd.ExecuteNonQuery() == 1) { /**/


                     res = true;
                 }


             }


             catch (Exception ex)
             {

                 res = false;
             }
             finally {

                 cn.Close();
             }


             return res;
         }
    }
}

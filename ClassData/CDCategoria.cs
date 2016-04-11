using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ClassData
{ 
    public  class CDCategoria
    {
        #region  Atributos 

           string Conn;
           SqlConnection cn;
          string spSPS_LISTAR_CATEGORIAS = "SPS_LISTAR_CATEGORIAS";
        
       
        #endregion Metodos
        

            

        



        #region

          public CDCategoria() {

              Conn = System.Configuration.ConfigurationManager.AppSettings["eConnectionString"];
              cn = new SqlConnection(Conn);

          }



          public DataTable GetCategoria() {

              SqlDataAdapter dap = new SqlDataAdapter(spSPS_LISTAR_CATEGORIAS, cn);
              DataTable dt = new DataTable();
              dap.SelectCommand.CommandType = CommandType.StoredProcedure;
              dap.SelectCommand.Parameters.AddWithValue("@accion", 1);
              dap.Fill(dt);
              return dt;
          
          
          }

          public DataTable GetSubCategoria(int codCateg) {

              SqlDataAdapter dap = new SqlDataAdapter(spSPS_LISTAR_CATEGORIAS, cn);
              DataTable dt = new DataTable();
              dap.SelectCommand.CommandType = CommandType.StoredProcedure;
              dap.SelectCommand.Parameters.AddWithValue("@accion", 2);
              dap.SelectCommand.Parameters.AddWithValue("@codCategoria", codCateg);
              dap.Fill(dt);
              return dt;
          
          
          }

          public DataTable GetSubCategoria() {

              SqlDataAdapter dap = new SqlDataAdapter(spSPS_LISTAR_CATEGORIAS, cn);
              DataTable dt = new DataTable();
              dap.SelectCommand.CommandType = CommandType.StoredProcedure;
              dap.SelectCommand.Parameters.AddWithValue("@accion",3 );
              dap.Fill(dt);
              return dt;

          
          }

        #endregion


       
    }
}

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
    public class CDProducto
    {
        string Conn;
        SqlConnection cn;


        #region  Atributos

        string spSPS_LISTAR_PRODUCTO = "SPS_LISTAR_PRODUCTO";
        string spSPI_PRODUCTO = "SPI_PRODUCTO";

        
        #endregion


        #region Metodos

        public CDProducto()
        {
            Conn = System.Configuration.ConfigurationManager.AppSettings["eConnectionString"];
            cn = new SqlConnection(Conn);
        }

        public DataTable GetProductosPorNombre(string nombre)
        {
            SqlDataAdapter dap = new SqlDataAdapter(spSPS_LISTAR_PRODUCTO, cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@accion", "3");
            dap.SelectCommand.Parameters.AddWithValue("@nombreProducto", nombre);
            dap.Fill(dt);
            return dt;
        }

        public DataTable GetProductoPorCategoria( string accion, int codCategoria , int codSubCate)
        {
            SqlDataAdapter dap = new SqlDataAdapter(spSPS_LISTAR_PRODUCTO, cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@accion", accion);
            dap.SelectCommand.Parameters.AddWithValue("@codigoCategoria", Convert.ToInt32(codCategoria));
            dap.SelectCommand.Parameters.AddWithValue("@codSubCategoria", Convert.ToInt32(codSubCate));
            dap.Fill(dt);
            return dt;
        } 

        public DataTable GetProductos(string accion, string codProd )
        {
            SqlDataAdapter dap = new SqlDataAdapter(spSPS_LISTAR_PRODUCTO, cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@accion",accion  );
            dap.SelectCommand.Parameters.AddWithValue("@codigoProducto", Convert.ToInt32(codProd));
            dap.Fill(dt);
            return dt;
        }

        public DataTable GetProductosPorTipo(string accion, int tipo)
        {
            SqlDataAdapter dap = new SqlDataAdapter(spSPS_LISTAR_PRODUCTO, cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@accion", accion);
            dap.SelectCommand.Parameters.AddWithValue("@tipoProducto", tipo);
            dap.Fill(dt);
            return dt;
        }

        public DataTable GetProductosPorDescripcion (string accion ,  string descripcion )
        {
            SqlDataAdapter dap = new SqlDataAdapter(spSPS_LISTAR_PRODUCTO, cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@accion", accion);
      
            dap.SelectCommand.Parameters.AddWithValue("@descripcion", descripcion);
            dap.Fill(dt);
            return dt;
        }

        public string InsertarProducto(int codCategoria , int codSubCategoria , int codTipoPedido,int codPresentacion , int CodConcentracion, int codUnidad,
                                         string nombre , string descripcion , int expira , int stockmin , string rutaimag1  ,string rutaimg2 ,int estado ,int  userReg  ) {


          string result = "";
          SqlCommand sqlcmd = new SqlCommand();
          sqlcmd.Connection = cn;
          try
          {
              sqlcmd.CommandText = spSPI_PRODUCTO;
              sqlcmd.CommandType = CommandType.StoredProcedure;
              cn.Open();
              sqlcmd.Parameters.AddWithValue("@accion", "1");
              sqlcmd.Parameters.AddWithValue("@codigoCategoria", codCategoria);
              sqlcmd.Parameters.AddWithValue("@codigoSubCategoria", codSubCategoria);
              sqlcmd.Parameters.AddWithValue("@codigoTipoPedido", codTipoPedido);
              sqlcmd.Parameters.AddWithValue("@codigoPresentacion", codPresentacion);
              sqlcmd.Parameters.AddWithValue("@codigoConcentracion", CodConcentracion);
              sqlcmd.Parameters.AddWithValue("@codigoUnidadMed", codUnidad);
              sqlcmd.Parameters.AddWithValue("@nombre", nombre);
              sqlcmd.Parameters.AddWithValue("@descripcion", descripcion);
              sqlcmd.Parameters.AddWithValue("@expira", expira);
              sqlcmd.Parameters.AddWithValue("@stockmin", stockmin);
              sqlcmd.Parameters.AddWithValue("@rutaimg1", rutaimag1);
              sqlcmd.Parameters.AddWithValue("@rutaimg2", rutaimg2);
              sqlcmd.Parameters.AddWithValue("@estado", estado);
              sqlcmd.Parameters.AddWithValue("@userReg", userReg);
              sqlcmd.Parameters.AddWithValue("@fechaEdit", null);
              sqlcmd.Parameters.AddWithValue("@userEdit", null);

              if (sqlcmd.ExecuteNonQuery() == 1)
              {
                  result = "Se registro correctamente";

              }
          }
          catch (SqlException ex)
            {
              result = ex.Message;
          }
          return result;
        }

        public string ActualizarProducto(int codProduct ,int codCategoria, int codSubCategoria, int codTipoPedido, int codPresentacion, int CodConcentracion, int codUnidad,
                                         string nombre, string descripcion, int expira, int stockmin, string rutaimag1, string rutaimg2, int estado, int userReg)
        {


            string result = "";
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = cn;
            try
            {
                sqlcmd.CommandText = spSPI_PRODUCTO;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                sqlcmd.Parameters.AddWithValue("@accion", "2");
                sqlcmd.Parameters.AddWithValue("@codigoproducto", codProduct);
                sqlcmd.Parameters.AddWithValue("@codigoCategoria", codCategoria);
                sqlcmd.Parameters.AddWithValue("@codigoSubCategoria", codSubCategoria);
                sqlcmd.Parameters.AddWithValue("@codigoTipoPedido", codTipoPedido);
                sqlcmd.Parameters.AddWithValue("@codigoPresentacion", codPresentacion);
                sqlcmd.Parameters.AddWithValue("@codigoConcentracion", CodConcentracion);
                sqlcmd.Parameters.AddWithValue("@codigoUnidadMed", codUnidad);
                sqlcmd.Parameters.AddWithValue("@nombre", nombre);
                sqlcmd.Parameters.AddWithValue("@descripcion", descripcion);
                sqlcmd.Parameters.AddWithValue("@expira", expira);
                sqlcmd.Parameters.AddWithValue("@stockmin", stockmin);
                sqlcmd.Parameters.AddWithValue("@rutaimg1", rutaimag1);
                sqlcmd.Parameters.AddWithValue("@rutaimg2", rutaimg2);
                sqlcmd.Parameters.AddWithValue("@estado", estado);
                sqlcmd.Parameters.AddWithValue("@userEdit", userReg);

                if (sqlcmd.ExecuteNonQuery() == 1)
                {
                    result = "Se actualizo correctamente";

                }
            }
            catch (SqlException ex)
            {
                result = ex.Message;
            }
            return result;
        }

        #endregion
    }
}

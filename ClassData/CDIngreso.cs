using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ClassData
{
    public class CDIngreso
    {
        const string spSPI_INGRESO = "SPI_INGRESO";

        string Conn;
        SqlConnection cn;
        public CDIngreso()
        {

            Conn = System.Configuration.ConfigurationManager.AppSettings["eConnectionString"];
            cn = new SqlConnection(Conn);

        }


        public string InsertarIngreso(int codigoOC , int codProducto , int CodLocal , int CodProyecto , int codProveedor, int codFabricante , string modelo , string lote , int Temperatura, DateTime fechaIngr,
                                      DateTime  fechaVenc, int codTipExistencia, int CodComprobante , string OtroComprobante, string serie , string numero , int codTipoOpe , string otroOper , int CantIngreso,
                                        int CantEgres, int CodUsuario, int UserReg )
        {

            string result = "";
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = cn;
            try
            {
                sqlcmd.CommandText = spSPI_INGRESO;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                sqlcmd.Parameters.AddWithValue("@CodigoOC", codigoOC);
                sqlcmd.Parameters.AddWithValue("@CodigoProducto",codProducto);
                sqlcmd.Parameters.AddWithValue("@CodLocal", CodLocal);
                sqlcmd.Parameters.AddWithValue("@CodProyecto", CodProyecto);
                sqlcmd.Parameters.AddWithValue("@CodProveedor", codProveedor);
                sqlcmd.Parameters.AddWithValue("@CodFabricante", codFabricante);
                sqlcmd.Parameters.AddWithValue("@Modelo", modelo);
                sqlcmd.Parameters.AddWithValue("@Lote", lote);
                sqlcmd.Parameters.AddWithValue("@Temperatura", Temperatura);
                sqlcmd.Parameters.AddWithValue("@FechaIngreso", fechaIngr);
                sqlcmd.Parameters.AddWithValue("@FechaVencimiento", fechaVenc);
                sqlcmd.Parameters.AddWithValue("@CodTipoExistencia", codTipExistencia);
                sqlcmd.Parameters.AddWithValue("@CodComprobante", CodComprobante);
                sqlcmd.Parameters.AddWithValue("@OtroComprobante", OtroComprobante);
                sqlcmd.Parameters.AddWithValue("@Serie", serie);
                sqlcmd.Parameters.AddWithValue("@Numero", numero);
                sqlcmd.Parameters.AddWithValue("@CodigoTipoOpe", codTipoOpe);
                sqlcmd.Parameters.AddWithValue("@OtroTipoOper", otroOper);
                sqlcmd.Parameters.AddWithValue("@CantidadIngr", CantIngreso);
                sqlcmd.Parameters.AddWithValue("@CantidadEgr", CantEgres);
                sqlcmd.Parameters.AddWithValue("@CodUsuario", CodUsuario);
                sqlcmd.Parameters.AddWithValue("@UserReg", UserReg);
              



                
                if (sqlcmd.ExecuteNonQuery() == 1)
                {
                    result = "Se realizo el ingreso correctamente";
                   

                }
            }



            catch (SqlException ex)
            {

                
             result = ex.Message;


            }

            return result;

         }
    }
}

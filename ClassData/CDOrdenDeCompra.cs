using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ClassData
{
    public class CDOrdenDeCompra
    {


        string Conn;
        SqlConnection cn;
        string spSPI_ORDEN_COMPRA_DETALLE = "SPI_ORDEN_COMPRA_DETALLE";
        string spSPI_ORDEN_COMPRA = "SPI_ORDEN_COMPRA";
        string spSPS_LISTAR_ORDEN_COMPRA = "SPS_LISTAR_ORDEN_COMPRA";
        string spSPS_LISTAR_ORDEN_COMPRA_DETALLE= "SPS_LISTAR_ORDEN_COMPRA_DETALLE";
        string SPSPS_LISTAR_ORDENES_POR_APROBAR = "SPS_LISTAR_ORDENES_POR_APROBAR";
        string spSPU_ORDEN_COMPRA_APROBACION_RESPONSABLE = "SPU_ORDEN_COMPRA_APROBACION_RESPONSABLE";
        string spSPS_RECEPCION_OC_COMPRA = "SPS_RECEPCION_OC_COMPRA";
        const string spSPS_ACTA_CONFORMIDAD = "SPS_ACTA_CONFORMIDAD";
        public CDOrdenDeCompra() {


            Conn = System.Configuration.ConfigurationManager.AppSettings["eConnectionString"];
            cn = new SqlConnection(Conn);
        
        }


        public DataTable GetListaOrdenes( string accion ) {

            SqlDataAdapter dap = new SqlDataAdapter(spSPS_LISTAR_ORDEN_COMPRA, cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@accion", accion);

            dap.Fill(dt);
            return dt;
        
        
         }

        public DataTable GetListaOrdenDetalle(string accion , int codigoOC) { 
        
            SqlDataAdapter dap = new SqlDataAdapter( spSPS_LISTAR_ORDEN_COMPRA_DETALLE, cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@accion", accion);
            dap.SelectCommand.Parameters.AddWithValue("@CodigoOC", codigoOC);

            dap.Fill(dt);
            return dt;
        
        }


        public int InsertarCompraCabecera(string accion ,int codPedido, int codProveedor  ,int codFormaPago , int estatus , int estado ,  int userReg,int incluyeIGV, 
            decimal TipoCambio,decimal ExoMe, decimal valorVentaMe,decimal igvME,decimal totalME,decimal ExoSL,decimal valorVentaSL,decimal IgvSL,decimal totalSL,string FechaInicio,string FechaFin , string Responsable,string observacion ) {


            int result = 0;
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = cn;
            try
            {
                sqlcmd.CommandText = spSPI_ORDEN_COMPRA;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                sqlcmd.Parameters.AddWithValue("@accion", accion);
                sqlcmd.Parameters.AddWithValue("@codigoPedido", codPedido);
                sqlcmd.Parameters.AddWithValue("@incluyeIGV", incluyeIGV);
                sqlcmd.Parameters.AddWithValue("@codigoProveedor", codProveedor);
                sqlcmd.Parameters.AddWithValue("@codigoFormaPago", codFormaPago);
                sqlcmd.Parameters.AddWithValue("@estatus", estatus);
                sqlcmd.Parameters.AddWithValue("@estado", estado);
                sqlcmd.Parameters.AddWithValue("@userReg", userReg);
                sqlcmd.Parameters.AddWithValue("@TipoCambio", TipoCambio);
                sqlcmd.Parameters.AddWithValue("@exoneradoME", ExoMe);
                sqlcmd.Parameters.AddWithValue("@valorVentaME", valorVentaMe);
                sqlcmd.Parameters.AddWithValue("@igvME", igvME);
                sqlcmd.Parameters.AddWithValue("@TotalME", totalME);
                sqlcmd.Parameters.AddWithValue("@exoneradoSL", ExoSL);
                sqlcmd.Parameters.AddWithValue("@valorVentaSL", valorVentaSL);
                sqlcmd.Parameters.AddWithValue("@igvSL", IgvSL);
                sqlcmd.Parameters.AddWithValue("@TotalSL", totalSL);
                sqlcmd.Parameters.AddWithValue("@FechaInicio", FechaInicio);
                sqlcmd.Parameters.AddWithValue("@FechaFin", FechaFin);
                sqlcmd.Parameters.AddWithValue("@responsable", Responsable);
                sqlcmd.Parameters.AddWithValue("@observ", observacion);
                
                SqlParameter idPedido = sqlcmd.Parameters.Add("@codigoOC", SqlDbType.BigInt);
                idPedido.Direction = ParameterDirection.Output;
                int varExe = sqlcmd.ExecuteNonQuery();
                if (varExe == 2)
                {
                    string var = sqlcmd.Parameters["@codigoOC"].Value.ToString(); ;
                    result = Convert.ToInt32(var);



                }
            }



            catch (Exception ex)
            {

                result = -1;
                string msj = ex.Message;


            }

            return result;

        
        }


        public int InsertarCompraDetalle( string accion ,int codigoOC , int codPedido , int CodPedidoDetalle  , int estatus , int estado , int UserReg,int codGarantia , DateTime fechaEntrega) {



            int result = 0;
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = cn;
            try
            {
                sqlcmd.CommandText = spSPI_ORDEN_COMPRA_DETALLE;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                sqlcmd.Parameters.AddWithValue("@accion", accion);
                sqlcmd.Parameters.AddWithValue("@codigoOC",  codigoOC);
                sqlcmd.Parameters.AddWithValue("@codigoPedido", codPedido);
                sqlcmd.Parameters.AddWithValue("@codigoPedidoDetalle", CodPedidoDetalle);
                sqlcmd.Parameters.AddWithValue("@estatus", estatus);
                sqlcmd.Parameters.AddWithValue("@estado", estado);
                sqlcmd.Parameters.AddWithValue("@codGarantia", codGarantia);
                sqlcmd.Parameters.AddWithValue("@userReg", UserReg);
                sqlcmd.Parameters.AddWithValue("@fechaEntrega", fechaEntrega);

              

                result = sqlcmd.ExecuteNonQuery();
               
            }



            catch (SqlException ex)
            {

                result = -1;
                string msj = ex.Message;


            }

            return result;

        }

        public DataTable GetOrdenesPorAprobar(string accion , int codUser ) {

            SqlDataAdapter dap = new SqlDataAdapter(SPSPS_LISTAR_ORDENES_POR_APROBAR, cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@accion", accion);
            dap.SelectCommand.Parameters.AddWithValue("@codUser", codUser);

            dap.Fill(dt);
            return dt;
        

        }

        public DataTable GetOrdenesPorAprobar(string accion, int codUser, DateTime fechaIni , DateTime fechaFin)
        { /**/


            SqlDataAdapter dap = new SqlDataAdapter(SPSPS_LISTAR_ORDENES_POR_APROBAR, cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@accion", accion);
            dap.SelectCommand.Parameters.AddWithValue("@codUser", codUser);
            dap.SelectCommand.Parameters.AddWithValue("@fechaIni", fechaIni);
            dap.SelectCommand.Parameters.AddWithValue("@fechaFin", fechaFin);

            dap.Fill(dt);
            return dt;

        }

        public DataTable GetOrdenCabecera(string accion , int codOrden) { /**/

            SqlDataAdapter dap = new SqlDataAdapter(SPSPS_LISTAR_ORDENES_POR_APROBAR, cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@accion", accion);
            dap.SelectCommand.Parameters.AddWithValue("@CodOC", codOrden);
           

            dap.Fill(dt);
            return dt;
        
        }

        public DataTable GetOrdenDetalle(string accion ,int codOrden) { /**/

            SqlDataAdapter dap = new SqlDataAdapter(SPSPS_LISTAR_ORDENES_POR_APROBAR, cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@accion", accion);
            dap.SelectCommand.Parameters.AddWithValue("@CodOC", codOrden);


            dap.Fill(dt);
            return dt;
        
        }

        public bool VistoBuenoOrden(int codOC, int vistoB ,string motivoVB, int codUserResp) { /**/

            bool result = false  ;
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = cn;
            try
            {
                sqlcmd.CommandText = spSPU_ORDEN_COMPRA_APROBACION_RESPONSABLE;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
             
                sqlcmd.Parameters.AddWithValue("@codOC", codOC);
                sqlcmd.Parameters.AddWithValue("@vbResponsable", vistoB);
                sqlcmd.Parameters.AddWithValue("@motivoResp", motivoVB);
                sqlcmd.Parameters.AddWithValue("@CoduserResp", codUserResp);

               




                if (sqlcmd.ExecuteNonQuery()==1) { /**/

                    result = true;
                }

            }



            catch (SqlException ex)
            {

                result = false;
                string msj = ex.Message;


            }

            return result;
        
        
        }


        public DataTable GetOrdenesDeCompraRecepcion() { /**/


            SqlDataAdapter dap = new SqlDataAdapter(spSPS_RECEPCION_OC_COMPRA, cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@accion", "1");
            dap.Fill(dt);
            return dt;

        
        }

        public DataTable GetOrdenesDeCompraRecepcion(string accion , int codLocal , int codProy)
        { /**/


            SqlDataAdapter dap = new SqlDataAdapter(spSPS_RECEPCION_OC_COMPRA, cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@accion", accion);
            dap.SelectCommand.Parameters.AddWithValue("@codProyecto", codProy);
            dap.SelectCommand.Parameters.AddWithValue("@codLocal", codLocal);
            dap.Fill(dt);
            return dt;


        }

        public DataTable GetCabecerDetalleOCRecepcion(string accion , int  codOc) { /**/

            SqlDataAdapter dap = new SqlDataAdapter(spSPS_RECEPCION_OC_COMPRA, cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@accion", accion);
            dap.SelectCommand.Parameters.AddWithValue("@codOC", codOc);         
            dap.Fill(dt);
            return dt;

        
        }

        public DataTable ActaConformidad(int codOc) {


            SqlDataAdapter dap = new SqlDataAdapter(spSPS_ACTA_CONFORMIDAD, cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;

            dap.SelectCommand.Parameters.AddWithValue("@CodigoOC", codOc);
            dap.Fill(dt);
            return dt;
             
        }
    }
}

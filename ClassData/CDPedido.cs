using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace ClassData
{
     public class CDPedido
    {

        string Conn;
        SqlConnection cn;
        string spSPS_LISTAR_MONEDAS = "SPS_LISTAR_MONEDAS";
       // string spSPS_LISTAR_LOCALES = "SPS_LISTAR_LOCALES";
        string spSPI_PEDIDO = "SPI_PEDIDO";
        string spSPI_PEDIDO_DETALLE = "SPI_PEDIDO_DETALLE";
        string spSPI_PEDIDO_CODIGOS_PRESUPUESTAL = "SPI_PEDIDO_CODIGOS_PRESUPUESTAL";
        string spSPS_LISTAR_PEDIDO = "SPS_LISTAR_PEDIDO";
        string spSPS_LISTAR_PEDIDOS_POR_APROBACION = "SPS_LISTAR_PEDIDOS_POR_APROBACION";
        string spSPU_PEDIDO_APROBACION_RESPONSABLE = "SPU_PEDIDO_APROBACION_RESPONSABLE";
        const string spSPS_PEDIDOS_EN_PROCESO = "SPS_PEDIDOS_EN_PROCESO";
        const string spSPS_PEDIDO_POR_CODIGO = "SPS_PEDIDO_POR_CODIGO";
        public CDPedido() {

            Conn = System.Configuration.ConfigurationManager.AppSettings["eConnectionString"];
            cn = new SqlConnection(Conn);
        
        }




        public DataTable GetPedidoCabecera(string accion , int codPedido) {
           
            SqlDataAdapter dap = new SqlDataAdapter(spSPS_LISTAR_PEDIDO, cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@accion", accion);
            dap.SelectCommand.Parameters.AddWithValue("@codPedido", codPedido);

            dap.Fill(dt);
            return dt;
         
        
        
        }

        public DataTable GetMonedas() {

            SqlDataAdapter dap = new SqlDataAdapter(spSPS_LISTAR_MONEDAS, cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.Fill(dt);
            return dt;
        
        }

        public int InsertarPedidoCabecera(int  codTipoPedido , int  codLocal , int codLocalEntrega ,int codProyecto  , int codMoneda,string descripcion ,int estatus , int estado ,int userReg, int Donacion ) {




            int  result = 0;
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = cn;
            try
            {
                sqlcmd.CommandText = spSPI_PEDIDO;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                sqlcmd.Parameters.AddWithValue("@codigoTipoPedido",  codTipoPedido);

                sqlcmd.Parameters.AddWithValue("@codigoLocal", codLocal);
                sqlcmd.Parameters.AddWithValue("@codigoLocalEntrega", codLocalEntrega);
               
                sqlcmd.Parameters.AddWithValue("@codigoProyecto", codProyecto);
                sqlcmd.Parameters.AddWithValue("@codigoMoneda", codMoneda);
                sqlcmd.Parameters.AddWithValue("@descripcion", descripcion);
                sqlcmd.Parameters.AddWithValue("@estatus", estatus);
                sqlcmd.Parameters.AddWithValue("@estado", estado);
                sqlcmd.Parameters.AddWithValue("@userReg", userReg);
                sqlcmd.Parameters.AddWithValue("@donacion", Donacion);
                SqlParameter idPedido = sqlcmd.Parameters.Add("@codigoPedido", SqlDbType.BigInt);
                idPedido.Direction = ParameterDirection.Output;

                if (sqlcmd.ExecuteNonQuery() == 1)
                {
                    string var = sqlcmd.Parameters["@codigoPedido"].Value.ToString(); ;
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

        
        public  int  InsertarDetallesPedido (int codPedido , int codProducto ,int cantidad  , decimal precio ,string ruta1 , string ruta2, int estatus , int estado ,int userReg){
        
         
             int  result = 0;
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = cn;
            try
            {
                sqlcmd.CommandText = spSPI_PEDIDO_DETALLE;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                sqlcmd.Parameters.AddWithValue("@codigoPedido",  codPedido);

                sqlcmd.Parameters.AddWithValue("@codigoProducto", codProducto);
                sqlcmd.Parameters.AddWithValue("@cantidad", cantidad);
                sqlcmd.Parameters.AddWithValue("@precio", precio);
                sqlcmd.Parameters.AddWithValue("@rutaimg1", ruta1);
                sqlcmd.Parameters.AddWithValue("@rutaimg2", ruta2);
                sqlcmd.Parameters.AddWithValue("@estatus", estatus);
             
                sqlcmd.Parameters.AddWithValue("@estado", estado);
                sqlcmd.Parameters.AddWithValue("@userReg", userReg);
              

                 result  = sqlcmd.ExecuteNonQuery();
                  
            }



            catch (SqlException ex)
            {

                result = -1;
                string msj = ex.Message;


            }

            return result;
        
        }

        public bool InsertarCodigosPresupuestal(int codPedido, string  codPrespuestal ,int userReg , decimal porcent ) {


            bool result = false;

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = cn;
            try
            {
                sqlcmd.CommandText = spSPI_PEDIDO_CODIGOS_PRESUPUESTAL;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                sqlcmd.Parameters.AddWithValue("@codPedido", codPedido);
                sqlcmd.Parameters.AddWithValue("@codPresupuestal", codPrespuestal);
                sqlcmd.Parameters.AddWithValue("@userReg", userReg);
                sqlcmd.Parameters.AddWithValue("@porcentaje", porcent);

                if (sqlcmd.ExecuteNonQuery() == 1) { 
                    
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

        public bool ActualizarVBResponsable( int codPedido , int vbResponsable , string Motivo , int userVBresponsable,int SigEstado) { /**/

            bool result = false;

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = cn;
            try
            {
                sqlcmd.CommandText = spSPU_PEDIDO_APROBACION_RESPONSABLE;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                sqlcmd.Parameters.AddWithValue("@codPedido", codPedido);
                sqlcmd.Parameters.AddWithValue("@VBresponsable", vbResponsable);
                sqlcmd.Parameters.AddWithValue("@motivoResponsable", Motivo);
                sqlcmd.Parameters.AddWithValue("@userResponsable", userVBresponsable);
                sqlcmd.Parameters.AddWithValue("@NextEstatus", SigEstado);
                int var = sqlcmd.ExecuteNonQuery();

                if (var  >0)
                {

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

        public DataTable GetPedido(string accion) {


            SqlDataAdapter dap = new SqlDataAdapter(spSPS_LISTAR_PEDIDO, cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@accion", accion);
            dap.Fill(dt);
            return dt;

        }

        public DataTable GetPedidosAprobacion(string accion , string CodUser ) {
            SqlDataAdapter dap = new SqlDataAdapter(spSPS_LISTAR_PEDIDOS_POR_APROBACION, cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@accion", accion);
            dap.SelectCommand.Parameters.AddWithValue("@codUser", Convert.ToInt32(CodUser));
            dap.Fill(dt);
            return dt;
        
        }

        public DataTable GetPedidosAprobacion(string accion, int  codPedido)
        {
            SqlDataAdapter dap = new SqlDataAdapter(spSPS_LISTAR_PEDIDOS_POR_APROBACION, cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@accion", accion);
            dap.SelectCommand.Parameters.AddWithValue("@codPedido",   codPedido);
            dap.Fill(dt);
            return dt;

        }

        public DataTable GetPedidosAprobacionPorFechas(string accion ,int codUser , DateTime fechaIni , DateTime fechaFin )
        {
            SqlDataAdapter dap = new SqlDataAdapter(spSPS_LISTAR_PEDIDOS_POR_APROBACION, cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@accion", accion);
            dap.SelectCommand.Parameters.AddWithValue("@codUser", codUser);
            dap.SelectCommand.Parameters.AddWithValue("@fechaIni", fechaIni);
            dap.SelectCommand.Parameters.AddWithValue("@fechaFin", fechaFin);
            dap.Fill(dt);
            return dt;

        }


        public DataTable GetPedidosEnProceso(string accion , int codUser )
        {
            SqlDataAdapter dap = new SqlDataAdapter(spSPS_PEDIDOS_EN_PROCESO, cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@accion", accion);
            dap.SelectCommand.Parameters.AddWithValue("@codUsuario", codUser);
            dap.Fill(dt);
           
            return dt;



        }

        public DataTable GetPedidoCabeceraEdit(string accion , int codPedido) 
        {

            SqlDataAdapter dap = new SqlDataAdapter(spSPS_PEDIDO_POR_CODIGO, cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@accion", accion);
            dap.SelectCommand.Parameters.AddWithValue("@CodPedido", codPedido);
            dap.Fill(dt);

            return dt;
            
        }

        public DataTable GetPedidoDetalleEdit(string accion, int codPedido)
        {

            SqlDataAdapter dap = new SqlDataAdapter(spSPS_PEDIDO_POR_CODIGO, cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@accion", accion);
            dap.SelectCommand.Parameters.AddWithValue("@CodPedido", codPedido);
            dap.Fill(dt);

            return dt;
             
            
        }

        public DataTable GetPedidoCodigosEdit(string accion , int codPedido)
        {

            SqlDataAdapter dap = new SqlDataAdapter(spSPS_PEDIDO_POR_CODIGO, cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@accion", accion);
            dap.SelectCommand.Parameters.AddWithValue("@CodPedido", codPedido);
            dap.Fill(dt);

            return dt;
            
        }




    }
}

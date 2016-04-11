using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ClassData
{
     public class CDCombo
    {
         string spSPS_LISTAR_COMBO_DETALLE = "SPS_LISTAR_COMBO_DETALLE";
         string spLISTAR_TIPO_FORMA_PAGO = "LISTAR_TIPO_FORMA_PAGO";
         string spSPS_LISTAR_TIPO_GARANTIA = "SPS_LISTAR_TIPO_GARANTIA";
         const string spSPS_LISTAR_CODIGOS_PRESUPUESTAL = "SPS_LISTAR_CODIGOS_PRESUPUESTAL ";
         const string spSPS_COMBO_ESTADOS = "SPS_COMBO_ESTADOS";
         const string spSPS_TIPO_COMPROBANTE = "SPS_TIPO_COMPROBANTE";
         const string spSPS_COMBOS = "SPS_COMBOS";

        string Conn;
        SqlConnection cn;


        public CDCombo() {

            Conn = System.Configuration.ConfigurationManager.AppSettings["eConnectionString"];
            cn = new SqlConnection(Conn);

        
        }


        public DataTable GetComboDetallle (int codCombo){


            SqlDataAdapter dap = new SqlDataAdapter(spSPS_LISTAR_COMBO_DETALLE, cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@codCombo", codCombo);
            
            dap.Fill(dt);
            return dt;
         
        
        }


        public DataTable GetValorIgv() {

            SqlDataAdapter dap = new SqlDataAdapter("select * from COMBO_DETALLE where CodigoCombo = 1  and CodigoDet =1", cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.Text;
           
            
            dap.Fill(dt);
            return dt;
        
        }

        public DataTable GetFormaPago() {


            SqlDataAdapter dap = new SqlDataAdapter(spLISTAR_TIPO_FORMA_PAGO, cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
           

            dap.Fill(dt);
            return dt;
         

         }

        public DataTable GetCodigoPresopuestal(string accion , int codigoProyecto) {

            SqlDataAdapter dap = new SqlDataAdapter(spSPS_LISTAR_CODIGOS_PRESUPUESTAL, cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@codProyecto", codigoProyecto);
            dap.SelectCommand.Parameters.AddWithValue("@accion", accion);

            dap.Fill(dt);
            return dt;

        
        
         }

        public DataTable GetCodigoTipoGarantia() {


            SqlDataAdapter dap = new SqlDataAdapter(spSPS_LISTAR_TIPO_GARANTIA, cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;


            dap.Fill(dt);
            return dt;
        
        }

        public DataTable GetComboEstados(string accion)
        {


            SqlDataAdapter dap = new SqlDataAdapter(spSPS_COMBO_ESTADOS, cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@accion", accion);

            dap.Fill(dt);
            return dt;


        }

        public DataTable GetComboTipoComprobante() { /**/

            SqlDataAdapter dap = new SqlDataAdapter(spSPS_TIPO_COMPROBANTE, cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;


            dap.Fill(dt);
            return dt;
        
        }

        public DataTable getCombos(string accion) { /**/


            SqlDataAdapter dap = new SqlDataAdapter(spSPS_COMBOS, cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
     
            dap.SelectCommand.Parameters.AddWithValue("@accion", accion);

            dap.Fill(dt);
            return dt;

        }
    }
}

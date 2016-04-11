using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ClassData;

namespace ClassBusiness
{
     public class CBPedido
    {
         CDPedido objCDPedido;


         public CBPedido() {

             objCDPedido = new CDPedido();
         }


         public DataTable GetMonedas() {


             return objCDPedido.GetMonedas();
         
         }

         public int InsertarPedidoCabecera(int codTipoPedido, int codLocal, int codLocalEntrega, int codProyecto, int codMoneda, string descripcion, int estatus, int estado, int userReg, int donacion)
         {

              return objCDPedido.InsertarPedidoCabecera(codTipoPedido, codLocal, codLocalEntrega, codProyecto, codMoneda, descripcion, estatus, estado, userReg,donacion);

                
         }


         public int InsertarDteallePedido(int codPedido, int codProducto, int cantidad, decimal precio, string ruta1, string ruta2, int estatus, int estado, int userReg)
         {
             return objCDPedido.InsertarDetallesPedido(codPedido, codProducto, cantidad, precio, ruta1, ruta2, estatus, estado, userReg);
         
          }

         public bool InsertarCodigosPresupuestal(int codPedido, string codPrespuestal, int userReg, decimal porcent)
         {


             return objCDPedido.InsertarCodigosPresupuestal(codPedido, codPrespuestal, userReg, porcent);
         
         
         }

          public bool ActualizarVBResponsable( int codPedido , int vbResponsable , string Motivo , int userVBresponsable,int SgtEstado) { /**/

              return objCDPedido.ActualizarVBResponsable(codPedido,vbResponsable,Motivo,userVBresponsable,SgtEstado);

          }
         public DataTable GetPedidoCabeceraDetalle(string accion , int codP) {

             return objCDPedido.GetPedidoCabecera(accion, codP);
         
          }

         public DataTable GetPedidos(string accion) {

             return objCDPedido.GetPedido(accion);
         }

         public DataTable GetPedidosAprobacion(string accion, string codUser) {

             return objCDPedido.GetPedidosAprobacion(accion, codUser);
         }
         public DataTable GetPedidosAprobacion(string accion, int codPedido)
         {

             return objCDPedido.GetPedidosAprobacion(accion,codPedido);
         }
         public DataTable GetPedidosAprobacionPorFechas(string accion, int codUser, DateTime fechaIni, DateTime fechaFin) { /**/

             return objCDPedido.GetPedidosAprobacionPorFechas(accion, codUser, fechaIni, fechaFin);    
         }

        public DataTable GetPedidosEnProceso(string accion, int codUser)
        {


            return objCDPedido.GetPedidosEnProceso(accion, codUser);
        }

        public DataTable GetPedidoCabeceraEdit(string accion, int codPedido) 
        {
          return objCDPedido.GetPedidoCabeceraEdit(accion,codPedido);  
            
       }

        public DataTable  GetPedidoDetalleEdit(string accion, int codPedido)
        {/**/

            return objCDPedido.GetPedidoDetalleEdit(accion, codPedido);
        }

        public DataTable GetPedidoCodigosEdit(string accion, int codPedido)
        {


            return objCDPedido.GetPedidoCodigosEdit(accion, codPedido);

        }

    }
}

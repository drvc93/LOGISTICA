using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ClassData;

namespace ClassBusiness
{
    public  class CBOrdenDeCompra
    {

        CDOrdenDeCompra objCDOrdenCompra;


        public CBOrdenDeCompra() {

            objCDOrdenCompra = new CDOrdenDeCompra();
        
        }


        public int InsertarOrdenCabecera(string accion ,int codPedido, int codProveedor  ,int codFormaPago , int estatus , int estado ,  int userReg, int incluyeigv,
             decimal TipoCambio, decimal ExoMe, decimal valorVentaMe, decimal igvME, decimal totalME, decimal ExoSL, decimal valorVentaSL, decimal IgvSL, decimal totalSL, string FechaInicio, string FechaFin, string Responsable, string observac)
        {

            return objCDOrdenCompra.InsertarCompraCabecera(accion, codPedido, codProveedor, codFormaPago, estatus, estado, userReg,incluyeigv,TipoCambio,ExoMe,valorVentaMe,igvME,totalME,ExoSL,valorVentaSL,IgvSL,totalSL,FechaInicio,FechaFin,Responsable ,observac);
        
        }


        public int InsertarOrdenDetalle(string accion, int codigoOC, int codPedido, int CodPedidoDetalle, int estatus, int estado, int UserReg, int codGarantia, DateTime FechaEntrega )
        {


            return objCDOrdenCompra.InsertarCompraDetalle(accion, codigoOC, codPedido, CodPedidoDetalle,estado,estado,UserReg,codGarantia ,FechaEntrega);
        
        }

        public DataTable GetListaOrdenes( string accion ) {

            return objCDOrdenCompra.GetListaOrdenes(accion);        
        }

        public DataTable GetListaOrdenDetalle(string accion, int codOC)
        {

            return objCDOrdenCompra.GetListaOrdenDetalle(accion, codOC);

        }

        public DataTable GetOrdenesPorAprobar(string accion, int codUser)
        {
            return objCDOrdenCompra.GetOrdenesPorAprobar(accion, codUser); /**/
        }

         public DataTable GetOrdenesPorAprobar(string accion, int codUser, DateTime fechaIni , DateTime fechaFin){/**/

             return objCDOrdenCompra.GetOrdenesPorAprobar(accion, codUser, fechaIni, fechaFin);

        }

         public DataTable GetCabceraOrden(string accion  , int codOrden) { /**/

             return objCDOrdenCompra.GetOrdenCabecera(accion, codOrden);
          
         }

         public DataTable GetOrdenDetalle(string accion, int codOrden) { /**/

             return objCDOrdenCompra.GetOrdenDetalle(accion, codOrden);

         }

        public bool VistoBuenoOrden(int codOC, int vistoB ,string motivoVB, int codUserResp)
         { /**/

             return objCDOrdenCompra.VistoBuenoOrden(codOC, vistoB, motivoVB, codUserResp);
        }

        public DataTable GetOrdenesDeCompraRecepcion() { /**/

            return objCDOrdenCompra.GetOrdenesDeCompraRecepcion();
        
        }


        public DataTable GetOrdenesDeCompraRecepcion(string accion , int codLocal , int codProy)
        { /**/

            return objCDOrdenCompra.GetOrdenesDeCompraRecepcion(accion,codLocal,codProy);

        }

        public DataTable GetCabecerDetalleOCRecepcion(string accion, int codOc) { /**/

            return objCDOrdenCompra.GetCabecerDetalleOCRecepcion(accion, codOc);

        }
        
        public DataTable ActaConformidad(int codOc){

            return objCDOrdenCompra.ActaConformidad(codOc);
        }
    }
}

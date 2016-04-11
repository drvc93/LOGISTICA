using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ClassData;

namespace ClassBusiness
{

    
    
    public class CBRecepcion
    {

        CDRecepcion objRecepcion;

        public CBRecepcion() { /**/

            objRecepcion = new CDRecepcion();
        }

        public int InsertarCabeceraRecepcion(int codOC, int userRecepcion, string nroFactura, string nroGuiaRemision, DateTime FechaRemision, string observacion, int RecepcionSistemas, int estatus, int userReg)
        {
            return objRecepcion.InsertarCabeceraRecepcion(codOC, userRecepcion, nroFactura, nroGuiaRemision, FechaRemision, observacion, RecepcionSistemas, estatus, userReg);

        }

        public int InsertarDetalleRecepcion(int codRecepcion, int codigoOCdetalle, int cantRecibida, int estatus, int userReg)
        {
            return objRecepcion.InsertarDetalleRecepcion(codRecepcion, codigoOCdetalle, cantRecibida, estatus, userReg);

        }

        public DataTable OrdenesPorIngresar(string accion)
        {

            return objRecepcion.OrdenesPorIngresar(accion);
        }

        public DataTable OrdenesPorIngresar(string accion, int codRC , int codProd)
        {

            return objRecepcion.OrdenesPorIngresar(accion, codRC, codProd);
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ClassData;

namespace ClassBusiness
{
    public class CBIngreso
    {
        CDIngreso objIngreso;

        public CBIngreso()
        {
            objIngreso = new CDIngreso();
        }
        
        public string InsertarIngreso(int codigoOC, int codProducto, int CodLocal, int CodProyecto, int codProveedor, int codFabricante, string modelo, string lote, int Temperatura, DateTime fechaIngr,
            DateTime fechaVenc, int codTipExistencia, int CodComprobante, string OtroComprobante, string serie, string numero, int codTipoOpe, string otroOper, int CantIngreso,
            int CantEgres, int CodUsuario, int UserReg)
        {
            return objIngreso.InsertarIngreso(codigoOC, codProducto, CodLocal, CodProyecto, codProveedor, codFabricante, modelo, lote, Temperatura, fechaIngr, fechaVenc, codTipExistencia, CodComprobante, OtroComprobante,
                serie, numero, codTipoOpe, otroOper, CantIngreso, CantEgres, CodUsuario, UserReg);
        }
    }
}
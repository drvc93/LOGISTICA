using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ClassData;

namespace ClassBusiness
{
    public class CBCombo 
    {

        CDCombo objCDCombo;

        public CBCombo() {
            objCDCombo = new CDCombo();
        
        }

        public DataTable GetComboDetalle(int cod) {


            return objCDCombo.GetComboDetallle(cod);
        
        }

        public DataTable GetValorIgv() {


            return objCDCombo.GetValorIgv();

        }


        public DataTable GetFormaTipoPago() {


            return objCDCombo.GetFormaPago();
        
        }

        public DataTable GetCodigoPresupuestal(string  accion , int cod) {


            return objCDCombo.GetCodigoPresopuestal( accion,cod);
        
        }

        public DataTable GetTipoGarantia() {

            return objCDCombo.GetCodigoTipoGarantia();

         }

        public DataTable GetComboEstados(string accion) { /**/

            return objCDCombo.GetComboEstados(accion);
        }

        public DataTable GetComboTipoComprobante() { /**/

            return objCDCombo.GetComboTipoComprobante();
        }

        public DataTable getCombos(string accion) { /**/
            return objCDCombo.getCombos(accion);
        
        }
        
         
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ClassData;

namespace ClassBusiness
{
    public class CBPresentacion
    {

        public CDPresentacion objPresentacion;



        public CBPresentacion() {

            objPresentacion = new CDPresentacion();
        
         }


        public DataTable GetPresentacion()
        {


            return objPresentacion.GetPresentacion();
        
          
        
        
        }

    }
}

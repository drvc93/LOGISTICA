using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ClassData;

namespace ClassBusiness
{
    public class CBConcentracion
    {


        CDCocentracion objConcetracion;

        public CBConcentracion() {

            objConcetracion = new CDCocentracion();
        
        }

        public DataTable GetConcentracion() {

           return objConcetracion.GetCocentracion();

        
        }


    }
}

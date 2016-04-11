using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassData;
using System.Data;

namespace ClassBusiness
{
     public class CBUnidad
    {

         CDUnidad objUnidad;

         public CBUnidad() {


             objUnidad = new CDUnidad();
         
         }

         public DataTable GetUnidadMedida() {


              return objUnidad.GetUnidadMedida();
         
         
         }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ClassData;

namespace ClassBusiness
{
     public class CBLocal
    {

         CDLocal objLocal;

         public CBLocal() {

             objLocal = new CDLocal();
         
         }


         public DataTable GetLocales(string  accion , string  param1) {


             return objLocal.GetLocales(accion, param1);

              
         }

         public string InsertarLocal(int codEmpresa, string nombre, string descripcion, string direccion, string distrito, string telefono, int estatus, int userReg) {


             return objLocal.InsertarLocal(codEmpresa, nombre, descripcion, direccion, distrito, telefono, estatus, userReg);
         
         }


         public bool AsginarNiveles(int codLocal, int codNivelAprobacion, int estado, int UserReg) {


             return objLocal.AsignarNieveles(codLocal, codNivelAprobacion, estado, UserReg);
              
         
         }

         public string ActualizarLocal(int codLocal, int codEmpresa, string nombre, string descripcion, string direccion, string distrito, string telefono, int estatus, int userReg) {


             return objLocal.ActualizarLocal(codLocal, codEmpresa, nombre, descripcion, direccion, distrito, telefono, estatus, userReg);
         
         }

         public DataTable GetLocalesPorNombre( string  accion , string parm) {



             return objLocal.GetLocalesPorNombre(accion, parm);
         
         
         
         }

    }
}

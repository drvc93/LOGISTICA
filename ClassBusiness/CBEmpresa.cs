using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ClassData;

namespace ClassBusiness
{
     public class CBEmpresa
    {
         CDEmpresa objCDEmpresa;

         public CBEmpresa() {

             objCDEmpresa = new CDEmpresa();
         }


         public DataTable GetEmpresas() {


             return objCDEmpresa.GetEmpresas();
         
         }


    }
}

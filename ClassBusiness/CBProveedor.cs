using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ClassData;

namespace ClassBusiness
{
     public class CBProveedor
    {

         CDProveedor objProveedor;


         public CBProveedor() {

             objProveedor = new CDProveedor();
         
         }


         public DataTable GetProveedores(string accion , string descrip)
         {

             return objProveedor.GetProveedor(accion,descrip);

         }
    }
}

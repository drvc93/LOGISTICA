using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ClassData;

namespace ClassBusiness
{
     public class CBProyecto
    {
         CDProyecto objCDProyecto;

         public CBProyecto() {



             objCDProyecto = new CDProyecto();
         }

         public DataTable GetAllProyectos(string accion) { /**/

             return objCDProyecto.GetAllProyectos(accion);
         
         }

         public DataTable GetProyectos(string accion ,string parm) {


             return objCDProyecto.GetProyectos(accion, parm);
         
         
         }

         public DataTable GetProyectos( string accion , int codUser) {

             return objCDProyecto.GetProyectos(accion, codUser);
         }

         public DataTable GetProyectosCodigoPresupuesal(int codProy) {

             return objCDProyecto.GetProyectosCodigoPresupuesal(codProy);
         }

         public DataTable GetGrupoProyectos() {


             return objCDProyecto.GetGrupoProyectos();
         
         }

         public string InsertarCodigoPresupuestal(int codProyecto, string codigo, string glosa, int codUserReg) {

             return objCDProyecto.InsertarCodigoPresupuestal(codProyecto, codigo, glosa, codUserReg);
         }

         public string InsertarProyecto(string accion, int codGrupoProyect, string nombre, string descripcion, string fechaIn, string fechaFin, int estado, int userReg) {


             return objCDProyecto.InsertarProyecto(accion, codGrupoProyect, nombre, descripcion, fechaIn, fechaFin, estado, userReg);
         
         }


         public string ActualizarProyecto(int codProyecto, string accion, int codGrupoProyect, string nombre, string descripcion, string fechaIn, string fechaFin, int estado, int userReg)
         {


             return objCDProyecto.ActualizarProyecto(codProyecto, accion, codGrupoProyect, nombre, descripcion, fechaIn, fechaFin, estado, userReg);
           
         
         }
         public void InsertarTableTemp(string cod, int cant, decimal CostoUnit) { /**/

              objCDProyecto.InsertarTableTemp(cod, cant, CostoUnit);
         }

         public  DataTable  GetTempDataCosto ()
         { /**/

             return objCDProyecto.GetTempDataCosto();
         
         }

         public bool InsertarCostosCodigosPresupuesto(int codProyecto, string codPresupuesto, int Cantidad, decimal MontoTotal, decimal montoUnitario)
         { /**/

             return objCDProyecto.InsertarCostosCodigosPresupuesto(codProyecto, codPresupuesto, Cantidad, MontoTotal, montoUnitario);
         }
    }
}

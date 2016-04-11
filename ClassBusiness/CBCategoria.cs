using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassData;
using System.Data;

namespace ClassBusiness
{
    public class CBCategoria
    {


        #region  Atributos 

        CDCategoria objCategoria;

        #endregion

        #region Metodos

        public CBCategoria() { objCategoria = new CDCategoria(); }

        public DataTable GetCategoria() {

            return objCategoria.GetCategoria();

        
        }

        public DataTable GetSubCategoria(int codCat) {


            return objCategoria.GetSubCategoria(codCat);
        
        }

        public DataTable GetSubCategoria() {

           return  objCategoria.GetSubCategoria();
        
        }

        #endregion


    }
}

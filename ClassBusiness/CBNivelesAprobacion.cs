using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassData;
using System.Data;

namespace ClassBusiness
{
    public class CBNivelesAprobacion
    {

        CDNivelesAprobacion objCDNiveles;


        public CBNivelesAprobacion() {
            objCDNiveles = new CDNivelesAprobacion();
                    
        }


        public DataTable GetNivelesAprobacion( int cod) {



            return objCDNiveles.GetNivelesAprobacion(cod);
        
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using ClassBusiness;

namespace WSLogis
{
    /// <summary>
    /// Descripción breve de AutocompletService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
     [System.Web.Script.Services.ScriptService]
    public class AutocompletService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }

        [WebMethod]
        public string[] FillTextBox(string prefixText, int count)
        {

            List<string> listFill = new List<string>();
            CBProveedor objProv = new CBProveedor();
            DataTable dtProvedores = objProv.GetProveedores("1", prefixText);

            if (dtProvedores != null)
            {


                for (int i = 0; i < dtProvedores.Rows.Count; i++)
                {

                    listFill.Add(dtProvedores.Rows[i]["Proveedor"].ToString());
                }
            }

            return listFill.ToArray();
        }
    }
}

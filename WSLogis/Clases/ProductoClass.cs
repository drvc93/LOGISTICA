using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSLogis.Clases
{
    public class ProductoClass
    {

        int var_productoID;
        string var_Descripcion;
        double var_Precio;
        int var_cantidad;

        

        

        public ProductoClass() {   }

        public ProductoClass( int cod , string descrip, double precio , int cantidad) {

            this.var_productoID = cod;
            this.var_Descripcion = descrip;
            this.var_Precio = precio;
            this.var_cantidad = cantidad;


        
        }


        public int ProductoID
        {
            get { return var_productoID; }
            set { var_productoID = value; }
        }


        public string Descripcion
        {
            get { return var_Descripcion; }
            set { var_Descripcion = value; }
        }

        public double Precio
        {
            get { return var_Precio; }
            set { var_Precio = value; }
        }

        public int Cantidad
        {
            get { return var_cantidad; }
            set { var_cantidad = value; }
        }

    }
}
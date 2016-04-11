using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassData;
using System.Data;

namespace ClassBusiness
{

   

    public class CBProducto
    {

        #region  Atributos 
        CDProducto objProducto;
        #endregion


        #region Constructor 
        public CBProducto(){   objProducto = new CDProducto();   }
         
        #endregion

        #region Metodos

        public DataTable GetProductosPorNombre(string nom)
        {
            return objProducto.GetProductosPorNombre(nom);
        }

        public DataTable GetProductos(string accion, string codProd)
        {
            return objProducto.GetProductos(accion,codProd);
        }

        public DataTable GetProductosPorTipo(string accion, int tipo)
        {
            return objProducto.GetProductosPorTipo(accion, tipo);
        }

        public DataTable GetProductosPorDescripcion(string accion,  string descripcion)
        {
            return objProducto.GetProductosPorDescripcion(accion, descripcion);
        }

        public DataTable GetProductosPorCategoria(string accion, int codCategoria, int SubCategoria)
        {
            return objProducto.GetProductoPorCategoria(accion, codCategoria, SubCategoria);
        }

        public string InsertarProducto(int codCategoria, int codSubCategoria, int codTipoPedido, int codPresentacion, int CodConcentracion, int codUnidad,
                                         string nombre, string descripcion, int expira, int stockmin, string rutaimag1, string rutaimg2, int estado, int userReg)
        {
            return objProducto.InsertarProducto(codCategoria, codSubCategoria, codTipoPedido, codPresentacion, CodConcentracion, codUnidad, nombre, descripcion, expira, stockmin, rutaimag1, rutaimg2, estado, userReg);
        }


        public string ActualizarProducto(int codProduct, int codCategoria, int codSubCategoria, int codTipoPedido, int codPresentacion, int CodConcentracion, int codUnidad,
                                         string nombre, string descripcion, int expira, int stockmin, string rutaimag1, string rutaimg2, int estado, int userReg)
        {
           return objProducto.ActualizarProducto(codProduct, codCategoria, codSubCategoria, codTipoPedido, codPresentacion, CodConcentracion, codUnidad, nombre, descripcion, expira, stockmin,
                                               rutaimag1, rutaimg2, estado, userReg);
        }
         
        #endregion

        

    }
}

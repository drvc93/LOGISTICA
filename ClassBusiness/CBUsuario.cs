using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ClassData;

namespace ClassBusiness
{
    public class CBUsuario
    {
        #region Atributos
        CDUsuario objCDUsuario;
        #endregion

        #region Constructor
        public CBUsuario()
        { objCDUsuario = new CDUsuario(); }
        #endregion

        public DataTable GetMenuData(int strUsu)
        { return objCDUsuario.GetMenuData(strUsu); }

        public DataTable GetValidarUsuario(string strUsu, string strCont)
        { return objCDUsuario.GetValidarUsuario(strUsu, strCont); }

        public DataTable GetUsuarios(string accion, string codUser)
        { return objCDUsuario.GetUsuarios(accion, codUser); }

        public DataTable GetUsuariosPorLogin(string accion, string login)
        {
            return objCDUsuario.GetUsuariosPorLogin(accion, login); 
            
         }

        public string InsertarUsuario(string acciion ,  int codLocal , string loginUser , string NomUser, string iniciales , string cargo,string correo, string   pass,  int estado  , int userReg) {

            return objCDUsuario.InsertarUsuario(acciion, codLocal, loginUser, NomUser, iniciales, cargo, correo, pass, estado, userReg);
        }

        public string ActualizarUsuario(int codUser, string acciion, int codLocal, string loginUser, string NomUser, string iniciales, string cargo, string correo, int estado, int userReg) {


            return objCDUsuario.ActualizarUsuario(codUser, acciion, codLocal, loginUser, NomUser, iniciales, cargo, correo, estado, userReg);
        
        
        }

        public DataTable GetUsuarioProyecto(int codUser) {

            return objCDUsuario.GetUsuarioProyecto(codUser);
        }

         public   DataTable GetUsuarioNivelAprobacion(int codUsuario) {

             return objCDUsuario.GetUsuarioNivelAprobacion(codUsuario);
         }

        public DataTable GetUsuarioRol(int codUsuario) {

            return objCDUsuario.GetUsuarioRol(codUsuario);
        }

        public string InsertarUsuarioProyecto(int codUser , int codProyec  , int estado  , int userReg) {


            return objCDUsuario.InsertarUsuarioProyecto(codUser, codProyec, estado, userReg);
         
        }

        public string InsertarUsuarioRol(int codUser, int codRol, int estado, int userReg) {
            return objCDUsuario.InsertarUsuarioRol(codUser, codRol, estado, userReg);
        
        }

        public string InsertarUsuarioNivelAprobacion(int codUser,int codNivel,int estado,int userReg) 
        {
            return objCDUsuario.InsertarUsuarioNivelAprobacion(codUser, codNivel, estado, userReg);

        }
            
    }

}

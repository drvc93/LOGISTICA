using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ClassData
{
    public class CDUsuario
    {
        string Conn;
        SqlConnection cn;
        string spSPI_USUARIO = "SPI_USUARIO";
        string spSPS_LISTAR_PROYECTO_USUARIO = "SPS_LISTAR_PROYECTO_USUARIO";
        string spSPI_PROYECTO_USUARIO = "SPI_PROYECTO_USUARIO";
        string spSPS_USUARIOS_ROL = "SPS_USUARIOS_ROL";
        string spSPI_USUARIOS_ROL = "SPI_USUARIOS_ROL";
        string spSPS_USUARIO_NIVEL_APROBACION = "SPS_USUARIO_NIVEL_APROBACION";
        string spSPI_USUARIO_NIVEL_APROBACION = "SPI_USUARIO_NIVEL_APROBACION";

        public CDUsuario()
        {
            Conn = System.Configuration.ConfigurationManager.AppSettings["eConnectionString"];
            cn = new SqlConnection(Conn);
        }

        #region atributos
        // PARA UBICAR EL CODIGO USUARIO Y RESETEAR PASSWORD
        private const string spSPS_VALIDAR_USUARIO = "SPS_VALIDAR_USUARIO";
        private const string spSPS_LISTAR_MENU_OPCIONES_USUARIO = "SPS_LISTAR_MENU_OPCIONES_USUARIO";
        private const string spSPS_LISTAR_USUARIOS = "SPS_LISTAR_USUARIOS";

        #endregion

        #region metodos
        public DataTable GetMenuData(int CodigoUsuario)
        {
            SqlDataAdapter dap = new SqlDataAdapter(spSPS_LISTAR_MENU_OPCIONES_USUARIO, cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@CodigoUsuario", CodigoUsuario);
            dap.Fill(dt);
            return dt;
        }

        public DataTable GetValidarUsuario(string strUsu, string strCont)
        {
            SqlDataAdapter dap = new SqlDataAdapter(spSPS_VALIDAR_USUARIO, cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@LoginUsuario", strUsu);
            dap.SelectCommand.Parameters.AddWithValue("@ContrasenaUsuario", strCont);
            dap.Fill(dt);
            return dt;
        }

        public DataTable GetUsuarios(string accion, string codUser)
        {
            SqlDataAdapter dap = new SqlDataAdapter(spSPS_LISTAR_USUARIOS, cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@accion", accion);
            dap.SelectCommand.Parameters.AddWithValue("@codUsuario", Convert.ToInt32(codUser));
            dap.Fill(dt);
            return dt;
        }

        public DataTable GetUsuariosPorLogin(string accion, string login) 
        {
            SqlDataAdapter dap = new SqlDataAdapter(spSPS_LISTAR_USUARIOS, cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@accion", accion);
            dap.SelectCommand.Parameters.AddWithValue("@loginUser", login);
            dap.Fill(dt);
            return dt;
            
        }

        public string InsertarUsuario ( string acciion ,  int codLocal , string loginUser , string NomUser, string iniciales , string cargo,string correo, string   pass,  int estado  , int userReg) {



            string result = "";

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = cn;

            try
            {

                sqlcmd.CommandText = spSPI_USUARIO;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                // parameter 
                sqlcmd.Parameters.AddWithValue("@accion", acciion);
                sqlcmd.Parameters.AddWithValue("@codigoLocal", codLocal);
                sqlcmd.Parameters.AddWithValue("@loginuser", loginUser);
                sqlcmd.Parameters.AddWithValue("@userName", NomUser);
                sqlcmd.Parameters.AddWithValue("@iniciales", iniciales);
                sqlcmd.Parameters.AddWithValue("@cargo", cargo);
                sqlcmd.Parameters.AddWithValue("@correo", correo);
                sqlcmd.Parameters.AddWithValue("@password", pass);
                sqlcmd.Parameters.AddWithValue("@estado", estado);
                sqlcmd.Parameters.AddWithValue("@userReg", userReg);
                if (sqlcmd.ExecuteNonQuery() == 1)
                {
                    result = "Se registro correctamente";

                }

            }


            catch (Exception ex)
            {

                result = ex.Message;
            }


            return result;


        
        }

        public string ActualizarUsuario(int codUser , string acciion, int codLocal, string loginUser, string NomUser, string iniciales, string cargo, string correo, int estado, int userReg) {


            string result = "";

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = cn;

            try
            {

                sqlcmd.CommandText = spSPI_USUARIO;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                // parameter 
                sqlcmd.Parameters.AddWithValue("@codigoUsuario", codUser);
                sqlcmd.Parameters.AddWithValue("@accion", acciion);
                sqlcmd.Parameters.AddWithValue("@codigoLocal", codLocal);
                sqlcmd.Parameters.AddWithValue("@loginuser", loginUser);
                sqlcmd.Parameters.AddWithValue("@userName", NomUser);
                sqlcmd.Parameters.AddWithValue("@iniciales", iniciales);
                sqlcmd.Parameters.AddWithValue("@cargo", cargo);
                sqlcmd.Parameters.AddWithValue("@correo", correo);
                sqlcmd.Parameters.AddWithValue("@estado", estado);
                sqlcmd.Parameters.AddWithValue("@userEdit", userReg);
                if (sqlcmd.ExecuteNonQuery() == 1)
                {
                    result = "Se actualizo correctamente";

                }

            }


            catch (Exception ex)
            {

                result = ex.Message;
            }


            return result;

        
        }

        public DataTable GetUsuarioProyecto(int codUser ) {

            SqlDataAdapter dap = new SqlDataAdapter(spSPS_LISTAR_PROYECTO_USUARIO, cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@codUsuario", codUser);
            dap.Fill(dt);
            return dt;
        
          

        }


        public DataTable GetUsuarioNivelAprobacion(int codUsuario) {

            SqlDataAdapter dap = new SqlDataAdapter(spSPS_USUARIO_NIVEL_APROBACION, cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@codUsuario", codUsuario);
            dap.Fill(dt);
            return dt;

        }
        public DataTable GetUsuarioRol(int codUser)
        {

            SqlDataAdapter dap = new SqlDataAdapter(spSPS_USUARIOS_ROL, cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@codUsuario", codUser);
            dap.Fill(dt);
            return dt;



        }

        public string InsertarUsuarioProyecto(int codUser  , int codProyecto , int estado, int userReg) {


            string result = "";

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = cn;

            try
            {

                sqlcmd.CommandText = spSPI_PROYECTO_USUARIO;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                // parameter 
                sqlcmd.Parameters.AddWithValue("@codUsuario", codUser);
                sqlcmd.Parameters.AddWithValue("@codProyecto", codProyecto);
                sqlcmd.Parameters.AddWithValue("@estado", estado);
                sqlcmd.Parameters.AddWithValue("@userReg", userReg);
              
                if (sqlcmd.ExecuteNonQuery() == 1)
                {
                    result = "Se registro correctamente";

                }

            }


            catch (Exception ex)
            {

                result = ex.Message;
            }


            return result;

        
        }

        public string InsertarUsuarioRol(int codUser,int codRol,int estado,int userReg) {


            string result = "";

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = cn;

            try
            {

                sqlcmd.CommandText = spSPI_USUARIOS_ROL;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                // parameter 
                sqlcmd.Parameters.AddWithValue("@codUsuario", codUser);
                sqlcmd.Parameters.AddWithValue("@codRol", codRol);
                sqlcmd.Parameters.AddWithValue("@estado", estado);
                sqlcmd.Parameters.AddWithValue("@userReg", userReg);

                if (sqlcmd.ExecuteNonQuery() == 1)
                {
                    result = "Se registro correctamente";

                }

            }


            catch (Exception ex)
            {

                result = ex.Message;
            }


            return result;


        
        }


        public string InsertarUsuarioNivelAprobacion(int codUser,int codNivel,int estado,int userReg) {


            string result = "";

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = cn;

            try
            {

                sqlcmd.CommandText = spSPI_USUARIO_NIVEL_APROBACION;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                // parameter 
                sqlcmd.Parameters.AddWithValue("@codigoUsuario", codUser);
                sqlcmd.Parameters.AddWithValue("@codigoNivelAprobacion", codNivel);
                sqlcmd.Parameters.AddWithValue("@estado", estado);
                sqlcmd.Parameters.AddWithValue("@UserReg", userReg);

                if (sqlcmd.ExecuteNonQuery() == 1)
                {
                    result = "Se registro correctamente";

                }

            }


            catch (Exception ex)
            {

                result = ex.Message;
            }


            return result;


        
        }

        #endregion


    }
}

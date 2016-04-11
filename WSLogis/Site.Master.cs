using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using System.Configuration;
using System.Data;
using ClassData;
using ClassBusiness;

namespace WSLogis
{
    public partial class SiteMaster : MasterPage
    {
        CBUsuario objCBUsuario = new CBUsuario();

        private const string AntiXsrfTokenKey = "__AntiXsrfToken";
        private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
        private string _antiXsrfTokenValue;

        protected void Page_Init(object sender, EventArgs e)
        {
            // El código siguiente ayuda a proteger frente a ataques XSRF
            var requestCookie = Request.Cookies[AntiXsrfTokenKey];
            Guid requestCookieGuidValue;
            if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
            {
                // Utilizar el token Anti-XSRF de la cookie
                _antiXsrfTokenValue = requestCookie.Value;
                Page.ViewStateUserKey = _antiXsrfTokenValue;
            }
            else
            {
                // Generar un nuevo token Anti-XSRF y guardarlo en la cookie
                _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
                Page.ViewStateUserKey = _antiXsrfTokenValue;

                var responseCookie = new HttpCookie(AntiXsrfTokenKey)
                {
                    HttpOnly = true,
                    Value = _antiXsrfTokenValue
                };
                if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
                {
                    responseCookie.Secure = true;
                }
                Response.Cookies.Set(responseCookie);
            }

            Page.PreLoad += master_Page_PreLoad;
        }

        protected void master_Page_PreLoad(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Establecer token Anti-XSRF
                ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
                ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
            }
            else
            {
                // Validar el token Anti-XSRF
                if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
                    || (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
                {
                    throw new InvalidOperationException("Error de validación del token Anti-XSRF.");
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblUser.Text = Session["LoginUsuario"].ToString();

                DataTable menuData = null;
                try
                {
                    menuData = new DataTable();
                    menuData = objCBUsuario.GetMenuData(int.Parse(Session["CodigoUsuario"].ToString()));
                    AddTopMenuItems(menuData);

                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);

                }
                finally
                {
                    menuData = null;

                }
            }
        }

        protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            Context.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        }

        private void AddTopMenuItems(DataTable menuData)
        {
            DataView view = null;
            try
            {
                view = new DataView(menuData);
                view.RowFilter = "ParentID IS NULL";
                foreach (DataRowView row in view)
                {
                    //Adding the menu item
                    MenuItem newMenuItem = new MenuItem(row["Text"].ToString(), row["MenuID"].ToString());
                    menuBar.Items.Add(newMenuItem);
                    AddChildMenuItems(menuData, newMenuItem);
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            finally
            {
                view = null;
            }
        }

        private void AddChildMenuItems(DataTable menuData, MenuItem parentMenuItem)
        {
            DataView view = null;
            try
            {
                view = new DataView(menuData);
                view.RowFilter = "ParentID=" + parentMenuItem.Value;
                foreach (DataRowView row in view)
                {
                    MenuItem newMenuItem = new MenuItem(row["Text"].ToString(), row["MenuID"].ToString());
                    newMenuItem.NavigateUrl = row["NavigateUrl"].ToString();
                    parentMenuItem.ChildItems.Add(newMenuItem);

                    AddChildMenuItems(menuData, newMenuItem);
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            finally
            {
                view = null;
            }
        }

        protected void lkSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/WFLogin.aspx", false);
        }

        protected void menuBar_MenuItemClick(object sender, MenuEventArgs e)
        {
            if(Session["dtProductos"]!=null)
            {/**/

                Session["dtProductos"] = null;
            
            }
            else { /**/
            
            }
        }
    }

}
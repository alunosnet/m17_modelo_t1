using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace M17_Modelo_T1
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //cookies
            HttpCookie cookie = Request.Cookies["avisocookies"] as HttpCookie;
            if (cookie != null)
            {
                if (cookie.Value == "mostrado")
                    div_cookies.Visible = false;
                else
                {
                    cookie = new HttpCookie("avisocookies", "mostrado");
                    cookie.Expires = DateTime.Now.AddYears(1);
                    Response.Cookies.Add(cookie);
                }
            }
            else
            {
                cookie = new HttpCookie("avisocookies", "mostrado");
                cookie.Expires = DateTime.Now.AddYears(1);
                Response.Cookies.Add(cookie);
            }
        }
    }
}
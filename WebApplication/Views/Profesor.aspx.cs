using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication.Views
{
    public partial class ProfeEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Uri url = new Uri(HttpContext.Current.Request.Url.AbsoluteUri);
            string param1 = HttpUtility.ParseQueryString(url.Query).Get("id");
            Response.Write(param1);
            
        }
    }
}
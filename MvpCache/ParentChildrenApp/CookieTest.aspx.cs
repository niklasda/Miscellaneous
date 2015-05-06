using System;
using System.Web.UI;

namespace nida.ui
{
    public partial class test : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Form["__JavascriptTest1_State"] == "True")
            {
                Response.Redirect("Default.aspx");
            }
        }
    }
}
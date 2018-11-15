using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class a : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
      
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        //var txt = TextBox1.Text;
        
        Session["str"] = TextBox1.Text;
        Response.Redirect("~/b.aspx");
    }
}
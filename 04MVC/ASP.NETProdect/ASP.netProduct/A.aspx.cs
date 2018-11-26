using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class A : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        var s1= TextBox1.Text;
        var s2 = TextBox2.Text;
        Response.Redirect("~/ b.aspx?s="+s1+","+s2);
    }
}
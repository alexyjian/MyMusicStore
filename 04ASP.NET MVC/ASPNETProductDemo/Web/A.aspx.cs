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
        var str1 = TextBox1.Text;
        var str2 = TextBox2.Text;
        Response.Redirect("~/b.aspx?s1="+str1+"&s2="+str2);
    }
}
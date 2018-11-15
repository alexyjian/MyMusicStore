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
        var str = textBox1.Text;
        Response.Redirect("b.aspx?s=" + str);
    }
}
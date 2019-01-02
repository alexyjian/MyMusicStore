using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        var str = TextBox1.Text;
        var str1 = TextBox2.Text;
        Response.Redirect("Contact.aspx?str=" + str + "&str1=" + str1);
    }
}
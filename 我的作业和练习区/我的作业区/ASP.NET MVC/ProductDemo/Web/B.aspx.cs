using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class B : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var st = Request.QueryString["s"].ToString();
        Label1.Text = st;
    }
}
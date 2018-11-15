using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class b : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["a"] != null)
        {
            var c = Session["a"] as List < Category>;
            var cstr = "";

            foreach (var item in c)
                cstr += item.SortCode + "." + item.Name + "\r\n";
            Label1.Text = cstr;
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("~/b.aspx");
    }
}
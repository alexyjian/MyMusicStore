using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class D : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["C"] != null)
        {
            var c = Session["C"] as List<Category>;
            var cstr = "";

            foreach (var item in c)
                cstr += item.SortCode + "." + item.Name + "\r\n";

            Label1.Text = cstr;
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        //手工方式
        //Session.Remove("C");
        //立即过期
        Session.Abandon();
        Response.Redirect("~/D.aspx");
    }
}
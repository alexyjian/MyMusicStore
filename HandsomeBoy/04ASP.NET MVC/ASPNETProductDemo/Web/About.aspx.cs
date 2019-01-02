using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class About : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["C"] != null)
        {
            var c = Session["C"] as Category;
            Label1.Text = c.SortCode + '.' + c.Name;
        }

        if (Session["E"] != null)
        {
            var c = Session["E"] as List<Category>;
            var cstr = "";
            foreach (var item in c)
                cstr += item.SortCode + '.' + item.Name + "\r\n";
            Label2.Text = cstr;
        }     


    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        //Session.Remove("E");
        Session.Abandon();
        Response.Redirect("~/About.aspx");
    }
}
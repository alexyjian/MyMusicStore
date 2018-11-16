using Entities;
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
        //if (Session["A"] != null)
        //{
        //    var c = Session["A"] as Student;
        //    Label1.Text = c.StudentCode + "." + c.Name;
        //}
        if (Session["A"] != null)
        {
            var c = Session["A"] as List<Student>;
            var cstr = "";

            foreach (var item in c)
                cstr += item.StudentCode + "." + item.Name + "\r\n";

            Label1.Text = cstr;
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        //手工方式
        //Session.Remove("C");
        //立即过期
        Session.Abandon();
        Response.Redirect("～/B.aspx");
    }
}
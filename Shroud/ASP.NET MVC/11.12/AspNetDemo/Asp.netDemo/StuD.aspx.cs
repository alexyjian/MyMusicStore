using SDataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class StuD : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {var id = Request.QueryString["Id"].ToString();
        if (id == null) Response.Redirect("test.aspx");
        using ( var content=new StudentContent())
        {
            
            var s = content.Students.Find(Guid.Parse(id));
            Label1.Text = s.Name;
            Label2.Text = s.StudentID;
            Label3.Text = s.Age.ToString();
            Label4.Text = s.Sex ? "男" : "女";
            Label5.Text = s.DepartMent.Name;

        }
    }
}
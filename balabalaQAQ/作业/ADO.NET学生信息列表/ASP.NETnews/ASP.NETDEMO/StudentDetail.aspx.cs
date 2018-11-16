using DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class StudentDetail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != null)
        {
            var id = Guid.Parse(Request.QueryString["id"].ToString());
            var student = new StuDBContext().Students.Find(id);
            StuID.Text = student.StudentCode.ToString();
            StuName.Text = student.Name;
            Stuphone.Text = student.Phone;
        }
        else
        {
            Response.Redirect("~/Productlist.aspx");
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Productlist.aspx");
    }
}
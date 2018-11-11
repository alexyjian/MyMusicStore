using DataContext;
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
        if (!IsPostBack)
        {
            using (var context = new StuDBContext())
            {
                var dps = context.Departments.OrderBy(x => x.SortCode).ToList();
                DropDownList1.DataSource = dps;
                DropDownList1.DataTextField = "Name";
                DropDownList1.DataValueField = "ID";
                DropDownList1.DataBind();

                GridView1.DataSource = context.Students.Select(n => new { StuNo = n.StuNumber, Name = n.Name, Department = n.Department.Name, Sex = n.Sex ? "男" : "女" }).OrderBy(x => x.StuNo).ToList();
                GridView1.DataBind();
            }
        }
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        using (var context = new StuDBContext())
        {
            var id = Guid.Parse(DropDownList1.SelectedValue);
            GridView1.DataSource = context.Students.Where(x=>x.Department.ID == id).Select(n => new { StuNo = n.StuNumber, Name = n.Name, Department = n.Department.Name, Sex = n.Sex ? "男" : "女" }).OrderBy(x => x.StuNo).ToList();
            GridView1.DataBind();
        }
    }
}
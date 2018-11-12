using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) _GetData();
    }
    void _GetData()
    {
        using (var context = new SDataContext.StudentContent())
        {
            var list = context.Students.ToList();
            GridView1.DataSource = list;
            GridView1.DataBind();
        }
    }
    void _DeleteData(Guid id)
    {
        using (var context = new SDataContext.StudentContent())
        {
            var stu = context.Students.SingleOrDefault(x => x.ID == id);
            context.Students.Remove(stu);
            context.SaveChanges();
        }
    }
    void _UpdateData(Guid id, string name, int age, bool sex)
    {
        using (var context = new SDataContext.StudentContent())
        {
            var stu = context.Students.SingleOrDefault(x => x.ID == id);
            stu.Name = name;
            stu.Age = age;
            stu.Sex = sex;
            context.SaveChanges();
        }
    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        _DeleteData((Guid)GridView1.DataKeys[e.RowIndex].Value);
        _GetData();


    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        _GetData();
    }

    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        _GetData();
    }

    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        _GetData();
    }

    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        var id = (Guid)GridView1.DataKeys[e.RowIndex].Value;
        var n = e.NewValues["Name"].ToString().Trim();
        var a = Convert.ToInt16(e.NewValues["Age"]);
        var s = Convert.ToBoolean(e.NewValues["Sex"]);
        _UpdateData(id, n, a, s);
        GridView1.EditIndex = -1;
        _GetData();
    }
}
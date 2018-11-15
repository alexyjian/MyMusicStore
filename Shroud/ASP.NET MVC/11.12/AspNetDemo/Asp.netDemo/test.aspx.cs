using SDataContext;
using SEntities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
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
    void _UpdateData(Guid id, string name, int age, bool sex, Guid did)
    {
        using (var context = new SDataContext.StudentContent())
        {
            var stu = context.Students.SingleOrDefault(x => x.ID == id);
            stu.Name = name;
            stu.Age = age;
            stu.Sex = sex;
            var d = context.DepartMents.Find(did);
            stu.DepartMent = d;
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
        GridView1.EditIndex = -1;
        _GetData();
    }

    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        _GetData();
        var Drl = (DropDownList)GridView1.Rows[e.NewEditIndex].FindControl("DropDownList1");

        var id = (Guid)GridView1.DataKeys[e.NewEditIndex].Value;
        var sdep = new StudentContent().Students.Find(id);
        if (sdep.DepartMent != null) Drl.SelectedValue = sdep.DepartMent.ID.ToString();
    }

    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        _GetData();
    }

    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        var id = (Guid)GridView1.DataKeys[e.RowIndex].Value;
        var n = (GridView1.Rows[e.RowIndex].FindControl("TextBox1") as TextBox).Text.Trim();
        var a = Convert.ToInt16(e.NewValues["Age"]);
        var s = Convert.ToBoolean(e.NewValues["Sex"]);
        var Drl = (DropDownList)GridView1.Rows[e.RowIndex].FindControl("DropDownList1");
        var d = Guid.Parse(Drl.SelectedValue);
        _UpdateData(id, n, a, s, d);
        GridView1.EditIndex = -1;
        _GetData();

    }


    protected List<DepartMent> GetDepartMent()
    {
        using (var context = new SDataContext.StudentContent())
        {
            var list = context.DepartMents.ToList();
            return list;
        }
    }

    protected string GetName(object obj)
    {
        if (obj != null) return ((DepartMent)obj).Name;
        else return null;
    }
}
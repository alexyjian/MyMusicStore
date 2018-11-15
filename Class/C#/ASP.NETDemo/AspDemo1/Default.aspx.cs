using DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;

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

                GridView1.DataSource = context.Students.Select(n => new { ID = n.ID, StuNo = n.StuNumber, Name = n.Name, Department = n.Department.Name, Sex = n.Sex ? "男" : "女" }).OrderBy(x => x.StuNo).ToList();
                GridView1.DataBind();
            }
        }
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        _getData();
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        using (var context = new StuDBContext())
        {
            GridView1.DataSource = context.Students.Select(n => new { ID = n.ID, StuNo = n.StuNumber, Name = n.Name, Department = n.Department.Name, Sex = n.Sex ? "男" : "女" }).OrderBy(x => x.StuNo).ToList();
            GridView1.DataBind();
        }
    }

    /// <summary>
    /// 根据学院ID获取数据
    /// </summary>
    private void _getData()
    {
        using (var context = new StuDBContext())
        {
            var id = Guid.Parse(DropDownList1.SelectedValue);
            GridView1.DataSource = context.Students.Where(x => x.Department.ID == id).Select(n => new { ID = n.ID, StuNo = n.StuNumber, Name = n.Name, Department = n.Department.Name, Sex = n.Sex ? "男" : "女" }).OrderBy(x => x.StuNo).ToList();
            GridView1.DataBind();
        }
    }

    /// <summary>
    /// 删除
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        var id = Guid.Parse(GridView1.DataKeys[e.RowIndex].Value.ToString());
        using (var context = new StuDBContext())
        {
            var delStu = context.Students.Find(id);
            context.Students.Remove(delStu);
            context.SaveChanges();
        }
        _getData();
    }

    /// <summary>
    /// 进入编辑状态
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        _getData();
        var context = new StuDBContext();

        var list = context.Departments.ToList();
        DropDownList item1 = (DropDownList)(GridView1.Rows[e.NewEditIndex].FindControl("DropDownList2"));
        item1.DataSource = list;
        item1.DataTextField = "Name";
        item1.DataValueField = "ID";
        item1.DataBind();

        var id = GridView1.DataKeys[e.NewEditIndex].Value;
        var stu = context.Students.Find(id);
        if (stu.Department != null)
        {
            item1.SelectedValue = stu.Department.ID.ToString();
        }

        Cookie cookie = new Cookie("pwd", "123456");
    }

    /// <summary>
    /// 取消编辑状态
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        _getData();
    }

    /// <summary>
    /// 保存
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        var id = Guid.Parse(GridView1.DataKeys[e.RowIndex].Value.ToString());

        using (var context = new StuDBContext())
        {
            var p = context.Students.Find(id);
            var row = GridView1.Rows[e.RowIndex];
            var stuNo = (row.Cells[0].Controls[0] as TextBox).Text.Trim();
            var Name = (row.Cells[1].Controls[0] as TextBox).Text.Trim();
            var Sex = (row.Cells[2].Controls[0] as TextBox).Text.Trim();
            var Did = Guid.Parse(((DropDownList)row.FindControl("DropDownList2")).SelectedValue);

            p.StuNumber = stuNo;
            p.Name = Name;
            p.Sex = Sex == "男" ? false : true;
            p.Department = context.Departments.Find(Did);
            context.SaveChanges();
        }
        GridView1.EditIndex = -1;
        _getData();
    }
}
using DataContext;
using Enities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class StudentList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            _getDate();
        }
    }
    private void _getDate()
    {
        //显示数据
        using (var context = new StuDBContext())
        {
            var studentList = context.Students.Select(x=>new{ Sex=x.Sex?"男":"女",ID=x.ID,Name=x.Name,Phone=x.Phone, StudentCode = x.StudentCode,x.DepartMent}).OrderBy(x => x.StudentCode).ToList();
            GridView1.DataSource = studentList;
            GridView1.DataBind();
        }
    }
    protected string GetName(object obj)
    {
        if (obj != null)
            return ((DepartMent)obj).Name;
         return "显示错误";

    }

    protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {

    }
    //删除时发生
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        var id = Guid.Parse(GridView1.DataKeys[e.RowIndex].Value.ToString());
        using (var context=new StuDBContext())
        {
            var stu = context.Students.Find(id);
            context.Students.Remove(stu);
            context.SaveChanges();
        }
        _getDate();

    }
    //翻页时发生
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.EditIndex = -1;
        GridView1.PageIndex = e.NewPageIndex;
        _getDate();
        
    }
    //保存修改
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        var id = Guid.Parse(GridView1.DataKeys[e.RowIndex].Value.ToString());
        using (var context = new StuDBContext())
        {
            var stu = context.Students.Find(id);
            var name = e.NewValues["Name"].ToString();
            var studentcode = e.NewValues["StudentCode"].ToString();
            var sex= true;
            if (e.NewValues["sex"].ToString().Trim()!="男")
            {
                sex = false;
            }
            
            stu.Name = name;
            stu.StudentCode = studentcode;
            stu.Sex =sex;
            context.SaveChanges();

        }
        GridView1.EditIndex = -1;
        _getDate();
    }
    //切换编辑
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        _getDate();
    }
    //取消编辑
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        _getDate();
    }
}
using StuEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProductList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            _getData();
    }
    private void _getData() {
        using (var context = new DataContext.StuDBContext())
        {
            //查询出Students数据
            var students = context.Students.OrderBy(x => x.StudentNo).ToList();
            GridView1.DataSource = students;
            GridView1.DataBind();   

 
       }
    }
 

    protected string GetName(object obj) {
        if (obj != null)
            return ((DepartMent)obj).Name;
        return "该商品未被分类";
    }
    //分页
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        GridView1.EditIndex = -1;
        _getData();
    }



    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        NewMethod(e);
     
        _getData();
    }
    //删除
    private void NewMethod(GridViewDeleteEventArgs e)
    {
        var id = Guid.Parse(GridView1.DataKeys[e.RowIndex].Value.ToString());
        using (var context = new DataContext.StuDBContext())
        {

            var delstu = context.Students.Find(id);
            context.Students.Remove(delstu);
            context.SaveChanges();
        }
    }
    //切换到编辑
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        _getData();



        //查询出所有的分类
        var context1 = new DataContext.StuDBContext();

        //查询出Students数据
        var department = context1.DepartMents.ToList();


        //查询出Gridview中分类列编辑状态模板中下拉菜单
        DropDownList ddl =(DropDownList)GridView1.Rows[e.NewEditIndex].FindControl("DdlDepartment") as DropDownList;
        //下拉数据绑定
        ddl.DataSource = department;
        ddl.DataTextField = "Name";
        ddl.DataValueField = "ID";
        ddl.DataBind();

        //选项绑定
        var id = (Guid)GridView1.DataKeys[e.NewEditIndex].Value;
        //查询出当前记录 的商品记录，获取他的分类
        var departMents = context1.Students.Find(id);
        if (departMents.Department != null)
        {
            ddl.SelectedValue = departMents.Department.ID.ToString();
        }
    }
    //取消编辑
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        _getData();
    }
    //保存修改
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        //查询出该记录的主键
        var id = Guid.Parse(GridView1.DataKeys[e.RowIndex].Value.ToString());
        using (var context = new DataContext.StuDBContext())
        {
            var s = context.Students.Find(id);
            //读出Gridview中用户编辑的字段，给每个允许修改的实体属性赋值
            //获取用户编辑的这一行
            var row = GridView1.Rows[e.RowIndex];
            var sn = (row.Cells[0].Controls[0] as TextBox).Text.Trim();
            var name= (row.Cells[1].Controls[0] as TextBox).Text.Trim();
            var add = (row.Cells[2].Controls[0] as TextBox).Text.Trim();
            var Departmentid= Guid.Parse(((DropDownList)GridView1.Rows[e.RowIndex].FindControl("DdlDepartment")).SelectedValue);
            s.Department = context.DepartMents.Find(Departmentid);
            s.StudentNo = sn;
            s.FullName = name;
            s.Address = add;
            


            context.SaveChanges();
        }
        GridView1.EditIndex = -1;
        _getData();


    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
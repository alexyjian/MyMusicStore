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
            //查询出product数据
            var productList = context.Students.OrderBy(x => x.StudentNo).ToList();
            GridView1.DataSource = productList;
            GridView1.DataBind();   

 
       }
    }

    protected string GetName(object obj) {
        if (obj != null)
            return ((DepartMent)obj).Name;
        return "该商品未被分类";
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        _getData();
    }



    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        NewMethod(e);
     
        _getData();
    }

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

            s.StudentNo = sn;
            s.FullName = name;
            s.Address = add;

           
            context.SaveChanges();
        }
        GridView1.EditIndex = -1;
        _getData();
    }
}
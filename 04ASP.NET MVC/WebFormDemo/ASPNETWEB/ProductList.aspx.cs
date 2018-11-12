using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataContext;

public partial class ProductList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            _getData();
    }

    private void _getData()
    {
        using (var context = new prductDbContext())
        {
            //查询出Produc数据
            var productList = context.Products.OrderBy(x => x.SN).ToList();
            GridView1.DataSource = productList;
            GridView1.DataBind();
        }
    }
    //翻页事件
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        _getData();
    }

    //删除
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        object id = null;
        var deIProduct = Context.Products.Find(id);
        Context.Products.Remove(deIProduct);
        Context.SaveChanges();
    }
 //保存
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        //查询出该记录的主键
        var id = Guid.Parse(GridView1.DataKeys[e.RowIndex].Value.ToString());
        using (var context = new ProductDbContext())
        {
            //查询出要修改这记录
            var p = context.Products.Find(id);
            //读出gridview用户编辑的字段，给每个允许修改的实体属性赋值
            //获取用户编辑的这一行
            var row = GridView1.Rows[e.RowIndex];
            var sn = (row.Cells[0].Controls[0] as TextBox).Text.Trim();
            var name = (row.Cells[1].Controls[0] as TextBox).Text.Trim();
            var dscn = (row.Cells[2].Controls[0] as TextBox).Text.Trim();

            p.SN = sn;
            p.Name = name;
            context.SaveChanges();
        }
        GridView1.EditIndex = -1;
        _getData();
    }
}
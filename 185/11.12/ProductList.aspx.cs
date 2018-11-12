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
        //页面初次加载时，加载数据
        if (!IsPostBack)
            _getData();
    }
    private void _getData()
    {
        using (var context = new ProductDbContext())
        {
            //查询出Product数据
            var productList = context.Products.OrderBy(x => x.Sn).ToList();
            GridView1.DataSource = productList;
            GridView1.DataBind();
        }
    }
    //翻页事件
    private void GridView1_PageIndexChanging(object sender,GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        _getData();
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
   

    protected void GridView1_RowDeleting1(object sender, GridViewDeleteEventArgs e)
    {
        //查询出该记录的主键
        var id = Guid.Parse(GridView1.DataKeys[e.RowIndex].Value.ToString());
        using (var context = new ProductDbContext())
        {
            var delProduct = context.Products.Find(id);
            context.Products.Remove(delProduct);
            context.SaveChanges();
        }
        _getData();

    }
}
using DataContext;
using Entities;
using System;
using System.Linq;
using System.Web.UI.WebControls;

public partial class ProductList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //页面初始加载时，加载数据
        if (!IsPostBack)
            _getData();
    }

    private void _getData()
    {
        using(var context = new ProductDbContext())
        {
            //查询出Product数据
            var productList = context.Products.OrderBy(x => x.SN).ToList();
            GridView1.DataSource = productList;
            GridView1.DataBind();
        }
    }
    //分类字段绑定的方法
    protected string GetName(object obj)
    {
        if (obj != null)
            return ((Category)obj).Name;
        return "该商品未分类";
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
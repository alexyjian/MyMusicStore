using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataContext;
using Entities;

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
            var productList = context.Products.OrderBy(x=>x.SN).ToList();
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

    //翻页事件
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        GridView1.EditIndex = -1;
        _getData();
    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        //查询出该记录的主键
        var id = Guid.Parse(GridView1.DataKeys[e.RowIndex].Value.ToString());
        using (var context = new ProductDbContext())
        {
            //删除这条记录
            var delProduct = context.Products.Find(id);
            context.Products.Remove(delProduct);
            context.SaveChanges();
        }
        _getData();
    }

    //切换到编辑
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        _getData();

        //查询出所有的分类
        var context = new ProductDbContext();
        var categories = context.Categories.ToList();

        //查询出gridview中分类列编辑状态模板中下拉菜单
        var ddl = (DropDownList)GridView1.Rows[e.NewEditIndex].FindControl("DdlCategory");

        //下拉数据绑定
        ddl.DataSource = categories;
        ddl.DataTextField = "Name";
        ddl.DataValueField = "ID";
        ddl.DataBind();

        //选项绑定
        var id = (Guid)GridView1.DataKeys[e.NewEditIndex].Value;
        //查询出当前记录的商品记录，获取它的分类
        var product = context.Products.Find(id);
        if (product.Categoty != null)
            ddl.SelectedValue = product.Categoty.ID.ToString();
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
        using (var context = new ProductDbContext())
        {
            //查询出要修改这条记录
            var p = context.Products.Find(id);
            //读出gridview中用户编辑的字段,给每个允许修改的实体属性赋值
            //获取用户编辑的这一行
            var row = GridView1.Rows[e.RowIndex];
            var sn = ((TextBox)row.FindControl("txtSN")).Text.Trim();
            var name = (row.Cells[1].Controls[0] as TextBox).Text.Trim();
            var dscn = (row.Cells[3].Controls[0] as TextBox).Text.Trim();
            var categoryID = Guid.Parse(((DropDownList)row.FindControl("DdlCategory")).SelectedValue);
            p.Categoty = context.Categories.Find(categoryID);
            p.SN = sn;
            p.Name = name;
            p.DSCN = dscn;
            context.SaveChanges();
        }

        GridView1.EditIndex = -1;
        _getData();
    }
}
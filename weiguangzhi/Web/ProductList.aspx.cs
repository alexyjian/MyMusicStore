using DataContext;
using Entities;
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
        //页面初次加载时，加载数据
        if (!IsPostBack)
            _getData();


    }
    private void _getData()
    {
        using (var context = new ProductDbContext())
        {
            //查询出Product数据
            var productlist = context.Products.OrderBy(x => x.SN).ToList();
            GridView1.DataSource = productlist;
            GridView1.DataBind();
        }
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



    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        _getData();
        //查询出所有的分类
        var context = new ProductDbContext();
        var categories = context.Categories.ToList();
        //查询出grdview中分类列编辑状态模板中下拉菜单
        var ddl = (DropDownList)GridView1.Rows[e.NewEditIndex].FindControl("DropDownList1");
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
    protected string GetName(object obj)
    {
        if (obj != null)
            return ((Category)obj).Name;
        return "该商品为分类";
    }

    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        //查詢出該記錄的主鍵
        var id = Guid.Parse(GridView1.DataKeys[e.RowIndex].Value.ToString());
        using (var context = new ProductDbContext())
        {
            //查詢出要修改這條記錄
            var p = context.Products.Find(id);
            //讀出gridview中用戶的字段，給每個允許修改的屍體屬性賦值
            //獲取用戶編輯的這一行
            var row = GridView1.Rows[e.RowIndex];

            var sn = ((TextBox)row.FindControl("TextBox1")).Text.Trim();

            var name= (row.Cells[1].Controls[0] as TextBox).Text.Trim();
            var dscn= (row.Cells[3].Controls[0] as TextBox).Text.Trim();

            p.SN = sn;
            p.Name = name;
            p.DSCN = dscn;
            context.SaveChanges();
        }
        GridView1.EditIndex = -1;
        _getData();
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        GridView1.EditIndex = -1;
        _getData();
    }

    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {

        GridView1.EditIndex = -1;
            _getData();
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        

    }
}
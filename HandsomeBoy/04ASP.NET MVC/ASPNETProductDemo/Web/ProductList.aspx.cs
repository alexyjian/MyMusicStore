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
        if (!IsPostBack)
        {
            _getLoad();
        }
    }
    //查询出数据
    private void _getLoad() {
        using (var context =new DataContext.ProductDbContext())
        {
            var productList =  context.Product.OrderBy(x => x.SN).ToList();
            GridView1.DataSource = productList;
            GridView1.DataBind();

            var categoryList = context.Category.OrderBy(x => x.ID).ToList();
            DropDownList1.DataSource = categoryList;
            DropDownList1.DataTextField = "Name";
            DropDownList1.DataValueField = "ID";
            DropDownList1.DataBind();
        }
    }
    //把类别显示出来
    protected string GetName(object obj) {
        if (obj != null)
            return ((Category)obj).Name;
        return "该商品未被分类";
    }
    
    //下拉框变换而变换
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        using (var context = new DataContext.ProductDbContext())
        {
            var ID = Guid.Parse(DropDownList1.SelectedValue);
          GridView1.DataSource = context.Product.Where(x => x.Categoty.ID == ID).OrderBy(x=>x.SN).ToList();
            GridView1.DataBind();
        }
    }
    //翻页
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        GridView1.EditIndex = -1;
        _getLoad();
    }
    //删除
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        var ID =Guid.Parse(GridView1.DataKeys[e.RowIndex].Value.ToString());
        using (var context = new DataContext.ProductDbContext())
        {
          var ProductID =  context.Product.Find(ID);
            context.Product.Remove(ProductID);
            GridView1.EditIndex = -1;
            context.SaveChanges();
            _getLoad();
        }
          
    }
    
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

        var ID = Guid.Parse(GridView1.DataKeys[e.RowIndex].Value.ToString());
        using (var context = new DataContext.ProductDbContext())
        {
            //查询出要修改这条记录
            var p = context.Product.Find(ID);
            //获取用户编辑的这一行
            var row = GridView1.Rows[e.RowIndex];

            var Name = (row.Cells[1].Controls[0] as TextBox).Text.Trim();
          
            var DSCN = (row.Cells[3].Controls[0] as TextBox).Text.Trim();
            var categoryid = Guid.Parse(((DropDownList)GridView1.Rows[e.RowIndex].FindControl("DdlCategory")).SelectedValue);
            var Category = context.Category.Find(categoryid);

            p.Name = Name;
        
            p.DSCN = DSCN;
            p.Categoty = Category;
         }
    }
    // 修改
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        _getLoad();
        var context = new DataContext.ProductDbContext();
        var category = context.Category.ToList();
        var ddl =(DropDownList)GridView1.Rows[e.NewEditIndex].FindControl("DdlCategory");
        ddl.DataSource = category;
        ddl.DataTextField = "Name";
        ddl.DataValueField = "ID";
        ddl.DataBind();
        var id = (Guid)GridView1.DataKeys[e.NewEditIndex].Value;
        var product = context.Product.Find(id);
        if (product.Categoty != null)
            ddl.SelectedValue = product.Categoty.ID.ToString();
    }

    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        _getLoad();
    }
}
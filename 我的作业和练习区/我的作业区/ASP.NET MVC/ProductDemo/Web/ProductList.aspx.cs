using System;
using DataContext;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entities;

public partial class ProductList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            _getData();
        }
    }
    private void _getData()
    {
        //显示数据
        using (var context=new ProductDbContext())
        {
            var productList = context.Products.OrderBy(x => x.SN).ToList();            
            GridView1.DataSource = productList;
            GridView1.DataBind();
        }
    }
    //删除事件
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        //查询出该纪录的主键
        var id = Guid.Parse(GridView1.DataKeys[e.RowIndex].Value.ToString());
        using (var context=new ProductDbContext())
        {
            //删除这条纪录
            var delProduct = context.Products.Find(id);
            context.Products.Remove(delProduct);
            context.SaveChanges();
        }
        _getData();
    }
    protected string GetName(object obj)
    {
        if (obj != null)
            return ((Category)obj).Name;      
        else return "该商品未分类";

    }
    //翻页时发生
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.EditIndex = -1;
        GridView1.PageIndex = e.NewPageIndex;
        _getData();
    }
    //切换编辑
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        _getData();
        //查询所有的分类
        var context = new ProductDbContext();       
        var catagoryList = context.Categorys.OrderBy(x => x.SortCode).ToList();
        
        //查询出Gridvidew中分类列编辑状态模版中下拉菜单
        var ddl =(DropDownList)GridView1.Rows[e.NewEditIndex].FindControl("DropDownList1");

        //下拉数据绑定
        ddl.DataSource = catagoryList;
        ddl.DataTextField = "Name";
        ddl.DataValueField = "ID";
        ddl.DataBind();

        //选项绑定
        var id = (Guid)GridView1.DataKeys[e.NewEditIndex].Value;
        var product = context.Products.Find(id);
        if (product.Category != null)
        {
            ddl.SelectedValue = product.Category.ID.ToString();                        
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
        //查询出该纪录的主键
        var id = Guid.Parse(GridView1.DataKeys[e.RowIndex].Value.ToString());
        using (var context = new ProductDbContext())
        {
            //查询这条纪录
            var p = context.Products.Find(id);
            //读出gridview用户编辑的字段，每个允许修改的实体属性赋值
            //获取用户编辑的这一行
            //var row = GridView1.Rows[e.RowIndex];
            //var sn = (row.Cells[0].Controls[0] as TextBox).Text.Trim();
            //var name= (row.Cells[1].Controls[1] as TextBox).Text.Trim();
            //var dscn= (row.Cells[2].Controls[2] as TextBox).Text.Trim();
            var sn = (TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox1");
            var name = e.NewValues["Name"].ToString();
            var dscn = e.NewValues["DSCN"].ToString();           
            var category = (DropDownList)GridView1.Rows[e.RowIndex].FindControl("DropDownList1");
            //更新
            p.SN = sn.Text.ToString().Trim();
            p.Name = name;
            p.DSCN = dscn;
            p.Category= context.Categorys.Find(Guid.Parse(category.SelectedValue));         
            //保存
            context.SaveChanges();
        }
        GridView1.EditIndex = -1;
        _getData();
    }
}
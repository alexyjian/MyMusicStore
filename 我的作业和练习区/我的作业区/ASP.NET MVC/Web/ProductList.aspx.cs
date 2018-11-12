using System;
using DataContext;
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
            _getData();
        }
    }
    private void _getData()
    {
        //显示数据
        using (var context=new ProductDbContext())
        {
            var productList = context.Products.Select(x =>new
            {     SN=x.SN,
                DSCN = x.DSCN,
                Name = x.Name,
                ID = x.ID,
                Category = x.Category.Name       
              
            }).OrderBy(x => x).ToList();            
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
    //翻页时发生
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        GridView1.PageIndex = e.NewPageIndex;
        _getData();
    }
    //切换编辑
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
            var sn = e.NewValues["SN"].ToString();
            var name = e.NewValues["Name"].ToString();
            var dscn = e.NewValues["DSCN"].ToString();
            var category = e.NewValues["Category"].ToString();
            //更新
            p.SN = sn;
            p.Name = name;
            p.DSCN = dscn;
            p.Category.Name = category;
            //保存
            context.SaveChanges();
        }
        GridView1.EditIndex = -1;
        _getData();
    }
}
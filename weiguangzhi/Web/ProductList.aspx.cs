using DataContext;
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

    }

    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        //查詢出該記錄的主鍵
        var id = Guid.Parse(GridView1.DataKeys[e.RowIndex].Value.ToString());
        using (var context = new ProductDbContext())
        {
            //查詢出要修改這條記錄
            var p = context.Products.Find();
            //讀出gridview中用戶的字段，給每個允許修改的屍體屬性賦值
            //獲取用戶編輯的這一行
            var row = GridView1.Rows[e.RowIndex];
            var sn = (row.Cells[0].Controls[0] as TextBox).Text.Trim();
            var name= (row.Cells[1].Controls[0] as TextBox).Text.Trim();
            var dscn= (row.Cells[2].Controls[0] as TextBox).Text.Trim();

            p.SN = sn;
            p.Name = name;
            p.DSCN = dscn;
            context.SaveChanges();
        }
        GridView1.EditIndex = -1;
        _getData();
    }
}
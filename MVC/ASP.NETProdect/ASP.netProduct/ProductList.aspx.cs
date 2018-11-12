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
                if (!IsPostBack)
                    _getData();
            }
    

        private void _getData()
        {
            using (var context = new ProductDbContext())
            {
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

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
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
    }

    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        _getData();
    }

    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        var id = Guid.Parse(GridView1.DataKeys[e.RowIndex].Value.ToString());
        using (var context = new ProductDbContext())
        {
            //查询出这条记录

            var P = context.Products.Find(id);
            //读出gridview中用户编辑的字段，给每个允许修改的实体属性赋值
            //获取用户编辑的一行
            var row = GridView1.Rows[e.RowIndex];
            var sn = (row.Cells[0].Controls[0] as TextBox).Text.Trim();
            var name = (row.Cells[1].Controls[0] as TextBox).Text.Trim();
            var dscn = (row.Cells[2].Controls[0] as TextBox).Text.Trim();

            P.SN = sn;
            P.Name = name;
            P.DSCN = dscn;
            context.SaveChanges();
           
        }
        GridView1.EditIndex = -1;
        _getData();
    }
}
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
    private void _getData() {
        using (var context = new DataContext.StuDBContext())
        {
            //查询出product数据
            var productList = context.Students.OrderBy(x => x.StudentNo).ToList();
            GridView1.DataSource = productList;
            GridView1.DataBind();   

 
       }
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        _getData();
    }



    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        NewMethod(e);
     
        _getData();
    }

    private void NewMethod(GridViewDeleteEventArgs e)
    {
        var id = Guid.Parse(GridView1.DataKeys[e.RowIndex].Value.ToString());
        using (var context = new DataContext.StuDBContext())
        {

            var delstu = context.Students.Find(id);
            context.Students.Remove(delstu);
            context.SaveChanges();
        }
    }
}
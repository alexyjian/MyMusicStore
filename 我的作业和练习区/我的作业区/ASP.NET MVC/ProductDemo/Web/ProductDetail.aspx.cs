using DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProductDetail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != null)
        {
            var id = Guid.Parse(Request.QueryString["id"].ToString());
            var product = new ProductDbContext().Products.Find(id);
            LblSN.Text = product.SN;
            LblName.Text = product.Name;
            LblDSCN.Text = product.DSCN;
        }
        else
        {
            Response.Redirect("~/productlist.aspx");
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/productlist.aspx");
    }
}
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
        if(Request.QueryString["id"]!=null)
        {
            var id = Guid.Parse(Request.QueryString["id"].ToString());
            var product = new ProductDbContext().Products.Find(id);
            Label2.Text = product.SN;
            Label3.Text = product.Name;
            Label4.Text = product.DSCN;
        }
        else
        {
            Response.Redirect("~/productlist.aspx");
        }
    }
}
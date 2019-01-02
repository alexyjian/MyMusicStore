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
       
        if (Request.QueryString["id"].ToString() != null)
        {
            var id = Guid.Parse(Request.QueryString["id"].ToString());
            var product = new DataContext.ProductDbContext().Product.Find(id);
            Label4.Text = product.Name;
            Label3.Text = product.SN;
            Label6.Text = product.DSCN;
        }
        else
        {
            Response.Redirect("productlist.aspx");
        }
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("productlist.aspx");
    }
}
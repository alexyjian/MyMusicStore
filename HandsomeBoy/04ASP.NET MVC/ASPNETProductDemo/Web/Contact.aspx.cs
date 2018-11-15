using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Contact : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //var s = Request.QueryString["str"].ToString();
        //var s1 = Request.QueryString["str1"].ToString();
        //Label1.Text = s+','+s1;

       
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        var category = new DataContext.ProductDbContext().Category.First();
        Session["C"] = category;


        var categoriesList = new DataContext.ProductDbContext().Category.ToList();
        Session["E"] = categoriesList;
        Response.Redirect("~/About.aspx");
    }
}
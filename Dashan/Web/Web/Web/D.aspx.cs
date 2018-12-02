using DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class D : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //var category = new ProductDbContext().Categories.First();//传对象

            //转泛型
            var Categories = new ProductDbContext().Categories.ToList();
            Session["D"] = Categories;
            Response.Redirect("~/E.aspx");

        }
    }
}
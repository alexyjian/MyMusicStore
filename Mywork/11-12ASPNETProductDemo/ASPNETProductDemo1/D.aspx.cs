using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class D : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["C"]!=null)
        {
            var c = Session["C"] as Category;
            Label1.Text = c.SortCode + "," + c.Name;
        }
    }
}
using System.Web.Providers.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entities;

public partial class D : System.Web.UI.Page
{
    private object catr;
    private object Label1;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["C"]!= null)
        {
            var c = Session["C"] as IList<Category>;
            var cstr = "";

            foreach (var item in c)
                cstr += item.SortCode + "." + item.Name + "\r\n";

            Label1.Text= catr;
        }
    }
}
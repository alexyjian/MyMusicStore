using StuEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class b : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //var a = Request.QueryString["a"].ToString();
        //Label1.Text = a ;

        if (Session["str"] != null)
            Label1.Text = Session["str"].ToString();
    }
}
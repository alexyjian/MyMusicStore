﻿using DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class C : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        var categories = new ProductDbContext().Categorys.ToList();
        Session["C"] = categories;
        Response.Redirect("~/D.aspx");
    }
}
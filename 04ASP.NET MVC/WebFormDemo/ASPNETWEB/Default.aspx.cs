using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var depts = new StuContext.StuDBContext().DepartMents.ToList();
        DropDownList1.DataSource = depts;
        DropDownList1.DataTextField = "Name";
        DropDownList1.DataValueField = "ID";
        DropDownList1.DataBind();
    }
}
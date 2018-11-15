using StuEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Details : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != null)
        {
            var id = Guid.Parse(Request.QueryString["id"].ToString());
            var datailsstu = new StuContext.StuuuContext().Studetnt.Find(id);
            LblName.Text = datailsstu.Name;
            LblAddress.Text = datailsstu.Address;
            Lblphone.Text = datailsstu.Phone;
        }
        else
            Response.Redirect("~/Default.aspx");
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SDataContext;

public partial class _Default : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            GridView1.DataSource = new StudentContent().Students
                .Select(n =>
                new
                {
                    Name = n.Name,
                    Department = n.DepartMent.Name,
                    Sex = n.Sex ? "男" : "女"
                }).Where(x => x.Department == "电子信息").OrderBy(x => x.Name).Take(100).ToList();
            GridView1.DataBind();
            DropDownList1.DataValueField = "ID";
            DropDownList1.DataTextField = "Name";
            DropDownList1.DataSource = new StudentContent().DepartMents.ToList();
            DropDownList1.DataBind();
        }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

        GridView1.DataSource = new StudentContent().Students
            .Select(n =>
            new
            {
                Name = n.Name,
                Department = n.DepartMent,
                Sex = n.Sex ? "男" : "女"
            }).Where(x => x.Department.ID==Guid.Parse(DropDownList1.SelectedValue)).OrderBy(x => x.Name).Take(100).ToList();
        GridView1.DataBind();
    }
}
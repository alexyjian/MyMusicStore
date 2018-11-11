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
        if (!IsPostBack) { 
        using (var context = new StuContext.StuuuContext())
        {
            var depts = context.DepartMent.ToList();

            DropDownList1.DataSource = depts;
            DropDownList1.DataTextField = "Name";
            DropDownList1.DataValueField = "ID";
            DropDownList1.DataBind();

            var list = context.Studetnt.Select(n => new
            {
                StuNo = n.StudentNo,
                Name = n.Name,
                department = n.DepartMent.Name,
                Sex = n.Sex ? "男" : "女",
                Address = n.Address,
                phone = n.Phone
            })
            .Take(20).OrderBy(x=>x.department).ToList();
            GridView1.DataSource = list;
            GridView1.DataBind();
        }
    }
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        var id = Guid.Parse(DropDownList1.SelectedValue);
        using (var context = new StuContext.StuuuContext())
        {
            var list = context.Studetnt.Where(n => n.DepartMent.ID == id).Select(n=>new
            {
                StuNo = n.StudentNo,
                Name = n.Name,
                department = n.DepartMent.Name,
                Sex = n.Sex ? "男" : "女",
                Address = n.Address,
                phone = n.Phone
            })
        .OrderBy(x => x.StuNo).ToList();
            GridView1.DataSource = list;
            GridView1.DataBind();
        }
        }
}
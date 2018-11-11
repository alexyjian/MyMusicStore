using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPnetWebForm01
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (var context = new DataContext.StuDBCotext())
        {
            var depts = new DataContext.StuDBCotext().DepartMents.ToList();
            DropDownList2.DataSource = depts;
            DropDownList2.DataTextField = "Name";
            DropDownList2.DataValueField = "ID";
            DropDownList2.DataBind();

            GridView1.DataSource = context.Students.Select(n => new { fullName = n.FullName, stuNo = n.StudentNo }).Take(20).ToList();
            GridView1.DataBind();
          }
        }
    }
}
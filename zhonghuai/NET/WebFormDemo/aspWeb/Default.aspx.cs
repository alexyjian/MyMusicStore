using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace aspWeb
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            using (var context = new DataContext.StuDBContext())
            {
                if (DropDownList1.SelectedValue == string.Empty)
                {
                    var depts = context.DepartMents.OrderBy(x=>x.SortCode).ToList();
                    DropDownList1.DataSource = depts;
                    DropDownList1.DataTextField = "Name";
                    DropDownList1.DataValueField = "ID";
                    DropDownList1.DataBind();

                    GridView1.DataSource = context.Students.Select(n=>new {
                        stundentCode =n.StudentCode,
                        name =n.Name,
                        department =n.Department_ID.Name,
                        sex =n.Sex?"男":"女",
                        address =n.Address,
                        telphone =n.Phone}
                    ).Take(30).OrderBy(x => x.stundentCode).ThenBy(x => x.sex).ToList();
                    GridView1.DataBind();
                }
                else
                {

                    //当前选择项
                    var drop =Guid.Parse(DropDownList1.SelectedValue);
                    GridView1.DataSource = context.Students.Take(30).Where(x =>x.Department_ID.ID == drop).Select(n => new {
                        stundentCode = n.StudentCode,
                        name = n.Name,
                        department = n.Department_ID.Name,
                        sex = n.Sex ? "男" : "女",
                        address = n.Address,
                        telphone = n.Phone
                    }
                    ).OrderBy(x => x.stundentCode).ThenBy(x => x.sex).ToList();//.OrderBy(x=>x.stundentCode).ThenBy(x=>x.sex)两次排序
                    GridView1.DataBind();
                }
            }
        }
    }
}
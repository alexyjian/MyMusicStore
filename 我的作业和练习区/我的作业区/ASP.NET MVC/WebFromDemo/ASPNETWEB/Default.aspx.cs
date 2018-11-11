using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ASPNETWEB_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            using (var context = new StuContext.StuDBContext())
            {
                var depts = context.DepartMents.ToList();

                DropDownList1.DataSource = depts;
                DropDownList1.DataTextField = "Name";
                DropDownList1.DataValueField = "ID";
                DropDownList1.DataBind();
                //取若干个字段显示
                var list = context.Students.Select(x => new
                {
                    StudentCode = x.StudentCode,
                    Name = x.Name,
                    Sex = x.Sex ? "男" : "女",
                    Phone = x.Phone,
                    Address = x.Address,
                    Birthday = x.Birthday,
                    DepartMent = x.DepartMent.Name

                })   //取前20条纪录，先按学院排序，再按学号倒序排序
                .Take(20).OrderBy(x => x.DepartMent).ThenByDescending(x => x.StudentCode).ToList();
                GridView1.DataSource = list;
                GridView1.DataBind();
            }
        }
    }
    //当下拉选项发生变化，触发事件
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        //读出选取的id
        var id = Guid.Parse(DropDownList1.SelectedValue);
        using (var context = new StuContext.StuDBContext())
        {

            var list = context.Students.Where(x => x.DepartMent.ID == id).Select(x => new
            {
                StudentCode = x.StudentCode,
                Name = x.Name,
                Sex = x.Sex ? "男" : "女",
                Phone = x.Phone,
                Address = x.Address,
                Birthday = x.Birthday,
                DepartMent = x.DepartMent.Name

            })   //按学号倒序排序
            .OrderBy(x => x.StudentCode).ToList();
            GridView1.DataSource = list;
            GridView1.DataBind();
        }
    }
}
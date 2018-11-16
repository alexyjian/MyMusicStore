using DataContext;
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
        //IsPostBack判断页面是加载还是回发，如果不是回发才进行数据初始化
        if (!IsPostBack)
        {
            //读出选择的部门id
            using (var context = new StuDBContext())
            {
                var depts = context.Departments.ToList();

                DropDownList1.DataSource = depts;
                DropDownList1.DataTextField = "Name";
                DropDownList1.DataValueField = "ID";
                DropDownList1.DataBind();

                //选取若干个字段显示
                var list = context.Students
                    .Select(n => new
                    {
                        StuNo = n.StudentCode,
                        Name = n.Name,
                        Department = n.Department.Name,
                        Sex = n.Sex ? "男" : "女",
                        Address = n.Address,
                        Telphone = n.Phone
                    }).Take(20).OrderBy(x => x.Department).ThenByDescending(x => x.StuNo).ToList();
                //取前20条记录，先按学院排序，在按学号倒序排序
                GridView1.DataSource = list;
                GridView1.DataBind();
            }
        }
    }

    protected void DataList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        //读出选择的部门id
        var id = Guid.Parse(DropDownList1.SelectedValue);

        //读出选择的部门id
        using (var context = new StuDBContext())
        {
            var list = context.Students.Where(n => n.Department.ID == id)
                 .Select(n => new
                 {
                     StuNo = n.StudentCode,
                     Name = n.Name,
                     Department = n.Department.Name,
                     Sex = n.Sex ? "男" : "女",
                     Address = n.Address,
                     Telphone = n.Phone
                 })
            //选取若干个字段显示
               .Take(20).OrderBy(x => x.StuNo).ToList();
            //取前20条记录，先按学院排序，在按学号倒序排序
            GridView1.DataSource = list;
            GridView1.DataBind();
        }
    }
}
using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _11_9ASP.net
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //IsPostBack判断页面是加载还是回发，如果不是回发才进行数据初始化
            if (!IsPostBack)
            {
                using (var context = new DataContext.StuDBContext())
                {
                    var depts = context.DepartMents.ToList();
                    DropDownList1.DataSource = depts;
                    DropDownList1.DataTextField = "Name";
                    DropDownList1.DataValueField = "ID";
                    DropDownList1.DataBind();

                    var list = context.Students
                         //选取若干个字段显示
                         .Select(n => new
                         {
                             StuNo = n.StudentNo,
                             FullName = n.FullName,
                             Department = n.Department.Name,
                             Sex = n.Sex ? "男" : "女",
                             Address = n.Address,
                             Telphone = n.Phone
                         })
                        //取前20条记录，先按学院排序，再按学号倒序排序
                        .Take(20).OrderBy(x => x.Department).ThenByDescending(x => x.StuNo).ToList();
                    GridView1.DataSource = list;
                    GridView1.DataBind();
                }
            }

            }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //读出选择的部门id
            var id = Guid.Parse(DropDownList1.SelectedValue);
            //按部门查询学生信息
            using (var context = new DataContext.StuDBContext())
            {
                var list = context.Students.Where(n => n.Department.ID == id)
                    //选取若干个字段显示
                    .Select(n => new
                    {
                        StuNo = n.StudentNo,
                        FullName = n.FullName,
                        Department = n.Department.Name,
                        Sex = n.Sex ? "男" : "女",
                        Address = n.Address,
                        Telphone = n.Phone
                    }).OrderBy(x => x.StuNo).ToList();
                GridView1.DataSource = list;
                GridView1.DataBind();
            }
        }
    }
}
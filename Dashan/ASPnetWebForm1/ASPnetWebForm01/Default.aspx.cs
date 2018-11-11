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

            //IsPostBack 时间周期 判断页面加载还是回发 不重复
            if (!IsPostBack)
            {
                using (var context = new DataContext.StuDBCotext())
                {
                    var depts = new DataContext.StuDBCotext().DepartMents.ToList();
                    DropDownList2.DataSource = depts;
                    DropDownList2.DataTextField = "Name";
                    DropDownList2.DataValueField = "ID";
                    DropDownList2.DataBind();


                    //列表形式
                    var list = context.Students.Select(n => new
                    {
                        //选字段显示
                        StuNo = n.StudentNo,
                        FullName = n.FullName,
                        Department = n.Department.Name,
                        Sex = n.Sex ? "男" : "女",
                        Address = n.Address,
                        Telphone = n.Phone
                    })

                   //运用二次排序（ThenBy）运用二次倒叙（ThenByDescending）
                   .Take(20).OrderBy(x => x.StuNo).ToList();
                    GridView1.DataSource = list;
                    GridView1.DataBind();

                }
            }
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = Guid.Parse(DropDownList2.SelectedValue);
            //按部门查询学生信息
            using(var context =new DataContext.StuDBCotext())
            {
                var list = context.Students.Where(n=>n.Department.ID==id)

                    .Select(n => new
                    {
                        //选字段显示
                        StuNo = n.StudentNo,
                        FullName = n.FullName,
                        Department = n.Department.Name,
                        Sex = n.Sex ? "男" : "女",
                        Address = n.Address,
                        Telphone = n.Phone
                    })
                   //运用二次排序（ThenBy）运用二次倒叙（ThenByDescending）
                  .Take(20).OrderBy(x => x.StuNo).ToList();
                GridView1.DataSource = list;
                GridView1.DataBind();
            }
           
        }
    }
 }

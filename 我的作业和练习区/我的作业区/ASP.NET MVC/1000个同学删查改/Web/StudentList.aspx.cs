using DataContext;
using Enities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class StudentList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            _getDate();
        }
    }
    private void _getDate()
    {
        //显示数据
        using (var context = new StuDBContext())
        {
            var studentList = context.Students.Select(x=>new{ Sex=x.Sex?"男":"女",ID=x.ID,Name=x.Name,Phone=x.Phone, StudentCode = x.StudentCode,x.DepartMent}).OrderBy(x => x.StudentCode).ToList();
            GridView1.DataSource = studentList;
            GridView1.DataBind();
        }
    }
    protected string GetName(object obj)
    {
        if (obj != null)
            return ((DepartMent)obj).Name;
         return "显示错误";

    }
}
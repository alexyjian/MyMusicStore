using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StuContext;
using StuEntities;
using StuEntities;

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
                    ID = n.ID,
                StuNo = n.StudentNo,
                Name = n.Name,
                department = n.DepartMent.Name,
                Sex = n.Sex ? "男" : "女",
                Address = n.Address,
                phone = n.Phone
            }) .Take(20).OrderBy(x=>x.department).ToList();
           
            GridView1.DataSource = list;
            GridView1.DataBind();
        }
    }
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        _selectStudetnt();
    }

    private void _selectStudetnt()
    {
        var id = Guid.Parse(DropDownList1.SelectedValue);
        using (var context = new StuContext.StuuuContext())
        {
            var list = context.Studetnt.Where(n => n.DepartMent.ID == id).Select(n => new
            {
                ID = n.ID,
                StuNo = n.StudentNo,
                Name = n.Name,
                department = n.DepartMent.Name,
                Sex = n.Sex ? "男" : "女",
                Address = n.Address,
                phone = n.Phone
            }) .OrderBy(x => x.StuNo).ToList();
       
            GridView1.DataSource = list;
            GridView1.DataBind();
        }
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        _selectStudetnt();
    }


    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        var keyid =Guid.Parse( GridView1.DataKeys[e.RowIndex].Value.ToString());
        using (var context = new StuContext.StuuuContext())
        {
            var delstudetnt = context.Studetnt.Find(keyid);
            context.Studetnt.Remove(delstudetnt);
            context.SaveChanges();
        }
        _selectStudetnt();
    }

    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        _selectStudetnt();

        //数据绑定
        var context = new StuContext.StuuuContext();
        var cate = context.DepartMent.ToList();
        var ddl =(DropDownList)GridView1.Rows[e.NewEditIndex].FindControl("DropDownList2");
        ddl.DataSource = cate;
        ddl.DataTextField = "Name";
        ddl.DataValueField = "ID";
        ddl.DataBind();
        //选项绑定
        var id = (Guid)GridView1.DataKeys[e.NewEditIndex].Value;
        var desctip = context.DepartMent.Find(id);
       

    }
 
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        _selectStudetnt();
    }
   
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        var id = Guid.Parse(GridView1.DataKeys[e.RowIndex].Value.ToString());
        using (var context = new StuContext.StuuuContext())
        {
            var p = context.Studetnt.Find(id);
            //获取编辑行
            var row = GridView1.Rows[e.RowIndex];
            //var StuNo = (row.Cells[0].Controls[0] as TextBox).Text.Trim();
            var Name = (row.Cells[1].Controls[0] as TextBox).Text.Trim();
            var Address = (row.Cells[4].Controls[0] as TextBox).Text.Trim();
            var phone = (row.Cells[5].Controls[0] as TextBox).Text.Trim();
            var Departmentid = Guid.Parse(((DropDownList)row.FindControl("DropDownList2")).SelectedValue);
            p.DepartMent = context.DepartMent.Find(Departmentid);
           // p.StudentNo = StuNo;
            p.Name = Name;
            p.Address = Address;
            p.Phone = phone;
            context.SaveChanges();
        }
        GridView1.EditIndex = -1;
        _selectStudetnt();

    }
    protected object GetName(object obj)
    {
        //  var dd = (TextBox)GridView1.Rows[e.NewEditIndex].FindControl("DepartMentSeedLbl");

        if (obj != null)
            return obj;
        return "此学生未分院系";
    }
}
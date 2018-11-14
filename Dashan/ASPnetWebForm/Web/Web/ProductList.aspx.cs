using DataContext;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class ProductList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //页面初次加载
            if (!IsPostBack)
                _getData();
        }

        //查询分类
        protected string GetName(object obj)
        {
            if (obj != null)
                return ((Category)obj).Name;
            return "该商品未分类";
        }

        private void _getData()
        {
            using (var context = new ProductDbContext())
            {
                //查询出Product数据
                var productList = context.Products.OrderBy(x => x.SN).ToList();
                GridView1.DataSource = productList;
                GridView1.DataBind();
            }
        }
  
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            _getData();
        }


      
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            var id = Guid.Parse(GridView1.DataKeys[e.RowIndex].Value.ToString());
            using (var context =new ProductDbContext())
            {
                //删除记录
                var delProduct = context.Products.Find(id);
                context.Products.Remove(delProduct);
                context.SaveChanges();
            }
            _getData();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            _getData();

            //查询出所有的分类
            var context = new ProductDbContext();
            var categories = context.Categories.ToList();

            //查询出GridView中的分类列编辑状态下的下拉菜单
            var ddl = (DropDownList)GridView1.Rows[e.NewEditIndex].FindControl("DdlCategory");

            //下拉数据绑定
            ddl.DataSource = categories;
            ddl.DataTextField = "Name";
            ddl.DataValueField = "ID";
            ddl.DataBind();

            //选项绑定
            var id = (Guid)GridView1.DataKeys[e.NewEditIndex].Value;
            //查询
            var product = context.Products.Find(id);
            if (product.Category != null)
                ddl.SelectedValue = product.Category.ID.ToString();

        }


        //保存修改
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            var id = Guid.Parse(GridView1.DataKeys[e.RowIndex].Value.ToString());
            using (var context = new ProductDbContext())

            {
                var p = context.Products.Find(id);
                var row = GridView1.Rows[e.RowIndex];
                var sn = (row.Cells[0].Controls[0] as TextBox).Text.Trim();
                var name = (row.Cells[1].Controls[0] as TextBox).Text.Trim();
                var dscn = (row.Cells[3].Controls[0] as TextBox).Text.Trim();

                var categoryID = Guid.Parse(((DropDownList)row.FindControl("DdlCategory")).SelectedValue);
                p.Category = context.Categories.Find(categoryID);


                p.SN = sn;
                p.Name = name;
                p.DSCN = dscn;
                context.SaveChanges();

            }
            GridView1.EditIndex = -1;
            _getData();
        }
    }
}
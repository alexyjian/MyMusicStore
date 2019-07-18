﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataContext;


namespace aspWeb
{
    public partial class ProductList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //页面初次加载时，加载数据
            if (!IsPostBack)
                _getData();
        }

        private void _getData()
        {
            using (var context = new StuDBContext())
            {
                //查询出Product数据
                var productList = context.DepartMents.OrderBy(x => x.ID).ToList();
                GridView1.DataSource = productList;
                GridView1.DataBind();
            }
        }

        //分类字段绑定的方法
        //protected string GetName(object obj)
        //{
        //    if (obj != null)
        //        return ((Category)obj).Name;
        //    return "该商品为分类";
        //}


        //翻页事件
        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            GridView1.PageIndex = e.NewSelectedIndex;
            _getData();
        }

       
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //查询出该记录的主键
            var id = Guid.Parse(GridView1.DataKeys[e.RowIndex].Value.ToString());
            using (var context = new StuDBContext())
            {
                //删除这条记录
                var delProduct = context.DepartMents.Find(id);
                context.DepartMents.Remove(delProduct);
                context.SaveChanges();

            }
            _getData();
        }

        //切换到编辑
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            _getData();

            //查询出所有的分类
            //var context= new Stu StuDBContext
        }



        //取消编辑
        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            _getData();
        }

        //保存修改
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //查询出该记录的主键
            var id = Guid.Parse(GridView1.DataKeys[e.RowIndex].Value.ToString());
            using (var context = new StuDBContext())
            {
                //查询出要修改这条记录
                var p = context.DepartMents.Find(id);
                //读出gridviev中用户编辑的字段，给每个允许修改的实体的属性赋值
                //获取用户编辑的这一行
                var row = GridView1.Rows[e.RowIndex];
                var sn = (row.Cells[0].Controls[0] as TextBox).Text.Trim();
                var name = (row.Cells[1].Controls[0] as TextBox).Text.Trim();

                var dsscn = (row.Cells[2].Controls[0] as TextBox).Text.Trim();
                 

                p.ID = id;
                p.Name = name;
                p.SortCode = dsscn;

            }
            GridView1.EditIndex = -1;
            _getData();
        }
    }
}
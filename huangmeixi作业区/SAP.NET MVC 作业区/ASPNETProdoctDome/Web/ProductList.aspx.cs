﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataContext;

public partial class ProductList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            _getData();
    }

    private void _getData()
    {
        using (var context = new ProductDbContext())
        {
            //查询Product数据
            var productList = context.Products.OrderBy(x => x.SN).ToList();
            GridView1.DataSource = productList;
            GridView1.DataBind();
    

        }

    }
    //翻页事件
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        _getData();
    }
    //删除事件
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        //查询出该纪录的主键
        var id = Guid.Parse(GridView1.DataKeys[e.RowIndex].Value.ToString());
        using (var context = new ProductDbContext())
        {
            //删除这条记录
            var delProduct = context.Products.Find(id);
            context.Products.Remove(delProduct);
            context.SaveChanges();
        }
        _getData();
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class B : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //获取地址请求的参数
            var s = Request.QueryString["s"].ToString();
            Label1.Text = s;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if(TextBox1.Text=="admin")
        {
            if (TextBox2.Text == "123")
                Response.Write("<script>alert('登录成功!');location.href='default.aspx'</script>");
            else
                Response.Write("<script>alert('密码不正确!');</script>");
        }
        else
        {
            Response.Write("<script>alert('用户名不正确!');</script>");
        }
    }
}
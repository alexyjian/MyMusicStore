using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class C : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["D"] != null)
            {


                //var d = Session["D"] as Category; //传对象

                //运用泛型
                var d = Session["D"] as List<Category>;
                var cstr = "";

                foreach (var item in d)
                    cstr += item.SortCode + "." + item.Name;
                Label1.Text =cstr;   

            }
             
        }
    }
}
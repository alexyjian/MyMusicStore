using MusicStoreEntities.UserAndRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStore.ViewModels
{
    public class LoginUserStatus
    {
        //登陆成否成功
        public bool IsLogin { get; set; }
        //登陆成功失败的信息
        public string Message { get; set;}
        //登陆成功后跳转的控制器
        public string GotoController { get; set;}
        //登陆成功后跳转的方法
        public string GotoAction { get; set; }

    }
    /// <summary>
    /// 用户处理登陆成功后的用户会话
    /// </summary>
    public class LoginUserSessionModel
    {
        public ApplicationUser User { get; set; }//账户对象
        public Person Person { get; set; }//个人信息的对象
        public string RoleName { get; set; }
        //此外还可以定义其他业务对象 购物车 订单.....
    }
}
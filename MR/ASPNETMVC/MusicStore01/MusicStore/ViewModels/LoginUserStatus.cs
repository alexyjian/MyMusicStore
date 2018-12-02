using MusicStoreEntity.UserAndRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UserAndRole;

namespace MusicStore.ViewModels
{
    /// <summary>
    /// 用户登录时的状态
    /// </summary>
    public class LoginUserStatus
    {
        //登录是否成功
        public bool IsLogin { get; set; }
        //登录成功或失败的信息
        public string Message { get; set; }
        //登陆成功后跳转的控制器
        public string GotoController { get; set; }
        //登陆成功后跳转的信息
        public string GotoAction { get; set; }
    }


    /// <summary>
    /// 用于处理登录成功后的用户会话
    /// </summary>
    public class LoginUserSessionModel
    {
        public ApplicationUser User { get; set; }//账户对象
        public Person Person { get; set; }//个人信息的对象
        public string RoleName { get; set; }//用户角色

        //此外还可以定义其他业务对象：购物车、订单......
    }
}
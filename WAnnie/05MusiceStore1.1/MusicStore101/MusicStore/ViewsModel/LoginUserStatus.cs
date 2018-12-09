using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MusicStoreEntity.UserAndRole;

namespace MusicStore.ViewsModel
{
    /// <summary>
    /// 用户登录的状态
    /// </summary>
    public class LoginUserStatus
    {
        //登录是否成功
        public bool IsLogin { get; set; }
        //登录成功或失败的信息
        public string Message { get; set; }
        //登录成功后跳转的控制器
        public string GotoController { get; set; }
        //登录成功后跳转的方法
        public string GotoAction { get; set; }
    }

    public class LoginUserSessionModel
    {
        //账户对象
        public ApplicationUser User { get; set; }
        //个人新消息的对象
        public  Person Person { get; set; }
        //用户角色
        public string RoleName { get; set; }

    }
}
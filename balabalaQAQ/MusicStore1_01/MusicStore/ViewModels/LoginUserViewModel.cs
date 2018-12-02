using MusicStoreEntity.UserAndRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStore.ViewModels
{
    /// <summary>
    /// 用户登录时的状态
    /// </summary>
    public class LoginUserStatus
    {
        //是否登录成功
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
        public ApplicationUser User { get; set; }
        public Person Person{ get; set; }
        public string RoleName { get; set; }
    }

}
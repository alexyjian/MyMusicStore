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
        public bool IsLogin { get; set; }//登录是否成功

        public string Message { get; set; }//登录成功或失败的信息

        public string GotoController { get; set; }//登录成功后跳转到控制器

        public string GotoAction { get; set; }//登录成功后跳转的方法


    }
    /// <summary>
    /// 用于处理登录成功后的用户会话
    /// </summary>
    public class LoginUserSessionModel

    {
        public ApplicationUser User { get; set; }//账户对象

        public Person Person { get; set; }//个人信息的对象

        public string RoleName { get; set;}//用户角色
    }
}
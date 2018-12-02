using MusicStoreEntity.UserAndRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStore.ViewModels
{
    public class LoginUserStatus
    {
        /// <summary>
        /// 用户是否登录
        /// </summary>
        public bool IsLogin { get; set; }

        /// <summary>
        /// 登录失败或成功的信息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 登录成功后跳转的控制器
        /// </summary>
        public string GotoController { get; set; }

        /// <summary>
        /// 登录成功后跳转的方法
        /// </summary>
        public string GotoAction { get; set; }
    }

    /// <summary>
    /// 用于处理用户登录成功后的会话
    /// </summary>
    public class LoginUserSessionModel
    {
        public ApplicationUser User { get; set; }

        public Person Person { get; set; }

        public string RoleName { get; set; }
    }
}
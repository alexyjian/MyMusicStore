using MusicStoreEntity.UserAndRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStore.ViewMoldels
{
    /// <summary>
    /// 用户登录的状态
    /// </summary>
    public class LoginUserStatus
    {
        public bool IsLogin { get; set; }//登录是否成功
        public string Message { get; set; }//登录成功或失败的信息
        public string GotoController { get; set; }
        public string GotoAction { get; set; }
    }
    public class LoginUserSessionModel
    {
        public ApplicationUser User { get; set; }
        public Person Person { get; set; }
        public string RoleName { get; set; }
    }
}
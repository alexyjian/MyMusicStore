using MusicStoreEntity;
using MusicStoreEntity.UserAndRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStore.ViewModels
{
    public class LoginUserStatus
    {
        //登录是否成功
        public bool Islogin { get; set; }
        //登录成功的信息
        public string Message { get; set; }
        //登录成功后跳转的控制器
        public string GotoController { get; set; }
        //登录成功后跳转的方法
        public string GotoAction { get; set; }
    }
    public class LoginUserSessionModel
    {
        public ApplicationUser User { get; set; }//账号对象

        public Person Person { get; set; }//个人信息的对象

        public string RoleName { get; set; }

        public Album Album { get; set; }

    }
}
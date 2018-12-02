using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MusicStoreEntity.UserAndRole;

namespace Music.ViewModels
{
    public class LoginUserStatus
    {
        public bool IsLogin { get; set; } //登陆是否成功
        public string Message { get; set; }//登陆成功或失败的信息
        public string GotoController { get; set; }//登录后跳转的控制器
        public string GotoAction { get; set; }//登录成功后跳转的方法
    }
    public class LoginUserSessionModel
    {
        public ApplicationUser User { get; set; }//账户对象
        public Person Person { get; set; }//个人信息的对象
        public string  Rolename { get; set; }
        //此外还可以定义其他业务对象 购物车 订单。。。。
    }
}
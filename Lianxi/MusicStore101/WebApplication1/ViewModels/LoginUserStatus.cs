using MusicStoreEntity.UserAndRole;


namespace MusicStore.ViewModels
{
    /// <summary>
    /// 用户登录时的状态
    /// </summary>
    public class LoginUserStatus
    {
        //登录成否成功
        public bool IsLogin { get; set; }
        //登录成功或失败的信息
        public string Message { get; set; }
        //登录成功后跳转的控制器
        public string GotoController { get; set; }
        //登录成功后跳转的方法
        public string GotoAction { get; set; }
    }

    /// <summary>
    /// 用于处理登录成功后的用户会话
    /// </summary>
    public class LoginUserSessionModel
    {
        public ApplicationUser User { get; set; }   //账户对象
        public Person Person { get; set; }   //个人信息的对象

        public string RoleName { get; set; }  //用户角色

       
    }
}
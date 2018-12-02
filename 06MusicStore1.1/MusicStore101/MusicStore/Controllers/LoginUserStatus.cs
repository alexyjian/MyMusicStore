namespace MusicStore.Controllers
{
    internal class LoginUserStatus
    {
        public LoginUserStatus()
        {
        }

        public string GotoAction { get; internal set; }
        public string GotoController { get; internal set; }
        public bool IsLogin { get; set; }
        public string Message { get; set; }
    }
}
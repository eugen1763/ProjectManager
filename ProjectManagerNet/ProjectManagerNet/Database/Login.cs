using ProjectManagerNet.Helpers;

namespace ProjectManagerNet.Database
{
    public sealed class Login
    {
        #region Singleton

        private Login() { }

        private static Login _instance;
        public static Login Instance => _instance ?? (_instance = new Login());

        #endregion

        public string Username { get; set; }
        public string Password { get; set; }

        public void Prompt()
        {
            //var loginData = PromptHelper.Spawn("Login", "Username", "Password");
            //Username = loginData["Username"];
            //Password = loginData["Password"];
            Username = "testuser";
            Password = "testuser";
        }
    }
}
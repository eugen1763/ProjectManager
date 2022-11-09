using System.Threading.Tasks;
using ProjectManagerNet.Database;

namespace ProjectManagerNet
{
    public static class Services
    {
        public static DBManager DB => DBManager.Instance;
        public static Login Login => Login.Instance;

        public static async Task Init()
        {
            Login.Prompt();
            await DB.Init();
        }

        public static void Kill()
        {
            DB.Kill();
        }
    }
}
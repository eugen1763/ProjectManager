using System.Collections.Generic;

namespace ProjectManagerNet.Helpers
{
    public static class PromptHelper
    {
        public static Dictionary<string, string> Spawn(string title, params string[] fields)
        {
            var window = new PromptWindow(fields)
            {
                Title = title
            };
            window.ShowDialog();
            return window.Inputs;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace ProjectManagerNet
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Startup += OnStartup;
            Exit += OnExit;
            DispatcherUnhandledException += OnDispatcherUnhandledException;
        }

        private void OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            // TODO
        }

        private void OnExit(object sender, ExitEventArgs e)
        {
            Services.Kill();
        }
        
        private static async void OnStartup(object sender, StartupEventArgs e)
        {
           await Services.Init();
        }
    }
}

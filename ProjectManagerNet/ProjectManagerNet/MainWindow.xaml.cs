using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ProjectManagerNet.Database;

namespace ProjectManagerNet
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            Closed += OnClosed;

            var obj = new DBObject();
            DBObject.RetrieveAll();
        }

        private static void OnClosed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}

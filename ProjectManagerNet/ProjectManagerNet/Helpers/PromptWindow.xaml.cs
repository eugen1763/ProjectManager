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
using System.Windows.Shapes;

namespace ProjectManagerNet.Helpers
{
    /// <summary>
    /// Interaction logic for PromptWindow.xaml
    /// </summary>
    public partial class PromptWindow : Window
    {
        public Dictionary<string, string> Inputs { get; } = new Dictionary<string, string>();
     
        public PromptWindow(params string[] fields)
        {
            InitializeComponent();

            GenerateInputs(fields.ToList());
        }

        private void GenerateInputs(IList<string> fields)
        {
            MainGrid.RowDefinitions.Clear();
            MainGrid.ColumnDefinitions.Clear();
            MainWindow.Height = 50 + 25 * fields.Count;

            foreach (var _ in Enumerable.Repeat(0, 2))
                MainGrid.ColumnDefinitions.Add(new ColumnDefinition {Width = new GridLength(1, GridUnitType.Star)});

            foreach (var field in fields)
            {
                var i = fields.IndexOf(field);
                Inputs[field] = "";
                
                MainGrid.RowDefinitions.Add(new RowDefinition
                {
                    Height = GridLength.Auto,
                });

                var label = new Label
                {
                    Content = field,
                    VerticalAlignment = VerticalAlignment.Center,
                };
                var textBox = new TextBox
                {
                    Height = 25,
                    VerticalAlignment = VerticalAlignment.Center,
                };

                textBox.TextChanged += (sender, args) =>
                {
                    Inputs[field] = textBox.Text;
                };

                MainGrid.Children.Add(label);
                MainGrid.Children.Add(textBox);

                Grid.SetRow(label, i);
                Grid.SetRow(textBox, i);
                Grid.SetColumn(label, 0);
                Grid.SetColumn(textBox, 1);
            }
        }
    }
}   

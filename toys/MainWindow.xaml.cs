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

namespace toys
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public enum Type
    {
        Снеговик=1,Машинка=2,Звезда=4,Снежинка=8,Петля=16,Мыло=32,Стул=64
    }
    public partial class MainWindow : Window
    {
        private Toys toys;
        public MainWindow()
        {
            InitializeComponent();
            foreach (string str in Enum.GetNames(typeof(Type)))
            {
                CheckBox checkBox = new CheckBox
                {
                    Content = str,
                    MaxHeight = 30,
                    IsChecked = false,
                    Margin = new Thickness(10)
                };
                checkBox.Checked += checkBox_checked;
                Patterns.Children.Add(checkBox);
            }
        }
        private void checkBox_checked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            Type properties = (Type)Enum.Parse(typeof(Type),
                                        checkBox.Content.ToString());
            toys.Pattern = properties;
            Result.Text = "";
            foreach (string str in toys.NaborHavePet())
            {
                Result.Text += str + "\n";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Result.Text = "";
            int n = Convert.ToInt32(nBox.Text);
            toys = new Toys(n);
            toys.FormNabor();
            Type[] nabor = toys.GetNabor();
            for (int i = 0; i < Patterns.Children.Count; i++)
            {
                (Patterns.Children[i] as CheckBox).IsChecked = false;
            }
            string[] strNabor = toys.GetStrNabor();
            for (int i = 0; i < n; i++)
            {
                Result.Text += "Набор " + (i + 1) + "  \n";
                Result.Text += strNabor[i] + '\n';
            }
        }

        private void Result_Scroll(object sender, System.Windows.Controls.Primitives.ScrollEventArgs e)
        {

        }
    }
}

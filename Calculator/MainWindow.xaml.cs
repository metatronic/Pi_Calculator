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

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            txtDisplay.Text += b.Content.ToString();
        }

        private void Result_click(object sender, RoutedEventArgs e)
        {
            try
            {
                Result();
            }
            catch (Exception)
            {
                txtDisplay.Text = "Error!";
            }
        }

        private void Result()
        {
            string operation;
            int indexOperator = 0;
            if (txtDisplay.Text.Contains("+"))
            {
                indexOperator = txtDisplay.Text.IndexOf("+");
            }
            else if (txtDisplay.Text.Contains("-"))
            {
                indexOperator = txtDisplay.Text.IndexOf("-");
            }
            else if (txtDisplay.Text.Contains("*"))
            {
                indexOperator = txtDisplay.Text.IndexOf("*");
            }
            else if (txtDisplay.Text.Contains("/"))
            {
                indexOperator = txtDisplay.Text.IndexOf("/");
            }
            else
            {
                //error    
            }

            operation = txtDisplay.Text.Substring(indexOperator, 1);
            double op1 = Convert.ToDouble(txtDisplay.Text.Substring(0, indexOperator));
            double op2 = Convert.ToDouble(txtDisplay.Text.Substring(indexOperator + 1, txtDisplay.Text.Length - indexOperator - 1));

            if (operation == "+")
            {
                txtDisplay.Text += "=" + (op1 + op2);
            }
            else if (operation == "-")
            {
                txtDisplay.Text += "=" + (op1 - op2);
            }
            else if (operation == "*")
            {
                txtDisplay.Text += "=" + (op1 * op2);
            }
            else
            {
                txtDisplay.Text += "=" + (op1 / op2);
            }
        }

        private void Off_Click_1(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            txtDisplay.Text = "";
        }

        private void R_Click(object sender, RoutedEventArgs e)
        {
            if (txtDisplay.Text.Length > 0)
            {
                txtDisplay.Text = txtDisplay.Text.Substring(0, txtDisplay.Text.Length - 1);
            }
        }
    }
}
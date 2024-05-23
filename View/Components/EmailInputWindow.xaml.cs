using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PWR_VI_PodPro.View.Components
{
    /// <summary>
    /// Interaction logic for EmailInputWindow.xaml
    /// </summary>
    public partial class EmailInputWindow : Window
    {
        public string Email { get; set; }
        public bool Success { get; set; }

        public EmailInputWindow(string sayString)
        {
            InitializeComponent();
            WelcomeTb.Text = sayString;
        }

        private void ButtonOk_Click(object sender, RoutedEventArgs e)
        {
            Success = true;
            Email = emailInputTb.Text;

            Close();
        }

        private void emailInputTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            ButtonOk.IsEnabled = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$").IsMatch(emailInputTb.Text);
        }
    }
}

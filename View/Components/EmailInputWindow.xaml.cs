using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace PWR_VI_PodPro.View.Components
{
    public partial class EmailInputWindow : Window
    {
        public string Email { get; set; }
        public bool Success { get; set; }

        public EmailInputWindow(string sayString)
        {
            InitializeComponent();
            WelcomeTb.Text = sayString;
        }

        /// <summary>
        /// Funkcja zamykająca okno po naciśnięciu przycisku oraz zwracająca dane.
        /// </summary>
        private void ButtonOk_Click(object sender, RoutedEventArgs e)
        {
            Success = true;
            Email = emailInputTb.Text;

            Close();
        }

        /// <summary>
        /// Funkcja sprawdzająca poprawność wprowadzonego adresu email aktywowana podczas modyfikowania tesktu.
        /// </summary>
        private void emailInputTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            ButtonOk.IsEnabled = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$").IsMatch(emailInputTb.Text);
        }
    }
}

using System.Text.RegularExpressions;
using System.Windows;

namespace PWR_VI_PodPro.View.Components
{
    /// <summary>
    /// Interaction logic for PriceInput.xaml
    /// </summary>
    public partial class PriceInput : Window
    {
        public string price { get; set; }
        public bool Success { get; set; }

        public PriceInput()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Funkcja zamykająca okno po naciśnięciu przycisku oraz zwracająca dane.
        /// </summary>
        private void ButtonOk_Click(object sender, RoutedEventArgs e)
        {
            Success = true;
            price = priceInputTb.Text;

            Close();
        }

        /// <summary>
        /// Funkcja sprawdzająca poprawność wprowadzonej ceny aktywowana podczas modyfikowania tesktu.
        /// </summary>
        private void priceInputTb_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            ButtonOk.IsEnabled = new Regex("^[0-9]+[.][0-9]{2,}$").IsMatch(priceInputTb.Text);
        }


        /// <summary>
        /// Funkcja zamykająca okno po naciśnięciu przycisku.
        /// </summary>
        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

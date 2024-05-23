using System.Windows;
using System.Windows.Controls;

namespace PWR_VI_PodPro.View.Components
{
    /// <summary>
    /// Interaction logic for SearchBox.xaml
    /// </summary>
    public partial class SearchBox : UserControl
    {
        public SearchBox()
        {
            InitializeComponent();
        }

        private void SearchInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(String.IsNullOrEmpty(SearchInput.Text))
            {
                PlaceholderTb.Visibility = Visibility.Visible;
            }
            else
            {
                PlaceholderTb.Visibility = Visibility.Hidden;
            }
        }
    }
}

﻿using PWR_VI_PodPro.Core;
using PWR_VI_PodPro.Core.MongoDB.DB;
using System.Windows;

namespace PWR_VI_PodPro.View.Components
{
    /// <summary>
    /// Interaction logic for FilterWindow.xaml
    /// </summary>
    public partial class FilterWindow : Window
    {
        public FilterWindow()
        {
            InitializeComponent();
        }

        private void ButtonOk_Click(object sender, RoutedEventArgs e)
        {
            DB.AddFilter(new filterObj
            {
                filterName = FilterNameTb.Text,
                lowerPrice = PriceMinTb.Text,
                upperPrice = PriceMaxTb.Text,
                title = TitleTb.Text,
                AAA = (bool)AAA_Chkb.IsChecked ? "1" : "0",
                metacritic = minMetacriticTb.Text
            });

            Close();
        }

        private void PriceMinTb_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
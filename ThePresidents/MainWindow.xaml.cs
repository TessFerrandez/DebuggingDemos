using System;
using System.Windows;
using System.Windows.Controls;
using ThePresidents.Models;
using ThePresidents.ViewModels;

namespace ThePresidents
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PresidentListViewModel _viewModel = new PresidentListViewModel();

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = _viewModel;
        }

        private void presidentsList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var list = (sender as ListView);
            if(list.SelectedItem != null && list.SelectedItem is President)
            {
                _viewModel.PresidentToDisplay = list.SelectedItem as President;
            }
        }

        private void previousButton_Click(object sender, RoutedEventArgs e)
        {
            var prevPresident = _viewModel.GoToAnother(-1);
            presidentsList.SelectedItem = prevPresident;
        }
        private void nextButton_Click(object sender, RoutedEventArgs e)
        {
            var nextPresident = _viewModel.GoToAnother(1);
            presidentsList.SelectedItem = nextPresident;
        }

        private void ExButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                throw new Exception("Just throwing an exception for kicks");
            }
            catch { }
        }
    }
}

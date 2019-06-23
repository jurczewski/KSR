using System.Collections.Generic;
using System.Windows;
using ViewModel;

namespace Zad2
{
    public partial class MainWindow : Window
    {
        private readonly MainViewModel viewModel;
        private List<Player> players = new List<Player>();
        public MainWindow()
        {
            InitializeComponent();
            DataLoader.LoadDataFromCSV(ref players);
            //DataLoader.LoadDataFromDB(ref players);
            viewModel = new MainViewModel(players);
            DataContext = viewModel;
        }
    }
}

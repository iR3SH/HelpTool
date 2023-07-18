using HelpData.Classes.Login;
using HelpTool.Languages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace HelpTool.SubWindow.Viewer
{
    /// <summary>
    /// Interaction logic for PlayerList.xaml
    /// </summary>
    public partial class PlayerList : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private ObservableCollection<Players>? _Players { get; set; }
        public ObservableCollection<Players>? Players {  get { return _Players; } set { _Players = value; NotifyPropertyChanged(); } }
        public PlayerList()
        {
            InitializeComponent();
            DataContext = this;
            InitData();
        }
        private async void InitData()
        {
            Players = new(await SharedObjects.PlayersRepository!.GetAll());
        }
        private void French(object sender, RoutedEventArgs e)
        {
            LanguageSetter.SetLanguage(new CultureInfo("fr-FR"));
            EnglishButton.IsChecked = false;
            FrenchButton.IsChecked = true;
        }
        private void English(object sender, RoutedEventArgs e)
        {
            LanguageSetter.SetLanguage(new CultureInfo("en-US"));
            EnglishButton.IsChecked = true;
            FrenchButton.IsChecked = false;
        }

        private void FilterText_TextChanged(object sender, TextChangedEventArgs e)
        {
            ICollectionView collectionView = CollectionViewSource.GetDefaultView(PlayerDataGrid.ItemsSource);
            if (FilterTextBox.Text.Length > 0)
            {
                if (collectionView != null)
                {
                    collectionView.Filter = o =>
                    {
                        if (o is Players player)
                        {
                            if (player.Name!.ToUpper().StartsWith(FilterTextBox.Text.ToUpper()))
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            return false;
                        }
                    };
                }
            }
            else
            {
                collectionView.Filter = null;
            }
        }

        private void SeeInventory(object sender, RoutedEventArgs e)
        {
            try
            {
                if (PlayerDataGrid.SelectedItem is Players player)
                {
                    Inventory inventory = new(player);
                    inventory.ShowDialog();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

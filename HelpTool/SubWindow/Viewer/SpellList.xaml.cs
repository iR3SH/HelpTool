using HelpData.Classes.Game;
using HelpData.Classes.Login;
using HelpTool.Languages;
using HelpTool.SubWindow.Spells;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace HelpTool.SubWindow.Viewer
{
    /// <summary>
    /// Interaction logic for SpellList.xaml
    /// </summary>
    public partial class SpellList : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private ObservableCollection<Sorts>? _Spells { get; set; }
        public ObservableCollection<Sorts>? Spells { get { return _Spells; } set { _Spells = value; NotifyPropertyChanged(); } }
        public SpellList()
        {
            InitializeComponent();
            DataContext = this;
            InitData();
        }
        private async void InitData()
        {
            Spells = new(await SharedObjects.SortsRepository!.GetAll());
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
            ICollectionView collectionView = CollectionViewSource.GetDefaultView(SpellDataGrid.ItemsSource);
            if (FilterTextBox.Text.Length > 0)
            {
                if (collectionView != null)
                {
                    collectionView.Filter = o =>
                    {
                        if (o is Sorts sort)
                        {
                            if (sort.Nom!.ToUpper().StartsWith(FilterTextBox.Text.ToUpper()))
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

        private void EditSpell(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SpellDataGrid.SelectedItem is Sorts spell)
                {
                    SpellCreator spellCreator = new(spell);
                    spellCreator.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

using HelpData.Classes.Game;
using HelpData.Classes.Login;
using HelpTool.Languages;
using HelpTool.SubWindow.Items;
using Org.BouncyCastle.Ocsp;
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
    /// Interaction logic for MonsterList.xaml
    /// </summary>
    public partial class MonsterList : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private ObservableCollection<HelpData.Classes.Game.Monsters>? _Monsters { get; set; }
        public ObservableCollection<HelpData.Classes.Game.Monsters>? Monsters { get { return _Monsters; } set { _Monsters = value; NotifyPropertyChanged(); } }
        public MonsterList()
        {
            InitializeComponent();
            DataContext = this;
            InitData();
        }
        private async void InitData()
        {
            Monsters = new(await SharedObjects.MonstersRepository!.GetAll());
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
            ICollectionView collectionView = CollectionViewSource.GetDefaultView(MonsterDataGrid.ItemsSource);
            if (FilterTextBox.Text.Length > 0)
            {
                if (collectionView != null)
                {
                    collectionView.Filter = o =>
                    {
                        if (o is HelpData.Classes.Game.Monsters monster)
                        {
                            if (monster.Name!.ToUpper().StartsWith(FilterTextBox.Text.ToUpper()))
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
        private void EditMonster(object sender, RoutedEventArgs e)
        {
            if(MonsterDataGrid.SelectedItem is HelpData.Classes.Game.Monsters monster)
            {
                MonsterCreator monsterCreator = new(monster);
                monsterCreator.ShowDialog();
            }
        }
    }
}

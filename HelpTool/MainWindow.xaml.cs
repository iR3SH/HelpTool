using HelpData.Classes.Game;
using HelpTool.Classes;
using HelpTool.SubWindow;
using HelpTool.SubWindow.Items;
using HelpTool.SubWindow.Spells;
using HelpTool.SubWindow.Viewer;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Documents;

namespace HelpTool
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void ButtonConfig_Click(object sender, RoutedEventArgs e)
        {
            Configuration config = new();
            config.ShowDialog();
        }

        private void ButtonItem_Click(object sender, RoutedEventArgs e)
        {
            if (SharedObjects.IsConfigured == true)
            {
                ItemCreator itemCreator = new();
                itemCreator.ShowDialog();
            }
            else
            {
                MessageBox.Show(Functions.Word("NotConfigured"), Functions.Word("Error"), MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void Monster_Click(object sender, RoutedEventArgs e)
        {
            if (SharedObjects.IsConfigured == true)
            {
                MonsterCreator monsterCreator = new();
                monsterCreator.ShowDialog();
            }
            else
            {
                MessageBox.Show(Functions.Word("NotConfigured"), Functions.Word("Error"), MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ButtonSpell_Click(object sender, RoutedEventArgs e)
        {
            if(SharedObjects.IsConfigured == true)
            {
                SpellCreator spellCreator = new();
                spellCreator.ShowDialog();
            }
            else
            {
                MessageBox.Show(Functions.Word("NotConfigured"), Functions.Word("Error"), MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void ButtonPlayer_Click(object sender, RoutedEventArgs e)
        {
            if (SharedObjects.IsConfigured == true)
            {
                PlayerList playerList = new();
                playerList.ShowDialog();
            }
            else
            {
                MessageBox.Show(Functions.Word("NotConfigured"), Functions.Word("Error"), MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void ButtonEditMonster_Click(object sender, RoutedEventArgs e)
        {
            if (SharedObjects.IsConfigured == true)
            {
                MonsterList monsterList = new();
                monsterList.ShowDialog();
            }
            else
            {
                MessageBox.Show(Functions.Word("NotConfigured"), Functions.Word("Error"), MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void ButtonEditSpell_Click(object sender, RoutedEventArgs e)
        {
            if (SharedObjects.IsConfigured == true)
            {
                SpellList spellList = new();
                spellList.ShowDialog();
            }
            else
            {
                MessageBox.Show(Functions.Word("NotConfigured"), Functions.Word("Error"), MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

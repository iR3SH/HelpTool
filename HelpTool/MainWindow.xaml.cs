using HelpTool.Classes;
using HelpTool.SubWindow;
using HelpTool.SubWindow.Items;
using HelpTool.SubWindow.Spells;
using System.Windows;

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
    }
}

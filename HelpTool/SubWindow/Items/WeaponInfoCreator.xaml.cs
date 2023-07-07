using HelpTool.Classes;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace HelpTool.SubWindow.Items
{
    /// <summary>
    /// Interaction logic for WeaponInfoCreator.xaml
    /// </summary>
    public partial class WeaponInfoCreator : Window
    {
        public WeaponInfoCreator()
        {
            InitializeComponent();
        }

        private void PaCostTextbox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = Functions.NumRegex();
            e.Handled = regex.IsMatch(e.Text);
        }

        private void GenerateButton_Click(object sender, RoutedEventArgs e)
        {
            if(PaCostTextbox.Text.Length > 0 && CCBonusTextBox.Text.Length > 0 && PoMinTextBox.Text.Length > 0 && PoMaxTextBox.Text.Length > 0 && CCTextBox.Text.Length > 0 && ECTextBox.Text.Length > 0)
            {
                ResultTextBox.Text = PaCostTextbox.Text + ";" + PoMinTextBox.Text + ";" + PoMaxTextBox.Text + ";" + CCTextBox.Text + ";" + ECTextBox.Text + ";" + CCBonusTextBox.Text + ";";
                ResultTextBox.Text += ArmesCheckBox.IsChecked == true ? "1" : "0";
            }
        }
    }
}

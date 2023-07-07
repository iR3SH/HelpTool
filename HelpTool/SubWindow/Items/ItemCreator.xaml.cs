using HelpData.Classes.Game;
using HelpData.Classes.Items;
using HelpTool.Classes;
using HelpTool.Languages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;

namespace HelpTool.SubWindow.Items
{
    /// <summary>
    /// Interaction logic for ItemCreator.xaml
    /// </summary>
    public partial class ItemCreator : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private List<ItemsType>? _ItemsTypes { get; set; }
        public List<ItemsType>? ItemsTypes { get { return _ItemsTypes; } set { _ItemsTypes = value; NotifyPropertyChanged(); } }
        public ItemCreator()
        {
            InitializeComponent();
            DataContext = this;
            ItemsTypes = Functions.GetItemsTypes();
            if(SharedObjects.SelectedCulture!.Name == "en-US")
            {
                EnglishButton.IsChecked = true;
                FrenchButton.IsChecked = false;
            }
            else
            {
                EnglishButton.IsChecked = false;
                FrenchButton.IsChecked = true;
            }
        }

        private void StatsGeneratorButton_Click(object sender, RoutedEventArgs e)
        {

            ItemsType? selectedType = TypeComboBox.SelectedItem as ItemsType;
            if (Functions.IsWeapon(selectedType!))
            {
                Jet jet = new(true, null);
                jet.Show();
            }
            else
            {
                Jet jet = new(false, null);
                jet.Show();
            }
        }

        private void ArmesInfosButton_Click(object sender, RoutedEventArgs e)
        {
            WeaponInfoCreator creator = new();
            creator.Show();
        }

        private void IdTextBox_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            Regex regex = Functions.NumRegex();
            e.Handled = regex.IsMatch(e.Text);
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

        private async void CreateItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (IdTextBox.Text.Length > 0 && TypeComboBox.SelectedIndex != -1 && NameTextBox.Text.Length > 0 && LevelTextBox.Text.Length > 0 && StatsTextBox.Text.Length > 0 && PodsTextBox.Text.Length > 0 && PanoTextBox.Text.Length > 0
                    && PriceTextBox.Text.Length > 0 && SoldTextBox.Text.Length > 0 && AvgPriceTextBox.Text.Length > 0 && PointsTextBox.Text.Length > 0 && ExchangesObjectTextBox.Text.Length > 0 && NewPriceTextBox.Text.Length > 0)
                {
                    ItemTemplate newItem = new()
                    {
                        Id = Convert.ToInt32(IdTextBox.Text),
                        Type = ((ItemsType)TypeComboBox.SelectedValue).Id,
                        Name = NameTextBox.Text,
                        Level = Convert.ToInt32(LevelTextBox.Text),
                        StatsTemplate = StatsTextBox.Text,
                        Pod = Convert.ToInt32(PodsTextBox.Text),
                        Panoplie = Convert.ToInt32(PanoTextBox.Text),
                        Prix = Convert.ToInt32(PriceTextBox.Text),
                        Conditions = ConditionTextBox.Text,
                        ArmesInfos = ArmeTextBox.Text,
                        Sold = Convert.ToInt32(SoldTextBox.Text),
                        AvgPrice = Convert.ToInt32(AvgPriceTextBox.Text),
                        Points = Convert.ToInt32(PointsTextBox.Text),
                        ExchangesObject = Convert.ToInt32(ExchangesObjectTextBox.Text),
                        NewPrice = Convert.ToInt32(NewPriceTextBox.Text)
                    };
                    await SharedObjects.ItemsRepository!.Create(newItem);
                    StringBuilder swfString = new();
                    swfString.Append("I.u["+ newItem.Id +"] = {n:\""+ newItem.Name + "\", t:" + newItem.Type + ", d:\"" + DescriptionTextBox.Text + "\", w: "+ newItem.Pod +", g:" + GfxTextBox.Text + ", l:" + newItem.Level + ", wd:true, fm:true, ep:1");
                    if (newItem.Panoplie > 0)
                    {
                        swfString.Append(", s:" + newItem.Panoplie);
                    }
                    if(Functions.IsWeapon((ItemsType) TypeComboBox.SelectedValue))
                    {
                        string PaCost = newItem.ArmesInfos.Split(';')[0];
                        string PoMin = newItem.ArmesInfos.Split(';')[1];
                        string PoMax = newItem.ArmesInfos.Split(';')[2];
                        string CCBonus = newItem.ArmesInfos.Split(';')[5];
                        string CC = newItem.ArmesInfos.Split(';')[3];
                        string EC = newItem.ArmesInfos.Split(';')[4];
                        string isTwohandWeapon = newItem.ArmesInfos.Split(';')[6] == "0" ? "false" : "true";
                        swfString.Append(", e:[" + CCBonus + ", " + PaCost + ", " + PoMin + ", " + PoMax + ", " + CC + ", " + EC + ", false, " + isTwohandWeapon + "]");
                    }
                    if(!string.IsNullOrEmpty(newItem.Conditions))
                    {
                        swfString.Append(", c: \"" + newItem.Conditions + "\"");
                    }
                    swfString.Append(", p: " + newItem.Prix + "};");
                    string finalSwf = swfString.ToString().Replace("\'", "\\\'");
                    SWFGenerateTextBlock.Text += finalSwf;
                    if (SWFGenerateTextBlock.Text.Length > 0)
                    {
                        SWFGenerateTextBlock.Text += Environment.NewLine;
                    }
                    else
                    {
                        SWFGenerateTextBlock.Text += "";
                    }

                }
            }
            catch (Exception)
            {
                MessageBox.Show(Functions.Word("ItemCreateError"), Functions.Word("Error"), MessageBoxButton.OK, MessageBoxImage.Error);
            };
        }
    }
}

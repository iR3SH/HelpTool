using HelpData.Classes.Spells;
using HelpTool.Classes;
using HelpTool.Languages;
using Org.BouncyCastle.Bcpg.OpenPgp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HelpTool.SubWindow.Spells
{
    /// <summary>
    /// Interaction logic for SpellCreator.xaml
    /// </summary>
    public partial class SpellCreator : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private ObservableCollection<Effects>? _Effects { get; set; } 
        public ObservableCollection<Effects>? Effects { get { return _Effects; } set { _Effects = value; NotifyPropertyChanged(); } }
        private ObservableCollection<Effects>? _EffectCC { get; set; }
        public ObservableCollection<Effects>? EffectsCC { get { return _EffectCC; } set { _EffectCC = value; NotifyPropertyChanged(); } }
        private ObservableCollection<SelectedEffects>? _SelectedEffects { get; set; }
        public ObservableCollection<SelectedEffects>? SelectedEffects { get { return _SelectedEffects; } set { _SelectedEffects = value; NotifyPropertyChanged(); } }
        private ObservableCollection<SelectedEffects>? _SelectedEffectCC { get; set; }
        public ObservableCollection<SelectedEffects>? SelectedEffectsCC { get { return _SelectedEffectCC; } set { _SelectedEffectCC = value; NotifyPropertyChanged(); } }
        private ObservableCollection<SpellsEffects>? _Levels { get; set; }
        public ObservableCollection<SpellsEffects>? Levels { get { return _Levels; } set { _Levels = value; NotifyPropertyChanged(); } }
        private ObservableCollection<States>? _States { get; set; }
        public ObservableCollection<States>? States { get { return _States; } set { _States = value; NotifyPropertyChanged(); } }
        private ObservableCollection<Zones>? _Zones { get; set; }
        public ObservableCollection<Zones>? Zones { get { return _Zones; } set { _Zones = value; NotifyPropertyChanged(); } }
        private ObservableCollection<HelpData.Classes.Spells.Colors>? _Colors { get; set; }
        public ObservableCollection<HelpData.Classes.Spells.Colors>? Colors { get { return _Colors; } set { _Colors = value; NotifyPropertyChanged(); } }
        private ObservableCollection<SpellTypes>? _SpellTypes { get; set; }
        public ObservableCollection<SpellTypes>? SpellTypes { get { return _SpellTypes; } set { _SpellTypes = value; NotifyPropertyChanged(); } }

        public SpellCreator()
        {
            InitializeComponent();
            DataContext = this;
            InitData();
            SelectedEffects = new();
            SelectedEffectsCC = new();
            Levels = new();
        }
        private void InitData()
        {
            Effects = new(Functions.GenerateAllPossibleSpellEffect());
            EffectsCC = new(Functions.GenerateAllPossibleSpellEffect());
            States = new(Functions.GetAllStates());
            Zones = new(Functions.GetZones());
            Colors = new(Functions.GetGlypheColors());
            SpellTypes = new(Functions.GetSpellTypes());
        }
        private void CheckIntValue(object sender, TextCompositionEventArgs e)
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

        private void ResetEffectValues()
        {
            EffectsComboBox.SelectedIndex = 0;
            DamageMin.Text = "-1";
            DamageMax.Text = "-1";
            DureeEffectTextBox.Text = "0";
            ReuEffectTextBox.Text = "0";
            ZoneComboBox.SelectedIndex = 0;
            ZoneSizeTextBox.Text = "0";
        }
        private void ResetEffectCCValues()
        {
            EffectsCCComboBox.SelectedIndex = 0;
            DamageMinCC.Text = "-1";
            DamageMaxCC.Text = "-1";
            DureeEffectCCTextBox.Text = "0";
            ReuEffectCCTextBox.Text = "0";
            ZoneCCComboBox.SelectedIndex = 0;
            ZoneSizeCCTextBox.Text = "0";
        }

        private void AddEffect_Click(object sender, RoutedEventArgs e)
        {
            if (EffectsComboBox.SelectedIndex > -1 && !string.IsNullOrEmpty(DamageMin.Text) && !string.IsNullOrEmpty(DamageMax.Text) && !string.IsNullOrEmpty(DureeEffectTextBox.Text) && !string.IsNullOrEmpty(ReuEffectTextBox.Text) && ZoneComboBox.SelectedIndex > -1 && !string.IsNullOrEmpty(ZoneSizeTextBox.Text))
            {
                if (EffectsComboBox.SelectedItem is Effects effect)
                {
                    if (SelectedEffects != null)
                    {
                        if (!SelectedEffects.Any(c => c.Effect!.EffectId == effect.EffectId))
                        {
                            if (ZoneComboBox.SelectedItem is Zones zone)
                            {
                                if (GlypheColorCCComboBox.SelectedItem is HelpData.Classes.Spells.Colors color)
                                {
                                    SelectedEffects selectedEffects = new()
                                    {
                                        Effect = effect,
                                        DamageMin = Convert.ToInt32(DamageMin.Text),
                                        DamageMax = Convert.ToInt32(DamageMax.Text),
                                        GlypheColor = color.Id,
                                        SpellDuration = Convert.ToInt32(DureeEffectTextBox.Text),
                                        Probability = Convert.ToInt32(ReuEffectTextBox.Text),
                                        Zone = zone.ZoneCode + Functions.GetIntByHashedValue(Convert.ToInt32(ZoneSizeTextBox.Text)),
                                        DisplayName = effect.Name,
                                        IconPath = effect.ImagePath
                                    };
                                    selectedEffects.DisplayName = selectedEffects.DisplayName?.Replace("Min", DamageMin.Text).Replace("Max", DamageMax.Text).Replace("#3", DamageMax.Text);
                                    SelectedEffects.Add(selectedEffects);
                                    ResetEffectValues();
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Vous avez déjà ajouté cet effet au sort.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
            }
        }

        private void AddEffectCC_Click(object sender, RoutedEventArgs e)
        {
            if(EffectsCCComboBox.SelectedIndex > -1 && !string.IsNullOrEmpty(DamageMinCC.Text) && !string.IsNullOrEmpty(DamageMaxCC.Text) && !string.IsNullOrEmpty(DureeEffectCCTextBox.Text) && !string.IsNullOrEmpty(ReuEffectCCTextBox.Text) && ZoneCCComboBox.SelectedIndex > -1 && !string.IsNullOrEmpty(ZoneSizeCCTextBox.Text))
            {
                if (EffectsCCComboBox.SelectedItem is Effects effect)
                {
                    if (SelectedEffectsCC != null)
                    {
                        if (!SelectedEffectsCC.Any(c => c.Effect!.EffectId == effect.EffectId))
                        {
                            if (ZoneCCComboBox.SelectedItem is Zones zone)
                            {
                                if (GlypheColorCCComboBox.SelectedItem is HelpData.Classes.Spells.Colors color)
                                {
                                    SelectedEffects selectedEffects = new()
                                    {
                                        Effect = effect,
                                        DamageMin = Convert.ToInt32(DamageMinCC.Text),
                                        DamageMax = Convert.ToInt32(DamageMaxCC.Text),
                                        GlypheColor = color.Id,
                                        SpellDuration = Convert.ToInt32(DureeEffectCCTextBox.Text),
                                        Probability = Convert.ToInt32(ReuEffectCCTextBox.Text),
                                        Zone = zone.ZoneCode + Functions.GetIntByHashedValue(Convert.ToInt32(ZoneSizeCCTextBox.Text)),
                                        DisplayName = effect.Name,
                                        IconPath = effect.ImagePath
                                    };
                                    selectedEffects.DisplayName = selectedEffects.DisplayName?.Replace("Min", DamageMinCC.Text).Replace("Max", DamageMaxCC.Text).Replace("#3", DamageMax.Text);
                                    SelectedEffectsCC.Add(selectedEffects);
                                    ResetEffectCCValues();
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Vous avez déjà ajouté cet effet au sort.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
            }
        }

        private void ZoneComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(ZoneComboBox.SelectedIndex == 0)
            {
                ZoneSizeTextBox.Text = "0";
            }
            else
            {
                ZoneSizeTextBox.Text = "1";
            }
        }

        private void ZoneCCComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ZoneCCComboBox.SelectedIndex == 0)
            {
                ZoneSizeCCTextBox.Text = "0";
            }
            else
            {
                ZoneSizeCCTextBox.Text = "1";
            }
        }

        private void DeleteSelectedEffect(object sender, RoutedEventArgs e)
        {
            if (SelectedEffectListBox.SelectedItem is SelectedEffects selectedEffect)
            {
                SelectedEffects?.Remove(selectedEffect);
            }
        }
        private void DeleteSelectedEffectCC(object sender, RoutedEventArgs e)
        {
            if (SelectedEffectCCListBox.SelectedItem is SelectedEffects selectedEffect)
            {
                SelectedEffectsCC?.Remove(selectedEffect);
            }
        }

        private void EffectsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(EffectsComboBox.SelectedItem is Effects effect)
            {
                if(Functions.IsSummonEffect(effect))
                {
                    DoMinLabel.Content = "Id Invocation";
                    DoMaxLabel.Content = "Grade";
                    DamageMin.Text = "-1";
                    DamageMin.IsReadOnly = false;
                    DamageMax.Text = "-1";
                    DamageMax.IsReadOnly = false;
                    GlypheColorLabel.Visibility = Visibility.Hidden;
                    GlypheColorComboBox.Visibility = Visibility.Hidden;
                    GlypheColorComboBox.SelectedIndex = 0;
                }
                else if(Functions.IsGlypheEffect(effect))
                {
                    DoMinLabel.Content = "Id Effet Glyphe";
                    DoMaxLabel.Content = "Grade";
                    DamageMin.Text = "-1";
                    DamageMin.IsReadOnly = false;
                    DamageMax.Text = "-1";
                    DamageMax.IsReadOnly = false;
                    GlypheColorLabel.Visibility = Visibility.Visible;
                    GlypheColorComboBox.Visibility = Visibility.Visible;
                    GlypheColorComboBox.SelectedIndex = 0;
                }
                else if(Functions.IsTrapEffect(effect))
                {
                    DoMinLabel.Content = "Id Effet Piège";
                    DoMaxLabel.Content = "Grade";
                    DamageMin.Text = "-1";
                    DamageMin.IsReadOnly = false;
                    DamageMax.Text = "-1";
                    DamageMax.IsReadOnly = false;
                    GlypheColorLabel.Visibility = Visibility.Visible;
                    GlypheColorComboBox.Visibility = Visibility.Visible;
                    GlypheColorComboBox.SelectedIndex = 0;
                }
                else if(Functions.IsEffectWithOnlyOneArgs(effect))
                {
                    DoMinLabel.Content = "Distance d'Effet";
                    DoMaxLabel.Content = "Aucun";
                    DamageMin.Text = "0";
                    DamageMin.IsReadOnly = false;
                    DamageMax.Text = "-1";
                    DamageMax.IsReadOnly = true;
                    GlypheColorLabel.Visibility = Visibility.Hidden;
                    GlypheColorComboBox.Visibility = Visibility.Hidden;
                    GlypheColorComboBox.SelectedIndex = 0;
                }
                else if(Functions.IsSpecialEffectWithoutArgs(effect))
                {
                    DoMinLabel.Content = "Aucun";
                    DoMaxLabel.Content = "Aucun";
                    DamageMin.Text = "-1";
                    DamageMin.IsReadOnly = true;
                    DamageMax.Text = "-1";
                    DamageMax.IsReadOnly = true;
                    GlypheColorLabel.Visibility = Visibility.Hidden;
                    GlypheColorComboBox.Visibility = Visibility.Hidden;
                    GlypheColorComboBox.SelectedIndex = 0;
                }
                else
                {
                    DoMinLabel.Content = "Dommages Min";
                    DoMaxLabel.Content = "Dommages Max";
                    DamageMin.Text = "-1";
                    DamageMin.IsReadOnly = false;
                    DamageMax.Text = "-1";
                    DamageMax.IsReadOnly = false;
                    GlypheColorLabel.Visibility = Visibility.Hidden;
                    GlypheColorComboBox.Visibility = Visibility.Hidden;
                    GlypheColorComboBox.SelectedIndex = 0;
                }
            }
        }

        private void EffectsCCComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (EffectsCCComboBox.SelectedItem is Effects effect)
            {
                if (Functions.IsSummonEffect(effect))
                {
                    DoMinCCLabel.Content = "Id Invocation";
                    DoMaxCCLabel.Content = "Grade";
                    DamageMinCC.Text = "-1";
                    DamageMinCC.IsReadOnly = false;
                    DamageMaxCC.Text = "-1";
                    DamageMaxCC.IsReadOnly = false;
                }
                else if (Functions.IsGlypheEffect(effect))
                {
                    DoMinCCLabel.Content = "Id Effet Glyphe";
                    DoMaxCCLabel.Content = "Grade";
                    DamageMinCC.Text = "-1";
                    DamageMinCC.IsReadOnly = false;
                    DamageMaxCC.Text = "-1";
                    DamageMaxCC.IsReadOnly = false;
                }
                else if (Functions.IsTrapEffect(effect))
                {
                    DoMinCCLabel.Content = "Id Effet Piège";
                    DoMaxCCLabel.Content = "Grade";
                    DamageMinCC.Text = "-1";
                    DamageMinCC.IsReadOnly = false;
                    DamageMaxCC.Text = "-1";
                    DamageMaxCC.IsReadOnly = false;
                }
                else if (Functions.IsEffectWithOnlyOneArgs(effect))
                {
                    DoMinCCLabel.Content = "Distance d'Effet";
                    DoMaxCCLabel.Content = "Aucun";
                    DamageMinCC.Text = "0";
                    DamageMinCC.IsReadOnly = false;
                    DamageMaxCC.Text = "-1";
                    DamageMaxCC.IsReadOnly = true;
                }
                else if (Functions.IsSpecialEffectWithoutArgs(effect))
                {
                    DoMinCCLabel.Content = "Aucun";
                    DoMaxCCLabel.Content = "Aucun";
                    DamageMinCC.Text = "-1";
                    DamageMinCC.IsReadOnly = true;
                    DamageMaxCC.Text = "-1";
                    DamageMaxCC.IsReadOnly = true;
                }
                else
                {
                    DoMinCCLabel.Content = "Dommages Min";
                    DoMaxCCLabel.Content = "Dommages Max";
                    DamageMinCC.Text = "-1";
                    DamageMinCC.IsReadOnly = false;
                    DamageMaxCC.Text = "-1";
                    DamageMaxCC.IsReadOnly = false;
                }
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            string message = "10 / 12 = Effet sur sois (ex : Poing Enflammé)\r\n11 = Effet sur la cible (ex: Flèche Persécutrice)\r\n20 / 21 = Effect Ciblé (ex: Flèche Absorbante)\r\n30 / 31 = Lancer un objet vers (ex: Attaque Naturelle)\r\n40 / 41 = Anime l'effet jusque la cible (ex : Epée de Iop)\r\n50 / 51 = Projection de l'animation vers la cible (ex : Pandatak)";
            MessageBox.Show(message, "Information", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void AddNewSpellLevelButton_Click(object sender, RoutedEventArgs e)
        {
            if (Levels != null)
            {
                if (Levels.Count < 6)
                {
                    if (IdTextBox.Text.Length > 0)
                    {
                        if (PaTextbox.Text.Length > 0 && PoMinTextBox.Text.Length > 0 && PoMaxTextBox.Text.Length > 0 && CCTextBox.Text.Length > 0 && ECTextBox.Text.Length > 0 && LaunchPerTurn.Text.Length > 0 && LaunchPerTurnPerPlayer.Text.Length > 0 && TurnBetweenTwoLaunch.Text.Length > 0)
                        {
                            string effect = "";
                            string effectCC = "";
                            string zone = "";
                            if (SelectedEffects != null)
                            {
                                if (SelectedEffects.Count > 0)
                                {
                                    for (int i = 0; i < SelectedEffects.Count; i++)
                                    {
                                        zone += SelectedEffects[i].Zone;
                                        if (i != SelectedEffects.Count - 1)
                                        {
                                            effect += SelectedEffects[i].Effect?.EffectId + ";" + SelectedEffects[i].DamageMin + ";" + SelectedEffects[i].DamageMax + ";" + SelectedEffects[i].GlypheColor + ";" + SelectedEffects[i].SpellDuration + ";" + SelectedEffects[i].Probability + ";" + Functions.CalcJetD(SelectedEffects[i].DamageMin, SelectedEffects[i].DamageMax) + "|";
                                        }
                                        else
                                        {
                                            effect += SelectedEffects[i].Effect?.EffectId + ";" + SelectedEffects[i].DamageMin + ";" + SelectedEffects[i].DamageMax + ";" + SelectedEffects[i].GlypheColor + ";" + SelectedEffects[i].SpellDuration + ";" + SelectedEffects[i].Probability + ";" + Functions.CalcJetD(SelectedEffects[i].DamageMin, SelectedEffects[i].DamageMax);
                                        }
                                    }
                                }
                            }
                            if (SelectedEffectsCC != null)
                            {
                                if (SelectedEffectsCC.Count > 0)
                                {
                                    effectCC += ",";
                                    for (int i = 0; i < SelectedEffectsCC.Count; i++)
                                    {
                                        zone += SelectedEffectsCC[i].Zone;
                                        if (i != SelectedEffectsCC.Count - 1)
                                        {
                                            effectCC += SelectedEffectsCC[i].Effect?.EffectId + ";" + SelectedEffectsCC[i].DamageMin + ";" + SelectedEffectsCC[i].DamageMax + ";" + SelectedEffectsCC[i].GlypheColor + ";" + SelectedEffectsCC[i].SpellDuration + ";" + SelectedEffectsCC[i].Probability + ";" + Functions.CalcJetD(SelectedEffectsCC[i].DamageMin, SelectedEffectsCC[i].DamageMax) + "|";
                                        }
                                        else
                                        {
                                            effectCC += SelectedEffectsCC[i].Effect?.EffectId + ";" + SelectedEffectsCC[i].DamageMin + ";" + SelectedEffectsCC[i].DamageMax + ";" + SelectedEffectsCC[i].GlypheColor + ";" + SelectedEffectsCC[i].SpellDuration + ";" + SelectedEffectsCC[i].Probability + ";" + Functions.CalcJetD(SelectedEffectsCC[i].DamageMin, SelectedEffectsCC[i].DamageMax);
                                        }
                                    }
                                }
                            }
                            if (SpellType.SelectedItem is SpellTypes spellType)
                            {
                                if (StateComboBox.SelectedItem is States state)
                                {
                                    SpellsEffects spellEffect = new()
                                    {
                                        SpellEffectLevel = Levels!.Count + 1,
                                        SpellId = Convert.ToInt32(IdTextBox.Text),
                                        Effect = effect,
                                        EffectCC = effectCC,
                                        PaCost = Convert.ToInt32(PaTextbox.Text),
                                        PoMin = Convert.ToInt32(PoMinTextBox.Text),
                                        PoMax = Convert.ToInt32(PoMaxTextBox.Text),
                                        CC = Convert.ToInt32(CCTextBox.Text),
                                        EC = Convert.ToInt32(ECTextBox.Text),
                                        Zone = zone,
                                        IsInlineLaunch = InlineLaunch.IsChecked == true,
                                        IsWithoutLdv = LDV.IsChecked == true,
                                        IsEmptycell = EmptyCell.IsChecked == true,
                                        IsPoEditable = PoModifiable.IsChecked == true,
                                        IsEcFinishTurn = EcFinishTurn.IsChecked == true,
                                        SpellType = spellType.Id,
                                        RequireState = state.Id,
                                        LaunchPerTurn = Convert.ToInt32(LaunchPerTurn.Text),
                                        LaunchPerTurnPerPlayer = Convert.ToInt32(LaunchPerTurnPerPlayer.Text),
                                        TurnBetweenTwoLaunch = Convert.ToInt32(TurnBetweenTwoLaunch.Text)
                                    };
                                    Levels?.Add(spellEffect);
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Vous devez saisir l'id du Spell pour créer un niveau de sort", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }
    }
}

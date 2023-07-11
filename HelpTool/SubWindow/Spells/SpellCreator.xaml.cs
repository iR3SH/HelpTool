using HelpData.Classes.Game;
using HelpData.Classes.Spells;
using HelpTool.Classes;
using HelpTool.Languages;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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
        private ObservableCollection<Colors>? _Colors { get; set; }
        public ObservableCollection<Colors>? Colors { get { return _Colors; } set { _Colors = value; NotifyPropertyChanged(); } }
        private ObservableCollection<SpellTypes>? _SpellTypes { get; set; }
        public ObservableCollection<SpellTypes>? SpellTypes { get { return _SpellTypes; } set { _SpellTypes = value; NotifyPropertyChanged(); } }
        private ObservableCollection<EffectsTarget>? _EffectsTargets { get; set; }
        public ObservableCollection<EffectsTarget>? EffectsTargets { get { return _EffectsTargets; } set { _EffectsTargets = value; NotifyPropertyChanged(); } }
        private SpellsEffects? CurrentEditedEffect { get; set; }

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
            EffectsTargets = new(Functions.GetEffectsTargets());
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
        private void ResetOtherValues()
        {
            IdTextBox.Text = "0";
            NameTextBox.Text = "";
            SpriteTextBox.Text = "0";
            SpriteInfosTextbox.Text = "0,0,0";
            LevelListBox.Items.Clear();
            PaTextbox.Text = "0";
            PoMinTextBox.Text = "0";
            PoMaxTextBox.Text = "0";
            CCTextBox.Text = "0";
            ECTextBox.Text = "0";
            InlineLaunch.IsChecked = false;
            LDV.IsChecked = false;
            EmptyCell.IsChecked = false;
            PoModifiable.IsChecked = false;
            EcFinishTurn.IsChecked = false;
            SpellType.SelectedIndex = 0;
            LaunchPerTurn.Text = "0";
            LaunchPerTurnPerPlayer.Text = "0";
            TurnBetweenTwoLaunch.Text = "0";
            StateComboBox.SelectedIndex = 0;
            RequiredLevelTextBox.Text = "0";
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
            EffectTargetComboBox.SelectedIndex = 0;
;        }
        private void ResetEffectCCValues()
        {
            EffectsCCComboBox.SelectedIndex = 0;
            DamageMinCC.Text = "-1";
            DamageMaxCC.Text = "-1";
            DureeEffectCCTextBox.Text = "0";
            ReuEffectCCTextBox.Text = "0";
            ZoneCCComboBox.SelectedIndex = 0;
            ZoneSizeCCTextBox.Text = "0";
            EffectTargetCCComboBox.SelectedIndex = 0;
        }

        private void AddEffect_Click(object sender, RoutedEventArgs e)
        {
            if (EffectsComboBox.SelectedIndex > -1 && EffectTargetComboBox.SelectedIndex > -1 && !string.IsNullOrEmpty(DamageMin.Text) && !string.IsNullOrEmpty(DamageMax.Text) && !string.IsNullOrEmpty(DureeEffectTextBox.Text) && !string.IsNullOrEmpty(ReuEffectTextBox.Text) && ZoneComboBox.SelectedIndex > -1 && !string.IsNullOrEmpty(ZoneSizeTextBox.Text))
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
                                    if (EffectTargetComboBox.SelectedItem is EffectsTarget target)
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
                                            IconPath = effect.ImagePath,
                                            EffectTarget = target.Id
                                        };
                                        selectedEffects.DisplayName = selectedEffects.DisplayName?.Replace("Min", DamageMin.Text).Replace("Max", DamageMax.Text).Replace("#3", DamageMax.Text);
                                        SelectedEffects.Add(selectedEffects);
                                        ResetEffectValues();
                                    }
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
            if(EffectsCCComboBox.SelectedIndex > -1 && EffectTargetCCComboBox.SelectedIndex > -1 && !string.IsNullOrEmpty(DamageMinCC.Text) && !string.IsNullOrEmpty(DamageMaxCC.Text) && !string.IsNullOrEmpty(DureeEffectCCTextBox.Text) && !string.IsNullOrEmpty(ReuEffectCCTextBox.Text) && ZoneCCComboBox.SelectedIndex > -1 && !string.IsNullOrEmpty(ZoneSizeCCTextBox.Text))
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
                                    if (EffectTargetCCComboBox.SelectedItem is EffectsTarget target)
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
                                            IconPath = effect.ImagePath,
                                            EffectTarget = target.Id
                                        };
                                        selectedEffects.DisplayName = selectedEffects.DisplayName?.Replace("Min", DamageMinCC.Text).Replace("Max", DamageMaxCC.Text).Replace("#3", DamageMax.Text);
                                        SelectedEffectsCC.Add(selectedEffects);
                                        ResetEffectCCValues();
                                    }
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
            if(CurrentEditedEffect == null) {
                if (Levels != null)
                {
                    if (Levels.Count < 6)
                    {
                        if (IdTextBox.Text.Length > 0)
                        {
                            if (PaTextbox.Text.Length > 0 && StateComboBox.SelectedIndex > -1 && PoMinTextBox.Text.Length > 0 && PoMaxTextBox.Text.Length > 0 && CCTextBox.Text.Length > 0 && ECTextBox.Text.Length > 0 && LaunchPerTurn.Text.Length > 0 && LaunchPerTurnPerPlayer.Text.Length > 0 && TurnBetweenTwoLaunch.Text.Length > 0 && RequiredLevelTextBox.Text.Length > 0)
                            {
                                string effect = "";
                                string effectCC = "";
                                string zone = "";
                                string effectTarget = "";
                                string effectTargetCC = "";
                                string effectSwf = "[";
                                string effectCCSwf = "[";
                                if (SelectedEffects != null)
                                {
                                    if (SelectedEffects.Count > 0)
                                    {
                                        for (int i = 0; i < SelectedEffects.Count; i++)
                                        {
                                            zone += SelectedEffects[i].Zone;
                                            if (i != SelectedEffects.Count - 1)
                                            {
                                                effectTarget += SelectedEffects[i].EffectTarget + ";";
                                                effect += SelectedEffects[i].Effect?.EffectId + ";" + SelectedEffects[i].DamageMin + ";" + SelectedEffects[i].DamageMax + ";" + SelectedEffects[i].GlypheColor + ";" + SelectedEffects[i].SpellDuration + ";" + SelectedEffects[i].Probability + ";" + Functions.CalcJetD(SelectedEffects[i].DamageMin, SelectedEffects[i].DamageMax) + "|";
                                                effectSwf += "[" + SelectedEffects[i].Effect?.EffectId + "," + SelectedEffects[i].DamageMin + "," + (SelectedEffects[i].DamageMax <= 0 ? "null" : SelectedEffects[i].DamageMax) + "," + (SelectedEffects[i].GlypheColor <= 0 ? "null" : SelectedEffects[i].GlypheColor) + "," + (SelectedEffects[i].SpellDuration < 0 ? "null" : SelectedEffects[i].SpellDuration) + "," + SelectedEffects[i].Probability + ",\"" + Functions.CalcJetD(SelectedEffects[i].DamageMin, SelectedEffects[i].DamageMax) + "\"],";
                                            }
                                            else
                                            {
                                                effectTarget += SelectedEffects[i].EffectTarget;
                                                effect += SelectedEffects[i].Effect?.EffectId + ";" + SelectedEffects[i].DamageMin + ";" + SelectedEffects[i].DamageMax + ";" + SelectedEffects[i].GlypheColor + ";" + SelectedEffects[i].SpellDuration + ";" + SelectedEffects[i].Probability + ";" + Functions.CalcJetD(SelectedEffects[i].DamageMin, SelectedEffects[i].DamageMax);
                                                effectSwf += "[" + SelectedEffects[i].Effect?.EffectId + "," + SelectedEffects[i].DamageMin + "," + (SelectedEffects[i].DamageMax <= 0 ? "null" : SelectedEffects[i].DamageMax) + "," + (SelectedEffects[i].GlypheColor <= 0 ? "null" : SelectedEffects[i].GlypheColor) + "," + (SelectedEffects[i].SpellDuration < 0 ? "null" : SelectedEffects[i].SpellDuration) + "," + SelectedEffects[i].Probability + ",\"" + Functions.CalcJetD(SelectedEffects[i].DamageMin, SelectedEffects[i].DamageMax) + "\"]";
                                            }
                                        }
                                        effectSwf += "]";
                                    }
                                }
                                if (SelectedEffectsCC != null)
                                {
                                    if (SelectedEffectsCC.Count > 0)
                                    {
                                        for (int i = 0; i < SelectedEffectsCC.Count; i++)
                                        {
                                            zone += SelectedEffectsCC[i].Zone;
                                            if (i != SelectedEffectsCC.Count - 1)
                                            {
                                                effectTargetCC += SelectedEffectsCC[i].EffectTarget + ";";
                                                effectCC += SelectedEffectsCC[i].Effect?.EffectId + ";" + SelectedEffectsCC[i].DamageMin + ";" + SelectedEffectsCC[i].DamageMax + ";" + SelectedEffectsCC[i].GlypheColor + ";" + SelectedEffectsCC[i].SpellDuration + ";" + SelectedEffectsCC[i].Probability + ";" + Functions.CalcJetD(SelectedEffectsCC[i].DamageMin, SelectedEffectsCC[i].DamageMax) + "|";
                                                effectCCSwf += "[" + SelectedEffectsCC[i].Effect?.EffectId + "," + SelectedEffectsCC[i].DamageMin + "," + (SelectedEffectsCC[i].DamageMax <= 0 ? "null" : SelectedEffectsCC[i].DamageMax) + "," + (SelectedEffectsCC[i].GlypheColor <= 0 ? "null" : SelectedEffectsCC[i].GlypheColor) + "," + (SelectedEffectsCC[i].SpellDuration < 0 ? "null" : SelectedEffectsCC[i].SpellDuration) + "," + SelectedEffectsCC[i].Probability + ",\"" + Functions.CalcJetD(SelectedEffectsCC[i].DamageMin, SelectedEffectsCC[i].DamageMax) + "\"],";

                                            }
                                            else
                                            {
                                                effectTargetCC += SelectedEffectsCC[i].EffectTarget;
                                                effectCC += SelectedEffectsCC[i].Effect?.EffectId + ";" + SelectedEffectsCC[i].DamageMin + ";" + SelectedEffectsCC[i].DamageMax + ";" + SelectedEffectsCC[i].GlypheColor + ";" + SelectedEffectsCC[i].SpellDuration + ";" + SelectedEffectsCC[i].Probability + ";" + Functions.CalcJetD(SelectedEffectsCC[i].DamageMin, SelectedEffectsCC[i].DamageMax);
                                                effectCCSwf += "[" + SelectedEffectsCC[i].Effect?.EffectId + "," + SelectedEffectsCC[i].DamageMin + "," + (SelectedEffectsCC[i].DamageMax <= 0 ? "null" : SelectedEffectsCC[i].DamageMax) + "," + (SelectedEffectsCC[i].GlypheColor <= 0 ? "null" : SelectedEffectsCC[i].GlypheColor) + "," + (SelectedEffectsCC[i].SpellDuration < 0 ? "null" : SelectedEffectsCC[i].SpellDuration) + "," + SelectedEffectsCC[i].Probability + ",\"" + Functions.CalcJetD(SelectedEffectsCC[i].DamageMin, SelectedEffectsCC[i].DamageMax) + "\"]";
                                            }
                                        }
                                        effectCCSwf += "]";
                                    }
                                    else
                                    {
                                        effectCCSwf = "null";
                                    }
                                }
                                if (SpellType.SelectedItem is SpellTypes spellType)
                                {
                                    if (StateComboBox.SelectedItem is States state)
                                    {
                                        SpellsEffects spellEffect = new()
                                        {
                                            SpellEffectLevel = Levels.Count + 1,
                                            SpellId = Convert.ToInt32(IdTextBox.Text),
                                            Effect = effect,
                                            EffectSwf = effectSwf,
                                            EffectCC = effectCC,
                                            EffectCCSwf = effectCCSwf,
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
                                            TurnBetweenTwoLaunch = Convert.ToInt32(TurnBetweenTwoLaunch.Text),
                                            EffectTarget = effectTarget + ":" + effectTargetCC,
                                            RequiredLevel = Convert.ToInt32(RequiredLevelTextBox.Text)
                                        };
                                        Levels?.Add(spellEffect);
                                        ResetEffectValues();
                                        ResetEffectCCValues();
                                        SelectedEffects?.Clear();
                                        SelectedEffectsCC?.Clear();
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
            else
            {
            }
        }

        private async void GenerateSpellButton_Click(object sender, RoutedEventArgs e)
        {
            if (Levels != null)
            {
                if (Levels.Count > 0)
                {
                    if(IdTextBox.Text.Length > 0 && NameTextBox.Text.Length > 0 && SpriteTextBox.Text.Length > 0 && SpriteInfosTextbox.Text.Length > 0 && SpellType.SelectedIndex > -1)
                    {
                        if (SpellType.SelectedItem is SpellTypes spellType)
                        {
                            string[] levels = new string[Levels.Count];
                            string[] levelsSwf = new string[Levels.Count];
                            string effectTarget = "";
                            for (int i = 0; i < Levels.Count; i++)
                            {
                                SpellsEffects effect = Levels[i];
                                if (i == 0)
                                {
                                    effectTarget = effect.EffectTarget!;
                                }
                                else
                                {
                                    effectTarget = effectTarget.Split(":")[0] + ";" + effect.EffectTarget!.Split(":")[0] + ":" + effectTarget.Split(':')[1] + ";" + effect.EffectTarget!.Split(':')[1];
                                }
                                if (!string.IsNullOrEmpty(effect.EffectCC))
                                {
                                    levels[i] = effect.Effect + "," + effect.EffectCC + "," + effect.PaCost + "," + effect.PoMin + "," + effect.PoMax + "," + effect.CC + "," + effect.EC + "," + effect.IsInlineLaunch.ToString().ToLower() + "," + effect.IsWithoutLdv.ToString().ToLower() + "," + effect.IsEmptycell.ToString().ToLower() + "," + effect.IsPoEditable.ToString().ToLower() + "," + effect.SpellType + "," + effect.LaunchPerTurn + "," + effect.LaunchPerTurnPerPlayer + "," + effect.TurnBetweenTwoLaunch + "," + effect.Zone + "," + effect.RequireState + ",18;19;3;1;41," + effect.RequiredLevel + "," + effect.IsEcFinishTurn.ToString().ToLower();
                                    levelsSwf[i] = "[" + effect.EffectSwf + "," + effect.EffectCCSwf + "," + effect.PaCost + "," + effect.PoMin + "," + effect.PoMax + "," + effect.CC + "," + effect.EC + "," + effect.IsInlineLaunch.ToString().ToLower() + "," + effect.IsWithoutLdv.ToString().ToLower() + "," + effect.IsEmptycell.ToString().ToLower() + "," + effect.IsPoEditable.ToString().ToLower() + "," + effect.SpellType + "," + effect.LaunchPerTurn + "," + effect.LaunchPerTurnPerPlayer + "," + effect.TurnBetweenTwoLaunch + ",\"" + effect.Zone + "\",[" + (effect.RequireState <= 0 ? "" : effect.RequireState) + "], [18, 19, 41, 1, 3]," + effect.RequiredLevel + "," + effect.IsEcFinishTurn.ToString().ToLower() + "]";
                                }
                                else
                                {
                                    levels[i] = effect.Effect + ",-1," + effect.PaCost + "," + effect.PoMin + "," + effect.PoMax + "," + effect.CC + "," + effect.EC + "," + effect.IsInlineLaunch.ToString().ToLower() + "," + effect.IsWithoutLdv.ToString().ToLower() + "," + effect.IsEmptycell.ToString().ToLower() + "," + effect.IsPoEditable.ToString().ToLower() + "," + effect.SpellType + "," + effect.LaunchPerTurn + "," + effect.LaunchPerTurnPerPlayer + "," + effect.TurnBetweenTwoLaunch + "," + effect.Zone + "," + effect.RequireState + ",18;19;3;1;41," + effect.RequiredLevel + "," + effect.IsEcFinishTurn.ToString().ToLower();
                                    levelsSwf[i] = "[" + effect.EffectSwf + ",null," + effect.PaCost + "," + effect.PoMin + "," + effect.PoMax + "," + effect.CC + "," + effect.EC + "," + effect.IsInlineLaunch.ToString().ToLower() + "," + effect.IsWithoutLdv.ToString().ToLower() + "," + effect.IsEmptycell.ToString().ToLower() + "," + effect.IsPoEditable.ToString().ToLower() + "," + effect.SpellType + "," + effect.LaunchPerTurn + "," + effect.LaunchPerTurnPerPlayer + "," + effect.TurnBetweenTwoLaunch + ",\"" + effect.Zone + "\",[" + (effect.RequireState <= 0 ? "" : effect.RequireState) + "], [18, 19, 41, 1, 3]," + effect.RequiredLevel + "," + effect.IsEcFinishTurn.ToString().ToLower() + "]";
                                }
                            }
                            Sorts? newSpell = await SharedObjects.SortsRepository!.Get(Convert.ToInt32(IdTextBox.Text));
                            if (newSpell != null)
                            {
                                newSpell = new()
                                {
                                    Id = Convert.ToInt32(IdTextBox.Text),
                                    Nom = NameTextBox.Text,
                                    Sprite = Convert.ToInt32(SpriteTextBox.Text),
                                    SpriteInfos = SpriteInfosTextbox.Text,
                                    EffectTarget = effectTarget,
                                    Type = spellType.Id < 0 ? 0 : spellType.Id,
                                    Duration = 800
                                };
                                for (int i = 0; i < levels.Length; i++)
                                {
                                    switch (i)
                                    {
                                        case 0:
                                            newSpell.Lvl1 = levels[i];
                                            break;
                                        case 1:
                                            newSpell.Lvl2 = levels[i];
                                            break;
                                        case 2:
                                            newSpell.Lvl3 = levels[i];
                                            break;
                                        case 3:
                                            newSpell.Lvl4 = levels[i];
                                            break;
                                        case 4:
                                            newSpell.Lvl5 = levels[i];
                                            break;
                                        case 5:
                                            newSpell.Lvl6 = levels[i];
                                            break;
                                    }
                                }
                                await SharedObjects.SortsRepository!.Create(newSpell);
                                StringBuilder builder = new();
                                builder.Append("S[").Append(IdTextBox.Text).Append("] = n:\"" + NameTextBox.Text + "\", d:\"" + DescriptionTextBox.Text + "\"");
                                for (int i = 0; i < levelsSwf.Length; i++)
                                {
                                    builder.Append(",l").Append(i + 1).Append(':').Append(levelsSwf[i]);
                                }
                                builder.Append("};");
                                SWFTextBox.Text = builder.ToString();
                            }
                            else
                            {
                                MessageBox.Show("Error", "Votre base de données contient déjà un sort avec cet identifiant");
                            }
                        }
                    }
                }
            }
        }
        private void DeleteSpellLevel(object sender, RoutedEventArgs e)
        {
            if (LevelListBox.SelectedItem is SpellsEffects effects)
            {
                if(CurrentEditedEffect != null)
                {
                    CurrentEditedEffect = null;
                    ResetEffectValues();
                    ResetEffectCCValues();
                    SelectedEffects?.Clear();
                    SelectedEffectsCC?.Clear();
                }
                if (Levels != null)
                {
                    Levels.Remove(effects);
                    for (int i = 0; i < Levels.Count; i++)
                    {
                        Levels[i].SpellEffectLevel = i + 1;
                    }
                    LevelListBox.ItemsSource = null;
                    LevelListBox.ItemsSource = Levels;
                }
            }
        }
        private void EditSpellLevel(object sender, RoutedEventArgs e)
        {
            if (LevelListBox.SelectedItem is SpellsEffects effects)
            {
                if (CurrentEditedEffect == null)
                {
                    CurrentEditedEffect = effects;
                    ResetEffectValues();
                    ResetEffectCCValues();
                    SelectedEffects?.Clear();
                    SelectedEffectsCC?.Clear();
                    if (CurrentEditedEffect.Effect != null)
                    {
                        string[] splitedEffects = CurrentEditedEffect.Effect.Split('|');
                        string[]? splitedEffectsCC = CurrentEditedEffect.EffectCC?.Split('|');
                        int numbEffect = 0;
                        for (int i = 0; i < splitedEffects.Length; i++)
                        {
                            Effects effect = Effects!.First(c => c.EffectId == Convert.ToInt32(splitedEffects[i].Split(';')[0]));
                            SelectedEffects selectedEffect = new()
                            {
                                Effect = effect,
                                DamageMin = Convert.ToInt32(splitedEffects[i].Split(';')[1]),
                                DamageMax = Convert.ToInt32(splitedEffects[i].Split(';')[2]),
                                GlypheColor = Convert.ToInt32(splitedEffects[i].Split(';')[3]),
                                SpellDuration = Convert.ToInt32(splitedEffects[i].Split(';')[4]),
                                Probability = Convert.ToInt32(splitedEffects[i].Split(';')[5]),
                                Zone = CurrentEditedEffect.Zone!.Substring(i * 2, 2 + (i * 2)),
                                DisplayName = effect.Name,
                                IconPath = effect.ImagePath,
                                EffectTarget = Convert.ToInt32(CurrentEditedEffect.EffectTarget!.Split(':')[0].Split(';')[i])
                            };
                            selectedEffect.DisplayName = selectedEffect.DisplayName?.Replace("Min", selectedEffect.DamageMin.ToString()).Replace("Max", selectedEffect.DamageMax.ToString()).Replace("#3", selectedEffect.DamageMax.ToString());
                            SelectedEffects?.Add(selectedEffect);
                            numbEffect++;
                        }

                        if (splitedEffectsCC != null)
                        {
                            for (int i = 0; i < splitedEffectsCC.Length; i++)
                            {
                                Effects effectCC = EffectsCC!.First(c => c.EffectId == Convert.ToInt32(splitedEffectsCC[i].Split(';')[0]));
                                SelectedEffects selectedEffectCC = new()
                                {
                                    Effect = effectCC,
                                    DamageMin = Convert.ToInt32(splitedEffectsCC[i].Split(';')[1]),
                                    DamageMax = Convert.ToInt32(splitedEffectsCC[i].Split(';')[2]),
                                    GlypheColor = Convert.ToInt32(splitedEffectsCC[i].Split(';')[3]),
                                    SpellDuration = Convert.ToInt32(splitedEffectsCC[i].Split(';')[4]),
                                    Probability = Convert.ToInt32(splitedEffectsCC[i].Split(';')[5]),
                                    Zone = CurrentEditedEffect.Zone!.Substring(numbEffect + (2 * i), 2 + numbEffect + (2 * i)),
                                    DisplayName = effectCC.Name,
                                    IconPath = effectCC.ImagePath,
                                    EffectTarget = Convert.ToInt32(CurrentEditedEffect.EffectTarget!.Split(':')[1].Split(';')[i])
                                };
                                selectedEffectCC.DisplayName = selectedEffectCC.DisplayName?.Replace("Min", selectedEffectCC.DamageMin.ToString()).Replace("Max", selectedEffectCC.DamageMax.ToString()).Replace("#3", selectedEffectCC.DamageMax.ToString());
                                SelectedEffectsCC?.Add(selectedEffectCC);
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Error", "Terminer l'édition du niveau de sort avant d'éditer un nouveau sort", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}

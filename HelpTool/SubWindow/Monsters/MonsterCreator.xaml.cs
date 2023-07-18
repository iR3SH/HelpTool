using HelpData.Classes.Game;
using HelpData.Classes.Monsters;
using HelpTool.Classes;
using HelpTool.Languages;
using HelpTool.SubWindow.Monsters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace HelpTool.SubWindow.Items
{
    /// <summary>
    /// Interaction logic for MonsterCreator.xaml
    /// </summary>
    public partial class MonsterCreator : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private List<Sorts>? _Spells { get; set; }
        public List<Sorts>? Spells { get { return _Spells; } set { _Spells = value; NotifyPropertyChanged(); } }
        private List<MobGrade>? _MobGrades { get; set; }
        public List<MobGrade>? MobGrades { get { return _MobGrades; } set { _MobGrades = value; NotifyPropertyChanged(); } }
        private List<int>? SpellsLevels { get; set; }
        private MobGrade? SelectedMobGrade { get; set; }
        private HelpData.Classes.Game.Monsters? EditedMonster { get; set; }
        public MonsterCreator()
        {
            InitializeComponent();
            DataContext = this;
            MobGrades = new();
            ResetMobGradesEntry();
        }
        public MonsterCreator(HelpData.Classes.Game.Monsters monster)
        {
            InitializeComponent();
            DataContext = this;
            EditedMonster = monster;
            InitEditingData();
        }

        private async void InitEditingData()
        {
            if (EditedMonster != null)
            {
                MobGrades = await Functions.InitMobGrades(EditedMonster);
                IdTextBox.Text = EditedMonster.Id.ToString();
                NameTextBox.Text = EditedMonster.Name;
                GfxIdTextBox.Text = EditedMonster.GfxID.ToString();
                ColorTextBox.Text = EditedMonster.Colors;
                MinKamasTextBox.Text = EditedMonster.MinKamas.ToString();
                MaxKamasTextBox.Text = EditedMonster.MaxKamas.ToString();
                IATypeTextBox.Text = EditedMonster.AI_Type.ToString();
                AlignComboBox.SelectedIndex = EditedMonster.Align switch
                {
                    -1 => 0,
                    _ => EditedMonster.Align,
                };
                CapturableCheckBox.IsChecked = EditedMonster.Capturable;
                DistAggroTextbox.Text = EditedMonster.AggroDistance.ToString();
                MessageBoxResult dialogResult = MessageBox.Show("Le monstre est-il un boss ?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if(dialogResult == MessageBoxResult.Yes)
                {
                    IsBossCheckBox.IsChecked = true;
                }
                else
                {
                    IsBossCheckBox.IsChecked = false;
                }
                MessageBoxResult dialogResult2 = MessageBox.Show("Le monstre est-il invocable ?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (dialogResult2 == MessageBoxResult.Yes)
                {
                    IsInvocable.IsChecked = true;
                }
                else
                {
                    IsInvocable.IsChecked = false;
                }
                switch(EditedMonster.Type)
                {
                    case 0:
                        TypeComboBox.SelectedIndex = 0;
                        break;
                    case 2:
                        TypeComboBox.SelectedIndex = 1;
                        break;
                    case 3:
                        TypeComboBox.SelectedIndex = 2;
                        break;
                    default:
                        TypeComboBox.Items.Add(new ComboBoxItem() { Tag = EditedMonster.Type, Content = "Custom" });
                        break;
                }
                CreateButton.Content = Functions.Word("UpdateMonster");
            }
        }

        private void AddSpellClick(object sender, RoutedEventArgs e)
        {
            SpellGetter spellGetter = new();
            spellGetter.ShowDialog();
            if(SharedObjects.MobGradeSpellGetter != null && SharedObjects.MobGradeSpellLevelGetter != null)
            {
                Spells = SharedObjects.MobGradeSpellGetter;
                SpellsLevels = SharedObjects.MobGradeSpellLevelGetter;
            }
        }

        private void DeleteSpellClick(object sender, RoutedEventArgs e)
        {
            if(SpellListBox.SelectedItem != null)
            {
                if (Spells != null)
                {
                    if (SharedObjects.MobGradeSpellLevelGetter!.Count > SpellListBox.SelectedIndex)
                    {
                        SharedObjects.MobGradeSpellLevelGetter.RemoveAt(SpellListBox.SelectedIndex);
                    }
                    if (SharedObjects.MobGradeSpellGetter!.Count > SpellListBox.SelectedIndex)
                    {
                        SharedObjects.MobGradeSpellGetter.RemoveAt(SpellListBox.SelectedIndex);
                    }
                }
            }
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            SharedObjects.MobGradeSpellGetter = null;
            SharedObjects.MobGradeSpellLevelGetter = null;
        }

        private void CheckIntValue(object sender, TextCompositionEventArgs e)
        {
            Regex regex = Functions.NumRegex();
            e.Handled = regex.IsMatch(e.Text);
        }

        private void AddMobGrade(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(LevelTextBox.Text) &&
               !string.IsNullOrEmpty(PaTextBox.Text) &&
               !string.IsNullOrEmpty(PmTextBox.Text) &&
               !string.IsNullOrEmpty(IniTextBox.Text) &&
               !string.IsNullOrEmpty(VitaTextBox.Text) &&
               !string.IsNullOrEmpty(SageTextBox.Text) &&
               !string.IsNullOrEmpty(ForceTextBox.Text) &&
               !string.IsNullOrEmpty(IntelTextBox.Text) &&
               !string.IsNullOrEmpty(ChanceTextBox.Text) &&
               !string.IsNullOrEmpty(AgiTextBox.Text) &&
               !string.IsNullOrEmpty(DomTextBox.Text) &&
               !string.IsNullOrEmpty(DomPerTextBox.Text) &&
               !string.IsNullOrEmpty(HealTextBox.Text) &&
               !string.IsNullOrEmpty(CreaTextBox.Text) &&
               !string.IsNullOrEmpty(ReNeuTextBox.Text) &&
               !string.IsNullOrEmpty(ReTerreTextBox.Text) &&
               !string.IsNullOrEmpty(ReFeuTextBox.Text) &&
               !string.IsNullOrEmpty(ReEauTextBox.Text) &&
               !string.IsNullOrEmpty(ReAirTextBox.Text) &&
               !string.IsNullOrEmpty(EsqPaTextBox.Text) &&
               !string.IsNullOrEmpty(EsqPmTextBox.Text) &&
               !string.IsNullOrEmpty(ExpTextBox.Text)
            )
            {
                MobGrade? mobGrade;
                if (SelectedMobGrade != null)
                {
                    mobGrade = SelectedMobGrade;
                    mobGrade.Level = Convert.ToInt32(LevelTextBox.Text);
                    mobGrade.Pa = Convert.ToInt32(PaTextBox.Text);
                    mobGrade.Pm = Convert.ToInt32(PmTextBox.Text);
                    mobGrade.Initiative = Convert.ToInt32(IniTextBox.Text);
                    mobGrade.Vitalite = Convert.ToInt32(VitaTextBox.Text);
                    mobGrade.Sagesse = Convert.ToInt32(SageTextBox.Text);
                    mobGrade.Force = Convert.ToInt32(ForceTextBox.Text);
                    mobGrade.Intelligence = Convert.ToInt32(IntelTextBox.Text);
                    mobGrade.Chance = Convert.ToInt32(ChanceTextBox.Text);
                    mobGrade.Agilite = Convert.ToInt32(AgiTextBox.Text);
                    mobGrade.Dommages = Convert.ToInt32(DomTextBox.Text);
                    mobGrade.DommagesPer = Convert.ToInt32(DomPerTextBox.Text);
                    mobGrade.Soins = Convert.ToInt32(HealTextBox.Text);
                    mobGrade.Creatures = Convert.ToInt32(CreaTextBox.Text);
                    mobGrade.ResNeutre = Convert.ToInt32(ReNeuTextBox.Text);
                    mobGrade.ResTerre = Convert.ToInt32(ReTerreTextBox.Text);
                    mobGrade.ResFeu = Convert.ToInt32(ReFeuTextBox.Text);
                    mobGrade.ResEau = Convert.ToInt32(ReEauTextBox.Text);
                    mobGrade.ResAir = Convert.ToInt32(ReAirTextBox.Text);
                    mobGrade.EsqPa = Convert.ToInt32(EsqPaTextBox.Text);
                    mobGrade.EsqPm = Convert.ToInt32(EsqPmTextBox.Text);
                    mobGrade.Experience = Convert.ToInt32(ExpTextBox.Text);
                    mobGrade.Sorts = Spells;
                    mobGrade.SortsLevels = SpellsLevels;
                }
                else
                {
                    mobGrade = new()
                    {
                        Grade = MobGrades!.Count + 1,
                        Level = Convert.ToInt32(LevelTextBox.Text),
                        Pa = Convert.ToInt32(PaTextBox.Text),
                        Pm = Convert.ToInt32(PmTextBox.Text),
                        Initiative = Convert.ToInt32(IniTextBox.Text),
                        Vitalite = Convert.ToInt32(VitaTextBox.Text),
                        Sagesse = Convert.ToInt32(SageTextBox.Text),
                        Force = Convert.ToInt32(ForceTextBox.Text),
                        Intelligence = Convert.ToInt32(IntelTextBox.Text),
                        Chance = Convert.ToInt32(ChanceTextBox.Text),
                        Agilite = Convert.ToInt32(AgiTextBox.Text),
                        Dommages = Convert.ToInt32(DomTextBox.Text),
                        DommagesPer = Convert.ToInt32(DomPerTextBox.Text),
                        Soins = Convert.ToInt32(HealTextBox.Text),
                        Creatures = Convert.ToInt32(CreaTextBox.Text),
                        ResNeutre = Convert.ToInt32(ReNeuTextBox.Text),
                        ResTerre = Convert.ToInt32(ReTerreTextBox.Text),
                        ResFeu = Convert.ToInt32(ReFeuTextBox.Text),
                        ResEau = Convert.ToInt32(ReEauTextBox.Text),
                        ResAir = Convert.ToInt32(ReAirTextBox.Text),
                        EsqPa = Convert.ToInt32(EsqPaTextBox.Text),
                        EsqPm = Convert.ToInt32(EsqPmTextBox.Text),
                        Experience = Convert.ToInt32(ExpTextBox.Text),
                        Sorts = Spells,
                        SortsLevels = SpellsLevels
                    };
                }
                if (!MobGrades!.Contains(mobGrade))
                {
                    if (MobGrades.Count < 6)
                    {
                        MobGrades!.Add(mobGrade);
                        LevelListBox.ItemsSource = null;
                        LevelListBox.ItemsSource = MobGrades;
                    }
                    else
                    {
                        MessageBox.Show("Vous ne pouvez pas ajouter plus de 6 Grâdes à un Monstre.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    SelectedMobGrade = null;
                    SelectedMobGradeLabel.Content = "";
                    AddMobGradeButton.Content = Functions.Word("AddMobGrade");
                }
                ResetMobGradesEntry();
            }
            else
            {
                MessageBox.Show("Vous devez remplir tout les champs nécéssaire au MobGrade", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ResetMobGradesEntry()
        {
            LevelTextBox.Text = "0";
            PaTextBox.Text = "0";
            PmTextBox.Text = "0";
            IniTextBox.Text = "0";
            VitaTextBox.Text = "0";
            SageTextBox.Text = "0";
            ForceTextBox.Text = "0";
            IntelTextBox.Text = "0";
            ChanceTextBox.Text = "0";
            AgiTextBox.Text = "0";
            DomTextBox.Text = "0";
            DomPerTextBox.Text = "0";
            HealTextBox.Text = "0";
            CreaTextBox.Text = "0";
            ReNeuTextBox.Text = "0";
            ReTerreTextBox.Text = "0";
            ReFeuTextBox.Text = "0";
            ReEauTextBox.Text = "0";
            ReAirTextBox.Text = "0";
            EsqPaTextBox.Text = "0";
            EsqPmTextBox.Text = "0";
            ExpTextBox.Text = "0";
            Spells?.Clear();
            SpellsLevels?.Clear();
        }

        private void LevelListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MessageBoxResult dialogResult = MessageBox.Show("Voulez-vous charger le Grâde pour le modifier ?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (dialogResult == MessageBoxResult.Yes)
            {
                if (LevelListBox.SelectedItem is MobGrade Grade)
                {
                    LevelTextBox.Text = Grade.Level.ToString();
                    PaTextBox.Text = Grade.Pa.ToString();
                    PmTextBox.Text = Grade.Pm.ToString();
                    IniTextBox.Text = Grade.Initiative.ToString();
                    VitaTextBox.Text = Grade.Vitalite.ToString();
                    SageTextBox.Text = Grade.Sagesse.ToString();
                    ForceTextBox.Text = Grade.Force.ToString();
                    IntelTextBox.Text = Grade.Intelligence.ToString();
                    ChanceTextBox.Text = Grade.Chance.ToString();
                    AgiTextBox.Text = Grade.Agilite.ToString();
                    DomTextBox.Text = Grade.Dommages.ToString();
                    DomPerTextBox.Text = Grade.DommagesPer.ToString();
                    HealTextBox.Text = Grade.Soins.ToString();
                    CreaTextBox.Text = Grade.Creatures.ToString();
                    ReNeuTextBox.Text = Grade.ResNeutre.ToString();
                    ReTerreTextBox.Text = Grade.ResTerre.ToString();
                    ReFeuTextBox.Text = Grade.ResFeu.ToString();
                    ReEauTextBox.Text = Grade.ResEau.ToString();
                    ReAirTextBox.Text = Grade.ResAir.ToString();
                    EsqPaTextBox.Text = Grade.EsqPa.ToString();
                    EsqPmTextBox.Text = Grade.EsqPm.ToString();
                    ExpTextBox.Text = Grade.Experience.ToString();
                    Spells = Grade.Sorts;
                    SpellsLevels = Grade.SortsLevels;
                    SelectedMobGrade = Grade;
                    SelectedMobGradeLabel.Content = "Grade " + Grade.Grade.ToString() + " sélectionné";
                    AddMobGradeButton.Content = Functions.Word("UpdateMobGrade");
                }
            }
        }
        private void NewGrade(object sender, RoutedEventArgs e)
        {
            ResetMobGradesEntry();
            if(SelectedMobGrade != null)
            {
                SelectedMobGrade = null;
                SelectedMobGradeLabel.Content = "";
                AddMobGradeButton.Content = Functions.Word("AddMobGrade");
            }
        }
        private void DeleteMobGrade(object sender, RoutedEventArgs e)
        {
            if(LevelListBox.SelectedItem is MobGrade Grade)
            {
                if(MobGrades != null)
                {
                    if(MobGrades.Contains(Grade))
                    {
                        MobGrades.Remove(Grade);
                    }
                }

                if(SelectedMobGrade == Grade)
                {
                    NewGrade(sender, e);
                }
            }
        }

        private async void CreateMonster(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(IdTextBox.Text) &&
                !string.IsNullOrEmpty(NameTextBox.Text) &&
                !string.IsNullOrEmpty(GfxIdTextBox.Text) &&
                AlignComboBox.SelectedIndex > 0 &&
                LevelListBox.Items.Count > 0 &&
                TypeComboBox.SelectedIndex > 0 &&
                MobGrades?.Count > 0 &&
                !string.IsNullOrEmpty(ColorTextBox.Text) &&
                !string.IsNullOrEmpty(MinKamasTextBox.Text) &&
                !string.IsNullOrEmpty(MaxKamasTextBox.Text) &&
                !string.IsNullOrEmpty(IATypeTextBox.Text) &&
                !string.IsNullOrEmpty(DistAggroTextbox.Text)
                )
            {
                
                List<string> MobGradeDetails = Functions.ParseMobGradesInfos(MobGrades);
                bool? isBoss = IsBossCheckBox.IsChecked;
                if(isBoss == null)
                {
                    isBoss = false;
                }

                bool? isCapturable = CapturableCheckBox.IsChecked;
                if(isCapturable == null)
                {
                    isCapturable = false;
                }
                bool? CanSummon = IsInvocable.IsChecked;
                if(CanSummon == null)
                {
                    CanSummon = false;
                }
                HelpData.Classes.Game.Monsters? monster;
                if (EditedMonster == null)
                {
                    monster = new()
                    {
                        Id = Convert.ToInt32(IdTextBox.Text),
                        Name = NameTextBox.Text,
                        GfxID = Convert.ToInt32(GfxIdTextBox.Text),
                        Align = Convert.ToInt32(AlignComboBox.SelectedItem as string),
                        Colors = ColorTextBox.Text,
                        MinKamas = Convert.ToInt32(MinKamasTextBox.Text),
                        MaxKamas = Convert.ToInt32(MaxKamasTextBox.Text),
                        AI_Type = Convert.ToInt32(IATypeTextBox.Text),
                        AggroDistance = Convert.ToInt32(DistAggroTextbox.Text),
                        Type = Convert.ToInt32(TypeComboBox.SelectedItem as string),
                        Grades = MobGradeDetails[0],
                        Stats = MobGradeDetails[1],
                        StatsInfos = MobGradeDetails[2],
                        Spells = MobGradeDetails[3],
                        Points = MobGradeDetails[4],
                        Pdvs = MobGradeDetails[5],
                        Inits = MobGradeDetails[6],
                        Exps = MobGradeDetails[7],
                        Capturable = (bool)isCapturable
                    };
                    await SharedObjects.MonstersRepository!.Create(monster);
                }
                else
                {
                    monster = EditedMonster;
                    monster.Id = Convert.ToInt32(IdTextBox.Text);
                    monster.Name = NameTextBox.Text;
                    monster.GfxID = Convert.ToInt32(GfxIdTextBox.Text);
                    monster.Align = Convert.ToInt32(AlignComboBox.SelectedItem as string);
                    monster.Colors = ColorTextBox.Text;
                    monster.MinKamas = Convert.ToInt32(MinKamasTextBox.Text);
                    monster.MaxKamas = Convert.ToInt32(MaxKamasTextBox.Text);
                    monster.AI_Type = Convert.ToInt32(IATypeTextBox.Text);
                    monster.AggroDistance = Convert.ToInt32(DistAggroTextbox.Text);
                    monster.Type = Convert.ToInt32(TypeComboBox.SelectedItem as string);
                    monster.Grades = MobGradeDetails[0];
                    monster.Stats = MobGradeDetails[1];
                    monster.StatsInfos = MobGradeDetails[2];
                    monster.Spells = MobGradeDetails[3];
                    monster.Points = MobGradeDetails[4];
                    monster.Pdvs = MobGradeDetails[5];
                    monster.Inits = MobGradeDetails[6];
                    monster.Exps = MobGradeDetails[7];
                    monster.Capturable = (bool)isCapturable;

                    await SharedObjects.MonstersRepository!.Update(monster);

                }
                StringBuilder stringBuilder = new();
                stringBuilder.Append("M[")
                    .Append(monster.Id)
                    .Append("] = {n:\"")
                    .Append(monster.Name)
                    .Append("\", g:")
                    .Append(monster.GfxID)
                    .Append(", b:-1, a:")
                    .Append(monster.Align == 0 ? -1 : monster.Align)
                    .Append(", k:false, d:")
                    .Append((bool)isBoss ? "true" : "false")
                    .Append(", s:")
                    .Append((bool)CanSummon ? "true" : "false")
                    .Append(", ")
                    .Append(Functions.GenerateGradeMonstersSwf(monster, (bool)CanSummon));
                SwfResultTextBox.Text = stringBuilder.ToString();
            }
        }

        private void French (object sender, RoutedEventArgs e)
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
        /*
         * SWF
         * b: Famille de Monstre (-1 pour non classé)
         * k: toujours false
         * d: est-ce un boss ?
         * s: true s'il n'est pas invocable / false s'il est invocable
         * a: id alignement (-1 pour neutre / 1 Bonta / 2 Brâ)
         */
    }
}

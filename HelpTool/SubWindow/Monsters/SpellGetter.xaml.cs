using HelpData.Classes.Game;
using HelpData.IRepository;
using HelpTool.Classes;
using Org.BouncyCastle.Crypto;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace HelpTool.SubWindow.Monsters
{
    /// <summary>
    /// Interaction logic for SpellGetter.xaml
    /// </summary>
    public partial class SpellGetter : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private ISortsRepository _repoSorts = SharedObjects.SortsRepository!;
        private List<Sorts>? _Spells {  get; set; }
        public List<Sorts>? Spells { get {  return _Spells; } set { _Spells = value; NotifyPropertyChanged(); } }
        public SpellGetter()
        {
            InitializeComponent();
            DataContext = this;
            GetData();  
        }
        private async void GetData()
        {
            Spells = await _repoSorts.GetAllNoTracking();
        }
        private void AddClick(object sender, RoutedEventArgs e)
        {
            Sorts? spell = SpellDt.SelectedItem as Sorts;
            if (spell != null && SpellLevel.SelectedValue != null)
            {
                if (SharedObjects.MobGradeSpellGetter == null)
                {
                    SharedObjects.MobGradeSpellGetter = new List<Sorts>() { spell };
                }
                else
                {
                    SharedObjects.MobGradeSpellGetter.Add(spell);
                }

                if (SharedObjects.MobGradeSpellLevelGetter == null)
                {
                    SharedObjects.MobGradeSpellLevelGetter = new List<int> { Convert.ToInt32(SpellLevel.SelectedValue.ToString()) };
                }
                else
                {
                    SharedObjects.MobGradeSpellLevelGetter.Add(Convert.ToInt32(SpellLevel.SelectedValue.ToString()));
                }
                Close();
            }
        }

        private void SpellDt_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if(SpellDt.SelectedItem != null)
            {
                Sorts spell = SpellDt.SelectedItem as Sorts;
                if (spell != null)
                {
                    int count = Functions.GetLevelsForSpell(spell);
                    SpellLevel.Items.Clear();
                    for(int i = 0; i < count; i++)
                    {
                        SpellLevel.Items.Add(i + 1);
                    }
                }
                SpellLevel.SelectedIndex = 0;
            }
        }
    }
}

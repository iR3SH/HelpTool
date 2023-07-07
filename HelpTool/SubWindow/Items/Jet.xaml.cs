using HelpData.Classes.Effects;
using HelpData.Classes.Game;
using HelpTool.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace HelpTool.SubWindow.Items
{
    /// <summary>
    /// Interaction logic for Jet.xaml
    /// </summary>
    public partial class Jet : Window, INotifyPropertyChanged
    {
        private Dictionary<ItemEffect, string[]> selectedEffects;
        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private ObservableCollection<DisplayEffects>? _Effects { get; set; }
        public ObservableCollection<DisplayEffects>? Effects { get { return _Effects; } set { _Effects = value; NotifyPropertyChanged(); } }
        public Jet(bool isCac, ItemTemplate? itemTemplate)
        {
            InitializeComponent();
            DataContext = this;
            List<ItemEffect> effects = Functions.GenerateAllEffect();
            foreach (ItemEffect effect in effects)
            {
                if (effect.IsCacEffect != false & effect.IsCacEffect == isCac)
                {
                    EffectComboBox.Items.Add(effect);
                }
                else if (effect.IsCacEffect == false)
                {
                    EffectComboBox.Items.Add(effect);
                }
            }
            selectedEffects = new Dictionary<ItemEffect, string[]>();
            Effects = new ObservableCollection<DisplayEffects>();
            if(itemTemplate != null)
            {
                selectedEffects = Functions.UnCryptEffectItem(itemTemplate.StatsTemplate!);
                for(int i = 0; i < selectedEffects.Keys.Count; i++)
                {
                    string EffectIdHex = selectedEffects.Values.ElementAt(i)[0];
                    string jetMin = selectedEffects.Values.ElementAt(i)[1];
                    string jetMax = selectedEffects.Values.ElementAt(i)[2];
                    string sign = Functions.GetStatsSign(EffectIdHex);
                    if (Convert.ToInt32(jetMax) > 0)
                    {
                        Effects.Add(new DisplayEffects() { Effect = selectedEffects.Keys.ElementAt(i), Text = sign + " " + jetMin + " à " + jetMax + " " + selectedEffects.Keys.ElementAt(i).Name });
                    }
                    else
                    {
                        Effects.Add(new DisplayEffects() { Effect = selectedEffects.Keys.ElementAt(i), Text = sign + " " + jetMin + " " + selectedEffects.Keys.ElementAt(i).Name });
                    }
                }
            }
        }

        private void EffectComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(EffectComboBox.SelectedItem is ItemEffect)
            { 
                ItemEffect? selectedEffect = EffectComboBox.SelectedItem as ItemEffect;
                if (string.IsNullOrEmpty(selectedEffect?.RemHexId))
                {
                    AddRem.Visibility = Visibility.Hidden;
                }
                else
                {
                    AddRem.Visibility = Visibility.Visible;
                }
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (EffectComboBox.SelectedItem is ItemEffect effect)
            {
                if (selectedEffects.ContainsKey(effect))
                {
                    MessageBox.Show("Vous ne pouvez pas ajouter deux fois le même effet", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (JetMaxTextBox.Text.Length > 0 & JetMinTextBox.Text.Length > 0)
                {
                    int jetmin = Convert.ToInt32(JetMinTextBox.Text);
                    int jetmax = Convert.ToInt32(JetMaxTextBox.Text);
                    ComboBoxItem? selectedItem = AddRem.SelectedItem as ComboBoxItem;
                    if (jetmin > jetmax & jetmax > 0)
                    {
                        MessageBox.Show("Le Jet Minimum ne peut pas être supérieur au Jet Max", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    if (string.IsNullOrEmpty(effect?.RemHexId))
                    {
                        if (jetmax > 0)
                        {
                            Effects?.Add(new DisplayEffects() { Text = "+ " + JetMinTextBox.Text + " à " + JetMaxTextBox.Text + " " + effect?.Name, Effect = effect });
                            NotifyPropertyChanged(nameof(Effects));
                        }
                        else
                        {
                            Effects?.Add(new DisplayEffects() { Text = "+ " + JetMinTextBox.Text + " " + effect?.Name, Effect = effect });
                            NotifyPropertyChanged(nameof(Effects));
                        }
                    }
                    else
                    {
                        if (jetmax > 0)
                        {
                            Effects?.Add(new DisplayEffects() { Text = selectedItem?.Content.ToString() + " " + JetMinTextBox.Text + " à " + JetMaxTextBox.Text + " " + effect?.Name, Effect = effect });
                            NotifyPropertyChanged(nameof(Effects));
                        }
                        else
                        {
                            Effects?.Add(new DisplayEffects() { Text = selectedItem?.Content.ToString() + " " + JetMinTextBox.Text + " " + effect?.Name, Effect = effect });
                            NotifyPropertyChanged(nameof(Effects));
                        }
                    }
                    if (effect != null)
                    {
                        if (selectedItem != null)
                        {
                            if (selectedItem.Content.ToString() == "+")
                            {
                                selectedEffects.Add(effect, new string[] { effect!.AddHexId!, jetmin.ToString(), jetmax.ToString()});
                            }
                            else
                            {
                                selectedEffects.Add(effect, new string[] { effect!.RemHexId!, jetmin.ToString(), jetmax.ToString()});
                            }
                        }
                    }
                }
            }
        }

        private void GenerateButton_Click(object sender, RoutedEventArgs e)
        {
            if(JetsListBox.Items.Count > 0)
            {
                if(GeneratedJetText.Text.Length > 0)
                {
                    GeneratedJetText.Text = "";
                }
                foreach(string[] details in selectedEffects.Values)
                {
                    if (GeneratedJetText.Text.Length > 0)
                    {
                        GeneratedJetText.Text += Functions.CalcEffectItem(details[0], Convert.ToInt32(details[1]), Convert.ToInt32(details[2]), false);
                    }
                    else
                    {
                        GeneratedJetText.Text += Functions.CalcEffectItem(details[0], Convert.ToInt32(details[1]), Convert.ToInt32(details[2]), true);
                    }
                }
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if(JetsListBox.SelectedItem != null)
            {
                ListBoxItem? selectedEffect = JetsListBox.SelectedItem as ListBoxItem;
                int index = JetsListBox.SelectedIndex;
                Effects?.RemoveAt(index);
                selectedEffects.Remove(selectedEffects.Keys.ElementAt(index));
            }
        }
        private void DeleteAll_Click(object sender, RoutedEventArgs e)
        {
            Effects?.Clear();
            selectedEffects.Clear();
        }

        private void Up_Click(object sender, RoutedEventArgs e)
        {
            if(JetsListBox.SelectedItem != null)
            {
                if (JetsListBox.SelectedIndex != 0)
                {
                    int oldIndex = JetsListBox.SelectedIndex;
                    int newIndex = JetsListBox.SelectedIndex - 1;
                    Effects?.Move(oldIndex, newIndex);
                    selectedEffects = Functions.Move(oldIndex, newIndex, selectedEffects);
                }
            }
        }

        private void Down_Click(object sender, RoutedEventArgs e)
        {
            if (JetsListBox.SelectedIndex != JetsListBox.Items.Count - 1)
            {
                int oldIndex = JetsListBox.SelectedIndex;
                int newIndex = JetsListBox.SelectedIndex + 1;
                Effects?.Move(oldIndex, newIndex);
                selectedEffects = Functions.Move(oldIndex, newIndex, selectedEffects);
            }
        }
    }
}

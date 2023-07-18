using Google.Protobuf.WellKnownTypes;
using HelpData.Classes.Effects;
using HelpData.Classes.Game;
using HelpData.Classes.Login;
using HelpTool.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
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
    /// Interaction logic for Inventory.xaml
    /// </summary>
    public partial class Inventory : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private List<Objects>? _Equipements { get; set; }
        public List<Objects>? Equipements { get { return _Equipements; } set { _Equipements = value; NotifyPropertyChanged(); } }
        private List<Objects>? _Consumables { get; set; }
        public List<Objects>? Consumables { get { return _Consumables; } set { _Consumables = value; NotifyPropertyChanged(); } }
        private List<Objects>? _Ressources { get; set; }
        public List<Objects>? Ressources { get { return _Ressources; } set { _Ressources = value; NotifyPropertyChanged(); } }
        private List<Objects>? _Quest { get; set; }
        public List<Objects>? Quest { get { return _Quest; } set { _Quest = value; NotifyPropertyChanged(); } }
        private List<Objects>? _Pierres { get; set; }
        public List<Objects>? Pierres { get { return _Pierres; } set { _Pierres = value; NotifyPropertyChanged(); } }
        private List<Objects>? _Runes { get; set; }
        public List<Objects>? Runes { get { return _Runes; } set { _Runes = value; NotifyPropertyChanged(); } }
        public Players? Player { get; set; }
        private Objects? _Coiffe { get; set; }
        public Objects? Coiffe { get { return _Coiffe; } set { _Coiffe = value; NotifyPropertyChanged(); } }
        private Objects? _Cac { get; set; }
        public Objects? Cac { get { return _Cac; } set { _Cac = value; NotifyPropertyChanged(); } }
        private Objects? _Cape { get; set; }
        public Objects? Cape { get { return _Cape; } set { _Cape = value; NotifyPropertyChanged(); } }
        private Objects? _Amulette { get; set; }
        public Objects? Amulette { get { return _Amulette; } set { _Amulette = value; NotifyPropertyChanged(); } }
        private Objects? _AnneauG { get; set; }
        public Objects? AnneauG { get { return _AnneauG; } set { _AnneauG = value; NotifyPropertyChanged(); } }
        private Objects? _AnneauD { get; set; }
        public Objects? AnneauD { get { return _AnneauD; } set { _AnneauD = value; NotifyPropertyChanged(); } }
        private Objects? _Ceinture { get; set; }
        public Objects? Ceinture { get { return _Ceinture; } set { _Ceinture = value; NotifyPropertyChanged(); } }
        private Objects? _Bottes { get; set; }
        public Objects? Bottes { get { return _Bottes; } set { _Bottes = value; NotifyPropertyChanged(); } }
        private Objects? _Famillier { get; set; }
        public Objects? Famillier { get { return _Famillier; } set { _Famillier = value; NotifyPropertyChanged(); } }
        private Objects? _Monture { get; set; }
        public Objects? Monture { get { return _Monture; } set { _Monture = value; NotifyPropertyChanged(); } }
        private Objects? _Dofus1 { get; set; }
        public Objects? Dofus1 { get { return _Dofus1; } set { _Dofus1 = value; NotifyPropertyChanged(); } }
        private Objects? _Dofus2 { get; set; }
        public Objects? Dofus2 { get { return _Dofus2; } set { _Dofus2 = value; NotifyPropertyChanged(); } }
        private Objects? _Dofus3 { get; set; }
        public Objects? Dofus3 { get { return _Dofus3; } set { _Dofus3 = value; NotifyPropertyChanged(); } }
        private Objects? _Dofus4 { get; set; }
        public Objects? Dofus4 { get { return _Dofus4; } set { _Dofus4 = value; NotifyPropertyChanged(); } }
        private Objects? _Dofus5 { get; set; }
        public Objects? Dofus5 { get { return _Dofus5; } set { _Dofus5 = value; NotifyPropertyChanged(); } }
        private Objects? _Dofus6 { get; set; }
        public Objects? Dofus6 { get { return _Dofus6; } set { _Dofus6 = value; NotifyPropertyChanged(); } }
        private Objects? _Bouclier { get; set; }
        public Objects? Bouclier { get { return _Bouclier; } set { _Bouclier = value; NotifyPropertyChanged(); } }
        private List<DisplayEffects>? _DisplayEffects { get; set; }
        public List<DisplayEffects>? DisplayEffects { get { return _DisplayEffects; } set { _DisplayEffects = value; NotifyPropertyChanged(); } }

        public Inventory(Players player)
        {
            InitializeComponent();
            DataContext = this;
            Player = player;
            Equipements = new();
            Consumables = new();
            Ressources = new();
            Quest = new();
            Runes = new();
            Pierres = new();
            InitData();
        }

        private async void InitData()
        {
            if (Player != null)
            {
                if (!string.IsNullOrEmpty(Player.Objets))
                {
                    foreach (string objectId in Player.Objets.Split('|'))
                    {
                        if (!string.IsNullOrEmpty(objectId))
                        {
                            Objects? objects = await SharedObjects.ObjectsRepository!.Get(Convert.ToInt32(objectId));
                            if (objects != null)
                            {
                                try {
                                    switch (objects.Position)
                                    {
                                        case 0:
                                            Amulette = objects;
                                            AmuletteImage.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\Resources\\Items\\" + objects.ItemTemplate!.Type + "\\" + objects.ItemTemplate!.GfxId + ".png"));
                                            AmuletteImage.ToolTip = new ToolTip() { Content = objects.ItemTemplate.Name };
                                            break;
                                        case 1:
                                            Cac = objects;
                                            CacImage.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\Resources\\Items\\" + objects.ItemTemplate!.Type + "\\" + objects.ItemTemplate!.GfxId + ".png"));
                                            CacImage.ToolTip = new ToolTip() { Content = objects.ItemTemplate.Name };
                                            break;
                                        case 2:
                                            AnneauG = objects;
                                            AnneauGImage.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\Resources\\Items\\" + objects.ItemTemplate!.Type + "\\" + objects.ItemTemplate!.GfxId + ".png"));
                                            AnneauGImage.ToolTip = new ToolTip() { Content = objects.ItemTemplate.Name };
                                            break;
                                        case 3:
                                            Ceinture = objects;
                                            CeintureImage.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\Resources\\Items\\" + objects.ItemTemplate!.Type + "\\" + objects.ItemTemplate!.GfxId + ".png"));
                                            CeintureImage.ToolTip = new ToolTip() { Content = objects.ItemTemplate.Name };
                                            break;
                                        case 4:
                                            AnneauD = objects;
                                            AnneauDImage.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\Resources\\Items\\" + objects.ItemTemplate!.Type + "\\" + objects.ItemTemplate!.GfxId + ".png"));
                                            AnneauDImage.ToolTip = new ToolTip() { Content = objects.ItemTemplate.Name };
                                            break;
                                        case 5:
                                            Bottes = objects;
                                            BottesImage.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\Resources\\Items\\" + objects.ItemTemplate!.Type + "\\" + objects.ItemTemplate!.GfxId + ".png"));
                                            BottesImage.ToolTip = new ToolTip() { Content = objects.ItemTemplate.Name };
                                            break;
                                        case 6:
                                            Coiffe = objects;
                                            CoiffeImage.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\Resources\\Items\\" + objects.ItemTemplate!.Type + "\\" + objects.ItemTemplate!.GfxId + ".png"));
                                            CoiffeImage.ToolTip = new ToolTip() { Content = objects.ItemTemplate.Name };
                                            break;
                                        case 7:
                                            Cape = objects;
                                            CapeImage.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\Resources\\Items\\" + objects.ItemTemplate!.Type + "\\" + objects.ItemTemplate!.GfxId + ".png"));
                                            CapeImage.ToolTip = new ToolTip() { Content = objects.ItemTemplate.Name };
                                            break;
                                        case 8:
                                            Famillier = objects;
                                            FamillierImage.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\Resources\\Items\\" + objects.ItemTemplate!.Type + "\\" + objects.ItemTemplate!.GfxId + ".png"));
                                            FamillierImage.ToolTip = new ToolTip() { Content = objects.ItemTemplate.Name };
                                            break;
                                        case 9:
                                        case 10:
                                        case 11:
                                        case 12:
                                        case 13:
                                        case 14:
                                            switch (objects.Position)
                                            {
                                                case 9:
                                                    Dofus1 = objects;
                                                    Dofus1Image.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\Resources\\Items\\" + objects.ItemTemplate!.Type + "\\" + objects.ItemTemplate!.GfxId + ".png"));
                                                    Dofus1Image.ToolTip = new ToolTip() { Content = objects.ItemTemplate.Name };
                                                    break;
                                                case 10:
                                                    Dofus2 = objects;
                                                    Dofus2Image.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\Resources\\Items\\" + objects.ItemTemplate!.Type + "\\" + objects.ItemTemplate!.GfxId + ".png"));
                                                    Dofus2Image.ToolTip = new ToolTip() { Content = objects.ItemTemplate.Name };
                                                    break;
                                                case 11:
                                                    Dofus3 = objects;
                                                    Dofus3Image.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\Resources\\Items\\" + objects.ItemTemplate!.Type + "\\" + objects.ItemTemplate!.GfxId + ".png"));
                                                    Dofus3Image.ToolTip = new ToolTip() { Content = objects.ItemTemplate.Name };
                                                    break;
                                                case 12:
                                                    Dofus4 = objects;
                                                    Dofus4Image.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\Resources\\Items\\" + objects.ItemTemplate!.Type + "\\" + objects.ItemTemplate!.GfxId + ".png"));
                                                    Dofus4Image.ToolTip = new ToolTip() { Content = objects.ItemTemplate.Name };
                                                    break;
                                                case 13:
                                                    Dofus5 = objects;
                                                    Dofus5Image.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\Resources\\Items\\" + objects.ItemTemplate!.Type + "\\" + objects.ItemTemplate!.GfxId + ".png"));
                                                    Dofus5Image.ToolTip = new ToolTip() { Content = objects.ItemTemplate.Name };
                                                    break;
                                                case 14:
                                                    Dofus6 = objects;
                                                    Dofus6Image.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\Resources\\Items\\" + objects.ItemTemplate!.Type + "\\" + objects.ItemTemplate!.GfxId + ".png"));
                                                    Dofus6Image.ToolTip = new ToolTip() { Content = objects.ItemTemplate.Name };
                                                    break;
                                            }
                                            break;
                                        case 15:
                                            Bouclier = objects;
                                            BouclierImage.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\Resources\\Items\\" + objects.ItemTemplate!.Type + "\\" + objects.ItemTemplate!.GfxId + ".png"));
                                            BouclierImage.ToolTip = new ToolTip() { Content = objects.ItemTemplate.Name };
                                            break;
                                        case 16:
                                            Monture = objects;
                                            MontureImage.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\Resources\\Items\\" + objects.ItemTemplate!.Type + "\\" + objects.ItemTemplate!.GfxId + ".png"));
                                            MontureImage.ToolTip = new ToolTip() { Content = objects.ItemTemplate.Name };
                                            break;
                                        default:
                                            if (Functions.IsEquipement(objects))
                                            {
                                                Equipements?.Add(objects);
                                                EquipementsDataGrid.Items.Refresh();
                                            }
                                            else if (Functions.IsConsumable(objects))
                                            {
                                                Consumables?.Add(objects);
                                                ConsomablesDataGrid.Items.Refresh();
                                            }
                                            else if (Functions.IsRessources(objects))
                                            {
                                                Ressources?.Add(objects);
                                                RessourcesDataGrid.Items.Refresh();
                                            }
                                            else if (Functions.IsQuestItem(objects))
                                            {
                                                Quest?.Add(objects);
                                                QuestDataGrid.Items.Refresh();
                                            }
                                            else if (Functions.IsRunes(objects))
                                            {
                                                Runes?.Add(objects);
                                                RunesDataGrid.Items.Refresh();
                                            }
                                            else if (Functions.IsCapture(objects))
                                            {
                                                Pierres?.Add(objects);
                                                PierresDataGrid.Items.Refresh();
                                            }
                                            break;
                                    }
                                }catch(Exception ex)
                                {
                                    MessageBox.Show("Possible Image non trouvé pour l'objet : " + objects.ItemTemplate!.Name,"Error", MessageBoxButton.OK, MessageBoxImage.Error);
                                    continue;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(sender is Image image)
            {
                switch(image.Name)
                {
                    case "CoiffeImage":
                        if(Coiffe != null)
                        {
                            LabelSelectedItem.Content = Coiffe.ItemTemplate!.Name + " (" + Coiffe.Id + ")";
                            DisplayEffects = Functions.ParseObjectEffects(Coiffe);
                            SelectedItemImage.Source = image.Source;
                        }
                        break;
                    case "CapeImage":
                        if (Cape != null)
                        {
                            LabelSelectedItem.Content = Cape.ItemTemplate!.Name + " (" + Cape.Id + ")";
                            DisplayEffects = Functions.ParseObjectEffects(Cape);
                            SelectedItemImage.Source = image.Source;
                        }
                        break;
                    case "AmuletteImage":
                        if (Amulette != null)
                        {
                            LabelSelectedItem.Content = Amulette.ItemTemplate!.Name + " (" + Amulette.Id + ")";
                            DisplayEffects = Functions.ParseObjectEffects(Amulette);
                            SelectedItemImage.Source = image.Source;
                        }
                        break;
                    case "AnneauGImage":
                        if (AnneauG != null)
                        {
                            LabelSelectedItem.Content = AnneauG.ItemTemplate!.Name + " (" + AnneauG.Id + ")";
                            DisplayEffects = Functions.ParseObjectEffects(AnneauG);
                            SelectedItemImage.Source = image.Source;
                        }
                        break;
                    case "AnneauDImage":
                        if (AnneauD != null)
                        {
                            LabelSelectedItem.Content = AnneauD.ItemTemplate!.Name + " (" + AnneauD.Id + ")";
                            DisplayEffects = Functions.ParseObjectEffects(AnneauD);
                            SelectedItemImage.Source = image.Source;
                        }
                        break;
                    case "CeintureImage":
                        if (Ceinture != null)
                        {
                            LabelSelectedItem.Content = Ceinture.ItemTemplate!.Name + " (" + Ceinture.Id + ")";
                            DisplayEffects = Functions.ParseObjectEffects(Ceinture);
                            SelectedItemImage.Source = image.Source;
                        }
                        break;
                    case "BottesImage":
                        if (Bottes != null)
                        {
                            LabelSelectedItem.Content = Bottes.ItemTemplate!.Name + " (" + Bottes.Id + ")";
                            DisplayEffects = Functions.ParseObjectEffects(Bottes);
                            SelectedItemImage.Source = image.Source;
                        }
                        break;
                    case "CacImage":
                        if (Cac != null)
                        {
                            LabelSelectedItem.Content = Cac.ItemTemplate!.Name + " (" + Cac.Id + ")";
                            DisplayEffects = Functions.ParseObjectEffects(Cac);
                            SelectedItemImage.Source = image.Source;
                        }
                        break;
                    case "BouclierImage":
                        if (Bouclier != null)
                        {
                            LabelSelectedItem.Content = Bouclier.ItemTemplate!.Name + " (" + Bouclier.Id + ")";
                            DisplayEffects = Functions.ParseObjectEffects(Bouclier);
                            SelectedItemImage.Source = image.Source;
                        }
                        break;
                    case "MontureImage":
                        if (Monture != null)
                        {
                            LabelSelectedItem.Content = Monture.ItemTemplate!.Name + " (" + Monture.Id + ")";
                            DisplayEffects = Functions.ParseObjectEffects(Monture);
                            SelectedItemImage.Source = image.Source;
                        }
                        break;
                    case "FamillierImage":
                        if (Famillier != null)
                        {
                            LabelSelectedItem.Content = Famillier.ItemTemplate!.Name + " (" + Famillier.Id + ")";
                            DisplayEffects = Functions.ParseObjectEffects(Famillier);
                            SelectedItemImage.Source = image.Source;
                        }
                        break;
                    case "Dofus1Image":
                        if(Dofus1 != null)
                        {
                            LabelSelectedItem.Content = Dofus1.ItemTemplate!.Name + " (" + Dofus1.Id + ")";
                            DisplayEffects = Functions.ParseObjectEffects(Dofus1);
                            SelectedItemImage.Source = image.Source;
                        }
                        break;
                    case "Dofus2Image":
                        if (Dofus2 != null)
                        {
                            LabelSelectedItem.Content = Dofus2.ItemTemplate!.Name + " (" + Dofus2.Id + ")";
                            DisplayEffects = Functions.ParseObjectEffects(Dofus2);
                            SelectedItemImage.Source = image.Source;
                        }
                        break;
                    case "Dofus3Image":
                        if (Dofus3 != null)
                        {
                            LabelSelectedItem.Content = Dofus3.ItemTemplate!.Name + " (" + Dofus3.Id + ")";
                            DisplayEffects = Functions.ParseObjectEffects(Dofus3);
                            SelectedItemImage.Source = image.Source;
                        }
                        break;
                    case "Dofus4Image":
                        if (Dofus4 != null)
                        {
                            LabelSelectedItem.Content = Dofus4.ItemTemplate!.Name + " (" + Dofus4.Id + ")";
                            DisplayEffects = Functions.ParseObjectEffects(Dofus4);
                            SelectedItemImage.Source = image.Source;
                        }
                        break;
                    case "Dofus5Image":
                        if (Dofus5 != null)
                        {
                            LabelSelectedItem.Content = Dofus5.ItemTemplate!.Name + " (" + Dofus5.Id + ")";
                            DisplayEffects = Functions.ParseObjectEffects(Dofus5);
                            SelectedItemImage.Source = image.Source;
                        }
                        break;
                    case "Dofus6Image":
                        if (Dofus6 != null)
                        {
                            LabelSelectedItem.Content = Dofus6.ItemTemplate!.Name + " (" + Dofus6.Id + ")";
                            DisplayEffects = Functions.ParseObjectEffects(Dofus6);
                            SelectedItemImage.Source = image.Source;
                        }
                        break;

                }
            }
        }
    }
}

using System.ComponentModel;
using System.Globalization;
using System.Resources;
using System.Threading;
using System.Windows.Data;

namespace HelpTool.Languages
{
    public class TranslationHelper : INotifyPropertyChanged
    {
        private CultureInfo? currentCulture = null;
        private readonly ResourceManager resManager = App.ResourceManager;
        public event PropertyChangedEventHandler? PropertyChanged;
        public string? this[string key] => resManager.GetString(key, currentCulture);
        public CultureInfo? CurrentCulture
        {
            get { return currentCulture; }
            set
            {
                SharedObjects.SelectedCulture = value;
                if (currentCulture != value)
                {
                    currentCulture = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(string.Empty));
                }
            }
        }
        public static TranslationHelper Instance { get; } = new();
    }
    public class LocExtension : Binding
    {
        public LocExtension(string name)
    : base($"[{name}]")
        {
            Mode = BindingMode.OneWay;
            Source = TranslationHelper.Instance;
        }
    }
    public static class LanguageSetter
    {
        public static void SetLanguage(CultureInfo culture)
        {
            TranslationHelper.Instance.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
            Thread.CurrentThread.CurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;
            Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencySymbol = "€";
            SharedObjects.SelectedCulture = culture;
        }
    }
}

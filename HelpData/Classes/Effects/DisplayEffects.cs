namespace HelpData.Classes.Effects
{
    public class DisplayEffects
    {
        public string? Text { get; set; }
        public ItemEffect? Effect { get; set; }
        public string Image { get { return "/Resources/Icons/" + Effect?.IconPath + ".png"; } }
    }
}

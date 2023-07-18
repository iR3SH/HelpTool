using System.IO;

namespace HelpData.Classes.Items
{
    public class ItemsGfxId
    {
        public int Id { get; set; }
        public int Type { get; set; }
        private string? _Path {get; set;}
        public string? ImagePath { get { return _Path; } set { _Path = Directory.GetCurrentDirectory() + "\\Resources\\Items\\" + Type + "\\" + value + ".png";  } }
    }
}

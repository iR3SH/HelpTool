using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Windows.Input;

namespace HelpData.Classes.Game
{
    [Table("objects")]
    public class Objects
    {
        [Key]
        public int Id { get; set; }
        public int? Template { get; set; }
        public ItemTemplate? ItemTemplate { get; set; }
        public int Quantity { get; set; }
        public int Position { get; set; }
        public string? Stats { get; set; }
        public int Puit { get; set; }
    }
}

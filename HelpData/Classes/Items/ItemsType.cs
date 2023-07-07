using System.ComponentModel.DataAnnotations;

namespace HelpData.Classes.Items
{
    public class ItemsType
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}

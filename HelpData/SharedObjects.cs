using HelpData;
using HelpData.Classes.Game;
using HelpData.IRepository;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Security.RightsManagement;
using System.Windows.Documents;

namespace HelpTool
{
    public static class SharedObjects
    {
        public static IServiceProvider? ServiceProvider { get; set; }
        public static HelpDbContext? Context { get; set; }
        public static IItemsRepository? ItemsRepository { get; set; }
        public static IMonstersRepository? MonstersRepository { get; set; }
        public static ISortsRepository? SortsRepository { get; set; }
        public static string? DbHost { get; set; }
        public static string? DbName { get; set; }
        public static string? DbUser { get; set; }
        public static string? DbPass { get; set; }
        public static CultureInfo? SelectedCulture { get; set; }
        public static bool? IsConfigured { get; set; }
        public static List<Sorts>? MobGradeSpellGetter { get; set; }
        public static List<int>? MobGradeSpellLevelGetter { get; set; }
    }

}

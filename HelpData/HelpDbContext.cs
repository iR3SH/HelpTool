using HelpData.Classes.Game;
using HelpTool;
using Microsoft.EntityFrameworkCore;

namespace HelpData
{
    public class HelpDbContext : DbContext
    {
        public HelpDbContext(DbContextOptions<HelpDbContext> options) : base(options) { }
        public DbSet<Monsters> Monsters { get; set; }
        public DbSet<ItemTemplate> Items { get; set; }
        public DbSet<Sorts> Sorts { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("Server="+ SharedObjects.DbHost +"; Database=" + SharedObjects.DbName + "; Uid=" + SharedObjects.DbUser + "; Pwd=" + SharedObjects.DbPass, b => b.MigrationsAssembly("HelpData"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Monsters>().Property(c => c.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<ItemTemplate>().Property(c => c.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Sorts>().Property(c => c.Id).ValueGeneratedOnAdd();
            base.OnModelCreating(modelBuilder);
        }
    }
}

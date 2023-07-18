using HelpData.Classes.Login;
using HelpTool;
using Microsoft.EntityFrameworkCore;

namespace HelpData
{
    public class LoginDbContext : DbContext
    {
        public LoginDbContext (DbContextOptions<LoginDbContext> options) : base(options) { }
        public DbSet<Accounts> Accounts { get; set; }
        public DbSet<Players> Players { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("Server=" + SharedObjects.DbHost + "; Database=" + SharedObjects.DbNameLogin + "; Uid=" + SharedObjects.DbUser + "; Pwd=" + SharedObjects.DbPass, b => b.MigrationsAssembly("HelpData"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Accounts>().Property(c => c.Guid).ValueGeneratedOnAdd();
            modelBuilder.Entity<Players>().Property(c => c.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Players>().HasOne(c => c.Nav_Accounts).WithMany(c => c.Nav_Players).HasForeignKey(c => c.Account);
            base.OnModelCreating(modelBuilder);
        }
    }
}

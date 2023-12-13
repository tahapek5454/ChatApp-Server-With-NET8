using ChatApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ChatApp.API.Contexts
{
    public class ChatDbContext: DbContext
    {
        public ChatDbContext(DbContextOptions options): base(options)
        {
            
        }

        public DbSet<Client> Celints { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>().HasOne(u => u.Client)
                .WithOne(c => c.User).HasForeignKey<Client>(c => c.UserId);
        }
    }
}

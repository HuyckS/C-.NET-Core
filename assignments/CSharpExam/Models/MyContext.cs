using Microsoft.EntityFrameworkCore;

namespace CSharpExam.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<ActivityEvent> Activities { get; set; }
    }
}
using Microsoft.EntityFrameworkCore;
using RosbankHelpCenter.API.Models;

namespace RosbankHelpCenter.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Value> Values { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Question> Questions { get; set; }
    }
}

using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace ConsoleBD {
    
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
    }
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users {get;set; } = null!; 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        { 
            optionsBuilder.UseSqlite($"Data Source={Directory.GetCurrentDirectory()}\\helloapp.db"); 
        } 
    }
    internal class Program {
        public static void Main(string[] args) {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseSqlite($"Data Source={Directory.GetCurrentDirectory()}\\test.db")
                .Options;
            // Act
            using (var context = new ApplicationContext())
            {
                context.Database.EnsureCreated(); 
                context.Users.Add(new User { Id = 1, Name = "John", Age = 25 }); 
                context.SaveChanges(); 
            }
            // Assert
            using (var context = new ApplicationContext())
            {
                var users = context.Users.ToList();
                Assert.AreEqual(1, users.Count);
                Assert.AreEqual("John", users[0].Name);
                Assert.AreEqual(25, users[0].Age);
            }
        }
    }

}
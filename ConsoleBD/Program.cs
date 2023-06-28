using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace ConsoleBD;

public class User {
    public int Id { get; set; }
    public string Name { get; set; }

    public override string ToString() {
        return $"{Id} {Name}";
    }
}

public class UserMaster {
    public int Id { get; set; }
    public string Name { get; set; }
    public List<int> Users { get; set; }

    public override string ToString() {
        return Users.Aggregate(" ", (current, user) => current + " " + user);
    }
}

public class ApplicationContext: DbContext {
    public DbSet<User> Users => Set<User>();
    public DbSet<UserMaster> UserMaster => Set<UserMaster>();

    public ApplicationContext() {
        Database.EnsureCreated();
    }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        optionsBuilder.UseSqlite("Data Source=hello.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.Entity<UserMaster>()
            .Property(p => p.Users)
            .HasConversion(
                v => string.Join(",", v),
                v => v.Split(',')
                    .Select(int.Parse)
                    .ToList());
    }
}

internal class Program {
    public static void Main(string[] args) {
        using (ApplicationContext context = new ApplicationContext()) {
            User tom = new User { Id = 1, Name = "Tom" };
            User alice = new User { Id = 2, Name = "Alice" };
            User bob = new User { Id = 3, Name = "Bob" };
            User roy = new User { Id = 4, Name = "Roy" };
            UserMaster greg = new UserMaster { Name = "Greg", Users = new List<int> { 1, 2, 3, 4 } };

            try {
                context.Users.Add(tom);
                context.Users.Add(alice);
                context.Users.Add(bob);
                context.Users.Add(roy);
                context.UserMaster.Add(greg);
                context.SaveChanges();
                Console.WriteLine("Объекты добавлены");
            }
            catch (Exception e) {
                Console.WriteLine(e);
            }


            try {
                List<User> users = context.Users.ToList();
                List<UserMaster> UserMasters = context.UserMaster.ToList();
                Console.WriteLine("Список объектов");
                foreach (UserMaster userMaster in UserMasters) {
                    Console.WriteLine(
                        $"ID:{userMaster.Id} имя {userMaster.Name} ползьзователи {userMaster.ToString()}");
                }

                foreach (User user in users) {
                    Console.WriteLine($"ID:{user.Id} имя {user.Name}");
                }

                var temp = context.Users.Where(u => u.Id == 1);
                var nexTemp = temp.First();
                Console.WriteLine(nexTemp);
            }
            catch (Exception e) {
                Console.WriteLine(e);
            }
        }
    }
}
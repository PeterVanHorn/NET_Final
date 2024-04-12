using System.Collections.Generic;
using System.Net.Sockets;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using VanHorn_NET_Final.Models;

namespace VanHorn_NET_Final.Models
{
    public class DomainContext : DbContext
    {
        public DbSet<Option> Options { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        public DomainContext(DbContextOptions<DomainContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Quiz>()
                .HasMany(e => e.Questions)
                .WithOne(q => q.Quiz);

            modelBuilder.Entity<Question>()
                .HasMany(e => e.Options)
                .WithOne(o => o.Question);

            modelBuilder.Entity<Teacher>()
                .HasMany(q => q.Quizzes)
                .WithOne(t => t.Teacher);

            IList<Teacher> teachers = new List<Teacher>();
            teachers.Add(new Teacher() { TeacherId = 1, FirstName = "Steve", LastName = "French", Password = "teach1" });
            teachers.Add(new Teacher() { TeacherId = 2, FirstName = "Mary", LastName = "Riddle", Password = "teach2" });

            modelBuilder.Entity<Teacher>().HasData(teachers);

            IList<Student> students = new List<Student>();
            students.Add(new Student() { StudentId = 1, firstName = "Bob", lastName = "Dole", TeacherId = 1 });
            students.Add(new Student() { StudentId = 2, firstName = "Geoffry", lastName = "Dahmer", TeacherId = 1 });

            modelBuilder.Entity<Student>().HasData(students);
        }
    }
}


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
            teachers.Add(new Teacher() { TeacherId = 1, FirstName = "Steve", LastName = "French", Quizzes = [], Students = [] });
            teachers.Add(new Teacher() { TeacherId = 2, FirstName = "Mary", LastName = "Riddle", Quizzes = [], Students = [] });

            modelBuilder.Entity<Teacher>().HasData(teachers);

            IList<Student> students = new List<Student>();
            students.Add(new Student() { StudentId = 1, firstName = "Bob", lastName = "Dole", Quizzes = [], TeacherId = 1 });
            students.Add(new Student() { StudentId = 2, firstName = "Geoffry", lastName = "Dahmer", Quizzes = [], TeacherId = 1 });

            modelBuilder.Entity<Student>().HasData(students);

            IList<Option> options = new List<Option>();
            options.Add(new Option() { OptionId = 1, OptionText = "2", Correct = true, QuestionId = 1 });
            options.Add(new Option() { OptionId = 2, OptionText = "3", Correct = false, QuestionId = 1 });
            options.Add(new Option() { OptionId = 3, OptionText = "4", Correct = false, QuestionId = 1 });
            options.Add(new Option() { OptionId = 4, OptionText = "5", Correct = false, QuestionId = 1 });

            modelBuilder.Entity<Option>().HasData(options);

            IList<Question> questions = new List<Question>();
            questions.Add(new Question() { QuestionId = 1, QuestionText = "1 + 1 =", Options = [], QuizId = 1 });
            questions.Add(new Question() { QuestionId = 2, QuestionText = "2 + 2 = ", Options = [], QuizId = 1 });
            questions.Add(new Question() { QuestionId = 3, QuestionText = "Pick a word: ", Options = [], QuizId = 2 });

            modelBuilder.Entity<Question>().HasData(questions);

            IList<Quiz> quizzes = new List<Quiz>();
            quizzes.Add(new Quiz() { QuizId = 1, QuizName = "MathQuiz", Questions = [], TeacherId = 1 });
            quizzes.Add(new Quiz() { QuizId = 2, QuizName = "WordQuiz", Questions = [], TeacherId = 2 });

            modelBuilder.Entity<Quiz>().HasData(quizzes);
        }
    }
}


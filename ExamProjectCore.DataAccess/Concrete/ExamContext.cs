using ExamProjectCore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExamProjectCore.DataAccess.Concrete
{
    public class ExamContext : DbContext
    {

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server=DESKTOP-JLJI4GI\SQLEXPRESS;Database=ExamCoreDb;User id=sa;Password=Password1");
        //}

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<ProductCategory>()
        //            .HasKey(c => new { c.CategoryId, c.ProductId });
        //}

        public DbSet<Exam> Exams { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<CorrectAnswer> CorrectAnswers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
            //.UseSqlite(@"Data Source=ExamSqliteDB.db;");
            .UseSqlite(@"Data Source=C:\sqlite3\ExamSqliteDB.db;");
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
            //Database.Migrate();

            //.UseSqlite("Filename=./ExamSqliteDB.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Exam>().ToTable("Exams");
            modelBuilder.Entity<Question>().ToTable("Questions");
            modelBuilder.Entity<Option>().ToTable("Options");
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<CorrectAnswer>().ToTable("CorrectAnswers");
        }


    }
}

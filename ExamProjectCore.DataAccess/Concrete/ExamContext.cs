using ExamProjectCore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExamProjectCore.DataAccess.Concrete
{
    public class ExamContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-JLJI4GI\SQLEXPRESS;Database=ExamCoreDb;User id=sa;Password=Password1");
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<ProductCategory>()
        //            .HasKey(c => new { c.CategoryId, c.ProductId });
        //}

        public DbSet<Exam> Exam { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<CorrectAnswer> CorrectAnswers { get; set; }
    }
}

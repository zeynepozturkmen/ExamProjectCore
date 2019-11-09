﻿using ExamProjectCore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExamProjectCore.DataAccess.Concrete
{
    public class ExamContext : DbContext
    {
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<CorrectAnswer> CorrectAnswers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
            .UseSqlite(@"Data Source=C:\sqlite3\ExamSqliteDB.db;");
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

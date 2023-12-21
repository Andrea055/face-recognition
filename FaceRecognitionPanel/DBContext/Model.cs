using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
// using MySQL.EntityFrameworkCore.Extensions;

namespace DBContext
{
    public class FaceContext : DbContext
    {
        public DbSet<Utenti> Utenti { get; set; }
        public DbSet<Classi> Classi { get; set; }

        public string DbPath { get; }

        static readonly string connectionString = "Server=localhost;Database=FaceRecognition;User ID=FaceRecognition;Password=faceqwe123";

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    }
}
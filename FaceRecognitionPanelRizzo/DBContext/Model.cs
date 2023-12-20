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

        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     base.OnModelCreating(modelBuilder);

        //     modelBuilder.Entity<Utenti>(entity =>
        //     {
        //         entity.HasKey(e => e.Id);
        //     });

        //     modelBuilder.Entity<Classi>(entity =>
        //     {
        //         entity.HasKey(e => e.Id);
        //     });
        // }
    }
}

public class Utenti
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Cognome { get; set; }
    public int Id_classe { get; set; }
}

public class Classi
{
    public int Id { get; set; }
    public string Sezione { get; set; }
}
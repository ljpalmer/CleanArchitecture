using CleanArchitecture.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Data
{
    public class StreamerDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder
                   .UseSqlServer(@"Data Source = DESKTOP-RD4881M\SQLEXPRESS; initial catalog = Streamer; user id = sa; password = 123456 ;Trust Server Certificate=true")
                   .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name}, Microsoft.Extensions.Logging.LogLevel.Information)
                   .EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) { 
            modelBuilder.Entity<Streamer>()
                .HasMany(m => m.Videos)
                .WithOne(m=> m.Streamer)
                .HasForeignKey(m=> m.StreamerId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict); //Delete on Cascade

            modelBuilder.Entity<Video>()
                .HasMany(m => m.Actores)
                .WithMany(t => t.Videos)
                .UsingEntity<VideoActor>(
                    pt => pt.HasKey(e => new { e.ActorId, e.VideoId })
                );

            modelBuilder.Entity<Actor>()
                .HasMany(m => m.Videos);

            modelBuilder.Entity<Director>();
                
                


        }
        public DbSet<Streamer>? Streamers { get; set; }
        public DbSet<Video>? Videos { get; set; }
        public DbSet<Actor> Actores { get; set; }
        public DbSet<Director>? Directores { get; set; }
    }
}

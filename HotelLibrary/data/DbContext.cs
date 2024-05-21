using HotelLibrary.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLibrary.data
{
    public class HotellContext : DbContext
    {
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<TaskModel> Tasks { get; set; }


        public HotellContext(DbContextOptions<HotellContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Room>()
            .Property(r => r.Name)
            .IsRequired()
            .HasMaxLength(100);

        modelBuilder.Entity<Reservation>()
            .HasOne(r => r.Room)
            .WithMany()
            .HasForeignKey(r => r.RoomId);

        modelBuilder.Entity<Room>()
            .HasMany(r => r.Tasks)
            .WithOne(t => t.Room)
            .HasForeignKey(t => t.RoomId);

            modelBuilder.Entity<Room>().HasData(
                    new Room { Id = 1, Name = "Deluxe Suite", Beds = 2, Size = "Large", IsAvailable = true },
                    new Room { Id = 2, Name = "Standard Room", Beds = 1, Size = "Medium", IsAvailable = true }
                );

            // Seed Reservation data
            modelBuilder.Entity<Reservation>().HasData(
                new Reservation { Id = 1, RoomId = 1, CheckInDate = DateTime.Now.AddDays(1), CheckOutDate = DateTime.Now.AddDays(3), CustomerName = "John Doe" }
            );
            modelBuilder.Entity<TaskModel>().HasData(
            new TaskModel { Id = 1, RoomId = 1, TaskType = "Cleaning", Description = "Clean the Deluxe Suite", Status = "New", CreatedDate = DateTime.Now },
            new TaskModel { Id = 2, RoomId = 2, TaskType = "Maintenance", Description = "Fix the air conditioner", Status = "New", CreatedDate = DateTime.Now }
        );

            
        }
    }

}
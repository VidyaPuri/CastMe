using CastMe.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CastMe.API.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base (options) 
        {

        }

        public DbSet<TeamMember> TeamMembers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TeamMember>()
                .HasData(new
                {
                    TeamMemberId = 1,
                    FirstName = "Gaj",
                    LastName = "Črešnik",
                    Role = Role.Camera,
                    Email = "gc@gmail.com",
                    PhoneNumber = "040-123-456",
                    IgHandle = "instagram\\gajsl",
                    FbHandle = "facebook\\gajsl",
                    Equipment = "Kamera - Sony, Studijske luči",
                    CreationDate = DateTime.Now
                }) ;

            modelBuilder.Entity<TeamMember>()
                .HasData(new
                {
                    TeamMemberId = 2,
                    FirstName = "Bob",
                    LastName = "Sabath",
                    Role = Role.Producer,
                    Email = "bs@gmail.com",
                    PhoneNumber = "040-334-555",
                    IgHandle = "instagram\\bobby",
                    FbHandle = "facebook\\bobby",
                    Equipment = "",
                    CreationDate = DateTime.Now
                });
            modelBuilder.Entity<TeamMember>()
                .HasData(new
                {
                    TeamMemberId = 3,
                    FirstName = "Annie",
                    LastName = "Buzzer",
                    Role = Role.MakeUp,
                    Email = "ab@gmail.com",
                    PhoneNumber = "031-435-725",
                    IgHandle = "instagram\\annieMUA",
                    FbHandle = "facebook\\annieMUA",
                    Equipment = "Make up equipment",
                    CreationDate = DateTime.Now
                });
            modelBuilder.Entity<TeamMember>()
                .HasData(new
                {
                    TeamMemberId = 4,
                    FirstName = "Zdravko",
                    LastName = "Pravnyk",
                    Role = Role.Lights,
                    Email = "luckar@gmail.com",
                    PhoneNumber = "041-465-725",
                    IgHandle = "instagram\\luckarZdravko",
                    FbHandle = "facebook\\luckarZdravko",
                    Equipment = "Lights, Dimmers, ..",
                    CreationDate = DateTime.Now
                });
        }
    }

}

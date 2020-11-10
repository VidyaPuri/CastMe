using ZenProject.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using ZenProject.API.Data.Entities;



namespace ZenProject.API.Data
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
                    Role = ZenProject.Data.Entities.Enums.Roles.Camera,
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
                    Role = ZenProject.Data.Entities.Enums.Roles.Producer,
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
                    Role = ZenProject.Data.Entities.Enums.Roles.MakeUp,
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
                    Role = ZenProject.Data.Entities.Enums.Roles.Lights,
                    Email = "luckar@gmail.com",
                    PhoneNumber = "041-465-725",
                    IgHandle = "instagram\\luckarZdravko",
                    FbHandle = "facebook\\luckarZdravko",
                    Equipment = "Lights, Dimmers, ..",
                    CreationDate = DateTime.Now
                });
        }


        public DbSet<ZenProject.API.Data.Entities.Staff> Staff { get; set; }
    }

}

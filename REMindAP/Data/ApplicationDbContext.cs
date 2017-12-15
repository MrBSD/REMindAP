using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using REMindAP.Core.Domain;
using REMindAP.Models;

namespace REMindAP.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public DbSet<Reminder> Reminders { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<ReminderType> ReminderTypes { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Reminder>()
                .Property(r => r.Title)
                .IsRequired()
                .HasMaxLength(255);

            builder.Entity<Reminder>()
                .Property(r => r.EventDate)
                .IsRequired();

            builder.Entity<ReminderTag>()
                .HasKey(rt => new {rt.ReminderId, rt.TagId});

            builder.Entity<ReminderTag>()
                .HasOne(rt => rt.Reminder)
                .WithMany(r => r.ReminderTags)
                .HasForeignKey(rt => rt.ReminderId);

            builder.Entity<ReminderTag>()
                .HasOne(rt => rt.Tag)
                .WithMany(t => t.ReminderTags)
                .HasForeignKey(rt => rt.TagId);

            builder.Entity<ReminderType>()
                .Property(r => r.Type)
                .IsRequired()
                .HasMaxLength(255);
          
            builder.Entity<Tag>()
                .Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(255);

            builder.Entity<Tag>()
                .Property(t => t.Color)
                .HasMaxLength(6)
                .HasDefaultValue("00ff00");


            base.OnModelCreating(builder);


            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}

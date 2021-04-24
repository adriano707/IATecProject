using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Schedule.Domain;
using Schedule.Domain.Event;
using Schedule.Domain.Shedule;
using Schedule.Domain.User;

namespace Schedule.Data
{
    public class ScheduleContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Event> Event { get; set; }
        public DbSet<Domain.Schedule.Schedule> Schedule { get; set; }
        public DbSet<ScheduleEvent> ScheduleEvent { get; set; }

        public ScheduleContext() { }

        public ScheduleContext(DbContextOptions<ScheduleContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }

}

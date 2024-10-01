using Microsoft.EntityFrameworkCore;
using TestTask.Models;

namespace TestTask.Infrastructure
{
    public class EventContext : DbContext
    {
        public DbSet<Event> Events { get; set; }

        public string DbPath { get; }

        public EventContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Join(path, "events.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
}

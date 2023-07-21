using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace EnglishAPI.Model
{
    public class MyDbContext: DbContext
    {
        
        public DbSet<User> Users { get; set; }
        public string ConnectionString { get; }

        public MyDbContext()
        {                    
            ConnectionString = Config.ConnectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseMySql(ConnectionString, ServerVersion.AutoDetect(ConnectionString));
        }
    }
}

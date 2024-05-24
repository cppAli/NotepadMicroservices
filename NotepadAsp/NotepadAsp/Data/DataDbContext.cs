using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using NotepadAsp.Models;
using NotesApp.Models;

namespace NotepadAsp.Data
{
    public class DataDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DataDbContext(DbContextOptions<DataDbContext> options) : base(options) 
        {
            try
            {
                var databaseCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
                if(databaseCreator != null)
                {
                    //Create db if cannot connect
                    if (!databaseCreator.CanConnect()) databaseCreator.Create();

                    //Create table if no tables exits
                    if(!databaseCreator.HasTables()) databaseCreator.CreateTables();
                }
            } 
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        
        }
    }
}

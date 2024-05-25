using Microsoft.EntityFrameworkCore;
using NotepadAsp.Data;

namespace NotepadAsp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();
            builder.Services.AddControllers();

            /* Database Context Dependency Injection*/
            var dbHost = "localhast";
            var dbName = "dms_notes";
            var dbPassword = "pass";

            var connectionString = $"server={dbHost};port=3306;database={dbName};user-root;password={dbPassword}";
            builder.Services.AddDbContext<DataDbContext>(o => o.UseMySQL(connectionString));

            // ======= //

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}

using System.Data.Entity;

namespace Books_WebApp.Models.Data
{
    public class AppDbContext: DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Book> Books { get; set; }
        public AppDbContext() : base("connectionDefault")
        {
                
        }
    }
}
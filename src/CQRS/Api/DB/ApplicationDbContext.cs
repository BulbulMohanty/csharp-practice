using Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.DB
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) { }

        public DbSet<Product> Products => Set<Product>();
        public DbSet<TodoItem> TodoItems => Set<TodoItem>();
    }
}

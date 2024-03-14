using cadastroWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace cadastroWeb.DataContext
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options): base(options) 
        { }

        public DbSet<FuncModel> Funcionarios { get; set; }
    }
}

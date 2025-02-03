using Microsoft.EntityFrameworkCore;

namespace Esthiber_Valentin_P1_AP1.DAL
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<Models.Modelo> Modelos { get; set; }
    }
}

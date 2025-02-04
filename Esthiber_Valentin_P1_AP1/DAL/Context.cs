using Esthiber_Valentin_P1_AP1.Models;
using Microsoft.EntityFrameworkCore;

namespace Esthiber_Valentin_P1_AP1.DAL
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<Modelos> Modelo { get; set; }
    }
}

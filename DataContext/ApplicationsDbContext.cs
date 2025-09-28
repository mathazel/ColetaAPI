using ColetaAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace ColetaAPI.DataContext
{
    public class ApplicationsDbContext : DbContext

    {
        public ApplicationsDbContext(DbContextOptions<ApplicationsDbContext> options) : base(options)
        {
        }


        public DbSet<ColetaModel> Coletas { get; set; }
    }
}

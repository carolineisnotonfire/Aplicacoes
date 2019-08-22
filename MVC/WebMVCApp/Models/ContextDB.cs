using System.Data.Entity;

namespace WebMVCApp.Models
{
    public class ContextDB : DbContext
    {

        public DbSet<Pessoa> pessoas { get; set; }
        public DbSet<Carro> carros { get; set; }

    }
}
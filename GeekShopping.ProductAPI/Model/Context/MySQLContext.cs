using GGstore.ProductAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace GGstore.ProductAPI.Model.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext() {}
        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options) {}

        public DbSet<Game> Games { get; set; }
        public DbSet<Plataforma> Plataformas { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<GameGenero> GameGeneros { get; set; }
        public DbSet<GamePlataforma> GamePlataformas { get; set; }

    }
}

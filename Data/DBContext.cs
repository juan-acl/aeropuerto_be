using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Aeropuerto.Backend.Data
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
        }

        public DbSet<AeropuertoModel> Aeropuertos { get; set; }
    }
}
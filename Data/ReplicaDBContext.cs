using Microsoft.EntityFrameworkCore;

namespace Aeropuerto.Backend.Data
{
    public class ReplicaDBContext : DBContext
    {
        public ReplicaDBContext(DbContextOptions<ReplicaDBContext> options) : base(options)
        {
        }
    }
}

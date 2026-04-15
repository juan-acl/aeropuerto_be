using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Aeropuerto.Backend.Services
{
    public class MantenimientoAvionService : IMantenimientoAvionService
    {
        private readonly DBContext _context;

        public MantenimientoAvionService(DBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MantenimientoAvionModel>> GetMantenimientosAsync()
        {
            return await _context.MantenimientosAviones.ToListAsync();
        }

        public async Task<MantenimientoAvionModel> GetMantenimientoByIdAsync(int id)
        {
            var entity = await _context.MantenimientosAviones.FindAsync(id);
            if (entity == null) return null!;
            return entity;
        }

        public async Task<MantenimientoAvionModel> AddMantenimientoAsync(MantenimientoAvionModel mantenimiento)
        {
            _context.MantenimientosAviones.Add(mantenimiento);
            await _context.SaveChangesAsync();
            return mantenimiento;
        }
    }
}

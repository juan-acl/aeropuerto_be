using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models.Finanzas;

namespace Aeropuerto.Backend.Services.Finanzas
{
    public class FinanzasServiceMock : IFinanzasService
    {
        private readonly List<Proveedor> _proveedores = new()
        {
            new() { IdProveedor = 1, NombreProveedor = "Combustibles del Pacifico S.A.", RucNit = "123456-7", TipoProveedor = "Combustible", Telefono = "2250-1000", Email = "ventas@combustipacifico.gt", Direccion = "Zona 12 Guatemala", Pais = "Guatemala", Activo = 1 },
            new() { IdProveedor = 2, NombreProveedor = "TechAero Solutions", RucNit = "789012-3", TipoProveedor = "Tecnologia", Telefono = "2260-5000", Email = "info@techaero.com", Direccion = "Miami, FL", Pais = "Estados Unidos", Activo = 1 },
            new() { IdProveedor = 3, NombreProveedor = "Limpieza Aeroportuaria GT", RucNit = "456789-0", TipoProveedor = "Servicios Generales", Telefono = "2270-3000", Email = "operaciones@limpiezagt.gt", Direccion = "Zona 13 Guatemala", Pais = "Guatemala", Activo = 1 },
            new() { IdProveedor = 4, NombreProveedor = "Catering Sky Foods", RucNit = "321654-8", TipoProveedor = "Catering", Telefono = "2280-7000", Email = "pedidos@skyfoods.gt", Direccion = "Zona 11 Guatemala", Pais = "Guatemala", Activo = 1 }
        };

        private readonly List<TasaAeroportuaria> _tasas = new()
        {
            new() { IdTasa = 1, NombreTasa = "Tasa de Embarque Internacional", Descripcion = "Cobro por uso de instalaciones en vuelos internacionales", TipoTasa = "Embarque", Monto = 30, Moneda = "USD", AplicaA = "Pasajeros Internacionales", Activo = 1 },
            new() { IdTasa = 2, NombreTasa = "Tasa de Embarque Nacional", Descripcion = "Cobro por uso de instalaciones en vuelos nacionales", TipoTasa = "Embarque", Monto = 50, Moneda = "GTQ", AplicaA = "Pasajeros Nacionales", Activo = 1 },
            new() { IdTasa = 3, NombreTasa = "Tasa de Seguridad", Descripcion = "Cobro por servicios de seguridad aeroportuaria", TipoTasa = "Seguridad", Monto = 15, Moneda = "USD", AplicaA = "Todos los Pasajeros", Activo = 1 },
            new() { IdTasa = 4, NombreTasa = "Tasa de Uso de Pista", Descripcion = "Cobro por aterrizaje y despegue", TipoTasa = "Operacional", Monto = 850, Moneda = "USD", AplicaA = "Aerolineas", Activo = 1 }
        };

        private readonly List<CuentaBancaria> _cuentas = new()
        {
            new() { IdCuenta = 1, NombreBanco = "Banco Industrial", NumeroCuenta = "001-12345678-9", TipoCuenta = "Monetaria", Moneda = "GTQ", Titular = "Aeropuerto Internacional La Aurora", Activo = 1 },
            new() { IdCuenta = 2, NombreBanco = "Banco Industrial", NumeroCuenta = "001-98765432-1", TipoCuenta = "Monetaria", Moneda = "USD", Titular = "Aeropuerto Internacional La Aurora", Activo = 1 },
            new() { IdCuenta = 3, NombreBanco = "G&T Continental", NumeroCuenta = "002-55544433-2", TipoCuenta = "Ahorro", Moneda = "GTQ", Titular = "Fondo de Mantenimiento Aeroportuario", Activo = 1 }
        };

        public Task<List<Proveedor>> GetAllProveedoresAsync() => Task.FromResult(_proveedores);
        public Task<Proveedor?> GetProveedorByIdAsync(int id) => Task.FromResult(_proveedores.FirstOrDefault(x => x.IdProveedor == id));
        public Task InsertProveedorAsync(Proveedor p) { p.IdProveedor = _proveedores.Count > 0 ? _proveedores.Max(x => x.IdProveedor) + 1 : 1; _proveedores.Add(p); return Task.CompletedTask; }
        public Task UpdateProveedorAsync(Proveedor p) { var i = _proveedores.FindIndex(x => x.IdProveedor == p.IdProveedor); if (i >= 0) _proveedores[i] = p; return Task.CompletedTask; }
        public Task DeleteProveedorAsync(int id) { _proveedores.RemoveAll(x => x.IdProveedor == id); return Task.CompletedTask; }

        public Task<List<TasaAeroportuaria>> GetAllTasasAsync() => Task.FromResult(_tasas);
        public Task<TasaAeroportuaria?> GetTasaByIdAsync(int id) => Task.FromResult(_tasas.FirstOrDefault(x => x.IdTasa == id));
        public Task InsertTasaAsync(TasaAeroportuaria t) { t.IdTasa = _tasas.Count > 0 ? _tasas.Max(x => x.IdTasa) + 1 : 1; _tasas.Add(t); return Task.CompletedTask; }
        public Task UpdateTasaAsync(TasaAeroportuaria t) { var i = _tasas.FindIndex(x => x.IdTasa == t.IdTasa); if (i >= 0) _tasas[i] = t; return Task.CompletedTask; }
        public Task DeleteTasaAsync(int id) { _tasas.RemoveAll(x => x.IdTasa == id); return Task.CompletedTask; }

        public Task<List<CuentaBancaria>> GetAllCuentasAsync() => Task.FromResult(_cuentas);
        public Task<CuentaBancaria?> GetCuentaByIdAsync(int id) => Task.FromResult(_cuentas.FirstOrDefault(x => x.IdCuenta == id));
        public Task InsertCuentaAsync(CuentaBancaria c) { c.IdCuenta = _cuentas.Count > 0 ? _cuentas.Max(x => x.IdCuenta) + 1 : 1; _cuentas.Add(c); return Task.CompletedTask; }
        public Task UpdateCuentaAsync(CuentaBancaria c) { var i = _cuentas.FindIndex(x => x.IdCuenta == c.IdCuenta); if (i >= 0) _cuentas[i] = c; return Task.CompletedTask; }
        public Task DeleteCuentaAsync(int id) { _cuentas.RemoveAll(x => x.IdCuenta == id); return Task.CompletedTask; }
    }
}

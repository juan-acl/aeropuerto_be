using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class SlotsAeropuertoService : ISlotAeropuertoService
    {
        private readonly DBContext _context;

        public SlotsAeropuertoService(DBContext context)
        {
            _context = context;
        }

        public async Task<bool> Insertar(SlotsAeropuerto m)
        {
            var parametros = new[] {
                new OracleParameter("p_i_da_er_ol_in_ea", (object?)m.IdAerolinea ?? DBNull.Value),
                new OracleParameter("p_f_ec_ha_sl_ot", (object?)m.FechaSlot ?? DBNull.Value),
                new OracleParameter("p_h_or_as_lo_t", (object?)m.HoraSlot ?? DBNull.Value),
                new OracleParameter("p_t_ip_oo_pe_ra_ci_on", (object?)m.TipoOperacion ?? DBNull.Value),
                new OracleParameter("p_i_dv_ue_lo_as_ig_na_do", (object?)m.IdVueloAsignado ?? DBNull.Value),
                new OracleParameter("p_e_st_ad_os_lo_t", (object?)m.EstadoSlot ?? DBNull.Value),
                new OracleParameter("p_f_ec_ha_as_ig_na_ci_on", (object?)m.FechaAsignacion ?? DBNull.Value),
                new OracleParameter("p_a_si_gn_ad_op_or", (object?)m.AsignadoPor ?? DBNull.Value),
                new OracleParameter("p_f_ec_ha_li_be_ra_ci_on", (object?)m.FechaLiberacion ?? DBNull.Value),
                new OracleParameter("p_m_ot_iv_oc_an_ce_la_ci_on", (object?)m.MotivoCancelacion ?? DBNull.Value),
            };

            string sql = "BEGIN pkg_slots_aeropuerto.insert_aeropuerto(:p_i_da_er_ol_in_ea, :p_f_ec_ha_sl_ot, :p_h_or_as_lo_t, :p_t_ip_oo_pe_ra_ci_on, :p_i_dv_ue_lo_as_ig_na_do, :p_e_st_ad_os_lo_t, :p_f_ec_ha_as_ig_na_ci_on, :p_a_si_gn_ad_op_or, :p_f_ec_ha_li_be_ra_ci_on, :p_m_ot_iv_oc_an_ce_la_ci_on); END;";
            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return true;
        }

        public async Task<bool> Actualizar(int id, SlotsAeropuerto m)
        {
            var parametros = new[] {
                new OracleParameter("p_i_ds_lo_t", (object?)m.IdSlot ?? DBNull.Value),
                new OracleParameter("p_i_da_er_ol_in_ea", (object?)m.IdAerolinea ?? DBNull.Value),
                new OracleParameter("p_f_ec_ha_sl_ot", (object?)m.FechaSlot ?? DBNull.Value),
                new OracleParameter("p_h_or_as_lo_t", (object?)m.HoraSlot ?? DBNull.Value),
                new OracleParameter("p_t_ip_oo_pe_ra_ci_on", (object?)m.TipoOperacion ?? DBNull.Value),
                new OracleParameter("p_i_dv_ue_lo_as_ig_na_do", (object?)m.IdVueloAsignado ?? DBNull.Value),
                new OracleParameter("p_e_st_ad_os_lo_t", (object?)m.EstadoSlot ?? DBNull.Value),
                new OracleParameter("p_f_ec_ha_as_ig_na_ci_on", (object?)m.FechaAsignacion ?? DBNull.Value),
                new OracleParameter("p_a_si_gn_ad_op_or", (object?)m.AsignadoPor ?? DBNull.Value),
                new OracleParameter("p_f_ec_ha_li_be_ra_ci_on", (object?)m.FechaLiberacion ?? DBNull.Value),
                new OracleParameter("p_m_ot_iv_oc_an_ce_la_ci_on", (object?)m.MotivoCancelacion ?? DBNull.Value),
            };

            string sql = "BEGIN pkg_slots_aeropuerto.update_aeropuerto(:p_i_ds_lo_t, :p_i_da_er_ol_in_ea, :p_f_ec_ha_sl_ot, :p_h_or_as_lo_t, :p_t_ip_oo_pe_ra_ci_on, :p_i_dv_ue_lo_as_ig_na_do, :p_e_st_ad_os_lo_t, :p_f_ec_ha_as_ig_na_ci_on, :p_a_si_gn_ad_op_or, :p_f_ec_ha_li_be_ra_ci_on, :p_m_ot_iv_oc_an_ce_la_ci_on); END;";
            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var sql = "BEGIN pkg_slots_aeropuerto.delete_aeropuerto(:p_id_slot); END;";
            await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id_slot", id));
            return true;
        }

        public async Task<List<SlotsAeropuerto>> ListarTodo()
        {
            return await _context.Set<SlotsAeropuerto>().ToListAsync();
        }

        public async Task<SlotsAeropuerto?> ObtenerPorId(int id)
        {
            return await _context.Set<SlotsAeropuerto>().FirstOrDefaultAsync(x => x.IdSlot == id);
        }
    }
}

using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class AsignacionPistasTiempoRealService : IAsigPistasTiempoRealService
    {
        private readonly DBContext _context;

        public AsignacionPistasTiempoRealService(DBContext context)
        {
            _context = context;
        }

        public async Task<bool> Insertar(AsignacionPistasTiempoReal m)
        {
            var parametros = new[] {
                new OracleParameter("p_i_dp_is_ta", (object?)m.IdPista ?? DBNull.Value),
                new OracleParameter("p_i_dv_ue_lo", (object?)m.IdVuelo ?? DBNull.Value),
                new OracleParameter("p_t_ip_oo_pe_ra_ci_on", (object?)m.TipoOperacion ?? DBNull.Value),
                new OracleParameter("p_f_ec_ha_ho_ra_as_ig_na_ci_on", (object?)m.FechaHoraAsignacion ?? DBNull.Value),
                new OracleParameter("p_h_or_ai_ni_ci_oe_st_im_ad_a", (object?)m.HoraInicioEstimada ?? DBNull.Value),
                new OracleParameter("p_h_or_af_in_es_ti_ma_da", (object?)m.HoraFinEstimada ?? DBNull.Value),
                new OracleParameter("p_h_or_ai_ni_ci_or_ea_l", (object?)m.HoraInicioReal ?? DBNull.Value),
                new OracleParameter("p_h_or_af_in_re_al", (object?)m.HoraFinReal ?? DBNull.Value),
                new OracleParameter("p_e_st_ad_oa_si_gn_ac_io_n", (object?)m.EstadoAsignacion ?? DBNull.Value),
                new OracleParameter("p_a_si_gn_ad_op_or", (object?)m.AsignadoPor ?? DBNull.Value),
                new OracleParameter("p_o_bs_er_va_ci_on_es", (object?)m.Observaciones ?? DBNull.Value),
            };

            string sql = "BEGIN pkg_asignacion_pistas.insert_pistas(:p_i_dp_is_ta, :p_i_dv_ue_lo, :p_t_ip_oo_pe_ra_ci_on, :p_f_ec_ha_ho_ra_as_ig_na_ci_on, :p_h_or_ai_ni_ci_oe_st_im_ad_a, :p_h_or_af_in_es_ti_ma_da, :p_h_or_ai_ni_ci_or_ea_l, :p_h_or_af_in_re_al, :p_e_st_ad_oa_si_gn_ac_io_n, :p_a_si_gn_ad_op_or, :p_o_bs_er_va_ci_on_es); END;";
            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return true;
        }

        public async Task<bool> Actualizar(int id, AsignacionPistasTiempoReal m)
        {
            var parametros = new[] {
                new OracleParameter("p_i_da_si_gn_ac_io_np_is_ta", (object?)m.IdAsignacionPista ?? DBNull.Value),
                new OracleParameter("p_i_dp_is_ta", (object?)m.IdPista ?? DBNull.Value),
                new OracleParameter("p_i_dv_ue_lo", (object?)m.IdVuelo ?? DBNull.Value),
                new OracleParameter("p_t_ip_oo_pe_ra_ci_on", (object?)m.TipoOperacion ?? DBNull.Value),
                new OracleParameter("p_f_ec_ha_ho_ra_as_ig_na_ci_on", (object?)m.FechaHoraAsignacion ?? DBNull.Value),
                new OracleParameter("p_h_or_ai_ni_ci_oe_st_im_ad_a", (object?)m.HoraInicioEstimada ?? DBNull.Value),
                new OracleParameter("p_h_or_af_in_es_ti_ma_da", (object?)m.HoraFinEstimada ?? DBNull.Value),
                new OracleParameter("p_h_or_ai_ni_ci_or_ea_l", (object?)m.HoraInicioReal ?? DBNull.Value),
                new OracleParameter("p_h_or_af_in_re_al", (object?)m.HoraFinReal ?? DBNull.Value),
                new OracleParameter("p_e_st_ad_oa_si_gn_ac_io_n", (object?)m.EstadoAsignacion ?? DBNull.Value),
                new OracleParameter("p_a_si_gn_ad_op_or", (object?)m.AsignadoPor ?? DBNull.Value),
                new OracleParameter("p_o_bs_er_va_ci_on_es", (object?)m.Observaciones ?? DBNull.Value),
            };

            string sql = "BEGIN pkg_asignacion_pistas.update_pistas(:p_i_da_si_gn_ac_io_np_is_ta, :p_i_dp_is_ta, :p_i_dv_ue_lo, :p_t_ip_oo_pe_ra_ci_on, :p_f_ec_ha_ho_ra_as_ig_na_ci_on, :p_h_or_ai_ni_ci_oe_st_im_ad_a, :p_h_or_af_in_es_ti_ma_da, :p_h_or_ai_ni_ci_or_ea_l, :p_h_or_af_in_re_al, :p_e_st_ad_oa_si_gn_ac_io_n, :p_a_si_gn_ad_op_or, :p_o_bs_er_va_ci_on_es); END;";
            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var sql = "BEGIN pkg_asignacion_pistas.delete_pistas(:p_id_asignacion_pista); END;";
            await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id_asignacion_pista", id));
            return true;
        }

        public async Task<List<AsignacionPistasTiempoReal>> ListarTodo()
        {
            return await _context.Set<AsignacionPistasTiempoReal>().ToListAsync();
        }

        public async Task<AsignacionPistasTiempoReal?> ObtenerPorId(int id)
        {
            return await _context.Set<AsignacionPistasTiempoReal>().FirstOrDefaultAsync(x => x.IdAsignacionPista == id);
        }
    }
}

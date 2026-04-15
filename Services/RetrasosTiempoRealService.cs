using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class RetrasosTiempoRealService : IRetrasosTiempoRealService
    {
        private readonly DBContext _context;

        public RetrasosTiempoRealService(DBContext context)
        {
            _context = context;
        }

        public async Task<bool> Insertar(RetrasosTiempoReal m)
        {
            var parametros = new[] {
                new OracleParameter("p_i_dv_ue_lo", (object?)m.IdVuelo ?? DBNull.Value),
                new OracleParameter("p_f_ec_ha_ho_ra_re_gi_st_ro", (object?)m.FechaHoraRegistro ?? DBNull.Value),
                new OracleParameter("p_t_ip_or_et_ra_so", (object?)m.TipoRetraso ?? DBNull.Value),
                new OracleParameter("p_c_au_sa_es_pe_ci_fi_ca", (object?)m.CausaEspecifica ?? DBNull.Value),
                new OracleParameter("p_m_in_ut_os_re_tr_as_oa_ct_ua_le_s", (object?)m.MinutosRetrasoActuales ?? DBNull.Value),
                new OracleParameter("p_m_in_ut_os_re_tr_as_oe_st_im_ad_os", (object?)m.MinutosRetrasoEstimados ?? DBNull.Value),
                new OracleParameter("p_i_mp_ac_to_gl_ob_al", (object?)m.ImpactoGlobal ?? DBNull.Value),
                new OracleParameter("p_a_fe_ct_ac_on_ex_io_ne_s", (object?)m.AfectaConexiones ?? DBNull.Value),
                new OracleParameter("p_n_ot_if_ic_ad_op_as_aj_er_os", (object?)m.NotificadoPasajeros ?? DBNull.Value),
                new OracleParameter("p_a_ct_ua_li_za_do_po_r", (object?)m.ActualizadoPor ?? DBNull.Value),
                new OracleParameter("p_o_bs_er_va_ci_on_es", (object?)m.Observaciones ?? DBNull.Value),
            };

            string sql = "BEGIN pkg_retrasos_tiempo_real.insert_real(:p_i_dv_ue_lo, :p_f_ec_ha_ho_ra_re_gi_st_ro, :p_t_ip_or_et_ra_so, :p_c_au_sa_es_pe_ci_fi_ca, :p_m_in_ut_os_re_tr_as_oa_ct_ua_le_s, :p_m_in_ut_os_re_tr_as_oe_st_im_ad_os, :p_i_mp_ac_to_gl_ob_al, :p_a_fe_ct_ac_on_ex_io_ne_s, :p_n_ot_if_ic_ad_op_as_aj_er_os, :p_a_ct_ua_li_za_do_po_r, :p_o_bs_er_va_ci_on_es); END;";
            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return true;
        }

        public async Task<bool> Actualizar(int id, RetrasosTiempoReal m)
        {
            var parametros = new[] {
                new OracleParameter("p_i_dr_et_ra_so_ti_em_po_re_al", (object?)m.IdRetrasoTiempoReal ?? DBNull.Value),
                new OracleParameter("p_i_dv_ue_lo", (object?)m.IdVuelo ?? DBNull.Value),
                new OracleParameter("p_f_ec_ha_ho_ra_re_gi_st_ro", (object?)m.FechaHoraRegistro ?? DBNull.Value),
                new OracleParameter("p_t_ip_or_et_ra_so", (object?)m.TipoRetraso ?? DBNull.Value),
                new OracleParameter("p_c_au_sa_es_pe_ci_fi_ca", (object?)m.CausaEspecifica ?? DBNull.Value),
                new OracleParameter("p_m_in_ut_os_re_tr_as_oa_ct_ua_le_s", (object?)m.MinutosRetrasoActuales ?? DBNull.Value),
                new OracleParameter("p_m_in_ut_os_re_tr_as_oe_st_im_ad_os", (object?)m.MinutosRetrasoEstimados ?? DBNull.Value),
                new OracleParameter("p_i_mp_ac_to_gl_ob_al", (object?)m.ImpactoGlobal ?? DBNull.Value),
                new OracleParameter("p_a_fe_ct_ac_on_ex_io_ne_s", (object?)m.AfectaConexiones ?? DBNull.Value),
                new OracleParameter("p_n_ot_if_ic_ad_op_as_aj_er_os", (object?)m.NotificadoPasajeros ?? DBNull.Value),
                new OracleParameter("p_a_ct_ua_li_za_do_po_r", (object?)m.ActualizadoPor ?? DBNull.Value),
                new OracleParameter("p_o_bs_er_va_ci_on_es", (object?)m.Observaciones ?? DBNull.Value),
            };

            string sql = "BEGIN pkg_retrasos_tiempo_real.update_real(:p_i_dr_et_ra_so_ti_em_po_re_al, :p_i_dv_ue_lo, :p_f_ec_ha_ho_ra_re_gi_st_ro, :p_t_ip_or_et_ra_so, :p_c_au_sa_es_pe_ci_fi_ca, :p_m_in_ut_os_re_tr_as_oa_ct_ua_le_s, :p_m_in_ut_os_re_tr_as_oe_st_im_ad_os, :p_i_mp_ac_to_gl_ob_al, :p_a_fe_ct_ac_on_ex_io_ne_s, :p_n_ot_if_ic_ad_op_as_aj_er_os, :p_a_ct_ua_li_za_do_po_r, :p_o_bs_er_va_ci_on_es); END;";
            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var sql = "BEGIN pkg_retrasos_tiempo_real.delete_real(:p_id_retraso_tiempo_real); END;";
            await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id_retraso_tiempo_real", id));
            return true;
        }

        public async Task<List<RetrasosTiempoReal>> ListarTodo()
        {
            return await _context.Set<RetrasosTiempoReal>().ToListAsync();
        }

        public async Task<RetrasosTiempoReal?> ObtenerPorId(int id)
        {
            return await _context.Set<RetrasosTiempoReal>().FirstOrDefaultAsync(x => x.IdRetrasoTiempoReal == id);
        }
    }
}

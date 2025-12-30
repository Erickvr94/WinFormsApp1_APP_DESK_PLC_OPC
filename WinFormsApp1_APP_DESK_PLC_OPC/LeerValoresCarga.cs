using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Opc.Ua;

namespace WinFormsApp1_APP_DESK_PLC_OPC
{
    internal class LeerValoresCarga
    {
        private readonly Servicio_OPC _opc_Carga;

        //Constructor que acepta la instancia de Servicio_OPC
        public LeerValoresCarga(Servicio_OPC opcService)
        {
            _opc_Carga = opcService ?? throw new ArgumentNullException(nameof(opcService));
        }
        public async Task<bool> CargarModoOperacion()
        {
            try
            {
                object val = await _opc_Carga.LeerNodoAsync(5, 9);   // ns=5; id=6
                return Convert.ToBoolean(val);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer clase: " + ex.Message);
                throw;
            }
        }

        public async Task<String> CargarHorarioOn()
        {
            try
            {
                object val = await _opc_Carga.LeerNodoAsync(5, 7);   // ns=5; id=6
                return Convert.ToString(val);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer clase: " + ex.Message);
                throw;
            }
        }

        public async Task<String> CargarHorarioOff()
        {
            try
            {
                object val = await _opc_Carga.LeerNodoAsync(5, 6);   // ns=5; id=6
                return Convert.ToString(val);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer clase: " + ex.Message);
                throw;
            }
        }
    }
}

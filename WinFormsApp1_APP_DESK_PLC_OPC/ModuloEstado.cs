using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Opc.Ua;

namespace WinFormsApp1_APP_DESK_PLC_OPC
{
    internal class ModuloEstado
    {
        private readonly Servicio_OPC _opc_UI;

        public RadioButton rbOpcion1 { get; }
        public RadioButton rbOpcion2 { get; }
        public CheckBox chkActivo { get; }
        public Label lbllervalor { get; }
        public Button btnLeer { get; }

        // Constructor que acepta la instancia de Servicio_OPC y controles UI
        public ModuloEstado(Servicio_OPC opcService_UI,
                           RadioButton rb1,
                           RadioButton rb2,
                           CheckBox chk1,
                           Label lbl1,
                           Button btn1)
        {
            _opc_UI = opcService_UI ?? throw new ArgumentNullException(nameof(opcService_UI));

            rbOpcion1 = rb1 ?? throw new ArgumentNullException(nameof(rb1));
            rbOpcion2 = rb2 ?? throw new ArgumentNullException(nameof(rb2));
            chkActivo = chk1 ?? throw new ArgumentNullException(nameof(chk1));
            lbllervalor = lbl1 ?? throw new ArgumentNullException(nameof(lbl1));
            btnLeer = btn1 ?? throw new ArgumentNullException(nameof(btn1));
        }
        public async Task LeerTag()
        {
            try
            {
                object val = await _opc_UI.LeerNodoAsync(5, 6);   // ns=5; id=6
                string texto = Convert.ToString(val);
                lbllervalor.Text = texto;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer: " + ex.Message);
            }
        }

        public async Task<String> CargarHorarioOn()
        {
            try
            {
                object val = await _opc_UI.LeerNodoAsync(5, 7);   // ns=5; id=6
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
                object val = await _opc_UI.LeerNodoAsync(5, 6);   // ns=5; id=6
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

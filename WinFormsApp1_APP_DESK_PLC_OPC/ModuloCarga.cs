using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Opc.Ua;

namespace WinFormsApp1_APP_DESK_PLC_OPC
{
    internal class ModuloCarga
    {
        private readonly Servicio_OPC _opc_Carga;

        public RadioButton rbOpcion_Manual { get; }
        public RadioButton rbOpcion_Horario { get; }
        public DateTimePicker dateTimePicker_On { get; }
        public DateTimePicker dateTimePicker_Off { get; }
        public CheckBox chk_RunRem { get; }

        //Constructor que acepta la instancia de Servicio_OPC
        public ModuloCarga(Servicio_OPC opcService_UI,
                           RadioButton rb1,
                           RadioButton rb2,
                           CheckBox chk1,
                           DateTimePicker dateTimePicker_1,
                           DateTimePicker dateTimePicker_0)
        {
            _opc_Carga = opcService_UI ?? throw new ArgumentNullException(nameof(opcService_UI));

            rbOpcion_Manual = rb1 ?? throw new ArgumentNullException(nameof(rb1));
            rbOpcion_Horario = rb2 ?? throw new ArgumentNullException(nameof(rb2));
            chk_RunRem = chk1 ?? throw new ArgumentNullException(nameof(chk1));
            dateTimePicker_On = dateTimePicker_1 ?? throw new ArgumentNullException(nameof(dateTimePicker_1));
            dateTimePicker_Off = dateTimePicker_0 ?? throw new ArgumentNullException(nameof(dateTimePicker_0));
        }
        public async Task CargarModoOperacion()
        {
            try
            {
                object val_blqautHr = await _opc_Carga.LeerNodoAsync(4, 9);
                object val_runrem = await _opc_Carga.LeerNodoAsync(4, 8);
                bool val = Convert.ToBoolean(val_runrem);
                if (Convert.ToBoolean(val_blqautHr))
                {
                    chk_RunRem.Enabled = true;
                    rbOpcion_Manual.Checked = true;
                    rbOpcion_Horario.Checked = false;
                    dateTimePicker_On.Enabled = false;
                    dateTimePicker_Off.Enabled = false;
                    if (val)
                    {
                        chk_RunRem.Checked = val;
                    }
                }
                if (!Convert.ToBoolean(val_blqautHr))
                {
                    chk_RunRem.Enabled = false;
                    rbOpcion_Manual.Checked = false;
                    rbOpcion_Horario.Checked = true;
                    dateTimePicker_On.Enabled = true;
                    dateTimePicker_Off.Enabled = true;
                    if (!val)
                    {
                        chk_RunRem.Checked = val;
                    }
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer: " + ex.Message);
                throw;
            }
        }

        public async Task<String> CargarHorarioOn()
        {
            try
            {
                object val = await _opc_Carga.LeerNodoAsync(4, 7);   // ns=4; id=6
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
                object val = await _opc_Carga.LeerNodoAsync(4, 6);   // ns=4; id=6
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

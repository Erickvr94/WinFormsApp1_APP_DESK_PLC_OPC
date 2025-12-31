using Opc.Ua;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1_APP_DESK_PLC_OPC
{
    internal class ModuloControlEstadoUI
    {
        private readonly Servicio_OPC _opc_UI;

        public RadioButton rbOpcion1 { get; }
        public RadioButton rbOpcion2 { get; }
        public CheckBox chkRunRem { get; }
        public Label lbllervalor { get; }
        public Button btnLeer { get; }

        public DateTimePicker dateTimePicker_On { get; }
        public DateTimePicker dateTimePicker_Off { get; }

        // Constructor que acepta la instancia de Servicio_OPC y controles UI
        public ModuloControlEstadoUI(Servicio_OPC opcService_UI,
                           RadioButton rb1,
                           RadioButton rb2,
                           CheckBox chk1,
                           Label lbl1,
                           Button btn1,
                           DateTimePicker dateTimePicker_On,
                           DateTimePicker dateTimePicker_Off)
        {
            _opc_UI = opcService_UI ?? throw new ArgumentNullException(nameof(opcService_UI));

            rbOpcion1 = rb1 ?? throw new ArgumentNullException(nameof(rb1));
            rbOpcion2 = rb2 ?? throw new ArgumentNullException(nameof(rb2));
            chkRunRem = chk1 ?? throw new ArgumentNullException(nameof(chk1));
            lbllervalor = lbl1 ?? throw new ArgumentNullException(nameof(lbl1));
            btnLeer = btn1 ?? throw new ArgumentNullException(nameof(btn1));
            this.dateTimePicker_On = dateTimePicker_On;
            this.dateTimePicker_Off = dateTimePicker_Off;
        }
        public async Task LeerTag()
        {
            try
            {
                object val = await _opc_UI.LeerNodoAsync(4, 6);   // ns=4; id=6
                string texto = Convert.ToString(val);
                lbllervalor.Text = texto;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer: " + ex.Message);
            }
        }

        public async Task ControlRemoto()
        {
            try
            {
                bool runrem = chkRunRem.Checked;
                object val_runrem = await _opc_UI.LeerNodoAsync(4, 9);
                object val_bloqautoHr = await _opc_UI.LeerNodoAsync(4, 8); 
                if (runrem)
                {
                    val_bloqautoHr = true;
                    await _opc_UI.EscribirNodoAsync(4, 9, val_bloqautoHr );
                    val_runrem = true;
                    await _opc_UI.EscribirNodoAsync(4, 8, val_runrem);
                    //MessageBox.Show("Encendido!");
                }
                else if (!runrem)
                {
                    val_runrem = false;
                    await _opc_UI.EscribirNodoAsync(4, 8, val_runrem);
                    val_bloqautoHr = false;
                    await _opc_UI.EscribirNodoAsync(4, 9, val_bloqautoHr);
                    //MessageBox.Show("Apagado!");
                }
                else
                {
                    MessageBox.Show("Error al encender o apagar en este modo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer: " + ex.Message);
            }
        }

        public async Task EnviarHorario()
        {
            try
            {
                TimeSpan tOn = dateTimePicker_On.Value.TimeOfDay;
                TimeSpan tOff = dateTimePicker_Off.Value.TimeOfDay;

                //Forzar segundos exactos sin milisegundos
                uint horaOn =
                    (uint)(
                        (tOn.Hours * 3600 +
                         tOn.Minutes * 60 +
                         tOn.Seconds) * 1000
                    );

                await _opc_UI.EscribirNodoAsync(4, 7, horaOn);

                uint horaOff =
                    (uint)(
                        (tOff.Hours * 3600 +
                         tOff.Minutes * 60 +
                         tOff.Seconds) * 1000
                    );
                //MessageBox.Show("Error al escribir Time_Of_Day: " + horaOff.GetType());

                await _opc_UI.EscribirNodoAsync(4, 6, horaOff);

                MessageBox.Show(
                     $"Hora On: {tOn.Hours:D2}:{tOn.Minutes:D2}:{tOn.Seconds:D2}\n" +
                     $"Hora Off: {tOff.Hours:D2}:{tOff.Minutes:D2}:{tOff.Seconds:D2}"
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al escribir Time_Of_Day: " + ex.Message);
            }
        }


        /*
        public async Task<String> CargarHorarioOn()
        {
            try
            {
                object val = await _opc_UI.LeerNodoAsync(4, 7);   // ns=4; id=6
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
                object val = await _opc_UI.LeerNodoAsync(4, 6);   // ns=4; id=6
                return Convert.ToString(val);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer clase: " + ex.Message);
                throw;
            }
        }*/
    }
}

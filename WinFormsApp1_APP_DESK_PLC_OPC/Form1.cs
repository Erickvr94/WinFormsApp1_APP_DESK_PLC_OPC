using Opc.Ua;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace WinFormsApp1_APP_DESK_PLC_OPC
{
    public partial class Form1 : Form
    {
        private Servicio_OPC _opc;

        private void Form1_Load(object sender, EventArgs e)
        {
            dateTimePicker_On.Format = DateTimePickerFormat.Time;
            dateTimePicker_On.ShowUpDown = true; // para que sea tipo spinner y no calendario
            dateTimePicker_Off.Format = DateTimePickerFormat.Time;
            dateTimePicker_Off.ShowUpDown = true;

        }

        public Form1()
        {
            InitializeComponent();
            _opc = new Servicio_OPC("opc.tcp://192.168.199.91:4840");
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                await _opc.ConectarAsync();
              
                MessageBox.Show("Conectado al PLC!", "OPC UA");
                var nodeId_SerialNumber = new NodeId("SerialNumber",3);   // <-- ns=3;s=SerialNumber
                object SerialNumber = await _opc.LeerNodoStringAsync(nodeId_SerialNumber);

                var nodeId_DeviceRevision = new NodeId("DeviceRevision", 3);   
                object DeviceRevision = await _opc.LeerNodoStringAsync(nodeId_DeviceRevision);

                var nodeId_EngineeringRevision = new NodeId("EngineeringRevision", 3);
                object EngineeringRevision = await _opc.LeerNodoStringAsync(nodeId_EngineeringRevision);

                lbSerieEquipo.Text = SerialNumber?.ToString();
                lbModelEquipo.Text = DeviceRevision?.ToString();
                lbVersionTiaP.Text = EngineeringRevision?.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            try
            {
                object val = await _opc.LeerNodoAsync(5, 6);   // ns=5; id=6
                lbLeertag1.Text = val.ToString();
                //MessageBox.Show("Valor leído: " + val);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer: " + ex.Message);
            }
        }

        private async void btnEscribir_Click(object sender, EventArgs e)
        {

            try
            {
                string bl = txtBox_Escribirtag1.Text;

                if (bool.TryParse(bl, out bool valor))
                {
                    await _opc.EscribirNodoAsync(5, 8, valor); // ns=5; id=5
                    MessageBox.Show("BOOL escrito correctamente");
                }
                else
                {
                    MessageBox.Show("Error: Ingrese 'true' o 'false' válido en el cuadro de texto.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer: " + ex.Message);
            }
        }

        private async void btnBloqAutoHora_Click(object sender, EventArgs e)
        {
            try
            {
                bool checkBloqAutHr = checkBox_BloqAutHr.Checked;
                string bloqAutoHr = txtBox_BloqAutoHora.Text;
                if (bool.TryParse(bloqAutoHr, out bool valor))
                {
                    await _opc.EscribirNodoAsync(5, 9, valor);
                    MessageBox.Show("BOOL escrito correctamente");
                }
                else if (checkBloqAutHr)
                {
                    await _opc.EscribirNodoAsync(5, 9, checkBloqAutHr);
                    MessageBox.Show("BOOL escrito correctamente");
                }

                else
                {
                    MessageBox.Show("Error: Ingrese 'true' o 'false' válido en el cuadro de texto.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer: " + ex.Message);
            }
        }

        private async void btnRunRem_Click(object sender, EventArgs e)
        {
            try
            {
                bool checkRunRem = checkB_RunRem.Checked;
                string runrem = txtBox_RunRem.Text;

                if (bool.TryParse(runrem, out bool valor))
                {
                    if (runrem == "true")
                    {
                        await _opc.EscribirNodoAsync(5, 8, valor);
                        //MessageBox.Show("BOOL escrito correctamente"); 
                        checkB_RunRem.Checked = true;
                    }
                    else if (runrem == "false")
                    {
                        await _opc.EscribirNodoAsync(5, 8, valor);
                        checkB_RunRem.Checked = false;
                    }
                }
                else
                {
                    MessageBox.Show("Error: no se pudo realiar Check");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer: " + ex.Message);
            }

        }
        private async void checkBox_BloqAutHr_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                bool checkBloqAutHr = checkBox_BloqAutHr.Checked;
                if (checkBloqAutHr)
                {
                    await _opc.EscribirNodoAsync(5, 9, checkBloqAutHr);
                    //MessageBox.Show("BOOL escrito correctamente"); 

                    txtBox_BloqAutoHora.Text = "true";
                }
                else if (!checkBloqAutHr)
                {
                    await _opc.EscribirNodoAsync(5, 9, checkBloqAutHr);

                    txtBox_BloqAutoHora.Text = "false";
                }
                else
                {
                    MessageBox.Show("Error: no se pudo realiar Check");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer: " + ex.Message);
            }
        }
        private async void checkB_RunRem_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                bool checkRunRem = checkB_RunRem.Checked;
                if (checkRunRem)
                {
                    await _opc.EscribirNodoAsync(5, 8, checkRunRem);
                    //MessageBox.Show("BOOL escrito correctamente"); 

                    txtBox_RunRem.Text = "true";
                }
                else if (!checkRunRem)
                {
                    await _opc.EscribirNodoAsync(5, 8, checkRunRem);

                    txtBox_RunRem.Text = "false";
                }
                else
                {
                    MessageBox.Show("Error: Ingrese 'true' o 'false' válido en el cuadro de texto");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer: " + ex.Message);
            }
        }

        private async void bt_EnviarHr_Click(object sender, EventArgs e)
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

                await _opc.EscribirNodoAsync(5, 7, horaOn);

                uint horaOff =
                    (uint)(
                        (tOff.Hours * 3600 +
                         tOff.Minutes * 60 +
                         tOff.Seconds) * 1000
                    );

                await _opc.EscribirNodoAsync(5, 6, horaOff);

                MessageBox.Show(
                     $"Hora On: {tOn.Hours:D2}:{tOn.Minutes:D2}:{tOn.Seconds:D2}\n"+
                     $"Hora Off: {tOff.Hours:D2}:{tOff.Minutes:D2}:{tOff.Seconds:D2}"
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al escribir Time_Of_Day: " + ex.Message);
            }
        }
    }
}

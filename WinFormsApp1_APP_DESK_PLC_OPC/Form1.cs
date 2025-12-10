namespace WinFormsApp1_APP_DESK_PLC_OPC
{
    public partial class Form1 : Form
    {
        private Servicio_OPC _opc;
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
                object val = await _opc.LeerNodoAsync(5, 5);   // ns=5; id=5
                MessageBox.Show("Valor leído: " + val);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer: " + ex.Message);
            }
        }
    }
}

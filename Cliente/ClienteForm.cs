using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cliente
{
    public partial class ClienteForm : Form
    {
        public static ConexionTcp conexionTcp = new ConexionTcp();
        public static string IPADDRESS = "127.0.0.1";
        public const int PORT = 1982;

        public ClienteForm()
        {
            InitializeComponent();
        }

        private void ClienteForm_Load(object sender, EventArgs e)
        {
            conexionTcp.OnDataRecieved += MensajeRecibido;

            if (!conexionTcp.Connectar(IPADDRESS, PORT))
            {
                MessageBox.Show("Error conectando con el servidor!");
                return;
            }
        }

        private void MensajeRecibido(string datos)
        {
            var paquete = new Paquete(datos);
            string comando = paquete.Comando;
            if (comando == "resultado")
            {
                string contenido = paquete.Contenido;

                Invoke(new Action(() => label1.Text = string.Format("Respuesta: {0}", contenido)));
            }
        }

        private void ClienteForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (conexionTcp.TcpClient.Connected)
            {
                var msgPack = new Paquete("login", string.Format("{0},{1}", textBox1.Text, textBox2.Text));
                conexionTcp.EnviarPaquete(msgPack);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (conexionTcp.TcpClient.Connected)
            {
                var msgPack = new Paquete("insertar", string.Format("{0},{1}", textBox1.Text, textBox2.Text));
                conexionTcp.EnviarPaquete(msgPack);
            }
        }
    }
}

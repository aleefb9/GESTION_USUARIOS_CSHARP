using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UsersPanel.Logica;

namespace UsersPanel
{
    public partial class FormMensajes : Form
    {
        public FormMensajes()
        {
            InitializeComponent();
        }

        /**
         * MÉTODO QUE SE ENCARGA DE LLAMAR AL MÉTODO QUE LISTA LOS MENSAJES 
         */
        public void mostrar_mensajes()
        {
            dgvmensajes.DataSource = null;
            dgvmensajes.DataSource = MensajeLogica.Instancia.ListarMensajes();
        }

        /**
         * MÉTODO QUE LLAMA AL MÉTODO ANTERIOR AL CARGAR EL FORMULARIO
         */
        private void FormMensajes_Load(object sender, EventArgs e)
        {
            mostrar_mensajes();
        }

        /**
         * MÉTODO QUE CIERRA ESTA VENTANA SI SE PULSA EN AL BOTÓN 
         */
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

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

            labelNoMensajes.Hide();
            imagenMensaje.Hide();
            if (dgvmensajes.RowCount == 0)
            {
                dgvmensajes.Hide();
                labelNoMensajes.Show();
                imagenMensaje.Show();   
            }
        }

        /**
         * MÉTODO QUE CIERRA ESTA VENTANA SI SE PULSA EN AL BOTÓN 
         */
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Declaramos las variables que arrastraran la ventana
        int m, mx, my;

        /**
         * MÉTODO QUE DETECTA CUANDO EL RATÓN ESTÁ PULSADO
         */
        private void pictureBox3_MouseDown(object sender, MouseEventArgs e)
        {
            m = 1;
            mx = e.X;
            my = e.Y;
        }

        /**
        * MÉTODO QUE MUEVE EL SITIO QUE PULSA EL RATÓN
        */
        private void pictureBox3_MouseMove(object sender, MouseEventArgs e)
        {
            if (m == 1)
            {
                this.SetDesktopLocation(MousePosition.X - mx, MousePosition.Y - my);
            }
        }

        /**
         * MÉTODO QUE DETECTA QUE EL RATÓN YA NO ESTÁ PULSADO
         */
        private void pictureBox3_MouseUp(object sender, MouseEventArgs e)
        {
            m = 0;
        }
    }
}

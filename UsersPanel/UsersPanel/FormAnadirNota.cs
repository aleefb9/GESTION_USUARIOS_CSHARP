using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UsersPanel.Logica;
using UsersPanel.Modelo;

namespace UsersPanel
{
    public partial class FormAnadirNota : Form
    {
        private static string cadena = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;

        public FormAnadirNota()
        {
            InitializeComponent();
            llenarComboBox();
        }

        /**
         * MÉTODO QUE LLENA EL COMBOBOX CON LOS NOMBRES DE LOS USUARIOS 
         */
        private void llenarComboBox()
        {
            comboBox1.Items.Clear();

            SQLiteConnection conexion = new SQLiteConnection(cadena);
            String query = "SELECT Id, Nombre FROM Usuarios";
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, conexion);

            conexion.Open();

            DataTable dt = new DataTable();
            adapter.Fill(dt);
            conexion.Close();

            DataRow fila = dt.NewRow();
            fila["Nombre"] = "Selecciona un usuario";
            dt.Rows.InsertAt(fila, 0);

            comboBox1.ValueMember = "Id";
            comboBox1.DisplayMember = "Nombre";
            comboBox1.DataSource = dt;
        }

        /**
         * MÉTODO QUE LIMPIA LOS CAMPOS DE LOS TEXTBOX DEL FORMULARIO
         */
        private void limpiar()
        {
            txttitulo.Text = "";
            txtdescripcion.Text = "";
            comboBox1.SelectedIndex = 0;
            txttitulo.Focus();
        }

        /**
         * MÉTODO QUE OCULTA LA VENTANA
         */
        private void cerrar()
        {
            this.Close();
        }

        /**
         * MÉTODO QUE ENVÍA LOS DATOS AL MÉTODO QUE LOS GUARDA EN LA BASE DE DATOS
         */
        private void btnguardarnota_Click(object sender, EventArgs e)
        {
            try
            {
                Nota objeto = new Nota()
                {
                    Titulo = txttitulo.Text,
                    Descripcion = txtdescripcion.Text,
                    IdUsuario = int.Parse(comboBox1.SelectedValue.ToString()),
                    FechaGuardado = DateTime.Today.ToShortDateString()
                };

                if (objeto.Titulo == "" || objeto.Descripcion == "")
                {
                    MessageBox.Show("Debe rellenar los campos obligatorios", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    bool respuesta = NotaLogica.Instancia.Guardar(objeto);

                    if (respuesta)
                    {
                        limpiar();
                        cerrar();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Debe rellenar los campos obligatorios", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /**
         * MÉTODO QUE CIERRA LA VENTANA
         */
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            cerrar();
        }

        //Declaramos las variables que arrastraran la ventana
        int m, mx, my;

        /**
         * MÉTODO QUE DETECTA CUANDO EL RATÓN ESTÁ PULSADO
         */
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            m = 1;
            mx = e.X;
            my = e.Y;
        }

        /**
         * MÉTODO QUE MUEVE EL SITIO QUE PULSA EL RATÓN
         */
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (m == 1)
            {
                this.SetDesktopLocation(MousePosition.X - mx, MousePosition.Y - my);
            }
        }

        /**
         * MÉTODO QUE DETECTA QUE EL RATÓN YA NO ESTÁ PULSADO
         */
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            m = 0;
        }
    }
}

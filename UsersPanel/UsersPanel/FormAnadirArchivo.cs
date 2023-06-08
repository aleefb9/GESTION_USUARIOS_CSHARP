using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UsersPanel.Logica;
using UsersPanel.Modelo;

namespace UsersPanel
{
    public partial class FormAnadirArchivo : Form
    {
        private static string cadena = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;

        public FormAnadirArchivo()
        {
            InitializeComponent();
            llenarComboBox();
        }

        /**
         * MÉTODO QUE RELLENA EL COMBOBOX CON LOS NOMBRES DE LOS USUARIOS DE LA BASE DE DATOS
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
         * MÉTODO QUE ABRE EL EXPLORADOR DE ARCHIVOS 
         */
        private void btnseleccionararchivo_Click(object sender, EventArgs e)
        {
            string rutaArchivo = string.Empty;

            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                rutaArchivo = openFileDialog.FileName;
            }

            txtruta.Text = rutaArchivo;
        }

        /**
         * MÉTODO QUE REVISA LA RUTA DEL ARCHIVO ESCRITA EN EL TXTRUTA
         */
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(txtruta.Text);
            }
            catch {}
        }

        /**
         * MÉTODO QUE LIMPIA LOS CAMPOS DEL FORMULARIO
         */
        private void limpiar()
        {
            txtnombrearchivo.Text = "";
            txtruta.Text = "";
            comboBox1.SelectedIndex = 0;
            txtnombrearchivo.Focus();
        }

        /**
         * MÉTODO QUE CIERRA EL FORMULARIO EL PULSAR EN EL BOTÓN
         */
        private void cerrar()
        {
            this.Close();
        }

        /**
         * MÉTODO QUE CARGA EL FORMULARIO
         */
        private void FormAnadirArchivo_Load(object sender, EventArgs e)
        {
            this.txtruta.AutoSize = false;
            this.txtruta.Size = new System.Drawing.Size(376, 34);
        }

        /**
         * MÉTODO QUE MANDA LOS DATOS AL MÉTODO QUE GUARDA LOS DATOS EN LA BASE DE DATOS
         */
        private void btnguardarnota_Click(object sender, EventArgs e)
        {
            try
            {
                Archivo objeto = new Archivo()
                {
                    NombreArchivo = txtnombrearchivo.Text,
                    Ruta = txtruta.Text,
                    IdUsuario = int.Parse(comboBox1.SelectedValue.ToString())
                };

                if (objeto.NombreArchivo == "" || objeto.Ruta == "")
                {
                    MessageBox.Show("Debe rellenar los campos obligatorios", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    bool respuesta = ArchivoLogica.Instancia.Guardar(objeto);

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

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

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start(txtruta.Text);
        }

        private void limpiar()
        {
            txtnombrearchivo.Text = "";
            txtruta.Text = "";
            comboBox1.SelectedIndex = 0;
            txtnombrearchivo.Focus();
        }

        private void cerrar()
        {
            this.Hide();
        }

        private void FormAnadirArchivo_Load(object sender, EventArgs e)
        {
            this.txtruta.AutoSize = false;
            this.txtruta.Size = new System.Drawing.Size(376, 34);
        }

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

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();   
        }
    }
}

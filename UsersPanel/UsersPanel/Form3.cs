using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UsersPanel.Logica;
using UsersPanel.Modelo;

namespace UsersPanel
{
    public partial class Form3 : Form
    {
        private static string cadena = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;

        public Form3()
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

        private void btnguardararchivo_Click(object sender, EventArgs e)
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
                        mostrar_archivos();
                    }
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Debe rellenar los campos obligatorios", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mostrar_archivos()
        {
            dgvarchivos.DataSource = null;
            dgvarchivos.DataSource = ArchivoLogica.Instancia.Listar();
            dgvarchivos.Columns[3].Visible = false;
            dgvarchivos.Columns[0].Width = 100;
            dgvarchivos.Columns[1].Width = 150;
            dgvarchivos.Columns[4].Width = 200;
        }

        private void limpiar()
        {
            txtidarchivo.Text = "";
            txtnombrearchivo.Text = "";
            txtruta.Text = "";
            comboBox1.SelectedIndex = 0;
            txtnombrearchivo.Focus();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            mostrar_archivos();

            this.txtruta.AutoSize = false;
            this.txtruta.Size = new System.Drawing.Size(291, 34);
        }

        private void btneditararchivos_Click(object sender, EventArgs e)
        {
            try
            {
                Archivo objeto = new Archivo()
                {
                    IdArchivo = int.Parse(txtidarchivo.Text),
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
                    bool respuesta = ArchivoLogica.Instancia.Editar(objeto);

                    if (respuesta)
                    {
                        limpiar();
                        mostrar_archivos();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Debe de introducir un identificador para MODIFICAR", "Introduzca ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btneliminararchivos_Click(object sender, EventArgs e)
        {
            try
            {
                Archivo objeto = new Archivo()
                {
                    IdArchivo = int.Parse(txtidarchivo.Text),
                };

                DialogResult result = MessageBox.Show("¿Está seguro de querer eliminar el archivo con id: " + txtidarchivo.Text + " ?", "CONFIRMAR BORRADO", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    bool respuesta = ArchivoLogica.Instancia.Eliminar(objeto);

                    if (respuesta)
                    {
                        limpiar();
                        mostrar_archivos();
                    }
                }
                else if (result == DialogResult.Cancel)
                {
                    MessageBox.Show("No se ha borrado el archivo " + txtidarchivo.Text + ".", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Debe de introducir un identificador para ELIMINAR", "Introduzca ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtbuscadorarchivos_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtbuscadorarchivos.Text == null || txtbuscadorarchivos.Text == "")
                {
                    mostrar_archivos();
                }
                else
                {
                    SQLiteConnection conexion = new SQLiteConnection(cadena);
                    String query = "SELECT IdArchivo, NombreArchivo, Ruta, Nombre FROM Archivos INNER JOIN Usuarios ON Archivos.IdUsuario = Usuarios.Id WHERE " + comboBox33.Text + " LIKE '%" + txtbuscadorarchivos.Text + "%'";
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, conexion);

                    conexion.Open();

                    DataSet data = new DataSet();
                    adapter.Fill(data, "Archivos");

                    dgvarchivos.DataSource = data;
                    dgvarchivos.DataMember = "Archivos";
                    dgvarchivos.Columns[0].Width = 100;
                    dgvarchivos.Columns[1].Width = 150;
                    dgvarchivos.Columns[3].Width = 200;
                    dgvarchivos.AllowUserToAddRows = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("El valor introducido es inválido.", "valor no válido", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvarchivos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtidarchivo.Text = dgvarchivos.CurrentRow.Cells[0].Value.ToString();
                txtnombrearchivo.Text = dgvarchivos.CurrentRow.Cells[1].Value.ToString();
                txtruta.Text = dgvarchivos.CurrentRow.Cells[2].Value.ToString();
                comboBox1.SelectedValue = dgvarchivos.CurrentRow.Cells[3].Value.ToString();
                dgvarchivos.Columns[3].Visible = false;

                if (e.ColumnIndex == this.dgvarchivos.Columns["Ruta"].Index)
                {
                    Process.Start(dgvarchivos.CurrentRow.Cells[2].Value.ToString());
                }
            }
            catch (Exception ex) {}
        }

        private void dgvarchivos_CellFormatting_1(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvarchivos.Columns[e.ColumnIndex].Name == "Ruta")
            {
                e.CellStyle.ForeColor = Color.Blue;
            }
        }

        private void btnregistros_Click(object sender, EventArgs e)
        {
            UsersPanel ventana1 = new UsersPanel();
            this.Hide();
            ventana1.Show();
        }

        private void btnanotaciones_Click(object sender, EventArgs e)
        {
            Form2 ventana2 = new Form2();
            this.Hide();
            ventana2.Show();
        }

        private void iconolimpiar2_Click(object sender, EventArgs e)
        {
            limpiar();
        }
    }
}

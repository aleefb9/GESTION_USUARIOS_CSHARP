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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace UsersPanel
{
    public partial class Form2 : Form
    {
        private static string cadena = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;

        public Form2()
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

        private void btnguardarnota_Click(object sender, EventArgs e)
        {
            try
            {
                Nota objeto = new Nota()
                {
                    Titulo = txttitulo.Text,
                    Descripcion = txtdescripcion.Text,
                    IdUsuario = int.Parse(comboBox1.SelectedValue.ToString())
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
                        mostrar_notas();
                        MessageBox.Show("Nota añadida correctamente", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Debe rellenar los campos obligatorios", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mostrar_notas()
        {
            dgvnotas.DataSource = null;
            dgvnotas.DataSource = NotaLogica.Instancia.Listar();
            dgvnotas.Columns[3].Visible = false;
            dgvnotas.Columns[0].Width = 100;
            dgvnotas.Columns[1].Width = 150;
            dgvnotas.Columns[4].Width = 200;
        }

        private void limpiar()
        {
            txtidnota.Text = "";
            txttitulo.Text = "";
            txtdescripcion.Text = "";
            comboBox1.SelectedIndex = 0;
            txttitulo.Focus();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            mostrar_notas();
        }

        private void btneditarnotas_Click(object sender, EventArgs e)
        {
            try
            {
                Nota objeto = new Nota()
                {
                    IdNota = int.Parse(txtidnota.Text),
                    Titulo = txttitulo.Text,
                    Descripcion = txtdescripcion.Text,
                    IdUsuario = int.Parse(comboBox1.SelectedValue.ToString())
                };

                if (objeto.Titulo == "" || objeto.Descripcion == "")
                {
                    MessageBox.Show("Debe rellenar los campos obligatorios", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    bool respuesta = NotaLogica.Instancia.Editar(objeto);

                    if (respuesta)
                    {
                        limpiar();
                        mostrar_notas();
                        MessageBox.Show("Nota " + txtidnota.Text + " editado correctamente", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Debe de introducir un identificador para MODIFICAR", "Introduzca ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btneliminarnota_Click(object sender, EventArgs e)
        {
            try
            {
                Nota objeto = new Nota()
                {
                    IdNota = int.Parse(txtidnota.Text),
                };

                DialogResult result = MessageBox.Show("¿Está seguro de querer eliminar la nota con id: " + txtidnota.Text + " ?", "CONFIRMAR BORRADO", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    bool respuesta = NotaLogica.Instancia.Eliminar(objeto);

                    if (respuesta)
                    {
                        limpiar();
                        mostrar_notas();
                        MessageBox.Show("Nota borrada correctamente", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (result == DialogResult.Cancel)
                {
                    MessageBox.Show("No se ha borrado la nota " + txtidnota.Text + ".", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Debe de introducir un identificador para ELIMINAR", "Introduzca ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtbuscadornotas_TextChanged(object sender, EventArgs e)
        {
            try 
            { 
                if (txtbuscadornotas.Text == null || txtbuscadornotas.Text == "")
                {
                    mostrar_notas();
                }
                else
                {
                    SQLiteConnection conexion = new SQLiteConnection(cadena);
                    String query = "SELECT IdNota, Titulo, Descripcion, Nombre FROM Notas INNER JOIN Usuarios ON Notas.IdUsuario = Usuarios.Id WHERE " + comboBox33.Text + " LIKE '%" + txtbuscadornotas.Text + "%'";
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, conexion);

                    conexion.Open();

                    DataSet data = new DataSet();
                    adapter.Fill(data, "Notas");

                    dgvnotas.DataSource = data;
                    dgvnotas.DataMember = "Notas";
                    dgvnotas.Columns[0].Width = 100;
                    dgvnotas.Columns[1].Width = 150;
                    dgvnotas.Columns[3].Width = 200;
                    dgvnotas.AllowUserToAddRows = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("El valor introducido es inválido.", "VALOR NO VÁLIDO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvnotas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtidnota.Text = dgvnotas.CurrentRow.Cells[0].Value.ToString();
            txttitulo.Text = dgvnotas.CurrentRow.Cells[1].Value.ToString();
            txtdescripcion.Text = dgvnotas.CurrentRow.Cells[2].Value.ToString();
            comboBox1.SelectedValue = dgvnotas.CurrentRow.Cells[3].Value.ToString();
            dgvnotas.Columns[3].Visible = false;
        }

        private void buttonregistros_Click(object sender, EventArgs e)
        {
            UsersPanel ventana1 = new UsersPanel();
            this.Hide();
            ventana1.Show();
        }

        private void btnarchivos_Click(object sender, EventArgs e)
        {
            Form3 ventana3 = new Form3();
            this.Hide();
            ventana3.Show();
        }

        private void iconolimpiar2_Click(object sender, EventArgs e)
        {
            limpiar();
        }
    }
}

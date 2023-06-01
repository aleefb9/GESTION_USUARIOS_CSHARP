using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using UsersPanel.Modelo;
using UsersPanel.Logica;
using System.Collections;
using System.Data.SQLite;
using System.Configuration;
using System.Data.SqlClient;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

namespace UsersPanel
{
    public partial class UsersPanel : Form
    {
        private static string cadena = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;

        public UsersPanel()
        {
            InitializeComponent();
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            Usuario objeto = new Usuario()
            {
                Nombre = txtnombre.Text,
                Departamento = txtdepartamento.Text,
                Semanas = txtinicio.Text,
                FechaIncorporacion = txtinicio.Value.ToString("yyyy/MM/dd"),
                FechaInicio = txtinicio.Value.ToString("yyyy/MM/dd"),
                Fecha2meses = txtinicio.Value.ToString("yyyy/MM/dd"),
                Fecha3meses = txtinicio.Value.ToString("yyyy/MM/dd"),
                Fecha4meses = txtinicio.Value.ToString("yyyy/MM/dd"),
                Fecha5meses = txtinicio.Value.ToString("yyyy/MM/dd"),
                Fecha6meses = txtinicio.Value.ToString("yyyy/MM/dd")
            };

            if (objeto.Nombre == "" || objeto.Departamento == "")
            {
                MessageBox.Show("Debe rellenar los campos obligatorios", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                bool respuesta = UsuarioLogica.Instancia.Guardar(objeto);

                if (respuesta)
                {
                    limpiar();
                    mostrar_usuarios();
                    MessageBox.Show("Usuario añadido correctamente", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        public void mostrar_usuarios()
        {
            dgvusuarios.DataSource = null;
            dgvusuarios.DataSource = UsuarioLogica.Instancia.Listar();
        }

        public void limpiar()
        {
            txtidusuario.Text = "";
            txtnombre.Text = "";
            txtdepartamento.Text = "";
            txtinicio.Text = "";
            txtnombre.Focus();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            mostrar_usuarios();    
        }

        private void btneditar_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario objeto = new Usuario()
                {
                    IdUsuario = int.Parse(txtidusuario.Text),
                    Nombre = txtnombre.Text,
                    Departamento = txtdepartamento.Text,
                    FechaInicio = txtinicio.Text,
                    FechaIncorporacion = txtinicio.Text,
                };

                if (objeto.Nombre == "" || objeto.Departamento == "")
                {
                    MessageBox.Show("Debe rellenar los campos obligatorios", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    bool respuesta = UsuarioLogica.Instancia.Editar(objeto);

                    if (respuesta)
                    {
                        limpiar();
                        mostrar_usuarios();
                        MessageBox.Show("Usuario " + txtidusuario.Text + " editado correctamente", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Debe de introducir un identificador para MODIFICAR", "Introduzca ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            try {
                Usuario objeto = new Usuario()
                {
                    IdUsuario = int.Parse(txtidusuario.Text),
                };

                DialogResult result = MessageBox.Show("¿Está seguro de querer eliminar el usuario con id: " + txtidusuario.Text + " ?", "CONFIRMAR BORRADO", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    bool respuesta = UsuarioLogica.Instancia.Eliminar(objeto);

                    if (respuesta)
                    {
                        limpiar();
                        mostrar_usuarios();
                        MessageBox.Show("Usuario borrado correctamente", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (result == DialogResult.Cancel)
                {
                    MessageBox.Show("No se ha borrado el usuario " + txtidusuario.Text + ".", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Debe de introducir un identificador para ELIMINAR", "Introduzca ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtbuscador_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtbuscador.Text == null || txtbuscador.Text == "")
                {
                    mostrar_usuarios();
                }
                else
                {
                    SQLiteConnection conexion = new SQLiteConnection(cadena);
                    String query = "SELECT * FROM Usuarios WHERE " + comboBox1.Text + " LIKE '%" + txtbuscador.Text + "%'";
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, conexion);

                    conexion.Open();

                    DataSet data = new DataSet();
                    adapter.Fill(data, "Usuarios");

                    dgvusuarios.DataSource = data;
                    dgvusuarios.DataMember = "Usuarios";
                    dgvusuarios.AllowUserToAddRows = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("El valor introducido es inválido.", "VALOR NO VÁLIDO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }   
        }

        private void dgvusuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtidusuario.Text = dgvusuarios.CurrentRow.Cells[0].Value.ToString();
            txtnombre.Text = dgvusuarios.CurrentRow.Cells[1].Value.ToString();
            txtdepartamento.Text = dgvusuarios.CurrentRow.Cells[2].Value.ToString();
            txtinicio.Text = dgvusuarios.CurrentRow.Cells[5].Value.ToString();
        }

        private void buttonanotaciones_Click(object sender, EventArgs e)
        {
            Form2 ventana2 = new Form2();
            this.Hide();
            ventana2.Show();
        }

        private void btnarchivos_Click(object sender, EventArgs e)
        {
            Form3 ventana3 = new Form3();
            this.Hide();
            ventana3.Show();
        }

        private void iconolimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }
    }
}

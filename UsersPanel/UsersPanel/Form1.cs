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
using System.Diagnostics;

namespace UsersPanel
{
    public partial class UsersPanel : Form
    {
        private static string cadena = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;

        public UsersPanel()
        {
            InitializeComponent();
        }

        /**
         * MÉTOTO ENCARGADO DE ENVIAR LOS DATOS PARA QUE SE GUARDEN EN LA BASE DE DATOS AL PULSAR EL BOTÓN "GUARDAR"
         */
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
                }
            }
        }

        /**
         * MÉTODO ENCARGADO DE LLAMAR AL MÉTODO QUE LISTA LSO DATOS DE LA BBDD EN EL DATAGRIDVIEW
         */
        public void mostrar_usuarios()
        {
            dgvusuarios.DataSource = null;
            dgvusuarios.DataSource = UsuarioLogica.Instancia.Listar();
        }

        /**
         * MÉTODO QUE LIMPIA LOS TEXTBOX DEL FORMULARIO 
         */
        public void limpiar()
        {
            txtidusuario.Text = "";
            txtnombre.Text = "";
            txtdepartamento.Text = "";
            txtinicio.Text = "";
            txtnombre.Focus();
        }

        /**
         * MÉTODO QUE LLAMA AL MÉTODO QU LISTA LOS DATOS Y CARGA EL FORMULARIO
         */
        private void Form1_Load(object sender, EventArgs e)
        {
            mostrar_usuarios();
            dgvusuarios.Columns[0].Visible = false;
            labelNoRegistros.Hide();
            if (dgvusuarios.RowCount == 0)
            {
                dgvusuarios.Hide();
                labelNoRegistros.Show();
            }
        }

        /**
         * MÉTODO QUE ENVÍA LOS NUEVOS DATOS MODIFICADOS PARA QUE SE EDITEN EN LA BASE DE DATOS AL PULSAR EL BOTÓN "EDITAR"
         */
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
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Debe de introducir un identificador para MODIFICAR", "Introduzca ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /**
         * MÉTODO QUE SE ENCARGA DE MANDAR EL ID SELECCIONADO PARA QUE SEA ELIMINADO AL PULSAR EL BOTÓN "ELIMINAR"
         */
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

        /**
         * MÉTODO ENCARGADO DE BUSCAR EL TEXTO INTRODUCIDO EN EL TEXTBOX BUSCAODR FILTRANDO POR LA OPCIÓN SELECCIONADA EN EL COMBOBOX
         */
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
                    dgvusuarios.Columns[0].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("El valor introducido es inválido.", "VALOR NO VÁLIDO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }   
        }

        /**
         * MÉTODO QUE ESCRIBE LA INFORMACIÓN DE UNA FILA EN LOS TEXTBOX CUANDO HACES CLICK EN ELLAS
         */
        private void dgvusuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtidusuario.Text = dgvusuarios.CurrentRow.Cells[0].Value.ToString();
                txtnombre.Text = dgvusuarios.CurrentRow.Cells[1].Value.ToString();
                txtdepartamento.Text = dgvusuarios.CurrentRow.Cells[2].Value.ToString();
                txtinicio.Text = dgvusuarios.CurrentRow.Cells[5].Value.ToString();

                if (e.ColumnIndex == this.dgvusuarios.Columns["Nombre"].Index)
                {
                    abrir_detalles();
                }
            }
            catch (Exception ex) { }
        }

        /**
         * MÉTODO QUE REALIZA MODIFICACIONES VISUALES EN EL DATAGRIDVIEW 
         */
        private void dgvusuarios_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvusuarios.Columns[e.ColumnIndex].Name == "Nombre")
            {
                e.CellStyle.ForeColor = Color.Blue;
            }
        }

        /**
         * MÉTODO QUE ABRE LA VENTANA DE DETALLES DE UN USUARIO Y PASA SU ID AL HACRER CLICK EN EL
         */
        public void abrir_detalles()
        {
            string IdUsuario = dgvusuarios.CurrentRow.Cells[0].Value.ToString();
            string nombreUsuario = dgvusuarios.CurrentRow.Cells[1].Value.ToString();
            string departamento = dgvusuarios.CurrentRow.Cells[2].Value.ToString();
            string fechaInicio = dgvusuarios.CurrentRow.Cells[4].Value.ToString();
            Detalles detalles = new Detalles(IdUsuario, nombreUsuario, departamento, fechaInicio);
            detalles.Show();
        }

        /**
         * MÉTODO QUE CAMBIA LA VENTANA PRINCIPAL POR LA DE NOTAS
         */
        private void buttonanotaciones_Click(object sender, EventArgs e)
        {
            Form2 ventana2 = new Form2();
            this.Hide();
            ventana2.Show();
        }

        /**
         * MÉTODO QUE CAMBIA LA VENTANA PRINCIPAR POR LA DE ARCHIVOS
         */
        private void btnarchivos_Click(object sender, EventArgs e)
        {
            Form3 ventana3 = new Form3();
            this.Hide();
            ventana3.Show();
        }

        /**
         * MÉTODO QUE ABRE EL FORMULARIO PARA AÑADIR UNA NOTA
         */
        private void btnanadirnota_Click(object sender, EventArgs e)
        {
            FormAnadirNota anadirNotas = new FormAnadirNota();
            anadirNotas.Show();
        }

        /**
         * MÉTODO QUE ABRE EL FORMULARIO PARA AÑADIR ARCHIVOS
         */
        private void btnanadirarchivo_Click(object sender, EventArgs e)
        {
            FormAnadirArchivo anadirNotas = new FormAnadirArchivo();
            anadirNotas.Show();
        }

        /**
         * MÉTODO QUE ABRE LA VENTANA QUE MUESTRA LOS MENSAJES 
         */
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            FormMensajes mensajes = new FormMensajes();
            mensajes.Show();
        }

        /**
         * MÉTODO QUE LLAMA AL MÉTODO QUE LIMPIA LOS TEXTBOX AL PULSAR EL BOTÓN DE LIMPIAR
         */
        private void iconolimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }
    }
}

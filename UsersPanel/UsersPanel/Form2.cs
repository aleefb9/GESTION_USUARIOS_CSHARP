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

        /**
         * MÉTODO QUE LLENA EL COMBOBOX CON LOS NOMBRES DE LOS USUARIOS DE LA BASE DE DATOS
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
         * MÉTODO QUE COGE LOS DATOS DE LOS TEXTBOX Y LOS MANDA PARA GUARDARSE EN LA BASE DE DATOS 
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
                        mostrar_notas();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Debe rellenar los campos obligatorios", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /**
         * MÉTODO QUE LLAMA AL MÉTODO QUE LISTA LOS DATOS DE NOTAS
         */
        private void mostrar_notas()
        {
            dgvnotas.DataSource = null;
            dgvnotas.DataSource = NotaLogica.Instancia.Listar();
            dgvnotas.Columns[3].Visible = false;
            dgvnotas.Columns[0].Width = 100;
            dgvnotas.Columns[1].Width = 150;
            dgvnotas.Columns[4].Width = 200;
        }

        /**
         * MÉTODO QUE LIMPIA LOS TEXTBOX
         */
        private void limpiar()
        {
            txtidnota.Text = "";
            txttitulo.Text = "";
            txtdescripcion.Text = "";
            comboBox1.SelectedIndex = 0;
            txttitulo.Focus();
        }

        /**
         * MÉTODO QUE LLAMA AL MÉTODO QUE LISTA LOS DATOS AL CARGAR EL FORMULARIO
         */
        private void Form2_Load(object sender, EventArgs e)
        {
            mostrar_notas();
            dgvnotas.Columns[0].Visible = false;
            labelNoRegistros.Hide();
            if (dgvnotas.RowCount == 0)
            {
                dgvnotas.Hide();
                labelNoRegistros.Show();
            }
        }

        /**
         * MÉTODO QUE ENVÍA LOS NUEVOS DATOS PARA QUE SEAN EDITADOS
         */
        private void btneditarnotas_Click(object sender, EventArgs e)
        {
            try
            {
                Nota objeto = new Nota()
                {
                    IdNota = int.Parse(txtidnota.Text),
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
                    bool respuesta = NotaLogica.Instancia.Editar(objeto);

                    if (respuesta)
                    {
                        limpiar();
                        mostrar_notas();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Debe de introducir un identificador para MODIFICAR", "Introduzca ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        /**
         * MÉTODO QUE ENVÍA EL ID SELECCIONADO PARA BORRARLO
         */
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

        /**
         * MÉTODO QUE BUSCA SEGÚN EL TEXTO QUE ESTÉ ESCRITO EN EL BUSCADOR, FILTRANDO POR LA OPCIÓN SELECCIONADA EN EL COMBOBOX
         */
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
                    String query = "SELECT IdNota, Titulo, Descripcion, Nombre, FechaGuardado FROM Notas INNER JOIN Usuarios ON Notas.IdUsuario = Usuarios.Id WHERE " + comboBox33.Text + " LIKE '%" + txtbuscadornotas.Text + "%'";
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
                    dgvnotas.Columns[0].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("El valor introducido es inválido.", "VALOR NO VÁLIDO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /**
         * MÉTODO QUE COGE LOS DATOS DEL DATAGRIDVIEW Y LOS ESCRIBE EN LOS TEXTBOX CUANDO SE PULSA EN ALGÚN CAMPO 
         */
        private void dgvnotas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtidnota.Text = dgvnotas.CurrentRow.Cells[0].Value.ToString();
                txttitulo.Text = dgvnotas.CurrentRow.Cells[1].Value.ToString();
                txtdescripcion.Text = dgvnotas.CurrentRow.Cells[2].Value.ToString();
                comboBox1.SelectedValue = dgvnotas.CurrentRow.Cells[3].Value.ToString();
                dgvnotas.Columns[3].Visible = false;
            }
            catch (Exception ex) { }
        }

        /**
         * MÉTODO QUE CAMBIA DE LA VISTA DE NOTAS A LA VISTA REGISTROS
         */
        private void buttonregistros_Click(object sender, EventArgs e)
        {
            UsersPanel ventana1 = new UsersPanel();
            this.Hide();
            ventana1.Show();
        }

        /**
         * MÉTODO QUE CAMBIA DE LA VISTA DE NOTAS A LA DE ARCHIVOS
         */
        private void btnarchivos_Click(object sender, EventArgs e)
        {
            Form3 ventana3 = new Form3();
            this.Hide();
            ventana3.Show();
        }

        /**
         * MÉTODO QUE LLAMA AL MÉTODO QUE LIMPIA LOS CAMPOS AL PULAR EN EL BOTÓN LIMPIAR
         */
        private void iconolimpiar2_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        /**
         * MÉTODO QUE ABRE LA VENTANA QUE MUESTRA DE MENSAJES
         */
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            FormMensajes mensajes = new FormMensajes();
            mensajes.Show();
        }
    }
}

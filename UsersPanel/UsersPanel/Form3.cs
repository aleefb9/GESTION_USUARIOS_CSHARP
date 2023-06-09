﻿using System;
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
         * MÉTODO QUE ABRE EL EXPLORADOR DE ARCHIVOS Y INTRODUCE LA RUTA EN EL TEXTBOX CORRESPONDIENTE
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
         * MÉTODO QUE ABRE UN ARCHIVO SEGÚN LA RUTA ESCRITA EN EL TEXTBOX
         */
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(txtruta.Text);
            }
            catch { }
        }

        /**
         * MÉTODO QUE ENVÍA LOS DATOS QUE COGE DE LOS TEXTBOX PARA GUARDARLOS EN LA BASE DE DATOS
         */
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

            this.Refresh();
        }

        /**
         * MÉTODO QUE LLAMA AL MÉTODO QUE LISTA LOS DATOS EN EL DATAGRIDVIEW
         */
        private void mostrar_archivos()
        {
            dgvarchivos.DataSource = null;
            dgvarchivos.DataSource = ArchivoLogica.Instancia.Listar();
            dgvarchivos.Columns[3].Visible = false;
            dgvarchivos.Columns[0].Width = 100;
            dgvarchivos.Columns[1].Width = 150;
            dgvarchivos.Columns[4].Width = 200;
        }

        /**
         * MÉTODO QUE LIMPIA LOS DATOS DE LOS TEXTBOX
         */
        private void limpiar()
        {
            txtidarchivo.Text = "";
            txtnombrearchivo.Text = "";
            txtruta.Text = "";
            comboBox1.SelectedIndex = 0;
            txtnombrearchivo.Focus();
        }

        /**
         * MÉTODO QUE LLAMA AL MÉTODO QUE LISTA LOS DATOS Y CARGA EL FORMULARIO
         */
        private void Form3_Load(object sender, EventArgs e)
        {
            mostrar_archivos();

            this.txtruta.AutoSize = false;
            this.txtruta.Size = new System.Drawing.Size(291, 34);
            dgvarchivos.Columns[0].Visible = false;

            labelNoRegistros.Hide();
            if (dgvarchivos.RowCount == 0)
            {
                dgvarchivos.Hide();
                labelNoRegistros.Show();
            }
        }

        /**
         * MÉTODO QUE COGE LOS NUEVOS DATOS INTRODUCIDOS Y LOS EDITA
         */
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

        /**
         * MÉTODO QUE MANDA EL ID SELECCIONADO PARA SER BORRADO
         */
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
                        this.Refresh();
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

        /**
         * MÉTODO ENCARGADO DE BUSCAR EN EL DATAGRIDVIEW LOS DATOS INTRODUCIDOS POR EL BUSCADOR Y FILTRANDO POR EL COMBOBOX
         */ 
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
                    dgvarchivos.Columns[0].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("El valor introducido es inválido.", "valor no válido", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /**
         * MÉTODO QUE CUANDO SE PULSA EN UNA CELDA, COGE LOS DATOS DE LA FILA Y SE LAS PASA A LOS TEXTBOX
         */
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

        /**
         * MÉTODO QUE CAMBIA LOS ESTILOS DEL DATAGRIDVIEW
         */
        private void dgvarchivos_CellFormatting_1(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvarchivos.Columns[e.ColumnIndex].Name == "Ruta")
            {
                e.CellStyle.ForeColor = Color.Blue;
            }
        }

        /**
         * MÉTODO QUE CAMBIA DE LA VISTA ARCHIVOS A LA VISTA REGISTROS
         */
        private void btnregistros_Click(object sender, EventArgs e)
        {
            UsersPanel ventana1 = new UsersPanel();
            this.Hide();
            ventana1.Show();
        }

        /**
         * MÉTODO QUE CAMBIA DE LA VISRA ARCHIVOS A LA VISTA DE NOTAS
         */
        private void btnanotaciones_Click(object sender, EventArgs e)
        {
            Form2 ventana2 = new Form2();
            this.Hide();
            ventana2.Show();
        }

        /**
         * MÉTODO QUE LLAMA AL MÉTODO QUE LIMPIA LOS TEXTBOX
         */
        private void iconolimpiar2_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        /**
         * MÉTODO QUE ABRE LA VENTANA DE MENSAJES
         */
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            FormMensajes mensajes = new FormMensajes();
            mensajes.Show();
        }
    }
}

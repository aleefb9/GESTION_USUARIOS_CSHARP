using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UsersPanel.Logica;
using UsersPanel.Modelo;

namespace UsersPanel
{
    public partial class Detalles : Form
    {
        private static string cadena = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;
        private string idUsuario;
        private string nombreUsuario;
        private string departamento;
        private string fechaInicio;

        public Detalles(string idUsuario, string nombreUsuario, string departamento, string fechaInicio)
        {
            InitializeComponent();
            this.idUsuario = idUsuario;
            this.nombreUsuario = nombreUsuario;
            this.departamento = departamento;
            this.fechaInicio = fechaInicio;
        }

        /**
        * MÉTODO QUE MUESTRA NOTAS DEL USUARIO SELECCIONADO 
        */
        private void mostrar_detalles_notas()
        {
            SQLiteConnection conexion = new SQLiteConnection(cadena);
            String query = "SELECT Descripcion as Notas FROM Notas WHERE IdUsuario = " + idUsuario;

            SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, conexion);
            conexion.Open();

            SQLiteCommandBuilder builder = new SQLiteCommandBuilder(adapter);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            dgvNotas.ReadOnly = true;
            dgvNotas.DataSource = ds.Tables[0];
        }

        /**
         * MÉTODO QUE MUESTRA ARCHIVOS DEL USUARIO SELECCIONADO 
         */
        private void mostrar_detalles_rutas()
        {
            SQLiteConnection conexion = new SQLiteConnection(cadena);
            String query = "SELECT Ruta as Rutas FROM Archivos WHERE IdUsuario = " +idUsuario;

            SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, conexion);
            conexion.Open();

            SQLiteCommandBuilder builder = new SQLiteCommandBuilder(adapter);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            dgvrutas.ReadOnly = true;
            dgvrutas.DataSource = ds.Tables[0];
        }

        /**
         * MÉTODO QUE LLAMA AL MÉTODO QUE LISTA LOS DATOS PARA QUE SE MUESTREN AL CARGAR EL FOMRULARIO
         */
        private void Detalles_Load(object sender, EventArgs e)
        {
            mostrar_detalles_rutas();
            mostrar_detalles_notas();

            labelDetalles.Text = "Detalles de "+ nombreUsuario;
            labelNombre.Text = nombreUsuario;
            labelPerfil.Text = departamento;
            labelInicio.Text = fechaInicio;

            dgvNotas.ClearSelection();
            dgvNotas.CurrentCell = null;

            dgvrutas.ClearSelection();
            dgvrutas.CurrentCell = null;
        }

        /**
         * MÉTODO ENCARGADO DE CAMBIAR ESTILOS DE LA TABLA
         */
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvrutas.Columns[e.ColumnIndex].Name == "Rutas")
            {
                e.CellStyle.ForeColor = Color.Blue;
            }
        }

        /**
         * MÉTODO QUE ABRE UN ARCHIVO AL PULSAR EN LA RUTA 
         */
        private void dgvrutas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == this.dgvrutas.Columns["Rutas"].Index)
            {
                Process.Start(dgvrutas.CurrentRow.Cells[0].Value.ToString());
            }
        }

        /**
         * MÉTODO QUE CIERRA LA VENTANA
         */
        private void pictureBox10_Click(object sender, EventArgs e)
        {
            this.Close();   
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;
using UsersPanel.Modelo;
using System.Data.SQLite;

namespace UsersPanel.Logica
{
    public class UsuarioLogica
    {
        private static string cadena = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;
        private static UsuarioLogica _instancia = null;

        public static UsuarioLogica Instancia
        {
            get
            {
                if(_instancia == null)
                {
                    _instancia = new UsuarioLogica();
                }

                return _instancia;  
            }
        }

        /**
         * MÉTODO QUE GUARDA EN LA BASE DE DATOS LOS DATOS DE USUARIO RECIBIDOS 
         */
        public bool Guardar(Usuario obj)
        {
            bool respuesta = true;

            using (SQLiteConnection conexion = new SQLiteConnection(cadena))
            {
                conexion.Open();
                string query = "INSERT INTO Usuarios(Nombre, Departamento, Semanas, FechaIncorporacion, FechaInicio, Fecha2meses, Fecha3meses, Fecha4meses, Fecha5meses, Fecha6meses ) " +
                                "VALUES (@nombre,@departamento,@semanas,@fechaincorporacion,@fechainicio,@fecha2meses,@fecha3meses,@fecha4meses,@fecha5meses,@fecha6meses)";

                SQLiteCommand cmd = new SQLiteCommand(query, conexion);
                cmd.Parameters.Add(new SQLiteParameter("@nombre", obj.Nombre));
                cmd.Parameters.Add(new SQLiteParameter("@departamento", obj.Departamento));
                cmd.Parameters.Add(new SQLiteParameter("@semanas", obj.Semanas));
                cmd.Parameters.Add(new SQLiteParameter("@fechaincorporacion", obj.FechaIncorporacion));
                cmd.Parameters.Add(new SQLiteParameter("@fechainicio", obj.FechaInicio));
                cmd.Parameters.Add(new SQLiteParameter("@fecha2meses", obj.Fecha2meses));
                cmd.Parameters.Add(new SQLiteParameter("@fecha3meses", obj.Fecha3meses));
                cmd.Parameters.Add(new SQLiteParameter("@fecha4meses", obj.Fecha4meses));
                cmd.Parameters.Add(new SQLiteParameter("@fecha5meses", obj.Fecha5meses));
                cmd.Parameters.Add(new SQLiteParameter("@fecha6meses", obj.Fecha6meses));
                cmd.CommandType = System.Data.CommandType.Text;

                if (cmd.ExecuteNonQuery() < 1)
                {
                    respuesta = false;
                }
            }

            return respuesta;   
        }

        /**
         * MÉTODO QUE SACA DE LA BASE DE DATOS LOS DATOS DE USUARIO Y LOS LISTA EN EL DATAGRIDVIEW
         */
        public List<Usuario> Listar()
        {
            List<Usuario> oLista = new List<Usuario>();

            using (SQLiteConnection conexion = new SQLiteConnection(cadena))
            {
                conexion.Open();
                string query = "SELECT * FROM Usuarios";

                SQLiteCommand cmd = new SQLiteCommand(query, conexion);
                cmd.CommandType = System.Data.CommandType.Text;

                using (SQLiteDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        //Cálculo del número de total de semanas
                        DateTime FechaInicio = Convert.ToDateTime(dr["FechaInicio"]);
                        DateTime FechaHoy = DateTime.Today;
                        TimeSpan difFechas = FechaHoy - FechaInicio;
                        int dias = difFechas.Days;
                        int TotalSemanas = dias / 7;

                        oLista.Add(new Usuario()
                        {
                            IdUsuario = int.Parse(dr["Id"].ToString()),
                            Nombre = dr["Nombre"].ToString(),
                            Departamento = dr["Departamento"].ToString(),
                            Semanas = TotalSemanas.ToString(),
                            FechaIncorporacion = Convert.ToDateTime(dr["FechaInicio"]).ToString("dd/MM/yyyy"),
                            FechaInicio = Convert.ToDateTime(dr["FechaInicio"]).ToString("dd/MM/yyyy"),
                            Fecha2meses = Convert.ToDateTime(dr["FechaInicio"]).AddMonths(2).ToString("dd/MM/yyyy"),
                            Fecha3meses = Convert.ToDateTime(dr["FechaInicio"]).AddMonths(3).ToString("dd/MM/yyyy"),
                            Fecha4meses = Convert.ToDateTime(dr["FechaInicio"]).AddMonths(4).ToString("dd/MM/yyyy"),
                            Fecha5meses = Convert.ToDateTime(dr["FechaInicio"]).AddMonths(5).ToString("dd/MM/yyyy"),
                            Fecha6meses = Convert.ToDateTime(dr["FechaInicio"]).AddMonths(6).ToString("dd/MM/yyyy")
                        });
                    }
                }
            }
            return oLista;
        }

        /**
         * MÉTODO QUE EDITA LOS USUARIOS CON LOS NUEVOS DATOS ENVIADOS
         */
        public bool Editar(Usuario obj)
        {
            bool respuesta = true;

            using (SQLiteConnection conexion = new SQLiteConnection(cadena))
            {
                conexion.Open();
                string query = "UPDATE Usuarios SET Nombre = @nombre, Departamento = @departamento, FechaIncorporacion = @fechaincorporacion, FechaInicio = @fechainicio WHERE Id = @idusuario";

                SQLiteCommand cmd = new SQLiteCommand(query, conexion);
                cmd.Parameters.Add(new SQLiteParameter("@idusuario", obj.IdUsuario));
                cmd.Parameters.Add(new SQLiteParameter("@nombre", obj.Nombre));
                cmd.Parameters.Add(new SQLiteParameter("@departamento", obj.Departamento));
                cmd.Parameters.Add(new SQLiteParameter("@semanas", obj.Semanas));
                cmd.Parameters.Add(new SQLiteParameter("@fechaincorporacion", obj.FechaIncorporacion));
                cmd.Parameters.Add(new SQLiteParameter("@fechainicio", obj.FechaInicio));
                cmd.CommandType = System.Data.CommandType.Text;

                if (cmd.ExecuteNonQuery() < 1)
                {
                    respuesta = false;
                }
            }
            return respuesta;
        }

        /**
         * MÉTODO QUE ELIMINA AL USUARIO SELECCIONADO
         */
        public bool Eliminar(Usuario obj)
        {
            bool respuesta = true;

            using (SQLiteConnection conexion = new SQLiteConnection(cadena))
            {
                conexion.Open();
                string query = "DELETE FROM Usuarios WHERE Id = @idusuario";

                SQLiteCommand cmd = new SQLiteCommand(query, conexion);
                cmd.Parameters.Add(new SQLiteParameter("@idusuario", obj.IdUsuario));
                cmd.Parameters.Add(new SQLiteParameter("@nombre", obj.Nombre));
                cmd.Parameters.Add(new SQLiteParameter("@departamento", obj.Departamento));
                cmd.Parameters.Add(new SQLiteParameter("@semanas", obj.Semanas));
                cmd.Parameters.Add(new SQLiteParameter("@fechaincorporacion", obj.FechaIncorporacion));
                cmd.Parameters.Add(new SQLiteParameter("@fechainicio", obj.FechaInicio));
                cmd.CommandType = System.Data.CommandType.Text;

                if (cmd.ExecuteNonQuery() < 1)
                {
                    respuesta = false;
                }
            }

            return respuesta;
        }
    }
}

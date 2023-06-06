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
    public class NotaLogica
    {
        private static string cadena = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;
        private static NotaLogica _instancia = null;

        public static NotaLogica Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new NotaLogica();
                }

                return _instancia;
            }
        }

        /**
         * MÉTODO QUE GUARDA LA NOTA EN LA BASE DE DATOS
         */
        public bool Guardar(Nota obj)
        {
            bool respuesta = true;

            using (SQLiteConnection conexion = new SQLiteConnection(cadena))
            {
                conexion.Open();
                string query = "INSERT INTO Notas(Titulo, Descripcion, FechaGuardado, IdUsuario) " +
                                "VALUES (@titulo, @descripcion, @fechaguardado, @idusuario)";

                SQLiteCommand cmd = new SQLiteCommand(query, conexion);
                cmd.Parameters.Add(new SQLiteParameter("@titulo", obj.Titulo));
                cmd.Parameters.Add(new SQLiteParameter("@descripcion", obj.Descripcion));
                cmd.Parameters.Add(new SQLiteParameter("@fechaguardado", obj.FechaGuardado));
                cmd.Parameters.Add(new SQLiteParameter("@idusuario", obj.IdUsuario));
                cmd.CommandType = System.Data.CommandType.Text;

                if (cmd.ExecuteNonQuery() < 1)
                {
                    respuesta = false;
                }
            }

            return respuesta;
        }

        /**
         * MÉTODO QUE LISTA LAS NOTAS EN EL DATAGRIDVIEW
         */
        public List<Nota> Listar()
        {
            List<Nota> oLista = new List<Nota>();

            using (SQLiteConnection conexion = new SQLiteConnection(cadena))
            {
                conexion.Open();
                string query = "SELECT * FROM Notas INNER JOIN Usuarios ON Notas.IdUsuario = Usuarios.Id ORDER BY FechaGuardado DESC";

                SQLiteCommand cmd = new SQLiteCommand(query, conexion);
                cmd.CommandType = System.Data.CommandType.Text;

                using (SQLiteDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new Nota()
                        {
                            IdNota = int.Parse(dr["IdNota"].ToString()),
                            Titulo = dr["Titulo"].ToString(),
                            Descripcion = dr["Descripcion"].ToString(),
                            FechaGuardado = dr["FechaGuardado"].ToString(),
                            IdUsuario = int.Parse(dr["IdUsuario"].ToString()),
                            Usuario = dr["Nombre"].ToString()
                        });
                    }
                }
            }

            return oLista;
        }

        /**
         * MÉTODO QUE EDITA LAS NOTAS CON LOS NUEVOS DATOS ENVIADOS
         */
        public bool Editar(Nota obj)
        {
            bool respuesta = true;

            using (SQLiteConnection conexion = new SQLiteConnection(cadena))
            {
                conexion.Open();
                string query = "UPDATE Notas SET Titulo = @titulo, Descripcion = @descripcion, FechaGuardado = @fechaguardado, IdUsuario = @idusuario WHERE IdNota = @idnota";

                SQLiteCommand cmd = new SQLiteCommand(query, conexion);
                cmd.Parameters.Add(new SQLiteParameter("@idnota", obj.IdNota));
                cmd.Parameters.Add(new SQLiteParameter("@titulo", obj.Titulo));
                cmd.Parameters.Add(new SQLiteParameter("@descripcion", obj.Descripcion));
                cmd.Parameters.Add(new SQLiteParameter("@fechaguardado", obj.FechaGuardado));
                cmd.Parameters.Add(new SQLiteParameter("@idusuario", obj.IdUsuario));
                cmd.CommandType = System.Data.CommandType.Text;

                if (cmd.ExecuteNonQuery() < 1)
                {
                    respuesta = false;
                }
            }

            return respuesta;
        }

        /**
         * MÉTODO QUE ELIMINA LA NOTA SELECCIONADA
         */
        public bool Eliminar(Nota obj)
        {
            bool respuesta = true;

            using (SQLiteConnection conexion = new SQLiteConnection(cadena))
            {
                conexion.Open();
                string query = "DELETE FROM Notas WHERE IdNota = @idnota";

                SQLiteCommand cmd = new SQLiteCommand(query, conexion);
                cmd.Parameters.Add(new SQLiteParameter("@idnota", obj.IdNota));
                cmd.Parameters.Add(new SQLiteParameter("@titulo", obj.Titulo));
                cmd.Parameters.Add(new SQLiteParameter("@descripcion", obj.Descripcion));
                cmd.Parameters.Add(new SQLiteParameter("@fechaguardado", obj.FechaGuardado));
                cmd.Parameters.Add(new SQLiteParameter("@idusuario", obj.IdUsuario));
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

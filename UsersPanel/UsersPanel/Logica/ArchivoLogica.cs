using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using UsersPanel.Modelo;

namespace UsersPanel.Logica
{
    internal class ArchivoLogica
    {
        private static string cadena = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;
        private static ArchivoLogica _instancia = null;

        public static ArchivoLogica Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new ArchivoLogica();
                }

                return _instancia;
            }
        }

        public bool Guardar(Archivo obj)
        {
            bool respuesta = true;

            using (SQLiteConnection conexion = new SQLiteConnection(cadena))
            {
                conexion.Open();
                string query = "INSERT INTO Archivos(NombreArchivo, Ruta, IdUsuario) " +
                                "VALUES (@nombrearchivo, @ruta, @idusuario)";

                SQLiteCommand cmd = new SQLiteCommand(query, conexion);
                cmd.Parameters.Add(new SQLiteParameter("@nombrearchivo", obj.NombreArchivo));
                cmd.Parameters.Add(new SQLiteParameter("@ruta", obj.Ruta));
                cmd.Parameters.Add(new SQLiteParameter("@idusuario", obj.IdUsuario));
                cmd.CommandType = System.Data.CommandType.Text;

                if (cmd.ExecuteNonQuery() < 1)
                {
                    respuesta = false;
                }
            }

            return respuesta;
        }

        public List<Archivo> Listar()
        {
            List<Archivo> oLista = new List<Archivo>();

            using (SQLiteConnection conexion = new SQLiteConnection(cadena))
            {
                conexion.Open();
                string query = "SELECT * FROM Archivos INNER JOIN Usuarios ON Archivos.IdUsuario = Usuarios.Id";

                SQLiteCommand cmd = new SQLiteCommand(query, conexion);
                cmd.CommandType = System.Data.CommandType.Text;

                using (SQLiteDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new Archivo()
                        {
                            IdArchivo = int.Parse(dr["IdArchivo"].ToString()),
                            NombreArchivo = dr["NombreArchivo"].ToString(),
                            Ruta = dr["Ruta"].ToString(),
                            IdUsuario = int.Parse(dr["IdUsuario"].ToString()),
                            Usuario = dr["Nombre"].ToString()
                        });
                    }
                }
            }

            return oLista;
        }

        public bool Editar(Archivo obj)
        {
            bool respuesta = true;

            using (SQLiteConnection conexion = new SQLiteConnection(cadena))
            {
                conexion.Open();
                string query = "UPDATE Archivos SET NombreArchivo = @nombrearchivo, Ruta = @ruta, IdUsuario = @idusuario WHERE IdArchivo = @idarchivo";

                SQLiteCommand cmd = new SQLiteCommand(query, conexion);
                cmd.Parameters.Add(new SQLiteParameter("@idarchivo", obj.IdArchivo));
                cmd.Parameters.Add(new SQLiteParameter("@nombrearchivo", obj.NombreArchivo));
                cmd.Parameters.Add(new SQLiteParameter("@ruta", obj.Ruta));
                cmd.Parameters.Add(new SQLiteParameter("@idusuario", obj.IdUsuario));
                cmd.CommandType = System.Data.CommandType.Text;

                if (cmd.ExecuteNonQuery() < 1)
                {
                    respuesta = false;
                }
            }

            return respuesta;
        }

        public bool Eliminar(Archivo obj)
        {
            bool respuesta = true;

            using (SQLiteConnection conexion = new SQLiteConnection(cadena))
            {
                conexion.Open();
                string query = "DELETE FROM Archivos WHERE IdArchivo = @idarchivo";

                SQLiteCommand cmd = new SQLiteCommand(query, conexion);
                cmd.Parameters.Add(new SQLiteParameter("@idarchivo", obj.IdArchivo));
                cmd.Parameters.Add(new SQLiteParameter("@nombrearchivo", obj.NombreArchivo));
                cmd.Parameters.Add(new SQLiteParameter("@ruta", obj.Ruta));
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

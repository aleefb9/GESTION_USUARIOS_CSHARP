﻿using System;
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

        public bool Guardar(Nota obj)
        {
            bool respuesta = true;

            using (SQLiteConnection conexion = new SQLiteConnection(cadena))
            {
                conexion.Open();
                string query = "INSERT INTO Notas(Titulo, Descripcion, IdUsuario) " +
                                "VALUES (@titulo, @descripcion, @idusuario)";

                //int usuario = obj.IdUsuario + 1;

                SQLiteCommand cmd = new SQLiteCommand(query, conexion);
                cmd.Parameters.Add(new SQLiteParameter("@titulo", obj.Titulo));
                cmd.Parameters.Add(new SQLiteParameter("@descripcion", obj.Descripcion));
                cmd.Parameters.Add(new SQLiteParameter("@idusuario", obj.IdUsuario));
                cmd.CommandType = System.Data.CommandType.Text;

                if (cmd.ExecuteNonQuery() < 1)
                {
                    respuesta = false;
                }
            }

            return respuesta;
        }

        public List<Nota> Listar()
        {
            List<Nota> oLista = new List<Nota>();

            using (SQLiteConnection conexion = new SQLiteConnection(cadena))
            {
                conexion.Open();
                string query = "SELECT * FROM Notas INNER JOIN Usuarios ON Notas.IdUsuario = Usuarios.Id";

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
                            IdUsuario = int.Parse(dr["IdUsuario"].ToString()),
                            Usuario = dr["Nombre"].ToString()
                        });
                    }
                }
            }

            return oLista;
        }

        public bool Editar(Nota obj)
        {
            bool respuesta = true;

            using (SQLiteConnection conexion = new SQLiteConnection(cadena))
            {
                conexion.Open();
                string query = "UPDATE Notas SET Titulo = @titulo, Descripcion = @descripcion, IdUsuario = @idusuario WHERE IdNota = @idnota";

                SQLiteCommand cmd = new SQLiteCommand(query, conexion);
                cmd.Parameters.Add(new SQLiteParameter("@idnota", obj.IdNota));
                cmd.Parameters.Add(new SQLiteParameter("@titulo", obj.Titulo));
                cmd.Parameters.Add(new SQLiteParameter("@descripcion", obj.Descripcion));
                cmd.Parameters.Add(new SQLiteParameter("@idusuario", obj.IdUsuario));
                cmd.CommandType = System.Data.CommandType.Text;

                if (cmd.ExecuteNonQuery() < 1)
                {
                    respuesta = false;
                }
            }

            return respuesta;
        }

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

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UsersPanel.Modelo;

namespace UsersPanel.Logica
{
    internal class MensajeLogica
    {
        private static string cadena = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;
        private static MensajeLogica _instancia = null;

        public static MensajeLogica Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new MensajeLogica();
                }

                return _instancia;
            }
        }

        /**
         * MÉTODO QUE LISTA LOS DATOS NECESARIOS DE LOS MENSAJES CUÁNDO FALTE UNA SEMANA PARA CUMPLIR 2, 4 O 6 MESES
         */
        public List<Modelo.Mensajes> ListarMensajes()
        {
            List<Modelo.Mensajes> oLista = new List<Modelo.Mensajes>();

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
                        DateTime fecha2meses = Convert.ToDateTime(dr["FechaInicio"]).AddMonths(2);
                        DateTime fecha4meses = Convert.ToDateTime(dr["FechaInicio"]).AddMonths(4);
                        DateTime fecha6meses = Convert.ToDateTime(dr["FechaInicio"]).AddMonths(6);
                        DateTime FechaHoy = DateTime.Today;

                        var dias2meses = (fecha2meses - FechaHoy).TotalDays;
                        var dias4meses = (fecha4meses - FechaHoy).TotalDays;
                        var dias6meses = (fecha6meses - FechaHoy).TotalDays;


                        if (dias2meses > -7 && dias2meses < 0)
                        {
                            oLista.Add(new Modelo.Mensajes()
                            {
                                Usuario = dr["Nombre"].ToString(),
                                FechaInicio = dr["FechaInicio"].ToString(),
                                Mensaje = "Faltan " + (-1 * dias2meses) + " días para los 2 meses",
                            });
                        }
                        else if (dias4meses > -7 && dias4meses < 0)
                        {
                            oLista.Add(new Modelo.Mensajes()
                            {
                                Usuario = dr["Nombre"].ToString(),
                                FechaInicio = dr["FechaInicio"].ToString(),
                                Mensaje = "Faltan " + (-1 * dias4meses) + " días para los 4 meses",
                            });
                        }
                        else if(dias6meses > -7 && dias6meses < 0)
                        {
                            oLista.Add(new Modelo.Mensajes()
                            {
                                Usuario = dr["Nombre"].ToString(),
                                FechaInicio = dr["FechaInicio"].ToString(),
                                Mensaje = "Faltan " + (-1 * dias6meses) + " días para los 6 meses",
                            });
                        }
                        else if(dias2meses == 0)
                        {
                            oLista.Add(new Modelo.Mensajes()
                            {
                                Usuario = dr["Nombre"].ToString(),
                                FechaInicio = dr["FechaInicio"].ToString(),
                                Mensaje = "Hoy cumple 2 meses",
                            });
                        }
                        else if(dias4meses == 0)
                        {
                            oLista.Add(new Modelo.Mensajes()
                            {
                                Usuario = dr["Nombre"].ToString(),
                                FechaInicio = dr["FechaInicio"].ToString(),
                                Mensaje = "Hoy cumple 4 meses",
                            });
                        }
                        else if(dias6meses == 0)
                        {
                            oLista.Add(new Modelo.Mensajes()
                            {
                                Usuario = dr["Nombre"].ToString(),
                                FechaInicio = dr["FechaInicio"].ToString(),
                                Mensaje = "Hoy cumple 6 meses",
                            });
                        }
                    }
                }
            }
            return oLista;
        }
    }
}

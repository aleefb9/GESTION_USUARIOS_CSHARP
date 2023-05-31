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


    }
}

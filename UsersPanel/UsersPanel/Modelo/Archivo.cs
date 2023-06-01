using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersPanel.Modelo
{
    internal class Archivo
    {
        public int IdArchivo { get; set; }
        public string NombreArchivo { get; set; }
        public string Ruta { get; set; }
        public int IdUsuario { get; set; }
        public string Usuario { get; set; }
    }
}

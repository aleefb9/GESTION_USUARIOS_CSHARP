using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersPanel.Modelo
{
    public class Nota
    {
        public int IdNota { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public int IdUsuario { get; set; }
        public string Usuario { get; set; }
    }
}

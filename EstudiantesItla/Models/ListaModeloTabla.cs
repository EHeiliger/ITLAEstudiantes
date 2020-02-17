using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EstudiantesItla.Models
{
    public class ListaModeloTabla
    {
        public int Matricula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Carrera { get; set; }
        public string Status { get; set; }
    }
}
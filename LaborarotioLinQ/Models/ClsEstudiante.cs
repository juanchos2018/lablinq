using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaborarotioLinQ.Models
{
    public class ClsEstudiante
    {

        public string busqueda { get; set; }
        public string resultado { get; set; }

        public List<string> nombeE { get; set; }
        public List<double> notaE { get; set; }
        public int filas { get; set; }

    }
}
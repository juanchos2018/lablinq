using LaborarotioLinQ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LaborarotioLinQ.Controllers
{
    public class EstudianteNotaController : Controller
    {
        //ClsEstudianteNota o = new ClsEstudianteNota();
        String[] estudiantes = { "Robles", "Estrella", "Porlles", "Panty", "Lupaca", "Andia", "Condori", "Mamani", "Maquera", "Rodriguez", "Castro", "Linares", "Perez" };

        double[] notas = { 12, 12,14, 6, 11, 17, 20, 10,17, 11,4, 10.4, 5 };

        // GET: EstudianteNota
        public ActionResult Index(ClsEstudianteNota o)
        {

            string busqueda;
            if (o.busqueda!=null)
            {
                busqueda = o.busqueda;
                var query = (from e in estudiantes.Select((estudiantes, index) => new { estudiantes, index }) 
                             join n in notas.Select((notas, index) => new { notas, index })
                             on e.index equals n.index
                             where e.estudiantes.Contains(busqueda)
                             select new { e.estudiantes,n.notas}).ToList();

                foreach (var item in query)
                {
                    o.resultado += item + "\n";
                }
            }
            else
            {
                busqueda = o.busqueda;
                var query = (from e in estudiantes.Select((estudiantes, index) => new { estudiantes, index })
                             join n in notas.Select((notas, index) => new { notas, index })
                             on e.index equals n.index
                             
                             select new { e.estudiantes, n.notas }).ToList();

                foreach (var item in query)
                {
                    o.resultado += item + "\n";
                }

            }
            return View(o);
        }
    }
}
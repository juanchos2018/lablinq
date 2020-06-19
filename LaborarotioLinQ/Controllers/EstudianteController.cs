using LaborarotioLinQ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LaborarotioLinQ.Controllers
{
    public class EstudianteController : Controller
    {

        String[] estudiantes = { "Robles", "Estrella", "Porlles", "Panty", "Lupaca", "Andia", "Condori", "Mamani", "Maquera", "Rodriguez", "Castro", "Linares", "Perez" };

        double[] notas = { 12, 12, 14, 19, 11, 17, 20, 10, 17, 11, 4, 10.4, 5 };

     //  
           
        // GET: Estudiante
        public ActionResult Index(ClsEstudiante o)
        {
            string busqueda;
            o.nombeE = new List<string>();
            o.notaE = new List<double>();   

            if (o.busqueda != null)
            {
                string radibutton;
                radibutton = Request["notas"];

                if (radibutton==null)
                {
                    busqueda = o.busqueda;
                    var query = (from e in estudiantes.Select((estudiantes, index) => new { estudiantes, index })
                                 join n in notas.Select((notas, index) => new { notas, index })
                                 on e.index equals n.index
                                 where e.estudiantes.Contains(busqueda)
                                 select new { e.estudiantes, n.notas }).ToList();

                    foreach (var item in query)
                    {
                        o.nombeE.Add(item.estudiantes);
                        o.notaE.Add(item.notas);

                    }
                }
             else   if (radibutton.Equals("Nombre"))
                {
                    busqueda = o.busqueda;
                    var query = (from e in estudiantes.Select((estudiantes, index) => new { estudiantes, index })
                                 join n in notas.Select((notas, index) => new { notas, index })
                                 on e.index equals n.index
                                 where e.estudiantes == busqueda
                                 select new { e.estudiantes, n.notas }).ToList();

                    foreach (var item in query)
                    {
                        o.nombeE.Add(item.estudiantes);
                        o.notaE.Add(item.notas);
                    }

                }

               else if (radibutton.Equals("Nota"))
                {
                    
                    busqueda = o.busqueda;
                    var query = (from e in estudiantes.Select((estudiantes, index) => new { estudiantes, index })
                                 join n in notas.Select((notas, index) => new { notas, index })
                                 on e.index equals n.index
                                 where n.notas==Double.Parse(busqueda)
                                 select new { e.estudiantes, n.notas }).ToList();

                    foreach (var item in query)
                    {
                        o.nombeE.Add(item.estudiantes);
                        o.notaE.Add(item.notas);
                    }

                }
                else if (radibutton.Equals("Condicion"))
                {
                    busqueda = o.busqueda;

                    switch (busqueda)
                    {
                        case "Aprobados":

                            var query = (from e in estudiantes.Select((estudiantes, index) => new { estudiantes, index })
                                         join n in notas.Select((notas, index) => new { notas, index })
                                         on e.index equals n.index
                                         where n.notas >10.5
                                         select new { e.estudiantes, n.notas }).ToList();

                            foreach (var item in query)
                            {
                                o.nombeE.Add(item.estudiantes);
                                o.notaE.Add(item.notas);
                            }


                            break;

                        case "Desprobados":

                            var query2 = (from e in estudiantes.Select((estudiantes, index) => new { estudiantes, index })
                                         join n in notas.Select((notas, index) => new { notas, index })
                                         on e.index equals n.index
                                         where n.notas < 10.5
                                         select new { e.estudiantes, n.notas }).ToList();

                            foreach (var item in query2)
                            {
                                o.nombeE.Add(item.estudiantes);
                                o.notaE.Add(item.notas);
                            }

                            break;
                        default:
                            break;
                    }

                }
                else
                {
                    busqueda = o.busqueda;
                    var query = (from e in estudiantes.Select((estudiantes, index) => new { estudiantes, index })
                                 join n in notas.Select((notas, index) => new { notas, index })
                                 on e.index equals n.index
                                 where e.estudiantes.Contains(busqueda)
                                 select new { e.estudiantes, n.notas }).ToList();

                    foreach (var item in query)
                    {
                        o.nombeE.Add(item.estudiantes);
                        o.notaE.Add(item.notas);

                    }

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
                    o.nombeE.Add(item.estudiantes);
                    o.notaE.Add(item.notas);

                }

            }

           
            o.filas = o.nombeE.Count();

            return View(o);
        }
    }
}
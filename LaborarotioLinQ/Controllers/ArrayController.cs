using LaborarotioLinQ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LaborarotioLinQ.Controllers
{
    public class ArrayController : Controller
    {
        // GET: Array

        String[] estudiantes = { "Robles", "Estrella", "Porlles", "Panty", "Lupaca", "Andia", "Condori", "Mamani","Maquera","Rodriguez","Castro","Linares","Perez" };

        List<ClsEstudiantes2> lista = new List<ClsEstudiantes2>();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SelectMany()
        {
            var query = estudiantes.SelectMany(e => e.ToCharArray());
            foreach (char item in query)
            {

                // ViewData["Resultado"] += Convert.ToString(item)+"\n";
             //   ViewData["Resultado"] += item + "\n";
                ClsEstudiantes2 o = new ClsEstudiantes2();
                o.Nombre = item.ToString();
                lista.Add(o);

            }

            return View(lista);
        }
        public ActionResult Listar()
        {
            var query = estudiantes.ToList();

            foreach (object item in query)
            {
                ClsEstudiantes2 o = new ClsEstudiantes2();
                o.Nombre = item.ToString();
                lista.Add(o);

            }

            return View(lista);
        }

        public ActionResult Reverse()
        {
            string[] estudiantes_reverse=estudiantes.Reverse().ToArray();

            //var query = estudiantes.Reverse();

            foreach (var item in estudiantes_reverse)
            {

                // ViewData["Resultado"] += Convert.ToString(item)+"\n";
               // ViewData["Resultado"] += item + "\n";
                ClsEstudiantes2 o = new ClsEstudiantes2();
                o.Nombre = item.ToString();
                lista.Add(o);

            }

            return View(lista);
        }

        public ActionResult Where()
        {            //string[] estudiantes_reverse = estudiantes.Reverse().ToArray();

         //   var query = from e in estudiantes where  e.StartsWith("C") select new { Estdiante = e };
           var query = estudiantes.Where(r => r.StartsWith("C"));

            foreach (var item in query)
            {
                // ViewData["Resultado"] += Convert.ToString(item)+"\n";
              //  ViewData["Resultado"] += item + "\n";
                ClsEstudiantes2 o = new ClsEstudiantes2();
                o.Nombre = item.ToString();
                lista.Add(o);
            }

            return View(lista);
        }
        public ActionResult Where2()
        {     
            // que contengoa la letra  e
           // var query = from e in estudiantes where e.ToLowerInvariant().Contains("e") 
                      //  select new { Estdiante = e };

            var query2 = estudiantes.Where(r => r.ToLowerInvariant().Contains("e"));
            foreach (var item in query2)
            {
                // ViewData["Resultado"] += Convert.ToString(item)+"\n";
              //  ViewData["Resultado"] += item + "\n";
                ClsEstudiantes2 o = new ClsEstudiantes2();
                o.Nombre = item.ToString();
                lista.Add(o);
            }

            return View(lista);
        }
        public ActionResult Where3()
        {
            // que contengoa la letra  e
            var query = from e in estudiantes
                        where e.Length>6
                        select new { Estdiante = e };

            var query2 = estudiantes.Where(r => r.Length>6);

            foreach (var item in query2)
            {
                // ViewData["Resultado"] += Convert.ToString(item)+"\n";
              //  ViewData["Resultado"] += item + "\n";

                ClsEstudiantes2 o = new ClsEstudiantes2();
                o.Nombre = item.ToString();
                lista.Add(o);
            }

            return View(lista);
        }

        public ActionResult Where4()
        {
            // que contengoa la letra  e
            var query = from e in estudiantes
                        where e.Length > 6
                        select new { Estdiante = e };

            foreach (var item in query)
            {
                // ViewData["Resultado"] += Convert.ToString(item)+"\n";
               // ViewData["Resultado"] += item + "\n";
                ClsEstudiantes2 o = new ClsEstudiantes2();
                o.Nombre = item.ToString();
                lista.Add(o);
            }

            return View(lista);
        }
    }
}
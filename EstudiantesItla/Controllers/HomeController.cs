using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EstudiantesItla.Models;

namespace EstudiantesItla.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            List<ListaModeloTabla> Lst;
            using (ITLAEntities1 db= new ITLAEntities1())
            {
                    Lst = (from d in db.Estudiantes
                    select new ListaModeloTabla()
                    {
                        Nombre = d.Nombre,
                        Apellido = d.Apellido,
                        Carrera = d.Carrera,
                        Matricula = d.Matricula,
                        Status = d.Status
                    }).ToList();
            }
            return View(Lst);
        }

        public ActionResult AddNuevo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GuardarNuevo(string Nombre,string Apellido, string Carrera)
        {
            using (ITLAEntities1 db = new ITLAEntities1())
            {
                var datos = new Estudiantes();
                datos.Nombre = Nombre;
                datos.Apellido = Apellido;
                datos.Carrera = Carrera;
                datos.Status = "t";
                db.Estudiantes.Add(datos);
                db.SaveChanges();
            }

            return Redirect("/home");
            
        }
        [HttpPost]
        public ActionResult Editar(int id)
        {
            ListaModeloTabla model = new ListaModeloTabla();
            using (ITLAEntities1 db = new ITLAEntities1())
            {
                var Estudiante = db.Estudiantes.Find(id);
                model.Nombre = Estudiante.Nombre;
                model.Apellido = Estudiante.Apellido;
                model.Carrera = Estudiante.Carrera;
                model.Status = Estudiante.Status;
                model.Matricula = id;
            }

            return View(model);

        }

        [HttpPost]
        public ActionResult GuardarCambio(int Matricula, string Apellido, string Nombre, string Status, string Carrera)
        {
            using (ITLAEntities1 db = new ITLAEntities1())
            {
                
                var estudiante = db.Estudiantes.Find(Matricula);
                estudiante.Nombre = Nombre;
                estudiante.Apellido = Apellido;
                estudiante.Carrera = Carrera;
                estudiante.Status = Status;
                db.Entry(estudiante).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }

            return Redirect("/home");
        }
        [HttpPost]
        public ActionResult Eliminar(int id)
        {
            using (ITLAEntities1 db = new ITLAEntities1())
            {
                var estudiante = db.Estudiantes.Find(id);
                db.Estudiantes.Remove(estudiante);
                db.SaveChanges();
            }

            return Redirect("/home");
        }
    }
    
}
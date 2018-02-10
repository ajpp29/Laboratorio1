using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab1_ED.DBContext;
using System.Net;

namespace Lab1_ED.Controllers
{
    public class PersonaController : Controller
    {
        public DefaultConnection db = DefaultConnection.getInstance;

        // GET: Persona
        public ActionResult Index()
        {
            return View(db.Personas.ToList());
        }

        // GET: Persona/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Persona/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Persona/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include ="PersonaID, Nombre, Apellido, Edad")]Models.Persona persona)
        {
            if (ModelState.IsValid)
            {
                persona.PersonaID = ++db.IdActual; //Incrementa el id de la pesona
                db.Personas.Add(persona);
                return RedirectToAction("Index");
            }

            return View(persona);
        }

        // GET: Persona/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Models.Persona persona = db.Personas.Find(x => x.PersonaID == id);

            if (persona == null)
            {
                return HttpNotFound();
            }

            return View(persona);
        }

        // POST: Persona/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PersonaID,Nombre,Apellido,Edad")] Models.Persona persona)
        {
            if (ModelState.IsValid)
            {
                Models.Persona modifiedPesona = db.Personas.Find(x => x.PersonaID == persona.PersonaID);

                if (modifiedPesona == null)
                {
                    return HttpNotFound();
                }

                modifiedPesona.Nombre = persona.Nombre;
                modifiedPesona.Apellido = persona.Apellido;
                modifiedPesona.Edad = persona.Edad;                     
                return View(modifiedPesona);
            }

            return RedirectToAction("Index");
        }

        // GET: Persona/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Persona/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

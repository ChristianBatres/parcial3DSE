using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_DataBase.Models;

namespace MVC_DataBase.Controllers
{
    public class clientesController : Controller
    {
        private tienda db = new tienda();

        // GET: clientes
        public ActionResult Index()
        {
            return View(db.clientes.ToList());
        }

        // GET: clientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            clientes clientes = db.clientes.Find(id);
            if (clientes == null)
            {
                return HttpNotFound();
            }
            return View(clientes);
        }

        // GET: clientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: clientes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,mombreCompleto,Direccion,Telefono")] clientes clientes)
        {
            if (ModelState.IsValid)
            {
                db.clientes.Add(clientes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(clientes);
        }

        // GET: clientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            clientes clientes = db.clientes.Find(id);
            if (clientes == null)
            {
                return HttpNotFound();
            }
            return View(clientes);
        }

        // POST: clientes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,mombreCompleto,Direccion,Telefono")] clientes clientes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clientes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clientes);
        }

        // GET: clientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            clientes clientes = db.clientes.Find(id);
            if (clientes == null)
            {
                return HttpNotFound();
            }
            return View(clientes);
        }

        // POST: clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            clientes clientes = db.clientes.Find(id);
            db.clientes.Remove(clientes);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


        [HttpPost]
        public Int32 Agregar(clientes clientes)
        {
            try
            {
                // lista inicial de ususarios
                var lista = clientes.Listar();
                if (String.IsNullOrEmpty(clientes.mombreCompleto))
                    return 6;
                if (String.IsNullOrEmpty(clientes.Direccion))
                    return 7;
                if (String.IsNullOrEmpty(clientes.Telefono))
                    return 8;
                if (lista.Where(x => x.mombreCompleto == clientes.mombreCompleto).Any())
                    return 1;
                lista.Add(clientes);
                return 0;
            }
            catch
            {
                return 1;
            }
        }
    }
}

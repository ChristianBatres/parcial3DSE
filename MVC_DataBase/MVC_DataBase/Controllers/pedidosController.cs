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
    public class pedidosController : Controller
    {
        private tienda db = new tienda();

        // GET: pedidos
        public ActionResult Index()
        {
            var pedidos = db.pedidos.Include(p => p.cliente).Include(p => p.producto);
            return View(pedidos.ToList());
        }

        // GET: pedidos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pedidos pedidos = db.pedidos.Find(id);
            if (pedidos == null)
            {
                return HttpNotFound();
            }
            return View(pedidos);
        }

        // GET: pedidos/Create
        public ActionResult Create()
        {
            ViewBag.cliente_Id = new SelectList(db.clientes, "id", "mombreCompleto");
            ViewBag.producto_Id = new SelectList(db.productos, "id", "mombreProducto");
            return View();
        }

        // POST: pedidos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,cantidad,cliente_Id,producto_Id")] pedidos pedidos)
        {
            if (ModelState.IsValid)
            {
                db.pedidos.Add(pedidos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cliente_Id = new SelectList(db.clientes, "id", "mombreCompleto", pedidos.cliente_Id);
            ViewBag.producto_Id = new SelectList(db.productos, "id", "mombreProducto", pedidos.producto_Id);
            return View(pedidos);
        }

        // GET: pedidos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pedidos pedidos = db.pedidos.Find(id);
            if (pedidos == null)
            {
                return HttpNotFound();
            }
            ViewBag.cliente_Id = new SelectList(db.clientes, "id", "mombreCompleto", pedidos.cliente_Id);
            ViewBag.producto_Id = new SelectList(db.productos, "id", "mombreProducto", pedidos.producto_Id);
            return View(pedidos);
        }

        // POST: pedidos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,cantidad,cliente_Id,producto_Id")] pedidos pedidos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pedidos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cliente_Id = new SelectList(db.clientes, "id", "mombreCompleto", pedidos.cliente_Id);
            ViewBag.producto_Id = new SelectList(db.productos, "id", "mombreProducto", pedidos.producto_Id);
            return View(pedidos);
        }

        // GET: pedidos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pedidos pedidos = db.pedidos.Find(id);
            if (pedidos == null)
            {
                return HttpNotFound();
            }
            return View(pedidos);
        }

        // POST: pedidos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            pedidos pedidos = db.pedidos.Find(id);
            db.pedidos.Remove(pedidos);
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
        public Int32 Agregar(pedidos pedidos)
        {
            try
            {
                // lista inicial de ususarios
                var lista = pedidos.Listar();
                if (String.IsNullOrEmpty(Convert.ToString(pedidos.cantidad)))
                    return 6;
                if (String.IsNullOrEmpty(Convert.ToString(pedidos.cliente_Id)))
                    return 7;
                if (String.IsNullOrEmpty(Convert.ToString(pedidos.producto_Id)))
                    return 8;
                if (pedidos.cantidad < 1)
                    return 3;
                lista.Add(pedidos);
                return 0;
            }
            catch
            {
                return 1;
            }
        }
    }
}

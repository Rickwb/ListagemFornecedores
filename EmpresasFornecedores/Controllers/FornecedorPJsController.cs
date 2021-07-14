using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EmpresasFornecedores.DAL;

namespace EmpresasFornecedores.Controllers
{
    public class FornecedorPJsController : Controller
    {
        private ProjetoEmpresasEntities db = new ProjetoEmpresasEntities();

        // GET: FornecedorPJs
        public ActionResult PJIndex()
        {
            var fornecedorPJ = db.FornecedorPJ.Include(f => f.Empresa);
            return View(fornecedorPJ.ToList());
        }

        // GET: FornecedorPJs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FornecedorPJ fornecedorPJ = db.FornecedorPJ.Find(id);
            if (fornecedorPJ == null)
            {
                return HttpNotFound();
            }
            return View(fornecedorPJ);
        }

        // GET: FornecedorPJs/Create
        public ActionResult Create()
        {
            ViewBag.EmpresaId = new SelectList(db.Empresa, "Id", "CNPJ");
            return View();
        }

        // POST: FornecedorPJs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,EmpresaId,FornecedorNome,FornecedorCNPJ,Telefone")] FornecedorPJ fornecedorPJ)
        {
            if (ModelState.IsValid)
            {
                fornecedorPJ.DataCadastro = DateTime.Now;
                db.FornecedorPJ.Add(fornecedorPJ);
                db.SaveChanges();
                return RedirectToAction("PJIndex");
            }

            ViewBag.EmpresaId = new SelectList(db.Empresa, "Id", "NomeFantasia", fornecedorPJ.EmpresaId);
            return View(fornecedorPJ);
        }

        // GET: FornecedorPJs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FornecedorPJ fornecedorPJ = db.FornecedorPJ.Find(id);
            if (fornecedorPJ == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmpresaId = new SelectList(db.Empresa, "Id", "NomeFantasia", fornecedorPJ.EmpresaId);
            return View(fornecedorPJ);
        }

        // POST: FornecedorPJs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,EmpresaId,FornecedorNome,FornecedorCNPJ,DataCadastro,Telefone")] FornecedorPJ fornecedorPJ)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fornecedorPJ).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("PJIndex");
            }
            ViewBag.EmpresaId = new SelectList(db.Empresa, "Id", "NomeFantasia", fornecedorPJ.EmpresaId);
            return View(fornecedorPJ);
        }

        // GET: FornecedorPJs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FornecedorPJ fornecedorPJ = db.FornecedorPJ.Find(id);
            if (fornecedorPJ == null)
            {
                return HttpNotFound();
            }
            return View(fornecedorPJ);
        }

        // POST: FornecedorPJs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FornecedorPJ fornecedorPJ = db.FornecedorPJ.Find(id);
            db.FornecedorPJ.Remove(fornecedorPJ);
            db.SaveChanges();
            return RedirectToAction("PJIndex");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

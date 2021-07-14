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
    public class FornecedorPFsController : Controller
    {
        private ProjetoEmpresasEntities db = new ProjetoEmpresasEntities();

        // GET: FornecedorPFs
        public ActionResult PFIndex()
        {
            var fornecedorPF = db.FornecedorPF.Include(f => f.Empresa);
            return View(fornecedorPF.ToList());
        }

        // GET: FornecedorPFs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FornecedorPF fornecedorPF = db.FornecedorPF.Find(id);
            if (fornecedorPF == null)
            {
                return HttpNotFound();
            }
            return View(fornecedorPF);
        }

        // GET: FornecedorPFs/Create
        public ActionResult Create()
        {
            ViewBag.EmpresaId = new SelectList(db.Empresa, "Id", "CNPJ");
            return View();
        }

        // POST: FornecedorPFs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,EmpresaId,FornecedorNome,FornecedorCPF,FornecedorRG,DataNascimento,Telefone")] FornecedorPF fornecedorPF)
        {

            if (ModelState.IsValid && ValidarParana(fornecedorPF))
            {
                fornecedorPF.DataCadastro = DateTime.Now;
                db.FornecedorPF.Add(fornecedorPF);
                db.SaveChanges();
                return RedirectToAction("PFIndex");
            }

            ViewBag.EmpresaId = new SelectList(db.Empresa, "Id", "NomeFantasia", fornecedorPF.EmpresaId);
            return View(fornecedorPF);
        }

        // GET: FornecedorPFs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FornecedorPF fornecedorPF = db.FornecedorPF.Find(id);
            if (fornecedorPF == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmpresaId = new SelectList(db.Empresa, "Id", "NomeFantasia", fornecedorPF.EmpresaId);
            return View(fornecedorPF);
        }

        // POST: FornecedorPFs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,EmpresaId,FornecedorNome,FornecedorCPF,FornecedorRG,DataNascimento,DataCadastro,Telefone")] FornecedorPF fornecedorPF)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fornecedorPF).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("PFIndex");
            }
            ViewBag.EmpresaId = new SelectList(db.Empresa, "Id", "NomeFantasia", fornecedorPF.EmpresaId);
            return View(fornecedorPF);
        }

        // GET: FornecedorPFs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FornecedorPF fornecedorPF = db.FornecedorPF.Find(id);
            if (fornecedorPF == null)
            {
                return HttpNotFound();
            }
            return View(fornecedorPF);
        }

        // POST: FornecedorPFs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FornecedorPF fornecedorPF = db.FornecedorPF.Find(id);
            db.FornecedorPF.Remove(fornecedorPF);
            db.SaveChanges();
            return RedirectToAction("PFIndex");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public bool ValidarParana(FornecedorPF fornecedorPF)
        {
            System.TimeSpan timediff = System.DateTime.Now.Subtract(fornecedorPF.DataNascimento.Value);
            int idade = Math.Abs(timediff.Days / 365);
            Empresa emp = db.Empresa.Find(fornecedorPF.EmpresaId);
            if (emp.UF=="PR"||emp.UF=="pr")
            {
                if (idade > 18)
                    return true;
                else
                    return false;
                
            }
            return true;
        }
    }
}

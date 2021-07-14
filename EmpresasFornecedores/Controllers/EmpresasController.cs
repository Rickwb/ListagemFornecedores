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
    public class EmpresasController : Controller
    {
        private ProjetoEmpresasEntities db = new ProjetoEmpresasEntities();

        // GET: Empresas
        public ActionResult EmpIndex()
        {
            return View(db.Empresa.ToList());
        }

        // GET: Empresas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empresa empresa = db.Empresa.Find(id);
            if (empresa == null)
            {
                return HttpNotFound();
            }
            return View(empresa);
        }

        // GET: Empresas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Empresas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NomeFantasia,CNPJ,UF")] Empresa empresa)
        {
            if (ModelState.IsValid)
            {
                db.Empresa.Add(empresa);
                db.SaveChanges();
                return RedirectToAction("EmpIndex");
            }

            return View(empresa);
        }

        // GET: Empresas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empresa empresa = db.Empresa.Find(id);
            if (empresa == null)
            {
                return HttpNotFound();
            }
            return View(empresa);
        }

        // POST: Empresas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NomeFantasia,CNPJ,UF")] Empresa empresa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empresa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("EmpIndex");
            }
            return View(empresa);
        }

        // GET: Empresas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empresa empresa = db.Empresa.Find(id);
            if (empresa == null)
            {
                return HttpNotFound();
            }
            return View(empresa);
        }

        // POST: Empresas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Empresa empresa = db.Empresa.Find(id);
            db.Empresa.Remove(empresa);
            db.SaveChanges();
            return RedirectToAction("EmpIndex");
        }
        public ActionResult EmpresaFornecedores(int id)
        {
            return View(db.Empresa.Where(a => a.Id == id).FirstOrDefault());
        }
        public ActionResult _ListarFornecedoresPFPorEmpresa(int empresaId, string pesquisa2, string Rdb)
        {
            var lista = db.FornecedorPF.Where(a => a.EmpresaId == empresaId).ToList();
            if (String.IsNullOrEmpty(pesquisa2))
            {
                return PartialView(lista);
            }
            var pfNome = lista.Where(x => x.FornecedorNome.Contains(pesquisa2));
            var pfCpf = lista.Where(x => x.FornecedorCPF == (pesquisa2));
            var pfDataCadastro = lista.Where(x => x.DataCadastro.ToString().Contains(pesquisa2));
            if (!String.IsNullOrEmpty(Rdb))
            {
                try
                {
                    switch (Rdb)
                    {
                        case "Nome":
                            return PartialView(pfNome.ToList());
                        case "Cpf":
                            return PartialView(pfCpf.ToList());
                        case "DataCadastro":
                            return PartialView(pfDataCadastro.ToList());
                        default:
                            return PartialView();
                    }


                }
                catch (NullReferenceException)
                {
                    return PartialView();
                    
                }
            }
                return PartialView();
            //if (pfNome.Count()==0)
            //{
            //    return PartialView(pfNome.ToList());
            //}else if (pfCpf.Count()==0)
            //{
            //    return PartialView(pfCpf.ToList());
            //}
            //else
            //{
            //    return PartialView(pfDataCadastro.ToList());

            //}
        }
        public  ActionResult _ListarFornecedoresPJPorEmpresa(int empresaId,string pesquisa1, string Rdb)
        {
               var lista =db.FornecedorPJ.Where(a => a.EmpresaId == empresaId).ToList();
            if (String.IsNullOrEmpty(pesquisa1))
            {
            return PartialView(lista);

            }
            
            
                var pjNome = lista.Where(x => x.FornecedorNome.Contains(pesquisa1));
                var pjCnpj =  lista.Where(x => x.FornecedorCNPJ.Contains(pesquisa1));
                var pjDataCadastro = lista.Where(x => x.DataCadastro.ToString().Contains(pesquisa1));
            if (!String.IsNullOrEmpty(Rdb))
            {
                try
                {
                    switch (Rdb)
                    {
                        case "Nome":
                            return PartialView(pjNome.ToList());
                        case "Cpf":
                            return PartialView(pjCnpj.ToList());
                        case "DataCadastro":
                            return PartialView(pjDataCadastro.ToList());
                        default:
                            return PartialView(lista);
                    }


                }
                catch (NullReferenceException)
                {
                    return PartialView();

                }
            }
                return PartialView();

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


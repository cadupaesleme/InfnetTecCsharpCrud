using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InfnetTecCsharpCrud.Infraestrutura;
using InfnetTecCsharpCrud.Models;

namespace InfnetTecCsharpCrud.Controllers
{
    public class FornecedorController : Controller
    {
        private Context db = new Context();

        // GET: Fornecedor
        public ActionResult Index()
        {
            return View(db.PessoaJuridica.ToList());
        }

        // GET: Fornecedor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PessoaJuridica pessoaJuridica = db.PessoaJuridica.Find(id);
            if (pessoaJuridica == null)
            {
                return HttpNotFound();
            }
            return View(pessoaJuridica);
        }

        // GET: Fornecedor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Fornecedor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodigoPessoa,Nome,Endereco,CNPJ,Ativa")] PessoaJuridica pessoaJuridica)
        {
            if (ModelState.IsValid)
            {
                db.Pessoa.Add(pessoaJuridica);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pessoaJuridica);
        }

        // GET: Fornecedor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PessoaJuridica pessoaJuridica = db.PessoaJuridica.Find(id);
            if (pessoaJuridica == null)
            {
                return HttpNotFound();
            }
            return View(pessoaJuridica);
        }

        // POST: Fornecedor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodigoPessoa,Nome,Endereco,CNPJ,Ativa")] PessoaJuridica pessoaJuridica)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pessoaJuridica).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pessoaJuridica);
        }

        // GET: Fornecedor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PessoaJuridica pessoaJuridica = db.PessoaJuridica.Find(id);
            if (pessoaJuridica == null)
            {
                return HttpNotFound();
            }
            return View(pessoaJuridica);
        }

        // POST: Fornecedor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PessoaJuridica pessoaJuridica = db.PessoaJuridica.Find(id);
            db.Pessoa.Remove(pessoaJuridica);
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
    }
}

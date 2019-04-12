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
    public class PedidoController : Controller
    {
        private Context db = new Context();

        // GET: Pedido
        public ActionResult Index()
        {
            var pedido = db.Pedido.Include(p => p.Comprador).Include(p => p.Vendedor);
            return View(pedido.ToList());
        }

        // GET: Pedido/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedido pedido = db.Pedido.Find(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            return View(pedido);
        }

        // GET: Pedido/Create
        public ActionResult Create()
        {
            ViewBag.CodigoComprador = new SelectList(db.PessoaFisica, "CodigoPessoa", "Nome");
            ViewBag.CodigoVendedor = new SelectList(db.PessoaJuridica, "CodigoPessoa", "Nome");
            ViewBag.Produto = db.Produto;
            return View();
        }

        // POST: Pedido/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create(Pedido pedido)
        {
            var retorno = "";

            try
            {
                if (ModelState.IsValid)
                {
                    Pedido _pedido = db.Pedido.Find(pedido.CodigoPedido);

                    if (pedido.CodigoPedido > 0)
                    {
                        _pedido.CodigoComprador = pedido.CodigoComprador;
                        _pedido.CodigoVendedor = pedido.CodigoVendedor;

                        //deletar os itens e criar novamente
                        foreach(var item in _pedido.Itens.ToList())
                        {
                            db.Item.Remove(db.Item.Find(item.CodigoItem));
                        }

                        _pedido.Itens = pedido.Itens;

                        db.Entry(_pedido).State = EntityState.Modified;
                    }
                    else
                    {
                        pedido.DataPedido = DateTime.Now;                        
                        db.Pedido.Add(pedido);
                    }

                    db.SaveChanges();
                    retorno = "Success";
                }

                ViewBag.CodigoComprador = new SelectList(db.PessoaFisica, "CodigoPessoa", "Nome", pedido.CodigoComprador);
                ViewBag.CodigoVendedor = new SelectList(db.PessoaJuridica, "CodigoPessoa", "Nome", pedido.CodigoVendedor);
                ViewBag.Produto = db.Produto;

                //return View(pedido);

            }
            catch (Exception ex)
            {
                retorno = "Erro ao salvar Pedido: " + ex.Message;

            }

            return Json(retorno);
        }

        // GET: Pedido/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedido pedido = db.Pedido.Find(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            ViewBag.CodigoComprador = new SelectList(db.PessoaFisica, "CodigoPessoa", "Nome", pedido.CodigoComprador);
            ViewBag.CodigoVendedor = new SelectList(db.PessoaJuridica, "CodigoPessoa", "Nome", pedido.CodigoVendedor);
            ViewBag.Produto = db.Produto;
            return View(pedido);
        }

        // POST: Pedido/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Edit(Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pedido).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CodigoComprador = new SelectList(db.PessoaFisica, "CodigoPessoa", "Nome", pedido.CodigoComprador);
            ViewBag.CodigoVendedor = new SelectList(db.PessoaJuridica, "CodigoPessoa", "Nome", pedido.CodigoVendedor);
            ViewBag.Produto = db.Produto;
            return View(pedido);
        }

        // GET: Pedido/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedido pedido = db.Pedido.Find(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            return View(pedido);
        }

        // POST: Pedido/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pedido pedido = db.Pedido.Find(id);
            db.Pedido.Remove(pedido);
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

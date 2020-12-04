using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Trabalho_MVC_Projeto.Context;
using Trabalho_MVC_Projeto.Models;

namespace Trabalho_MVC_Projeto.Controllers
{
    public class ProdutoController : Controller
    {
        // GET: Produto

        private readonly Contexto db = new Contexto();

        #region Index
        public ActionResult Index()
        {
            var produtos = db.Produtos.Include(c => c.Fornecedor).ToList();
            return View(produtos);
        }
        #endregion

        #region Create 

        public ActionResult Create() 
        {
            ViewBag.FornecedorID = new SelectList(db.Fornecedores, "Id", "Nome");
            return View();
        }

        #endregion

        #region Create - Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProdutoModel produtoModel) 
        {
            if (ModelState.IsValid)
            {
                db.Produtos.Add(produtoModel);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.FornecedorID = new SelectList(db.Fornecedores, "Id", "Nome");
            return View(produtoModel);
        }

        #endregion

        #region Details

        public ActionResult Detaisl(int? id) 
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ProdutoModel produtoModel = db.Produtos.Include(p => p.Fornecedor).First(f => f.ID == id);

            if (produtoModel == null)
            {
                return HttpNotFound();
            }
            return View(produtoModel);
        }

        #endregion

        #region Edit 

        public ActionResult Edit(int? id) 
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ProdutoModel produtoModel = db.Produtos.Where(a => a.ID == id).FirstOrDefault();
            ViewBag.FornecedorID = new SelectList(db.Fornecedores, "Id", "Nome");


            if (produtoModel == null)
            {
                return HttpNotFound();
            }
            return View(produtoModel);
        }

        #endregion

        #region Edit - Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProdutoModel produtoModel) 
        {
            if (ModelState.IsValid)
            {
                //ProdutoModel produto = db.Produtos.Find(produtoModel.ID);
                db.Entry(produtoModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.FornecedorID = new SelectList(db.Fornecedores, "Id", "Nome");
            return View(produtoModel);
        }

        #endregion

        #region Delete

        public ActionResult Delete(int? id) 
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ProdutoModel produtoModel = db.Produtos.Find(id);

            if (produtoModel == null)
            {
                return HttpNotFound();
            }
            return View(produtoModel);
        }

        #endregion

        #region Delete - Post

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public ActionResult Delete(int id) 
        {
            ProdutoModel produtoModel = db.Produtos.Find(id);
            db.Produtos.Remove(produtoModel);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        #endregion
    }
}
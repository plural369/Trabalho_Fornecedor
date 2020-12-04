using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Trabalho_MVC_Projeto.Context;
using Trabalho_MVC_Projeto.Models;

namespace Trabalho_MVC_Projeto.Controllers
{
    public class FornecedorController : Controller
    {
        private readonly Contexto db = new Contexto();

        public ActionResult Index()
        {
            return View(db.Fornecedores.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FornecedorModel fornecedorModel)
        {
            if (ModelState.IsValid)
            {
                db.Fornecedores.Add(fornecedorModel);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(fornecedorModel);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            FornecedorModel fornecedor = db.Fornecedores.Find(id);
            if (fornecedor == null)
            {
                return HttpNotFound();
            }
            return View(fornecedor);

        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            FornecedorModel fornecedor = db.Fornecedores.Find(id);
            if (fornecedor == null)
            {
                return HttpNotFound();
            }
            return View(fornecedor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FornecedorModel fornecedorModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fornecedorModel).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(fornecedorModel);
        }

        public ActionResult Delete()
        {
            return View();
        }
        [HttpPost ,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FornecedorModel fornecedorModel = db.Fornecedores.Find(id);

            if (fornecedorModel == null)
            {
                return HttpNotFound();
            }
            db.Fornecedores.Remove(fornecedorModel);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));

        }

    }
}
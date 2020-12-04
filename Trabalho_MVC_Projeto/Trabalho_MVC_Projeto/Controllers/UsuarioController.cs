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
    public class UsuarioController : Controller
    {
        private readonly Contexto db = new Contexto();
        // GET: Usuario
        #region Index
        public ActionResult Index()
        {
            return View(db.Usuarios.ToList());
        }
#endregion

        #region Create
        public ActionResult Create()
        {
            return View();
        }
        #endregion

        #region Create- Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsuarioModel usuarioModel) 
        {
            if (ModelState.IsValid)
            {
                usuarioModel.Senha = BCrypt.Net.BCrypt.HashPassword(usuarioModel.Senha);
                usuarioModel.ConfirmaSenha = usuarioModel.Senha;
                db.Usuarios.Add(usuarioModel);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(usuarioModel);
        }
        #endregion

        #region Details
        public ActionResult Details(int? id) 
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsuarioModel usuarioModel = db.Usuarios.Find(id);
            if (usuarioModel == null)
            {
                return HttpNotFound();
            }
            return View(usuarioModel);
        }
        #endregion

        #region Edit
        public ActionResult Edit(int? id) 
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            UsuarioModel usuarioModel = db.Usuarios.Find(id);

            if (usuarioModel == null)
            {
                return HttpNotFound();
            }

            return View(usuarioModel);
        }
        #endregion

        #region Edit - Post

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UsuarioModel usuarioModel) 
        {
            UsuarioModel usuario = db.Usuarios.Find(usuarioModel.ID);
            usuarioModel.Senha = usuario.Senha;
            usuarioModel.ConfirmaSenha = usuario.Senha;
            db.Entry(usuario).State = EntityState.Detached;
            db.Entry(usuarioModel).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        #endregion

        #region Delete
        [HttpGet]
        public ActionResult Delete(int? id) 
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            UsuarioModel usuarioModel = db.Usuarios.Find(id);

            if (usuarioModel == null)
            {
                return HttpNotFound();
            }
            return View(usuarioModel);
        }

        #endregion

        #region Delete - Post
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id) 
        {
            UsuarioModel usuarioModel = db.Usuarios.Find(id);
            db.Usuarios.Remove(usuarioModel);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        #endregion
    }
}
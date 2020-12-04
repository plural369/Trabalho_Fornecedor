using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trabalho_MVC_Projeto.Context;
using Trabalho_MVC_Projeto.Models;

namespace Trabalho_MVC_Projeto.Controllers
{
    public class LoginController : Controller
    {
        private readonly Contexto db = new Contexto();

        #region Index
        public ActionResult Index(string? erro)
        {
            if (erro != null)
            {
                TempData["error"] = erro;
            }
            return View();
        }
        #endregion

        #region Verificar
        public ActionResult Verificar(UsuarioModel usuarioModel)
        {

            UsuarioModel Consulta = db.Usuarios.FirstOrDefault
                (u => u.Usuario == usuarioModel.Usuario);

            string erro = "Usuário ou Senha Inválido";

            if (Consulta == null)
            {
                return RedirectToAction(nameof(Index), new { @erro = erro });
            }

            if (BCrypt.Net.BCrypt.Verify(usuarioModel.Senha, Consulta.Senha))
            {
                Session["Nome"] = Consulta.Usuario;
                Session["Nivel"] = Consulta.Nivel;
                return RedirectToAction("Index", "Usuario");
            }

            return RedirectToAction(nameof(Index), new { @erro = erro });
        }
        #endregion

        #region Logout
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
        #endregion
    }
}
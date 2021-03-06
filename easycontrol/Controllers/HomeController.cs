﻿using easycontrol.Areas.Admin.models;
using easycontrol.Areas.Admin.models.DAO;
using easycontrol.Areas.Admin.Models.DAO;
using easycontrol.Services;
using System;
using System.Web.Mvc;

namespace easycontrol.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Logar(string user, string password)
        {
            //Declarando váriaveis
            USUARIODAO _usuarioDAO = new USUARIODAO();
            USUARIO _usuario = new USUARIO();

            //Validando acesso
            _usuario = _usuarioDAO.ValidarAcesso(user, password);

            if (_usuario != null)
            {
                return Json(_usuario, JsonRequestBehavior.AllowGet);
            }

            return Json(false, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult EsqueciSenha(string user)
        {
            //Declarando váriaveis
            USUARIODAO _usuarioDAO = new USUARIODAO();
            USUARIO _usuario = new USUARIO();
            Email _email = new Email();

            //Validando acesso
            _usuario = _usuarioDAO.ConsultarUsuario(user);

            if (_usuario != null)
            {
                //Retorna falso pois não foi encontrado e-mail ou senha para o usuário
                if (String.IsNullOrEmpty(_usuario.EMAIL) || String.IsNullOrEmpty(_usuario.SENHA)) return Json(false, JsonRequestBehavior.AllowGet);

                _email.enviaEmail(_usuario.EMAIL, _usuario.SENHA);
                return Json(true, JsonRequestBehavior.AllowGet);
            }

            return Json(false, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ListarDivida(int userID)
        {
            INADIMPLENCIADAO _INDADIMPLENCIADAO = new INADIMPLENCIADAO();

            return Json(_INDADIMPLENCIADAO.litarInadim(userID), JsonRequestBehavior.AllowGet);
        }

    }
}
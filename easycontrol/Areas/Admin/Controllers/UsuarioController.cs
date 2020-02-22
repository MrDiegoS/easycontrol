using easycontrol.Areas.Admin.models;
using easycontrol.Areas.Admin.models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace easycontrol.Areas.Admin.Controllers
{
    public class UsuarioController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ListarUsuario() {
            USUARIODAO _usuariodao = new USUARIODAO();

            List<USUARIO> _usuario = new List<USUARIO>();

            //Lista todos os fator calculo cadastrado
            _usuario = _usuariodao.ListarFatorCalculo();

            //Se a lista não for vazia, retorna
            if (_usuario != null)
            {
                return Json(_usuario, JsonRequestBehavior.AllowGet);
            }
            return Json(false, JsonRequestBehavior.AllowGet);

        }

        public JsonResult CarregaUsuario(int id)
        {
            USUARIODAO _usuario = new USUARIODAO();
            //Retornar sucesso ou falso para tentativa de carregar o fator calculo
            return Json(_usuario.PesquisarFatorCalculo(id), JsonRequestBehavior.AllowGet); ;
        }

        public JsonResult AlterarUsuario(USUARIO _usuario)
        {
            USUARIODAO _usuariodao = new USUARIODAO();
            //Retornar sucesso ou falso para tentativa de alterar o fator calculo
            return Json(_usuariodao.AlterarUsuario(_usuario), JsonRequestBehavior.AllowGet); ;
        }

        public JsonResult ExcluirUsuario(int id)
        {
            USUARIODAO _usuariodao = new USUARIODAO();
            //Retornar sucesso ou falso para tentativa de excluir o fator calculo
            return Json(_usuariodao.ExcluirUsuario(id), JsonRequestBehavior.AllowGet); ;
        }

        public JsonResult AdicionarUsuario(USUARIO _usuario)
        {
            USUARIODAO _usuariodao = new USUARIODAO();
            //Retornar sucesso ou falso para tentativa de excluir o fator calculo
            return Json(_usuariodao.InserirUsuario(_usuario), JsonRequestBehavior.AllowGet); ;
        }
    }
}
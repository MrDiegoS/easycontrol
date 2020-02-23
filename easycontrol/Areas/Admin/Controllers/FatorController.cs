using easycontrol.Areas.Admin.models;
using easycontrol.Areas.Admin.models.DAO;
using System.Collections.Generic;
using System.Web.Mvc;

namespace easycontrol.Areas.Admin.Controllers
{
    public class FatorController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult ListarFatorCalculo()
        {
            FATOR_CALCULODAO _fator_calculodao = new FATOR_CALCULODAO();
            List<FATOR_CALCULO> _fator_calculo = new List<FATOR_CALCULO>();

            //Lista todos os fator calculo cadastrado
            _fator_calculo = _fator_calculodao.ListarFatorCalculo();

            //Se a lista não for vazia, retorna
            if (_fator_calculo != null)
            {
                return Json(_fator_calculo, JsonRequestBehavior.AllowGet);
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AlterarFatorCalculo(FATOR_CALCULO _fator_calculo)
        {
            FATOR_CALCULODAO _fator_calculodao = new FATOR_CALCULODAO();
            //Retornar sucesso ou falso para tentativa de alterar o fator calculo
            return Json(_fator_calculodao.AlterarFatorCalculo(_fator_calculo), JsonRequestBehavior.AllowGet); ;
        }

        [HttpPost]
        public JsonResult CarregaFatorCalculo(int id)
        {
            FATOR_CALCULODAO _fator_calculodao = new FATOR_CALCULODAO();
            //Retornar sucesso ou falso para tentativa de carregar o fator calculo
            return Json(_fator_calculodao.PesquisarFatorCalculo(id), JsonRequestBehavior.AllowGet); ;
        }

        [HttpPost]
        public JsonResult ExcluirFatorCalculo(int id)
        {
            FATOR_CALCULODAO _fator_calculodao = new FATOR_CALCULODAO();
            //Retornar sucesso ou falso para tentativa de excluir o fator calculo
            return Json(_fator_calculodao.ExcluirFatorCalculo(id), JsonRequestBehavior.AllowGet); ;
        }

        [HttpPost]
        public JsonResult AdicionarFatorCalculo(FATOR_CALCULO _fator_calculo)
        {
            FATOR_CALCULODAO _fator_calculodao = new FATOR_CALCULODAO();
            //Retornar sucesso ou falso para tentativa de excluir o fator calculo
            return Json(_fator_calculodao.InserirFatorCalculo(_fator_calculo), JsonRequestBehavior.AllowGet); ;
        }
    }
}
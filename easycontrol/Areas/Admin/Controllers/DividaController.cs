using easycontrol.Areas.Admin.models;
using easycontrol.Areas.Admin.Models.DAO;
using System.Web.Mvc;

namespace easycontrol.Areas.Admin.Controllers
{
    public class DividaController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Dividas()
        {
            return View();
        }

        [HttpPost]
        public JsonResult CalcularDivida(INADIMPLENCIA _inadimplencia)
        {
            INADIMPLENCIADAO _INDADIMPLENCIADAO = new INADIMPLENCIADAO();

            return Json(_INDADIMPLENCIADAO.calcularInadim(_inadimplencia), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ListarDivida(int? _uerID = 0)
        {
            INADIMPLENCIADAO _INDADIMPLENCIADAO = new INADIMPLENCIADAO();

            return Json(_INDADIMPLENCIADAO.litarInadim(_uerID), JsonRequestBehavior.AllowGet);
        }
    }
}
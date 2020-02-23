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

        [HttpPost]
        public JsonResult CalcularDivida(INADIMPLENCIA _inadimplencia)
        {
            INADIMPLENCIADAO _INDADIMPLENCIADAO = new INADIMPLENCIADAO();

            return Json(_INDADIMPLENCIADAO.calcularInadim(_inadimplencia), JsonRequestBehavior.AllowGet);
        }
    }
}
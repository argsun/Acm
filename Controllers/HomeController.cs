using DataLayer1;
using System.Web.Mvc;

namespace ACMS.Controllers
{
    public class HomeController : Controller
    {
        AcmsCOntext db = new AcmsCOntext();
        private IPageRepository pageRepository;

        public HomeController()
        {
            pageRepository = new PageRepository(db);
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Slider()
        {


            return PartialView(pageRepository.pageSlider());
        }
    }
}
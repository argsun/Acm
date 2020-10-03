using DataLayer1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ACMS.Controllers
{
    public class SearchController : Controller
    {
        private IPageRepository pageRepository;
        AcmsCOntext db=new AcmsCOntext();

        public SearchController()
        {

            pageRepository = new PageRepository(db);
        }
        // GET: Search

#pragma warning disable CA3147 // Mark Verb Handlers With Validate Antiforgery Token
        public ActionResult Index(string q)
#pragma warning restore CA3147 // Mark Verb Handlers With Validate Antiforgery Token
        {
            {
     
                    ViewBag.Name = q;
                    return View(pageRepository.SearchPage(q));
               
               
            }
        }
    }
}

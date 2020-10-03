using DataLayer1;
using System;
using System.Web.Mvc;

namespace ACMS.Controllers
{
    public class NewsController : Controller
    {
        // GET: News
        AcmsCOntext db = new AcmsCOntext();
        private IPageGroupRepository pageGroupRepository;
        private IPageRepository pageRepository;
        private IPageCommentRepository pageCommentRepository;

        public NewsController()
        {
            pageGroupRepository = new PageGroupRepository(db);
            pageRepository = new PageRepository(db);
            pageCommentRepository = new PageCommentRepository(db);
        }
        public ActionResult ShowGroups()
        {
            return PartialView(pageGroupRepository.GetGroupForView());
        }

        public ActionResult ShowGroupInMenu()
        {
            return PartialView(pageGroupRepository.GetAllGroups());
        }
        public ActionResult TopNews()
        {
            return PartialView(pageRepository.TopNews());
        }

        public ActionResult LatestNews()
        {
            return PartialView(pageRepository.LatestNews());
        }
        [Route("Archive")]
        public ActionResult AechiveNews()
        {
            return View(pageRepository.GetAllPage());
        }

        [Route("Group/{id}/{title}")]
        public ActionResult ShowGroupNewsById(int id, string title)
        {
            ViewBag.name = title;

            return View(pageRepository.ShowNewsByGroup(id));
        }

        [Route("News/{id}")]
        public ActionResult ShowNews(int id)
        {
            var news = pageRepository.GetPageById(id);
            if (news == null)
            {
                return HttpNotFound();
            }

            news.Visit += 1;
            pageRepository.UpdatePage(news);
            pageRepository.Save();
            return View(news);
        }

        public ActionResult AddComment(int id, string name, string email, string comments)
        {
            PageComment AddComent = new PageComment()
            {
                PageID = id,
                Name = name,
                Email = email,
                Comment = comments,
                CreateTime = DateTime.Now

            };
            pageCommentRepository.AddComment(AddComent);

            return PartialView("ShowComments", pageCommentRepository.GetCommentByNewsId(id));
        }

        public ActionResult ShowComments(int id)
        {
            return PartialView(pageCommentRepository.GetCommentByNewsId(id));
        }
        
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DataLayer1;

namespace ACMS.Controllers
{
    public class AccountController : Controller
    {
        private IAdminLoginRepository adminLoginRepository;
        AcmsCOntext db=new AcmsCOntext();

        public AccountController()
        {
            adminLoginRepository=new AdminLoginRepository(db);
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel login,string ReturnUrl="/")
        {
            if (ModelState.IsValid)
            {
                if (adminLoginRepository.IsUserExist(login.UserName, login.Password))
                {
                    FormsAuthentication.SetAuthCookie(login.UserName,login.RememberMe);
                    return Redirect(ReturnUrl);
                }
                else
                {
                    ModelState.AddModelError("UserName",":کاربری با این نام ثبت نشده است");
                }
            }
            return View(login);
        }

        public ActionResult SignOut()
        {

            FormsAuthentication.SignOut();
            return Redirect("/");
        }



    }
}
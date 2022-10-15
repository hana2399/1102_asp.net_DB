using System;  //暫時不要動 發瘋
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace prjFin052701.Controllers
{
    [Authorize]
    public class HomeController : Controller

    {
        [Authorize(Users = "mary,kate,shai")]

        public ActionResult Index()
        {
            return View();
        }
        public string IndexL()
        {
            return "<p>＊＊＊＊Welcome " + User.Identity.Name + "！，按 <a href='/Paged/IndexP'>商品檢視</a> 可引導到上架商品總覽頁＊＊＊＊<p>" +
                "<img src='../Images/miiw.jpg' width='100%'>";
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();//登出
            return RedirectToAction("Login");
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(string txtUid, string txtPwd)
        {
            string[] uidAry = new string[] { "mary", "kate", "shai" };
            string[] pwdAry = new string[] { "123", "456", "789" };

            int index = -1;
            for (int i = 0; i < uidAry.Length; i++)
            {
                if (uidAry[i] == txtUid && pwdAry[i] == txtPwd)
                {
                    index = i;
                    break;
                }
            }
            if (index == -1)
            {
                ViewBag.Err = "帳密錯誤，偷偷說帳號是＂mary/kate/shai＂，密碼分別為＂123/456/789＂!";
            }
            else
            {
                FormsAuthentication.RedirectFromLoginPage(txtUid, true);

                return RedirectToAction("IndexL");
            }
            return View();
        }

    }
}
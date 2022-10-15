using prjFin052701.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace prjFin052701.Controllers
{
    public class ClassController : Controller
    {
        // GET: Class
        dbBookEntities db = new dbBookEntities();
        /*Class*/
        public ActionResult Check(int classId = 1)
        {
            ViewBag.CLASS_NAME = db.TableClasss1091711  /*Class*/
            .Where(m => m.CLASS_ID == classId)
            .FirstOrDefault().CLASS_NAME + "類";
            CVMBook vm = new CVMBook()
            {
                class01 = db.TableClasss1091711.ToList(),
                book00 = db.TableBooks1091711
                .Where(m => m.CLASS_ID == classId).ToList()
            };
            return View(vm);
        }
        //-----------------------------------------------------------------------------------------------//-----------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------//-----------------------------------------------------------------------------------------------
        /*public ActionResult Create()  
        {
            return View(db.TableClasss1091711.ToList());
        }
        [HttpPost]
        public ActionResult Create(TableBooks1091711 book)
        {
            try
            {
                db.TableBooks1091711.Add(book);
                db.SaveChanges();
                return RedirectToAction
                    ("Index", new { classId = book.CLASS_ID });
            }
            catch (Exception ex)
            { }
            return View(book);
        }*/
        //-----------------------------------------------------------------------------------------------//-----------------------------------------------------------------------------------------------//-----------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------//-----------------------------------------------------------------------------------------------
        /*public ActionResult Delete(string BOOK_IBSN) 
        {
            var book = db.TableBooks1091711.Where
                (m => m.BOOK_IBSN == BOOK_IBSN).FirstOrDefault();
            db.TableBooks1091711.Remove(book);
            db.SaveChanges();
            return RedirectToAction("Index", new { classId = book.CLASS_ID });
        }
        //-----------------------------------------------------------------------------------------------//-----------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------//-----------------------------------------------------------------------------------------------
        public ActionResult Edit(string BOOK_IBSN)
        {
            var books = db.TableBooks1091711
                .Where(m => m.BOOK_IBSN == BOOK_IBSN).FirstOrDefault();
            return View(books);
        }
        [HttpPost]
        public ActionResult Edit(TableBooks1091711 books)
        {
            if (ModelState.IsValid)
            {
                var temp = db.TableBooks1091711.Where(m => m.BOOK_IBSN == books.BOOK_IBSN).FirstOrDefault();
                temp.BOOK_IBSN = books.BOOK_IBSN;
                temp.BOOK_TITLE = books.BOOK_TITLE;
                temp.BOOK_ATOR = books.BOOK_ATOR;
                temp.CLASS_ID = books.CLASS_ID;
                temp.BOOK_PUB = books.BOOK_PUB;
                temp.BOOK_UPDATE = books.BOOK_UPDATE;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(books);
        }*/
        //-----------------------------------------------------------------------------------------------//-----------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------//-----------------------------------------------------------------------------------------------

        public ActionResult IndexS(string searchString) /*for searching*/
        {
            var book = from m in db.TableBooks1091711
                       select m;
            if (!String.IsNullOrEmpty(searchString))
            {
                book = book.Where(s => s.BOOK_TITLE.Contains(searchString));
            }
            return View(book);
        }
        //-----------------------------------------------------------------------------------------------//-----------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------//-----------------------------------------------------------------------------------------------
        public ActionResult Index()
        {
            var book00 = db.TableBooks1091711.ToList();
            return View(book00);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(TableBooks1091711 book00)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Error = false;
                var temp = db.TableBooks1091711.Where(m => m.BOOK_IBSN == book00.BOOK_IBSN)
                    .FirstOrDefault();
                if (temp != null)
                {
                    ViewBag.Error = true;
                    return View(book00);
                }
                db.TableBooks1091711.Add(book00);
                db.SaveChanges();
                return RedirectToAction("Check");
            }
            return View(book00);
        }

        public ActionResult Edit(string BOOK_IBSN)
        {
            var book00 = db.TableBooks1091711
                .Where(m => m.BOOK_IBSN == BOOK_IBSN).FirstOrDefault();
            return View(book00);
        }

        [HttpPost]
        public ActionResult Edit(TableBooks1091711 book00)
        {
            if (ModelState.IsValid)
            {
                var temp = db.TableBooks1091711
                    .Where(m => m.BOOK_IBSN == book00.BOOK_IBSN)
                    .FirstOrDefault();
                temp.BOOK_TITLE = book00.BOOK_TITLE;
                temp.BOOK_ATOR = book00.BOOK_ATOR;
                temp.CLASS_ID = book00.CLASS_ID;
                temp.BOOK_PUB = book00.BOOK_PUB;
                temp.BOOK_UPDATE = book00.BOOK_UPDATE;
                db.SaveChanges();
                return RedirectToAction("Check");
            }
            return View(book00);
        }
        public ActionResult Delete(string BOOK_IBSN)
        {
            var book00 = db.TableBooks1091711
                .Where(m => m.BOOK_IBSN == BOOK_IBSN).FirstOrDefault();

            db.TableBooks1091711.Remove(book00);
            db.SaveChanges();
            return RedirectToAction("Check", new {class01=book00.CLASS_ID });
        }


    }
}

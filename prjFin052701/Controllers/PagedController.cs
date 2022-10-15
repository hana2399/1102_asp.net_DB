using PagedList;
using prjFin052701.Models;
using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;


namespace prjFin052701.Controllers
{
    public class PagedController : Controller
    {
        PagedEntities db = new PagedEntities();
        int pageSize = 10;
        public ActionResult IndexP(int page = 1)
        {
            int currentPage = page < 1 ? 1 : page;
            var products = db.TablePageds1091711.OrderBy(m => m.書籍IBSN碼).ToList();
            var result = products.ToPagedList(currentPage, pageSize);
            
                        return View(result);
        }
        /*public string ShowBooks()
        {
            PagedEntities db = new PagedEntities();
            var result = from m in db.TablePageds1091711 select m;
            string show = "";
            foreach(var m in result)
            {
                show += $"IBSN碼:{m.書籍IBSN碼}<br/>";
                show += $"書名:{m.書名}<br/>";
                show += $"作者:{m.作者}<br/>";
            }
            return show;
        }*/
        public string ShowBookByName(string keyword)
        {
            PagedEntities db = new PagedEntities();
            var result = db.TablePageds1091711.Where(m => m.書名.Contains(keyword));
            string show = "";
                foreach(var m in result)
            {
                show += $"IBSN碼:{m.書籍IBSN碼}<br/>";
                show += $"書名:{m.書名}<br/>";
                show += $"作者:{m.作者}<br/>";
            }
            return show;
        }

        public ActionResult IndexS(string name)
         {
             var books = from n in db.TablePageds1091711
                          select n;
             if (!String.IsNullOrEmpty(name))
             {
                 books = books.Where(s => s.書名.Contains(name));
             }
             return View(books);
         }
         [HttpPost]
         public string IndexS(FormCollection fc, string name)
         {
             return "<h3> From [HttpPost]IndexS: " + name + "</h3>";
         }
        

    }
 }


        //-----------------------------------------------------------------------------------------------//-----------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------//-----------------------------------------------------------------------------------------------

        /*string constr = @"Server=140.138.144.66\SQL1422" +
            "database=1102netdbB" + "uid=1102netdbB" + "pwd=yzuim1102dbB";
        private List<TablePageds1091711> GetAllBooks()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = constr;
            SqlDataAdapter adp = new SqlDataAdapter("SELECT*FROM TablePageds1091711", con);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            DataTable dt = ds.Tables[0];
            List<TablePageds1091711> book00 = new List<TablePageds1091711>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                book00.Add(new TablePageds1091711
                {
                    書籍IBSN碼 = dt.Rows[i]["書籍IBSN碼"].ToString(),
                    書名 = dt.Rows[i]["書名"].ToString(),
                    作者 = dt.Rows[i]["作者"].ToString(),
                    書籍分類 = dt.Rows[i]["書籍分類"].ToString(),
                    出版日期 = DateTime.Parse(dt.Rows[i]["上架日期"].ToString()),
                    上架日期 = DateTime.Parse(dt.Rows[i]["上架日期"].ToString())
                });
            }
            return book00;
        }
        private TablePageds1091711 GetBook(string 書籍IBSN碼) /*0601
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = constr;
            SqlCommand cmd = new SqlCommand("SELECT*FROM TablePageds1091711 WHERE 書籍IBSN碼 = @書籍IBSN碼", con);
            cmd.Parameters.Add(new SqlParameter("@書籍IBSN碼", SqlDbType.NVarChar)).Value = 書籍IBSN碼;
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            DataTable dt = ds.Tables[0];
            TablePageds1091711 book = new TablePageds1091711
            {
                書籍IBSN碼 = dt.Rows[0]["書籍IBSN碼"].ToString(),
                書名 = dt.Rows[0]["書名"].ToString(),
                作者 = dt.Rows[0]["作者"].ToString(),
                書籍分類 = dt.Rows[0]["書籍分類"].ToString(),
                出版日期 = DateTime.Parse(dt.Rows[0]["出版日期"].ToString()),
                上架日期 = DateTime.Parse(dt.Rows[0]["上架日期"].ToString())
            };
            return book;
        }

        private void ExecuteCmd(SqlCommand cmd)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = constr;
            con.Open();
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public ActionResult IndexC()
        {
            return View(GetAllBooks());
        }
        */
        /*public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(TablePageds1091711 book00)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Error = false;
                var temp = db.TablePageds1091711
                    .Where(m => m.書籍分類 == book00.書籍IBSN碼).FirstOrDefault();
                if (temp != null)
                {
                    ViewBag.Error = true;
                    return View(book00);
                }
                db.TablePageds1091711.Add(book00);
                db.SaveChanges();
                return RedirectToAction("IndexP");
            }
            return View(book00);
        }
    }
}
                /*try
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.CommandText =
                        "INSERT INTO TablePageds1091711(書籍IBSN碼,書名,作者,書籍分類,出版日期,上架日期)" +
                        "VALUES(@書籍IBSN碼,@書名,@作者,@書籍分類,@出版日期,@上架日期)";
                    sqlCommand.Parameters.Add(new SqlParameter
                        ("@書籍IBSN碼", SqlDbType.NVarChar)).Value = book00.書籍IBSN碼;
                    sqlCommand.Parameters.Add(new SqlParameter
                        ("@書名", SqlDbType.NVarChar)).Value = book00.書名;
                    sqlCommand.Parameters.Add(new SqlParameter
                        ("@作者", SqlDbType.NVarChar)).Value = book00.作者;
                    sqlCommand.Parameters.Add(new SqlParameter
                        ("@書籍分類", SqlDbType.NVarChar)).Value = book00.書籍分類;
                    sqlCommand.Parameters.Add(new SqlParameter
                        ("@出版日期", SqlDbType.NVarChar)).Value = book00.出版日期;
                    sqlCommand.Parameters.Add(new SqlParameter
                        ("@上架日期", SqlDbType.NVarChar)).Value = book00.上架日期;
                    ExecuteCmd(sqlCommand);
                    return RedirectToAction("IndexP");
                }
                catch (Exception ex)
                {
                    ViewBag.Error = true;
                    return View(book00);
                }
            }
            return View(book00);
        }*/
        //-----------------------------------------------------------------------------------------------//-----------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------//-----------------------------------------------------------------------------------------------

       /* public ActionResult Edit(string 書籍IBSN碼)
        {
            return View(GetBook(書籍IBSN碼));
        }
        [HttpPost]
        public ActionResult Edit(TablePageds1091711 book00)
        {
            if (ModelState.IsValid)
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText =
                    "UPDATE TablePageds1091711 SET 書名=@書名, 作者=@作者, 書籍分類=@書籍分類," +
                    "出版日期=@出版日期, 上架日期=@上架日期 WHERE 書籍IBSN碼=@書籍IBSN碼";
                sqlCommand.Parameters.Add(new SqlParameter
                    ("書籍IBSN碼", SqlDbType.NVarChar)).Value =
                    book00.書籍IBSN碼;
                sqlCommand.Parameters.Add(new SqlParameter
                    ("書名", SqlDbType.NVarChar)).Value =
                    book00.書名;
                sqlCommand.Parameters.Add(new SqlParameter
                    ("作者", SqlDbType.NVarChar)).Value =
                    book00.作者;
                sqlCommand.Parameters.Add(new SqlParameter
                    ("書籍分類", SqlDbType.NVarChar)).Value =
                    book00.書籍分類;
                sqlCommand.Parameters.Add(new SqlParameter
                    ("出版日期", SqlDbType.NVarChar)).Value =
                    book00.出版日期;
                sqlCommand.Parameters.Add(new SqlParameter
                    ("上架日期", SqlDbType.NVarChar)).Value =
                    book00.上架日期;
                ExecuteCmd(sqlCommand);
                return RedirectToAction("IndexP");
            }
            return View(book00);
        }
        public ActionResult Delete(string 書籍IBSN碼)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText =
                "DELETE FROM TablePageds1091711 WHERE 書籍IBSN碼 = @書籍IBSN碼";
            sqlCommand.Parameters.Add(new SqlParameter
                ("@書籍IBSN碼", SqlDbType.NVarChar)).Value = 書籍IBSN碼;
            ExecuteCmd(sqlCommand);
            return RedirectToAction("IndexP"); 
        }
    }
}


/*var book = db.TablePageds1091711.Where
                (m => m.書籍IBSN碼 == 書籍IBSN碼).FirstOrDefault();
            db.TablePageds1091711.Remove(book);
            db.SaveChanges();
            return RedirectToAction("IndexP"/*, new { 書籍IBSN碼 = book.書籍IBSN碼 } */



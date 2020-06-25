using Bourse.Models;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Bourse.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext dbContext = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ShowInfo()
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

        public ActionResult CategoryList()
        {
            return View(dbContext.Categories.ToList());
        }
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category model)
        {
            if (ModelState.IsValid)
            {
                using (ApplicationDbContext dbContext = new ApplicationDbContext())
                {
                    dbContext.Categories.Add(model);
                    dbContext.SaveChanges();
                }
                return RedirectToAction(nameof(CategoryList));
            }
            else
            {
                return View(model);
            }

        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public ActionResult DownloadFile(int id)
        {

            string RemoteDownloadUri = "";

            RemoteDownloadUri =
            "http://www.tsetmc.com/tsev2/data/Export-txt.aspx?";
            // public System.Windows.Forms.WebBrowser MyWebBrowser { get; set; }
            WebClient webClient = null;

            try
            {
                string unicId = "";
                string content = "";
                SubCategories subCategories = new SubCategories();
                using (ApplicationDbContext dbContext = new ApplicationDbContext())
                {

                    subCategories = dbContext.SubCategories.Find(id);
                }
                unicId = subCategories.UniqueID;

                string remotePathName =
                    $"{ RemoteDownloadUri }t=i&a=1&b=0&i={ unicId }";

                // **************************************************
                webClient =
                    new System.Net.WebClient();

                webClient.Encoding = System.Text.Encoding.UTF8;

                byte[] result =
                    webClient.DownloadData(address: remotePathName);

                byte[] decompressedResult =
                    Infrastructure.Utility.DecompressGZip(result);

                content =
               System.Text.Encoding.UTF8.GetString(decompressedResult);
                // **************************************************

                // **************************************************
                string temp =
                 content.Replace("\r", string.Empty);

                System.Collections.Generic.List<Models.Symbol>
                    symbols = new System.Collections.Generic.List<Models.Symbol>();

                string[] rows =
                    content.Split('\n');

                for (int index = 1; index <= rows.Length - 1; index++)
                {
                    Models.Symbol symbol = new Models.Symbol(rows[index]);
                    symbol.SubCategoriesId = subCategories.Id;
                    symbols.Add(symbol);
                }

                // model.Symbols = symbols;
                using (ApplicationDbContext dbContext = new ApplicationDbContext())
                {
                    dbContext.Symbols.AddRange(symbols);
                    dbContext.SaveChanges();
                }

                // **************************************************

                // myDataGridView.DataSource = symbols;
            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                if (webClient != null)
                {
                    webClient.Dispose();
                    webClient = null;
                }
            }

            return RedirectToAction("Index", "SubCategories");

        }

        [HttpPost]
        public ActionResult DownloadFile(DownloadFile model)
        {

            string RemoteDownloadUri = "";

            RemoteDownloadUri =
            "http://www.tsetmc.com/tsev2/data/Export-txt.aspx?";
            // public System.Windows.Forms.WebBrowser MyWebBrowser { get; set; }
            WebClient webClient = null;

            try
            {
                //string id =
                //    "33603212156438463";
                string id =
                    "47302318535715632";

                string remotePathName =
                    $"{ RemoteDownloadUri }t=i&a=1&b=0&i={ id }";

                // **************************************************
                webClient =
                    new System.Net.WebClient();

                webClient.Encoding = System.Text.Encoding.UTF8;

                byte[] result =
                    webClient.DownloadData(address: remotePathName);

                byte[] decompressedResult =
                    Infrastructure.Utility.DecompressGZip(result);

                model.Content =
               System.Text.Encoding.UTF8.GetString(decompressedResult);
                // **************************************************

                // **************************************************
                string temp =
                 model.Content.Replace("\r", string.Empty);

                System.Collections.Generic.List<Models.Symbol>
                    symbols = new System.Collections.Generic.List<Models.Symbol>();

                string[] rows =
                    model.Content.Split('\n');

                for (int index = 1; index <= rows.Length - 1; index++)
                {
                    Models.Symbol symbol = new Models.Symbol(rows[index]);

                    symbols.Add(symbol);
                }

                model.Symbols = symbols;
                using (ApplicationDbContext dbContext = new ApplicationDbContext())
                {
                    dbContext.Symbols.AddRange(symbols);
                    dbContext.SaveChanges();
                }

                // **************************************************

                // myDataGridView.DataSource = symbols;
            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                if (webClient != null)
                {
                    webClient.Dispose();
                    //webClient = null;
                }
            }
            return View(model);

        }

    }
}


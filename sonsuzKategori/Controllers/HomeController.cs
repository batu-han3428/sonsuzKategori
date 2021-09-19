using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using sonsuzKategori.contexts;
using sonsuzKategori.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sonsuzKategori.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        public IActionResult Index()
        {
            var tb = new TagBuilder("ul");
            tb.MergeAttribute("style", "list-style-image: url(folder.png);");
            tb.AddCssClass("myJstree");
            using (SqlDbContext vt = new SqlDbContext())
            {

                var Kategori = from i in vt.urunKategorileri
                               where i.urunKategorileriUstId == 0
                               select i;

                foreach (urunKategorileri anamenu in Kategori)
                {
                    tb.InnerHtml.AppendHtml("<li>" + anamenu.urunKategorileriKategoriAdi + Altkategori(anamenu.urunKategorileriId) + "</li>");
                }

            }
            return View(tb);
        }


        private string Altkategori(int id)
        {
            string ab = "";

            using (SqlDbContext a = new SqlDbContext())
            {

                var say = (from i in a.urunKategorileri
                           where i.urunKategorileriUstId == id
                           select i).Count();
                if (say > 0)
                {

                    var altKat = from i in a.urunKategorileri
                                 where i.urunKategorileriUstId == id
                                 select i;

                    ab = "<ul id='menu'>";
                    foreach (urunKategorileri altkategori in altKat)
                    {
                        ab += "<li>" + altkategori.urunKategorileriKategoriAdi + Altkategori(altkategori.urunKategorileriId);
                        
                        ab += "</li>";
                    }
                    ab += "</ul>";

                    return ab;
                }
            }

            return "";
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
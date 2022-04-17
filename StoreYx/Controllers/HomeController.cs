using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreYx.Data;
using StoreYx.Models;
using System.Diagnostics;

namespace StoreYx.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {

            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var model = new ListModel();
            model.ServiceModel = await _context.Service.ToListAsync();
            model.ArticleModel = await _context.Article.ToListAsync();
            model.PageModel = await _context.Page.FirstOrDefaultAsync();
            return View(model);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
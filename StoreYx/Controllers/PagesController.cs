#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StoreYx.Data;
using StoreYx.Models;

namespace StoreYx.Controllers
{
    public class PagesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PagesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Pages
        public async Task<IActionResult> Index(string permalink)
        {
             var page = HttpContext.Items["cmspage"] as Page;
            if(page == null)
            {
                return NotFound();
            }
             return View(page);
            //  return View(await _context.Page.FirstOrDefaultAsync());
        }

    }
}

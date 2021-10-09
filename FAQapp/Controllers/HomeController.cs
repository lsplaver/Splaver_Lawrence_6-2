using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using FAQapp.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace FAQapp.Controllers
{
    public class HomeController : Controller
    {
        private FAQContext context { get; set; }

        public HomeController(FAQContext ctx)
        {
            context = ctx;
        }

        [HttpGet("[controller]/[action]/genre/{id}")]
        [HttpGet("[controller]/[action]/category/{id}")]
        public IActionResult Index(string id)
        {
            if ((id == "pow-metal") || (id == "spd-metal") || (id == "sym-metal"))
            {
                var faqs = context.FAQs
                    .Include(c => c.Category)
                    .Include(c => c.Genre)
                    .Where(c => c.GenreId == id)
                    .OrderBy(c => c.Name)
                    .ToList();
                return View(faqs);
            }
            else if ((id == "gen") || (id == "hist") || (id == "link"))
            {
                var faqs = context.FAQs
                    .Include(c => c.Category)
                    .Include(c => c.Genre)
                    .Where(c => c.CategoryId == id)
                    .OrderBy(c => c.Name)
                    .ToList();
                return View(faqs);
            }
            else
            {
                return Content("Invalid entry");
            }

        }
        /* public IActionResult Index(string catId)
        {
            var faqs = context.FAQs
                .Include(c => c.Category)
                .Include(c => c.Genre)
                .Where(c => c.CategoryId == catId)
                .OrderBy(c => c.Name)
                .ToList();
            return View(faqs);
        } */

        [HttpGet("[controller]/[action]/genre/{genreId}/category/{catId}")]
        // [Route("genre-and-category")]
        public IActionResult Index(string genreId, string catId)
        {
            /* if ((genreId == null) && (catId != null))
            {
                var faqs = context.FAQs
                    .Include(c => c.Category)
                    .Include(c => c.Genre)
                    .Where(c => c.CategoryId == catId)
                    .OrderBy(c => c.Name)
                    .ToList();
                return View(faqs);
            }
            else if ((genreId != null) && (catId != null))
            {
                var faqs = context.FAQs
                    .Include(c => c.Category)
                    .Include(c => c.Genre)
                    .Where(c => c.GenreId == genreId)
                    .OrderBy(c => c.Name)
                    .ToList();
                return View(faqs);
            }
            else if ((genreId != null) && (catId != null))
            { */
                var faqs = context.FAQs
                    .Include(c => c.Category)
                    .Include(c => c.Genre)
                    .Where(c => c.GenreId == genreId)
                    .Where(c => c.CategoryId == catId)
                    .OrderBy(c => c.Name)
                    .ToList();
                return View(faqs);
            // }
            /* else
            {
                var faqs = context.FAQs
                    .Include(c => c.Category)
                    .Include(c => c.Genre)
                    .OrderBy(c => c.Name)
                    .ToList();
                return View(faqs);
            } */
        }

        // [Route("default")]
        public IActionResult Index()
        {
            var faqs = context.FAQs
                .Include(c => c.Category)
                .Include(c => c.Genre)
                .OrderBy(c => c.Name)
                .ToList();
            return View(faqs);
        }
    }
}

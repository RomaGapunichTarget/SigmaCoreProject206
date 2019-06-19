using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SigmaCoreProject.Models;

namespace SigmaCoreProject.Controllers
{
    public class NewsController : Controller
    {
        private readonly sigmaCoreContext _context;

        public NewsController(sigmaCoreContext context)
        {
            _context = context;
        }

        // GET: News
        public async Task<IActionResult> Index()
        {
            return View(await _context.News.ToListAsync());
        }

        // GET: News/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news = await _context.News
                .FirstOrDefaultAsync(m => m.Id == id);
            if (news == null)
            {
                return NotFound();
            }

            return View(news);
        }

        // GET: News/Details/5
        public async Task<IActionResult> ReadNews(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news = await _context.News
                .FirstOrDefaultAsync(m => m.Id == id);
            if (news == null)
            {
                return NotFound();
            }

            ModelReadNews ModelViewNes = new ModelReadNews();
            ModelViewNes.IdNews = news.Id;
            ModelViewNes.TitileNews = news.TitleNews;
            ModelViewNes.Bodynews = news.BodyNews;

            var lstComment = _context.Comments.Where(comments => comments.IdNews == ModelViewNes.IdNews).ToList();

            ModelViewNes.lstComentNews = new List<Commnetsnews>();
            foreach (var vars in lstComment)
            {
                string DateTimse = Convert.ToDateTime(vars.DateComent).ToString("dd.MM.yyyy HH:mm:ss");
                Commnetsnews newsComm = new Commnetsnews
                {
                    idComent = vars.Id,
                    Comment = vars.BodyComment,
                    DateCrateCommnet = DateTimse
                };
                ModelViewNes.lstComentNews.Add(newsComm);
            }


            return View(ModelViewNes);
        }

        // GET: News/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: News/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TitleNews,BodyNews,ShoreInfo")] News news)
        {
            if (ModelState.IsValid)
            {
                news.DateCreate = DateTime.Now;
                news.DateUpdate = DateTime.Now;
                news.DateStartVisible = DateTime.Now.AddDays(-1);
                news.DateEndVisible = DateTime.Now.AddDays(5);
                news.IsVisible = true;
                news.IdUserCreate = Guid.NewGuid().ToString();
                _context.News.Add(news);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(news);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddComment([Bind("Id,IdNews,BodyComment")] Comments comment)
        {
            if (ModelState.IsValid)
            {
                comment.DateComent = DateTime.Now;
                _context.Comments.Add(comment);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index","Home");
            }
            return RedirectToAction("Index", "Home");
        }

        // GET: News/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news = await _context.News.FindAsync(id);
            if (news == null)
            {
                return NotFound();
            }
            return View(news);
        }

        // POST: News/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TitleNews,BodyNews,ShoreInfo")] News news)
        {
            if (id != news.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    news.DateUpdate = DateTime.Now;
                    _context.Update(news);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NewsExists(news.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(news);
        }

        // GET: News/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news = await _context.News
                .FirstOrDefaultAsync(m => m.Id == id);
            if (news == null)
            {
                return NotFound();
            }

            return View(news);
        }

        // POST: News/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var news = await _context.News.FindAsync(id);
            _context.News.Remove(news);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NewsExists(int id)
        {
            return _context.News.Any(e => e.Id == id);
        }
    }
}

using Blog.Data;
using Blog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Blog.Pages
{
    public class ViewArticleModel : PageModel
    {

        private readonly ILogger<IndexModel> _logger;

        private readonly BlogDbContext db;

        public ViewArticleModel(ILogger<IndexModel> logger, BlogDbContext db)
        {
            _logger = logger;
            this.db = db;
        }

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        public Article article { get; set; }
        public async Task OnGetAsync()
        {
            article = await db.Articles.Include(article => article.Author).Where(article => article.Id == Id).FirstOrDefaultAsync();
        }
    }
}

using Blog.Data;
using Blog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Blog.Pages
{
    public class AuthorArticlesModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private readonly BlogDbContext db;

        public AuthorArticlesModel(ILogger<IndexModel> logger, BlogDbContext db)
        {
            _logger = logger;
            this.db = db;
        }

        [BindProperty(SupportsGet = true)]
        public string Id { get; set; }

        public List<Article> authorArticles { get; set; }
        public async Task OnGetAsync()
        {
            authorArticles = await db.Articles.Include(article => article.Author).Where(article => article.Author.Id == Id).ToListAsync();
        }

    }
}

using Blog.Data;
using Blog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Blog.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    private readonly BlogDbContext db;

    public IndexModel(ILogger<IndexModel> logger, BlogDbContext db)
    {
        _logger = logger;
        this.db = db;
    }

    public List<Article> articlesList { get; set; }

    public async Task OnGetAsync()
    {
        articlesList = await db.Articles.Include(article => article.Author).ToListAsync();
    }
}

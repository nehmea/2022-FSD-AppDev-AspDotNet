using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyFriends.Data;
using MyFriends.Models;
using Microsoft.EntityFrameworkCore;

namespace MyFriends.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly FriendsDbContext db;

    public IndexModel(FriendsDbContext db, ILogger<IndexModel> logger)
    {
        _logger = logger;
        this.db = db;
    }

    public List<Friend> Friends { get; set; }

    public async void OnGet()
    {
        Friends = await db.Friends.ToListAsync();
    }
}

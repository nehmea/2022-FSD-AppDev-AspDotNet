using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyFriends.Data;
using MyFriends.Models;

namespace MyFriends.Pages
{
    public class ViewModel : PageModel
    {
        private readonly FriendsDbContext db;

        public ViewModel(FriendsDbContext db)
        {
            this.db = db;
        }

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        public Friend friend { get; set; }


        public async Task OnGetAsync() => friend = await db.Friends.FindAsync(Id);
    }
}

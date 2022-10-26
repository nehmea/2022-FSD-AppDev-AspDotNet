using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyFriends.Models;
using MyFriends.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace MyFriends.Pages
{
    public class AddModel : PageModel
    {

        private FriendsDbContext db;
        public AddModel(FriendsDbContext db) => this.db = db;

        [BindProperty]
        public Friend NewFriend { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            else
            {
                await db.Friends.AddAsync(NewFriend);
                await db.SaveChangesAsync();
                return RedirectToPage("./AddSuccess");
            }
        }
    }
}

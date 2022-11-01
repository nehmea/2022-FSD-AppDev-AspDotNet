using System.ComponentModel.DataAnnotations;
using Blog.Data;
using Blog.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Blog.Pages
{
    [Authorize(Roles = "User")]
    public class AddArticleModel : PageModel
    {

        private readonly BlogDbContext db;
        private ILogger<RegisterModel> logger;
        public AddArticleModel(BlogDbContext db, ILogger<RegisterModel> logger)
        {
            this.db = db;
            this.logger = logger;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required, MinLength(3), MaxLength(150)]
            public string Title { get; set; }

            [Required, MinLength(3), MaxLength(20000), Display(Name = "Content")]
            public string Body { get; set; }
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                string userName = User.Identity.Name;
                var user = db.Users.Where(user => user.UserName == userName).FirstOrDefault();
                var newArticle = new Article { Title = Input.Title, Body = Input.Body, Author = user, Created = DateTime.Now };
                await db.AddAsync(newArticle);
                await db.SaveChangesAsync();

                return RedirectToPage("/Index");
            }
            return Page();
        }
    }
}

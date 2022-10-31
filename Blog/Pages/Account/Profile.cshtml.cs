using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Blog.Data;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;

namespace Blog.Pages
{
    [Authorize]
    public class ProfileModel : PageModel
    {
        private UserManager<IdentityUser> userManager;

        private SignInManager<IdentityUser> signInManager;

        private readonly BlogDbContext db;

        private ILogger<RegisterModel> logger;
        public ProfileModel(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, ILogger<RegisterModel> logger, BlogDbContext db)
        {
            this.userManager = userManager;
            this.logger = logger;
            this.signInManager = signInManager;
            this.db = db;
        }


        [BindProperty]
        public InputModel Input { get; set; } = new InputModel();

        public class InputModel
        {

            [Required]
            [DataType(DataType.Password)]
            [Display(Name = "Current Password")]
            public string CurrentPassword { get; set; }

            [Required]
            [Display(Name = "New Password")]
            [StringLength(100, MinimumLength = 6, ErrorMessage = " The {0} must be at least {2} and at max {1} characters long")]
            [DataType(DataType.Password)]
            public string NewPassword { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm Password")]
            [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {

            if (ModelState.IsValid)
            {
                string userName = User.Identity.Name;
                var user = await userManager.FindByNameAsync(userName); //db.Users.Where(user => user.UserName == userName).FirstOrDefault();
                // await userManager.CheckPasswordAsync(user, Input.CurrentPassword);
                var result = await userManager.ChangePasswordAsync(user, Input.CurrentPassword, Input.NewPassword);
                if (result.Succeeded)
                {
                    logger.LogInformation($"User {userName} changed their passowrd successfully");
                    return RedirectToPage("Profile");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

                // string userName = User.Identity.Name;
                // IdentityUser user = db.Users.Where(user => user.UserName == userName).FirstOrDefault();
                // var passwordCheck = userManager.CheckPasswordAsync(user, Input.CurrentPassword);
                // if (passwordCheck.Result)
                // {
                //     db.Users.Update(user);
                //     await db.SaveChangesAsync();
                // }
            }
            return Page();
        }
    }
}

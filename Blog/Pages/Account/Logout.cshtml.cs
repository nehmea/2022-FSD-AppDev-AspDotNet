using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Blog.Pages
{
    public class LogoutModel : PageModel
    {
        private UserManager<IdentityUser> userManager;
        private SignInManager<IdentityUser> signInManager;

        private ILogger<RegisterModel> logger;
        public LogoutModel(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, ILogger<RegisterModel> logger)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.logger = logger;
        }
        public async Task<IActionResult> OnGetAsync()
        {
            if (signInManager.IsSignedIn(User))
            {
                await signInManager.SignOutAsync();
                logger.LogInformation($"User {User.Identity.Name} has logged out");
            }
            return Page();
        }
    }
}

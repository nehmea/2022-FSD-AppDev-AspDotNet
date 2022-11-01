using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MidtermAuction.Pages
{
    public class NewAuctionSuccessModel : PageModel
    {

        [BindProperty(SupportsGet = true)]
        public string ItemName { get; set; }

        public void OnGet()
        {

        }
    }
}

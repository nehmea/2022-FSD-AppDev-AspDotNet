using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MidtermAuction.Pages
{
    public class AuctionBidSuccessModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string ItemName { get; set; } = "";

        [BindProperty(SupportsGet = true)]
        public string NewBidPrice { get; set; } = "";

        public void OnGet()
        {
        }
    }
}

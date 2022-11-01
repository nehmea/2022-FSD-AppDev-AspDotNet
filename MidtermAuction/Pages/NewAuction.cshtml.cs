using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MidtermAuction.Data;
using MidtermAuction.Models;

namespace MidtermAuction.Pages
{
    public class CreateModel : PageModel
    {
        private readonly MidtermAuction.Data.AuctionDbContext _context;

        public CreateModel(MidtermAuction.Data.AuctionDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Auction Auction { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Auctions == null || Auction == null)
            {
                return Page();
            }

            _context.Auctions.Add(Auction);
            await _context.SaveChangesAsync();

            return RedirectToPage("./NewAuctionSuccess", new { ItemName = Auction.ItemName });
        }
    }
}

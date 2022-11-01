using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MidtermAuction.Data;
using MidtermAuction.Models;

namespace MidtermAuction.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly MidtermAuction.Data.AuctionDbContext _context;

        public DetailsModel(MidtermAuction.Data.AuctionDbContext context)
        {
            _context = context;
        }

        public Auction Auction { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Auctions == null)
            {
                return NotFound();
            }

            var auction = await _context.Auctions.FirstOrDefaultAsync(m => m.Id == id);
            if (auction == null)
            {
                return NotFound();
            }
            else
            {
                Auction = auction;
            }
            return Page();
        }
    }
}

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
    public class IndexModel : PageModel
    {
        private readonly MidtermAuction.Data.AuctionDbContext _context;

        public IndexModel(MidtermAuction.Data.AuctionDbContext context)
        {
            _context = context;
        }

        public IList<Auction> Auction { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Auctions != null)
            {
                Auction = await _context.Auctions.ToListAsync();
            }
        }
    }
}

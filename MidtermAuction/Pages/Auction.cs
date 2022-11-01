using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MidtermAuction.Data;
using MidtermAuction.Models;

namespace MidtermAuction.Pages
{
    public class EditModel : PageModel
    {
        private readonly MidtermAuction.Data.AuctionDbContext _context;

        public EditModel(MidtermAuction.Data.AuctionDbContext context)
        {
            _context = context;
        }

        [BindProperty(SupportsGet = true)]
        public int id { get; set; }


        public Auction Auction { get; set; } = default!;

        [BindProperty]
        [Required, Display(Name = "Bid Price")]
        public double NewBidPrice { get; set; }

        [BindProperty]
        [Required, EmailAddress, Display(Name = "Email Address")]
        public string NewBidderEmail { get; set; }

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
            Auction = auction;
            return Page();
        }


        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            Auction = await _context.Auctions.FirstOrDefaultAsync(m => m.Id == id);
            if (Auction == null)
            {
                return NotFound();
            }
            if (NewBidPrice <= Auction.LastPrice)
            {
                ModelState.AddModelError(string.Empty, "New Bid price should be higher than last bid price");
                return Page();
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            Auction.LastBidderEmail = NewBidderEmail;
            Auction.LastPrice = NewBidPrice;
            _context.Attach(Auction).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuctionExists(Auction.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./AuctionBidSuccess", new { ItemName = Auction.ItemName, NewBidPrice = NewBidPrice });
        }

        private bool AuctionExists(int id)
        {
            return (_context.Auctions?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

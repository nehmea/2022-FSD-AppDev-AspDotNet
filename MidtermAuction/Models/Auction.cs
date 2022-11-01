using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MidtermAuction.Models
{
    public class Auction
    {
        public int Id { get; set; }

        [Required, EmailAddress, Display(Name = "Seller Email")]
        public string SellerEmail { get; set; }

        [Required, StringLength(100, MinimumLength = 2, ErrorMessage = " The {0} must be at least {2} and at max {1} characters long.")]
        [Display(Name = "Item Name")]
        [RegularExpression(@"^[a-zA-Z0-9\s\:\.\/,_\(\)\-]{1,40}$", ErrorMessage = "Item name can contain only uppercase, lowercase, digits, spaces and :./,_()-")]
        public string ItemName { get; set; }

        [Required, StringLength(10000, MinimumLength = 2, ErrorMessage = " The {0} must be at least {2} and at max {1} characters long.")]
        [Display(Name = "Item Description")]
        [AllowHtml]
        public string ItemDescription { get; set; }

        [Required]
        [Range(0.0, Double.MaxValue, ErrorMessage = "The Bid Price {0} must be greater than {1}.")]
        [Display(Name = "Bid Price")]
        public double LastPrice { get; set; }

        [EmailAddress]
        [Display(Name = "Last Bidder Email")]
        //[Display(Name = "Last Bidder Email")]
        //[Required(AllowEmptyStrings = true)]
        public string? LastBidderEmail { get; set; }
    }
}
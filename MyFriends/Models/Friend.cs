using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MyFriends.Models
{
    public class Friend
    {
        public int Id { get; set; }

        [Required, StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters.")]
        public string Name { get; set; }

        [Required, Range(1, 150, ErrorMessage = "Age must not exceed 150")]
        public string Age { get; set; }
    }
}
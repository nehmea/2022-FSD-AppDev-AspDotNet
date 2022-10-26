using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyFriends.Models;

namespace MyFriends.Data
{
    public class FriendsDbContext : DbContext
    {
        public DbSet<Friend> Friends { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data source=MyFriends.db");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;
using FitFrig.Web.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FitFrig.Web.Data
{
    public class FoodDbContext : DbContext
    {
        public DbSet<Food> Food { get; set; }

        public FoodDbContext(DbContextOptions<FoodDbContext> options) : base(options)
        {            
        }
    }
}

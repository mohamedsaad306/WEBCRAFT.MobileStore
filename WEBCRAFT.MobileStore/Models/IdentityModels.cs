﻿using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace WEBCRAFT.MobileStore.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<PartModel> PartModels { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Account> Accounts { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }
    }
}
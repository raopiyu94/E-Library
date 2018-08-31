using eLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace eLibrary.Dal
{
    public class Dal:DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Book>().ToTable("tblBooks"); 
            modelBuilder.Entity<Customer>().ToTable("tblCustomers"); 
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}
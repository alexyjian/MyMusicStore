using System;
using DataContext.Migrations;
using Entities;
using System.Runtime.Remoting.Contexts;

namespace DataContext.Migrations
{
    public class ProductDbContext : Context
    {
        public DbSst<Product> Categories { get; set; }
        public DbSst<Product> Products { get; set; }

    }

}

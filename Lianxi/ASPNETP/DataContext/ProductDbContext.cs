﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Entities;
namespace DataContext
{
    public class ProductDbContext:System.Data.Entity.DbContext
        {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Puoducts { get; set; }
   //不合格
    }
}

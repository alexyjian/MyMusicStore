﻿using CodeFirst1108.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst1108.DataContext
{
   public  class StunDbContext:DbContext
    {
        public DbSet<DeparMent> DeparMents { get; set; }
        public DbSet<Studetnt> Students { get; set; }
    }
}

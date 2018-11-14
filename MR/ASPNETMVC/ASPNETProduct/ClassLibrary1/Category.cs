﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Category
    {
        /// <summary>
        /// 分类的实体
        /// </summary>
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string SortCode { get; set; }
        public Category()
        {
            this.ID = Guid.NewGuid();
        }
    }
}
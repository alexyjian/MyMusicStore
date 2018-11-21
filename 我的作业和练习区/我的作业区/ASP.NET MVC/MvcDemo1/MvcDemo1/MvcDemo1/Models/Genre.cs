using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcDemo1.Models
{
    public class Genre
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public Genre()
        {
            ID = Guid.NewGuid();
        }
    }
}
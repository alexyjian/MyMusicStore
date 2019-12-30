using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _11_19_MvcDemo.Models
{
    public class Genres
    {
        public Guid ID { get; set; }
        public string Name { get; set; }

        public Genres()
        {
            ID = Guid.NewGuid();
        }
    }
}
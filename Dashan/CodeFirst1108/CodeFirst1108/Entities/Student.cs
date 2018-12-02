﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst1108.Entities
{
  public  class Student
    {
        public Guid ID { get; set;}
        public string StudentNo { get; set;}
        public string FirstName { get; set;}
        public string LastName { get; set;}
        public string FullName { get; set;}
        public bool Sex { get; set; } = true;
        public DateTime BirthDay { get; set; } = DateTime.Parse("1990-10-01");
         public string Address { get; set;}
        public string Phone { get; set;}
        public virtual DepartMent Department { get; set;}
        public Student()
        {
            this.ID = Guid.NewGuid();
         
        }
        public string GetFullName()
        {
            this.FirstName = this.FirstName + this.LastName;
            return this.FullName;
        }

    }
}
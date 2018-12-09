﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstDemo.CodeFirstNodels
{
    /// <summary>
    /// 学生信息实体
    /// </summary>
   public class Student
    {
        public Guid ID { get; set; }
        //姓名
        public string Name { get; set; }
        //学号
        public string StudentCode { get; set; }
        //性别
        public bool Sex { get; set; }
        //生日
        public DateTime Birthday { get; set; }
        //地址
        public string Address { get; set; }
        //联系电话
        public string Phone { get; set; }
        public virtual Department Department { get; set; }

        public Student()
        {
            ID = Guid.NewGuid();
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace _1027EF代码优先作业
{
    using System;
    using System.Collections.Generic;
    
    public partial class Courses
    {
        public System.Guid ID { get; set; }
        public string Tile { get; set; }
        public int Credit { get; set; }
        public Nullable<System.Guid> Department_ID { get; set; }
    
        public virtual Departments Departments { get; set; }
    }
}

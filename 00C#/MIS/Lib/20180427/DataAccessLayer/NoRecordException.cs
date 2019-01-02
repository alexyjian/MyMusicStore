using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class NoRecordException:ApplicationException
    {
        public NoRecordException() 
            : base("查询记录失败") { }

        public NoRecordException(string message)
            : base(message) { }
    }
}

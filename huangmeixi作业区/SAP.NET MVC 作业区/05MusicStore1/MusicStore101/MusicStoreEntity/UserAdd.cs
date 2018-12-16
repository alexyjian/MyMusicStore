using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreEntity
{
    public class UserAdd
    {
        
        public Guid ID { get; set; }

      
        public string AddressPerson { get; set; }// 收件人


        public string Location { get; set; }// 收件人地址

     

        public string MobilNumber { get; set; }//收件人电话号码

        public string  Email { get; set; }
        public UserAdd()
        {
            ID = Guid.NewGuid();

        }
    }
}

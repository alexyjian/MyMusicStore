using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreEntities.UserAndRole
{
    public class Person
    {
        public Guid ID { get; set; }

        [StringLength(50)]
        public string Name { get; set; } // 全名

        [StringLength(1000)]
        public string Description { get; set; } // 人员简要编码

        [StringLength(50)]
        public string SortCode { get; set; } // 系统内部编码

        [StringLength(50)]
        public string FirstName { get; set; } // 姓氏

        [StringLength(50)]
        public string LastName { get; set; } // 名字

        public bool Sex { get; set; } // 性别

        [StringLength(20)]
        public string TelephoneNumber { get; set; } // 电话号码

        [StringLength(20)]
        public string MobileNumber { get; set; } // 手机号码

        [StringLength(100)]
        public string Email { get; set; } // 电子邮箱

        public DateTime Birthday { get; set; } // 出生日期

        [StringLength(26)]
        public string CredentialsCode { get; set; } // 身份证编号

        public DateTime UpdateTime { get; set; } // 信息更新时间

        public DateTime CreateDateTime { get; set; } // 创建日期

        [StringLength(50)]
        public string InquiryPassword { get; set; } // 查询密码，仅仅用于查询是否已经已经建立数据
        
        public Person()
        {
            this.ID = Guid.NewGuid();
            this.UpdateTime = DateTime.Now;
            this.CreateDateTime = DateTime.Now;
        }
    }
}

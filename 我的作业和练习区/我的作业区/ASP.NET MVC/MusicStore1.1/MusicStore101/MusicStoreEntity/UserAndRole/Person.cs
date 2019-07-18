using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreEntity.UserAndRole
{
    public class Person
    {
        [ScaffoldColumn(false)]
        public Guid ID { get; set; }

        [StringLength(50)]
        [Display(Name = "姓名")]
        [Required(ErrorMessage = "姓名不能为空。")]
        public string Name { get; set; } // 全名

        [ScaffoldColumn(false)]
        [StringLength(1000)]
        public string Description { get; set; } // 人员简要编码

        [ScaffoldColumn(false)]
        [StringLength(50)]
        public string SortCode { get; set; } // 系统内部编码

        [ScaffoldColumn(false)]
        [StringLength(50)]
        public string FirstName { get; set; } // 姓氏

        [ScaffoldColumn(false)]
        [StringLength(50)]
        public string LastName { get; set; } // 名字

        [ScaffoldColumn(false)]
        public bool Sex { get; set; } // 性别

        [ScaffoldColumn(false)]
        [StringLength(20)]
        public string TelephoneNumber { get; set; } // 电话号码

        [Display(Name = "手机号")]
        [Required(ErrorMessage = "手机号不能为空。")]
        [StringLength(20)]
        public string MobileNumber { get; set; } // 手机号码

        [StringLength(100)]
        [Display(Name = "邮箱")]
        [Required(ErrorMessage = "邮箱不能为空。")]
        public string Email { get; set; } // 电子邮箱

        [ScaffoldColumn(false)]
        public DateTime Birthday { get; set; } // 出生日期

        [ScaffoldColumn(false)]
        [StringLength(26)]
        public string CredentialsCode { get; set; } // 身份证编号

        [ScaffoldColumn(false)]
        public DateTime UpdateTime { get; set; } // 信息更新时间

        [ScaffoldColumn(false)]
        public DateTime CreateDateTime { get; set; } // 创建日期
        public string Address { get; set; }

        [ScaffoldColumn(false)]
        [DataType(DataType.ImageUrl)]
        public string Avarda { get; set; } = "/Content/Images/moren.png";//头像

        [ScaffoldColumn(false)]
        [StringLength(50)]
        public string InquiryPassword { get; set; } // 查询密码，仅仅用于查询是否已经已经建立数据
        public virtual ICollection<PersonAddress> PersonAddresss { get; set; }

        public Person()
        {
            this.ID = Guid.NewGuid();
            this.UpdateTime = DateTime.Now;
            this.CreateDateTime = DateTime.Now;
        }
    }
}

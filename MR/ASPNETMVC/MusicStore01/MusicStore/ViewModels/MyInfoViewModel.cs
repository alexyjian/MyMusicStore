using MusicStoreEntity.UserAndRole;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicStore.ViewModels
{
    public class MyInfoViewModel
    {
        [Required(ErrorMessage = "姓名不能为空")]
        [Display(Name = "姓名")]
        public string Name { get; set; }

        //性别验证
        [Display(Name = "性别")]
        public bool sex { get; set; }

        //电话号码验证
        [Required(ErrorMessage ="手机号不能为空")]
        [Display(Name = "手机号")]
        public string TelePhoneNumber { get; set; }

        //邮箱验证
        [Required(ErrorMessage ="邮箱不能为空")]
        [Display(Name = "邮箱")]
        public string Email { get; set; }

        //收货地址验证
        [Required(ErrorMessage ="收货地址不能为空")]
        [Display(Name = "收货地址")]
        public string Address { get; set; }

        //生日     
        [Display(Name = "生日")]
        //public DateTime Birthay { get; set; }
        public string Birthay { get; set; }

        public MyInfoViewModel()
        {
        }
        public MyInfoViewModel(Person person)
        {
            this.Name = person.Name;
            this.Address = person.Address;
            this.sex = person.Sex;
            this.TelePhoneNumber = person.TelephoneNumber;
            this.Email = person.Email;
            this.Birthay =person.Birthday.ToString("yyyy-MM-dd");
        }

    }
   
}
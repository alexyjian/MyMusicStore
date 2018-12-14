using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreEntity
{
   public class My
    {
        public Guid ID { get; set; }

        /// <summary>
        /// /收件人
        /// </summary>
        [Required(ErrorMessage = " 收件人不能为空")]//必填
        [Display(Name = "收件人")]//显示的中文名
        
        public string AddressPerson { get; set; }

        /// <summary>
        /// 所在地区
        /// </summary>
        [Required(ErrorMessage = " 所在地区")]//必填
        [Display(Name = "所在地区")]//显示的中文名

        public string Area { get; set; }//所在地区

        /// <summary>
        /// 街道地址
        /// </summary>
        [Required(ErrorMessage = "街道地址")]//必填
        [Display(Name = "街道地址")]//显示的中文名
        public string Address { get; set; }//街道地址

        /// <summary>
        /// 手机
        /// </summary>
        [Required(ErrorMessage = " 手机不能为空")]//必填
        [Display(Name = "手机")]//显示的中文名

        public string MobiNumber { get; set; }//收件人的手机
        /// <summary>
        /// 邮编
        /// </summary>

        [Required(ErrorMessage = "邮政编号")]//必填
        [Display(Name = "邮政编号")]
      
       
        public string Email { get; set; }


        public My()
        {
            ID = Guid.NewGuid();
        }
    }
}

using MusicStoreEntity;
using MusicStoreEntity.UserAndRole;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicStore.ViewModels
{
    public class RepViewModel
    {
        public Guid ID { get; set; }

        [Required(ErrorMessage = "回复内容不能为空")]
        [Display(Name = "回复")]
        public string Content { get; set; }

        public  Person Person { get; set; }

      
        public  Album Album { get; set; }



        public DateTime CreateDateTime { get; set; }


    }
}
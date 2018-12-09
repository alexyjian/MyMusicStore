﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreEntity
{
    /// <summary>
    /// 音乐分类
    /// </summary>
   public class Genre
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        //当前分类包含的专辑
        public virtual ICollection<Ablum> Ablums { get; set; }
        public Genre()
        {
            ID = Guid.NewGuid();
        }
    }
}

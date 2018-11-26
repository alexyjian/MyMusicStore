using System;
using System.ComponentModel.DataAnnotations;

namespace MusicStoreEntities.UserAndRole
{
    /// <summary>
    /// 系统基础信息
    /// </summary>
    public class ApplicationInformation 
    {
        [Key]
        public Guid ID { get; set; }

        [StringLength(100)]
        public string Name { get; set; } // 应用程序程序集完全名字空间名称

        [StringLength(500)]
        public string Description { get; set; } // 说明

        [StringLength(50)]
        public string SortCode { get; set; } // 序号

        public Guid AppID { get; set; } // 应用程序程序集ID

        [StringLength(100)]
        public string AppShortName { get; set; } // 应用程序程序集名称

        [StringLength(100)]
        public string AppDisplayName { get; set; } // 应用程序名称

        [StringLength(100)]
        public string AppFullUrl { get; set; } // 应用程序访问完整路径

        [StringLength(100)]
        public string AppDesktopFullUrl { get; set; } // 应用程序个人桌面完整路径

        [StringLength(100)]
        public string AppSSOFullUrl { get; set; } // 应用程序单点登录完整路径

        [StringLength(100)]
        public string AppVersion { get; set; } // 版本

        [StringLength(100)]
        public string AppIconString { get; set; } // 显示的图标字符串

        public bool IsDefault { get; set; } // 是否平台缺省应用

        public virtual ApplicationBusinessType AppType { get; set; } // 应用系统类型

        public ApplicationInformation()
        {
            this.ID = Guid.NewGuid();
        }
    }
}
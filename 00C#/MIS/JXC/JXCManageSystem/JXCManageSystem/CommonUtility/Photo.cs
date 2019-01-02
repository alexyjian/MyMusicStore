using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;

namespace CommonUtility
{
    /// <summary>
    /// 照片的读写类
    /// </summary>
    public class Photo
    {
        /// <summary>
        /// 按文件的物理路径读取图片文件的内容
        /// </summary>
        /// <param name="photoPath"></param>
        /// <returns></returns>
        public static byte[] ReadPhotoFromPath(string photoPath)
        {
            //检测路径是否为空
            if (string.IsNullOrEmpty(photoPath))
                throw new ArgumentNullException("photoPath");
            //检测是否为图片文件
            try
            {
                //利用图像处理类判断此文件是否为图片
                Image img = Image.FromFile(photoPath);
            }
            catch
            {
                //如果图片转换失败，则此文件不是图片，跳出方法
                return null;
            }
            //读取文件内容
            var fileContent = new FileStream(photoPath, FileMode.Open, FileAccess.Read);
            BinaryReader reader = new BinaryReader(fileContent);
            return reader.ReadBytes((int)fileContent.Length);
        }
    }
}

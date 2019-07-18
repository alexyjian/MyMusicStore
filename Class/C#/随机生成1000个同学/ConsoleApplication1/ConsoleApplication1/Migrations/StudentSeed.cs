using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MoreLinq;
using EntityFramework.Extensions;

namespace ConsoleApplication1.Migrations
{
    public class StudentSeed
    {
        public static void Seed(StudentContext context)
        {
            string[] nameS3 = new string[] { "赵", "钱", "孙", "李", "周", "吴", "郑", "王", "冯",
             "陈", "褚", "卫", "蒋", "沈", "韩", "杨", "朱", "秦", "尤", "许", "何", "吕", "施",
             "张", "孔", "曹", "严", "华", "金", "魏", "陶", "姜", "戚", "谢", "邹", "喻", "柏",
             "水", "窦", "章", "云", "苏", "潘", "葛", "奚", "范", "彭", "郎" };

            string[] nameS2 = new string[] {"鲁","韦","昌","马","苗","凤","花","方","俞","任","袁"
             ,"柳","酆","鲍","史","唐","费","廉","岑","薛","雷","贺","倪","汤","滕","殷","罗",
             "毕","郝","邬","安","常","乐","于","时","傅","皮","卞","齐","康","伍","余","元",
             "卜","顾","孟","平","黄"};

            string[] nameS1 = new string[] { "梅", "盛", "林", "刁", "锺", "徐", "邱", "骆", "高",
             "夏", "蔡", "樊", "胡", "凌", "霍", "虞", "万", "支", "柯", "昝", "管", "卢", "莫",
             "经", "房", "裘", "缪", "干", "解", "应", "宗", "丁", "宣", "贲", "邓", "郁", "单",
             "杭", "洪", "包", "诸", "左", "石", "崔", "吉", "钮", "龚", "程", "嵇", "邢", "滑",
             "裴", "陆", "荣", "翁", "荀", "羊", "於", "惠", "甄", "麴", "家", "封", "芮", "羿",
             "储", "靳", "汲", "邴", "糜", "松", "井" };

            string[] phoneHead = new string[]{ "182", "188", "151", "189", "135", "158", "159" };

            for (int i = 0; i < 1000; i++)
            {
                Random rd = new Random();

                string s1 = nameS1[rd.Next(0, nameS1.Length - 1)];
                string s2 = nameS2[rd.Next(0, nameS2.Length - 1)];
                string s3 = nameS3[rd.Next(0, nameS3.Length - 1)];
                string name = s3 + s2 + s1;

                var lastNum = rd.Next(10000000, 99999999).ToString();
                var sortcode = "00" + rd.Next(1, 3);

                var stu = new Student()
                {
                    Name = name,
                    StuNumber = "2017031" + i.ToString("0000"),
                    Birthday = DateTime.Parse("1999-1-1"),
                    Address = "广西柳州市柳南区",
                    Phone = phoneHead[rd.Next(0, phoneHead.Length - 1)] + lastNum,
                    Department = context.Departments.SingleOrDefault(x => x.SortCode == sortcode)
                };

                context.Students.Add(stu);
                Thread.Sleep(3);
            }
        }

        public static void _GarbageClear()
        {
            var dbcontext = new StudentContext();
            var students = dbcontext.Students.DistinctBy(x => x.Name).ToList();
            foreach (var stu in students)
            {
                dbcontext.Students.Where(x => x.Name == stu.Name && x.ID != stu.ID).Delete();
            }
        }
    }
}

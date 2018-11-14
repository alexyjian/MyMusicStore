using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.Extensions;
using MoreLinq;
using System.Threading;
using DataContext;
using Entities;

namespace DataContext
{
    public class StudentSeed
    {
        public static void Seed(StuDBContext context)
        {
            var d1 = context.DepartMents.SingleOrDefault(x => x.Name == "电子信息工程学院");
            var firstName = "";
            var lastName = "";
            for (var i = 0; i < 300; i++)
            {
                var fullname = _GetRandomChineseFullName(ref firstName, ref lastName);

                var student = new Student()
                {
                    StudentCode = "DZXX" + i.ToString("0000"),
                    Name = fullname,
                    Sex = new Random().Next(10) > 5 ? true : false,
                    Birthday = DateTime.Now,
                    Address = "社湾路28号",
                    Department_ID = d1,
                    Phone = "188********"
                };
                context.Students.Add(student);
                Thread.Sleep(1);
            }

            var d2 = context.DepartMents.SingleOrDefault(x => x.Name == "汽车工程学院");
            for (var i = 0; i < 300; i++)
            {
                var fullname = _GetRandomChineseFullName(ref firstName, ref lastName);

                var student = new Student()
                {
                    StudentCode = "QCGC" + i.ToString("0000"),
                    Name = fullname,
                    Sex = new Random().Next(10) > 0.1 ? true : false,
                    Birthday = DateTime.Now,
                    Address = "社湾路28号",
                    Department_ID = d2,
                    Phone = "188********"
                };
                context.Students.Add(student);
                Thread.Sleep(1);
            }

            var d3 = context.DepartMents.SingleOrDefault(x => x.Name == "艺术学院");
            for (var i = 0; i < 200; i++)
            {
                var fullname = _GetRandomChineseFullName(ref firstName, ref lastName);

                var student = new Student()
                {
                    StudentCode = "YS" + i.ToString("0000"),
                    Name = fullname,
                    Sex = new Random().Next(10) > 8 ? true : false,
                    Birthday = DateTime.Now,
                    Address = "社湾路28号",
                    Department_ID = d3,
                    Phone = "188********"
                };
                context.Students.Add(student);
                Thread.Sleep(1);
            }

            var d4 = context.DepartMents.SingleOrDefault(x => x.Name == "贸易与旅游工程学院");
            for (var i = 0; i < 200; i++)
            {
                var fullname = _GetRandomChineseFullName(ref firstName, ref lastName);

                var student = new Student()
                {
                    StudentCode = "MYLY" + i.ToString("0000"),
                    Name = fullname,
                    Sex = new Random().Next(10) > 6 ? true : false,
                    Birthday = DateTime.Now,
                    Address = "社湾路28号",
                    Department_ID = d4,
                    Phone = "188********"
                };
                context.Students.Add(student);
                Thread.Sleep(1);
            }

            context.SaveChanges();
            _GarbageClear();
        }
        /// <summary>
        /// 随机生成中文姓名
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        private static string _GetRandomChineseFullName(ref string firstName, ref string lastName)
        {
            string str = "赵钱孙李周吴郑王冯陈褚卫蒋沈韩杨朱秦尤许何吕施张孔曹严华金魏陶姜戚谢邹喻柏水窦章云苏潘葛奚范彭郎鲁韦昌马苗凤花方俞任袁柳酆鲍史唐费廉岑薛雷贺倪汤";
            char[] _seedfirstName = str.ToCharArray();
            string _seedLastName = "伟刚勇毅俊峰强军平保东文辉力明永健世广志义兴良海山仁波宁贵福生龙元全国胜学祥才发武新利清飞彬富顺信子杰涛昌成康星光天达安岩中茂进林有坚和彪博诚先敬震振壮会思群豪心邦承乐绍功松善厚庆磊民友裕河哲江超浩亮政谦亨奇固之轮翰朗伯宏言若鸣朋斌梁栋维启克伦翔旭鹏泽晨辰士以建家致树炎德行时泰盛姿梨秋蕾瑾羽菡莺卿柳曼惠灵萍思婉盼艺雯冰菲雪旋玥蓝晓如燕紫甜春海静绮曦悦梅柔迎蓉瑜素彩娅盈婷璇瑛芳虹英怡涵霎舞欢薇珠丽雅洁嫣南若佳韵茹倩竹纹敏惜婕凝萱嘉娜琼诗婧颖茵菊青枝幽宛姗妮沛桐昕映念沐蕊馨芬佩欣玫音柏夏香";

            var rnd = new Random(DateTime.Now.Millisecond);
            firstName = _seedfirstName[rnd.Next(_seedfirstName.Length - 1)].ToString();
            lastName = _seedLastName.Substring(rnd.Next(0, _seedLastName.Length - 1), 1)
                + _seedLastName.Substring(rnd.Next(0, _seedLastName.Length - 1), 1);
            //几率产生一个名
            if (rnd.Next(10 * 3) < 2)
            {
                var n = lastName.ToCharArray();
                lastName = n[rnd.Next(2)].ToString();
            }
            return firstName + lastName;
        }
        private static void _GarbageClear()
        {
            var dbcontext = new StuDBContext();
            var students = dbcontext.Students.DistinctBy(x => x.Name).ToList();
            //删除
            foreach (var stu in students)
            {
                dbcontext.Students.Where(x => x.Name == stu.Name &&
                        x.ID != stu.ID).Delete();
            }
        }
    }
}

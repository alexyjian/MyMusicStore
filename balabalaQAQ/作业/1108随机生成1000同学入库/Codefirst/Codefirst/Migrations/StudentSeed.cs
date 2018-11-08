using Codefirst.DataContext;
using Codefirst.Entities;
using EntityFramework.Extensions;
using MoreLinq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Codefirst.Migrations
{
    public class StudentSeed
    {
        public static void Seed(StuDBContext context)
        {
            List<string> Xing = new List<string>()
            { "赵","钱","孙","李","周", "吴","郑 ","王 ","冯", "陈","褚","卫", "蒋","沈","韩","杨","朱","秦","尤","许",

"何",   "吕",   "施",  "张",   "孔",   "曹",   "严",  "华","金",};
            string _Ming = "刚伟勇毅俊峰强军平保东文辉力明永健世广志义兴良海山仁波宁贵福生龙元全国胜学祥才发武新利清飞彬富顺信子杰涛昌成康星光天达安岩中茂进林有坚和彪博诚先敬震振壮会思群豪心邦承乐绍功松善厚庆磊民友裕河哲江超浩亮政谦亨奇固之轮翰朗伯宏言若鸣朋斌梁栋维启克伦翔旭鹏泽晨辰士以建家致树炎德行时泰盛雄琛钧冠策腾楠榕风航弘";
            char[] Ming = _Ming.ToCharArray();  
            Random X = new Random();
            Random M = new Random();


            for (var i = 0; i < 1000; i++)
            {
                string sotrcode = M.Next(1, 4).ToString();
                var d1 = new Student()
                {
                    Name = Xing[X.Next(Xing.Count-1)] + Ming[M.Next(Ming.Length - 1)] + Ming[M.Next(Ming.Length - 1)],
                    Address = "柳北",
                    Sex = false,
                    Birthday = DateTime.Parse("2000-01-06"),
                    Phone = "151"+X.Next(7000000).ToString(),
                    Department = context.DepartMents.SingleOrDefault(x => x.SortCode == sotrcode),
                    StudentCode = "20170" + X.Next(9) + X.Next(9)+ X.Next(9)+ X.Next(9),
                };
                context.Students.Add(d1);
                Thread.Sleep(1);
            }
        }
        public static void _GarbageClear()
        {
            var dbcontext = new StuDBContext();
            var students = dbcontext.Students.DistinctBy(x => x.Name).ToList();
            //删除重名
            foreach (var stu in students)
                dbcontext.Students.Where(x => x.Name == stu.Name && x.ID != stu.ID).Delete();
        }
    }
}

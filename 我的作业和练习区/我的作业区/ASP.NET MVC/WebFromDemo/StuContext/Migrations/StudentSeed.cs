using StuContext;
using ASPNETWEB.StuEntities;
using EntityFramework.Extensions;
using MoreLinq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StuContext
{
    public class StudentSeed
    {
        public static void Seed(StuDBContext context)
        {
            
            Random random = new Random();
            string name = "赵钱孙李周吴郑王冯陈褚卫蒋沈韩杨朱秦尤许何吕施张孔曹严华金魏陶姜戚谢邹喻柏水窦章云苏潘葛奚范彭郎鲁韦昌马苗凤花方俞任袁柳酆鲍史唐费廉岑薛雷贺倪汤滕殷罗毕郝邬安常乐于时傅皮卞齐康伍余元卜顾孟平黄和穆萧尹姚邵湛汪祁毛禹狄米贝明臧计伏成戴谈宋茅庞熊纪舒屈项祝董梁杜阮蓝闵席季麻强贾路娄危江童颜郭梅盛林刁钟徐邱骆高夏蔡田樊胡凌霍虞万支柯昝管卢莫经房裘缪干解应宗丁宣贲邓郁单杭洪包诸左石崔吉钮龚程嵇邢滑裴陆荣翁荀羊於惠甄麴家封芮羿储靳汲邴糜松井段富巫乌焦巴弓牧隗山谷车侯宓蓬全郗班仰秋仲伊宫宁仇栾暴甘钭厉戎祖武符刘景詹束龙叶幸司韶郜黎蓟薄印宿白怀蒲邰从鄂索咸籍赖卓蔺屠蒙池乔阴郁胥能苍双闻莘党翟谭贡劳逄姬申扶堵冉宰郦雍舄璩桑桂濮牛寿通边扈燕冀郏浦尚农温别庄晏柴瞿阎充慕连茹习宦艾鱼容向古易慎戈廖庾终暨居衡步都耿满弘匡国文寇广禄阙东殴殳沃利蔚越夔隆师巩厍聂晁勾敖融冷訾辛阚那简饶空曾毋沙乜养鞠须丰巢关蒯相查後荆红游竺权逯盖益桓公万俟司马上官欧阳夏侯诸葛闻人东方赫连皇甫尉迟公羊澹台公冶宗政濮阳淳于单于太叔申屠公孙仲孙轩辕令狐钟离宇文长孙慕容鲜于闾丘司徒司空亓官司寇仉督子车颛孙端木巫马公西漆雕乐正壤驷公良拓跋夹谷宰父谷梁晋楚闫法汝鄢涂钦段干百里东郭南门呼延归海羊舌微生岳帅缑亢况后有琴梁丘左丘东门西门商牟佘佴伯赏南宫墨哈谯笪年爱阳佟第五言福";
            string str = "苍苍白露为霜所谓伊人在水一方溯洄从之道阻且长溯游从之宛在水中央萋萋白露未晞所谓伊人在水之湄溯洄从之道阻且跻溯游从之宛在水中坻采采白露未已所谓伊人在水之涘溯洄从之道阻且右溯游从之宛在水中沚若";
            int studentcode = 2017031000;
            string ph ="133";
            for (int i = 0; i < 1000; i++)
            {
                studentcode++;
                int xin = 0, ming = 0, ming1 = 0,de=0;
                xin = random.Next(0, name.Length);
                ming = random.Next(0, str.Length);
                ming1 = random.Next(0, str.Length);
                de = random.Next(1, 4);
                var d = new Student()
                {
                    //随机姓名
                    Name = name.Substring(xin,1) + str.Substring(ming, 1) + str.Substring(ming1, 1),
                    StudentCode =studentcode.ToString(),
                    Sex = (i % 2 == 0) ? true : false,
                    Birthday = DateTime.Now,
                    //随机号码
                    Phone =ph+ de.ToString() + (de/2).ToString() + de.ToString()+((i<100)?"0"+i.ToString():i.ToString()) + de.ToString(),
                    Address="社湾路28号",
                    //随机学院
                    DepartMent = context.DepartMents.SingleOrDefault(x => x.SortCode =="00"+de.ToString())

                };
                context.Students.Add(d);
               
            }           
            context.SaveChanges();
            _GarbageClear();
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

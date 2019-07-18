
using MusicStoreEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;

namespace MusicStore.Migrations
{
    public class GenreSeed
    {
        private static readonly EntityDbContext _dbContext = new EntityDbContext();

        public static void Seed()
        {
            _dbContext.Database.ExecuteSqlCommand("delete Albums");
            _dbContext.Database.ExecuteSqlCommand("delete Artists");
            _dbContext.Database.ExecuteSqlCommand("delete Genres");

            #region 分类
            var genres = new List<Genre>()
            {
                new Genre() { Name = "华语"},
                new Genre() { Name = "流行"},
                new Genre() { Name = "怀旧"},
                new Genre() { Name = "性感"},
                new Genre() { Name = "蓝调"},
                new Genre() { Name = "拉丁"},
                new Genre() { Name = "民族"},
                new Genre() { Name = "古典"},
                new Genre() { Name = "轻音乐"},
                new Genre() { Name = "嘻哈"},
            };
            foreach (var g in genres)
            {
                _dbContext.Genres.Add(g);
            }
            #endregion
            #region 歌手
            var artist = new List<Artist>()
            {
                new Artist() { Name = "蔡健雅",Sex = false,Description="新加坡人，华语著名歌手、词曲作者，音乐制作人。1997年在新加坡由其经纪公司 Music & Movement 旗下的Yellow Music发行英语专辑《Bored》而正式出道，1999年将国语唱片签约于宝丽金唱片旗下，并推出首张国语同名专辑《蔡健雅》。2000年因宝丽金唱片并入环球唱片旗下，因此《记念》及之后的唱片皆由台湾环球唱片发行。在此一专辑中，蔡健雅以〈记念〉一曲成功打响在台湾市场的知名度。同年入围台湾第11届金曲奖最佳新人奖。2002年发行《Secret Lavender》专辑。同年以〈打错了〉作曲者身份入围台湾第13届金曲奖最佳作曲人奖，并同时入围最佳国语演唱人奖。2004年首度担任制作人，替梁咏琪制作《归属感》专辑。同年以《陌生人》获得台湾第15届金曲奖最佳国语女演唱人提名。2008年推出专辑《My Space》，同年获台湾第19届金曲奖7项提名，并获得了最佳专辑制作人和最佳国语女歌手两座大奖。近年移居台湾。2012年获最佳国语女歌手奖。代表作品：《呼吸》《陌生人》《空白格》《若你碰到他》《红色高跟鞋》。"},
                new Artist() { Name = "田馥甄",Sex = false,Description="田馥甄，艺名Hebe，台湾知名女艺人，女子演唱团体S.H.E组合成员，出生于台湾新竹县新丰乡，于2000年参加“宇宙2000实力美少女争霸战”选秀活动，并于同年与宇宙唱片（华研唱片前身）签约培训，接着在隔年与Selina、Ella组成S.H.E，并于2001年9月11日发行S.H.E首张专辑《女生宿舍》正式出道。2010年下半年，S.H.E正式迈向“单飞不解散”阶段，接着同年9月3日，使用本名“田馥甄”推出首张个人专辑《To Hebe》。"},
                new Artist() { Name = "陈奕迅",Sex = true,Description = "著名实力派粤语流行音乐歌手、演员，香港演艺人协会副会长之一，曾被美国《时代杂志》形容为影响香港乐坛风格的人物，同时也是继许冠杰、张学友之后第三个获得“歌神”称号的香港男歌手。同时他也是继张学友后另一个在台湾获得成功的香港歌手，在2003年他成为了第二个拿到台湾金曲奖“最佳国语男演唱人”的香港歌手。陈奕迅曾被《时代》杂志形容为影响香港乐坛风格的人物。2010年，陈奕迅入选全球华人音乐殿堂华语金曲奖“30年经典评选”，成为1990年代出道歌手唯一代表。陈奕迅曾在多个亚太地区获得多个奖项和提名，包括香港地区的“叱咤乐坛男歌手金奖”、“叱咤乐坛我最喜爱的男歌手奖”、“十大劲歌金曲最受欢迎男歌星奖”。代表作品：《爱情转移》、《十年》、《浮夸》、《K歌之王》。"},
                new Artist() { Name = "毛不易",Sex = true,Description = "毛不易，原名王维家，1994年10月1日出生于黑龙江省齐齐哈尔市泰来县，中国内地流行乐男歌手，毕业于杭州师范大学护理专业。2017年，参加选秀娱乐节目《明日之子》的比赛，获得全国总决赛冠军，从而正式进入演艺圈；9月1日，推出首张个人音乐专辑《巨星不易工作室 No.1》；11月11日，推出个人原创单曲《项羽虞姬》。"},
                new Artist() { Name = "林俊杰",Sex = true,Description = "著名男歌手，作曲人、作词人、音乐制作人，偶像与实力兼具。林俊杰出生于新加坡的一个音乐世家。在父母的引导下，4岁就开始学习古典钢琴，不善言辞的他由此发现了另一种与人沟通的语言。小时候的林俊杰把哥哥林俊峰当作偶像，跟随哥哥的步伐做任何事，直到接触流行音乐后，便爱上创作这一条路。2003年以专辑《乐行者》出道，2004年一曲《江南》红遍两岸三地，凭借其健康的形象，迷人的声线，出众的唱功，卓越的才华，迅速成为华语流行乐坛的领军人物之一，迄今为止共创作数百首音乐作品，唱片销量在全亚洲逾1000万张。2007年成立个人音乐制作公司JFJ，2008创立潮流品牌SMG。2011年被媒体封为“新四大天王”之一，同年8月8日正式加盟华纳音乐，开启事业新乐章。2012年发行故事影像书《记得》，成功跻身畅销书作家行列。获得多项奖项：第15届台湾金曲奖最佳新人奖，6届新加坡金曲奖大奖，6届新加坡词曲版权协会大奖，8届全球华语歌曲排行榜大奖，5届MusicRadio中国TOP排行榜大奖。"},
                new Artist() { Name = "G.E.M.邓紫棋",Sex = false,Description = "邓紫棋成长于一个音乐世家，其母亲为上海音乐学院声乐系毕业生，外婆教唱歌，舅父拉小提琴，外公在乐团吹色士风。在家人的熏陶下，自小便热爱音乐，喜爱唱歌，与音乐结下不解之缘。G.E.M.在5岁的时候已经开始尝试作曲及填词，13岁完成了8级钢琴。G.E.M.在小学时期就读位于太子道西的中华基督教会协和小学上午校，为2003年的毕业生，同时亦为校内诗歌班成员。其英文名G.E.M.是Get Everybody Moving的缩写，象徵著她希望透过音乐让大家动起来的梦想。2008年出道，2009年在叱咤乐坛流行榜颁奖典礼夺得女新人奖金奖，亦是该奖项历年来最年轻，以及第一位未成年的得奖者。因其广阔的音域，得到不少前辈歌手点名公开赞扬。2014年她参加湖南卫视《我是歌手》第二季名声大震。"},
                new Artist() { Name = "莫文蔚",Sex = false,Description = "莫文蔚 (Karen Joy Morris，艺名Karen Mok)，香港歌手和演员。1993年发行首张粤语唱片《karen莫文蔚》进入娱乐圈；1995年主演电影《大话西游》获得关注。1996年凭借电影《堕落天使》获得香港电影金像奖最佳女配角奖。1997年莫文蔚在台湾推出首张国语唱片《做自己》，专辑卖出80多万张，主打歌《他不爱我》成为其代表作之一；1999年被香港时装设计师协会评为香港十大杰出衣着人士。2003年获得第5届CCTV-MTV音乐盛典香港地区年度最佳女歌手奖。2008年代表香港参与韩国第五届亚洲音乐节，并获颁亚洲最佳女歌手奖（中国），2011年凭借专辑《宝贝》夺得台湾金曲奖最佳国语女歌手奖。2013年，莫文蔚发行首张英语爵士专辑《Somewhere I Belong》，成为首位itunes同步发行的华人歌手。截至2013年共发行30多张专辑，参演50多部电影，举行过30多场个人演唱会。 2014年9月19日，莫文蔚在沪举办2014“莫后年代”莫文蔚20周年世界巡回演唱会-安可场，而此次场地选址上海大舞台。2015年2月18日莫文蔚登上中央电视台春节联欢晚会，独唱歌曲《当你老了》，9月展开莫文蔚“看看世界巡回演唱会”。2016年7月，参与录制《我们来了》。"},
                new Artist() { Name = "王菲",Sex = false,Description = "中国著名女歌手、演员。是继邓丽君后大中华地区成就最高、影响力最大的华语女歌手。以其极具辨识度的天籁空灵般嗓音，在华语歌坛创造了属于她自己的时代。她是首位登上美国《时代周刊》封面并接受CNN专访的华语歌手。她是身价最高，演唱会上座率最高，演唱会票房累计最高的华语女歌手。王菲北京出生。1987年放弃厦门大学生物系的录取跟随父母移居香港，并拜师戴思聪学习声乐，1989年签约新艺宝唱片公司并发行了第一张个人专辑，从此正式步入乐坛，曾使用艺名王靖雯。她于1994年在香港红馆第一次举办演唱会，就以连续18场的纪录打破新人红馆演唱会纪录，至今仍未有人打破。王菲自2005年逐渐淡出歌坛，2010-2012年开始复出大规模巡回演唱会。代表作品：《我愿意》《执迷不悔》《天空》《红豆》《流年》《催眠》。"},
                new Artist() { Name = "林宥嘉",Sex = true,Description = "林宥嘉（英文名：Yoga Lin，1987年7月1日－）是台湾著名男歌手。出生于台湾屏东县，是家中长子，有一弟一妹，家里经营建材生意。林宥嘉考上凤山高中后搬到高雄居住，高中毕业后就读于国立东华大学运动与休闲学系。2007年7月6日以20岁大学生的身份，获得台湾中视主办的歌唱选秀节目第一届《超级星光大道》冠军，并与华研国际音乐签约成为歌手。演唱歌曲有《你把我灌醉》《悬崖》《我爱的人》《你是我的眼》等。曾获第十届CCTV-MTV音乐盛典港澳台地区年度最受欢迎潜力歌手奖。林宥嘉拥有独特的声线和极佳的唱功，人称“迷幻唱腔”，“迷幻王子”。代表作包括《说谎》、《伯乐》、《我总是一个人在练习一个人》、《诱》、《自然醒》、《想自由》、《心酸》、《残酷月光》等。2017年5月16日入围金曲奖最佳男歌手奖。"}
            };

            foreach (var i in artist)
            {
                _dbContext.Aritists.Add(i);
            }
            #endregion
            #region 专辑
            new List<Album>()
            {
                new Album() { Title = "红色高跟鞋",Genre=genres.Single(a=>a.Name == "华语"),Artist = artist.Single(a=>a.Name == "蔡健雅"),PublisherDate = DateTime.Parse("2009-8-19"),AlbumArtUrl="" },
                new Album() { Title = "越来越不懂",Genre=genres.Single(a=>a.Name == "流行"),Artist = artist.Single(a=>a.Name == "蔡健雅"),PublisherDate = DateTime.Parse("2008-7-29"),AlbumArtUrl="" },
                new Album() { Title = "停格",Genre=genres.Single(a=>a.Name == "怀旧"),Artist = artist.Single(a=>a.Name == "蔡健雅"),PublisherDate = DateTime.Parse("2015-2-11"),AlbumArtUrl="" },
                new Album() { Title = "魔鬼中的天使",Genre=genres.Single(a=>a.Name == "性感"),Artist = artist.Single(a=>a.Name == "田馥甄"),PublisherDate = DateTime.Parse("2011-9-2"),AlbumArtUrl="" },
                new Album() { Title = "小幸运",Genre=genres.Single(a=>a.Name == "蓝调"),Artist = artist.Single(a=>a.Name == "田馥甄"),PublisherDate = DateTime.Parse("2015-10-21"),AlbumArtUrl="" },
                new Album() { Title = "你就不要想起我",Genre=genres.Single(a=>a.Name == "拉丁"),Artist = artist.Single(a=>a.Name == "田馥甄"),PublisherDate = DateTime.Parse("2013-11-29"),AlbumArtUrl="" },
                new Album() { Title = "我们",Genre=genres.Single(a=>a.Name == "民族"),Artist = artist.Single(a=>a.Name == "陈奕迅"),PublisherDate = DateTime.Parse("2018-4-10"),AlbumArtUrl="" },
                new Album() { Title = "好久不见",Genre=genres.Single(a=>a.Name == "古典"),Artist = artist.Single(a=>a.Name == "陈奕迅"),PublisherDate = DateTime.Parse("2007-4-24"),AlbumArtUrl="" },
                new Album() { Title = "十年",Genre=genres.Single(a=>a.Name == "轻音乐"),Artist = artist.Single(a=>a.Name == "陈奕迅"),PublisherDate = DateTime.Parse("2003-4-1"),AlbumArtUrl="" },
                new Album() { Title = "说谎",Genre=genres.Single(a=>a.Name == "嘻哈"),Artist = artist.Single(a=>a.Name == "林宥嘉"),AlbumArtUrl="" },
                new Album() { Title = "成全",Genre=genres.Single(a=>a.Name == "华语"),Artist = artist.Single(a=>a.Name == "林宥嘉"),AlbumArtUrl="" },
                new Album() { Title = "浪费",Genre=genres.Single(a=>a.Name == "流行"),Artist = artist.Single(a=>a.Name == "林宥嘉"),AlbumArtUrl="" },
                new Album() { Title = "可惜没如果",Genre=genres.Single(a=>a.Name == "怀旧"),Artist = artist.Single(a=>a.Name == "林俊杰"),AlbumArtUrl="" },
                new Album() { Title = "他说",Genre=genres.Single(a=>a.Name == "性感"),Artist = artist.Single(a=>a.Name == "林俊杰"),AlbumArtUrl="" },
                new Album() { Title = "江南",Genre=genres.Single(a=>a.Name == "蓝调"),Artist = artist.Single(a=>a.Name == "林俊杰"),AlbumArtUrl="" },
                new Album() { Title = "不染",Genre=genres.Single(a=>a.Name == "拉丁"),Artist = artist.Single(a=>a.Name == "毛不易"),AlbumArtUrl="" },
                new Album() { Title = "消愁",Genre=genres.Single(a=>a.Name == "民族"),Artist = artist.Single(a=>a.Name == "毛不易"),AlbumArtUrl="" },
                new Album() { Title = "想我这样的人",Genre=genres.Single(a=>a.Name == "古典"),Artist = artist.Single(a=>a.Name == "毛不易"),AlbumArtUrl="" },
                new Album() { Title = "慢慢喜欢你",Genre=genres.Single(a=>a.Name == "轻音乐"),Artist = artist.Single(a=>a.Name == "莫文蔚"),AlbumArtUrl="" },
                new Album() { Title = "阴天",Genre=genres.Single(a=>a.Name == "嘻哈"),Artist = artist.Single(a=>a.Name == "莫文蔚"),AlbumArtUrl="" },
                new Album() { Title = "忽然之间",Genre=genres.Single(a=>a.Name == "华语"),Artist = artist.Single(a=>a.Name == "莫文蔚"),AlbumArtUrl="" },
                new Album() { Title = "匆匆那年",Genre=genres.Single(a=>a.Name == "流行"),Artist = artist.Single(a=>a.Name == "王菲"),AlbumArtUrl="" },
                new Album() { Title = "红豆",Genre=genres.Single(a=>a.Name == "怀旧"),Artist = artist.Single(a=>a.Name == "王菲"),AlbumArtUrl="" },
                new Album() { Title = "因为爱情",Genre=genres.Single(a=>a.Name == "性感"),Artist = artist.Single(a=>a.Name == "王菲"),AlbumArtUrl="" },
                new Album() { Title = "光年之外",Genre=genres.Single(a=>a.Name == "蓝调"),Artist = artist.Single(a=>a.Name == "G.E.M.邓紫棋"),AlbumArtUrl="" },
                new Album() { Title = "再见",Genre=genres.Single(a=>a.Name == "拉丁"),Artist = artist.Single(a=>a.Name == "G.E.M.邓紫棋"),AlbumArtUrl="" },
                new Album() { Title = "倒数",Genre=genres.Single(a=>a.Name == "民族"),Artist = artist.Single(a=>a.Name == "G.E.M.邓紫棋"),AlbumArtUrl="" },
                 new Album() { Title = "船",Genre=genres.Single(a=>a.Name == "华语"),Artist = artist.Single(a=>a.Name == "林宥嘉"),AlbumArtUrl="" },
                new Album() { Title = "致姗姗来迟的你",Genre=genres.Single(a=>a.Name == "流行"),Artist = artist.Single(a=>a.Name == "林宥嘉"),AlbumArtUrl="" },
                new Album() { Title = "修炼爱情",Genre=genres.Single(a=>a.Name == "怀旧"),Artist = artist.Single(a=>a.Name == "林俊杰"),AlbumArtUrl="" },
                new Album() { Title = "曹操",Genre=genres.Single(a=>a.Name == "性感"),Artist = artist.Single(a=>a.Name == "林俊杰"),AlbumArtUrl="" },
                new Album() { Title = "爱笑的眼睛",Genre=genres.Single(a=>a.Name == "蓝调"),Artist = artist.Single(a=>a.Name == "林俊杰"),AlbumArtUrl="" },
                new Album() { Title = "哎哟",Genre=genres.Single(a=>a.Name == "拉丁"),Artist = artist.Single(a=>a.Name == "毛不易"),AlbumArtUrl="" },
                new Album() { Title = "项羽虞姬",Genre=genres.Single(a=>a.Name == "民族"),Artist = artist.Single(a=>a.Name == "毛不易"),AlbumArtUrl="" },
                new Album() { Title = "一江水",Genre=genres.Single(a=>a.Name == "古典"),Artist = artist.Single(a=>a.Name == "毛不易"),AlbumArtUrl="" },
                new Album() { Title = "老男孩",Genre=genres.Single(a=>a.Name == "轻音乐"),Artist = artist.Single(a=>a.Name == "莫文蔚"),AlbumArtUrl="" },
                new Album() { Title = "如果没有你",Genre=genres.Single(a=>a.Name == "嘻哈"),Artist = artist.Single(a=>a.Name == "莫文蔚"),AlbumArtUrl="" },
                new Album() { Title = "当你老了",Genre=genres.Single(a=>a.Name == "华语"),Artist = artist.Single(a=>a.Name == "莫文蔚"),AlbumArtUrl="" },
                new Album() { Title = "不问西东",Genre=genres.Single(a=>a.Name == "流行"),Artist = artist.Single(a=>a.Name == "王菲"),AlbumArtUrl="" },
                new Album() { Title = "致青春",Genre=genres.Single(a=>a.Name == "怀旧"),Artist = artist.Single(a=>a.Name == "王菲"),AlbumArtUrl="" },
                new Album() { Title = "暧昧",Genre=genres.Single(a=>a.Name == "性感"),Artist = artist.Single(a=>a.Name == "王菲"),AlbumArtUrl="" },
                new Album() { Title = "盲点",Genre=genres.Single(a=>a.Name == "蓝调"),Artist = artist.Single(a=>a.Name == "G.E.M.邓紫棋"),AlbumArtUrl="" },
                new Album() { Title = "穿越火线",Genre=genres.Single(a=>a.Name == "拉丁"),Artist = artist.Single(a=>a.Name == "G.E.M.邓紫棋"),AlbumArtUrl="" },
                new Album() { Title = "你把我灌醉",Genre=genres.Single(a=>a.Name == "民族"),Artist = artist.Single(a=>a.Name == "G.E.M.邓紫棋"),AlbumArtUrl="" },
                 new Album() { Title = "天真有邪",Genre=genres.Single(a=>a.Name == "华语"),Artist = artist.Single(a=>a.Name == "林宥嘉"),AlbumArtUrl="" },
                new Album() { Title = "残酷月光",Genre=genres.Single(a=>a.Name == "流行"),Artist = artist.Single(a=>a.Name == "林宥嘉"),AlbumArtUrl="" },
                new Album() { Title = "醉赤壁",Genre=genres.Single(a=>a.Name == "怀旧"),Artist = artist.Single(a=>a.Name == "林俊杰"),AlbumArtUrl="" },
                new Album() { Title = "小酒窝",Genre=genres.Single(a=>a.Name == "性感"),Artist = artist.Single(a=>a.Name == "林俊杰"),AlbumArtUrl="" },
                new Album() { Title = "一千年以后",Genre=genres.Single(a=>a.Name == "蓝调"),Artist = artist.Single(a=>a.Name == "林俊杰"),AlbumArtUrl="" },
                new Album() { Title = "盛夏",Genre=genres.Single(a=>a.Name == "拉丁"),Artist = artist.Single(a=>a.Name == "毛不易"),AlbumArtUrl="" },
                new Album() { Title = "如果有一天我变得很有钱",Genre=genres.Single(a=>a.Name == "民族"),Artist = artist.Single(a=>a.Name == "毛不易"),AlbumArtUrl="" },
                new Album() { Title = "感觉自己是巨星",Genre=genres.Single(a=>a.Name == "古典"),Artist = artist.Single(a=>a.Name == "毛不易"),AlbumArtUrl="" },
                new Album() { Title = "一念之间",Genre=genres.Single(a=>a.Name == "轻音乐"),Artist = artist.Single(a=>a.Name == "莫文蔚"),AlbumArtUrl="" },
                new Album() { Title = "一生所爱",Genre=genres.Single(a=>a.Name == "嘻哈"),Artist = artist.Single(a=>a.Name == "莫文蔚"),AlbumArtUrl="" },
                new Album() { Title = "盛夏的果实",Genre=genres.Single(a=>a.Name == "华语"),Artist = artist.Single(a=>a.Name == "莫文蔚"),AlbumArtUrl="" },
                new Album() { Title = "流年",Genre=genres.Single(a=>a.Name == "流行"),Artist = artist.Single(a=>a.Name == "王菲"),AlbumArtUrl="" },
                new Album() { Title = "人间",Genre=genres.Single(a=>a.Name == "怀旧"),Artist = artist.Single(a=>a.Name == "王菲"),AlbumArtUrl="" },
                new Album() { Title = "清风徐来",Genre=genres.Single(a=>a.Name == "性感"),Artist = artist.Single(a=>a.Name == "王菲"),AlbumArtUrl="" },
                new Album() { Title = "泡沫",Genre=genres.Single(a=>a.Name == "蓝调"),Artist = artist.Single(a=>a.Name == "G.E.M.邓紫棋"),AlbumArtUrl="" },
                new Album() { Title = "龙卷风",Genre=genres.Single(a=>a.Name == "拉丁"),Artist = artist.Single(a=>a.Name == "G.E.M.邓紫棋"),AlbumArtUrl="" },
                new Album() { Title = "突然之间",Genre=genres.Single(a=>a.Name == "民族"),Artist = artist.Single(a=>a.Name == "G.E.M.邓紫棋"),AlbumArtUrl="" }
            }.ForEach(n => _dbContext.Albums.Add(n));
            #endregion

            _dbContext.SaveChanges();
        }

        /// <summary>
        /// 赋值GenreID and ArtistID
        /// </summary>
        public static void Extend()
        {
            var album = _dbContext.Albums.ToList();
            foreach (var i in album)
            {
                var item = _dbContext.Albums.Find(i.ID);
                item.GenreID = item.Genre.ID.ToString();
                item.ArtistID = item.Artist.ID.ToString();
                Thread.Sleep(3);
            }
            _dbContext.SaveChanges();
        }
    }
}
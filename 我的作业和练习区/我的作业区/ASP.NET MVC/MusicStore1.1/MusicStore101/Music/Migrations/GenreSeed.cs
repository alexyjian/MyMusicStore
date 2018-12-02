using MusicStoreEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace Music.Migrations
{
    public class GenreSeed
    {
        private static readonly MusicStoreEntity.EntityDbContext _dbContext = new MusicStoreEntity.EntityDbContext();

        public static void Seed()
        {
            var genres = new List<Genre>()
            {
                new Genre() { Name="摇滚",Description="Rock" },
                new Genre() { Name="爵士",Description="Jazz"  },
                new Genre() { Name="重金属",Description="Metal"  },
                new Genre() { Name="慢摇" ,Description="DownTempo" },
                new Genre() { Name="蓝调",Description="Blue"  },
                new Genre() { Name="拉丁" ,Description="Latin" },
                new Genre() { Name="流行",Description="Pop"  },
                new Genre() { Name="古典" ,Description="Classical" },
                new Genre() { Name="DJ",Description="DJ"  },
                new Genre() { Name="嘻哈" ,Description="HiHop" },
            };
            foreach (var g in genres)
            {
                _dbContext.Genres.Add(g);
            }
            var artists = new List<Artist>()
            {
                new Artist() {Name="张惠妹",Sex=false,Description="中国台湾著名女歌手，亚洲流行歌坛重量级天后，台湾原住民歌手。张惠妹于华人世界名气极高，于海外（尤美、日等地）也有一定的知名度，已囊括多项华语圈重要的音乐奖项。也是台湾首位接受美国CNN专访的歌手（并且在2011年第二度接受此媒体《Talk Asia》节目专访）。阿妹在1996年三月被著名台湾音乐人陈志远、陈复明发现并签约丰华唱片。并在同年7月在带自己入行的恩师张雨生的《两伊战争－红色热情》专辑中与张雨生男女对唱《最爱的人伤我最深》。同年12月13日，张惠妹在张雨生的协助下发行第一张个人专辑《姐妹》。1998年 举办第一场个人大型户外售票演唱会“妹力四射”，创下台湾歌手有史以来最快举行大型演唱会的纪录。2009年发行的《阿密特》专辑至今仍是金曲奖史上获得最大成功的作品，曾于第21届时擒下包括专辑、制作人、歌手等六项大奖。代表作品：《姐妹》、《我可以抱你吗》、《记得》、《火》、《如果你也听说》、《掉了》、《我最亲爱的》。" },
                new Artist() {Name="Fine乐团",Sex=true,Description="内地流行乐独立音乐人Fine乐团由一男一女组成。男生冠南创作词曲，女生乔西负责演唱" },
                new Artist() {Name="万晓利",Sex=true,Description="是一位富有浓郁人文色彩的民谣歌手，中国现代民谣的代表人物之一，浮华世界里一位坚定的歌唱者。万晓利给我留下的印象是一把木箱琴和千变万化的人声，后来他出动机的时候，居然拿出一支碗，用勺子在碗边划出丁冬之声，表情是无比虔诚的，效果是出人意料的。 万晓利因其独特的唱腔被观众评为颠覆民谣的歌手。" },
                new Artist() {Name="赵雷",Sex=true,Description="民谣音乐人赵雷，中国内地新生代民谣歌手。1986年7月20日生于北京，高中时间接触音乐，开始学习吉他。年纪轻轻便踏遍祖国的大江南北，山河东西，足迹遍布陕甘、云藏，为自己的音乐之路，积累了大量时代底蕴与人文滋养。赵雷的音乐，虽然没有诗句般的柔情感动，但痞子气的调侃，单纯率直直达你的内心。词作、编曲朴实坦诚以描写生活中细微见长，每一首歌都像一部短剧，折射出他自己的生活、他眼中社会、甚至他心底的梦想，画面感极强。是最具传统北京胡同文化气质的新生代音乐人之一。" },
                new Artist() {Name="王三溥",Sex=true,Description="左手新古典，右手金属，踽踽行于音乐旅途。 微信公众号：王三溥 微博：王三溥" },
                new Artist() {Name="吴莫愁",Sex=false,Description="吴莫愁（MoMo Wu），中国大陆新生代个性女歌手、新女性主义代言人、90后标志性人物。从小跟随父母亲开大篷车唱游全国，2012年凭《中国好声音》上出色表现获得全国总亚军，一举成名。莫愁拥有饱满的情绪、扎实的唱功、新颖的唱法和十足的欧美摇滚范儿，被誉为中国版的“lady gaga”。2012年，与庾澄庆合作单曲《我要给你》，年末获中国魅力50人、亚洲年度新锐歌手、年度艺人、全球最美50新人、年度女性榜样等奖项。" },
                new Artist() {Name="洪启",Sex=true,Description="词曲作家、诗人、歌手。1973年出生于新疆和田，1992年开始音乐创作。他的音乐形式质朴而简单，色彩明亮；题材宽泛，内容涉及社会、人文关怀和爱情。在公益领域，洪启也有一番作为。他的“关注流浪儿童”系列活动成果显著。他被权威乐评人称为“民歌的理想主义者”，他的歌谣被称为“中国流行乐罕见的美丽纯粹民谣”。 曾发表唱片《红雪莲》《阿里木江，你在哪里？》《九棵树》《谁的羊》《黑夜的那颗心》及《洪启自选辑1992--2011》。" },
                new Artist() {Name="李霄云",Sex=true,Description="录音室专辑：《正常人》《房间1501》《你看到的我是蓝色的》 自驾全国旅行创作：《三十禁流浪巡展》 艺术及合作：《虚无-视觉装置展》《恋爱世纪-舞台剧》《STRONG ENGLISH-电台》 Email：michellestudio@163.com" },
                new Artist() {Name="孙楠",Sex=true,Description="内地乐坛实力男歌手。1990年发行首张个人专辑《弯弯的月亮》。1996年1月单曲《红旗飘飘》是孙楠签约海外唱片公司后，向内地歌坛正式推出的第一首作品，一经推出，即产生巨大的轰动。1998年12月录制第五张个人专辑《不见不散》，以一首《不见不散》红遍大江南北。与毛阿敏合作演唱2010年广州第16届亚运会会歌《重逢》。他的代表作品主要有《不见不散》、《风往北吹》、《你快回来》、《红旗飘飘》、《拯救》以及奥运会歌曲《Forever Friends》等。" },
                new Artist() {Name="老狼",Sex=true,Description="中国大陆男歌手，音乐人。于1968年出生于音乐世家，从小就耳濡目染。1989年-1991年 加入中国第一支大学生摇滚乐队“青铜器”担任主唱。1991年—1991大地唱片公司唱片《校园民谣1》的录制，演唱《同桌的你》、《睡在我上铺的兄弟》及《流浪歌手的情人》三首主打歌。1994—1997年 《校园民谣1》发行近六十万张，签约风行音乐工作室。首张个人专辑《恋恋风尘》，专辑发行20天便创下了23万的销售记录，共发行40万张，成为当年中国国内歌手发行量最高的专辑。2000年2月 与华纳唱片签订唱片约，并与“麦田音乐”签订演艺合约。代表作品：《同桌的你》，《恋恋风尘》，《睡在我上铺的兄弟》。" },
            };
            var albums = new List<Album>
            {
                new Album {Title="A",Genre=genres.Single(g=>g.Name=="摇滚"),Price=7.99M,Artist=artists.Single(a=>a.Name=="吴莫愁"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                new Album {Title="B",Genre=genres.Single(g=>g.Name=="摇滚"),Price=9.99M,Artist=artists.Single(a=>a.Name=="张惠妹"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                new Album {Title="C",Genre=genres.Single(g=>g.Name=="爵士"),Price=6.99M,Artist=artists.Single(a=>a.Name=="孙楠"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                new Album {Title="D",Genre=genres.Single(g=>g.Name=="重金属"),Price=5.99M,Artist=artists.Single(a=>a.Name=="万晓利"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                new Album {Title="E",Genre=genres.Single(g=>g.Name=="慢摇"),Price=8.69M,Artist=artists.Single(a=>a.Name=="赵雷"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                new Album {Title="F",Genre=genres.Single(g=>g.Name=="蓝调"),Price=2.99M,Artist=artists.Single(a=>a.Name=="孙楠"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                new Album {Title="G",Genre=genres.Single(g=>g.Name=="拉丁"),Price=3.99M,Artist=artists.Single(a=>a.Name=="Fine乐团"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                new Album {Title="H",Genre=genres.Single(g=>g.Name=="流行"),Price=5.99M,Artist=artists.Single(a=>a.Name=="洪启"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                new Album {Title="I",Genre=genres.Single(g=>g.Name=="古典"),Price=6.99M,Artist=artists.Single(a=>a.Name=="王三溥"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                new Album {Title="J",Genre=genres.Single(g=>g.Name=="DJ"),Price=8.69M,Artist=artists.Single(a=>a.Name=="孙楠"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                new Album {Title="K",Genre=genres.Single(g=>g.Name=="嘻哈"),Price=8.99M,Artist=artists.Single(a=>a.Name=="老狼"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                new Album {Title="L",Genre=genres.Single(g=>g.Name=="流行"),Price=7.99M,Artist=artists.Single(a=>a.Name=="吴莫愁"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                new Album {Title="N",Genre=genres.Single(g=>g.Name=="流行"),Price=5.99M,Artist=artists.Single(a=>a.Name=="王三溥"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                new Album {Title="M",Genre=genres.Single(g=>g.Name=="嘻哈"),Price=8.99M,Artist=artists.Single(a=>a.Name=="老狼"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                new Album {Title="O",Genre=genres.Single(g=>g.Name=="古典"),Price=7.99M,Artist=artists.Single(a=>a.Name=="吴莫愁"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                new Album {Title="P",Genre=genres.Single(g=>g.Name=="爵士"),Price=5.99M,Artist=artists.Single(a=>a.Name=="万晓利"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                new Album {Title="Q",Genre=genres.Single(g=>g.Name=="拉丁"),Price=7.99M,Artist=artists.Single(a=>a.Name=="吴莫愁"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                new Album {Title="R",Genre=genres.Single(g=>g.Name=="DJ"),Price=5.99M,Artist=artists.Single(a=>a.Name=="老狼"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                new Album {Title="S",Genre=genres.Single(g=>g.Name=="DJ"),Price=5.99M,Artist=artists.Single(a=>a.Name=="万晓利"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                new Album {Title="T",Genre=genres.Single(g=>g.Name=="重金属"),Price=5.99M,Artist=artists.Single(a=>a.Name=="老狼"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                new Album {Title="U",Genre=genres.Single(g=>g.Name=="DJ"),Price=5.99M,Artist=artists.Single(a=>a.Name=="张惠妹"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                new Album {Title="V",Genre=genres.Single(g=>g.Name=="DJ"),Price=5.99M,Artist=artists.Single(a=>a.Name=="老狼"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                new Album {Title="W",Genre=genres.Single(g=>g.Name=="拉丁"),Price=5.99M,Artist=artists.Single(a=>a.Name=="孙楠"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                new Album {Title="X",Genre=genres.Single(g=>g.Name=="古典"),Price=7.99M,Artist=artists.Single(a=>a.Name=="吴莫愁"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                new Album {Title="Y",Genre=genres.Single(g=>g.Name=="蓝调"),Price=5.99M,Artist=artists.Single(a=>a.Name=="王三溥"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                new Album {Title="Z",Genre=genres.Single(g=>g.Name=="流行"),Price=5.99M,Artist=artists.Single(a=>a.Name=="Fine乐团"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                new Album {Title="A1",Genre=genres.Single(g=>g.Name=="摇滚"),Price=7.99M,Artist=artists.Single(a=>a.Name=="吴莫愁"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                new Album {Title="B1",Genre=genres.Single(g=>g.Name=="摇滚"),Price=9.99M,Artist=artists.Single(a=>a.Name=="张惠妹"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                new Album {Title="C1",Genre=genres.Single(g=>g.Name=="爵士"),Price=6.99M,Artist=artists.Single(a=>a.Name=="孙楠"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                new Album {Title="D1",Genre=genres.Single(g=>g.Name=="重金属"),Price=5.99M,Artist=artists.Single(a=>a.Name=="万晓利"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                new Album {Title="E1",Genre=genres.Single(g=>g.Name=="慢摇"),Price=8.69M,Artist=artists.Single(a=>a.Name=="赵雷"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                new Album {Title="F1",Genre=genres.Single(g=>g.Name=="蓝调"),Price=2.99M,Artist=artists.Single(a=>a.Name=="孙楠"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                new Album {Title="G1",Genre=genres.Single(g=>g.Name=="拉丁"),Price=3.99M,Artist=artists.Single(a=>a.Name=="Fine乐团"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                new Album {Title="H1",Genre=genres.Single(g=>g.Name=="流行"),Price=5.99M,Artist=artists.Single(a=>a.Name=="洪启"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                new Album {Title="I1",Genre=genres.Single(g=>g.Name=="古典"),Price=6.99M,Artist=artists.Single(a=>a.Name=="王三溥"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                new Album {Title="J1",Genre=genres.Single(g=>g.Name=="DJ"),Price=8.69M,Artist=artists.Single(a=>a.Name=="孙楠"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                new Album {Title="K1",Genre=genres.Single(g=>g.Name=="嘻哈"),Price=8.99M,Artist=artists.Single(a=>a.Name=="老狼"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                new Album {Title="L1",Genre=genres.Single(g=>g.Name=="流行"),Price=7.99M,Artist=artists.Single(a=>a.Name=="吴莫愁"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                new Album {Title="N1",Genre=genres.Single(g=>g.Name=="流行"),Price=5.99M,Artist=artists.Single(a=>a.Name=="王三溥"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                new Album {Title="M1",Genre=genres.Single(g=>g.Name=="嘻哈"),Price=8.99M,Artist=artists.Single(a=>a.Name=="老狼"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                new Album {Title="O1",Genre=genres.Single(g=>g.Name=="古典"),Price=7.99M,Artist=artists.Single(a=>a.Name=="吴莫愁"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                new Album {Title="P1",Genre=genres.Single(g=>g.Name=="爵士"),Price=5.99M,Artist=artists.Single(a=>a.Name=="万晓利"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                new Album {Title="Q1",Genre=genres.Single(g=>g.Name=="拉丁"),Price=7.99M,Artist=artists.Single(a=>a.Name=="吴莫愁"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                new Album {Title="R1",Genre=genres.Single(g=>g.Name=="DJ"),Price=5.99M,Artist=artists.Single(a=>a.Name=="老狼"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                new Album {Title="S1",Genre=genres.Single(g=>g.Name=="DJ"),Price=5.99M,Artist=artists.Single(a=>a.Name=="万晓利"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                new Album {Title="T1",Genre=genres.Single(g=>g.Name=="重金属"),Price=5.99M,Artist=artists.Single(a=>a.Name=="老狼"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                new Album {Title="U1",Genre=genres.Single(g=>g.Name=="DJ"),Price=5.99M,Artist=artists.Single(a=>a.Name=="张惠妹"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                new Album {Title="V1",Genre=genres.Single(g=>g.Name=="DJ"),Price=5.99M,Artist=artists.Single(a=>a.Name=="老狼"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                new Album {Title="W1",Genre=genres.Single(g=>g.Name=="拉丁"),Price=5.99M,Artist=artists.Single(a=>a.Name=="孙楠"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                new Album {Title="X1",Genre=genres.Single(g=>g.Name=="古典"),Price=7.99M,Artist=artists.Single(a=>a.Name=="吴莫愁"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                new Album {Title="Y1",Genre=genres.Single(g=>g.Name=="蓝调"),Price=5.99M,Artist=artists.Single(a=>a.Name=="王三溥"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                new Album {Title="Z1",Genre=genres.Single(g=>g.Name=="流行"),Price=5.99M,Artist=artists.Single(a=>a.Name=="Fine乐团"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                new Album {Title="人质",Genre=genres.Single(g=>g.Name=="流行"),Price=5.99M,Artist=artists.Single(a=>a.Name=="张惠妹"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                new Album {Title="如果你也听说",Genre=genres.Single(g=>g.Name=="流行"),Price=5.99M,Artist=artists.Single(a=>a.Name=="张惠妹"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                new Album {Title="血腥爱情故事",Genre=genres.Single(g=>g.Name=="流行"),Price=5.99M,Artist=artists.Single(a=>a.Name=="张惠妹"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                new Album {Title="听海",Genre=genres.Single(g=>g.Name=="流行"),Price=5.99M,Artist=artists.Single(a=>a.Name=="张惠妹"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                new Album {Title="我可以抱你吗",Genre=genres.Single(g=>g.Name=="流行"),Price=5.99M,Artist=artists.Single(a=>a.Name=="张惠妹"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                new Album {Title="最爱的人伤我最深",Genre=genres.Single(g=>g.Name=="流行"),Price=5.99M,Artist=artists.Single(a=>a.Name=="张惠妹"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                new Album {Title="原来你什么都不想要 ",Genre=genres.Single(g=>g.Name=="流行"),Price=5.99M,Artist=artists.Single(a=>a.Name=="张惠妹"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                new Album {Title="相亲相爱",Genre=genres.Single(g=>g.Name=="流行"),Price=5.99M,Artist=artists.Single(a=>a.Name=="张惠妹"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                new Album {Title="三天三夜",Genre=genres.Single(g=>g.Name=="流行"),Price=5.99M,Artist=artists.Single(a=>a.Name=="张惠妹"),AlbumArtUrl="/Content/Images/placeholder.gif" },
            };
            foreach (var a in artists)
            {
                _dbContext.Artists.Add(a);
            }
            foreach (var a in albums)
            {
                _dbContext.Albums.Add(a);
            }
            _dbContext.SaveChanges();
        }
        public static void Extend()
        {
            var ablums = _dbContext.Albums.ToList();
            foreach(var album in ablums)
            {
                var item = _dbContext.Albums.Find(album.ID);
                item.GenreId = item.Genre.ID.ToString();
                item.ArtistId = item.Artist.ID.ToString();
                Thread.Sleep(5);
            }
        }
    }
}
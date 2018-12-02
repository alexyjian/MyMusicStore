using MusicStoreEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace MusicStore.Migrations
{
    public class GenreSeed
    {
        private static readonly MusicStoreEntity.EntityDbContext _dbContext = new MusicStoreEntity.EntityDbContext();

        public static void Seed()
        {
            _dbContext.Database.ExecuteSqlCommand("delete albums");
            _dbContext.Database.ExecuteSqlCommand("delete artists");
            _dbContext.Database.ExecuteSqlCommand("delete genres");

            var genres = new List<Genre>()
            {
                new Genre() {Name = "摇滚",Description = "Rock" },
                new Genre() {Name = "爵士",Description = "Jazz" },
                new Genre() {Name = "重金属",Description = "Metal" },
                new Genre() {Name = "慢摇",Description = "DownTempo" },
                new Genre() {Name = "蓝调",Description = "Blue" },
                new Genre() {Name = "拉丁",Description = "Latin" },
                new Genre() {Name = "流行",Description = "Pop" },
                new Genre() {Name = "古典",Description = "Classical" },
                new Genre() {Name = "DISCO",Description = "DISCO" },
                new Genre() {Name = "嘻哈",Description = "HiHop" },
            };

            foreach (var g in genres)
                _dbContext.Genres.Add(g);

            var artists = new List<Artist>()
                {
                    new Artist() {Name = "薛之谦",Sex = true,Description = "薛之谦（Joker Xue），1983年7月17日出生于上海，华语流行乐男歌手、影视演员、音乐制作人，毕业于格里昂酒店管理学院。 2005年，参加选秀节目《我型我秀》正式出道 。2006年，发行首张同名专辑《薛之谦》，随后凭借歌曲《认真的雪》获得广泛关注。2008年，发行专辑《深深爱过你》并在上海举行个人首场演唱会“谦年传说” 。2013年，专辑《几个薛之谦》获得MusicRadio中国TOP排行榜内地推荐唱片。2014年，专辑《意外》获得第21届东方风云榜颁奖最佳唱作人 ；2015年6月，薛之谦首度担当制作人并发行原创EP《绅士》，2016年，凭借EP《绅士》、《一半》获得第16届全球华语歌曲排行榜多项奖项，而歌曲《初学者》则获得年度二十大金曲奖。2017年4月，开启“我好像在哪见过你”全国巡回演唱会。" },
                    new Artist() {Name = "华晨宇",Sex = true,Description = "华晨宇，1990年2月7日生于湖北十堰 ，中国男歌手，毕业于武汉音乐学院。 2013年，参加湖南卫视《快乐男声》获年度总冠军出道 。2014年1月，首登央视春晚舞台。9月6日-7日，在北京万事达中心连开两场“火星”演唱会 ，随后首张个人专辑《卡西莫多的礼物》发行 ，并凭此专辑获第十五届音乐风云榜年度最受欢迎男歌手等奖项。同年7月31日—8月2日，2015火星演唱会在上海大舞台连开三场。12月，发行第二张专辑《异类》。 2016年7-9月，2016火星演唱会相继在北上深三个城市举办。9月27日，出席亚洲新歌榜2016年度盛典，揽获最佳男歌手奖。10月，加盟东方卫视《天籁之战》。12月2日，获2016MAMA亚洲最佳艺人奖。2017年3月14日，专辑《H》发行。" },
                    new Artist() {Name = "蔡健雅",Sex = false,Description = "新加坡人，华语著名歌手、词曲作者，音乐制作人。1997年在新加坡由其经纪公司 Music & Movement 旗下的Yellow Music发行英语专辑《Bored》而正式出道，1999年将国语唱片签约于宝丽金唱片旗下，并推出首张国语同名专辑《蔡健雅》。2000年因宝丽金唱片并入环球唱片旗下，因此《记念》及之后的唱片皆由台湾环球唱片发行。在此一专辑中，蔡健雅以〈记念〉一曲成功打响在台湾市场的知名度。同年入围台湾第11届金曲奖最佳新人奖。2002年发行《Secret Lavender》专辑。同年以〈打错了〉作曲者身份入围台湾第13届金曲奖最佳作曲人奖，并同时入围最佳国语演唱人奖。2004年首度担任制作人，替梁咏琪制作《归属感》专辑。同年以《陌生人》获得台湾第15届金曲奖最佳国语女演唱人提名。2008年推出专辑《My Space》，同年获台湾第19届金曲奖7项提名，并获得了最佳专辑制作人和最佳国语女歌手两座大奖。近年移居台湾。2012年获最佳国语女歌手奖。代表作品：《呼吸》《陌生人》《空白格》《若你碰到他》《红色高跟鞋》。" },
                    new Artist() {Name = "陈奕迅",Sex = true,Description = "著名实力派粤语流行音乐歌手、演员，香港演艺人协会副会长之一，曾被美国《时代杂志》形容为影响香港乐坛风格的人物，同时也是继许冠杰、张学友之后第三个获得“歌神”称号的香港男歌手。同时他也是继张学友后另一个在台湾获得成功的香港歌手，在2003年他成为了第二个拿到台湾金曲奖“最佳国语男演唱人”的香港歌手。陈奕迅曾被《时代》杂志形容为影响香港乐坛风格的人物。2010年，陈奕迅入选全球华人音乐殿堂华语金曲奖“30年经典评选”，成为1990年代出道歌手唯一代表。陈奕迅曾在多个亚太地区获得多个奖项和提名，包括香港地区的“叱咤乐坛男歌手金奖”、“叱咤乐坛我最喜爱的男歌手奖”、“十大劲歌金曲最受欢迎男歌星奖”。代表作品：《爱情转移》、《十年》、《浮夸》、《K歌之王》。" },
                    new Artist() {Name = "万晓利",Sex = true,Description = "是一位富有浓郁人文色彩的民谣歌手，中国现代民谣的代表人物之一，浮华世界里一位坚定的歌唱者。万晓利给我留下的印象是一把木箱琴和千变万化的人声，后来他出动机的时候，居然拿出一支碗，用勺子在碗边划出丁冬之声，表情是无比虔诚的，效果是出人意料的。 万晓利因其独特的唱腔被观众评为颠覆民谣的歌手。" },
                    new Artist() {Name = "赵雷",Sex = true,Description = "民谣音乐人赵雷，中国内地新生代民谣歌手。1986年7月20日生于北京，高中时间接触音乐，开始学习吉他。年纪轻轻便踏遍祖国的大江南北，山河东西，足迹遍布陕甘、云藏，为自己的音乐之路，积累了大量时代底蕴与人文滋养。赵雷的音乐，虽然没有诗句般的柔情感动，但痞子气的调侃，单纯率直直达你的内心。词作、编曲朴实坦诚以描写生活中细微见长，每一首歌都像一部短剧，折射出他自己的生活、他眼中社会、甚至他心底的梦想，画面感极强。是最具传统北京胡同文化气质的新生代音乐人之一。" },
                    new Artist() {Name = "王三溥",Sex = true,Description = "左手新古典，右手金属，踽踽行于音乐旅途。 微信公众号：王三溥 微博：王三溥" },
                    new Artist() {Name = "吴莫愁",Sex = false,Description = "吴莫愁（MoMo Wu），中国大陆新生代个性女歌手、新女性主义代言人、90后标志性人物。从小跟随父母亲开大篷车唱游全国，2012年凭《中国好声音》上出色表现获得全国总亚军，一举成名。莫愁拥有饱满的情绪、扎实的唱功、新颖的唱法和十足的欧美摇滚范儿，被誉为中国版的“lady gaga”。2012年，与庾澄庆合作单曲《我要给你》，年末获中国魅力50人、亚洲年度新锐歌手、年度艺人、全球最美50新人、年度女性榜样等奖项。" },
                    new Artist() {Name = "洪启",Sex = true,Description = "词曲作家、诗人、歌手。1973年出生于新疆和田，1992年开始音乐创作。他的音乐形式质朴而简单，色彩明亮；题材宽泛，内容涉及社会、人文关怀和爱情。在公益领域，洪启也有一番作为。他的“关注流浪儿童”系列活动成果显著。他被权威乐评人称为“民歌的理想主义者”，他的歌谣被称为“中国流行乐罕见的美丽纯粹民谣”。 曾发表唱片《红雪莲》《阿里木江，你在哪里？》《九棵树》《谁的羊》《黑夜的那颗心》及《洪启自选辑1992--2011》。" },
                    new Artist() {Name = "孙楠",Sex = true,Description = "内地乐坛实力男歌手。1990年发行首张个人专辑《弯弯的月亮》。1996年1月单曲《红旗飘飘》是孙楠签约海外唱片公司后，向内地歌坛正式推出的第一首作品，一经推出，即产生巨大的轰动。1998年12月录制第五张个人专辑《不见不散》，以一首《不见不散》红遍大江南北。与毛阿敏合作演唱2010年广州第16届亚运会会歌《重逢》。他的代表作品主要有《不见不散》、《风往北吹》、《你快回来》、《红旗飘飘》、《拯救》以及奥运会歌曲《Forever Friends》等。" },
                    new Artist() {Name = "张惠妹", Sex = false, Description = "中国台湾著名女歌手，亚洲流行歌坛重量级天后，台湾原住民歌手。张惠妹于华人世界名气极高，于海外（尤美、日等地）也有一定的知名度，已囊括多项华语圈重要的音乐奖项。也是台湾首位接受美国CNN专访的歌手（并且在2011年第二度接受此媒体《Talk Asia》节目专访）。阿妹在1996年三月被著名台湾音乐人陈志远、陈复明发现并签约丰华唱片。并在同年7月在带自己入行的恩师张雨生的《两伊战争－红色热情》专辑中与张雨生男女对唱《最爱的人伤我最深》。同年12月13日，张惠妹在张雨生的协助下发行第一张个人专辑《姐妹》。1998年 举办第一场个人大型户外售票演唱会“妹力四射”，创下台湾歌手有史以来最快举行大型演唱会的纪录。2009年发行的《阿密特》专辑至今仍是金曲奖史上获得最大成功的作品，曾于第21届时擒下包括专辑、制作人、歌手等六项大奖。代表作品：《姐妹》、《我可以抱你吗》、《记得》、《火》、《如果你也听说》、《掉了》、《我最亲爱的》。"},
                    new Artist() {Name = "王以太", Sex = false, Description = "中国台湾著名女歌手，亚洲流行歌坛重量级天后，台湾原住民歌手。张惠妹于华人世界名气极高，于海外（尤美、日等地）也有一定的知名度，已囊括多项华语圈重要的音乐奖项。也是台湾首位接受美国CNN专访的歌手（并且在2011年第二度接受此媒体《Talk Asia》节目专访）。阿妹在1996年三月被著名台湾音乐人陈志远、陈复明发现并签约丰华唱片。并在同年7月在带自己入行的恩师张雨生的《两伊战争－红色热情》专辑中与张雨生男女对唱《最爱的人伤我最深》。同年12月13日，张惠妹在张雨生的协助下发行第一张个人专辑《姐妹》。1998年 举办第一场个人大型户外售票演唱会“妹力四射”，创下台湾歌手有史以来最快举行大型演唱会的纪录。2009年发行的《阿密特》专辑至今仍是金曲奖史上获得最大成功的作品，曾于第21届时擒下包括专辑、制作人、歌手等六项大奖。代表作品：《姐妹》、《我可以抱你吗》、《记得》、《火》、《如果你也听说》、《掉了》、《我最亲爱的》。"},
                    new Artist() {Name = "The Chainsmokers", Sex = false, Description = "中国台湾著名女歌手，亚洲流行歌坛重量级天后，台湾原住民歌手。张惠妹于华人世界名气极高，于海外（尤美、日等地）也有一定的知名度，已囊括多项华语圈重要的音乐奖项。也是台湾首位接受美国CNN专访的歌手（并且在2011年第二度接受此媒体《Talk Asia》节目专访）。阿妹在1996年三月被著名台湾音乐人陈志远、陈复明发现并签约丰华唱片。并在同年7月在带自己入行的恩师张雨生的《两伊战争－红色热情》专辑中与张雨生男女对唱《最爱的人伤我最深》。同年12月13日，张惠妹在张雨生的协助下发行第一张个人专辑《姐妹》。1998年 举办第一场个人大型户外售票演唱会“妹力四射”，创下台湾歌手有史以来最快举行大型演唱会的纪录。2009年发行的《阿密特》专辑至今仍是金曲奖史上获得最大成功的作品，曾于第21届时擒下包括专辑、制作人、歌手等六项大奖。代表作品：《姐妹》、《我可以抱你吗》、《记得》、《火》、《如果你也听说》、《掉了》、《我最亲爱的》。"},
                    new Artist() {Name = "S.H.E", Sex = false, Description = "中国台湾著名女歌手，亚洲流行歌坛重量级天后，台湾原住民歌手。张惠妹于华人世界名气极高，于海外（尤美、日等地）也有一定的知名度，已囊括多项华语圈重要的音乐奖项。也是台湾首位接受美国CNN专访的歌手（并且在2011年第二度接受此媒体《Talk Asia》节目专访）。阿妹在1996年三月被著名台湾音乐人陈志远、陈复明发现并签约丰华唱片。并在同年7月在带自己入行的恩师张雨生的《两伊战争－红色热情》专辑中与张雨生男女对唱《最爱的人伤我最深》。同年12月13日，张惠妹在张雨生的协助下发行第一张个人专辑《姐妹》。1998年 举办第一场个人大型户外售票演唱会“妹力四射”，创下台湾歌手有史以来最快举行大型演唱会的纪录。2009年发行的《阿密特》专辑至今仍是金曲奖史上获得最大成功的作品，曾于第21届时擒下包括专辑、制作人、歌手等六项大奖。代表作品：《姐妹》、《我可以抱你吗》、《记得》、《火》、《如果你也听说》、《掉了》、《我最亲爱的》。"},
                    new Artist() {Name = "张国荣", Sex = true, Description = "中国台湾著名女歌手，亚洲流行歌坛重量级天后，台湾原住民歌手。张惠妹于华人世界名气极高，于海外（尤美、日等地）也有一定的知名度，已囊括多项华语圈重要的音乐奖项。也是台湾首位接受美国CNN专访的歌手（并且在2011年第二度接受此媒体《Talk Asia》节目专访）。阿妹在1996年三月被著名台湾音乐人陈志远、陈复明发现并签约丰华唱片。并在同年7月在带自己入行的恩师张雨生的《两伊战争－红色热情》专辑中与张雨生男女对唱《最爱的人伤我最深》。同年12月13日，张惠妹在张雨生的协助下发行第一张个人专辑《姐妹》。1998年 举办第一场个人大型户外售票演唱会“妹力四射”，创下台湾歌手有史以来最快举行大型演唱会的纪录。2009年发行的《阿密特》专辑至今仍是金曲奖史上获得最大成功的作品，曾于第21届时擒下包括专辑、制作人、歌手等六项大奖。代表作品：《姐妹》、《我可以抱你吗》、《记得》、《火》、《如果你也听说》、《掉了》、《我最亲爱的》。"},
                    new Artist() {Name = "周杰伦", Sex = true, Description = "中国台湾著名女歌手，亚洲流行歌坛重量级天后，台湾原住民歌手。张惠妹于华人世界名气极高，于海外（尤美、日等地）也有一定的知名度，已囊括多项华语圈重要的音乐奖项。也是台湾首位接受美国CNN专访的歌手（并且在2011年第二度接受此媒体《Talk Asia》节目专访）。阿妹在1996年三月被著名台湾音乐人陈志远、陈复明发现并签约丰华唱片。并在同年7月在带自己入行的恩师张雨生的《两伊战争－红色热情》专辑中与张雨生男女对唱《最爱的人伤我最深》。同年12月13日，张惠妹在张雨生的协助下发行第一张个人专辑《姐妹》。1998年 举办第一场个人大型户外售票演唱会“妹力四射”，创下台湾歌手有史以来最快举行大型演唱会的纪录。2009年发行的《阿密特》专辑至今仍是金曲奖史上获得最大成功的作品，曾于第21届时擒下包括专辑、制作人、歌手等六项大奖。代表作品：《姐妹》、《我可以抱你吗》、《记得》、《火》、《如果你也听说》、《掉了》、《我最亲爱的》。"},
                    new Artist() {Name = "徐秉龙", Sex = true, Description = "中国台湾著名女歌手，亚洲流行歌坛重量级天后，台湾原住民歌手。张惠妹于华人世界名气极高，于海外（尤美、日等地）也有一定的知名度，已囊括多项华语圈重要的音乐奖项。也是台湾首位接受美国CNN专访的歌手（并且在2011年第二度接受此媒体《Talk Asia》节目专访）。阿妹在1996年三月被著名台湾音乐人陈志远、陈复明发现并签约丰华唱片。并在同年7月在带自己入行的恩师张雨生的《两伊战争－红色热情》专辑中与张雨生男女对唱《最爱的人伤我最深》。同年12月13日，张惠妹在张雨生的协助下发行第一张个人专辑《姐妹》。1998年 举办第一场个人大型户外售票演唱会“妹力四射”，创下台湾歌手有史以来最快举行大型演唱会的纪录。2009年发行的《阿密特》专辑至今仍是金曲奖史上获得最大成功的作品，曾于第21届时擒下包括专辑、制作人、歌手等六项大奖。代表作品：《姐妹》、《我可以抱你吗》、《记得》、《火》、《如果你也听说》、《掉了》、《我最亲爱的》。"},
                    new Artist() {Name = "毛不易", Sex = true, Description = "中国台湾著名女歌手，亚洲流行歌坛重量级天后，台湾原住民歌手。张惠妹于华人世界名气极高，于海外（尤美、日等地）也有一定的知名度，已囊括多项华语圈重要的音乐奖项。也是台湾首位接受美国CNN专访的歌手（并且在2011年第二度接受此媒体《Talk Asia》节目专访）。阿妹在1996年三月被著名台湾音乐人陈志远、陈复明发现并签约丰华唱片。并在同年7月在带自己入行的恩师张雨生的《两伊战争－红色热情》专辑中与张雨生男女对唱《最爱的人伤我最深》。同年12月13日，张惠妹在张雨生的协助下发行第一张个人专辑《姐妹》。1998年 举办第一场个人大型户外售票演唱会“妹力四射”，创下台湾歌手有史以来最快举行大型演唱会的纪录。2009年发行的《阿密特》专辑至今仍是金曲奖史上获得最大成功的作品，曾于第21届时擒下包括专辑、制作人、歌手等六项大奖。代表作品：《姐妹》、《我可以抱你吗》、《记得》、《火》、《如果你也听说》、《掉了》、《我最亲爱的》。"},
                    new Artist() {Name = "房东的猫", Sex = false, Description = "中国台湾著名女歌手，亚洲流行歌坛重量级天后，台湾原住民歌手。张惠妹于华人世界名气极高，于海外（尤美、日等地）也有一定的知名度，已囊括多项华语圈重要的音乐奖项。也是台湾首位接受美国CNN专访的歌手（并且在2011年第二度接受此媒体《Talk Asia》节目专访）。阿妹在1996年三月被著名台湾音乐人陈志远、陈复明发现并签约丰华唱片。并在同年7月在带自己入行的恩师张雨生的《两伊战争－红色热情》专辑中与张雨生男女对唱《最爱的人伤我最深》。同年12月13日，张惠妹在张雨生的协助下发行第一张个人专辑《姐妹》。1998年 举办第一场个人大型户外售票演唱会“妹力四射”，创下台湾歌手有史以来最快举行大型演唱会的纪录。2009年发行的《阿密特》专辑至今仍是金曲奖史上获得最大成功的作品，曾于第21届时擒下包括专辑、制作人、歌手等六项大奖。代表作品：《姐妹》、《我可以抱你吗》、《记得》、《火》、《如果你也听说》、《掉了》、《我最亲爱的》。"},
                    new Artist() {Name = "艾热", Sex = false, Description = "中国台湾著名女歌手，亚洲流行歌坛重量级天后，台湾原住民歌手。张惠妹于华人世界名气极高，于海外（尤美、日等地）也有一定的知名度，已囊括多项华语圈重要的音乐奖项。也是台湾首位接受美国CNN专访的歌手（并且在2011年第二度接受此媒体《Talk Asia》节目专访）。阿妹在1996年三月被著名台湾音乐人陈志远、陈复明发现并签约丰华唱片。并在同年7月在带自己入行的恩师张雨生的《两伊战争－红色热情》专辑中与张雨生男女对唱《最爱的人伤我最深》。同年12月13日，张惠妹在张雨生的协助下发行第一张个人专辑《姐妹》。1998年 举办第一场个人大型户外售票演唱会“妹力四射”，创下台湾歌手有史以来最快举行大型演唱会的纪录。2009年发行的《阿密特》专辑至今仍是金曲奖史上获得最大成功的作品，曾于第21届时擒下包括专辑、制作人、歌手等六项大奖。代表作品：《姐妹》、《我可以抱你吗》、《记得》、《火》、《如果你也听说》、《掉了》、《我最亲爱的》。"},
                    new Artist() {Name = "Charlie Puth", Sex = false, Description = "中国台湾著名女歌手，亚洲流行歌坛重量级天后，台湾原住民歌手。张惠妹于华人世界名气极高，于海外（尤美、日等地）也有一定的知名度，已囊括多项华语圈重要的音乐奖项。也是台湾首位接受美国CNN专访的歌手（并且在2011年第二度接受此媒体《Talk Asia》节目专访）。阿妹在1996年三月被著名台湾音乐人陈志远、陈复明发现并签约丰华唱片。并在同年7月在带自己入行的恩师张雨生的《两伊战争－红色热情》专辑中与张雨生男女对唱《最爱的人伤我最深》。同年12月13日，张惠妹在张雨生的协助下发行第一张个人专辑《姐妹》。1998年 举办第一场个人大型户外售票演唱会“妹力四射”，创下台湾歌手有史以来最快举行大型演唱会的纪录。2009年发行的《阿密特》专辑至今仍是金曲奖史上获得最大成功的作品，曾于第21届时擒下包括专辑、制作人、歌手等六项大奖。代表作品：《姐妹》、《我可以抱你吗》、《记得》、《火》、《如果你也听说》、《掉了》、《我最亲爱的》。"},
                    new Artist() {Name = "许嵩", Sex = true, Description = "中国台湾著名女歌手，亚洲流行歌坛重量级天后，台湾原住民歌手。张惠妹于华人世界名气极高，于海外（尤美、日等地）也有一定的知名度，已囊括多项华语圈重要的音乐奖项。也是台湾首位接受美国CNN专访的歌手（并且在2011年第二度接受此媒体《Talk Asia》节目专访）。阿妹在1996年三月被著名台湾音乐人陈志远、陈复明发现并签约丰华唱片。并在同年7月在带自己入行的恩师张雨生的《两伊战争－红色热情》专辑中与张雨生男女对唱《最爱的人伤我最深》。同年12月13日，张惠妹在张雨生的协助下发行第一张个人专辑《姐妹》。1998年 举办第一场个人大型户外售票演唱会“妹力四射”，创下台湾歌手有史以来最快举行大型演唱会的纪录。2009年发行的《阿密特》专辑至今仍是金曲奖史上获得最大成功的作品，曾于第21届时擒下包括专辑、制作人、歌手等六项大奖。代表作品：《姐妹》、《我可以抱你吗》、《记得》、《火》、《如果你也听说》、《掉了》、《我最亲爱的》。"},
                    new Artist() {Name = "王力宏", Sex = true, Description = "中国台湾著名女歌手，亚洲流行歌坛重量级天后，台湾原住民歌手。张惠妹于华人世界名气极高，于海外（尤美、日等地）也有一定的知名度，已囊括多项华语圈重要的音乐奖项。也是台湾首位接受美国CNN专访的歌手（并且在2011年第二度接受此媒体《Talk Asia》节目专访）。阿妹在1996年三月被著名台湾音乐人陈志远、陈复明发现并签约丰华唱片。并在同年7月在带自己入行的恩师张雨生的《两伊战争－红色热情》专辑中与张雨生男女对唱《最爱的人伤我最深》。同年12月13日，张惠妹在张雨生的协助下发行第一张个人专辑《姐妹》。1998年 举办第一场个人大型户外售票演唱会“妹力四射”，创下台湾歌手有史以来最快举行大型演唱会的纪录。2009年发行的《阿密特》专辑至今仍是金曲奖史上获得最大成功的作品，曾于第21届时擒下包括专辑、制作人、歌手等六项大奖。代表作品：《姐妹》、《我可以抱你吗》、《记得》、《火》、《如果你也听说》、《掉了》、《我最亲爱的》。"},
                    new Artist() {Name = "张学友", Sex = true, Description = "中国台湾著名女歌手，亚洲流行歌坛重量级天后，台湾原住民歌手。张惠妹于华人世界名气极高，于海外（尤美、日等地）也有一定的知名度，已囊括多项华语圈重要的音乐奖项。也是台湾首位接受美国CNN专访的歌手（并且在2011年第二度接受此媒体《Talk Asia》节目专访）。阿妹在1996年三月被著名台湾音乐人陈志远、陈复明发现并签约丰华唱片。并在同年7月在带自己入行的恩师张雨生的《两伊战争－红色热情》专辑中与张雨生男女对唱《最爱的人伤我最深》。同年12月13日，张惠妹在张雨生的协助下发行第一张个人专辑《姐妹》。1998年 举办第一场个人大型户外售票演唱会“妹力四射”，创下台湾歌手有史以来最快举行大型演唱会的纪录。2009年发行的《阿密特》专辑至今仍是金曲奖史上获得最大成功的作品，曾于第21届时擒下包括专辑、制作人、歌手等六项大奖。代表作品：《姐妹》、《我可以抱你吗》、《记得》、《火》、《如果你也听说》、《掉了》、《我最亲爱的》。"},
                    new Artist() {Name = "Coldplay", Sex = false, Description = "中国台湾著名女歌手，亚洲流行歌坛重量级天后，台湾原住民歌手。张惠妹于华人世界名气极高，于海外（尤美、日等地）也有一定的知名度，已囊括多项华语圈重要的音乐奖项。也是台湾首位接受美国CNN专访的歌手（并且在2011年第二度接受此媒体《Talk Asia》节目专访）。阿妹在1996年三月被著名台湾音乐人陈志远、陈复明发现并签约丰华唱片。并在同年7月在带自己入行的恩师张雨生的《两伊战争－红色热情》专辑中与张雨生男女对唱《最爱的人伤我最深》。同年12月13日，张惠妹在张雨生的协助下发行第一张个人专辑《姐妹》。1998年 举办第一场个人大型户外售票演唱会“妹力四射”，创下台湾歌手有史以来最快举行大型演唱会的纪录。2009年发行的《阿密特》专辑至今仍是金曲奖史上获得最大成功的作品，曾于第21届时擒下包括专辑、制作人、歌手等六项大奖。代表作品：《姐妹》、《我可以抱你吗》、《记得》、《火》、《如果你也听说》、《掉了》、《我最亲爱的》。"},
                    new Artist() {Name = "莫文蔚", Sex = true, Description = "中国台湾著名女歌手，亚洲流行歌坛重量级天后，台湾原住民歌手。张惠妹于华人世界名气极高，于海外（尤美、日等地）也有一定的知名度，已囊括多项华语圈重要的音乐奖项。也是台湾首位接受美国CNN专访的歌手（并且在2011年第二度接受此媒体《Talk Asia》节目专访）。阿妹在1996年三月被著名台湾音乐人陈志远、陈复明发现并签约丰华唱片。并在同年7月在带自己入行的恩师张雨生的《两伊战争－红色热情》专辑中与张雨生男女对唱《最爱的人伤我最深》。同年12月13日，张惠妹在张雨生的协助下发行第一张个人专辑《姐妹》。1998年 举办第一场个人大型户外售票演唱会“妹力四射”，创下台湾歌手有史以来最快举行大型演唱会的纪录。2009年发行的《阿密特》专辑至今仍是金曲奖史上获得最大成功的作品，曾于第21届时擒下包括专辑、制作人、歌手等六项大奖。代表作品：《姐妹》、《我可以抱你吗》、《记得》、《火》、《如果你也听说》、《掉了》、《我最亲爱的》。"},
                    new Artist() {Name = "Justin Bieber", Sex = true, Description = "中国台湾著名女歌手，亚洲流行歌坛重量级天后，台湾原住民歌手。张惠妹于华人世界名气极高，于海外（尤美、日等地）也有一定的知名度，已囊括多项华语圈重要的音乐奖项。也是台湾首位接受美国CNN专访的歌手（并且在2011年第二度接受此媒体《Talk Asia》节目专访）。阿妹在1996年三月被著名台湾音乐人陈志远、陈复明发现并签约丰华唱片。并在同年7月在带自己入行的恩师张雨生的《两伊战争－红色热情》专辑中与张雨生男女对唱《最爱的人伤我最深》。同年12月13日，张惠妹在张雨生的协助下发行第一张个人专辑《姐妹》。1998年 举办第一场个人大型户外售票演唱会“妹力四射”，创下台湾歌手有史以来最快举行大型演唱会的纪录。2009年发行的《阿密特》专辑至今仍是金曲奖史上获得最大成功的作品，曾于第21届时擒下包括专辑、制作人、歌手等六项大奖。代表作品：《姐妹》、《我可以抱你吗》、《记得》、《火》、《如果你也听说》、《掉了》、《我最亲爱的》。"},
                    new Artist() {Name = "王菲", Sex = false, Description = "中国台湾著名女歌手，亚洲流行歌坛重量级天后，台湾原住民歌手。张惠妹于华人世界名气极高，于海外（尤美、日等地）也有一定的知名度，已囊括多项华语圈重要的音乐奖项。也是台湾首位接受美国CNN专访的歌手（并且在2011年第二度接受此媒体《Talk Asia》节目专访）。阿妹在1996年三月被著名台湾音乐人陈志远、陈复明发现并签约丰华唱片。并在同年7月在带自己入行的恩师张雨生的《两伊战争－红色热情》专辑中与张雨生男女对唱《最爱的人伤我最深》。同年12月13日，张惠妹在张雨生的协助下发行第一张个人专辑《姐妹》。1998年 举办第一场个人大型户外售票演唱会“妹力四射”，创下台湾歌手有史以来最快举行大型演唱会的纪录。2009年发行的《阿密特》专辑至今仍是金曲奖史上获得最大成功的作品，曾于第21届时擒下包括专辑、制作人、歌手等六项大奖。代表作品：《姐妹》、《我可以抱你吗》、《记得》、《火》、《如果你也听说》、《掉了》、《我最亲爱的》。"},
                    new Artist() {Name = "张震岳", Sex = true, Description = "中国台湾著名女歌手，亚洲流行歌坛重量级天后，台湾原住民歌手。张惠妹于华人世界名气极高，于海外（尤美、日等地）也有一定的知名度，已囊括多项华语圈重要的音乐奖项。也是台湾首位接受美国CNN专访的歌手（并且在2011年第二度接受此媒体《Talk Asia》节目专访）。阿妹在1996年三月被著名台湾音乐人陈志远、陈复明发现并签约丰华唱片。并在同年7月在带自己入行的恩师张雨生的《两伊战争－红色热情》专辑中与张雨生男女对唱《最爱的人伤我最深》。同年12月13日，张惠妹在张雨生的协助下发行第一张个人专辑《姐妹》。1998年 举办第一场个人大型户外售票演唱会“妹力四射”，创下台湾歌手有史以来最快举行大型演唱会的纪录。2009年发行的《阿密特》专辑至今仍是金曲奖史上获得最大成功的作品，曾于第21届时擒下包括专辑、制作人、歌手等六项大奖。代表作品：《姐妹》、《我可以抱你吗》、《记得》、《火》、《如果你也听说》、《掉了》、《我最亲爱的》。"},
                    new Artist() {Name = "胡彦斌", Sex = true, Description = "中国台湾著名女歌手，亚洲流行歌坛重量级天后，台湾原住民歌手。张惠妹于华人世界名气极高，于海外（尤美、日等地）也有一定的知名度，已囊括多项华语圈重要的音乐奖项。也是台湾首位接受美国CNN专访的歌手（并且在2011年第二度接受此媒体《Talk Asia》节目专访）。阿妹在1996年三月被著名台湾音乐人陈志远、陈复明发现并签约丰华唱片。并在同年7月在带自己入行的恩师张雨生的《两伊战争－红色热情》专辑中与张雨生男女对唱《最爱的人伤我最深》。同年12月13日，张惠妹在张雨生的协助下发行第一张个人专辑《姐妹》。1998年 举办第一场个人大型户外售票演唱会“妹力四射”，创下台湾歌手有史以来最快举行大型演唱会的纪录。2009年发行的《阿密特》专辑至今仍是金曲奖史上获得最大成功的作品，曾于第21届时擒下包括专辑、制作人、歌手等六项大奖。代表作品：《姐妹》、《我可以抱你吗》、《记得》、《火》、《如果你也听说》、《掉了》、《我最亲爱的》。"},
                };
            foreach (var a in artists)
                _dbContext.Artists.Add(a);
            _dbContext.SaveChanges();

            //使用Lamda代替foreach
            new List<Album>
            {
                new Album
                {
                    Title = "The Best Of Men At Work", Genre = genres.Single(g => g.Name == "摇滚"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "蔡健雅"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "A Copland Celebration, Vol. I", Genre = genres.Single(g => g.Name == "古典"),
                    Price = 8.99M, Artist = artists.Single(a => a.Name == "蔡健雅"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Worlds", Genre = genres.Single(g => g.Name == "爵士"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "蔡健雅"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "For Those About To Rock We Salute You", Genre = genres.Single(g => g.Name == "摇滚"),
                    Price = 8.99M, Artist = artists.Single(a => a.Name == "蔡健雅"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Let There Be 摇滚", Genre = genres.Single(g => g.Name == "摇滚"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "张惠妹"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Balls to the Wall", Genre = genres.Single(g => g.Name == "摇滚"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "张惠妹"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Restless and Wild", Genre = genres.Single(g => g.Name == "摇滚"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "张惠妹"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Górecki: Symphony No. 3", Genre = genres.Single(g => g.Name == "古典"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "王以太"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Big Ones", Genre = genres.Single(g => g.Name == "摇滚"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "The Chainsmokers"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Quiet Songs", Genre = genres.Single(g => g.Name == "爵士"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "The Chainsmokers"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Jagged Little Pill", Genre = genres.Single(g => g.Name == "摇滚"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "The Chainsmokers"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Facelift", Genre = genres.Single(g => g.Name == "摇滚"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "The Chainsmokers"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Frank", Genre = genres.Single(g => g.Name == "流行"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "王力宏"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Ring My Bell", Genre = genres.Single(g => g.Name == "DISCO"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "王力宏"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Chill: Brazil (Disc 2)", Genre = genres.Single(g => g.Name == "拉丁"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "王力宏"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Warner 25 Anos", Genre = genres.Single(g => g.Name == "爵士"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "王力宏"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Plays Metallica By Four Cellos", Genre = genres.Single(g => g.Name == "重金属"),
                    Price = 8.99M, Artist = artists.Single(a => a.Name == "王菲"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Revelations", Genre = genres.Single(g => g.Name == "流行"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "王菲"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Audioslave", Genre = genres.Single(g => g.Name == "摇滚"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "王菲"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "The Last Night of the Proms", Genre = genres.Single(g => g.Name == "古典"),
                    Price = 8.99M, Artist = artists.Single(a => a.Name == "王菲"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Sibelius: Finlandia", Genre = genres.Single(g => g.Name == "古典"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "张国荣"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Mozart: Symphonies Nos. 40 & 41", Genre = genres.Single(g => g.Name == "古典"),
                    Price = 8.99M, Artist = artists.Single(a => a.Name == "陈奕迅"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "The Best Of Billy Cobham", Genre = genres.Single(g => g.Name == "爵士"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "陈奕迅"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Alcohol Fueled Brewtality Live! [Disc 1]", Genre = genres.Single(g => g.Name == "重金属"),
                    Price = 8.99M, Artist = artists.Single(a => a.Name == "张国荣"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Alcohol Fueled Brewtality Live! [Disc 2]", Genre = genres.Single(g => g.Name == "重金属"),
                    Price = 8.99M, Artist = artists.Single(a => a.Name == "陈奕迅"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "胡彦斌 Vol. 4 (Remaster)", Genre = genres.Single(g => g.Name == "重金属"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "胡彦斌"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "胡彦斌", Genre = genres.Single(g => g.Name == "重金属"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "胡彦斌"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Carmina Burana", Genre = genres.Single(g => g.Name == "古典"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Charlie Puth"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "A Soprano Inspired", Genre = genres.Single(g => g.Name == "古典"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Charlie Puth"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Chemical Wedding", Genre = genres.Single(g => g.Name == "重金属"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "张学友"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Prenda Minha", Genre = genres.Single(g => g.Name == "拉丁"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Charlie Puth"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Sozinho Remix Ao Vivo", Genre = genres.Single(g => g.Name == "拉丁"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "张学友"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Cake: B-Sides and Rarities", Genre = genres.Single(g => g.Name == "流行"),
                    Price = 8.99M, Artist = artists.Single(a => a.Name == "Justin Bieber"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Carried to Dust (Bonus Track Version)",
                    Genre = genres.Single(g => g.Name == "流行"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Justin Bieber"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Cássia Eller - Sem Limite [Disc 1]", Genre = genres.Single(g => g.Name == "拉丁"),
                    Price = 8.99M, Artist = artists.Single(a => a.Name == "Justin Bieber"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Le Freak", Genre = genres.Single(g => g.Name == "DISCO"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Justin Bieber"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Scheherazade", Genre = genres.Single(g => g.Name == "古典"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Justin Bieber"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Minha Historia", Genre = genres.Single(g => g.Name == "拉丁"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "张学友"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Afrociberdelia", Genre = genres.Single(g => g.Name == "嘻哈"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Justin Bieber"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Da Lama Ao Caos", Genre = genres.Single(g => g.Name == "拉丁"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Justin Bieber"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Carry On", Genre = genres.Single(g => g.Name == "流行"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "张学友"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "SCRIABIN: Vers la flamme", Genre = genres.Single(g => g.Name == "蓝调"),
                    Price = 8.99M, Artist = artists.Single(a => a.Name == "Justin Bieber"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
            }.ForEach(n => _dbContext.Albums.Add(n));
            _dbContext.SaveChanges();
        }

        //给GenreId和ArtistId赋值
        public static void Extend()
        {
            var albums = _dbContext.Albums.ToList();
            foreach (var album in albums)
            {
                var item = _dbContext.Albums.Find(album.ID);
                item.GenreId = item.Genre.ID.ToString();
                item.ArtistId = item.Artist.ID.ToString();
                _dbContext.SaveChanges();
                Thread.Sleep(3);
            }
        }
    }
}
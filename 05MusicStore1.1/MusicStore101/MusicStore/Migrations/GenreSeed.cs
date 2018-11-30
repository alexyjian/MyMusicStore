using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MusicStoreEntity;
using System.Threading;

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
                new Genre() {Name = "摇滚",Description = "Rock"},
                new Genre() {Name =  "爵士",Description = "Jazz"},
                new Genre() {Name =  "重金属",Description = "重金属"},
                new Genre() {Name =  "慢摇",Description = "DownTempo"},
                new Genre() {Name =  "蓝调",Description = "Blue"},
                new Genre() {Name =  "拉丁",Description = "Latin"},
                new Genre() {Name =  "流行",Description = "Pop"},
                new Genre() {Name =  "古典",Description = "Classical"},
                new Genre() {Name =  "DISCO",Description = "DISCO"},
                new Genre() {Name =  "嘻哈",Description = "HiHop"},
            };
            foreach ( var g  in genres)
                _dbContext.Genres.Add(g);

            var artists = new List<Artist>()
            {
                new Artist() {Name = "蔡健雅", Sex = false, Description = "新加坡人，华语著名歌手、词曲作者，音乐制作人。1997年在新加坡由其经纪公司 Music & Movement 旗下的Yellow Music发行英语专辑《Bored》而正式出道，1999年将国语唱片签约于宝丽金唱片旗下，并推出首张国语同名专辑《蔡健雅》。2000年因宝丽金唱片并入环球唱片旗下，因此《记念》及之后的唱片皆由台湾环球唱片发行。在此一专辑中，蔡健雅以〈记念〉一曲成功打响在台湾市场的知名度。同年入围台湾第11届金曲奖最佳新人奖。2002年发行《Secret Lavender》专辑。同年以〈打错了〉作曲者身份入围台湾第13届金曲奖最佳作曲人奖，并同时入围最佳国语演唱人奖。2004年首度担任制作人，替梁咏琪制作《归属感》专辑。同年以《陌生人》获得台湾第15届金曲奖最佳国语女演唱人提名。2008年推出专辑《My Space》，同年获台湾第19届金曲奖7项提名，并获得了最佳专辑制作人和最佳国语女歌手两座大奖。近年移居台湾。2012年获最佳国语女歌手奖。代表作品：《呼吸》《陌生人》《空白格》《若你碰到他》《红色高跟鞋》。"},
                new Artist() {Name = "张惠妹", Sex = false, Description = "中国台湾著名女歌手，亚洲流行歌坛重量级天后，台湾原住民歌手。张惠妹于华人世界名气极高，于海外（尤美、日等地）也有一定的知名度，已囊括多项华语圈重要的音乐奖项。也是台湾首位接受美国CNN专访的歌手（并且在2011年第二度接受此媒体《Talk Asia》节目专访）。阿妹在1996年三月被著名台湾音乐人陈志远、陈复明发现并签约丰华唱片。并在同年7月在带自己入行的恩师张雨生的《两伊战争－红色热情》专辑中与张雨生男女对唱《最爱的人伤我最深》。同年12月13日，张惠妹在张雨生的协助下发行第一张个人专辑《姐妹》。1998年 举办第一场个人大型户外售票演唱会“妹力四射”，创下台湾歌手有史以来最快举行大型演唱会的纪录。2009年发行的《阿密特》专辑至今仍是金曲奖史上获得最大成功的作品，曾于第21届时擒下包括专辑、制作人、歌手等六项大奖。代表作品：《姐妹》、《我可以抱你吗》、《记得》、《火》、《如果你也听说》、《掉了》、《我最亲爱的》。"},
                new Artist() {Name = "王以太", Sex = false, Description = "中国台湾著名女歌手，亚洲流行歌坛重量级天后，台湾原住民歌手。张惠妹于华人世界名气极高，于海外（尤美、日等地）也有一定的知名度，已囊括多项华语圈重要的音乐奖项。也是台湾首位接受美国CNN专访的歌手（并且在2011年第二度接受此媒体《Talk Asia》节目专访）。阿妹在1996年三月被著名台湾音乐人陈志远、陈复明发现并签约丰华唱片。并在同年7月在带自己入行的恩师张雨生的《两伊战争－红色热情》专辑中与张雨生男女对唱《最爱的人伤我最深》。同年12月13日，张惠妹在张雨生的协助下发行第一张个人专辑《姐妹》。1998年 举办第一场个人大型户外售票演唱会“妹力四射”，创下台湾歌手有史以来最快举行大型演唱会的纪录。2009年发行的《阿密特》专辑至今仍是金曲奖史上获得最大成功的作品，曾于第21届时擒下包括专辑、制作人、歌手等六项大奖。代表作品：《姐妹》、《我可以抱你吗》、《记得》、《火》、《如果你也听说》、《掉了》、《我最亲爱的》。"},
                new Artist() {Name = "The Chainsmokers", Sex = false, Description = "中国台湾著名女歌手，亚洲流行歌坛重量级天后，台湾原住民歌手。张惠妹于华人世界名气极高，于海外（尤美、日等地）也有一定的知名度，已囊括多项华语圈重要的音乐奖项。也是台湾首位接受美国CNN专访的歌手（并且在2011年第二度接受此媒体《Talk Asia》节目专访）。阿妹在1996年三月被著名台湾音乐人陈志远、陈复明发现并签约丰华唱片。并在同年7月在带自己入行的恩师张雨生的《两伊战争－红色热情》专辑中与张雨生男女对唱《最爱的人伤我最深》。同年12月13日，张惠妹在张雨生的协助下发行第一张个人专辑《姐妹》。1998年 举办第一场个人大型户外售票演唱会“妹力四射”，创下台湾歌手有史以来最快举行大型演唱会的纪录。2009年发行的《阿密特》专辑至今仍是金曲奖史上获得最大成功的作品，曾于第21届时擒下包括专辑、制作人、歌手等六项大奖。代表作品：《姐妹》、《我可以抱你吗》、《记得》、《火》、《如果你也听说》、《掉了》、《我最亲爱的》。"},
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
                new Artist() {Name = "S.H.E", Sex = false, Description = "中国台湾著名女歌手，亚洲流行歌坛重量级天后，台湾原住民歌手。张惠妹于华人世界名气极高，于海外（尤美、日等地）也有一定的知名度，已囊括多项华语圈重要的音乐奖项。也是台湾首位接受美国CNN专访的歌手（并且在2011年第二度接受此媒体《Talk Asia》节目专访）。阿妹在1996年三月被著名台湾音乐人陈志远、陈复明发现并签约丰华唱片。并在同年7月在带自己入行的恩师张雨生的《两伊战争－红色热情》专辑中与张雨生男女对唱《最爱的人伤我最深》。同年12月13日，张惠妹在张雨生的协助下发行第一张个人专辑《姐妹》。1998年 举办第一场个人大型户外售票演唱会“妹力四射”，创下台湾歌手有史以来最快举行大型演唱会的纪录。2009年发行的《阿密特》专辑至今仍是金曲奖史上获得最大成功的作品，曾于第21届时擒下包括专辑、制作人、歌手等六项大奖。代表作品：《姐妹》、《我可以抱你吗》、《记得》、《火》、《如果你也听说》、《掉了》、《我最亲爱的》。"},
                new Artist() {Name = "张国荣", Sex = true, Description = "中国台湾著名女歌手，亚洲流行歌坛重量级天后，台湾原住民歌手。张惠妹于华人世界名气极高，于海外（尤美、日等地）也有一定的知名度，已囊括多项华语圈重要的音乐奖项。也是台湾首位接受美国CNN专访的歌手（并且在2011年第二度接受此媒体《Talk Asia》节目专访）。阿妹在1996年三月被著名台湾音乐人陈志远、陈复明发现并签约丰华唱片。并在同年7月在带自己入行的恩师张雨生的《两伊战争－红色热情》专辑中与张雨生男女对唱《最爱的人伤我最深》。同年12月13日，张惠妹在张雨生的协助下发行第一张个人专辑《姐妹》。1998年 举办第一场个人大型户外售票演唱会“妹力四射”，创下台湾歌手有史以来最快举行大型演唱会的纪录。2009年发行的《阿密特》专辑至今仍是金曲奖史上获得最大成功的作品，曾于第21届时擒下包括专辑、制作人、歌手等六项大奖。代表作品：《姐妹》、《我可以抱你吗》、《记得》、《火》、《如果你也听说》、《掉了》、《我最亲爱的》。"},
                new Artist() {Name = "周杰伦", Sex = true, Description = "中国台湾著名女歌手，亚洲流行歌坛重量级天后，台湾原住民歌手。张惠妹于华人世界名气极高，于海外（尤美、日等地）也有一定的知名度，已囊括多项华语圈重要的音乐奖项。也是台湾首位接受美国CNN专访的歌手（并且在2011年第二度接受此媒体《Talk Asia》节目专访）。阿妹在1996年三月被著名台湾音乐人陈志远、陈复明发现并签约丰华唱片。并在同年7月在带自己入行的恩师张雨生的《两伊战争－红色热情》专辑中与张雨生男女对唱《最爱的人伤我最深》。同年12月13日，张惠妹在张雨生的协助下发行第一张个人专辑《姐妹》。1998年 举办第一场个人大型户外售票演唱会“妹力四射”，创下台湾歌手有史以来最快举行大型演唱会的纪录。2009年发行的《阿密特》专辑至今仍是金曲奖史上获得最大成功的作品，曾于第21届时擒下包括专辑、制作人、歌手等六项大奖。代表作品：《姐妹》、《我可以抱你吗》、《记得》、《火》、《如果你也听说》、《掉了》、《我最亲爱的》。"},
                new Artist { Name = "Aaron Copland & London Symphony Orchestra", Sex = true, Description = "中国台湾著名女歌手，亚洲流行歌坛重量级天后，台湾原住民歌手。张惠妹于华人世界名气极高，于海外（尤美、日等地）也有一定的知名度，已囊括多项华语圈重要的音乐奖项。也是台湾首位接受美国CNN专访的歌手（并且在2011年第二度接受此媒体《Talk Asia》节目专访）。阿妹在1996年三月被著名台湾音乐人陈志远、陈复明发现并签约丰华唱片。并在同年7月在带自己入行的恩师张雨生的《两伊战争－红色热情》专辑中与张雨生男女对唱《最爱的人伤我最深》。同年12月13日，张惠妹在张雨生的协助下发行第一张个人专辑《姐妹》。1998年 举办第一场个人大型户外售票演唱会“妹力四射”，创下台湾歌手有史以来最快举行大型演唱会的纪录。2009年发行的《阿密特》专辑至今仍是金曲奖史上获得最大成功的作品，曾于第21届时擒下包括专辑、制作人、歌手等六项大奖。代表作品：《姐妹》、《我可以抱你吗》、《记得》、《火》、《如果你也听说》、《掉了》、《我最亲爱的》。" },
                new Artist { Name = "Aaron Goldberg", Sex = true, Description = "中国台湾著名女歌手，亚洲流行歌坛重量级天后，台湾原住民歌手。张惠妹于华人世界名气极高，于海外（尤美、日等地）也有一定的知名度，已囊括多项华语圈重要的音乐奖项。也是台湾首位接受美国CNN专访的歌手（并且在2011年第二度接受此媒体《Talk Asia》节目专访）。阿妹在1996年三月被著名台湾音乐人陈志远、陈复明发现并签约丰华唱片。并在同年7月在带自己入行的恩师张雨生的《两伊战争－红色热情》专辑中与张雨生男女对唱《最爱的人伤我最深》。同年12月13日，张惠妹在张雨生的协助下发行第一张个人专辑《姐妹》。1998年 举办第一场个人大型户外售票演唱会“妹力四射”，创下台湾歌手有史以来最快举行大型演唱会的纪录。2009年发行的《阿密特》专辑至今仍是金曲奖史上获得最大成功的作品，曾于第21届时擒下包括专辑、制作人、歌手等六项大奖。代表作品：《姐妹》、《我可以抱你吗》、《记得》、《火》、《如果你也听说》、《掉了》、《我最亲爱的》。" },
                new Artist { Name = "AC/DC" , Sex = true, Description = "中国台湾著名女歌手，亚洲流行歌坛重量级天后，台湾原住民歌手。张惠妹于华人世界名气极高，于海外（尤美、日等地）也有一定的知名度，已囊括多项华语圈重要的音乐奖项。也是台湾首位接受美国CNN专访的歌手（并且在2011年第二度接受此媒体《Talk Asia》节目专访）。阿妹在1996年三月被著名台湾音乐人陈志远、陈复明发现并签约丰华唱片。并在同年7月在带自己入行的恩师张雨生的《两伊战争－红色热情》专辑中与张雨生男女对唱《最爱的人伤我最深》。同年12月13日，张惠妹在张雨生的协助下发行第一张个人专辑《姐妹》。1998年 举办第一场个人大型户外售票演唱会“妹力四射”，创下台湾歌手有史以来最快举行大型演唱会的纪录。2009年发行的《阿密特》专辑至今仍是金曲奖史上获得最大成功的作品，曾于第21届时擒下包括专辑、制作人、歌手等六项大奖。代表作品：《姐妹》、《我可以抱你吗》、《记得》、《火》、《如果你也听说》、《掉了》、《我最亲爱的》。"},
                new Artist { Name = "Accept" , Sex = true, Description = "中国台湾著名女歌手，亚洲流行歌坛重量级天后，台湾原住民歌手。张惠妹于华人世界名气极高，于海外（尤美、日等地）也有一定的知名度，已囊括多项华语圈重要的音乐奖项。也是台湾首位接受美国CNN专访的歌手（并且在2011年第二度接受此媒体《Talk Asia》节目专访）。阿妹在1996年三月被著名台湾音乐人陈志远、陈复明发现并签约丰华唱片。并在同年7月在带自己入行的恩师张雨生的《两伊战争－红色热情》专辑中与张雨生男女对唱《最爱的人伤我最深》。同年12月13日，张惠妹在张雨生的协助下发行第一张个人专辑《姐妹》。1998年 举办第一场个人大型户外售票演唱会“妹力四射”，创下台湾歌手有史以来最快举行大型演唱会的纪录。2009年发行的《阿密特》专辑至今仍是金曲奖史上获得最大成功的作品，曾于第21届时擒下包括专辑、制作人、歌手等六项大奖。代表作品：《姐妹》、《我可以抱你吗》、《记得》、《火》、《如果你也听说》、《掉了》、《我最亲爱的》。"},
                new Artist { Name = "Adrian Leaper & Doreen de Feis", Sex = true, Description = "中国台湾著名女歌手，亚洲流行歌坛重量级天后，台湾原住民歌手。张惠妹于华人世界名气极高，于海外（尤美、日等地）也有一定的知名度，已囊括多项华语圈重要的音乐奖项。也是台湾首位接受美国CNN专访的歌手（并且在2011年第二度接受此媒体《Talk Asia》节目专访）。阿妹在1996年三月被著名台湾音乐人陈志远、陈复明发现并签约丰华唱片。并在同年7月在带自己入行的恩师张雨生的《两伊战争－红色热情》专辑中与张雨生男女对唱《最爱的人伤我最深》。同年12月13日，张惠妹在张雨生的协助下发行第一张个人专辑《姐妹》。1998年 举办第一场个人大型户外售票演唱会“妹力四射”，创下台湾歌手有史以来最快举行大型演唱会的纪录。2009年发行的《阿密特》专辑至今仍是金曲奖史上获得最大成功的作品，曾于第21届时擒下包括专辑、制作人、歌手等六项大奖。代表作品：《姐妹》、《我可以抱你吗》、《记得》、《火》、《如果你也听说》、《掉了》、《我最亲爱的》。" },
                new Artist { Name = "Aerosmith" , Sex = true, Description = "中国台湾著名女歌手，亚洲流行歌坛重量级天后，台湾原住民歌手。张惠妹于华人世界名气极高，于海外（尤美、日等地）也有一定的知名度，已囊括多项华语圈重要的音乐奖项。也是台湾首位接受美国CNN专访的歌手（并且在2011年第二度接受此媒体《Talk Asia》节目专访）。阿妹在1996年三月被著名台湾音乐人陈志远、陈复明发现并签约丰华唱片。并在同年7月在带自己入行的恩师张雨生的《两伊战争－红色热情》专辑中与张雨生男女对唱《最爱的人伤我最深》。同年12月13日，张惠妹在张雨生的协助下发行第一张个人专辑《姐妹》。1998年 举办第一场个人大型户外售票演唱会“妹力四射”，创下台湾歌手有史以来最快举行大型演唱会的纪录。2009年发行的《阿密特》专辑至今仍是金曲奖史上获得最大成功的作品，曾于第21届时擒下包括专辑、制作人、歌手等六项大奖。代表作品：《姐妹》、《我可以抱你吗》、《记得》、《火》、《如果你也听说》、《掉了》、《我最亲爱的》。"},
                new Artist { Name = "Aisha Duo", Sex = true, Description = "中国台湾著名女歌手，亚洲流行歌坛重量级天后，台湾原住民歌手。张惠妹于华人世界名气极高，于海外（尤美、日等地）也有一定的知名度，已囊括多项华语圈重要的音乐奖项。也是台湾首位接受美国CNN专访的歌手（并且在2011年第二度接受此媒体《Talk Asia》节目专访）。阿妹在1996年三月被著名台湾音乐人陈志远、陈复明发现并签约丰华唱片。并在同年7月在带自己入行的恩师张雨生的《两伊战争－红色热情》专辑中与张雨生男女对唱《最爱的人伤我最深》。同年12月13日，张惠妹在张雨生的协助下发行第一张个人专辑《姐妹》。1998年 举办第一场个人大型户外售票演唱会“妹力四射”，创下台湾歌手有史以来最快举行大型演唱会的纪录。2009年发行的《阿密特》专辑至今仍是金曲奖史上获得最大成功的作品，曾于第21届时擒下包括专辑、制作人、歌手等六项大奖。代表作品：《姐妹》、《我可以抱你吗》、《记得》、《火》、《如果你也听说》、《掉了》、《我最亲爱的》。" },
                new Artist { Name = "Alanis Morissette" , Sex = true, Description = "中国台湾著名女歌手，亚洲流行歌坛重量级天后，台湾原住民歌手。张惠妹于华人世界名气极高，于海外（尤美、日等地）也有一定的知名度，已囊括多项华语圈重要的音乐奖项。也是台湾首位接受美国CNN专访的歌手（并且在2011年第二度接受此媒体《Talk Asia》节目专访）。阿妹在1996年三月被著名台湾音乐人陈志远、陈复明发现并签约丰华唱片。并在同年7月在带自己入行的恩师张雨生的《两伊战争－红色热情》专辑中与张雨生男女对唱《最爱的人伤我最深》。同年12月13日，张惠妹在张雨生的协助下发行第一张个人专辑《姐妹》。1998年 举办第一场个人大型户外售票演唱会“妹力四射”，创下台湾歌手有史以来最快举行大型演唱会的纪录。2009年发行的《阿密特》专辑至今仍是金曲奖史上获得最大成功的作品，曾于第21届时擒下包括专辑、制作人、歌手等六项大奖。代表作品：《姐妹》、《我可以抱你吗》、《记得》、《火》、《如果你也听说》、《掉了》、《我最亲爱的》。"},
                new Artist { Name = "Alberto Turco & Nova Schola Gregoriana" , Sex = true, Description = "中国台湾著名女歌手，亚洲流行歌坛重量级天后，台湾原住民歌手。张惠妹于华人世界名气极高，于海外（尤美、日等地）也有一定的知名度，已囊括多项华语圈重要的音乐奖项。也是台湾首位接受美国CNN专访的歌手（并且在2011年第二度接受此媒体《Talk Asia》节目专访）。阿妹在1996年三月被著名台湾音乐人陈志远、陈复明发现并签约丰华唱片。并在同年7月在带自己入行的恩师张雨生的《两伊战争－红色热情》专辑中与张雨生男女对唱《最爱的人伤我最深》。同年12月13日，张惠妹在张雨生的协助下发行第一张个人专辑《姐妹》。1998年 举办第一场个人大型户外售票演唱会“妹力四射”，创下台湾歌手有史以来最快举行大型演唱会的纪录。2009年发行的《阿密特》专辑至今仍是金曲奖史上获得最大成功的作品，曾于第21届时擒下包括专辑、制作人、歌手等六项大奖。代表作品：《姐妹》、《我可以抱你吗》、《记得》、《火》、《如果你也听说》、《掉了》、《我最亲爱的》。"},
                new Artist { Name = "Alice In Chains", Sex = true, Description = "中国台湾著名女歌手，亚洲流行歌坛重量级天后，台湾原住民歌手。张惠妹于华人世界名气极高，于海外（尤美、日等地）也有一定的知名度，已囊括多项华语圈重要的音乐奖项。也是台湾首位接受美国CNN专访的歌手（并且在2011年第二度接受此媒体《Talk Asia》节目专访）。阿妹在1996年三月被著名台湾音乐人陈志远、陈复明发现并签约丰华唱片。并在同年7月在带自己入行的恩师张雨生的《两伊战争－红色热情》专辑中与张雨生男女对唱《最爱的人伤我最深》。同年12月13日，张惠妹在张雨生的协助下发行第一张个人专辑《姐妹》。1998年 举办第一场个人大型户外售票演唱会“妹力四射”，创下台湾歌手有史以来最快举行大型演唱会的纪录。2009年发行的《阿密特》专辑至今仍是金曲奖史上获得最大成功的作品，曾于第21届时擒下包括专辑、制作人、歌手等六项大奖。代表作品：《姐妹》、《我可以抱你吗》、《记得》、《火》、《如果你也听说》、《掉了》、《我最亲爱的》。" },
                new Artist { Name = "Amy Winehouse", Sex = true, Description = "中国台湾著名女歌手，亚洲流行歌坛重量级天后，台湾原住民歌手。张惠妹于华人世界名气极高，于海外（尤美、日等地）也有一定的知名度，已囊括多项华语圈重要的音乐奖项。也是台湾首位接受美国CNN专访的歌手（并且在2011年第二度接受此媒体《Talk Asia》节目专访）。阿妹在1996年三月被著名台湾音乐人陈志远、陈复明发现并签约丰华唱片。并在同年7月在带自己入行的恩师张雨生的《两伊战争－红色热情》专辑中与张雨生男女对唱《最爱的人伤我最深》。同年12月13日，张惠妹在张雨生的协助下发行第一张个人专辑《姐妹》。1998年 举办第一场个人大型户外售票演唱会“妹力四射”，创下台湾歌手有史以来最快举行大型演唱会的纪录。2009年发行的《阿密特》专辑至今仍是金曲奖史上获得最大成功的作品，曾于第21届时擒下包括专辑、制作人、歌手等六项大奖。代表作品：《姐妹》、《我可以抱你吗》、《记得》、《火》、《如果你也听说》、《掉了》、《我最亲爱的》。" },
                new Artist { Name = "Anita Ward", Sex = true, Description = "中国台湾著名女歌手，亚洲流行歌坛重量级天后，台湾原住民歌手。张惠妹于华人世界名气极高，于海外（尤美、日等地）也有一定的知名度，已囊括多项华语圈重要的音乐奖项。也是台湾首位接受美国CNN专访的歌手（并且在2011年第二度接受此媒体《Talk Asia》节目专访）。阿妹在1996年三月被著名台湾音乐人陈志远、陈复明发现并签约丰华唱片。并在同年7月在带自己入行的恩师张雨生的《两伊战争－红色热情》专辑中与张雨生男女对唱《最爱的人伤我最深》。同年12月13日，张惠妹在张雨生的协助下发行第一张个人专辑《姐妹》。1998年 举办第一场个人大型户外售票演唱会“妹力四射”，创下台湾歌手有史以来最快举行大型演唱会的纪录。2009年发行的《阿密特》专辑至今仍是金曲奖史上获得最大成功的作品，曾于第21届时擒下包括专辑、制作人、歌手等六项大奖。代表作品：《姐妹》、《我可以抱你吗》、《记得》、《火》、《如果你也听说》、《掉了》、《我最亲爱的》。" },
                new Artist { Name = "Antônio Carlos Jobim", Sex = true, Description = "中国台湾著名女歌手，亚洲流行歌坛重量级天后，台湾原住民歌手。张惠妹于华人世界名气极高，于海外（尤美、日等地）也有一定的知名度，已囊括多项华语圈重要的音乐奖项。也是台湾首位接受美国CNN专访的歌手（并且在2011年第二度接受此媒体《Talk Asia》节目专访）。阿妹在1996年三月被著名台湾音乐人陈志远、陈复明发现并签约丰华唱片。并在同年7月在带自己入行的恩师张雨生的《两伊战争－红色热情》专辑中与张雨生男女对唱《最爱的人伤我最深》。同年12月13日，张惠妹在张雨生的协助下发行第一张个人专辑《姐妹》。1998年 举办第一场个人大型户外售票演唱会“妹力四射”，创下台湾歌手有史以来最快举行大型演唱会的纪录。2009年发行的《阿密特》专辑至今仍是金曲奖史上获得最大成功的作品，曾于第21届时擒下包括专辑、制作人、歌手等六项大奖。代表作品：《姐妹》、《我可以抱你吗》、《记得》、《火》、《如果你也听说》、《掉了》、《我最亲爱的》。" },
                new Artist { Name = "Apocalyptica", Sex = true, Description = "中国台湾著名女歌手，亚洲流行歌坛重量级天后，台湾原住民歌手。张惠妹于华人世界名气极高，于海外（尤美、日等地）也有一定的知名度，已囊括多项华语圈重要的音乐奖项。也是台湾首位接受美国CNN专访的歌手（并且在2011年第二度接受此媒体《Talk Asia》节目专访）。阿妹在1996年三月被著名台湾音乐人陈志远、陈复明发现并签约丰华唱片。并在同年7月在带自己入行的恩师张雨生的《两伊战争－红色热情》专辑中与张雨生男女对唱《最爱的人伤我最深》。同年12月13日，张惠妹在张雨生的协助下发行第一张个人专辑《姐妹》。1998年 举办第一场个人大型户外售票演唱会“妹力四射”，创下台湾歌手有史以来最快举行大型演唱会的纪录。2009年发行的《阿密特》专辑至今仍是金曲奖史上获得最大成功的作品，曾于第21届时擒下包括专辑、制作人、歌手等六项大奖。代表作品：《姐妹》、《我可以抱你吗》、《记得》、《火》、《如果你也听说》、《掉了》、《我最亲爱的》。" },
                new Artist { Name = "Audioslave", Sex = true, Description = "中国台湾著名女歌手，亚洲流行歌坛重量级天后，台湾原住民歌手。张惠妹于华人世界名气极高，于海外（尤美、日等地）也有一定的知名度，已囊括多项华语圈重要的音乐奖项。也是台湾首位接受美国CNN专访的歌手（并且在2011年第二度接受此媒体《Talk Asia》节目专访）。阿妹在1996年三月被著名台湾音乐人陈志远、陈复明发现并签约丰华唱片。并在同年7月在带自己入行的恩师张雨生的《两伊战争－红色热情》专辑中与张雨生男女对唱《最爱的人伤我最深》。同年12月13日，张惠妹在张雨生的协助下发行第一张个人专辑《姐妹》。1998年 举办第一场个人大型户外售票演唱会“妹力四射”，创下台湾歌手有史以来最快举行大型演唱会的纪录。2009年发行的《阿密特》专辑至今仍是金曲奖史上获得最大成功的作品，曾于第21届时擒下包括专辑、制作人、歌手等六项大奖。代表作品：《姐妹》、《我可以抱你吗》、《记得》、《火》、《如果你也听说》、《掉了》、《我最亲爱的》。" },
                new Artist { Name = "Barry Wordsworth & BBC Concert Orchestra" },
                new Artist { Name = "Berliner Philharmoniker & Hans Rosbaud" },
                new Artist { Name = "Berliner Philharmoniker & Herbert Von Karajan" },
                new Artist { Name = "Billy Cobham" },
                new Artist { Name = "Black Label Society" },
                new Artist { Name = "Black Sabbath" },
                new Artist { Name = "Boston Symphony Orchestra & Seiji Ozawa" },
                new Artist { Name = "Britten Sinfonia, Ivor Bolton & Lesley Garrett" },
                new Artist { Name = "Bruce Dickinson" },
                new Artist { Name = "Buddy Guy" },
                new Artist { Name = "Caetano Veloso" },
                new Artist { Name = "Cake" },
                new Artist { Name = "Calexico" },
                new Artist { Name = "Cássia Eller" },
                new Artist { Name = "Chic" },
                new Artist { Name = "Chicago Symphony Orchestra & Fritz Reiner" },
                new Artist { Name = "Chico Buarque" },
                new Artist { Name = "Chico Science & Nação Zumbi" },
                new Artist { Name = "Choir Of Westminster Abbey & Simon Preston" },
                new Artist { Name = "Chris Cornell" },
                new Artist { Name = "Christopher O'Riley" },
                new Artist { Name = "Cidade Negra" },
                new Artist { Name = "Cláudio Zoli" },
                new Artist { Name = "Creedence Clearwater Revival" },
                new Artist { Name = "David Coverdale" },
                new Artist { Name = "Deep Purple" },
                new Artist { Name = "Dennis Chambers" },
                new Artist { Name = "Djavan" },
                new Artist { Name = "Donna Summer" },
                new Artist { Name = "Dread Zeppelin" },
                new Artist { Name = "Ed Motta" },
                new Artist { Name = "Edo de Waart & San Francisco Symphony" },
                new Artist { Name = "Elis Regina" },
                new Artist { Name = "English Concert & Trevor Pinnock" },
                new Artist { Name = "Eric Clapton" },
                new Artist { Name = "Eugene Ormandy" },
                new Artist { Name = "Faith No More" },
                new Artist { Name = "Falamansa" },
                new Artist { Name = "Foo Fighters" },
                new Artist { Name = "Frank Zappa & Captain Beefheart" },
                new Artist { Name = "Fretwork" },
                new Artist { Name = "Funk Como Le Gusta" },
                new Artist { Name = "Gerald Moore" },
                new Artist { Name = "Gilberto Gil" },
                new Artist { Name = "Godsmack" },
                new Artist { Name = "Gonzaguinha" },
                new Artist { Name = "Göteborgs Symfoniker & Neeme Järvi" },
                new Artist { Name = "Guns N' Roses" },
                new Artist { Name = "Gustav Mahler" },
                new Artist { Name = "Incognito" },
                new Artist { Name = "Iron Maiden" },
                new Artist { Name = "James Levine" },
                new Artist { Name = "Jamiroquai" },
                new Artist { Name = "Jimi Hendrix" },
                new Artist { Name = "Joe Satriani" },
                new Artist { Name = "Jorge Ben" },
                new Artist { Name = "Jota Quest" },
                new Artist { Name = "Judas Priest" },
                new Artist { Name = "Julian Bream" },
                new Artist { Name = "Kent Nagano and Orchestre de l'Opéra de Lyon" },
                new Artist { Name = "Kiss" },
                new Artist { Name = "Led Zeppelin" },
                new Artist { Name = "Legião Urbana" },
                new Artist { Name = "Lenny Kravitz" },
                new Artist { Name = "Les Arts Florissants & William Christie" },
                new Artist { Name = "London Symphony Orchestra & Sir Charles Mackerras" },
                new Artist { Name = "Luciana Souza/Romero Lubambo" },
                new Artist { Name = "Lulu Santos" },
                new Artist { Name = "Marcos Valle" },
                new Artist { Name = "Marillion" },
                new Artist { Name = "Marisa Monte" },
                new Artist { Name = "Martin Roscoe" },
                new Artist { Name = "Maurizio Pollini" },
                new Artist { Name = "Mela Tenenbaum, Pro Musica Prague & Richard Kapp" },
                new Artist { Name = "Men At Work" },
                new Artist { Name = "重金属lica" },
                new Artist { Name = "Michael Tilson Thomas & San Francisco Symphony" },
                new Artist { Name = "Miles Davis" },
                new Artist { Name = "Milton Nascimento" },
                new Artist { Name = "Mötley Crüe" },
                new Artist { Name = "Motörhead" },
                new Artist { Name = "Nash Ensemble" },
                new Artist { Name = "Nicolaus Esterhazy Sinfonia" },
                new Artist { Name = "Nirvana" },
                new Artist { Name = "O Terço" },
                new Artist { Name = "Olodum" },
                new Artist { Name = "Orchestra of The Age of Enlightenment" },
                new Artist { Name = "Os Paralamas Do Sucesso" },
                new Artist { Name = "Ozzy Osbourne" },
                new Artist { Name = "Page & Plant" },
                new Artist { Name = "Paul D'Ianno" },
                new Artist { Name = "Pearl Jam" },
                new Artist { Name = "Pink Floyd" },
                new Artist { Name = "Queen" },
                new Artist { Name = "R.E.M." },
                new Artist { Name = "Raul Seixas" },
                new Artist { Name = "Red Hot Chili Peppers" },
                new Artist { Name = "Roger Norrington, London 古典 Players" },
                new Artist { Name = "Royal Philharmonic Orchestra & Sir Thomas Beecham" },
                new Artist { Name = "Rush" },
                new Artist { Name = "Santana" },
                new Artist { Name = "Scholars Baroque Ensemble" },
                new Artist { Name = "Scorpions" },
                new Artist { Name = "Sergei Prokofiev & Yuri Temirkanov" },
                new Artist { Name = "Sir Georg Solti & Wiener Philharmoniker" },
                new Artist { Name = "Skank" },
                new Artist { Name = "Soundgarden" },
                new Artist { Name = "Spyro Gyra" },
                new Artist { Name = "Stevie Ray Vaughan & Double Trouble" },
                new Artist { Name = "Stone Temple Pilots" },
                new Artist { Name = "System Of A Down" },
                new Artist { Name = "Temple of the Dog" },
                new Artist { Name = "Terry Bozzio, Tony Levin & Steve Stevens" },
                new Artist { Name = "The 12 Cellists of The Berlin Philharmonic" },
                new Artist { Name = "The Black Crowes" },
                new Artist { Name = "The Cult" },
                new Artist { Name = "The Doors" },
                new Artist { Name = "The King's Singers" },
                new Artist { Name = "The Police" },
                new Artist { Name = "The Posies" },
                new Artist { Name = "The Rolling Stones" },
                new Artist { Name = "The Who" },
                new Artist { Name = "Tim Maia" },
                new Artist { Name = "Ton Koopman" },
                new Artist { Name = "U2" },
                new Artist { Name = "UB40" },
                new Artist { Name = "Van Halen" },
                new Artist { Name = "Various Artists" },
                new Artist { Name = "Velvet Revolver" },
                new Artist { Name = "Vinícius De Moraes" },
                new Artist { Name = "Wilhelm Kempff" },
                new Artist { Name = "Yehudi Menuhin" },
                new Artist { Name = "Yo-Yo Ma" },
                new Artist { Name = "Zeca Pagodinho" }
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
                    Price = 8.99M, Artist = artists.Single(a => a.Name == "张国荣"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "The Best Of Billy Cobham", Genre = genres.Single(g => g.Name == "爵士"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "张国荣"), AlbumArtUrl = "/Content/Images/placeholder.gif"
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
                    Price = 8.99M, Artist = artists.Single(a => a.Name == "张国荣"),
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
                    Artist = artists.Single(a => a.Name == "Charlie Puth"),
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
                    Artist = artists.Single(a => a.Name == "Charlie Puth"),
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
                    Artist = artists.Single(a => a.Name == "Justin Bieber"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Afrociberdelia", Genre = genres.Single(g => g.Name == "拉丁"), Price = 8.99M,
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
                    Artist = artists.Single(a => a.Name == "Justin Bieber"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "SCRIABIN: Vers la flamme", Genre = genres.Single(g => g.Name == "古典"),
                    Price = 8.99M, Artist = artists.Single(a => a.Name == "Justin Bieber"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Acústico MTV [Live]", Genre = genres.Single(g => g.Name == "流行"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Justin Bieber"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Cidade Negra - Hits", Genre = genres.Single(g => g.Name == "流行"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Justin Bieber"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Na Pista", Genre = genres.Single(g => g.Name == "拉丁"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Justin Bieber"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Chronicle, Vol. 1", Genre = genres.Single(g => g.Name == "摇滚"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "张学友"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Chronicle, Vol. 2", Genre = genres.Single(g => g.Name == "摇滚"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "张学友"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Into The Light", Genre = genres.Single(g => g.Name == "摇滚"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "David Coverdale"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Come Taste The Band", Genre = genres.Single(g => g.Name == "摇滚"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "莫文蔚"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "莫文蔚 In 摇滚", Genre = genres.Single(g => g.Name == "摇滚"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "莫文蔚"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Fireball", Genre = genres.Single(g => g.Name == "摇滚"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "莫文蔚"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Machine Head", Genre = genres.Single(g => g.Name == "摇滚"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "莫文蔚"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "MK III The Final Concerts [Disc 1]", Genre = genres.Single(g => g.Name == "摇滚"),
                    Price = 8.99M, Artist = artists.Single(a => a.Name == "莫文蔚"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Purpendicular", Genre = genres.Single(g => g.Name == "摇滚"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "莫文蔚"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Slaves And Masters", Genre = genres.Single(g => g.Name == "摇滚"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "莫文蔚"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Stormbringer", Genre = genres.Single(g => g.Name == "摇滚"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "莫文蔚"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "The Battle Rages On", Genre = genres.Single(g => g.Name == "摇滚"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "莫文蔚"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "The Final Concerts (Disc 2)", Genre = genres.Single(g => g.Name == "摇滚"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "莫文蔚"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Outbreak", Genre = genres.Single(g => g.Name == "爵士"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "周杰伦"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "周杰伦 Ao Vivo - Vol. 02", Genre = genres.Single(g => g.Name == "拉丁"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "周杰伦"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "周杰伦 Ao Vivo - Vol. 1", Genre = genres.Single(g => g.Name == "拉丁"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "周杰伦"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "MacArthur Park Suite", Genre = genres.Single(g => g.Name == "DISCO"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Donna Summer"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Un-Led-Ed", Genre = genres.Single(g => g.Name == "摇滚"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Dread Zeppelin"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "The Best of Ed Motta", Genre = genres.Single(g => g.Name == "拉丁"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Ed Motta"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Adams, John: The Chairman Dances", Genre = genres.Single(g => g.Name == "古典"),
                    Price = 8.99M, Artist = artists.Single(a => a.Name == "Edo de Waart & San Francisco Symphony"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Elis Regina-Minha História", Genre = genres.Single(g => g.Name == "拉丁"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Elis Regina"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Pachelbel: Canon & Gigue", Genre = genres.Single(g => g.Name == "古典"),
                    Price = 8.99M, Artist = artists.Single(a => a.Name == "English Concert & Trevor Pinnock"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Unplugged", Genre = genres.Single(g => g.Name == "拉丁"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Eric Clapton"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "The Cream Of Clapton", Genre = genres.Single(g => g.Name == "流行"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Eric Clapton"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Unplugged", Genre = genres.Single(g => g.Name == "流行"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Eric Clapton"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Respighi:Pines of Rome", Genre = genres.Single(g => g.Name == "古典"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Eugene Ormandy"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Strauss: Waltzes", Genre = genres.Single(g => g.Name == "古典"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Eugene Ormandy"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "King For A Day Fool For A Lifetime", Genre = genres.Single(g => g.Name == "摇滚"),
                    Price = 8.99M, Artist = artists.Single(a => a.Name == "Faith No More"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Deixa Entrar", Genre = genres.Single(g => g.Name == "拉丁"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Falamansa"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "In Your Honor [Disc 1]", Genre = genres.Single(g => g.Name == "摇滚"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Foo Fighters"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "In Your Honor [Disc 2]", Genre = genres.Single(g => g.Name == "摇滚"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Foo Fighters"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "The Colour And The Shape", Genre = genres.Single(g => g.Name == "摇滚"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Foo Fighters"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Bongo Fury", Genre = genres.Single(g => g.Name == "摇滚"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Frank Zappa & Captain Beefheart"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Roda De Funk", Genre = genres.Single(g => g.Name == "拉丁"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Funk Como Le Gusta"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Quanta Gente Veio Ver (Live)", Genre = genres.Single(g => g.Name == "拉丁"),
                    Price = 8.99M, Artist = artists.Single(a => a.Name == "Gilberto Gil"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Quanta Gente Veio ver--Bônus De Carnaval", Genre = genres.Single(g => g.Name == "爵士"),
                    Price = 8.99M, Artist = artists.Single(a => a.Name == "Gilberto Gil"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Faceless", Genre = genres.Single(g => g.Name == "重金属"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Godsmack"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Meus Momentos", Genre = genres.Single(g => g.Name == "拉丁"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Gonzaguinha"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Nielsen: The Six Symphonies", Genre = genres.Single(g => g.Name == "古典"),
                    Price = 8.99M, Artist = artists.Single(a => a.Name == "Göteborgs Symfoniker & Neeme Järvi"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Appetite for Destruction", Genre = genres.Single(g => g.Name == "摇滚"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Guns N' Roses"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Use Your Illusion I", Genre = genres.Single(g => g.Name == "摇滚"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Guns N' Roses"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Use Your Illusion II", Genre = genres.Single(g => g.Name == "重金属"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Guns N' Roses"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Blue Moods", Genre = genres.Single(g => g.Name == "爵士"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Incognito"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "A Matter of Life and Death", Genre = genres.Single(g => g.Name == "摇滚"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Iron Maiden"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Brave New World", Genre = genres.Single(g => g.Name == "摇滚"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Iron Maiden"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Fear Of The Dark", Genre = genres.Single(g => g.Name == "摇滚"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Iron Maiden"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Live At Donington 1992 (Disc 1)", Genre = genres.Single(g => g.Name == "摇滚"),
                    Price = 8.99M, Artist = artists.Single(a => a.Name == "Iron Maiden"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Live At Donington 1992 (Disc 2)", Genre = genres.Single(g => g.Name == "摇滚"),
                    Price = 8.99M, Artist = artists.Single(a => a.Name == "Iron Maiden"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "摇滚 In Rio [CD2]", Genre = genres.Single(g => g.Name == "摇滚"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Iron Maiden"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "The Number of The Beast", Genre = genres.Single(g => g.Name == "摇滚"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Iron Maiden"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "The X Factor", Genre = genres.Single(g => g.Name == "摇滚"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Iron Maiden"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Virtual XI", Genre = genres.Single(g => g.Name == "摇滚"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Iron Maiden"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "A Real Dead One", Genre = genres.Single(g => g.Name == "重金属"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Iron Maiden"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "A Real Live One", Genre = genres.Single(g => g.Name == "重金属"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Iron Maiden"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Live After Death", Genre = genres.Single(g => g.Name == "重金属"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Iron Maiden"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "No Prayer For The Dying", Genre = genres.Single(g => g.Name == "重金属"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Iron Maiden"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Piece Of Mind", Genre = genres.Single(g => g.Name == "重金属"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Iron Maiden"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Powerslave", Genre = genres.Single(g => g.Name == "重金属"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Iron Maiden"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "摇滚 In Rio [CD1]", Genre = genres.Single(g => g.Name == "重金属"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Iron Maiden"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "摇滚 In Rio [CD2]", Genre = genres.Single(g => g.Name == "重金属"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Iron Maiden"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Seventh Son of a Seventh Son", Genre = genres.Single(g => g.Name == "重金属"),
                    Price = 8.99M, Artist = artists.Single(a => a.Name == "Iron Maiden"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Somewhere in Time", Genre = genres.Single(g => g.Name == "重金属"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Iron Maiden"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "The Number of The Beast", Genre = genres.Single(g => g.Name == "重金属"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Iron Maiden"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Iron Maiden", Genre = genres.Single(g => g.Name == "流行"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Iron Maiden"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Mascagni: Cavalleria Rusticana", Genre = genres.Single(g => g.Name == "古典"),
                    Price = 8.99M, Artist = artists.Single(a => a.Name == "James Levine"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Emergency On Planet Earth", Genre = genres.Single(g => g.Name == "摇滚"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Jamiroquai"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Are You Experienced?", Genre = genres.Single(g => g.Name == "摇滚"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Jimi Hendrix"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Surfing with the Alien (Remastered)", Genre = genres.Single(g => g.Name == "摇滚"),
                    Price = 8.99M, Artist = artists.Single(a => a.Name == "Joe Satriani"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Jorge Ben Jor 25 Anos", Genre = genres.Single(g => g.Name == "拉丁"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Jorge Ben"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Jota Quest-1995", Genre = genres.Single(g => g.Name == "拉丁"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Jota Quest"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Living After Midnight", Genre = genres.Single(g => g.Name == "重金属"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Judas Priest"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Weill: The Seven Deadly Sins", Genre = genres.Single(g => g.Name == "古典"),
                    Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Kent Nagano and Orchestre de l'Opéra de Lyon"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Greatest Kiss", Genre = genres.Single(g => g.Name == "摇滚"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Kiss"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Unplugged [Live]", Genre = genres.Single(g => g.Name == "摇滚"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Kiss"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "BBC Sessions [Disc 1] [Live]", Genre = genres.Single(g => g.Name == "摇滚"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Led Zeppelin"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "BBC Sessions [Disc 2] [Live]", Genre = genres.Single(g => g.Name == "摇滚"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Led Zeppelin"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Coda", Genre = genres.Single(g => g.Name == "摇滚"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Led Zeppelin"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Houses Of The Holy", Genre = genres.Single(g => g.Name == "摇滚"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Led Zeppelin"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "In Through The Out Door", Genre = genres.Single(g => g.Name == "摇滚"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Led Zeppelin"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "IV", Genre = genres.Single(g => g.Name == "摇滚"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Led Zeppelin"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Led Zeppelin I", Genre = genres.Single(g => g.Name == "摇滚"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Led Zeppelin"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Led Zeppelin II", Genre = genres.Single(g => g.Name == "摇滚"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Led Zeppelin"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Led Zeppelin III", Genre = genres.Single(g => g.Name == "摇滚"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Led Zeppelin"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Physical Graffiti [Disc 1]", Genre = genres.Single(g => g.Name == "摇滚"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Led Zeppelin"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Physical Graffiti [Disc 2]", Genre = genres.Single(g => g.Name == "摇滚"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Led Zeppelin"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Presence", Genre = genres.Single(g => g.Name == "摇滚"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Led Zeppelin"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "The Song Remains The Same (Disc 1)", Genre = genres.Single(g => g.Name == "摇滚"),
                    Price = 8.99M, Artist = artists.Single(a => a.Name == "Led Zeppelin"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "The Song Remains The Same (Disc 2)", Genre = genres.Single(g => g.Name == "摇滚"),
                    Price = 8.99M, Artist = artists.Single(a => a.Name == "Led Zeppelin"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Mais Do Mesmo", Genre = genres.Single(g => g.Name == "拉丁"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Legião Urbana"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Greatest Hits", Genre = genres.Single(g => g.Name == "流行"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Lenny Kravitz"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Greatest Hits", Genre = genres.Single(g => g.Name == "摇滚"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Lenny Kravitz"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Greatest Hits", Genre = genres.Single(g => g.Name == "重金属"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Lenny Kravitz"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Tchaikovsky: The Nutcracker", Genre = genres.Single(g => g.Name == "古典"),
                    Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "London Symphony Orchestra & Sir Charles Mackerras"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Duos II", Genre = genres.Single(g => g.Name == "拉丁"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Luciana Souza/Romero Lubambo"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Chill: Brazil (Disc 1)", Genre = genres.Single(g => g.Name == "拉丁"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Marcos Valle"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Misplaced Childhood", Genre = genres.Single(g => g.Name == "摇滚"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Marillion"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Barulhinho Bom", Genre = genres.Single(g => g.Name == "拉丁"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Marisa Monte"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Szymanowski: Piano Works, Vol. 1", Genre = genres.Single(g => g.Name == "古典"),
                    Price = 8.99M, Artist = artists.Single(a => a.Name == "Martin Roscoe"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "...And Justice For All", Genre = genres.Single(g => g.Name == "重金属"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "重金属lica"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Black Album", Genre = genres.Single(g => g.Name == "重金属"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "重金属lica"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Garage Inc. (Disc 1)", Genre = genres.Single(g => g.Name == "重金属"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "重金属lica"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Garage Inc. (Disc 2)", Genre = genres.Single(g => g.Name == "重金属"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "重金属lica"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Load", Genre = genres.Single(g => g.Name == "重金属"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "重金属lica"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Master Of Puppets", Genre = genres.Single(g => g.Name == "重金属"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "重金属lica"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "ReLoad", Genre = genres.Single(g => g.Name == "重金属"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "重金属lica"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Ride The Lightning", Genre = genres.Single(g => g.Name == "重金属"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "重金属lica"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "St. Anger", Genre = genres.Single(g => g.Name == "重金属"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "重金属lica"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Berlioz: Symphonie Fantastique", Genre = genres.Single(g => g.Name == "古典"),
                    Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Michael Tilson Thomas & San Francisco Symphony"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Prokofiev: Romeo & Juliet", Genre = genres.Single(g => g.Name == "古典"),
                    Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Michael Tilson Thomas & San Francisco Symphony"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Miles Ahead", Genre = genres.Single(g => g.Name == "爵士"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Miles Davis"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "The Essential Miles Davis [Disc 1]", Genre = genres.Single(g => g.Name == "爵士"),
                    Price = 8.99M, Artist = artists.Single(a => a.Name == "Miles Davis"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "The Essential Miles Davis [Disc 2]", Genre = genres.Single(g => g.Name == "爵士"),
                    Price = 8.99M, Artist = artists.Single(a => a.Name == "Miles Davis"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Milton Nascimento Ao Vivo", Genre = genres.Single(g => g.Name == "拉丁"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Milton Nascimento"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Minas", Genre = genres.Single(g => g.Name == "拉丁"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Milton Nascimento"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Motley Crue Greatest Hits", Genre = genres.Single(g => g.Name == "重金属"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Mötley Crüe"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Ace Of Spades", Genre = genres.Single(g => g.Name == "重金属"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Motörhead"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Mozart: Chamber Music", Genre = genres.Single(g => g.Name == "古典"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Nash Ensemble"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "The Best of Beethoven", Genre = genres.Single(g => g.Name == "古典"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Nicolaus Esterhazy Sinfonia"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Nevermind", Genre = genres.Single(g => g.Name == "摇滚"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Nirvana"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Compositores", Genre = genres.Single(g => g.Name == "摇滚"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "O Terço"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Olodum", Genre = genres.Single(g => g.Name == "拉丁"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Olodum"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Bach: The Brandenburg Concertos", Genre = genres.Single(g => g.Name == "古典"),
                    Price = 8.99M, Artist = artists.Single(a => a.Name == "Orchestra of The Age of Enlightenment"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Acústico MTV", Genre = genres.Single(g => g.Name == "拉丁"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Os Paralamas Do Sucesso"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Arquivo II", Genre = genres.Single(g => g.Name == "拉丁"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Os Paralamas Do Sucesso"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Arquivo Os Paralamas Do Sucesso", Genre = genres.Single(g => g.Name == "拉丁"),
                    Price = 8.99M, Artist = artists.Single(a => a.Name == "Os Paralamas Do Sucesso"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Tribute", Genre = genres.Single(g => g.Name == "重金属"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Ozzy Osbourne"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Bark at the Moon (Remastered)", Genre = genres.Single(g => g.Name == "摇滚"),
                    Price = 8.99M, Artist = artists.Single(a => a.Name == "Ozzy Osbourne"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Blizzard of Ozz", Genre = genres.Single(g => g.Name == "摇滚"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Ozzy Osbourne"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Diary of a Madman (Remastered)", Genre = genres.Single(g => g.Name == "摇滚"),
                    Price = 8.99M, Artist = artists.Single(a => a.Name == "Ozzy Osbourne"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "No More Tears (Remastered)", Genre = genres.Single(g => g.Name == "摇滚"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Ozzy Osbourne"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Speak of the Devil", Genre = genres.Single(g => g.Name == "摇滚"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Ozzy Osbourne"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Walking Into Clarksdale", Genre = genres.Single(g => g.Name == "摇滚"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Page & Plant"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "The Beast Live", Genre = genres.Single(g => g.Name == "摇滚"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Paul D'Ianno"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Live On Two Legs [Live]", Genre = genres.Single(g => g.Name == "摇滚"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Pearl Jam"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Riot Act", Genre = genres.Single(g => g.Name == "摇滚"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Pearl Jam"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Ten", Genre = genres.Single(g => g.Name == "摇滚"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Pearl Jam"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Vs.", Genre = genres.Single(g => g.Name == "摇滚"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Pearl Jam"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Dark Side Of The Moon", Genre = genres.Single(g => g.Name == "摇滚"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Pink Floyd"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Greatest Hits I", Genre = genres.Single(g => g.Name == "摇滚"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Queen"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Greatest Hits II", Genre = genres.Single(g => g.Name == "摇滚"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Queen"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "News Of The World", Genre = genres.Single(g => g.Name == "摇滚"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Queen"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "New Adventures In Hi-Fi", Genre = genres.Single(g => g.Name == "摇滚"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "R.E.M."), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Raul Seixas", Genre = genres.Single(g => g.Name == "摇滚"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Raul Seixas"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "By The Way", Genre = genres.Single(g => g.Name == "摇滚"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Red Hot Chili Peppers"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Californication", Genre = genres.Single(g => g.Name == "摇滚"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Red Hot Chili Peppers"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Purcell: The Fairy Queen", Genre = genres.Single(g => g.Name == "古典"),
                    Price = 8.99M, Artist = artists.Single(a => a.Name == "Roger Norrington, London 古典 Players"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Haydn: Symphonies 99 - 104", Genre = genres.Single(g => g.Name == "古典"),
                    Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Royal Philharmonic Orchestra & Sir Thomas Beecham"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Retrospective I (1974-1980)", Genre = genres.Single(g => g.Name == "摇滚"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Rush"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Santana - As Years Go By", Genre = genres.Single(g => g.Name == "摇滚"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Santana"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Santana Live", Genre = genres.Single(g => g.Name == "摇滚"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Santana"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Supernatural", Genre = genres.Single(g => g.Name == "摇滚"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Santana"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Handel: The Messiah (Highlights)", Genre = genres.Single(g => g.Name == "古典"),
                    Price = 8.99M, Artist = artists.Single(a => a.Name == "Scholars Baroque Ensemble"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Prokofiev: Symphony No.1", Genre = genres.Single(g => g.Name == "古典"),
                    Price = 8.99M, Artist = artists.Single(a => a.Name == "Sergei Prokofiev & Yuri Temirkanov"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Wagner: Favourite Overtures", Genre = genres.Single(g => g.Name == "古典"),
                    Price = 8.99M, Artist = artists.Single(a => a.Name == "Sir Georg Solti & Wiener Philharmoniker"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Maquinarama", Genre = genres.Single(g => g.Name == "摇滚"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Skank"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "O Samba Poconé", Genre = genres.Single(g => g.Name == "摇滚"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Skank"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "A-Sides", Genre = genres.Single(g => g.Name == "摇滚"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Soundgarden"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Heart of the Night", Genre = genres.Single(g => g.Name == "爵士"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Spyro Gyra"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Morning Dance", Genre = genres.Single(g => g.Name == "爵士"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Spyro Gyra"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "In Step", Genre = genres.Single(g => g.Name == "流行"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Stevie Ray Vaughan & Double Trouble"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Core", Genre = genres.Single(g => g.Name == "摇滚"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Stone Temple Pilots"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Mezmerize", Genre = genres.Single(g => g.Name == "重金属"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "System Of A Down"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Temple of the Dog", Genre = genres.Single(g => g.Name == "流行"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Temple of the Dog"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "[1997] Black Light Syndrome", Genre = genres.Single(g => g.Name == "摇滚"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Terry Bozzio, Tony Levin & Steve Stevens"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "South American Getaway", Genre = genres.Single(g => g.Name == "古典"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "The 12 Cellists of The Berlin Philharmonic"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Live [Disc 1]", Genre = genres.Single(g => g.Name == "流行"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "The Black Crowes"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Live [Disc 2]", Genre = genres.Single(g => g.Name == "流行"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "The Black Crowes"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Beyond Good And Evil", Genre = genres.Single(g => g.Name == "摇滚"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "The Cult"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "The Doors", Genre = genres.Single(g => g.Name == "摇滚"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "The Doors"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "English Renaissance", Genre = genres.Single(g => g.Name == "古典"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "The King's Singers"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "The Police Greatest Hits", Genre = genres.Single(g => g.Name == "摇滚"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "The Police"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Every Kind of Light", Genre = genres.Single(g => g.Name == "摇滚"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "The Posies"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Hot 摇滚s, 1964-1971 (Disc 1)", Genre = genres.Single(g => g.Name == "摇滚"),
                    Price = 8.99M, Artist = artists.Single(a => a.Name == "The Rolling Stones"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "No Security", Genre = genres.Single(g => g.Name == "摇滚"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "The Rolling Stones"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Voodoo Lounge", Genre = genres.Single(g => g.Name == "摇滚"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "The Rolling Stones"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "My Generation - The Very Best Of The Who", Genre = genres.Single(g => g.Name == "摇滚"),
                    Price = 8.99M, Artist = artists.Single(a => a.Name == "The Who"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Serie Sem Limite (Disc 1)", Genre = genres.Single(g => g.Name == "拉丁"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Tim Maia"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Serie Sem Limite (Disc 2)", Genre = genres.Single(g => g.Name == "拉丁"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "Tim Maia"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Bach: Toccata & Fugue in D Minor", Genre = genres.Single(g => g.Name == "古典"),
                    Price = 8.99M, Artist = artists.Single(a => a.Name == "Ton Koopman"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Achtung Baby", Genre = genres.Single(g => g.Name == "摇滚"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "周杰伦"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "B-Sides 1980-1990", Genre = genres.Single(g => g.Name == "摇滚"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "周杰伦"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "How To Dismantle An Atomic Bomb", Genre = genres.Single(g => g.Name == "摇滚"),
                    Price = 8.99M, Artist = artists.Single(a => a.Name == "周杰伦"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "流行", Genre = genres.Single(g => g.Name == "摇滚"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "周杰伦"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Rattle And Hum", Genre = genres.Single(g => g.Name == "摇滚"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "周杰伦"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "The Best Of 1980-1990", Genre = genres.Single(g => g.Name == "摇滚"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "周杰伦"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "War", Genre = genres.Single(g => g.Name == "摇滚"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "周杰伦"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Zooropa", Genre = genres.Single(g => g.Name == "摇滚"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "周杰伦"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "UB40 The Best Of - Volume Two [UK]", Genre = genres.Single(g => g.Name == "流行"),
                    Price = 8.99M, Artist = artists.Single(a => a.Name == "许嵩"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Diver Down", Genre = genres.Single(g => g.Name == "摇滚"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "毛不易"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "The Best Of 毛不易, Vol. I", Genre = genres.Single(g => g.Name == "摇滚"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "毛不易"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "毛不易 III", Genre = genres.Single(g => g.Name == "摇滚"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "毛不易"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "毛不易", Genre = genres.Single(g => g.Name == "摇滚"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "毛不易"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Axé Bahia 2001", Genre = genres.Single(g => g.Name == "流行"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "毛不易"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Sambas De Enredo 2001", Genre = genres.Single(g => g.Name == "拉丁"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "毛不易"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Vozes do MPB", Genre = genres.Single(g => g.Name == "拉丁"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "毛不易"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Contraband", Genre = genres.Single(g => g.Name == "摇滚"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "许嵩"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Vinicius De Moraes", Genre = genres.Single(g => g.Name == "拉丁"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "许嵩"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Bach: Goldberg Variations", Genre = genres.Single(g => g.Name == "古典"),
                    Price = 8.99M, Artist = artists.Single(a => a.Name == "许嵩"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Bartok: Violin & Viola Concertos", Genre = genres.Single(g => g.Name == "古典"),
                    Price = 8.99M, Artist = artists.Single(a => a.Name == "许嵩"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Bach: The Cello Suites", Genre = genres.Single(g => g.Name == "古典"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "许嵩"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Ao Vivo [IMPORT]", Genre = genres.Single(g => g.Name == "拉丁"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "许嵩"), AlbumArtUrl = "/Content/Images/placeholder.gif"
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
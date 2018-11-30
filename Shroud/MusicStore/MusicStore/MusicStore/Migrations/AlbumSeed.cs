using MusicStoreEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStore.Migrations
{
    public class AlbumSeed
    {
        static readonly MusicStoreEntity.MusicContext _dbMusicContext = new MusicStoreEntity.MusicContext();
        public static void Seed()
        {
            new List<Album>()
            {
                new Album () { Title = "Bad Habit", Price = 8.9m,Genre = _GetGenreByGenreName("乡村"), GenreId = _GetGenreByGenreName("乡村").ID.ToString(), Artist = _GetArtistByArtistName("华晨宇"), ArtistId = _GetArtistByArtistName("华晨宇").ID.ToString()},
                new Album () { Title="A swim in the love that you give me" , Price = 8.8m,Genre = _GetGenreByGenreName("说唱"), GenreId = _GetGenreByGenreName("说唱").ID.ToString(), Artist = _GetArtistByArtistName("蔡健雅"), ArtistId = _GetArtistByArtistName("蔡健雅").ID.ToString()},
                new Album () { Title="抱紧你" , Price = 8.7m,Genre = _GetGenreByGenreName("摇滚"), GenreId = _GetGenreByGenreName("摇滚").ID.ToString(), Artist = _GetArtistByArtistName("王以太"), ArtistId = _GetArtistByArtistName("王以太").ID.ToString()},
                new Album () { Title="我喜欢的每个女孩都有男朋友" , Price = 8.6m,Genre = _GetGenreByGenreName("古典"), GenreId = _GetGenreByGenreName("古典").ID.ToString(), Artist = _GetArtistByArtistName("The Chainsmokers"), ArtistId = _GetArtistByArtistName("The Chainsmokers").ID.ToString()},
                new Album () { Title="绿色丛林" , Price = 8.5m,Genre = _GetGenreByGenreName("爵士"), GenreId = _GetGenreByGenreName("爵士").ID.ToString(), Artist = _GetArtistByArtistName("马雨阳"), ArtistId = _GetArtistByArtistName("马雨阳").ID.ToString()},
                new Album () { Title="Late Night" , Price = 8.4m,Genre = _GetGenreByGenreName("舞曲"), GenreId = _GetGenreByGenreName("舞曲").ID.ToString(), Artist = _GetArtistByArtistName("徐秉龙"), ArtistId = _GetArtistByArtistName("徐秉龙").ID.ToString()},
                new Album () { Title="Playboy Style" , Price = 8.3m,Genre = _GetGenreByGenreName("Soul"), GenreId = _GetGenreByGenreName("Soul").ID.ToString(), Artist = _GetArtistByArtistName("毛不易"), ArtistId = _GetArtistByArtistName("毛不易").ID.ToString()},
                new Album () { Title="徒花ネクロマンシー" ,Price = 4.9m,Genre = _GetGenreByGenreName("轻音乐"), GenreId = _GetGenreByGenreName("轻音乐").ID.ToString(), Artist = _GetArtistByArtistName("房东的猫"), ArtistId = _GetArtistByArtistName("房东的猫").ID.ToString()},
                new Album () { Title="IKIJIBIKI feat.Taka" , Price = 8.2m,Genre = _GetGenreByGenreName("电子"), GenreId = _GetGenreByGenreName("电子").ID.ToString(), Artist = _GetArtistByArtistName("艾热"), ArtistId = _GetArtistByArtistName("艾热").ID.ToString()},
                new Album () { Title="hectopascal" , Price = 8.1m,Genre = _GetGenreByGenreName("流行"), GenreId = _GetGenreByGenreName("流行").ID.ToString(), Artist = _GetArtistByArtistName("许嵩"), ArtistId = _GetArtistByArtistName("许嵩").ID.ToString()},
                new Album () { Title="倾城时光" , Price = 7.9m,Genre = _GetGenreByGenreName("英伦"), GenreId = _GetGenreByGenreName("英伦").ID.ToString(), Artist = _GetArtistByArtistName("王力宏"), ArtistId = _GetArtistByArtistName("王力宏").ID.ToString()},
                new Album () { Title="喜新恋旧" , Price = 6.9m,Genre = _GetGenreByGenreName("民族"), GenreId = _GetGenreByGenreName("民族").ID.ToString(), Artist = _GetArtistByArtistName("田馥甄"), ArtistId = _GetArtistByArtistName("田馥甄").ID.ToString()},
                new Album () { Title="绝代风华" , Price = 5.9m,Genre = _GetGenreByGenreName("民谣"), GenreId = _GetGenreByGenreName("民谣").ID.ToString(), Artist = _GetArtistByArtistName("Charlie Puth"), ArtistId = _GetArtistByArtistName("Charlie Puth").ID.ToString()},

                new Album () { Title = "新鲜感", Price = 8.9m,Genre = _GetGenreByGenreName("乡村"), GenreId = _GetGenreByGenreName("乡村").ID.ToString(), Artist = _GetArtistByArtistName("华晨宇"), ArtistId = _GetArtistByArtistName("华晨宇").ID.ToString()},
                new Album () { Title="一辈子的孤单" , Price = 8.8m,Genre = _GetGenreByGenreName("说唱"), GenreId = _GetGenreByGenreName("说唱").ID.ToString(), Artist = _GetArtistByArtistName("蔡健雅"), ArtistId = _GetArtistByArtistName("蔡健雅").ID.ToString()},
                new Album () { Title="我真的受伤了" , Price = 8.7m,Genre = _GetGenreByGenreName("摇滚"), GenreId = _GetGenreByGenreName("摇滚").ID.ToString(), Artist = _GetArtistByArtistName("王以太"), ArtistId = _GetArtistByArtistName("王以太").ID.ToString()},
                new Album () { Title="越长大越孤单" , Price = 8.6m,Genre = _GetGenreByGenreName("古典"), GenreId = _GetGenreByGenreName("古典").ID.ToString(), Artist = _GetArtistByArtistName("The Chainsmokers"), ArtistId = _GetArtistByArtistName("The Chainsmokers").ID.ToString()},
                new Album () { Title="不能说的秘密" , Price = 8.5m,Genre = _GetGenreByGenreName("爵士"), GenreId = _GetGenreByGenreName("爵士").ID.ToString(), Artist = _GetArtistByArtistName("马雨阳"), ArtistId = _GetArtistByArtistName("马雨阳").ID.ToString()},
                new Album () { Title="我能够抱你吗" , Price = 8.4m,Genre = _GetGenreByGenreName("舞曲"), GenreId = _GetGenreByGenreName("舞曲").ID.ToString(), Artist = _GetArtistByArtistName("徐秉龙"), ArtistId = _GetArtistByArtistName("徐秉龙").ID.ToString()},
                new Album () { Title="他务必很爱你" , Price = 8.3m,Genre = _GetGenreByGenreName("Soul"), GenreId = _GetGenreByGenreName("Soul").ID.ToString(), Artist = _GetArtistByArtistName("毛不易"), ArtistId = _GetArtistByArtistName("毛不易").ID.ToString()},
                new Album () { Title="YELLOW" ,Price = 4.9m,Genre = _GetGenreByGenreName("轻音乐"), GenreId = _GetGenreByGenreName("轻音乐").ID.ToString(), Artist = _GetArtistByArtistName("房东的猫"), ArtistId = _GetArtistByArtistName("房东的猫").ID.ToString()},
                new Album () { Title="他必须很爱你" , Price = 8.2m,Genre = _GetGenreByGenreName("电子"), GenreId = _GetGenreByGenreName("电子").ID.ToString(), Artist = _GetArtistByArtistName("艾热"), ArtistId = _GetArtistByArtistName("艾热").ID.ToString()},
                new Album () { Title="一辈子的孤单" , Price = 8.1m,Genre = _GetGenreByGenreName("流行"), GenreId = _GetGenreByGenreName("流行").ID.ToString(), Artist = _GetArtistByArtistName("许嵩"), ArtistId = _GetArtistByArtistName("许嵩").ID.ToString()},
                new Album () { Title="越长大越孤单" , Price = 7.9m,Genre = _GetGenreByGenreName("英伦"), GenreId = _GetGenreByGenreName("英伦").ID.ToString(), Artist = _GetArtistByArtistName("王力宏"), ArtistId = _GetArtistByArtistName("王力宏").ID.ToString()},
                new Album () { Title="我真的受伤了" , Price = 6.9m,Genre = _GetGenreByGenreName("民族"), GenreId = _GetGenreByGenreName("民族").ID.ToString(), Artist = _GetArtistByArtistName("田馥甄"), ArtistId = _GetArtistByArtistName("田馥甄").ID.ToString()},
                new Album () { Title="思念是一种病" , Price = 5.9m,Genre = _GetGenreByGenreName("民谣"), GenreId = _GetGenreByGenreName("民谣").ID.ToString(), Artist = _GetArtistByArtistName("Charlie Puth"), ArtistId = _GetArtistByArtistName("Charlie Puth").ID.ToString()},

                new Album () { Title = "我能够抱你吗", Price = 8.9m,Genre = _GetGenreByGenreName("乡村"), GenreId = _GetGenreByGenreName("乡村").ID.ToString(), Artist = _GetArtistByArtistName("华晨宇"), ArtistId = _GetArtistByArtistName("华晨宇").ID.ToString()},
                new Album () { Title="后青春期的诗" , Price = 8.8m,Genre = _GetGenreByGenreName("说唱"), GenreId = _GetGenreByGenreName("说唱").ID.ToString(), Artist = _GetArtistByArtistName("蔡健雅"), ArtistId = _GetArtistByArtistName("蔡健雅").ID.ToString()},
                new Album () { Title="结局后才明白" , Price = 8.7m,Genre = _GetGenreByGenreName("摇滚"), GenreId = _GetGenreByGenreName("摇滚").ID.ToString(), Artist = _GetArtistByArtistName("王以太"), ArtistId = _GetArtistByArtistName("王以太").ID.ToString()},
                new Album () { Title="请你勇敢一点" , Price = 8.6m,Genre = _GetGenreByGenreName("古典"), GenreId = _GetGenreByGenreName("古典").ID.ToString(), Artist = _GetArtistByArtistName("The Chainsmokers"), ArtistId = _GetArtistByArtistName("The Chainsmokers").ID.ToString()},
                new Album () { Title="来不及说再见" , Price = 8.5m,Genre = _GetGenreByGenreName("爵士"), GenreId = _GetGenreByGenreName("爵士").ID.ToString(), Artist = _GetArtistByArtistName("马雨阳"), ArtistId = _GetArtistByArtistName("马雨阳").ID.ToString()},
                new Album () { Title="柠檬草的味道" , Price = 8.4m,Genre = _GetGenreByGenreName("舞曲"), GenreId = _GetGenreByGenreName("舞曲").ID.ToString(), Artist = _GetArtistByArtistName("徐秉龙"), ArtistId = _GetArtistByArtistName("徐秉龙").ID.ToString()},
                new Album () { Title="说好的幸福呢" , Price = 8.3m,Genre = _GetGenreByGenreName("Soul"), GenreId = _GetGenreByGenreName("Soul").ID.ToString(), Artist = _GetArtistByArtistName("毛不易"), ArtistId = _GetArtistByArtistName("毛不易").ID.ToString()},
                new Album () { Title="蒲公英的约定" ,Price = 4.9m,Genre = _GetGenreByGenreName("轻音乐"), GenreId = _GetGenreByGenreName("轻音乐").ID.ToString(), Artist = _GetArtistByArtistName("房东的猫"), ArtistId = _GetArtistByArtistName("房东的猫").ID.ToString()},
                new Album () { Title="不能收的秘密" , Price = 8.2m,Genre = _GetGenreByGenreName("电子"), GenreId = _GetGenreByGenreName("电子").ID.ToString(), Artist = _GetArtistByArtistName("艾热"), ArtistId = _GetArtistByArtistName("艾热").ID.ToString()},
                new Album () { Title="米兰的小铁匠" , Price = 8.1m,Genre = _GetGenreByGenreName("流行"), GenreId = _GetGenreByGenreName("流行").ID.ToString(), Artist = _GetArtistByArtistName("许嵩"), ArtistId = _GetArtistByArtistName("许嵩").ID.ToString()},
                new Album () { Title="爱的飞行日记" , Price = 7.9m,Genre = _GetGenreByGenreName("英伦"), GenreId = _GetGenreByGenreName("英伦").ID.ToString(), Artist = _GetArtistByArtistName("王力宏"), ArtistId = _GetArtistByArtistName("王力宏").ID.ToString()},
                new Album () { Title="印地安老斑鸠" , Price = 6.9m,Genre = _GetGenreByGenreName("民族"), GenreId = _GetGenreByGenreName("民族").ID.ToString(), Artist = _GetArtistByArtistName("田馥甄"), ArtistId = _GetArtistByArtistName("田馥甄").ID.ToString()},
                new Album () { Title="玫瑰花的葬礼" , Price = 5.9m,Genre = _GetGenreByGenreName("民谣"), GenreId = _GetGenreByGenreName("民谣").ID.ToString(), Artist = _GetArtistByArtistName("Charlie Puth"), ArtistId = _GetArtistByArtistName("Charlie Puth").ID.ToString()},

                new Album () { Title = "感情里的眼泪", Price = 8.9m,Genre = _GetGenreByGenreName("乡村"), GenreId = _GetGenreByGenreName("乡村").ID.ToString(), Artist = _GetArtistByArtistName("华晨宇"), ArtistId = _GetArtistByArtistName("华晨宇").ID.ToString()},
                new Album () { Title="安徒生不后悔" , Price = 8.8m,Genre = _GetGenreByGenreName("说唱"), GenreId = _GetGenreByGenreName("说唱").ID.ToString(), Artist = _GetArtistByArtistName("蔡健雅"), ArtistId = _GetArtistByArtistName("蔡健雅").ID.ToString()},
                new Album () { Title="看不见的风景" , Price = 8.7m,Genre = _GetGenreByGenreName("摇滚"), GenreId = _GetGenreByGenreName("摇滚").ID.ToString(), Artist = _GetArtistByArtistName("王以太"), ArtistId = _GetArtistByArtistName("王以太").ID.ToString()},
                new Album () { Title="你比从前快乐" , Price = 8.6m,Genre = _GetGenreByGenreName("古典"), GenreId = _GetGenreByGenreName("古典").ID.ToString(), Artist = _GetArtistByArtistName("The Chainsmokers"), ArtistId = _GetArtistByArtistName("The Chainsmokers").ID.ToString()},
                new Album () { Title="不潮不用花钱" , Price = 8.5m,Genre = _GetGenreByGenreName("爵士"), GenreId = _GetGenreByGenreName("爵士").ID.ToString(), Artist = _GetArtistByArtistName("马雨阳"), ArtistId = _GetArtistByArtistName("马雨阳").ID.ToString()},
                new Album () { Title="只对你有感觉" , Price = 8.4m,Genre = _GetGenreByGenreName("舞曲"), GenreId = _GetGenreByGenreName("舞曲").ID.ToString(), Artist = _GetArtistByArtistName("徐秉龙"), ArtistId = _GetArtistByArtistName("徐秉龙").ID.ToString()},
                new Album () { Title="会有那么一天" , Price = 8.3m,Genre = _GetGenreByGenreName("Soul"), GenreId = _GetGenreByGenreName("Soul").ID.ToString(), Artist = _GetArtistByArtistName("毛不易"), ArtistId = _GetArtistByArtistName("毛不易").ID.ToString()},
                new Album () { Title="让我心动的人" ,Price = 4.9m,Genre = _GetGenreByGenreName("轻音乐"), GenreId = _GetGenreByGenreName("轻音乐").ID.ToString(), Artist = _GetArtistByArtistName("房东的猫"), ArtistId = _GetArtistByArtistName("房东的猫").ID.ToString()},
                new Album () { Title="真材实料的我" , Price = 8.2m,Genre = _GetGenreByGenreName("电子"), GenreId = _GetGenreByGenreName("电子").ID.ToString(), Artist = _GetArtistByArtistName("艾热"), ArtistId = _GetArtistByArtistName("艾热").ID.ToString()},
                new Album () { Title="你要的不是我" , Price = 8.1m,Genre = _GetGenreByGenreName("流行"), GenreId = _GetGenreByGenreName("流行").ID.ToString(), Artist = _GetArtistByArtistName("许嵩"), ArtistId = _GetArtistByArtistName("许嵩").ID.ToString()},
                new Album () { Title="半梦半醒之间" , Price = 7.9m,Genre = _GetGenreByGenreName("英伦"), GenreId = _GetGenreByGenreName("英伦").ID.ToString(), Artist = _GetArtistByArtistName("王力宏"), ArtistId = _GetArtistByArtistName("王力宏").ID.ToString()},
                new Album () { Title="大男人，小女孩" , Price = 6.9m,Genre = _GetGenreByGenreName("民族"), GenreId = _GetGenreByGenreName("民族").ID.ToString(), Artist = _GetArtistByArtistName("田馥甄"), ArtistId = _GetArtistByArtistName("田馥甄").ID.ToString()},
                new Album () { Title="第几个一百天" , Price = 5.9m,Genre = _GetGenreByGenreName("民谣"), GenreId = _GetGenreByGenreName("民谣").ID.ToString(), Artist = _GetArtistByArtistName("Charlie Puth"), ArtistId = _GetArtistByArtistName("Charlie Puth").ID.ToString()},

                new Album () { Title = "听不懂没关系", Price = 8.9m,Genre = _GetGenreByGenreName("乡村"), GenreId = _GetGenreByGenreName("乡村").ID.ToString(), Artist = _GetArtistByArtistName("华晨宇"), ArtistId = _GetArtistByArtistName("华晨宇").ID.ToString()},
                new Album () { Title="不流泪的机场" , Price = 8.8m,Genre = _GetGenreByGenreName("说唱"), GenreId = _GetGenreByGenreName("说唱").ID.ToString(), Artist = _GetArtistByArtistName("蔡健雅"), ArtistId = _GetArtistByArtistName("蔡健雅").ID.ToString()},
                new Album () { Title="我们的纪念日" , Price = 8.7m,Genre = _GetGenreByGenreName("摇滚"), GenreId = _GetGenreByGenreName("摇滚").ID.ToString(), Artist = _GetArtistByArtistName("王以太"), ArtistId = _GetArtistByArtistName("王以太").ID.ToString()},
                new Album () { Title="不分手的恋爱" , Price = 8.6m,Genre = _GetGenreByGenreName("古典"), GenreId = _GetGenreByGenreName("古典").ID.ToString(), Artist = _GetArtistByArtistName("The Chainsmokers"), ArtistId = _GetArtistByArtistName("The Chainsmokers").ID.ToString()},
                new Album () { Title="在回忆中死去" , Price = 8.5m,Genre = _GetGenreByGenreName("爵士"), GenreId = _GetGenreByGenreName("爵士").ID.ToString(), Artist = _GetArtistByArtistName("马雨阳"), ArtistId = _GetArtistByArtistName("马雨阳").ID.ToString()},
                new Album () { Title="会长大的幸福" , Price = 8.4m,Genre = _GetGenreByGenreName("舞曲"), GenreId = _GetGenreByGenreName("舞曲").ID.ToString(), Artist = _GetArtistByArtistName("徐秉龙"), ArtistId = _GetArtistByArtistName("徐秉龙").ID.ToString()},
                new Album () { Title="思念是一种病" , Price = 8.3m,Genre = _GetGenreByGenreName("Soul"), GenreId = _GetGenreByGenreName("Soul").ID.ToString(), Artist = _GetArtistByArtistName("毛不易"), ArtistId = _GetArtistByArtistName("毛不易").ID.ToString()},
                new Album () { Title="一场游戏一场梦" ,Price = 4.9m,Genre = _GetGenreByGenreName("轻音乐"), GenreId = _GetGenreByGenreName("轻音乐").ID.ToString(), Artist = _GetArtistByArtistName("房东的猫"), ArtistId = _GetArtistByArtistName("房东的猫").ID.ToString()},
                new Album () { Title="谁的眼泪在飞" , Price = 8.2m,Genre = _GetGenreByGenreName("电子"), GenreId = _GetGenreByGenreName("电子").ID.ToString(), Artist = _GetArtistByArtistName("艾热"), ArtistId = _GetArtistByArtistName("艾热").ID.ToString()},
                new Album () { Title="不能和你分手" , Price = 8.1m,Genre = _GetGenreByGenreName("流行"), GenreId = _GetGenreByGenreName("流行").ID.ToString(), Artist = _GetArtistByArtistName("许嵩"), ArtistId = _GetArtistByArtistName("许嵩").ID.ToString()},
                new Album () { Title="一个人的行李" , Price = 7.9m,Genre = _GetGenreByGenreName("英伦"), GenreId = _GetGenreByGenreName("英伦").ID.ToString(), Artist = _GetArtistByArtistName("王力宏"), ArtistId = _GetArtistByArtistName("王力宏").ID.ToString()},
                new Album () { Title="只要有你孙楠" , Price = 6.9m,Genre = _GetGenreByGenreName("民族"), GenreId = _GetGenreByGenreName("民族").ID.ToString(), Artist = _GetArtistByArtistName("田馥甄"), ArtistId = _GetArtistByArtistName("田馥甄").ID.ToString()},
                new Album () { Title="两个人的荒岛" , Price = 5.9m,Genre = _GetGenreByGenreName("民谣"), GenreId = _GetGenreByGenreName("民谣").ID.ToString(), Artist = _GetArtistByArtistName("Charlie Puth"), ArtistId = _GetArtistByArtistName("Charlie Puth").ID.ToString()},

                new Album () { Title = "你是我的眼林", Price = 8.9m,Genre = _GetGenreByGenreName("乡村"), GenreId = _GetGenreByGenreName("乡村").ID.ToString(), Artist = _GetArtistByArtistName("华晨宇"), ArtistId = _GetArtistByArtistName("华晨宇").ID.ToString()},
                new Album () { Title="冬天里的一把火" , Price = 8.8m,Genre = _GetGenreByGenreName("说唱"), GenreId = _GetGenreByGenreName("说唱").ID.ToString(), Artist = _GetArtistByArtistName("蔡健雅"), ArtistId = _GetArtistByArtistName("蔡健雅").ID.ToString()},
                new Album () { Title="寂寞寂寞就好" , Price = 8.7m,Genre = _GetGenreByGenreName("摇滚"), GenreId = _GetGenreByGenreName("摇滚").ID.ToString(), Artist = _GetArtistByArtistName("王以太"), ArtistId = _GetArtistByArtistName("王以太").ID.ToString()},
                new Album () { Title="我能够抱你吗" , Price = 8.6m,Genre = _GetGenreByGenreName("古典"), GenreId = _GetGenreByGenreName("古典").ID.ToString(), Artist = _GetArtistByArtistName("The Chainsmokers"), ArtistId = _GetArtistByArtistName("The Chainsmokers").ID.ToString()},
                new Album () { Title="爱一个人好难" , Price = 8.5m,Genre = _GetGenreByGenreName("爵士"), GenreId = _GetGenreByGenreName("爵士").ID.ToString(), Artist = _GetArtistByArtistName("马雨阳"), ArtistId = _GetArtistByArtistName("马雨阳").ID.ToString()},
                new Album () { Title="那女孩对我说" , Price = 8.4m,Genre = _GetGenreByGenreName("舞曲"), GenreId = _GetGenreByGenreName("舞曲").ID.ToString(), Artist = _GetArtistByArtistName("徐秉龙"), ArtistId = _GetArtistByArtistName("徐秉龙").ID.ToString()},
                new Album () { Title="最重要的决定" , Price = 8.3m,Genre = _GetGenreByGenreName("Soul"), GenreId = _GetGenreByGenreName("Soul").ID.ToString(), Artist = _GetArtistByArtistName("毛不易"), ArtistId = _GetArtistByArtistName("毛不易").ID.ToString()},
                new Album () { Title="当爱已成往事" ,Price = 4.9m,Genre = _GetGenreByGenreName("轻音乐"), GenreId = _GetGenreByGenreName("轻音乐").ID.ToString(), Artist = _GetArtistByArtistName("房东的猫"), ArtistId = _GetArtistByArtistName("房东的猫").ID.ToString()},
                new Album () { Title="越长大越孤单" , Price = 8.2m,Genre = _GetGenreByGenreName("电子"), GenreId = _GetGenreByGenreName("电子").ID.ToString(), Artist = _GetArtistByArtistName("艾热"), ArtistId = _GetArtistByArtistName("艾热").ID.ToString()},
                new Album () { Title="轻轻的告诉你" , Price = 8.1m,Genre = _GetGenreByGenreName("流行"), GenreId = _GetGenreByGenreName("流行").ID.ToString(), Artist = _GetArtistByArtistName("许嵩"), ArtistId = _GetArtistByArtistName("许嵩").ID.ToString()},
                new Album () { Title="恰似你的温柔" , Price = 7.9m,Genre = _GetGenreByGenreName("英伦"), GenreId = _GetGenreByGenreName("英伦").ID.ToString(), Artist = _GetArtistByArtistName("王力宏"), ArtistId = _GetArtistByArtistName("王力宏").ID.ToString()},
                new Album () { Title="自己的歌" , Price = 6.9m,Genre = _GetGenreByGenreName("民族"), GenreId = _GetGenreByGenreName("民族").ID.ToString(), Artist = _GetArtistByArtistName("田馥甄"), ArtistId = _GetArtistByArtistName("田馥甄").ID.ToString()},
                new Album () { Title="路人" , Price = 5.9m,Genre = _GetGenreByGenreName("民谣"), GenreId = _GetGenreByGenreName("民谣").ID.ToString(), Artist = _GetArtistByArtistName("Charlie Puth"), ArtistId = _GetArtistByArtistName("Charlie Puth").ID.ToString()},
            }.ForEach(g=>_dbMusicContext.Albums.Add(g));
            _dbMusicContext.SaveChanges();
        }

        static Genre _GetGenreByGenreName(string name)
        {
            return _dbMusicContext.Genres.Single(g => g.Name == name);
        }
        static Artist _GetArtistByArtistName(string name)
        {
            return _dbMusicContext.Artists.Single(g => g.Name == name);
        }
    }
}
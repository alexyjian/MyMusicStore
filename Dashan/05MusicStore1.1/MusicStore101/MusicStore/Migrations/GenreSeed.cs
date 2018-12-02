﻿using System;
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
            _dbContext.Database.ExecuteSqlCommand("delete genres");
            _dbContext.Database.ExecuteSqlCommand("delete artists");
            _dbContext.Database.ExecuteSqlCommand("delete albums");

            var genres = new List<Genre>()
            {
                new Genre() {Name = "摇滚",Description = "Rock"},
                new Genre() {Name =  "爵士",Description = "Jazz"},
                new Genre() {Name =  "重金属",Description = "Metal"},
                new Genre() {Name =  "慢摇",Description = "DownTempo"},
                new Genre() {Name =  "蓝调",Description = "Blue"},
                new Genre() {Name =  "拉丁",Description = "Latin"},
                new Genre() {Name =  "流行",Description = "Pop"},
                new Genre() {Name =  "古典",Description = "Classical"},
                new Genre() {Name =  "DJ",Description = "DJ"},
                new Genre() {Name =  "嘻哈",Description = "HiHop"},
            };
            foreach (var g in genres)
                _dbContext.Genres.Add(g);


            var artists = new List<Artist>()
            {
                new Artist() {Name="charlie Puth",Sex=true,Description = "华宇乐坛著名歌手" },
                  new Artist() {Name="陈奕迅",Sex=false,Description = "华宇乐坛著名歌手" },
                   new Artist() {Name="李荣浩",Sex=true,Description = "华宇乐坛著名歌手" },
                  new Artist() {Name="薛之谦",Sex=false,Description = "华宇乐坛著名歌手" },
                   new Artist() {Name="半阳",Sex=true,Description = "华宇乐坛著名歌手" },
                  new Artist() {Name="李荣浩",Sex=false,Description = "华宇乐坛著名歌手" },
                   new Artist() {Name="胡彦斌",Sex=true,Description = "华宇乐坛著名歌手" },
                  new Artist() {Name="易烊千玺",Sex=false,Description = "华宇乐坛著名歌手" },
                   new Artist() {Name="李宇春",Sex=true,Description = "华宇乐坛著名歌手" },
                  new Artist() {Name="张杰",Sex=false,Description = "华宇乐坛著名歌手" },

                  new Artist() {Name="毛不易",Sex=true,Description = "华宇乐坛著名歌手" },
                  new Artist() {Name="蒋蒋",Sex=false,Description = "华宇乐坛著名歌手" },
                   new Artist() {Name="贺一航",Sex=true,Description = "华宇乐坛著名歌手" },
                  new Artist() {Name="王力宏",Sex=false,Description = "华宇乐坛著名歌手" },
                   new Artist() {Name="于文文",Sex=true,Description = "华宇乐坛著名歌手" },
                  new Artist() {Name="许嵩",Sex=false,Description = "华宇乐坛著名歌手" },
                   new Artist() {Name="周传雄",Sex=true,Description = "华宇乐坛著名歌手" },
                  new Artist() {Name="黑龙",Sex=false,Description = "华宇乐坛著名歌手" },
                   new Artist() {Name="王嘉尔",Sex=true,Description = "华宇乐坛著名歌手" },
                  new Artist() {Name="吴亦凡",Sex=false,Description = "华宇乐坛著名歌手" },

                  new Artist() {Name="周柏豪",Sex=true,Description = "华宇乐坛著名歌手" },
                  new Artist() {Name="杨坤",Sex=false,Description = "华宇乐坛著名歌手" },
                   new Artist() {Name="汪峰",Sex=true,Description = "华宇乐坛著名歌手" },
                  new Artist() {Name="郑源",Sex=false,Description = "华宇乐坛著名歌手" },
                   new Artist() {Name="朴树",Sex=true,Description = "华宇乐坛著名歌手" },
                  new Artist() {Name="王菲",Sex=false,Description = "华宇乐坛著名歌手" },
                   new Artist() {Name="周传雄",Sex=true,Description = "华宇乐坛著名歌手" },
                  new Artist() {Name="许巍",Sex=false,Description = "华宇乐坛著名歌手" },


            };

            foreach (var a in artists)
                _dbContext.Artists.Add(a);
            _dbContext.SaveChanges();

            new List<Album>
            {

                new Album
                {
                    Title = "The Best Of Men At Work", Genre = genres.Single(g => g.Name == "摇滚"),
                    Price = 9.33M, Artist = artists.Single(a=>a.Name=="charlie Puth"),AlbumaArtUrl ="/Content/Images/placeholder.gif" 
                },

                   new Album
                {
                    Title = "The Best Of Men Work", Genre = genres.Single(g => g.Name == "慢摇"),
                    Price = 9.33M, Artist = artists.Single(a=>a.Name=="杨坤"),AlbumaArtUrl ="/Content/Images/placeholder.gif"
                },

                //      new Album
                //{
                //    Title = "The BestAt Work", Genre = genres.Single(g => g.Name == "爵士"),
                //    Price = 9.33M, Artist = artists.Single(a=>a.Name=="charlie Puth"),AlbumaArtUrl ="/Content/Images/placeholder.gif"
                //},

                //         new Album
                //{
                //    Title = "The Best", Genre = genres.Single(g => g.Name == "爵士"),
                //    Price = 9.33M, Artist = artists.Single(a=>a.Name=="charlie Puth"),AlbumaArtUrl ="/Content/Images/placeholder.gif"
                //},

                //     new Album
                //{
                //    Title = "The Of Men At Work", Genre = genres.Single(g => g.Name == "蓝调"),
                //    Price = 9.33M, Artist = artists.Single(a=>a.Name=="杨坤"),AlbumaArtUrl ="/Content/Images/placeholder.gif"
                //},

                //        new Album
                //{
                //    Title = " Best Of Men At Work", Genre = genres.Single(g => g.Name == "蓝调"),
                //    Price = 9.33M, Artist = artists.Single(a=>a.Name=="杨坤"),AlbumaArtUrl ="/Content/Images/placeholder.gif"
                //},

                //    new Album
                //{
                //    Title = "The Best Of Men At", Genre = genres.Single(g => g.Name == "摇滚"),
                //    Price = 9.33M, Artist = artists.Single(a=>a.Name=="王力宏"),AlbumaArtUrl ="/Content/Images/placeholder.gif"
                //},

                //       new Album
                //{
                //    Title = "TheWork", Genre = genres.Single(g => g.Name == "蓝调"),
                //    Price = 9.33M, Artist = artists.Single(a=>a.Name=="王力宏"),AlbumaArtUrl ="/Content/Images/placeholder.gif"
                //},



                  //new Album {Title="2", Genre = genres.Single(g=>g.Name == "摇滚"), Price = 9.33M, Artist = artists.Single(a=>a.Name=="charlie Puth"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                  // new Album {Title="", Genre = genres.Single(g=>g.Name == "摇滚"), Price = 9.33M, Artist = artists.Single(a=>a.Name=="薛之谦"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                  //      new Album {Title="", Genre = genres.Single(g=>g.Name == "摇滚"), Price = 9.33M, Artist = artists.Single(a=>a.Name=="易烊千玺"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                  // new Album {Title="", Genre = genres.Single(g=>g.Name == "摇滚"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="周杰伦"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                  //           new Album {Title="",Genre = genres.Single(g=>g.Name == "摇滚"),Price = 9.33M, Artist = artists.Single(a=>a.Name=="李荣浩"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //   new Album {Title="",Genre = genres.Single(g=>g.Name == "摇滚"),Price = 9.33M, Artist = artists.Single(a=>a.Name=="林俊杰"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //        new Album {Title="",Genre = genres.Single(g=>g.Name == "摇滚"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="半阳"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //   new Album {Title="",Genre = genres.Single(g=>g.Name == "摇滚"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="陈奕迅"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //             new Album {Title="",Genre = genres.Single(g=>g.Name == "摇滚"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="毛不易"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //   new Album {Title="",Genre = genres.Single(g=>g.Name == "爵士"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="庄心妍"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //        new Album {Title="",Genre = genres.Single(g=>g.Name == "爵士"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="胡彦斌"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //   new Album {Title="",Genre = genres.Single(g=>g.Name == "爵士"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="张韶涵"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //             new Album {Title="",Genre = genres.Single(g=>g.Name == "爵士"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="张学友"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //   new Album {Title="",Genre = genres.Single(g=>g.Name == "爵士"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="빅뱅"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //        new Album {Title="",Genre = genres.Single(g=>g.Name == "爵士"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="蒋蒋"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //   new Album {Title="",Genre = genres.Single(g=>g.Name == "爵士"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="蒋家驹"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //             new Album {Title="",Genre = genres.Single(g=>g.Name == "爵士"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="刘德华"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //   new Album {Title="",Genre = genres.Single(g=>g.Name == "爵士"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="李宇春"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //        new Album {Title="",Genre = genres.Single(g=>g.Name == "爵士"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="冯提莫"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //   new Album {Title="",Genre = genres.Single(g=>g.Name == "慢摇"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="张杰"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //             new Album {Title="",Genre = genres.Single(g=>g.Name == "慢摇"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="于文文"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //   new Album {Title="",Genre = genres.Single(g=>g.Name == "慢摇"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="王力宏"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //        new Album {Title="",Genre = genres.Single(g=>g.Name == "慢摇"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="许嵩"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //   new Album {Title="",Genre = genres.Single(g=>g.Name == "慢摇"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="简弘亦"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //        new Album {Title="",Genre = genres.Single(g=>g.Name == "慢摇"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="黑龙"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //   new Album {Title="",Genre = genres.Single(g=>g.Name == "慢摇"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="贺一航"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //        new Album {Title="",Genre = genres.Single(g=>g.Name == "慢摇"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="金玟岐"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //   new Album {Title="",Genre = genres.Single(g=>g.Name == "慢摇"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="周传雄"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //             new Album {Title="",Genre = genres.Single(g=>g.Name == "慢摇"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="王嘉尔"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //   new Album {Title="",Genre = genres.Single(g=>g.Name == "慢摇"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="吴亦凡"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //        new Album {Title="",Genre = genres.Single(g=>g.Name == "蓝调"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="周柏豪"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //   new Album {Title="",Genre = genres.Single(g=>g.Name == "蓝调"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="杨坤"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //             new Album {Title="",Genre = genres.Single(g=>g.Name == "蓝调"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="汪峰"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //   new Album {Title="",Genre = genres.Single(g=>g.Name == "蓝调"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="郑源"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //        new Album {Title="",Genre = genres.Single(g=>g.Name == "蓝调"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="朴树"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //   new Album {Title="",Genre = genres.Single(g=>g.Name == "蓝调"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="王菲"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //             new Album {Title="",Genre = genres.Single(g=>g.Name == "蓝调"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="许巍"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //   new Album {Title="",Genre = genres.Single(g=>g.Name == "蓝调"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="王力宏"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //        new Album {Title="",Genre = genres.Single(g=>g.Name == "蓝调"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="王力宏"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //   new Album {Title="",Genre = genres.Single(g=>g.Name == "蓝调"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="王力宏"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //             new Album {Title="",Genre = genres.Single(g=>g.Name == "流行"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="王力宏"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //   new Album {Title="",Genre = genres.Single(g=>g.Name == "流行"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="王力宏"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //        new Album {Title="",Genre = genres.Single(g=>g.Name == "流行"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="王力宏"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //   new Album {Title="",Genre = genres.Single(g=>g.Name == "流行"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="王力宏"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //             new Album {Title="",Genre = genres.Single(g=>g.Name == "流行"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="王力宏"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //   new Album {Title="",Genre = genres.Single(g=>g.Name == "流行"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="王力宏"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //        new Album {Title="",Genre = genres.Single(g=>g.Name == "流行"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="王力宏"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //   new Album {Title="",Genre = genres.Single(g=>g.Name == "流行"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="王力宏"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //            new Album {Title="",Genre = genres.Single(g=>g.Name == "流行"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="王力宏"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //   new Album {Title="",Genre = genres.Single(g=>g.Name == "流行"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="王菲"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //        new Album {Title="",Genre = genres.Single(g=>g.Name == "嘻哈"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="王菲"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //   new Album {Title="",Genre = genres.Single(g=>g.Name == "嘻哈"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="王菲"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //             new Album {Title="",Genre = genres.Single(g=>g.Name == "嘻哈"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="王菲"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //   new Album {Title="",Genre = genres.Single(g=>g.Name == "嘻哈"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="王菲"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //        new Album {Title="",Genre = genres.Single(g=>g.Name == "嘻哈"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="王菲"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //   new Album {Title="",Genre = genres.Single(g=>g.Name == "嘻哈"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="王菲"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //             new Album {Title="",Genre = genres.Single(g=>g.Name == "嘻哈"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="王菲"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //   new Album {Title="",Genre = genres.Single(g=>g.Name == "嘻哈"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="朴树"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //        new Album {Title="",Genre = genres.Single(g=>g.Name == "嘻哈"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="朴树"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //   new Album {Title="",Genre = genres.Single(g=>g.Name == "古典"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="朴树"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //      new Album {Title="",Genre = genres.Single(g=>g.Name == "古典"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="朴树"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //      new Album {Title="",Genre = genres.Single(g=>g.Name == "古典"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="朴树"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //      new Album {Title="",Genre = genres.Single(g=>g.Name == "古典"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="朴树"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //      new Album {Title="",Genre = genres.Single(g=>g.Name == "古典"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="朴树"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //      new Album {Title="",Genre = genres.Single(g=>g.Name == "古典"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="朴树"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //      new Album {Title="",Genre = genres.Single(g=>g.Name == "古典"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="朴树"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //      new Album {Title="",Genre = genres.Single(g=>g.Name == "古典"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="简弘亦"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //      new Album {Title="",Genre = genres.Single(g=>g.Name == "古典"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="简弘亦"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //      new Album {Title="",Genre = genres.Single(g=>g.Name == "古典"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="简弘亦"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //      new Album {Title="",Genre = genres.Single(g=>g.Name == "重金属"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="简弘亦"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //      new Album {Title="",Genre = genres.Single(g=>g.Name == "重金属"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="简弘亦"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //          new Album {Title="",Genre = genres.Single(g=>g.Name == "重金属"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="简弘亦"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //      new Album {Title="",Genre = genres.Single(g=>g.Name == "重金属"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="简弘亦"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //       new Album {Title="",Genre = genres.Single(g=>g.Name == "重金属"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="简弘亦"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //      new Album {Title="",Genre = genres.Single(g=>g.Name == "重金属"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="简弘亦"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //          new Album {Title="",Genre = genres.Single(g=>g.Name == "重金属"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="简弘亦"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //      new Album {Title="",Genre = genres.Single(g=>g.Name == "重金属"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="简弘亦"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //       new Album {Title="",Genre = genres.Single(g=>g.Name == "重金属"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="简弘亦"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //      new Album {Title="",Genre = genres.Single(g=>g.Name == "重金属"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="简弘亦"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //          new Album {Title="",Genre = genres.Single(g=>g.Name == "DJ"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="빅뱅"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //      new Album {Title="",Genre = genres.Single(g=>g.Name == "DJ"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="빅뱅"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //         new Album {Title="",Genre = genres.Single(g=>g.Name == "DJ"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="빅뱅"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //      new Album {Title="",Genre = genres.Single(g=>g.Name == "DJ"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="빅뱅"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //         new Album {Title="",Genre = genres.Single(g=>g.Name == "DJ"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="빅뱅"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //      new Album {Title="",Genre = genres.Single(g=>g.Name == "DJ"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="빅뱅"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //    new Album {Title="",Genre = genres.Single(g=>g.Name == "DJ"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="빅뱅"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //      new Album {Title="",Genre = genres.Single(g=>g.Name == "DJ"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="빅뱅"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //         new Album {Title="",Genre = genres.Single(g=>g.Name == "DJ"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="薛之谦"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //      new Album {Title="",Genre = genres.Single(g=>g.Name == "DJ"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="薛之谦"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //         new Album {Title="",Genre = genres.Single(g=>g.Name == "拉丁"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="薛之谦"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //      new Album {Title="",Genre = genres.Single(g=>g.Name == "拉丁"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="薛之谦"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //        new Album {Title="",Genre = genres.Single(g=>g.Name == "拉丁"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="薛之谦"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //      new Album {Title="",Genre = genres.Single(g=>g.Name == "拉丁"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="薛之谦"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //        new Album {Title="",Genre = genres.Single(g=>g.Name == "拉丁"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="李荣浩"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //      new Album {Title="",Genre = genres.Single(g=>g.Name == "拉丁"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="李荣浩"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //        new Album {Title="",Genre = genres.Single(g=>g.Name == "拉丁"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="李荣浩"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //      new Album {Title="",Genre = genres.Single(g=>g.Name == "拉丁"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="李荣浩"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //        new Album {Title="",Genre = genres.Single(g=>g.Name == "拉丁"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="李荣浩"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //      new Album {Title="",Genre = genres.Single(g=>g.Name == "拉丁"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="李荣浩"),AlbumaArtUrl ="/Content/Images/placeholder.gif" }, new Album {Title="1", Genre = genres.Single(g=>g.Name == "摇滚"), Price = 9.33M, Artist = artists.Single(a=>a.Name=="charlie Puth"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //  new Album {Title="2", Genre = genres.Single(g=>g.Name == "摇滚"), Price = 9.33M, Artist = artists.Single(a=>a.Name=="charlie Puth"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //   new Album {Title="", Genre = genres.Single(g=>g.Name == "摇滚"), Price = 9.33M, Artist = artists.Single(a=>a.Name=="薛之谦"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //        new Album {Title="", Genre = genres.Single(g=>g.Name == "摇滚"), Price = 9.33M, Artist = artists.Single(a=>a.Name=="易烊千玺"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //   new Album {Title="", Genre = genres.Single(g=>g.Name == "摇滚"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="周杰伦"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //             new Album {Title="",Genre = genres.Single(g=>g.Name == "摇滚"),Price = 9.33M, Artist = artists.Single(a=>a.Name=="李荣浩"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //   new Album {Title="",Genre = genres.Single(g=>g.Name == "摇滚"),Price = 9.33M, Artist = artists.Single(a=>a.Name=="林俊杰"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //        new Album {Title="",Genre = genres.Single(g=>g.Name == "摇滚"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="半阳"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //   new Album {Title="",Genre = genres.Single(g=>g.Name == "摇滚"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="陈奕迅"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //             new Album {Title="",Genre = genres.Single(g=>g.Name == "摇滚"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="毛不易"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //   new Album {Title="",Genre = genres.Single(g=>g.Name == "爵士"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="庄心妍"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //        new Album {Title="",Genre = genres.Single(g=>g.Name == "爵士"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="胡彦斌"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //   new Album {Title="",Genre = genres.Single(g=>g.Name == "爵士"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="张韶涵"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //             new Album {Title="",Genre = genres.Single(g=>g.Name == "爵士"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="张学友"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //   new Album {Title="",Genre = genres.Single(g=>g.Name == "爵士"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="빅뱅"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //        new Album {Title="",Genre = genres.Single(g=>g.Name == "爵士"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="蒋蒋"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //   new Album {Title="",Genre = genres.Single(g=>g.Name == "爵士"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="蒋家驹"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //             new Album {Title="",Genre = genres.Single(g=>g.Name == "爵士"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="刘德华"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //   new Album {Title="",Genre = genres.Single(g=>g.Name == "爵士"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="李宇春"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //        new Album {Title="",Genre = genres.Single(g=>g.Name == "爵士"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="冯提莫"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //   new Album {Title="",Genre = genres.Single(g=>g.Name == "慢摇"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="张杰"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //             new Album {Title="",Genre = genres.Single(g=>g.Name == "慢摇"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="于文文"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //   new Album {Title="",Genre = genres.Single(g=>g.Name == "慢摇"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="王力宏"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //        new Album {Title="",Genre = genres.Single(g=>g.Name == "慢摇"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="许嵩"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //   new Album {Title="",Genre = genres.Single(g=>g.Name == "慢摇"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="简弘亦"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //        new Album {Title="",Genre = genres.Single(g=>g.Name == "慢摇"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="黑龙"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //   new Album {Title="",Genre = genres.Single(g=>g.Name == "慢摇"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="贺一航"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //        new Album {Title="",Genre = genres.Single(g=>g.Name == "慢摇"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="金玟岐"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //   new Album {Title="",Genre = genres.Single(g=>g.Name == "慢摇"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="周传雄"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //             new Album {Title="",Genre = genres.Single(g=>g.Name == "慢摇"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="王嘉尔"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //   new Album {Title="",Genre = genres.Single(g=>g.Name == "慢摇"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="吴亦凡"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //        new Album {Title="",Genre = genres.Single(g=>g.Name == "蓝调"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="周柏豪"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //   new Album {Title="",Genre = genres.Single(g=>g.Name == "蓝调"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="杨坤"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //             new Album {Title="",Genre = genres.Single(g=>g.Name == "蓝调"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="汪峰"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //   new Album {Title="",Genre = genres.Single(g=>g.Name == "蓝调"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="郑源"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //        new Album {Title="",Genre = genres.Single(g=>g.Name == "蓝调"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="朴树"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //   new Album {Title="",Genre = genres.Single(g=>g.Name == "蓝调"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="王菲"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //             new Album {Title="",Genre = genres.Single(g=>g.Name == "蓝调"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="许巍"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //   new Album {Title="",Genre = genres.Single(g=>g.Name == "蓝调"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="王力宏"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //        new Album {Title="",Genre = genres.Single(g=>g.Name == "蓝调"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="王力宏"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //   new Album {Title="",Genre = genres.Single(g=>g.Name == "蓝调"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="王力宏"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //             new Album {Title="",Genre = genres.Single(g=>g.Name == "流行"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="王力宏"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //   new Album {Title="",Genre = genres.Single(g=>g.Name == "流行"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="王力宏"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //        new Album {Title="",Genre = genres.Single(g=>g.Name == "流行"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="王力宏"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //   new Album {Title="",Genre = genres.Single(g=>g.Name == "流行"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="王力宏"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //             new Album {Title="",Genre = genres.Single(g=>g.Name == "流行"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="王力宏"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //   new Album {Title="",Genre = genres.Single(g=>g.Name == "流行"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="王力宏"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //        new Album {Title="",Genre = genres.Single(g=>g.Name == "流行"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="王力宏"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //   new Album {Title="",Genre = genres.Single(g=>g.Name == "流行"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="王力宏"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //            new Album {Title="",Genre = genres.Single(g=>g.Name == "流行"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="王力宏"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //   new Album {Title="",Genre = genres.Single(g=>g.Name == "流行"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="王菲"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //        new Album {Title="",Genre = genres.Single(g=>g.Name == "嘻哈"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="王菲"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //   new Album {Title="",Genre = genres.Single(g=>g.Name == "嘻哈"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="王菲"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //             new Album {Title="",Genre = genres.Single(g=>g.Name == "嘻哈"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="王菲"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //   new Album {Title="",Genre = genres.Single(g=>g.Name == "嘻哈"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="王菲"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //        new Album {Title="",Genre = genres.Single(g=>g.Name == "嘻哈"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="王菲"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //   new Album {Title="",Genre = genres.Single(g=>g.Name == "嘻哈"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="王菲"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //             new Album {Title="",Genre = genres.Single(g=>g.Name == "嘻哈"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="王菲"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //   new Album {Title="",Genre = genres.Single(g=>g.Name == "嘻哈"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="朴树"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //        new Album {Title="",Genre = genres.Single(g=>g.Name == "嘻哈"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="朴树"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //   new Album {Title="",Genre = genres.Single(g=>g.Name == "古典"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="朴树"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //      new Album {Title="",Genre = genres.Single(g=>g.Name == "古典"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="朴树"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //      new Album {Title="",Genre = genres.Single(g=>g.Name == "古典"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="朴树"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //      new Album {Title="",Genre = genres.Single(g=>g.Name == "古典"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="朴树"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //      new Album {Title="",Genre = genres.Single(g=>g.Name == "古典"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="朴树"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //      new Album {Title="",Genre = genres.Single(g=>g.Name == "古典"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="朴树"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //      new Album {Title="",Genre = genres.Single(g=>g.Name == "古典"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="朴树"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //      new Album {Title="",Genre = genres.Single(g=>g.Name == "古典"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="简弘亦"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //      new Album {Title="",Genre = genres.Single(g=>g.Name == "古典"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="简弘亦"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //      new Album {Title="",Genre = genres.Single(g=>g.Name == "古典"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="简弘亦"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //      new Album {Title="",Genre = genres.Single(g=>g.Name == "重金属"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="简弘亦"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //      new Album {Title="",Genre = genres.Single(g=>g.Name == "重金属"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="简弘亦"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //          new Album {Title="",Genre = genres.Single(g=>g.Name == "重金属"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="简弘亦"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //      new Album {Title="",Genre = genres.Single(g=>g.Name == "重金属"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="简弘亦"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //       new Album {Title="",Genre = genres.Single(g=>g.Name == "重金属"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="简弘亦"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //      new Album {Title="",Genre = genres.Single(g=>g.Name == "重金属"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="简弘亦"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //          new Album {Title="",Genre = genres.Single(g=>g.Name == "重金属"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="简弘亦"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //      new Album {Title="",Genre = genres.Single(g=>g.Name == "重金属"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="简弘亦"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //       new Album {Title="",Genre = genres.Single(g=>g.Name == "重金属"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="简弘亦"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //      new Album {Title="",Genre = genres.Single(g=>g.Name == "重金属"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="简弘亦"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //          new Album {Title="",Genre = genres.Single(g=>g.Name == "DJ"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="빅뱅"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //      new Album {Title="",Genre = genres.Single(g=>g.Name == "DJ"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="빅뱅"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //         new Album {Title="",Genre = genres.Single(g=>g.Name == "DJ"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="빅뱅"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //      new Album {Title="",Genre = genres.Single(g=>g.Name == "DJ"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="빅뱅"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //         new Album {Title="",Genre = genres.Single(g=>g.Name == "DJ"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="빅뱅"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //      new Album {Title="",Genre = genres.Single(g=>g.Name == "DJ"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="빅뱅"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //    new Album {Title="",Genre = genres.Single(g=>g.Name == "DJ"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="빅뱅"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //      new Album {Title="",Genre = genres.Single(g=>g.Name == "DJ"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="빅뱅"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //         new Album {Title="",Genre = genres.Single(g=>g.Name == "DJ"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="薛之谦"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //      new Album {Title="",Genre = genres.Single(g=>g.Name == "DJ"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="薛之谦"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //         new Album {Title="",Genre = genres.Single(g=>g.Name == "拉丁"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="薛之谦"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //      new Album {Title="",Genre = genres.Single(g=>g.Name == "拉丁"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="薛之谦"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //        new Album {Title="",Genre = genres.Single(g=>g.Name == "拉丁"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="薛之谦"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //      new Album {Title="",Genre = genres.Single(g=>g.Name == "拉丁"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="薛之谦"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //        new Album {Title="",Genre = genres.Single(g=>g.Name == "拉丁"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="李荣浩"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //      new Album {Title="",Genre = genres.Single(g=>g.Name == "拉丁"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="李荣浩"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //        new Album {Title="",Genre = genres.Single(g=>g.Name == "拉丁"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="李荣浩"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //      new Album {Title="",Genre = genres.Single(g=>g.Name == "拉丁"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="李荣浩"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //        new Album {Title="",Genre = genres.Single(g=>g.Name == "拉丁"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="李荣浩"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //      new Album {Title="",Genre = genres.Single(g=>g.Name == "拉丁"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="李荣浩"),AlbumaArtUrl ="/Content/Images/placeholder.gif" }, new Album {Title="1", Genre = genres.Single(g=>g.Name == "摇滚"), Price = 9.33M, Artist = artists.Single(a=>a.Name=="charlie Puth"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //  new Album {Title="2", Genre = genres.Single(g=>g.Name == "摇滚"), Price = 9.33M, Artist = artists.Single(a=>a.Name=="charlie Puth"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //   new Album {Title="", Genre = genres.Single(g=>g.Name == "摇滚"), Price = 9.33M, Artist = artists.Single(a=>a.Name=="薛之谦"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //        new Album {Title="", Genre = genres.Single(g=>g.Name == "摇滚"), Price = 9.33M, Artist = artists.Single(a=>a.Name=="易烊千玺"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //   new Album {Title="", Genre = genres.Single(g=>g.Name == "摇滚"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="周杰伦"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //             new Album {Title="",Genre = genres.Single(g=>g.Name == "摇滚"),Price = 9.33M, Artist = artists.Single(a=>a.Name=="李荣浩"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //   new Album {Title="",Genre = genres.Single(g=>g.Name == "摇滚"),Price = 9.33M, Artist = artists.Single(a=>a.Name=="林俊杰"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //        new Album {Title="",Genre = genres.Single(g=>g.Name == "摇滚"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="半阳"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //   new Album {Title="",Genre = genres.Single(g=>g.Name == "摇滚"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="陈奕迅"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //             new Album {Title="",Genre = genres.Single(g=>g.Name == "摇滚"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="毛不易"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //   new Album {Title="",Genre = genres.Single(g=>g.Name == "爵士"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="庄心妍"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //        new Album {Title="",Genre = genres.Single(g=>g.Name == "爵士"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="胡彦斌"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //   new Album {Title="",Genre = genres.Single(g=>g.Name == "爵士"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="张韶涵"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //             new Album {Title="",Genre = genres.Single(g=>g.Name == "爵士"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="张学友"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //   new Album {Title="",Genre = genres.Single(g=>g.Name == "爵士"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="빅뱅"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //        new Album {Title="",Genre = genres.Single(g=>g.Name == "爵士"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="蒋蒋"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //   new Album {Title="",Genre = genres.Single(g=>g.Name == "爵士"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="蒋家驹"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //             new Album {Title="",Genre = genres.Single(g=>g.Name == "爵士"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="刘德华"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //   new Album {Title="",Genre = genres.Single(g=>g.Name == "爵士"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="李宇春"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //        new Album {Title="",Genre = genres.Single(g=>g.Name == "爵士"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="冯提莫"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //   new Album {Title="",Genre = genres.Single(g=>g.Name == "慢摇"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="张杰"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //             new Album {Title="",Genre = genres.Single(g=>g.Name == "慢摇"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="于文文"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //   new Album {Title="",Genre = genres.Single(g=>g.Name == "慢摇"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="王力宏"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //        new Album {Title="",Genre = genres.Single(g=>g.Name == "慢摇"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="许嵩"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //   new Album {Title="",Genre = genres.Single(g=>g.Name == "慢摇"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="简弘亦"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //        new Album {Title="",Genre = genres.Single(g=>g.Name == "慢摇"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="黑龙"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //   new Album {Title="",Genre = genres.Single(g=>g.Name == "慢摇"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="贺一航"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //        new Album {Title="",Genre = genres.Single(g=>g.Name == "慢摇"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="金玟岐"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //   new Album {Title="",Genre = genres.Single(g=>g.Name == "慢摇"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="周传雄"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //             new Album {Title="",Genre = genres.Single(g=>g.Name == "慢摇"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="王嘉尔"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //   new Album {Title="",Genre = genres.Single(g=>g.Name == "慢摇"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="吴亦凡"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //        new Album {Title="",Genre = genres.Single(g=>g.Name == "蓝调"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="周柏豪"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //   new Album {Title="",Genre = genres.Single(g=>g.Name == "蓝调"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="杨坤"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //             new Album {Title="",Genre = genres.Single(g=>g.Name == "蓝调"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="汪峰"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //   new Album {Title="",Genre = genres.Single(g=>g.Name == "蓝调"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="郑源"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //        new Album {Title="",Genre = genres.Single(g=>g.Name == "蓝调"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="朴树"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //   new Album {Title="",Genre = genres.Single(g=>g.Name == "蓝调"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="王菲"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //             new Album {Title="",Genre = genres.Single(g=>g.Name == "蓝调"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="许巍"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //   new Album {Title="",Genre = genres.Single(g=>g.Name == "蓝调"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="王力宏"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //        new Album {Title="",Genre = genres.Single(g=>g.Name == "蓝调"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="王力宏"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //   new Album {Title="",Genre = genres.Single(g=>g.Name == "蓝调"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="王力宏"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //             new Album {Title="",Genre = genres.Single(g=>g.Name == "流行"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="王力宏"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //   new Album {Title="",Genre = genres.Single(g=>g.Name == "流行"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="王力宏"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //        new Album {Title="",Genre = genres.Single(g=>g.Name == "流行"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="王力宏"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //   new Album {Title="",Genre = genres.Single(g=>g.Name == "流行"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="王力宏"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //             new Album {Title="",Genre = genres.Single(g=>g.Name == "流行"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="王力宏"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //   new Album {Title="",Genre = genres.Single(g=>g.Name == "流行"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="王力宏"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //        new Album {Title="",Genre = genres.Single(g=>g.Name == "流行"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="王力宏"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //   new Album {Title="",Genre = genres.Single(g=>g.Name == "流行"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="王力宏"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //            new Album {Title="",Genre = genres.Single(g=>g.Name == "流行"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="王力宏"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //   new Album {Title="",Genre = genres.Single(g=>g.Name == "流行"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="王菲"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //        new Album {Title="",Genre = genres.Single(g=>g.Name == "嘻哈"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="王菲"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //   new Album {Title="",Genre = genres.Single(g=>g.Name == "嘻哈"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="王菲"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //             new Album {Title="",Genre = genres.Single(g=>g.Name == "嘻哈"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="王菲"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //   new Album {Title="",Genre = genres.Single(g=>g.Name == "嘻哈"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="王菲"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //        new Album {Title="",Genre = genres.Single(g=>g.Name == "嘻哈"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="王菲"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //   new Album {Title="",Genre = genres.Single(g=>g.Name == "嘻哈"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="王菲"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //             new Album {Title="",Genre = genres.Single(g=>g.Name == "嘻哈"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="王菲"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //   new Album {Title="",Genre = genres.Single(g=>g.Name == "嘻哈"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="朴树"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //        new Album {Title="",Genre = genres.Single(g=>g.Name == "嘻哈"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="朴树"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //   new Album {Title="",Genre = genres.Single(g=>g.Name == "古典"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="朴树"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //      new Album {Title="",Genre = genres.Single(g=>g.Name == "古典"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="朴树"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //      new Album {Title="",Genre = genres.Single(g=>g.Name == "古典"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="朴树"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //      new Album {Title="",Genre = genres.Single(g=>g.Name == "古典"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="朴树"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //      new Album {Title="",Genre = genres.Single(g=>g.Name == "古典"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="朴树"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //      new Album {Title="",Genre = genres.Single(g=>g.Name == "古典"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="朴树"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //      new Album {Title="",Genre = genres.Single(g=>g.Name == "古典"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="朴树"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //      new Album {Title="",Genre = genres.Single(g=>g.Name == "古典"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="简弘亦"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //      new Album {Title="",Genre = genres.Single(g=>g.Name == "古典"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="简弘亦"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //      new Album {Title="",Genre = genres.Single(g=>g.Name == "古典"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="简弘亦"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //      new Album {Title="",Genre = genres.Single(g=>g.Name == "重金属"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="简弘亦"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //      new Album {Title="",Genre = genres.Single(g=>g.Name == "重金属"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="简弘亦"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //          new Album {Title="",Genre = genres.Single(g=>g.Name == "重金属"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="简弘亦"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //      new Album {Title="",Genre = genres.Single(g=>g.Name == "重金属"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="简弘亦"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //       new Album {Title="",Genre = genres.Single(g=>g.Name == "重金属"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="简弘亦"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //      new Album {Title="",Genre = genres.Single(g=>g.Name == "重金属"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="简弘亦"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //          new Album {Title="",Genre = genres.Single(g=>g.Name == "重金属"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="简弘亦"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //      new Album {Title="",Genre = genres.Single(g=>g.Name == "重金属"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="简弘亦"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //       new Album {Title="",Genre = genres.Single(g=>g.Name == "重金属"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="简弘亦"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //      new Album {Title="",Genre = genres.Single(g=>g.Name == "重金属"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="简弘亦"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //          new Album {Title="",Genre = genres.Single(g=>g.Name == "DJ"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="빅뱅"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //      new Album {Title="",Genre = genres.Single(g=>g.Name == "DJ"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="빅뱅"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //         new Album {Title="",Genre = genres.Single(g=>g.Name == "DJ"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="빅뱅"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //      new Album {Title="",Genre = genres.Single(g=>g.Name == "DJ"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="빅뱅"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //         new Album {Title="",Genre = genres.Single(g=>g.Name == "DJ"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="빅뱅"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //      new Album {Title="",Genre = genres.Single(g=>g.Name == "DJ"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="빅뱅"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //    new Album {Title="",Genre = genres.Single(g=>g.Name == "DJ"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="빅뱅"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //      new Album {Title="",Genre = genres.Single(g=>g.Name == "DJ"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="빅뱅"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //         new Album {Title="",Genre = genres.Single(g=>g.Name == "DJ"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="薛之谦"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //      new Album {Title="",Genre = genres.Single(g=>g.Name == "DJ"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="薛之谦"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //         new Album {Title="",Genre = genres.Single(g=>g.Name == "拉丁"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="薛之谦"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //      new Album {Title="",Genre = genres.Single(g=>g.Name == "拉丁"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="薛之谦"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //        new Album {Title="",Genre = genres.Single(g=>g.Name == "拉丁"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="薛之谦"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //      new Album {Title="",Genre = genres.Single(g=>g.Name == "拉丁"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="薛之谦"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //        new Album {Title="",Genre = genres.Single(g=>g.Name == "拉丁"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="李荣浩"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //      new Album {Title="",Genre = genres.Single(g=>g.Name == "拉丁"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="李荣浩"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //        new Album {Title="",Genre = genres.Single(g=>g.Name == "拉丁"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="李荣浩"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //      new Album {Title="",Genre = genres.Single(g=>g.Name == "拉丁"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="李荣浩"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //        new Album {Title="",Genre = genres.Single(g=>g.Name == "拉丁"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="李荣浩"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },
                //      new Album {Title="",Genre = genres.Single(g=>g.Name == "拉丁"),Price = 9.33M,Artist = artists.Single(a=>a.Name=="李荣浩"),AlbumaArtUrl ="/Content/Images/placeholder.gif" },

            }.ForEach(n => _dbContext.Albums.Add(n));
            _dbContext.SaveChanges();
        }
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
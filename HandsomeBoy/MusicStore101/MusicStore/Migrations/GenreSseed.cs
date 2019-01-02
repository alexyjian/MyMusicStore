using MusicStoreEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace MusicStore.Migrations
{
    public class GenreSseed
    {
        private static readonly MusicStoreEntity.EntityDbContext _dbContext = new MusicStoreEntity.EntityDbContext();
        public static void Seed()
        {
            //_dbContext.Database.ExecuteSqlCommand("delete Albuns");
            //_dbContext.Database.ExecuteSqlCommand("delete Genres");
            //_dbContext.Database.ExecuteSqlCommand("delete Artists");

            var genres = new List<Genre>()
            {
                 new Genre() { Name = "摇滚",Desciption="Rack"},
                   new Genre() { Name = "DJ",Desciption="DJ"},
                     new Genre() { Name = "流行",Desciption="fashion"},
                       new Genre() { Name = "乡村",Desciption="country"},
                         new Genre() { Name = "爱情",Desciption="LOVE"},
                           new Genre() { Name = "伤感",Desciption="slop over"},
                             new Genre() { Name = "情歌",Desciption="love song"},
                              new Genre() { Name = "民歌",Desciption="love song"},
                               new Genre() { Name = "电音",Desciption="love song"},
            };
            foreach (var g in genres)
            {
                _dbContext.Genres.Add(g);
            }
            _dbContext.SaveChanges();

            var artists = new List<Artist>()
            {
                 new Artist() { Name="薛之谦",Sex = true,Description = "真的很帅" },

             new Artist() { Name = "张杰", Sex = true, Description = "真的很帅" },

             new Artist() { Name = "汪苏泷", Sex = true, Description = "真的很帅" },

             new Artist() { Name = "徐良", Sex = true, Description = "真的很帅" },

             new Artist() { Name = "张震岳", Sex = true, Description = "真的很帅" },

             new Artist() { Name = "热狗", Sex = true, Description = "著名嘻哈音乐人" },
             new Artist() { Name = "张学友", Sex = true, Description = "著名嘻哈音乐人" },
              new Artist() { Name = "刘德华", Sex = true, Description = "著名嘻哈音乐人" },
                new Artist() { Name = "毛不易", Sex = true, Description = "著名嘻哈音乐人" },
            };
            foreach (var a in artists)
                _dbContext.Artists.Add(a);
            _dbContext.SaveChanges();
            var albun = new List<Albun>()
            {
                new Albun() { Title="我听了你的声音",Price=50.50M,Genre=genres.Single(g=>g.Name=="伤感"),Artist = artists.Single(a=>a.Name=="薛之谦"),AlbumArtUrl = "/Content/Images/placeholder.gif"},
                new Albun() { Title="旧情绵绵",Price=50.50M,Genre=genres.Single(g=>g.Name=="DJ"),Artist = artists.Single(a=>a.Name=="张学友"),AlbumArtUrl = "/Content/Images/placeholder.gif" },
                new Albun() { Title="恋爱时代",Price=50.50M,Genre=genres.Single(g=>g.Name=="电音"),Artist = artists.Single(a=>a.Name=="徐良"),AlbumArtUrl = "/Content/Images/placeholder.gif"},
                new Albun() { Title="爱之初体验",Price=50.50M,Genre=genres.Single(g=>g.Name=="乡村"),Artist = artists.Single(a=>a.Name=="张震岳"),AlbumArtUrl = "/Content/Images/placeholder.gif"},
                new Albun() { Title="三国杀",Price=50.50M,Genre=genres.Single(g=>g.Name=="流行"),Artist = artists.Single(a=>a.Name=="汪苏泷"),AlbumArtUrl = "/Content/Images/placeholder.gif"},
                new Albun() { Title="这就是爱",Price=50.50M,Genre=genres.Single(g=>g.Name=="摇滚"),Artist = artists.Single(a=>a.Name=="张杰"),AlbumArtUrl = "/Content/Images/placeholder.gif"},
                new Albun() { Title="差不多的先生",Price=50.50M,Genre=genres.Single(g=>g.Name=="爱情"),Artist = artists.Single(a=>a.Name=="热狗"),AlbumArtUrl = "/Content/Images/placeholder.gif"},
                new Albun() { Title="上海滩",Price=50.50M,Genre=genres.Single(g=>g.Name=="民歌"),Artist = artists.Single(a=>a.Name=="刘德华"),AlbumArtUrl = "/Content/Images/placeholder.gif"},
                new Albun() { Title="像我这样的人",Price=50.50M,Genre=genres.Single(g=>g.Name=="情歌"),Artist = artists.Single(a=>a.Name=="毛不易"),AlbumArtUrl = "/Content/Images/placeholder.gif"},


                  new Albun() { Title="我想摸你的头发",Price=50.50M,Genre=genres.Single(g=>g.Name=="伤感"),Artist = artists.Single(a=>a.Name=="薛之谦"),AlbumArtUrl = "/Content/Images/placeholder.gif"},
                new Albun() { Title="只是简单的试探下",Price=50.50M,Genre=genres.Single(g=>g.Name=="DJ"),Artist = artists.Single(a=>a.Name=="张学友"),AlbumArtUrl = "/Content/Images/placeholder.gif" },
                new Albun() { Title="如果你也爱我",Price=50.50M,Genre=genres.Single(g=>g.Name=="电音"),Artist = artists.Single(a=>a.Name=="徐良"),AlbumArtUrl = "/Content/Images/placeholder.gif"},
                new Albun() { Title="那我们就手牵着手",Price=50.50M,Genre=genres.Single(g=>g.Name=="乡村"),Artist = artists.Single(a=>a.Name=="张震岳"),AlbumArtUrl = "/Content/Images/placeholder.gif"},
                new Albun() { Title="环游地球",Price=50.50M,Genre=genres.Single(g=>g.Name=="流行"),Artist = artists.Single(a=>a.Name=="汪苏泷"),AlbumArtUrl = "/Content/Images/placeholder.gif"},
                new Albun() { Title="享受这美好的时光",Price=50.50M,Genre=genres.Single(g=>g.Name=="摇滚"),Artist = artists.Single(a=>a.Name=="张杰"),AlbumArtUrl = "/Content/Images/placeholder.gif"},
                new Albun() { Title="你怎么那么好看",Price=50.50M,Genre=genres.Single(g=>g.Name=="爱情"),Artist = artists.Single(a=>a.Name=="热狗"),AlbumArtUrl = "/Content/Images/placeholder.gif"},
                new Albun() { Title="那么好看怎么办",Price=50.50M,Genre=genres.Single(g=>g.Name=="民歌"),Artist = artists.Single(a=>a.Name=="刘德华"),AlbumArtUrl = "/Content/Images/placeholder.gif"},
                new Albun() { Title="我想你了",Price=50.50M,Genre=genres.Single(g=>g.Name=="情歌"),Artist = artists.Single(a=>a.Name=="毛不易"),AlbumArtUrl = "/Content/Images/placeholder.gif"},
                  new Albun() { Title = "如果没有他", Price = 50.50M, Genre = genres.Single(g => g.Name == "伤感"), Artist = artists.Single(a => a.Name == "薛之谦"), AlbumArtUrl = "/Content/Images/placeholder.gif" },
                new Albun() { Title = "他说", Price = 50.50M, Genre = genres.Single(g => g.Name == "DJ"), Artist = artists.Single(a => a.Name == "张学友"), AlbumArtUrl = "/Content/Images/placeholder.gif" },
                new Albun() { Title = "可不可以", Price = 50.50M, Genre = genres.Single(g => g.Name == "电音"), Artist = artists.Single(a => a.Name == "徐良"), AlbumArtUrl = "/Content/Images/placeholder.gif" },
                new Albun() { Title = "一百万个可能", Price = 50.50M, Genre = genres.Single(g => g.Name == "乡村"), Artist = artists.Single(a => a.Name == "张震岳"), AlbumArtUrl = "/Content/Images/placeholder.gif" },
                new Albun() { Title = "这就是傻逼", Price = 50.50M, Genre = genres.Single(g => g.Name == "流行"), Artist = artists.Single(a => a.Name == "汪苏泷"), AlbumArtUrl = "/Content/Images/placeholder.gif" },
                new Albun() { Title = "你就是汉堡", Price = 50.50M, Genre = genres.Single(g => g.Name == "摇滚"), Artist = artists.Single(a => a.Name == "张杰"), AlbumArtUrl = "/Content/Images/placeholder.gif" },
                new Albun() { Title = "最可耐的不是你", Price = 50.50M, Genre = genres.Single(g => g.Name == "爱情"), Artist = artists.Single(a => a.Name == "热狗"), AlbumArtUrl = "/Content/Images/placeholder.gif" },
                new Albun() { Title = "是你的人就是你", Price = 50.50M, Genre = genres.Single(g => g.Name == "民歌"), Artist = artists.Single(a => a.Name == "刘德华"), AlbumArtUrl = "/Content/Images/placeholder.gif" },
                new Albun() { Title = "如果你没听说", Price = 50.50M, Genre = genres.Single(g => g.Name == "情歌"), Artist = artists.Single(a => a.Name == "毛不易"), AlbumArtUrl = "/Content/Images/placeholder.gif" },


           new Albun() { Title = "123木头人", Price = 50.50M, Genre = genres.Single(g => g.Name == "情歌"), Artist = artists.Single(a => a.Name == "毛不易"), AlbumArtUrl = "/Content/Images/placeholder.gif" },
                new Albun() { Title = "321木头人", Price = 50.50M, Genre = genres.Single(g => g.Name == "流行"), Artist = artists.Single(a => a.Name == "汪苏泷"), AlbumArtUrl = "/Content/Images/placeholder.gif" },
                new Albun() { Title = "如果没有他你会爱我吗", Price = 50.50M, Genre = genres.Single(g => g.Name == "摇滚"), Artist = artists.Single(a => a.Name == "张杰"), AlbumArtUrl = "/Content/Images/placeholder.gif" },
                new Albun() { Title = "我是你的前男友", Price = 50.50M, Genre = genres.Single(g => g.Name == "爱情"), Artist = artists.Single(a => a.Name == "热狗"), AlbumArtUrl = "/Content/Images/placeholder.gif" },
                new Albun() { Title = "钱女友", Price = 50.50M, Genre = genres.Single(g => g.Name == "民歌"), Artist = artists.Single(a => a.Name == "刘德华"), AlbumArtUrl = "/Content/Images/placeholder.gif" },
                new Albun() { Title = "可怕", Price = 50.50M, Genre = genres.Single(g => g.Name == "情歌"), Artist = artists.Single(a => a.Name == "毛不易"), AlbumArtUrl = "/Content/Images/placeholder.gif" },
                  new Albun() { Title = "难过", Price = 50.50M, Genre = genres.Single(g => g.Name == "伤感"), Artist = artists.Single(a => a.Name == "薛之谦"), AlbumArtUrl = "/Content/Images/placeholder.gif" },
                new Albun() { Title = "想哭", Price = 50.50M, Genre = genres.Single(g => g.Name == "DJ"), Artist = artists.Single(a => a.Name == "张学友"), AlbumArtUrl = "/Content/Images/placeholder.gif" },
                new Albun() { Title = "想笑", Price = 50.50M, Genre = genres.Single(g => g.Name == "电音"), Artist = artists.Single(a => a.Name == "徐良"), AlbumArtUrl = "/Content/Images/placeholder.gif" },
                new Albun() { Title = "爱国", Price = 50.50M, Genre = genres.Single(g => g.Name == "乡村"), Artist = artists.Single(a => a.Name == "张震岳"), AlbumArtUrl = "/Content/Images/placeholder.gif" },
                new Albun() { Title = "这就是中国馆", Price = 50.50M, Genre = genres.Single(g => g.Name == "流行"), Artist = artists.Single(a => a.Name == "汪苏泷"), AlbumArtUrl = "/Content/Images/placeholder.gif" },
                new Albun() { Title = "南宁", Price = 50.50M, Genre = genres.Single(g => g.Name == "摇滚"), Artist = artists.Single(a => a.Name == "张杰"), AlbumArtUrl = "/Content/Images/placeholder.gif" },
                new Albun() { Title = "柳州", Price = 50.50M, Genre = genres.Single(g => g.Name == "爱情"), Artist = artists.Single(a => a.Name == "热狗"), AlbumArtUrl = "/Content/Images/placeholder.gif" },
                new Albun() { Title = "小气", Price = 50.50M, Genre = genres.Single(g => g.Name == "民歌"), Artist = artists.Single(a => a.Name == "刘德华"), AlbumArtUrl = "/Content/Images/placeholder.gif" },
                new Albun() { Title = "狗叼", Price = 50.50M, Genre = genres.Single(g => g.Name == "情歌"), Artist = artists.Single(a => a.Name == "毛不易"), AlbumArtUrl = "/Content/Images/placeholder.gif" }
            };

            foreach (var a in albun)
                _dbContext.Albuns.Add(a);
            _dbContext.SaveChanges();

            //var my = new My()
            //{
            //    AddressPerson = "黄学明",
            //    Area = "广西南宁市马山县",
            //    MobiNumber = "18877213447",
            //    Email = "530615",
               
            //};
            //var my1 = new My()
            //{
            //    AddressPerson = "周仁发",
            //    Area = "广西南宁市123马山县",
            //    MobiNumber = "18877213447",
            //    Email = "53023615"
            //};
            //_dbContext.Mys.Add(my);
            //_dbContext.Mys.Add(my1);
            //_dbContext.SaveChanges();
        }

        public static void Extend()
        {
            var albums = _dbContext.Albuns.ToList();
            foreach (var album in albums)
            {
                var item = _dbContext.Albuns.Find(album.ID);
                item.GenreId = item.Genre.ID.ToString();
                item.ArtistId = item.Artist.ID.ToString();
                _dbContext.SaveChanges();
                Thread.Sleep(3);
            }
        }
    }
    }


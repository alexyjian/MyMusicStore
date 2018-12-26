﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MusicStoreEntity;
using MusicStoreEntity.UserAndRole;
using MusicStore.ViewMoldels;

namespace MusicStore.Controllers
{
    public class StoreController : Controller
    {
        /// <summary>
        /// 显示专辑明细
        /// </summary>
          private static readonly EntityDbContext  _context = new EntityDbContext();
        public ActionResult Detail(Guid id)
        {
            var detail = _context.Albums.Find(id);
            return View(detail);
        }


        /// <summary>
        /// 添加 回复、评论
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cmt"></param>
        /// <param name="reply"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]//关闭验证
        public ActionResult AddCmt (string id,string cmt,string reply)
        {

            //判断是否登录
            if (Session["loginUserSessionModel"] == null)
                return Json("nologin");

            //获取用户
            var person =_context.Persons.Find ((Session["LoginUserSessionModel"] as LoginUserSessionModel).Person.ID);
            var album = _context.Albums.Find(Guid.Parse(id));

            //创建回复对象
            var r= new Reply()
            {
                Album = album,
                Person = person,
                Content = cmt,
                Title = " "
            };

            if (string.IsNullOrEmpty(reply))
            {
                //顶级回复
                r.ReplyPlaries = null;
            }
            else
            {
                r.ReplyPlaries = _context.Plaries.Find(Guid.Parse(reply));
            }
            _context.Plaries.Add(r);
            _context.SaveChanges();
            return Json("OK");
        }


        /// <summary>
        /// 按分类显示专辑
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Browser(Guid id)
        {
            var list = _context.Albums.Where(x => x.Genre.ID == id).OrderByDescending(x => x.PublisherDate).ToList();
            return View(list);
        }

        /// <summary>
        /// 显示所有分类
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var genres = _context.Genres.OrderBy(x =>x.Name).ToList();
            return View(genres);//返回到视图
        }

    }
}
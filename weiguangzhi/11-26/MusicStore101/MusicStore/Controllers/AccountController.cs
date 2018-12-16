using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MusicStore.ViewModels;
using MusicStoreEntity;
using MusicStoreEntity.UserAndRole;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MusicStore.Controllers
{
    

    public class AccountController : Controller
    {
       
        /// <summary>
        /// 填写注册信息
        /// </summary>
        /// <returns></returns>
        // GET: Account
        public ActionResult Register()
        {
                 return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public ActionResult Register(RwgisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var person = new Person()
                {
                    FirstName = model.FullName.Substring(0, 1),
                    LastName = model.FullName.Substring(1, model.FullName.Length - 1),
                    Name = model.FullName,
                    CredentialsCode = "",
                    Birthday = DateTime.Now,
                    Sex = true,
                    MobileNumber = "18866668888",
                    Email = model.Email,
                    TelephoneNumber = "18866668888",
                    Description = "",
                    CreateDateTime = DateTime.Now,
                    UpdateTime = DateTime.Now,
                    InquiryPassword = "未设置",
                };
                var user = new ApplicationUser()
                {
                    UserName = model.UserName,
                    FirstName = model.FullName.Substring(0, 1),
                    LastName = model.FullName.Substring(1, model.FullName.Length - 1),
                    ChineseFullName = model.FullName,
                    MobileNumber = "18866668888",
                    Email = model.Email,
                    Person = person,
                };

                //是否要验证Email

                var idManager = new IdentityManager();
                idManager.CreateUser(user, model.PassWord);
                idManager.AddUserToRole(user.Id, "Admin");

                return Content("<script>alert('恭喜注册成功!');location.href='" + Url.Action("login", "Account") + "'</script>");
            }

            return View();
        }

        /// <summary>
        /// 登录方法
        /// </summary>
        /// <param name="returnUrl">登录成功后跳转地址</param>
        /// <returns></returns>
        public ActionResult Login(string returnUrl = null)
        {
            if (string.IsNullOrEmpty(returnUrl))
                ViewBag.ReturnUrl = Url.Action("index", "home");
            else
                ViewBag.ReturnUrl = returnUrl;

            return View();
        }

        [HttpPost]   //此Action用来接收用户提交
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            //判断实体是否校验通过
            if (ModelState.IsValid)
            {
                var loginStatus = new LoginUserStatus()
                {
                    IsLogin = false,
                    Message = "用户或密码错误",
                };
                //登录处理
                var userManage =
                    new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new EntityDbContext()));
                var user = userManage.Find(model.UserName, model.PassWord);
                if (user != null)
                {
                    var roleName = "";
                    var context = new EntityDbContext();
                    foreach (var role in user.Roles)
                    {
                        roleName += (context.Roles.Find(role.RoleId) as ApplicationRole).DisplayName + ",";
                    }

                    loginStatus.IsLogin = true;
                    loginStatus.Message = "登录成功！用户的角色：" + roleName;
                    loginStatus.GotoController = "home";
                    loginStatus.GotoAction = "index";
                    //把登录状态保存到会话
                    Session["loginStatus"] = loginStatus;

                    var loginUserSessionModel = new LoginUserSessionModel()
                    {
                        User = user,
                        Person = user.Person,
                        RoleName = roleName,
                    };
                    //把登录成功后用户信息保存到会话
                    Session["LoginUserSessionModel"] = loginUserSessionModel;

                    //identity登录处理,创建aspnet的登录令牌Token
                    var identity = userManage.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                    return Redirect(returnUrl);
                }
                else
                {
                    if (string.IsNullOrEmpty(returnUrl))
                        ViewBag.ReturnUrl = Url.Action("index", "home");
                    else
                        ViewBag.ReturnUrl = returnUrl;
                    ViewBag.LoginUserStatus = loginStatus;
                    return View();
                }
            }
            if (string.IsNullOrEmpty(returnUrl))
                ViewBag.ReturnUrl = Url.Action("index", "home");
            else
                ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        public ActionResult LoginOut()
        {
            Session.Remove("loginStatus");
            Session.Remove("LoginUserSessionModel");
            return RedirectToAction("index", "Home");
        }

        public ActionResult EditPw()
        {
            //    if (ModelState.IsValid)
            //    {
            //        var userManage =new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new EntityDbContext()));
            //        var pass = userManage.Find(model.PassWord, model.NewPassWord);
            //        if (pass != null)
            //        {

            //        }
            //    }

            //用户先得登录才能修改
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("Login");
                    return View();
        }
        /// <summary>
        /// 处理用户提交下单
        /// </summary>
        /// <param name="oder"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Index(Order oder)
        {
            EntityDbContext _context = new EntityDbContext();
            //1 判断用户登录凭据是否过期，如果过期跳转回登录页，登录成功后返回确认购买页
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("login", "Account", new { returnUrl = Url.Action("index", "ShonppingCart") });
            //2 读出当前用户Person
            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;
            oder.Person = _context.Persons.Find(person.ID);

            //3 从会话中读出订单明细列表
            oder.OrderDetails = new List<OrderDetail>();

            if (ModelState.IsValid)
            {
                //把订单中的收件人信息保存带person中
                var p = _context.Persons.Find(person.ID);
                p.MobileNumber = oder.MobilNumber;
                p.Address = oder.Address;
                p.Name = oder.AddressPerson;
                p.FirstName = p.Name.Substring(0, 1);
                p.LastName = p.Name.Substring(1, p.Name.Length - 1);
                _context.SaveChanges();

               
            }
            return View(oder);
        }

        [HttpPost]
        public ActionResult EditPw(EditPwViewModel model)
        {
            //判断是否通过验证
            if (ModelState.IsValid)
            {
                //输入合法，进行修改密码
                bool editpwSuccessed;
                try
                {
                    var userManage = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new EntityDbContext()));
                    var userName = (Session["LoginUserSessionModel"] as LoginUserSessionModel).User.UserName;
                    var user = userManage.Find(userName, model.PassWord);
                    if (user == null)
                    {
                        ModelState.AddModelError("","密码错误");
                        return View();
                    }
                    else
                    {
                        //修改密码
                        editpwSuccessed = userManage.ChangePassword(user.Id, model.PassWord, model.NewPassWord).Succeeded;
                        if (editpwSuccessed)
                            return Content("<script>alert('修改成功!');location.href='" + Url.Action("index", "home") + "'</script>");
                        else
                           ModelState.AddModelError("", "修改失败，请重试");
                    }
                }
                catch
                {
                    ModelState.AddModelError("", "修改失败，请重试");
                }
            }
            return View();

        }

        public ActionResult Index()
        {
            EntityDbContext _context = new EntityDbContext();

            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;
            var orders = Session["Order"] as Order;
            //3.创建新Order对象
            var order = new Order()
            {
                //Address = orders.Address,
                AddressPerson = person.Name,
                MobilNumber = person.MobileNumber,
                Person = _context.Persons.Find(person.ID),

            };

            return View(order);


        }
    
            
            
            }
}
using BusinessLogicLayer;
using CommonUtility;
using Enity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JXCMIS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //var category = new Category()
            //{
            //    CategoryID = 7,
            //    CategoryName = "显示器(液晶)"
            //};
            ////测试新增
            ////if (new CategoryBLL().Add(category))
            ////    MessageBox.Show("添加成功");
            ////测试修改
            //if (new CategoryBLL().Edit(category))
            //    MessageBox.Show("修改成功");
            ////测试删除
            //if (new CategoryBLL().Delete(category))
            //    MessageBox.Show("删除成功");
            //测试查询所有的分类
            dataGridView1.DataSource = new CategoryBLL().GetAll();
            ////测试查询编号为3的分类
            //MessageBox.Show(new CategoryBLL().GetByID(3).CategoryName);

            //var employee = new Employee()
            //{
            //    EmployeeName = "刘诗诗",
            //    CardNo = "A03",
            //    PassWord = new Encrypt().SHA1("123456"),
            //    Sex = true,
            //    Phone = "13933663366",
            //    Memo = "我是一名小小的业务员"
            //};
            //var employee1 = new Employee()
            //{
            //    EmployeeName = "赵丽颖",
            //    CardNo = "A04",
            //    PassWord = new Encrypt().SHA1("123456"),
            //    Sex = true,
            //    Phone = "13633553377",
            //    Memo = "我是一名小小的业务员"
            //};
            //var employee2 = new Employee()
            //{
            //    EmployeeName = "郑爽",
            //    CardNo = "C02",
            //    PassWord = new Encrypt().SHA1("123456"),
            //    Sex = true,
            //    Phone = "13933553399",
            //    Memo = "我是一名小小的仓管"
            //};
            //new EmployeeBLL().Add(employee);
            //new EmployeeBLL().Add(employee1);
            //new EmployeeBLL().Add(employee2);

            if(new EmployeeBLL().Login("C02","123456"))
                MessageBox.Show("登录成功");
            else
                MessageBox.Show("登录失败");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = BarQrCodeLib.GetBarCode("1000111333");
            pictureBox2.Image = BarQrCodeLib.GetQrCode("http://www.lzzy.net");
        }
    }
}

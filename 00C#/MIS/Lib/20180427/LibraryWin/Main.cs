using BusinessLogicLayer;
using CommonUtility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryWin
{
    public partial class Main : Form
    {
        private string deleteBookID;  //待删除的图书ID
        private string userID;   //借书时读者ID

        public Main()
        {
            InitializeComponent();

            //当窗体对象被创建时，加载需要的数据，如下拉菜单里的选项
            cbSearchBookClass3.DataSource = new BookInfo().GetAllBookClass().Tables[0];
            //指定下拉选项用于显示的字段
            cbSearchBookClass3.DisplayMember = "分类名称";
            //指定选项传值的字段
            cbSearchBookClass3.ValueMember = "分类编号";

            //当窗体对象被创建时，加载需要的数据，如下拉菜单里的选项
            cbBookClass3.DataSource = new BookInfo().GetAllBookClass().Tables[0];
            //指定下拉选项用于显示的字段
            cbBookClass3.DisplayMember = "分类名称";
            //指定选项传值的字段
            cbBookClass3.ValueMember = "分类编号";
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            //dgvTest.DataSource = new BookInfo().GetBookInfo(txtTest1.Text, txtTest2.Text).Tables[0];
            dgvTest.DataSource = new BookInfo().GetAllBookClass().Tables[0];
        }

        private void btnSearch3_Click(object sender, EventArgs e)
        {
            //获取用户输入的书名关键字
            var bookName = txtSearchBookName3.Text.Trim();
            //获取用户选择的下拉选项
            var bookClass = Convert.ToString(cbSearchBookClass3.SelectedValue).Trim();

            //调用业务逻辑层的图书查询方法 检索图书 
            var data = new BookInfo().GetBookInfo(bookName, bookClass).Tables[0];

            //判断有没有记录  Rows表示Table中的行
            if (data.Rows.Count > 0)
                dgvBookInfo3.DataSource = data;
            else
            {
                dgvBookInfo3.DataSource = null;
                MessageBox.Show("未找到相应的图书！", "温馨提醒");
            }
        }

        /// <summary>
        /// 确保不会选择未来的时间
        /// </summary>
        private void dtPublishDate3_ValueChanged(object sender, EventArgs e)
        {
            //比较用户选的时间，如果晚于当前时间，将控件时间调回今天
            var dt1 = dtPublishDate3.Value;
            var dt2 = DateTime.Now;
            //比较时间早晚  早于>0  相同时间=0  晚于<0
            var result = DateTime.Compare(dt1, dt2);
            if (result > 0)
                dtPublishDate3.Value = DateTime.Now;
        }

        private void btnTestAdd_Click(object sender, EventArgs e)
        {
            //new BookInfo().InsertNewBook("测试10", "1234", "西游记", "吴承恩", DateTime.Parse("2018-2-1"), 
            //    "第十版", 3000000, 900, "南天出版社", "I");

            byte[] pic = Photo.ReadPhotoFromPath("e:\\face.jpeg");
            var result = new User().AddUser("20170000001", "孙悟空", "123456", 1, "swk@qq.com", "2017软件技术1班", pic);
            MessageBox.Show(result.ToString());
        }

        /// <summary>
        /// 图书信息新增或更新
        /// </summary>
        private void btnOK3_Click(object sender, EventArgs e)
        {
            //1.检查用户是否输入
            foreach(Control c in gbAddBook.Controls)
            {
                if(c is TextBox && c.Text.Trim()=="")
                {
                    MessageBox.Show("请输入所有内容！", "温馨提示");
                    return;
                }
            }

            //2.检查用户输入是否正确
            var inputCheck = new InputCheck();
            //图书编号是否正确
            if(!inputCheck.CheckBookID(txtBookID3.Text.Trim()))
            {
                MessageBox.Show("请输入正确的图书编号！", "温馨提示");
                return;
            }
            //ISBN是否正确
            if (!inputCheck.CheckISBN(txtISBN3.Text.Trim()))
            {
                MessageBox.Show("请输入正确的ISBN！", "温馨提示");
                return;
            }
            //字数页数是否输入数字
            int pageCount = 0;
            int wordCount = 0;
            try
            {
                pageCount = Convert.ToInt32(txtPageCount3.Text.Trim());
            }
            catch
            {
                MessageBox.Show("请输入正确的页数！", "温馨提示");
                return;
            }
            try
            {
                wordCount = Convert.ToInt32(txtWordCount3.Text.Trim());
            }
            catch
            {
                MessageBox.Show("请输入正确的字数！", "温馨提示");
                return;
            }

            string bookid = txtBookID3.Text.Trim();
            string bookname = txtBookName3.Text.Trim();
            string isbn = txtISBN3.Text.Trim();
            string author = txtAuthor3.Text.Trim();
            string bookversion = txtBookVersion3.Text.Trim();
            string publisher = txtPublisher3.Text.Trim();
            string classid = Convert.ToString(cbBookClass3.SelectedValue);
            DateTime publishdate = dtPublishDate3.Value;

            if(rbAddBook3.Checked)
            {
                //新增图书
                //3.调用业务方法
                if (new BookInfo().InsertNewBook(bookid, isbn, bookname, author, publishdate, bookversion,wordCount, pageCount, publisher, classid))
                {
                    MessageBox.Show("新书入库成功！" , "温馨提示");

                    //4.刷新数据
                    DataSet ds = new BookInfo().GetBookInfo(bookname, classid);
                    //txtSearchBookName3.Text = bookname;
                    //cbSearchBookClass3.SelectedValue = classid;
                    dgvBookInfo3.DataSource = ds.Tables[0];
                }
                else
                {
                    MessageBox.Show("新书入库失败！", "温馨提示");
                }
            }
            else
            {
                //更新图书
                if (new BookInfo().UpdateBook(bookid, isbn, bookname, author, publishdate, bookversion, wordCount, pageCount, publisher, classid))
                {
                    MessageBox.Show("修改成功！", "温馨提示");

                    //4.刷新数据
                    DataSet ds = new BookInfo().GetBookInfo(bookname, classid);
                    dgvBookInfo3.DataSource = ds.Tables[0];
                }
                else
                {
                    MessageBox.Show("修改图书失败！", "温馨提示");
                }
            }
        }

        private void btnTestISBN_Click(object sender, EventArgs e)
        {
            //var isbn = "69716";
            //var result = new InputCheck().CheckISBN(isbn);
            //if (result)
            //    MessageBox.Show("isbn正确");
            //else
            //    MessageBox.Show("isbn不正确");

            var bookid = "12aa12341231234";
            var result = new InputCheck().CheckBookID(bookid);
            if (result)
                MessageBox.Show("正确");
            else
                MessageBox.Show("不正确");
        }

        /// <summary>
        ///   图书管理 清空用户输入 
        /// </summary>
        private void btnCancel3_Click(object sender, EventArgs e)
        {
            //txtBookID3.Text =string.Empty;
            //txtAuthor3.Text = string.Empty;
            foreach(Control c in gbAddBook.Controls)
                if (c is TextBox)
                    c.Text = string.Empty;
            //将出版日期设置为今天
            dtPublishDate3.Value = DateTime.Now;
            //将下拉图书分类设置为第一个选项
            cbBookClass3.SelectedIndex = 0;
        }

        /// <summary>
        /// DGV的单元格任意部分被单击发生的事件
        /// </summary>
        private void dgvBookInfo3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                #region 将用户选定行的字段内容提供给用户进行编辑

                //将当前行选定
                dgvBookInfo3.CurrentRow.Selected = true;

                //从控件中读出数据表
                var table = dgvBookInfo3.DataSource as DataTable;

                //按当前行数据下标 表示当前行的数组
                var row = table.Rows[dgvBookInfo3.CurrentRow.Index];

                //读取当前行的每一列
                var bookid = row["编号"].ToString();
                deleteBookID = bookid;   //将读取的图书ID赋值给待删除的bookID
                var author = row.ItemArray[3].ToString();
                var bookName = row.ItemArray[2].ToString();
                var isbn = row["ISBN"].ToString();
                var publishdate = Convert.ToDateTime(row["出版日期"]);
                var page = row["页数"].ToString();
                var word = row["字数"].ToString();
                var version = row["版本"].ToString();
                var publisher = row["出版社"].ToString();
                var classID = row["分类号"].ToString();

                //给控件进行赋值 提供给用户编辑
                txtBookID3.Text = bookid;
                txtAuthor3.Text = author;
                txtISBN3.Text = isbn;
                txtBookName3.Text = bookName;
                txtBookVersion3.Text = version;
                txtPageCount3.Text = page;
                txtWordCount3.Text = word;
                txtPublisher3.Text = publisher;
                dtPublishDate3.Value = publishdate;
                cbBookClass3.SelectedValue = classID;

                #endregion 将用户选定行的字段内容提供给用户进行编辑

                rbEditBook3.Checked = true;  //启用编辑
                btnDel3.Enabled = true;   //启用删除
                txtBookID3.ReadOnly = true;  //图书编号禁止修改，设为只读
            }
            catch
            {
                return;
            }
        }

        /// <summary>
        /// 删除图书
        /// </summary>
        private void btnDel3_Click(object sender, EventArgs e)
        {
            //防止用户手误
            DialogResult dlg = MessageBox.Show("你将删除此图书，是否继续？", "注意", MessageBoxButtons.YesNo, 
                MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

            if (dlg == System.Windows.Forms.DialogResult.Yes)
            {                
                //继续删除
                if(new BookInfo().DeleteBook(deleteBookID))
                {
                    MessageBox.Show("删除图书成功！", "温馨提示");
                    //刷新数据，按对应的关键字重新检索
                    DataSet ds = new BookInfo().GetBookInfo(txtSearchBookName3.Text.Trim(), Convert.ToString(cbSearchBookClass3.SelectedValue));
                    dgvBookInfo3.DataSource = ds.Tables[0];
                }
            }
            else
                return;
        }

        /// <summary>
        /// 借书，查询读者信息及借书信息
        /// </summary>
        private void btnOK0_Click(object sender, EventArgs e)
        {
            userID = txtUserID0.Text;
            if(string.IsNullOrEmpty(userID))
            {
                MessageBox.Show("请先输入图书证号！", "温馨提示");
                return;
            }
            //查询出读者信息
            var userInfo = new User().GetOneUserInfo(userID);
            if(userInfo.Tables[0].Rows.Count!=0)
            {
                txtUserName0.Text = userInfo.Tables[0].Rows[0]["姓名"].ToString();
                txtSex0.Text = userInfo.Tables[0].Rows[0]["性别"].ToString();
                txtClass0.Text = userInfo.Tables[0].Rows[0]["班级"].ToString();

                //显示该读者的借书记录
                //dgvBorrowInfo0.DataSource = new BorrowInfo().GetBorrowInfoByUserID(userID).Tables[0];
                Paging0( new BorrowInfo().GetBorrowInfoByUserID(userID).Tables[0]);
                LoadPage0();

                //借书操作启用
                txtBookID0.Enabled = btnBorrow0.Enabled = btnCancel01.Enabled = true;

                //显示大头像
                if(userInfo.Tables[0].Rows[0]["头像"]!=Convert.DBNull)
                {
                    //将字段（byte[]类型）转换回文件流格式（图片控件只能访问文件流格式）
                    var pic = new MemoryStream(userInfo.Tables[0].Rows[0]["头像"] as byte[]);
                    //从内在流中给控件赋值
                    pbPic0.Image = Image.FromStream(pic);
                }
                else
                {
                    //从文件路径中给控件赋值
                    pbPic0.Image = Image.FromFile("no.jpg");
                }
            }
            else
            {
                MessageBox.Show("此图书证号不存在！", "温馨提示");
                return;
            }
        }

        /// <summary>
        /// 借书界面下 清除读者信息 头像 借书记录
        /// </summary>
        private void btnCancel00_Click(object sender, EventArgs e)
        {
            txtUserID0.Text = txtUserName0.Text = txtSex0.Text = txtClass0.Text = string.Empty;
            pbPic0.Image = Image.FromFile("no.jpg");
            dgvBorrowInfo0.DataSource = null;
        }

        //重新输入要借的图书ID
        private void btnCancel01_Click(object sender, EventArgs e)
        {
            txtBookID0.Text = string.Empty;
        }

        //借书
        //1.有没有这本书
        //2.该书未被借出
        //3.借阅，添加一条借书记录
        private void btnBorrow0_Click(object sender, EventArgs e)
        {
            var bookID = txtBookID0.Text.Trim();
            //判断用户输入图书ID是否正确
            if(string.IsNullOrEmpty(bookID))
            {
                MessageBox.Show("请先输入图书编号！", "温馨提示");
                return;
            }
            if (string.IsNullOrEmpty(userID))
            {
                MessageBox.Show("请先输入借书证号！", "温馨提示");
                return;
            }

            var result = new BorrowInfo().BorrowBook(bookID,userID);
            switch(result)
            {
                case 1:
                    MessageBox.Show("借书成功！", "温馨提示");
                    //刷新借书记录
                    //dgvBorrowInfo0.DataSource = new BorrowInfo().GetBorrowInfoByUserID(userID).Tables[0];
                    Paging0( new BorrowInfo().GetBorrowInfoByUserID(userID).Tables[0]);
                    LoadPage0();
                    break;
                case 9:
                    MessageBox.Show("数据访问失败，请重试！", "温馨提示");
                    break;
                case -1:
                    MessageBox.Show("您输入的图书不存在，请核对！", "温馨提示");
                    break;
                case 0:
                    MessageBox.Show("此书已经借出，不能重复借书！", "温馨提示");
                    break;
                default:
                    return;
            }
        }

        #region 借书记录的翻页处理
        public int borrowInfoPageSize = 5;      //每页记录数
        public int borrowInfoRecordCount = 0;    //总记录数
        public int borrowInfoPageCount = 0;      //总页数
        public int borrowInfoCurrentPage = 0;    //当前页
        DataTable BorrowInfoDataTable = new DataTable();

        ///LoadPage方法
        /// <summary>
        /// loaddpage方法
        /// </summary>
        private void LoadPage0()
        {
            if (borrowInfoCurrentPage < 1) 
                borrowInfoCurrentPage = 1;
            if (borrowInfoCurrentPage > borrowInfoPageCount)
                borrowInfoCurrentPage = borrowInfoPageCount;

            int beginRecord;
            int endRecord;
            DataTable dtTemp;
            dtTemp = BorrowInfoDataTable.Clone();

            beginRecord = borrowInfoPageSize * (borrowInfoCurrentPage - 1);
            if (borrowInfoCurrentPage == 1) 
                beginRecord = 0;
            endRecord = borrowInfoPageSize * borrowInfoCurrentPage;

            if (borrowInfoCurrentPage == borrowInfoPageCount) 
                endRecord = borrowInfoRecordCount;
            if (BorrowInfoDataTable.Rows.Count>0)
                for (int i = beginRecord; i < endRecord; i++)
                {
                    dtTemp.ImportRow(BorrowInfoDataTable.Rows[i]);
                }

            dgvBorrowInfo0.DataSource = dtTemp; //datagridview控件名是tf_dgv1
            lblCurrentPage0.Text = borrowInfoCurrentPage.ToString(); //当前页
            lblTotalPage0.Text = borrowInfoPageCount.ToString(); //总页数
            lblReccordCount0.Text = borrowInfoRecordCount.ToString(); //总记录数
        }

        /// <summary>
        /// 分页的方法
        /// </summary>
        /// <param name="str"></param>
        private void Paging0(DataTable dtSource) //str是sql语句
        {
            BorrowInfoDataTable = dtSource;
            borrowInfoRecordCount = BorrowInfoDataTable.Rows.Count;
            borrowInfoPageCount = (borrowInfoRecordCount / borrowInfoPageSize);
            if ((borrowInfoRecordCount % borrowInfoPageSize) > 0)
            {
                borrowInfoPageCount++;
            }
            //默认第一页
            borrowInfoCurrentPage = 1;
            LoadPage0(); //调用加载数据的方法
        }

        private void btnFirstPage0_Click(object sender, EventArgs e)
        {
            borrowInfoCurrentPage = 1;
            LoadPage0();
        }

        private void btnPrePage0_Click(object sender, EventArgs e)
        {
            borrowInfoCurrentPage--;
            LoadPage0();
        }

        private void btnNextPage0_Click(object sender, EventArgs e)
        {
            borrowInfoCurrentPage++;
            LoadPage0();
        }

        private void btnLastPage0_Click(object sender, EventArgs e)
        {
            borrowInfoCurrentPage = borrowInfoPageCount;
            LoadPage0();
        }

        #endregion 借书记录的翻页处理

        private void txtUserID0_KeyDown(object sender, KeyEventArgs e)
        {
            //输入完图书证回车
            if (e.KeyCode == Keys.Enter)
                this.btnOK0_Click(sender, e);
        }

        private void Main_Activated(object sender, EventArgs e)
        {
            //设置焦点
            txtUserID0.Focus();
        }
    }
}

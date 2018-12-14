using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogicLayer;
using Enity;

namespace JXCMIS
{
    public partial class Form2 : Form
    {
        private TestBLL _testBLL;
        private string _select_StuNo="";
        private Students _select_Student;
        private string _select_RoomName="";
        private Rooms _select_Room;
        private string _delete_stuNo = "";

        public Form2()
        {
            InitializeComponent();
            _testBLL = new  TestBLL();

            lbStu.DataSource = _testBLL.GetAllStudents().Select(x => x.StuNo).ToList();
            lbStu.SelectedIndex = -1;

            lbRoom.DataSource = _testBLL.GetAllRooms().Select(x => x.Name).ToList();
            lbRoom.SelectedIndex = -1;

            lbStuRoom.SelectedIndex = -1;
        }

        private void lbRoom_Click(object sender, EventArgs e)
        {
            try
            {
                _select_RoomName = lbRoom.SelectedItem.ToString();

                var roomName = lbRoom.SelectedItem.ToString();
                var room = _testBLL.GetAllRoomsByName(roomName);
                _select_Room = room;
                txtRoomName.Text = room.Name;
                txtCap.Text = room.Capacity.ToString();
                txtSex.Text = room.Sex ? "男生宿舍" : "女生宿舍";
                txtStatus.Text = _testBLL.GetRoomCapacity(room.ID) == room.Capacity ? "满员" : "未满员";
                //显示该宿舍入住记录
                lbStuRoom.DataSource = _testBLL.GetStuNoRoom(room.ID);
                lbStuRoom.SelectedIndex = -1;
            }
            catch { }
        }

        private void lbStu_Click(object sender, EventArgs e)
        {
            try
            {
                _select_StuNo = lbStu.SelectedItem.ToString();
                _select_Student = _testBLL.GetStudentByStuNo(_select_StuNo);
            }
            catch { }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_select_StuNo))
            {
                MessageBox.Show("请选择同学");
                return;
            }
            if (string.IsNullOrEmpty(_select_RoomName))
            {
                MessageBox.Show("请选择宿舍");
                return;
            }
            //判断此学生是否已经入住
            var stu_room = _testBLL.GetStuRoomByStuNo(_select_StuNo);
            if (stu_room!=null&&!string.IsNullOrEmpty(stu_room.RoomName)&&!string.IsNullOrEmpty(stu_room.StuNo))
            {
                MessageBox.Show(_select_StuNo+"已经入住"+stu_room.RoomName);
                return;
            }
            //宿舍是否同性
            if (_select_Student.Sex != _select_Room.Sex)
            {
                var msg = _select_Student.Sex ? "男生不能入住女生宿舍" : "女生不能入住男生宿舍";
                MessageBox.Show(msg);
                return;
            }
            //宿舍是否满员
            var count = _testBLL.GetRoomCapacity(_select_Room.ID);
            if (count == _select_Room.Capacity)
            {
                MessageBox.Show(_select_RoomName+"已经满员，不能入住");
                return;
            }
            //入住处理
            if (_testBLL.InRoom(_select_Student.ID, _select_Room.ID, ""))
            {
                MessageBox.Show(_select_StuNo + "入住" + _select_RoomName + "成功");
                this.lbRoom_Click(null,null);
                lbStu.DataSource = _testBLL.GetAllStudents().Select(x => x.StuNo).ToList();
                lbStu.SelectedIndex = -1;
                _select_Student = null;
                _select_StuNo = "";
            }
            else
            {
                MessageBox.Show(_select_StuNo + "入住" + _select_RoomName + "失败");
            }
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_delete_stuNo))
            {
                MessageBox.Show("请选择要搬出的同学");
                return;
            }
            
            var deleteStudent = _testBLL.GetStudentByStuNo(_delete_stuNo);
            //搬出处理
            if (_testBLL.OutRoom(deleteStudent.ID, _select_Room.ID))
            {
                MessageBox.Show(_delete_stuNo + "搬出" + _select_RoomName + "成功");
                this.lbRoom_Click(null, null);
                lbStu.DataSource = _testBLL.GetAllStudents().Select(x=>x.StuNo).ToList();
                lbStu.SelectedIndex = -1;
                _delete_stuNo = "";
            }
            else
            {
                MessageBox.Show(_delete_stuNo + "搬出" + _select_RoomName + "成功");
            }
        }

        private void lbStuRoom_Click(object sender, EventArgs e)
        {
            try
            {
                _delete_stuNo = lbStuRoom.SelectedItem.ToString();
            }
            catch { }
        }
    }
}

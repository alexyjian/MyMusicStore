using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Enity;

namespace BusinessLogicLayer
{
    public class TestBLL
    {
        private SqlCommand _cmd;
        public TestBLL()
        {
            _cmd = new SqlCommand();
            _cmd.CommandType = CommandType.StoredProcedure;
        }

        public List<Students> GetAllStudents()
        {
            _cmd.CommandText = "GetAllStudents";
            _cmd.Parameters.Clear();
            var list = new List<Students>();
            var data = DBAccess.ReadData(_cmd);
            while (data.Read())
            {
                var item = new Students();
                item.ID = Convert.ToInt32(data["ID"]);
                item.Name = data["Name"].ToString();
                item.ClassInfo = data["ClassInfo"].ToString();
                item.StuNo = data["StuNo"].ToString();
                item.Sex = Convert.ToBoolean(data["Sex"]);
                list.Add(item);
            }
            data.Close();
            return list;
        }

        public Students GetStudentByStuNo(string stuNo)
        {
            _cmd.CommandText = "[GetStudentByNo]";
            _cmd.Parameters.Clear();
            _cmd.Parameters.Add("@stuno", SqlDbType.NVarChar, 20).Value = stuNo;
            var item = new Students();
            var data = DBAccess.ReadData(_cmd);
            while (data.Read())
            {
                item.ID = Convert.ToInt32(data["ID"]);
                item.Name = data["Name"].ToString();
                item.ClassInfo = data["ClassInfo"].ToString();
                item.StuNo = data["StuNo"].ToString();
                item.Sex = Convert.ToBoolean(data["Sex"]);
            }
            data.Close();
            return item;
        }

        public List<Rooms> GetAllRooms()
        {
            _cmd.CommandText = "GetAllRooms";
            _cmd.Parameters.Clear();
            var list = new List<Rooms>();
            var data = DBAccess.ReadData(_cmd);
            while (data.Read())
            {
                var item = new Rooms();
                item.ID = Convert.ToInt32(data["ID"]);
                item.Name = data["Name"].ToString();
                item.Capacity = Convert.ToInt32(data["Capacity"]);
                item.Sex = Convert.ToBoolean(data["Sex"]);
                list.Add(item);
            }
            data.Close();
            return list;
        }

        public Rooms GetAllRoomsByName(string name)
        {
            _cmd.CommandText = "GetAllRoomsByName";
            _cmd.Parameters.Clear();
            _cmd.Parameters.Add("@name", SqlDbType.NVarChar, 50).Value = name;
            var item = new Rooms();
            var data = DBAccess.ReadData(_cmd);
            while (data.Read())
            {
                item.ID = Convert.ToInt32(data["ID"]);
                item.Name = data["Name"].ToString();
                item.Capacity = Convert.ToInt32(data["Capacity"]);
                item.Sex = Convert.ToBoolean(data["Sex"]);
            }
            data.Close();
            return item;
        }

        public int GetRoomCapacity(int id)
        {
            _cmd.CommandText = "GetRoomCapacity";
            _cmd.Parameters.Clear();
            _cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            return (int)DBAccess.GetScalar(_cmd);
        }

        //判断此学生是否已入住
        public Stu_Rooms GetStuRoomByStuNo(string stuno)
        {
            _cmd.CommandText = "GetStuRoomByStuNo";
            _cmd.Parameters.Clear();
            _cmd.Parameters.Add("@stuno", SqlDbType.NVarChar, 20).Value = stuno;
            var item = new Stu_Rooms();
            var data = DBAccess.ReadData(_cmd);
            while (data.Read())
            {
                item.ID = Convert.ToInt32(data["ID"]);
                item.StuID = Convert.ToInt32(data["StuID"]);
                item.StuNo = data["StuNo"].ToString();
                item.StuName = data["stuName"].ToString();
                item.RoomID = Convert.ToInt32(data["RoomID"]);
                item.RoomName = data["roomName"].ToString();
                item.Memo = data["Memo"].ToString();
            }
            data.Close();
            return item;
        }

        public List<string> GetStuNoRoom(int roomID)
        {
            _cmd.CommandText = "GetStuRoom";
            _cmd.Parameters.Clear();
            _cmd.Parameters.Add("@roomid", SqlDbType.Int).Value = roomID;
            var stuNos = new List<string>();
            var data = DBAccess.ReadData(_cmd);
            while (data.Read())
            {
                var stuno = data["StuNo"].ToString();
                stuNos.Add(stuno);
            }
            data.Close();
            return stuNos;
        }

        public bool InRoom(int stuId, int roomId, string memo)
        {
            _cmd.CommandText = "InRoom";
            _cmd.Parameters.Clear();
            _cmd.Parameters.Add("@stuId", SqlDbType.Int).Value = stuId;
            _cmd.Parameters.Add("@roomid", SqlDbType.Int).Value = roomId;
            _cmd.Parameters.Add("@memo", SqlDbType.NVarChar,50).Value = memo;
            var result = DBAccess.ExecuteSQL(_cmd);
            if (result > 0)
                return true;
            return false;
        }

        public bool OutRoom(int stuId, int roomId)
        {
            _cmd.CommandText = "OutRoom";
            _cmd.Parameters.Clear();
            _cmd.Parameters.Add("@stuId", SqlDbType.Int).Value = stuId;
            _cmd.Parameters.Add("@roomid", SqlDbType.Int).Value = roomId;
            var result = DBAccess.ExecuteSQL(_cmd);
            if (result > 0)
                return true;
            return false;
        }
    }
}

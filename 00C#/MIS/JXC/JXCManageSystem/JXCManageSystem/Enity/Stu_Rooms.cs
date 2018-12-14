using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enity
{
    public class Stu_Rooms
    {
        public int ID { get; set; }
        public int StuID { get; set; }
        public string StuNo { get; set; }
        public string StuName { get; set; }
        public int RoomID { get; set; }
        public string RoomName { get; set; }
        public string Memo { get; set; }
        public Stu_Rooms() { }
    }
}

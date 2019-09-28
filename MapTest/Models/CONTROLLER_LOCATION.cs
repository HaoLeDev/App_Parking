using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MapTest.Models
{
    public class CONTROLLER_LOCATION
    {
        public string ID { get; set; }//id
        public string NAME { get; set; }//tên controller
        public int BTS_ID { get; set; }//thuộc trạm bts nào
        public int LEFT { get; set; }//vị trí của controller trong sơ đồ trạm, hàng ngang từ trái sang
        public int TOP { get; set; }//vị trí của controller trong sơ đồ trạm, hàng dọc từ trên xuống
        public float TEMP { get; set; }//giá trị nhiệt độ
        public float HUMI { get; set; }//giá trị độ ẩm 
    }
}
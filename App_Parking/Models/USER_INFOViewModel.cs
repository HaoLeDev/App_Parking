using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace App_Parking.Models
{
    public class USER_INFOViewModel
    {
        public int USER_ID { get; set; }
        [DisplayName("Loại khách hàng")]
        public Nullable<int> USER_TYPEID { get; set; }
        [DisplayName("Tên khách hàng")]
        public string USER_NAME { get; set; }
        [DisplayName("Mã khách hàng")]
        public string USER_CODE { get; set; }
        [DisplayName("Số điện thoại")]
        public string PHONE { get; set; }
        [DisplayName("Số CMND")]
        public string IDENTITY_NUMBER { get; set; }
        [DisplayName("Giới tính")]
        public string SEX { get; set; }
        [DisplayName("Ngày sinh")]
        public DateTime? USER_BIRTH { get; set; }
        public string strUSER_BIRTH
        {
            get
            {
                return USER_BIRTH.HasValue ? USER_BIRTH.Value.ToString("dd/MM/yyyy") : "";
            }
        }
        [DisplayName("Địa chỉ")]
        public string ADDRESS { get; set; }
        [DisplayName("Ảnh")]
        public byte[] IMAGE { get; set; }
        [DisplayName("Email")]
        public string EMAIL { get; set; }
        [DisplayName("Ghi chú")]
        public string NOTE { get; set; }
        [DisplayName("Trạng thái")]
        public Nullable<bool> USER_STATUS { get; set; }
        [DisplayName("Điểm tích lũy")]
        public Nullable<int> REDEEM_POINTS { get; set; }
        [DisplayName("Ngày tạo")]
        public Nullable<System.DateTime> CREATE_DATE { get; set; }
        [DisplayName("Ngày sửa")]
        public Nullable<System.DateTime> UPDATE_DATE { get; set; }
        public string strEM_STATUS
        {
            get
            {
                return USER_STATUS.HasValue == true && USER_STATUS.Value == true ? "<input type='checkbox' class='editor-active' checked='checked' onclick='return false;'>" : "<input type='checkbox' class='editor-active' onclick='return false;'>";
            }
        }
        public string strSEX
        {
            get
            {
                string result = "";
                if (SEX == "M")
                {
                    result = "<span class='label label-warning'>Nam</span>";
                }
                else
                {
                    result = "<span class='label label-success'>Nữ</span>";
                }
                return result;
            }
        }
    }
}
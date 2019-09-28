using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Api.Models
{
    public class CardModel
    {
        /// <summary>
        /// ID thẻ
        /// </summary>
        public string caId { get; set; }
        /// <summary>
        /// ID người dùng
        /// </summary>
        public string userId { get; set; }
        /// <summary>
        /// Mã thẻ
        /// </summary>
        public string caNo { get; set; }
        /// <summary>
        /// Số thẻ
        /// </summary>
        public string caNumber { get; set; }
        /// <summary>
        /// Loại xe
        /// </summary>
        public string ctId { get; set; }
        /// <summary>
        /// Loại vé
        /// </summary>
        public string typeId { get; set; }
        /// <summary>
        /// Biển số
        /// </summary>
        public string plateNumber { get; set; }
        /// <summary>
        /// Ngày đăng ký
        /// </summary>
        public string registerDate { get; set; }
        /// <summary>
        /// Có ảnh đăng ký không
        /// </summary>
        public bool hasRegisterImage { get; set; }
        /// <summary>
        /// Trạng thái thẻ, có thể null
        /// </summary>
        public Nullable<bool> caStatus { get; set; }
        /// <summary>
        /// Thẻ đã kích hoạt chưa, có thể null
        /// </summary>
        public Nullable<bool> caActive { get; set; }
        /// <summary>
        /// Mô tả
        /// </summary>
        public string description { get; set; }
        /// <summary>
        /// Loại phương tiện
        /// </summary>
        public string vehicleType { get; set; }
        /// <summary>
        /// Đời xe, phương tiện
        /// </summary>
        public string vehicleModel { get; set; }
        /// <summary>
        /// Màu xe, phương tiện
        /// </summary>
        public string vehicleColor { get; set; }
        /// <summary>
        /// Ngày áp dụng
        /// </summary>
        public string applyDate { get; set; }
        /// <summary>
        /// Ngày hết hạn
        /// </summary>
        public string expriedDate { get; set; }
        /// <summary>
        /// Trạng thái hỏng thẻ, có thể null
        /// </summary>
        public Nullable<bool> caDamaged { get; set; }
        /// <summary>
        /// Trạng thái mất thẻ, có thể null
        /// </summary>
        public Nullable<bool> caLost { get; set; }
        /// <summary>
        /// Tình trạng sử dụng, có thể null
        /// </summary>
        public Nullable<bool> caUsing { get; set; }
        /// <summary>
        /// Cho phép đồng bộ, có thể null
        /// </summary>
        public Nullable<bool> allowSynchronized { get; set; }
        /// <summary>
        /// Danh sách controller có thể đi qua
        /// </summary>
        public string controllerList { get; set; }
        /// <summary>
        /// Ngày bắt đầu
        /// </summary>
        public string startDate { get; set; }
        /// <summary>
        /// Ngày kết thúc
        /// </summary>
        public string endDate { get; set; }
        /// <summary>
        /// Trạng thái hủy thẻ
        /// </summary>
        public Nullable<bool> destroyed { get; set; }
        /// <summary>
        /// Ngày hủy thẻ
        /// </summary>
        public string destroyedDate { get; set; }
        /// <summary>
        /// Nhân viên hủy thẻ
        /// </summary>
        public string accId { get; set; }
        /// <summary>
        /// Ngày chỉnh sửa
        /// </summary>
        public string dateEdit { get; set; }
    }
}
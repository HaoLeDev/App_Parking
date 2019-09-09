using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    /// <summary>
    /// Thuộc tính dùng chung cho tất cả các đối tượng
    /// </summary>
    public class BaseEntity
    {
        /// <summary>
        /// Mã định danh cho từng thực thể
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Ngày tạo
        /// </summary>
        public DateTime? DateCreated { get; set; }
        /// <summary>
        /// Ngày sửa
        /// </summary>
        public DateTime? DateModified { get; set; }
        /// <summary>
        /// Người tạo
        /// </summary>
        public string UserCreated { get; set; }
        /// <summary>
        /// Người sửa
        /// </summary>
        public string UserModified { get; set; }
    }
}

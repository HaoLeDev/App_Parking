using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    /// <summary>
    /// Tài khoản đăng nhập
    /// </summary>
    [Table("Account")]
    public class Account:BaseEntity
    {
        /// <summary>
        /// Tên đăng nhập
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// Mật khẩu
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Ghi chú
        /// </summary>
        public string Note { get; set; }

    }
}

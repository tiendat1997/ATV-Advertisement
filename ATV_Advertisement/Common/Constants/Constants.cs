using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATV_Advertisement.Common.Constants
{
    public static class Constants
    {
        public static class RoleConstants
        {
            public static string ADMIN = "Admin";
            public static string STAFF = "Staff";
        }
        
        public static class CommonMessages
        {
            public static string INVALID_LOGIN = "Thông tin đăng nhâp không đúng";
            public static string UNAUTHORIZED = "Không có quyền truy cập";
            public static string ALREADY_LOGIN = "Tài khoản hiện đang được đăng nhập";

            public static string APPLICATION_IS_RUNNING = "Ứng dụng đang chạy";
        }
    }
}

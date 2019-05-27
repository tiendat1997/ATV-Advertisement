using DataService.Model;
using DataService.Services;
using System.Linq;

namespace ATV_Advertisement.Common.Auth
{
    public static class Session
    {
        private static string FULLNAME = "";
        private static string CODE = "";
        private static string ROLE = "";
        private static bool ISLOGIN = false;

        public static bool Login(string username, string password)
        {
            UserService userService = null;
            User user = null;
            bool result = false;

            try
            {
                userService = new UserService();
                if (!string.IsNullOrWhiteSpace(username))
                {
                    if (!string.IsNullOrWhiteSpace(password))
                    {
                        user = userService.GetLogin(username, password);
                        if (user != null)
                        {
                            FULLNAME = user.Fullname;
                            CODE = user.Code;
                            ROLE = user.Role.Name;
                            ISLOGIN = true;

                            result = true;
                        }
                    }
                }

                return result;
            }
            catch
            {
                throw;
            }
            finally
            {
                userService = null;
                user = null;
            }
        }

        public static bool CheckAuthorize(string role)
        {
            bool result = false;
            try
            {
                if (ISLOGIN)
                {
                    if (FULLNAME != "" && CODE != "" && ROLE != "")
                    {
                        result = role == ROLE;
                    }
                }
                return result;
            }
            catch
            {
                throw;
            }
        }

        public static void Logout()
        {
            ClearInfo();
        }

        public static void ClearInfo()
        {
            FULLNAME = "";
            CODE = "";
            ROLE = "";
            ISLOGIN = false;
        }

        public static string GetFullName()
        {
            return FULLNAME;
        }

        public static string GetCode()
        {
            return CODE;
        }

        public static string GetRole()
        {
            return ROLE;
        }

        public static bool IsLogin()
        {
            ISLOGIN = false;

            if (!string.IsNullOrWhiteSpace(FULLNAME))
            {
                if (!string.IsNullOrWhiteSpace(CODE))
                {
                    if (!string.IsNullOrWhiteSpace(ROLE))
                    {
                        ISLOGIN = true;
                    }
                }
            }

            return ISLOGIN;
        }
    }
}

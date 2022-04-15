using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class UserBLL
    {
        UserAccess ua = new UserAccess();
        public User GetUser(string tenDN)
        {
            return ua.GetUser(tenDN);
        }
        public int Check_Users(string tenDN,string pass)
        {
            User u = this.GetUser(tenDN);

            if(string.Compare(tenDN,u.tenDN)==0 && string.Compare(pass,u.pass)==0)
            {
                return u.quyen;
            }
            return -1;
        }
    }
}

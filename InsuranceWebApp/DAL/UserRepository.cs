using InsuranceWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InsuranceWebApp.DAL
{
    public class UserRepository : IDisposable
    {
        public UserAuth AuthenticateUser(string userName, string password)
        {
            UserAuth user;
            using (InsuranceDBEntities db = new InsuranceDBEntities())
            {
                user = db.USP_USERAUTHENTICATION(userName, password).Select(u => new UserAuth
                {
                    UserName = u.userName,
                    Role = u.role
                }).FirstOrDefault();
            }
            return user;
        }

        public void Dispose()
        {
            GC.Collect();
        }
    }
}
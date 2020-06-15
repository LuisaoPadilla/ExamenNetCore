using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Services
{
    public class LoginRepository : ILoginRepository
    {
        private AppDbContext context;
        public LoginRepository(AppDbContext context)
        {
            this.context = context;
        }

        public bool Login(Users user)
        {
            var userTemp = this.context.Users.FirstOrDefault(x => x.Username == user.Username && x.Password == user.Password);
            if (userTemp != null)
            {
                return true;
            }
            return false;
        }
    }
}

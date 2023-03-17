using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Models.Repository
{
    public class AuthenticateLogin : ILogin
    {
        private readonly InventoryContext _context;

        public AuthenticateLogin(InventoryContext context)
        {
            _context = context;
        }
        public bool AuthenticateUser(string userName, string password)
        {
            var succeeded = _context.Users.Where(authUser => authUser.UserName == userName && authUser.Password == password).FirstOrDefault();
            if (succeeded != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}

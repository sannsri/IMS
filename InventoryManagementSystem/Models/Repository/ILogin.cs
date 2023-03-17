using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Models.Repository
{
    public interface ILogin
    {
       bool AuthenticateUser(string userName, string password);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnvironmentalApp.Core.Models;

namespace EnvironmentalApp.Core.Services
{
    public interface IAuthenicationService
    {
        //Role    
        int CreateRole(string roleName);
        List<Role> GetRole();
        Role GetRole(int roleId);
        int UpdateRole(Role entity);
        
        //UserRole
        int CreateUserRole(string hawkId, int roleId);
        List<UserRole> GetUserRole(int roleId);
        UserRole GetUserRole(string hawkId);
        int UpdateUserRole(UserRole entity);

    }

}

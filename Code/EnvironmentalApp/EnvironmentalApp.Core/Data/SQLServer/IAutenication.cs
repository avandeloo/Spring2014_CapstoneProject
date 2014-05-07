using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnvironmentalApp.Core.Models;

namespace EnvironmentalApp.Core.Data.SQLServer
{
    public interface IUserRole
    {
        int Create(UserRole entity);
        UserRole Get(string hawkId);
        List<UserRole> Get();
        List<UserRole>Get (int roleId);
    }
    public interface IRole
    {
        int Create(Role entity);
        Role Get(int roleId);
        List<Role> Get();
    }
}

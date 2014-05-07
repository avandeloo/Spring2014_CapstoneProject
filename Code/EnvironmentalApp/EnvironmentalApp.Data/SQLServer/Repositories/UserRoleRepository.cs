using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnvironmentalApp.Core.Models;
using EnvironmentalApp.Data.SQLServer;
using EnvironmentalApp.Core.Data.SQLServer;

namespace EnvironmentalApp.Data.SQLServer.Repositories
{
    public class UserRoleRepository : Base_SQL_Repository, IUserRole
    {
        public int Create(UserRole entity)
        {
            using (var ctx = new EnergyDataContext(ConnString))
            {
                ctx.UserRoles.Add(entity);
                var result = ctx.SaveChanges();
                if (!(result > 0))
                {
                    throw new Exception("Error creating user role");
                }
                else {
                    return result;
                }
            }
        }

        public UserRole Get(string hawkId)
        {
            using (var ctx = new EnergyDataContext(ConnString))
            {
                var userRole = ctx.UserRoles.FirstOrDefault(x => x.HawkId == hawkId);
                if (userRole == null)
                {
                    throw new Exception("User does not have a role");
                }
                return userRole;
            }
        }

        public List<UserRole> Get()
        {
            using (var ctx = new EnergyDataContext(ConnString))
            {
                var userRole = ctx.UserRoles.AsEnumerable().ToList();
                
                return userRole;
            }
        }

        public List<UserRole> Get(int roleId)
        {
            using (var ctx = new EnergyDataContext(ConnString))
            {
                var userRole = ctx.UserRoles.AsEnumerable().Where(x => x.RoleId == roleId).ToList();
             
                return userRole;
            }
        }
        public int Update(UserRole entity)
        {


            using (var ctx = new EnergyDataContext(ConnString))
            {
                var userRole = ctx.UserRoles.First(x => x.ID == entity.ID);

                userRole.HawkId = entity.HawkId;
                userRole.RoleId = entity.RoleId;
               

                ctx.Entry(userRole).State = System.Data.Entity.EntityState.Modified;
                var result = ctx.SaveChanges();
                if (result != 1)
                {
                    throw new Exception("Error updating user role");
                }
                return result;
            }
        }
    }
}

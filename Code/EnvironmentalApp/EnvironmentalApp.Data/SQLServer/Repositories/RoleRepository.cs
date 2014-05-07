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
    public class RoleRepository : Base_SQL_Repository, IRole
    {

        public int Create(Role entity)
        {
            using (var ctx = new EnergyDataContext(ConnString))
            {
                ctx.Roles.Add(entity);
                var result = ctx.SaveChanges();
                if (result == 1)
                {
                    return result;
                }
                else
                {
                    throw new Exception("Error creating role");
                }
            }
        }

        public Role Get(int roleId)
        {
            using (var ctx = new EnergyDataContext(ConnString))
            {
                var role = ctx.Roles.FirstOrDefault(x => x.Id == roleId);

                if (role == null)
                {
                    throw new Exception("Role not found");
                }
                return role;
            }

        }

        public List<Role> Get()
        {
            using (var ctx = new EnergyDataContext(ConnString))
            {
                var role = ctx.Roles.AsEnumerable().ToList();
                return role;
            }
        }
        public int Update(Role entity)
        {


            using (var ctx = new EnergyDataContext(ConnString))
            {
                var role = ctx.Roles.First(x=>x.Id== entity.Id);

                role.Name = entity.Name;

                ctx.Entry(role).State = System.Data.Entity.EntityState.Modified;
               var result= ctx.SaveChanges();
               if (result != 1)
               {
                   throw new Exception("Error updating role");
               }
                return result;
            }
        }
    }
}

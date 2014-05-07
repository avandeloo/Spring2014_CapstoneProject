using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvironmentalApp.Core.Models
{
    public partial class Role
    {
        public Role()
        {
            this.UserRoles = new List<UserRole>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}

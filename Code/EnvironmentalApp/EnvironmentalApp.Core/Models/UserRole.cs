using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvironmentalApp.Core.Models
{
    public partial class UserRole
    {
        public int ID { get; set; }
        public string HawkId { get; set; }
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
}

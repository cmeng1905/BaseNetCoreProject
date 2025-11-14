using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class AppRole
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public virtual ICollection<AppUserRole> AppUserRoles { get; set; } = [];
    }
}

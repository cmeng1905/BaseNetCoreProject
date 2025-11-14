using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class AppUserRole
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }
        public DateTime AssignedDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public virtual AppUser AppUser { get; set; } = null!;
        public virtual AppRole AppRole { get; set;} = null!;
    }
}

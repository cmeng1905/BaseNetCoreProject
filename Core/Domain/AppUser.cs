using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class AppUser
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string TCKimlikNo { get; set; } = null!;
        public bool AktifMi { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public virtual ICollection<AppUserRole> AppUserRoles { get; set; } = [];

    }
}

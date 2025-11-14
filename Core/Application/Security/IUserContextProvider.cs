using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Security
{
    public interface IUserContextProvider
    {
        public bool IsAuthenticated { get; }
        public string UserName { get; }
        public string Email { get; }
        public string Tckn { get; }
        public IEnumerable<string> Roles { get; }

    }
}

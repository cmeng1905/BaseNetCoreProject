using Application.Abstractions.Services;
using System.DirectoryServices;

namespace Application.Services
{
    public class LdapService : ILdapService
    {
        public bool Authenticate(string username, string password)
        {
            try
            {
                using DirectoryEntry objADEntry = new("LDAP://...", username, password);
                bool res = !objADEntry.NativeObject.Equals(null);
                return res;
            }
            catch 
            {
            }
            return false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace Moto.App_Start
{
    public class CustomPrincipal : ICustomPrincipal, IPrincipal
    {
        public IIdentity Identity { get; private set; }
        public bool IsInRole(string role) { return false; }

        public CustomPrincipal(string email)
        {
            this.Identity = new GenericIdentity(email);
        }

        public Guid UserGuid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
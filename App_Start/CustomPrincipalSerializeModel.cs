using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Moto.App_Start
{
    public class CustomPrincipalSerializeModel
    {
        public Guid UserGuid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
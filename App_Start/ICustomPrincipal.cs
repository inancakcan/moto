using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moto.App_Start
{
    interface ICustomPrincipal
    {
        Guid UserGuid { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
    }
}

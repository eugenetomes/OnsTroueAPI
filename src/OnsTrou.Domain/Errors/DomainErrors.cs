using EasyCompany.GenericResult.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnsTrou.Domain.Errors
{
    public static class DomainErrors
    {
        public static class Weddings
        {
            public static readonly Error NotFound = new Error("Wedding.NotFound", $"Wedding was not found.");
        }

        public static class Accommodations
        {
            public static readonly Func<Guid, Error> NotFound = id => new Error("Accommodation.NotFound", $"Accommodation with the identifier {id} was not found.");
        }
    }
}

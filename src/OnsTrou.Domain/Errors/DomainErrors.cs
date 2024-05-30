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

        public static class Emails
        {
            public static readonly Error Empty = new("Email.Empty", "Email is empty");

            public static readonly Error InvalidFormat = new("Email.InvalidFormat","Email format is invalid");
        }

        public static class WeddingGuests
        {
            public static readonly Error PhoneNumberAlreadyExists = new("WeddingGuest.PhoneNumberAlreadyExists", "Phone Number Already Exists");
        }

        public static class PhoneNumbers
        {
            public static readonly Error Empty = new("PhoneNumber.Empty", "PhoneNumber is empty");
            public static readonly Error AtleastOneDigit = new("PhoneNumber.AtleastOneDigit", "The phone number must contain at least one digit.");
            public static readonly Error OnlyDigits = new("PhoneNumber.OnlyDigits", "The phone number must contain only digits.");
        }
    }
}

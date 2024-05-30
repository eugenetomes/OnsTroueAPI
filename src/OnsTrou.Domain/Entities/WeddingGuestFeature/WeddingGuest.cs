using EasyCompany.GenericResult.Core;
using OnsTrou.Domain.Entities.WeddingFeature;
using OnsTrou.Domain.Errors;
using OnsTrou.Domain.Primitives;
using OnsTrou.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnsTrou.Domain.Entities.WeddingGuestFeature
{
    public class WeddingGuest : WeddingEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }


        public WeddingGuest()
        {
        }

        public WeddingGuest(Guid weddingId, string name, string surname, string phoneNumber) : base(nameof(WeddingGuest), weddingId, phoneNumber!.ToString())
        {
            Name = name;
            Surname = surname;
            PhoneNumber = phoneNumber;
        }

        public static Result<WeddingGuest> Create(Guid weddingId, string name, string surname, string phoneNumber, bool phoneNumberAlreadyExists)
        {
            if(phoneNumberAlreadyExists == true)
            {
                return Result.Failure<WeddingGuest>(DomainErrors.WeddingGuests.PhoneNumberAlreadyExists);
            }
            
            var guest = new WeddingGuest(weddingId, name, surname, phoneNumber);
            return guest;
        }
    }
}

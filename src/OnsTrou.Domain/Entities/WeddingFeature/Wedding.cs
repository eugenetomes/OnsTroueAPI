using EasyCompany.GenericResult.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnsTrou.Domain.Entities.WeddingFeature
{
    public class Wedding
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public DateTime EventDateUtc { get; private set; }
        public Bride Bride { get; private set; }
        public Groom Groom { get; private set; }
        public WeddingVenue Venue { get; private set; }

        private Wedding(Guid id, string name, DateTime eventDateUtc, Bride bride, Groom groom, WeddingVenue venue)
        {
            Id = id;
            Name = name;
            EventDateUtc = eventDateUtc;
            Bride = bride;
            Groom = groom;
            Venue = venue;
        }

        public static Result<Wedding> Create(string name, DateTime eventDateUtc, Bride bride, Groom groom, WeddingVenue venue)
        {
            var wedding = new Wedding(Guid.NewGuid(), name, eventDateUtc, bride, groom, venue);
            return wedding;
        }
    }
}

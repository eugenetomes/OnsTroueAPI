using EasyCompany.GenericResult.Core;
using OnsTrou.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OnsTrou.Domain.Entities.WeddingFeature
{
    public class Wedding : AggregateRoot
    {
        public string Name { get; private set; }
        public DateTime EventDateUtc { get; private set; }
        public Bride Bride { get; private set; }
        public Groom Groom { get; private set; }
        public WeddingVenue Venue { get; private set; }

        private Wedding(string id, string name, DateTime eventDateUtc, Bride bride, Groom groom, WeddingVenue venue) : base(nameof(Wedding), id)
        {
            Name = name;
            EventDateUtc = eventDateUtc;
            Bride = bride;
            Groom = groom;
            Venue = venue;
        }

        public static Result<Wedding> Create(string name, DateTime eventDateUtc, Bride bride, Groom groom, WeddingVenue venue)
        {
            var wedding = new Wedding(Guid.NewGuid().ToString(), name, eventDateUtc, bride, groom, venue);
            return wedding;
        }
    }
}

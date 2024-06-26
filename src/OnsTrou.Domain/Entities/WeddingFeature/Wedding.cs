﻿using EasyCompany.GenericResult.Core;
using OnsTrou.Domain.Primitives;

namespace OnsTrou.Domain.Entities.WeddingFeature;

public class Wedding : AggregateRoot
{
    public string Name { get; init; }
    public DateTime EventDateUtc { get; init; }
    public Bride Bride { get; init; }
    public Groom Groom { get; init; }
    public WeddingVenue Venue { get; init; }

    private Wedding(Guid id, string name, DateTime eventDateUtc, Bride bride, Groom groom, WeddingVenue venue) : base(nameof(Wedding), id)
    {
        Name = name;
        EventDateUtc = eventDateUtc;
        Bride = bride;
        Groom = groom;
        Venue = venue;
    }
    public Wedding()
    {

    }

    public static Result<Wedding> Create(string name, DateTime eventDateUtc, Bride bride, Groom groom, WeddingVenue venue)
    {
        var wedding = new Wedding(Guid.NewGuid(), name, eventDateUtc, bride, groom, venue);
        return wedding;
    }

    public void UpdateBride(string name, string surname, string personalMessage, string email, string telephone)
    {
        Bride.Update(name, surname, personalMessage, email, telephone);
    }
}
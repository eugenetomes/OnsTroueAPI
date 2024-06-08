namespace OnsTrou.Domain.Entities.WeddingFeature;

public class Groom
{
    public string Name { get; init; }
    public string Surname { get; init; }
    public string PersonalMessage { get; init; }
    public string Telephone { get; private set; }
    public string Email { get; private set; }

    public Groom()
    {

    }

    public Groom(string name, string surname, string personalMessage, string email, string telephone)
    {
        Name = name;
        Surname = surname;
        PersonalMessage = personalMessage;
        Email = email;
        Telephone = telephone;
    }
}

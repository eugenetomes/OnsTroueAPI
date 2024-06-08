namespace OnsTrou.Domain.Entities.WeddingFeature;

public class Bride
{
    public string Name { get; private set; }
    public string Surname { get; private set; }
    public string PersonalMessage { get; private set; }
    public string Telephone { get; private set; }
    public string Email { get; private set; }


    public Bride()
    {

    }

    public Bride(string name, string surname, string personalMessage, string email, string telephone)
    {
        Name = name;
        Surname = surname;
        PersonalMessage = personalMessage;
        Email = email;
        Telephone = telephone;
    }

    public void Update(string name, string surname, string personalMessage, string email, string telephone)
    {
        Name = name;
        Surname = surname;
        PersonalMessage = personalMessage;
        Email = email;
        Telephone = telephone;
    }
}
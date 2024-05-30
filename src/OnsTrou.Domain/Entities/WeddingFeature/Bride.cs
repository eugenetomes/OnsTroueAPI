using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnsTrou.Domain.Entities.WeddingFeature;

public class Bride
{
    public string Name { get; private set; }
    public string Surname { get; private set; }
    public string PersonalMessage { get; private set; }


    public Bride()
    {

    }

    public Bride(string name, string surname, string personalMessage)
    {
        Name = name;
        Surname = surname;
        PersonalMessage = personalMessage;
    }

    public void Update(string name, string surname, string personalMessage)
    {
        Name = name;
        Surname = surname;
        PersonalMessage = personalMessage;
    }
}
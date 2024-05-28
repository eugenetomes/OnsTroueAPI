using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnsTrou.Domain.Entities.WeddingFeature
{
    public class Bride
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PersonalMessage { get; set; }

        public Bride(string name, string surname, string personalMessage)
        {
            Name = name;
            Surname = surname;
            PersonalMessage = personalMessage;
        }
    }
}

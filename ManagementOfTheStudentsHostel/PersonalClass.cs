using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementOfTheStudentsHostel
{
    public class PersonalClass
    {
        public string NamePersonal { get; set; }
        public string PostPersonal { get; set; }
        public string AdressPersonal { get; set; }
        public string PhonePersonal { get; set; }

        public PersonalClass() { }

        public PersonalClass(string namePersonal,
            string postPersonal,
            string adressPersonal,
            string phonePersonal)
        {
            NamePersonal = namePersonal;
            PostPersonal = postPersonal;
            AdressPersonal = adressPersonal;
            PhonePersonal = phonePersonal;
        }
    }
}

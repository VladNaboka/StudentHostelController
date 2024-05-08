using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementOfTheStudentsHostel
{
    public class MeropriatiaClass
    {
        public string NameEvent { get; set; }
        public string DescriptionEvent { get; set; }
        public DateTime DateEvent { get; set; }

        public MeropriatiaClass() { }

        public MeropriatiaClass(string nameEvent,
            string descriptionEvent,
            DateTime dateEvent)
        {
            NameEvent = nameEvent;
            DescriptionEvent = descriptionEvent;
            DateEvent = dateEvent;
        }
    }
}

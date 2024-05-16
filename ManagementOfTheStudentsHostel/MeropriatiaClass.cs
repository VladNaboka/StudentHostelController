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
        public string PlaceEvent { get; set; }
        public DateTime DateEvent { get; set; }
        public string ResponsibleEvent { get; set; }
        public string ExecutorEvent { get; set; }

        public MeropriatiaClass() { }

        public MeropriatiaClass(string nameEvent,
            string descriptionEvent,
            DateTime dateEvent,
            string responsibleEvent,
            string executorEvent)
        {
            NameEvent = nameEvent;
            PlaceEvent = descriptionEvent;
            DateEvent = dateEvent;
            ResponsibleEvent = responsibleEvent;
            ExecutorEvent = executorEvent;
        }
    }
}

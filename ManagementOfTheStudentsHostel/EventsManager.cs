using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ManagementOfTheStudentsHostel
{
    public class EventsManager
    {
        private List<MeropriatiaClass> events;
        private string filePath = "events.json";

        public EventsManager()
        {
            LoadEventsFromFile();
        }

        public void AddEvent(MeropriatiaClass newEvent)
        {
            // Проверка существования мероприятия с таким же названием
            if (events.Exists(e => e.NameEvent == newEvent.NameEvent))
            {
                throw new InvalidOperationException("Мероприятие с таким названием уже существует!");
            }

            // Добавление нового мероприятия
            events.Add(newEvent);

            // Сохранение обновленного списка мероприятий
            SaveEventsToFile();
        }

        public void UpdateEvent(MeropriatiaClass updatedEvent)
        {
            // Поиск мероприятия по имени и обновление его данных
            var existingEvent = events.Find(e => e.NameEvent == updatedEvent.NameEvent);
            if (existingEvent != null)
            {
                existingEvent.DescriptionEvent = updatedEvent.DescriptionEvent;
                existingEvent.DateEvent = updatedEvent.DateEvent;

                // Сохранение обновленного списка мероприятий
                SaveEventsToFile();
            }
            else
            {
                throw new InvalidOperationException("Мероприятие с таким названием не найдено!");
            }
        }

        private void SaveEventsToFile()
        {
            string json = JsonConvert.SerializeObject(events);
            File.WriteAllText(filePath, json);
        }

        private void LoadEventsFromFile()
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                events = JsonConvert.DeserializeObject<List<MeropriatiaClass>>(json);
            }
            else
            {
                events = new List<MeropriatiaClass>();
            }
        }
    }
}

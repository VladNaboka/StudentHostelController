using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementOfTheStudentsHostel
{
    public class FileManager
    {
        public UserClass user = new UserClass();

        private List<MeropriatiaClass> events;
        private string filePath = "events.json";

        //public EventsManager eventsManager;

        public FileManager() 
        { 
            LoadEventsFromFile();
        }

        public UserClass GetUser(string login)
        {
            // папка пользователя 
            string userFolder = Directory.GetCurrentDirectory() + "\\Users\\" + login;

            // файл пользователя 
            string infoFilePath = userFolder + "\\info.txt";

            UserClass userToReturn = new UserClass();

            // проверка сущестования файла пользователя
            if (!File.Exists(infoFilePath))
            {
                throw new LoginException("Такого пользоватея не существует!");
            }

            // файл есть, открываем его
            using (StreamReader sr = File.OpenText(infoFilePath))
            {
                userToReturn.Login = login;
                userToReturn.Password = sr.ReadLine();
                userToReturn.FullName = sr.ReadLine();
                userToReturn.Room = int.Parse(sr.ReadLine());
                userToReturn.AccessLevel = int.Parse(sr.ReadLine());
                userToReturn.CreateDate = DateTime.Parse(sr.ReadLine());
                userToReturn.IIN = sr.ReadLine();
            }

            // файл c заметками о пользователе
            string notesFilePath = userFolder + "\\notes.txt";
            // пытаемся открыть его, иначе ничего страшного
            if (File.Exists(notesFilePath))
            {
                using (StreamReader sr = File.OpenText(notesFilePath))
                {
                    userToReturn.Notes = sr.ReadToEnd();
                }
            }
            else
            {
                userToReturn.Notes = "";
            }
            return userToReturn;
        }

        public string GetTextInstr()
        {
            // файл c инструкцией для поселения
            string InstructionsFilePath = Directory.GetCurrentDirectory() + "\\instructions.txt";
            // пытаемся открыть его, иначе ничего страшного
            if (File.Exists(InstructionsFilePath))
            {
                using (StreamReader sr = File.OpenText(InstructionsFilePath))
                {
                    return sr.ReadToEnd();
                }
            }
            else
            {
               return "";
            }
            
        }

        public void Login(string login, string password)
        {
            // папка пользователя 
            string userFolder = Directory.GetCurrentDirectory() + "\\Users\\" + login;

            // файл пользователя 
            string infoFilePath = userFolder + "\\info.txt";

            // проверка сущестования файла пользователя
            if (!File.Exists(infoFilePath))
            {
                throw new LoginException("Такого пользоватея не существует!");
            }

            // файл есть, открываем его
            using (StreamReader sr = File.OpenText(infoFilePath))
            {
                // если пароли совпадают, то считываем файл дальше
                if (password == sr.ReadLine())
                {
                    user.Login = login;
                    user.Password = password;
                    user.FullName = sr.ReadLine();
                    user.Room = int.Parse(sr.ReadLine());
                    user.AccessLevel = int.Parse(sr.ReadLine());
                    user.CreateDate = DateTime.Parse(sr.ReadLine());
                    user.IIN = sr.ReadLine();
                }
                // иначе ошибка
                else
                {
                    throw new LoginException("Неверный пароль!");
                }
            }

            // файл c заметками о пользователе
            string notesFilePath = userFolder + "\\notes.txt";
            // пытаемся открыть его, иначе ничего страшного
            if (File.Exists(notesFilePath))
            {
                using (StreamReader sr = File.OpenText(notesFilePath))
                {
                    user.Notes = sr.ReadToEnd();
                }
            }
            else
            {
                user.Notes = "";
            }

        }
        public void CreateUser(UserClass newUser)
        {
            // папка c информацией пользователя (если он уже есть)
            string userFolder = Directory.GetCurrentDirectory() + "\\Users\\" + newUser.Login;

            // проверка сущестования файла пользователя
            if (File.Exists(userFolder))
            {
                throw new UserAlreadyExistException("Пользователь с логином "+ newUser.Login + " уже существует!");
            }
            else
            {
                Directory.CreateDirectory(userFolder);
                ChangeUser(newUser);
            }
        }

        public void ChangeUser(UserClass newUser)
        {
            // текущая папка проекта
            string startPath = Directory.GetCurrentDirectory();

            // файл c информацией пользователя
            string infoFilePath = startPath + "\\Users\\" + newUser.Login + "\\info.txt";

            // открываем его
            using (StreamWriter sw = File.CreateText(infoFilePath))
            {
                sw.WriteLine(newUser.Password);
                sw.WriteLine(newUser.FullName);
                sw.WriteLine(newUser.Room);
                sw.WriteLine(newUser.AccessLevel);
                sw.WriteLine(newUser.CreateDate);
                sw.WriteLine(newUser.IIN);
            }

            // файл c заметками о пользователе
            string notesFilePath = startPath + "\\Users\\" + newUser.Login + "\\notes.txt";
            // открываем его
            using (StreamWriter sw = File.CreateText(notesFilePath))
            {
                sw.Write(newUser.Notes);
            }
        }
        public bool IsLoginExists(string login)
        {
            // папка пользователя 
            string userFolder = Directory.GetCurrentDirectory() + "\\Users\\" + login;

            // проверяем существование папки пользователя
            return Directory.Exists(userFolder);
        }


        public List<UserClass> GetAllUsers()
        {
            List<UserClass> userstToReturn = new List<UserClass>();

            // получение всех пользователей в директории

            // текущая папка проекта
            string usersFolderPath = Directory.GetCurrentDirectory() + "\\Users\\";
            
            string[] usersFolders = Directory.GetDirectories(usersFolderPath);

            foreach (string folder in usersFolders)
            {
                //folderShortName == login
                string folderShortName = Path.GetFileName(folder);
                UserClass user = GetUser(folderShortName);

                //userstToReturn.Add(GetUser(folderShortName));

                // Проверяем, является ли пользователь студентом
                if (user.AccessLevel == Helper.AccessLevelTextToInt("Студент"))
                {
                    // Добавляем студента в список
                    userstToReturn.Add(user);
                }
            }

            return userstToReturn;
        }

        /// <summary>
        /// </summary>
        /// <param name="newEvent"></param>

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
        public MeropriatiaClass GetEvent(string nameEvent)
        {
            //// проверка сущестования файла пользователя
            //if (!File.Exists(nameEvent))
            //{
            //    throw new LoginException("Такого мероприятия не существует!");
            //}

            MeropriatiaClass eventData = events.Find(e => e.NameEvent == nameEvent);

            return eventData;
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

        public List<MeropriatiaClass> GetAllEvents()
        {
            // Проверяем, загружены ли мероприятия
            if (events == null)
            {
                LoadEventsFromFile();
            }

            return events;
        }

    }
}

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

        public List<MeropriatiaClass> events;
        public List<RoomsClass> rooms;
        public List<PersonalClass> personals;
        private string filePathEvent = "events.json";
        private string filePathRooms = "rooms.json";
        private string filePathPersonal = "personal.json";

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
                userToReturn.Faculty = sr.ReadLine();
                userToReturn.Speciality = sr.ReadLine();
                userToReturn.Gender = sr.ReadLine();
                userToReturn.FormLearning = sr.ReadLine();
                userToReturn.Course = int.Parse(sr.ReadLine());
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
                    user.Faculty = sr.ReadLine();
                    user.Speciality = sr.ReadLine();
                    user.Gender = sr.ReadLine();
                    user.FormLearning = sr.ReadLine();
                    user.Course = int.Parse(sr.ReadLine());
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
                sw.WriteLine(newUser.Faculty);
                sw.WriteLine(newUser.Speciality);
                sw.WriteLine(newUser.Gender);
                sw.WriteLine(newUser.FormLearning);
                sw.WriteLine(newUser.Course);
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

        public void DeleteUser(string login)
        {
            // папка пользователя 
            string userFolder = Directory.GetCurrentDirectory() + "\\Users\\" + login;

            // проверка сущестования папки пользователя
            if (Directory.Exists(userFolder))
            {
                Directory.Delete(userFolder, true); // true для рекурсивного удаления папки со всеми файлами
            }
            else
            {
                throw new InvalidOperationException("Пользователь с таким логином не найден!");
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="newEvent"></param>

        public void AddEvent(MeropriatiaClass newEvent)
        {
            //// Проверка существования мероприятия с таким же названием
            //if (events.Exists(e => e.NameEvent == newEvent.NameEvent))
            //{
            //    throw new InvalidOperationException("Мероприятие с таким названием уже существует!");
            //}

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
                existingEvent.PlaceEvent = updatedEvent.PlaceEvent;
                existingEvent.DateEvent = updatedEvent.DateEvent;
                existingEvent.NameEvent = updatedEvent.NameEvent;
                existingEvent.ExecutorEvent = updatedEvent.ExecutorEvent;

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
            File.WriteAllText(filePathEvent, json);
        }

        private void LoadEventsFromFile()
        {
            if (File.Exists(filePathEvent))
            {
                string json = File.ReadAllText(filePathEvent);
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

        public void DeleteEvent(string eventName)
        {
            var eventToDelete = events.Find(e => e.NameEvent == eventName);
            if (eventToDelete != null)
            {
                events.Remove(eventToDelete);
                SaveEventsToFile();
            }
            else
            {
                throw new InvalidOperationException("Мероприятие с таким названием не найдено!");
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="newRoom"></param>
        /// 

        public void AddRoom(RoomsClass newRoom)
        {

            // Добавление новой комнаты
            rooms.Add(newRoom);

            // Сохранение обновленного списка комнат
            SaveRoomsToFile();
        }

        public void UpdateRoom(RoomsClass updatedRoom)
        {
            // Поиск комнаты по имени и обновление ее данных
            var existingRoom = rooms.Find(e => e.NumberRoom == updatedRoom.NumberRoom);
            if (existingRoom != null)
            {
                existingRoom.FloorRoom = updatedRoom.FloorRoom;
                existingRoom.NumberRoom = updatedRoom.NumberRoom;
                existingRoom.SquareRoom = updatedRoom.SquareRoom;
                existingRoom.CountBadroom = updatedRoom.CountBadroom;
                existingRoom.CountWardrobe = updatedRoom.CountWardrobe;
                existingRoom.TableRoom = updatedRoom.TableRoom;
                existingRoom.ChairsRoom = updatedRoom.ChairsRoom;
                existingRoom.StoveRoom = updatedRoom.StoveRoom;
                existingRoom.ElectricRoom = updatedRoom.ElectricRoom;
                existingRoom.WiFiRoom = updatedRoom.WiFiRoom;

                // Сохранение обновленного списка комнат
                SaveRoomsToFile();
            }
            else
            {
                throw new InvalidOperationException("Комната с таким названием не найдена!");
            }
        }
        public RoomsClass GetRoom(int numberRoom)
        {
            RoomsClass roomData = rooms.Find(e => e.NumberRoom == numberRoom);

            return roomData;
        }

        private void SaveRoomsToFile()
        {
            string json = JsonConvert.SerializeObject(rooms);
            File.WriteAllText(filePathRooms, json);
        }

        private void LoadRoomsFromFile()
        {
            if (File.Exists(filePathRooms))
            {
                string json = File.ReadAllText(filePathRooms);
                rooms = JsonConvert.DeserializeObject<List<RoomsClass>>(json);
            }
            else
            {
                rooms = new List<RoomsClass>();
            }
        }

        public List<RoomsClass> GetAllRooms()
        {
            // Проверяем, загружены ли комнаты
            if (rooms == null)
            {
                LoadRoomsFromFile();
            }

            return rooms;
        }
        public void DeleteRoom(int roomNumber)
        {
            var roomToDelete = rooms.Find(r => r.NumberRoom == roomNumber);
            if (roomToDelete != null)
            {
                rooms.Remove(roomToDelete);
                SaveRoomsToFile();
            }
            else
            {
                throw new InvalidOperationException("Комната с таким номером не найдена!");
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="newPersonal"></param>

        public void AddPersonal(PersonalClass newPersonal)
        {

            // Добавление нового сотрудника
            personals.Add(newPersonal);

            // Сохранение обновленного списка сотрудников
            SavePersonalToFile();
        }

        public void UpdatePersonal(PersonalClass updatedPersonal)
        {
            // Поиск сотрудника по имени и обновление ее данных
            var existingPersonal = personals.Find(e => e.NamePersonal == updatedPersonal.NamePersonal);
            if (existingPersonal != null)
            {
                existingPersonal.NamePersonal = updatedPersonal.NamePersonal;
                existingPersonal.PostPersonal = updatedPersonal.PostPersonal;
                existingPersonal.AdressPersonal = updatedPersonal.AdressPersonal;
                existingPersonal.PhonePersonal = updatedPersonal.PhonePersonal;

                // Сохранение обновленного списка сотрудников
                SavePersonalToFile();
            }
            else
            {
                throw new InvalidOperationException("Комната с таким названием не найдена!");
            }
        }
        public PersonalClass GetPersonal(string numberPersonal)
        {
            PersonalClass personalData = personals.Find(e => e.NamePersonal == numberPersonal);

            return personalData;
        }

        private void SavePersonalToFile()
        {
            string json = JsonConvert.SerializeObject(personals);
            File.WriteAllText(filePathPersonal, json);
        }

        private void LoadPersonalFromFile()
        {
            if (File.Exists(filePathPersonal))
            {
                string json = File.ReadAllText(filePathPersonal);
                personals = JsonConvert.DeserializeObject<List<PersonalClass>>(json);
            }
            else
            {
                personals = new List<PersonalClass>();
            }
        }

        public List<PersonalClass> GetAllPersonal()
        {
            // Проверяем, загружены ли сотрудники
            if (personals == null)
            {
                LoadPersonalFromFile();
            }

            return personals;
        }

        public void DeletePersonal(string personalName)
        {
            var personalToDelete = personals.Find(p => p.NamePersonal == personalName);
            if (personalToDelete != null)
            {
                personals.Remove(personalToDelete);
                SavePersonalToFile();
            }
            else
            {
                throw new InvalidOperationException("Персонал с таким именем не найден!");
            }
        }
    }
}

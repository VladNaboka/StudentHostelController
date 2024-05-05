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
        
        public FileManager() { }

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
                throw new UserAlreadyExistException("Пользователь с логином "+ newUser.Login+" уже существует!");
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
            }

            // файл c заметками о пользователе
            string notesFilePath = startPath + "\\Users\\" + newUser.Login + "\\notes.txt";
            // открываем его
            using (StreamWriter sw = File.CreateText(notesFilePath))
            {
                sw.Write(newUser.Notes);
            }
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
                // folderShortName == login
                string folderShortName = Path.GetFileName(folder);
                userstToReturn.Add(GetUser(folderShortName));
            }

            return userstToReturn;
        }
    }
}

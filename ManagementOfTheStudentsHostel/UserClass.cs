using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementOfTheStudentsHostel
{
    public class UserClass
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public int Room { get; set; }
        public int AccessLevel { get; set; }
        public string AccessLevelString {
            // Только для чтения
            get
            {
                return Helper.AccessLevelIntToText(AccessLevel);
            }
        }
        public DateTime CreateDate { get; set; }
        public string Notes { get; set; }
        public string IIN { get; set; }
        public string Faculty { get; set; }
        public string Speciality { get; set; }
        public string Gender { get; set; }
        public string FormLearning { get; set; }
        public int Course { get; set; }

        public bool IsGuest { get; set; }

        public UserClass() { }

        public UserClass(string login,
            string password,
            string fullName,
            int room,
            int accessLevel,
            DateTime createDate,
            string notes,
            int iin,
            string faculty,
            string speciality,
            string gender,
            string formLearning,
            int course,
            bool isGuest)
        {
            Login = login;
            Password = password;
            FullName = fullName;
            Room = room;
            AccessLevel = accessLevel;
            CreateDate = createDate;
            Notes = notes;
            IIN = iin.ToString();
            Faculty = faculty;
            Speciality = speciality;
            Gender = gender;
            FormLearning = formLearning;
            Course = course;
            IsGuest = isGuest;
        }

    }
}

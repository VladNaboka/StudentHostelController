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

        public UserClass() { }

        public UserClass(string login,
            string password,
            string fullName,
            int room,
            int accessLevel,
            DateTime createDate,
            string notes)
        {
            Login = login;
            Password = password;
            FullName = fullName;
            Room = room;
            AccessLevel = accessLevel;
            CreateDate = createDate;
            Notes = notes;
        }

    }
}

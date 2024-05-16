using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementOfTheStudentsHostel
{
    public static class Helper
    {
        public static string AccessLevelIntToText(int accessLevel)
        {
            switch (accessLevel)
            {
                case 0: return "Студент";
                case 1: return "Воспитатель";
                case 2: return "Комендант";
            }
            throw new ArgumentOutOfRangeException("Нет такого уровня доступа!");
        }

        public static int AccessLevelTextToInt(string accessLevel)
        {
            switch (accessLevel)
            {
                case "Студент": return 0;
                case "Воспитатель": return 1;
                case "Комендант": return 2;
            }
            throw new ArgumentOutOfRangeException("Нет такого уровня доступа!");
        }
    }
}

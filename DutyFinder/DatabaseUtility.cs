using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DutyFinder
{
    public class DatabaseUtility
    {
        public DatabaseUtility()
        {
            
        }

        public void InsertData(string code, int duty)
        {
            Console.WriteLine("Код ТНВЭД: " + code + "  Пошлина: " + duty + "%");
        }
    }
}

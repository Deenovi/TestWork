using DutyFinder;
using DutyFinder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DummyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            CodeInfoProvider codeInfoProvider = new CodeInfoProvider();
            DatabaseUtility databaseUtility = new DatabaseUtility();
            int maxDutyValue;
            string templateCode;

            Console.Title = "Поиск номеров ТНВЭД с максимальными пошлинами";
            Console.Write("Пожалуйста введите номер ТНВЭД: ");
            templateCode = Console.ReadLine(); //Code = 6102901000
            Console.WriteLine("Идет обработка...");
      
            List<CodeInfo> codeInfoList = codeInfoProvider
                                          .GetCodeInfoList(templateCode)
                                          .OrderByDescending((x) => x.Duty).ToList();

            if (codeInfoList.Count > 0)
            {
                maxDutyValue = codeInfoList[0].Duty;

                foreach (var codeInfo in codeInfoList)
                {
                    if (codeInfo.Duty == maxDutyValue)
                    {
                        databaseUtility.InsertData(codeInfo.Code, codeInfo.Duty);
                    }
                }
            }

            Console.ReadLine();
        }
    }
}

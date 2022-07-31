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
            int maxDutyValue;
            string templateCode;

            Console.Title = "Поиск номеров ТНВЭД с максимальными пошлинами";
            Console.Write("Пожалуйста введите номер ТНВЭД: ");
            templateCode = Console.ReadLine(); //Code = 6102901000
            Console.WriteLine("Идет обработка...\n");
      
            List<CodeInfo> codeInfoList = codeInfoProvider
                                          .GetCodeInfoList(templateCode)
                                          .OrderByDescending((x) => x.Duty).ToList();

            if (codeInfoList.Count > 0)
            {
                maxDutyValue = codeInfoList[0].Duty;

                Console.WriteLine("Номер ТНВЭД\tПошлина");

                foreach (var codeInfo in codeInfoList)
                {
                    if (codeInfo.Duty == maxDutyValue)
                    {
                        Console.WriteLine(codeInfo.Code + "\t" + codeInfo.Duty + "%");
                    }
                }
            }
            else
            {
                Console.WriteLine("Номера не найдены");
            }


            Console.ReadLine();
        }
    }
}

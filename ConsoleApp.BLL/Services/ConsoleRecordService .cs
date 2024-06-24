using ConsoleApp.Common.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.BLL.Services
{
    public class ConsoleRecordService : IRecordService
    {
        public void ProcessRecord(string text)
        {
            Console.WriteLine(text);
        }
    }
}

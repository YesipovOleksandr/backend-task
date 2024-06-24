using ConsoleApp.Common.Abstract;

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

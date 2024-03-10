using System.Net;
using ZplPrinter.Library.Abstractions;

namespace ZplPrinter.Library.Infrastructure
{
    internal class ConsolePrinterService : IPrinterService
    {
        public void Print(string content)
        {
            Console.WriteLine(content);
        }
    }
}

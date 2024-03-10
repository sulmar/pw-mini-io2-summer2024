using System.Net;
using ZplPrinter.Library.Abstractions;

namespace ZplPrinter.Library.Infrastructure
{
    internal class ConsolePrinter : IPrinterService
    {
        public void Print(string content)
        {
            Console.WriteLine(content);
        }
    }
}

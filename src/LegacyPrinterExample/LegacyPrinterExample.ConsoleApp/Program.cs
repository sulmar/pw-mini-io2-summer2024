
using LegacyPrinterExample;
using System.Reflection;

Console.WriteLine("Hello, Printer!");

// TODO: Dodaj obliczanie kosztu wydruku i licznik do starej drukarki

bool legacy = false;

string document = "Hello World!";
int copies = 3;

IPrinterAdapter printer;

if (legacy)
{
     printer = new LegacyPrinterAdapter();   
}
else
{
    printer = new Printer();
}

var printer2 = new CounterPrinterDecorator(
       new CostPrinterDecorator(printer));

printer2.Print(document, copies);
Console.WriteLine($"Counter: {printer2.Counter}");
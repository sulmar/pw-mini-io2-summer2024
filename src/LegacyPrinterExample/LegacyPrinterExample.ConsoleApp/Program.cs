
using LegacyPrinterExample;

Console.WriteLine("Hello, Printer!");

// TODO: Dodaj obliczanie kosztu wydruku i licznik do starej drukarki

bool legacy = true;

string document = "Hello World!";
int copies = 3;

CounterPrinterProxy printer = new CounterPrinterProxy(
    new CostPrinterDecorator(
        PrinterFactory.Create(legacy), new CostPrinterCalculatorStrategy()));

printer.Print(document, copies);
Console.WriteLine($"Counter: {printer.Counter}");
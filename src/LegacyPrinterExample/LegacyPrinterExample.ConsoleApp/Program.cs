
using LegacyPrinterExample;

Console.WriteLine("Hello, Printer!");

// TODO: Dodaj obliczanie kosztu wydruku i licznik do starej drukarki

bool legacy = false;

string document = "Hello World!";
int copies = 3;


if (legacy)
{
    LegacyPrinter printer = new LegacyPrinter();

    for (int i = 0; i < copies; i++)
    {
        printer.PrintDocument(document);
    }
}
else
{
    Printer printer = new Printer();
    printer.Print(document, copies);
    Console.WriteLine($"Counter: {printer.Counter}");
}
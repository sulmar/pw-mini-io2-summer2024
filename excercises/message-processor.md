## Message Processor

## Wprowadzenie
Firma zamierza uruchomić skrzynkę mailową na zamówienia od swoich handlowców. Potrzebuje aplikacji, która automatycznie będzie przetwarzać przychodzące wiadomości, analizować je i zapisywać w bazie danych. 

## Zadanie

Utwórz klasę _MessageProcessor_ z metodą _void Process(Message message)_ do przetwarzania wiadomości mailowych:
```csharp
public class Message
{
    public string From { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }

    public Message(string from, string title, string body)
    {
        From = from;
        Title = title;
        Body = body;
    }       
}
```

Wymagania realizuj zgodnie z techniką **TDD** (_Test-driven-development_):

- **Red** - kod nieprzechodzący test
- **Green** - kod przechodzący test
- **Refactor** - refaktoryzacja kodu i testów

## Wymagania

1. W przypadku pustej wiadomości (pusty nadawca, temat lub treść) metoda powinna rzucić wyjątkiem _ArgumentException_ z komunikatem, którego pola dotyczy.
2. Jeśli nadawca wiadomości jest spoza białej listy _whitelist_ to powinien rzucić wyjątkiem _InvalidOperationException_.
3. Jeśli tytuł wiadomości nie zawiera słowa `ORDER` to powinien rzucić wyjątkiem _FormatException_.
4. Treść wiadomości powinna być zapisana w bazie danych.

Pamiętaj o robieniu na bieżąco commitów do Gita.


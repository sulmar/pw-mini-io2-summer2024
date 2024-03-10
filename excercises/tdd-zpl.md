# Ćwiczenie TDD - ZPL

## Wprowadzenie

Sklep internetowy potrzebuje drukowania etykiet na produktach. Sklep korzysta z sieciowych drukarek termicznych, które obsługują popularny format ZPL.

Przykładowy kod w C# do drukowania w sieci po protokole TCP wygląda następująco:
``` csharp
 TcpClient tcpClient = new TcpClient();
 tcpClient.Connect(ipAdress, port);

 var stream = new StreamWriter(tcpClient.GetStream());
 stream.Write(content);
 stream.Flush(); 
 stream.Close();
 tcpClient.Close();
```

lecz nie mamy dostępnej drukarki.

## Zadanie
Przygotuj bibliotekę **LabelGenerator**, która umożliwi drukowanie etykiet w formacie _ZPL_.

Wymagania realizuj pojedynczo w cyklu:
- nowe wymaganie
- test pod wymagania (Red)
- kod przechodzący test (Green)
- refaktoryzacja kodu i testów (Refactor)


## Wymagania

1. Dodaj metodę to drukowania pola na etykiecie:
```
^XA
^FDHello World
^XZ
```

2. Pusty string powinien rzucać wyjątek.
3. Dodaj metodę do ustawienia położenia pola
```
^XA
^FO50,50
^FDHello World
^XZ
```
4. Przekroczenie limitów powinno rzucać wyjątek.
5. Dodaj metodę do separatora pola `^FS`
6. Dodaj możliwość zmiany rozmiaru czcionki
```
^XA
^ADN,36,20^FDYour Name
^XZ
```
7. Dodaj możliwość zmiany orientacji czcionki
8. Dodaj metodę do drukowania kodu kreskowego w formacie _code 39_
```
^XA
^B3N,N,100,Y,N
^FD123456^FS
^XZ
```
9. Pusty string powinien rzucać wyjątek.
10. Dodaj metodę do drukowania kodu kreskowego w formacie _qrcode_
```
^XA
^FO20,20
^BQ,2,10
^FDQA,Your Name^FS
^XZ
```

## Dokumentacja
- Labelary Engine Documentation https://labelary.com/docs.html
- ZPL Commands https://support.zebra.com/cpws/docs/zpl/zpl_Exercises.pdf
- ZPL II Programming Guide https://www.servopack.de/support/zebra/ZPLII-Prog.pdf

## Wizualizacja
- ZPL Online Viewer https://labelary.com/viewer.html

## TDD - Automation Test - Kalkulator rabatów

## Wprowadzenie

Sklep internetowy przygotowuje się do uruchomienia promocji. Każdy kupujący będzie mógł skorzystać z okazji, wprowadzając specjalny kod kuponu podczas procesu zamawiania. System automatycznie przeliczy cenę na podstawie udzielonego rabatu.

## Zadanie

Utwórz kalkulator _DiscountCalculator_ z metodą _CalculateDiscount(decimal price, string discountCode)_ do obliczania ceny na podstawie kodu kuponu według poniższych wymagań.

Wymagania realizuj zgodnie z techniką **TDD** (_Test-driven-development_):

- **Red** - kod nieprzechodzący test
- **Green** - kod przechodzący test
- **Refactor** - refaktoryzacja kodu i testów

## Wymagania

1. W przypadku podania pustego kodu rabat nie będzie udzielany.
2. Dodaj rabat 10%, który będzie naliczany po podaniu kodu kuponu `SAVE10NOW`.
3. Dodaj rabat 20%, który będzie naliczany po podaniu kodu kuponu `DISCOUNT20OFF`.
4. Wywołanie metody _CalculateDiscount_ z ujemną ceną powinno rzucić wyjątkiem _ArgumentException_ z komunikatem _"Negatives not allowed"_.
5. W przypadku błędnego kodu powinien być zwracany wyjątek _ArgumentException_ z komunikatem _"Invalid discount code"_

[6. Dodaj rabat 50%, który jest naliczany jednorazowo na podstawie kodu z puli kodów.]

Pamiętaj o robieniu na bieżąco commitów do Gita.

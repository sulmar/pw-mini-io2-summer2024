# Zasady FIRST

To zestaw zasad, które definiują dobre praktyki przy tworzeniu testów jednostkowych:

1. **Fast (Szybkie)**:
   - Testy powinny być szybkie w swoim wykonaniu. Szybkie testy pozwalają programistom na częste uruchamianie ich podczas procesu programowania bez opóźnień. To umożliwia szybką informację zwrotną o stanie kodu i zmniejsza czas potrzebny na debugowanie.
2. **Independent (Niezależne)**:
   - Każdy test powinien być niezależny od innych testów. Oznacza to, że wynik jednego testu nie powinien wpływać na wynik innych testów, co zapewnia bardziej stabilne i wiarygodne testowanie.
3. **Repeatable (Powtarzalne)**:
   - Testy powinny być powtarzalne w różnych środowiskach i czasach. Oznacza to, że wyniki testów powinny być spójne i przewidywalne, bez względu na warunki, w których są wykonywane.
4. **Self-checking (Automatyczne)**:
   - Testy powinny być automatyczne i nie wymagać interakcji użytkownika. Automatyzacja testów pozwala na szybsze i bardziej efektywne sprawdzanie poprawności kodu, a także ułatwia proces weryfikacji zmian.
5. **Timely (Pisane na bieżąco)**:
   - Testy powinny być pisane na bieżąco, równolegle z procesem programowania. Pisane na bieżąco testy są łatwiejsze do utrzymania, a także pomagają w zapewnieniu, że kod działa zgodnie z oczekiwaniami od samego początku jego tworzenia.

# Cykl Red-Greeen-Refactor

Cykl Red-Green-Refactor to podejście używane przez programistów do iteratywnego tworzenia wysokiej jakości kodu:

1. **Red (Czerwony)**:
   - Napisz test, który nie przechodzi („czerwony”)
2. **Green (Zielony)**:
   - Zaimplementuj minimalny kod, aby test przeszedł („zielony”).
3. **Refactor (Refaktorowanie)**:
   - Popraw kod, zachowując jego funkcjonalność.

To cykl, który powtarza się, pomagając w stopniowym rozwoju kodu przy zachowaniu jakości i elastyczności.

# Zasada Arrange-Act-Assert

Testy powinny mieć określoną strukturę:

1. **Arrange**:
   - Przygotuj się wszystko, co jest potrzebne do wykonania testu
2. **Act**:
   - Wywołaj operację, którą należy przetestować
3. **Assert**:
   - Sprawdź, czy otrzymany wynik jest taki jak oczekiwany.

## Szablon testu

```csharp
public class MyLibraryTests
{
  [Fact]
  public void Method_Scenario_ExpectedBehavior()
  {
      // Arrange

      // Act

      // Assert
  }
}
```

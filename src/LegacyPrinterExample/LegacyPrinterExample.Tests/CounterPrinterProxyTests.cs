namespace LegacyPrinterExample.Tests
{
    internal class FakePrinter : IPrinter
    {
        public int Counter => throw new NotImplementedException();

        public void Print(string document, int copies = 1)
        {           
        }
    }

    public class CounterPrinterProxyTests
    {
        [Fact]
        public void Print_WhenCalled_ShouldSetCounter()
        {
            CounterPrinterProxy sut = new CounterPrinterProxy(new FakePrinter());

            sut.Print("a", 3);

            Assert.Equal(3, sut.Counter);

        }
    }
}
namespace VendingMachineSimulation.Tests
{
    public class VendingMachineTests
    {
        [Fact]
        public void Constructor_WhenCalled_StateIdle()
        {
            VendingMachine sut = new VendingMachine();

            Assert.NotNull(sut);
            Assert.Equal(State.Idle, sut.State);
        }

        [Fact]
        public void SelectProduct_NoSelected_StateSelecting()
        {
            var sut = new VendingMachine();
            var product = new BasicProduct();

            sut.SelectProduct(product);

            Assert.Equal(State.Selecting, sut.State);
        }

        [Fact]
        public void SelectProduct_AnySelected_StateSelecting()
        {
            var sut = new VendingMachine();
            var product = new BasicProduct();
            sut.SelectProduct(product);
            
            sut.SelectProduct(product);

            Assert.Equal(State.Selecting, sut.State);
        }

        [Fact]
        public void ConfirmSelected_WhenAnySelected_StateCheckout()
        {
            var sut = new VendingMachine();
            var product = new BasicProduct();
            sut.SelectProduct(product);

            sut.ConfirmSelected();

            Assert.Equal(State.Checkout, sut.State);
        }

        [Fact]
        public void ConfirmSelected_InvalidState_ThrowsInvalidOperationException()
        {
            var sut = new VendingMachine();

            var act = () => sut.ConfirmSelected();

            Assert.Throws<InvalidOperationException>(act);
        }

        // TODO: MORE TESTS
    }
}
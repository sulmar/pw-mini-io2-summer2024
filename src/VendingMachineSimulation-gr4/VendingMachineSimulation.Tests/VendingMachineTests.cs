namespace VendingMachineSimulation.Tests
{
    public class VendingMachineTests
    {
        [Fact]
        public void Constructor_WhenCalled_StateIdle()
        {
            VendingMachine sut = new VendingMachine();

            Assert.NotNull(sut);
            Assert.IsType<Idle>(sut.State);
        }

        [Fact]
        public void SelectProduct_NoSelected_StateSelecting()
        {
            var sut = new VendingMachine();
            var product = new BasicProduct();

            sut.SelectProduct(product);

            Assert.IsType<Selecting>(sut.State);
        }

        [Fact]
        public void SelectProduct_AnySelected_StateSelecting()
        {
            var sut = new VendingMachine();
            var product = new BasicProduct();
            sut.SelectProduct(product);

            sut.SelectProduct(product);

            Assert.IsType<Selecting>(sut.State);
        }

        [Fact]
        public void ConfirmSelected_WhenAnySelected_StateCheckout()
        {
            var sut = new VendingMachine();
            var product = new BasicProduct();
            sut.SelectProduct(product);

            sut.ConfirmSelected();

            Assert.IsType<Checkout>(sut.State);
        }

        [Fact]
        public void ConfirmSelected_InvalidState_ThrowsInvalidOperationException()
        {
            var sut = new VendingMachine();

            var act = () => sut.ConfirmSelected();

            Assert.Throws<InvalidOperationException>(act);
        }

        // TODO: MORE TESTS
        [Fact]
        public void DeleteProduct_ProductNotFound_ThrowsInvalidOperationException()
        {
            var sut = new VendingMachine();
            var product = new BasicProduct();
            sut.SelectProduct(product);

            var act = () => sut.DeleteProduct(new BasicProduct());

            Assert.Throws<InvalidOperationException>(act);
        }

        [Fact]
        public void DeleteProduct_SelectedProduct_RemoveSelectedProduct()
        {
            var sut = new VendingMachine();
            var product = new BasicProduct();
            sut.SelectProduct(product);

            sut.DeleteProduct(product);

            Assert.True(sut.IsEmpty());
            Assert.IsType<Idle>(sut.State);
        }

        [Fact]
        public void DeleteProduct_SelectProductTwice_RemoveOnlyOneSelectedProduct()
        {
            var sut = new VendingMachine();
            var product1 = new BasicProduct();
            var product2 = new BasicProduct();
            sut.SelectProduct(product1);
            sut.SelectProduct(product2);

            sut.DeleteProduct(product1);

            Assert.False(sut.IsEmpty());
            Assert.IsType<Selecting>(sut.State);
        }

        [Fact]
        public void ClearSelected_SelectMultipleProducts_RemoveAllSelectedProducts()
        {
            var sut = new VendingMachine();
            var product1 = new BasicProduct();
            var product2 = new BasicProduct();
            sut.SelectProduct(product1);
            sut.SelectProduct(product2);

            sut.ClearSelected();

            Assert.True(sut.IsEmpty());
            Assert.IsType<Idle>( sut.State);
        }

        [Fact]
        public void ClearSelected_Empty_ThrowsInvalidOperationException()
        {
            var sut = new VendingMachine();

            var act = () => sut.ClearSelected();

            Assert.Throws<InvalidOperationException>(act);
        }

        [Fact]
        public void Pay_FullPrice_StateShouldBeIdle()
        {
            var sut = new VendingMachine();
            var product = new BasicProduct() { Price = 1 };
            sut.SelectProduct(product);
            sut.ConfirmSelected();

            sut.Pay(PaymentMethod.Cash, 1);

            Assert.IsType<Idle>(sut.State);
        }

        [Fact]
        public void Pay_HalfPrice_StateShouldBeAwatingPayment()
        {
            var sut = new VendingMachine();
            var product = new BasicProduct() { Price = 1 };
            sut.SelectProduct(product);
            sut.ConfirmSelected();

            sut.Pay(PaymentMethod.Cash, 0.5m);

            Assert.IsType<AwaitingPayment>(sut.State);
        }

        [Fact]
        public void Pay_Idle_ShouldThrowsInvalidOperationException()
        {
            var sut = new VendingMachine();

            var act = () => sut.Pay(PaymentMethod.Cash, 1);

            Assert.Throws<InvalidOperationException>(act);
        }

        [Fact]
        public void Pay_HalfPriceTwice_StateShouldBeIdle()
        {
            var sut = new VendingMachine();
            var product = new BasicProduct() { Price = 1 };
            sut.SelectProduct(product);
            sut.ConfirmSelected();
            sut.Pay(PaymentMethod.Cash, 0.5m);

            sut.Pay(PaymentMethod.Cash, 0.5m);

            Assert.IsType<Idle>( sut.State);
        }

        [Fact]
        public void Pay_NonPositivePrice_ShouldThrowsArgumentException()
        {
            var sut = new VendingMachine();
            var product = new BasicProduct() { Price = 1 };
            sut.SelectProduct(product);
            sut.ConfirmSelected();

            var act = () => sut.Pay(PaymentMethod.Cash, -1);

            Assert.Throws<ArgumentException>(act);
        }

        [Fact]
        public void CancelPayment_AwaitingPayment_ShouldSetCheckoutState()
        {
            var sut = new VendingMachine();
            var product = new BasicProduct() { Price = 1 };
            sut.SelectProduct(product);
            sut.ConfirmSelected();
            sut.Pay(PaymentMethod.Cash, 0.5m);

            sut.CancelPayment();

            Assert.IsType<Checkout>(sut.State);
        }

        [Fact]
        public void CancelPayment_NotInAwaitingPayment_ShouldThrowsInvalidOperationException()
        {
            var sut = new VendingMachine();

            var act = () => sut.CancelPayment();

            Assert.Throws<InvalidOperationException>(act);
        }
    }
}
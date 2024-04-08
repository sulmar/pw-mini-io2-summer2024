namespace VendingMachineSimulation
{
    public interface IProduct
    {
        string Name { get; }
        decimal Price { get; }
    }

    public class BasicProduct : IProduct
    {
        public string Name { get; }
        public decimal Price { get; }
    }

    public enum PaymentMethod
    {
        Card,
        Cash,
        Blik
    }

    public enum State
    {
        Idle,
        Selecting,
        Checkout,
        AwaitingPayment
    }

    public class VendingMachine
    {
        public VendingMachine()
        {
            State = State.Idle;
        }

        public State State { get; private set; }

        private List<IProduct> selectedProducts = new List<IProduct>();

        public void SelectProduct(IProduct product)
        {
            if (State != State.Idle && State != State.Selecting)
                throw new InvalidOperationException();
            
            selectedProducts.Add(product);

            State = State.Selecting;
        }

        public void ConfirmSelected()
        {
            if (State != State.Selecting)
                throw new InvalidOperationException();

            State = State.Checkout;
        }

        public void DeleteProduct(IProduct product)
        {
            throw new NotImplementedException();
        }

        public void ClearSelected()
        {
            throw new NotImplementedException();
        }

        public void Pay(PaymentMethod method)
        {
            throw new NotImplementedException();
        }

        public void ConfirmPayment()
        {
            throw new NotImplementedException();
        }

        public void CancelPayment()
        {
            throw new NotImplementedException();
        }


    }
}

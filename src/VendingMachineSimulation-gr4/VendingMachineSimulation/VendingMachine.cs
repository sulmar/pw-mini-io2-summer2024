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
        public decimal Price { get; set; }
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

        private Decimal balance = 0;

        public bool IsEmpty()
        {
            return selectedProducts.Count == 0;
        }

        private decimal TotalPrice => selectedProducts.Sum(p => p.Price);

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
            if (!selectedProducts.Contains(product))
                throw new InvalidOperationException();

            selectedProducts.Remove(product);

            if (IsEmpty())
                this.State = State.Idle;
        }

        public void ClearSelected()
        {
            if (IsEmpty())
                throw new InvalidOperationException();

            selectedProducts.Clear();
            this.State = State.Idle;
        }

        public void Pay(PaymentMethod method, decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException();

            if (this.State != State.Checkout && this.State != State.AwaitingPayment)
                throw new InvalidOperationException();

            this.State = State.AwaitingPayment;

            this.balance += amount;

            if (this.balance >= TotalPrice)
                ConfirmPayment();
        }

        private void ConfirmPayment()
        {
            this.balance = 0;
            this.State = State.Idle;
        }

        public void CancelPayment()
        {
            if (this.State != State.AwaitingPayment)
                throw new InvalidOperationException();

            this.balance = 0;
            this.State = State.Checkout;
        }
    }
}

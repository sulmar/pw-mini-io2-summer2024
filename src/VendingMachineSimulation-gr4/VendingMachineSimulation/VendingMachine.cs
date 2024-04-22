using Stateless;

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

    public enum Trigger
    {
        SelectProduct,
        Cancel,
        Pay,
        Confirm,
        DeleteProduct
    }

    public class VendingMachine
    {
        private StateMachine<State, Trigger> machine;

        public VendingMachine()
        {
            machine = new StateMachine<State, Trigger>(State.Idle);

            machine.Configure(State.Idle)
                .Permit(Trigger.SelectProduct, State.Selecting);

            machine.Configure(State.Selecting)
                .PermitReentry(Trigger.SelectProduct)
                .Permit(Trigger.Confirm, State.Checkout)
                .Permit(Trigger.Cancel, State.Idle)
                .PermitReentry(Trigger.DeleteProduct)
                ;

            machine.Configure(State.Checkout)
                .PermitIf(Trigger.Pay, State.AwaitingPayment, () => Balance < TotalPrice)
                .PermitIf(Trigger.Pay, State.Idle, () => Balance >= TotalPrice);

            machine.Configure(State.AwaitingPayment)
                .Permit(Trigger.Confirm, State.Idle)
                .Permit(Trigger.Cancel, State.Checkout);


            Console.WriteLine(Graph);

        }

        public string Graph => Stateless.Graph.UmlDotGraph.Format( machine.GetInfo());

        public State State => machine.State;

        public List<IProduct> selectedProducts = new List<IProduct>();

        public decimal Balance { get; set; } = 0;

        public bool IsEmpty()
        {
            return selectedProducts.Count == 0;
        }

        public decimal TotalPrice => selectedProducts.Sum(p => p.Price);

        public void SelectProduct(IProduct product)
        {
            selectedProducts.Add(product);

            machine.Fire(Trigger.SelectProduct);
        }

        public void ConfirmSelected()
        {
            machine.Fire(Trigger.Confirm);
        }

        public void DeleteProduct(IProduct product)
        {
            if (!selectedProducts.Contains(product))
                throw new InvalidOperationException();

            selectedProducts.Remove(product);

            machine.Fire(Trigger.DeleteProduct);
        }

        public void ClearSelected()
        {
            if (IsEmpty())
                throw new InvalidOperationException();

            selectedProducts.Clear();

            machine.Fire(Trigger.Cancel);
        }

        public void Pay(PaymentMethod method, decimal amount)
        {
            machine.Fire(Trigger.Pay);
        }

        public void ConfirmPayment()
        {
            this.Balance = 0;

        }

        public void CancelPayment()
        {
            Balance = 0;
            machine.Fire(Trigger.Cancel);
        }



    }
}

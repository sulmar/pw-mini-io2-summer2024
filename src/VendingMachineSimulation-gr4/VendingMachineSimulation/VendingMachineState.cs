namespace VendingMachineSimulation
{
    // Abstract State
    public abstract class VendingMachineState
    {
        protected VendingMachine vendingMachine;

        protected VendingMachineState(VendingMachine vendingMachine)
        {
            this.vendingMachine = vendingMachine;
        }

        public virtual void SelectProduct(IProduct product)
        {
            throw new InvalidOperationException();
        }

        public virtual void ClearSelected()
        {
            throw new InvalidOperationException();
        }
        public virtual void DeleteProduct(IProduct product)
        {
            throw new InvalidOperationException();
        }
        public virtual void ConfirmSelected()
        {
            throw new InvalidOperationException();
        }
        public virtual void Pay(PaymentMethod paymentMethod, decimal amount)
        {
            throw new InvalidOperationException();
        }

        public virtual void CancelPayment()
        {
            throw new InvalidOperationException();
        }
    }
}

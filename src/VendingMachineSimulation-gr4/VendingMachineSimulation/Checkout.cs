namespace VendingMachineSimulation
{
    public class Checkout : VendingMachineState
    {
        public Checkout(VendingMachine vendingMachine) : base(vendingMachine)
        {
        }



        public override void Pay(PaymentMethod paymentMethod, decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException();

            vendingMachine.State = new AwaitingPayment(vendingMachine);

            vendingMachine.Balance += amount;

            if (vendingMachine.Balance >= vendingMachine.TotalPrice)
            { 
                vendingMachine.ConfirmPayment();
                vendingMachine.State = new Idle(vendingMachine);
            }
        }

        public override void CancelPayment()
        {
            vendingMachine.Balance = 0;
            vendingMachine.State =new Checkout(vendingMachine);
        }

    }
}

namespace Vending_Machine_Demo;

public class AwaitingPayment : VendingMachineState
{
    public AwaitingPayment(VendingMachine vendingMachine) : base(vendingMachine)
    {
    }

    public override void CancelPayment()
    {
        vendingMachine.MachineState = new ProductSelected(vendingMachine);
    }

    public override void InsertCoin(decimal amount)
    {
        vendingMachine.Balance += amount;

        if (vendingMachine.Balance > 10m)
        {
            Dispense();
        }

    }

    private void Dispense()
    {
        vendingMachine.Balance = 0;

        vendingMachine.MachineState = new Idle(vendingMachine);
    }

}

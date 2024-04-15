namespace Vending_Machine_Demo;

// Concrete State

public class Idle : VendingMachineState
{
    public Idle(VendingMachine vendingMachine) : base(vendingMachine)
    {
    }

    public override void SelectProduct(string productName)
    { 
        vendingMachine.MachineState = new ProductSelected(vendingMachine);
    }
}

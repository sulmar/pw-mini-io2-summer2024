using static Vending_Machine_Demo.VendingMachine;

namespace Vending_Machine_Demo;

public class ProductSelected : VendingMachineState
{
    public ProductSelected(VendingMachine vendingMachine) : base(vendingMachine)
    {
    }
    public override void SelectPaymentMethod(PaymentMethod paymentMethod)
    {
        vendingMachine.MachineState = new AwaitingPayment(vendingMachine);
    }

    public override void Clear()
    {
        vendingMachine.MachineState = new Idle(vendingMachine);
    }
}

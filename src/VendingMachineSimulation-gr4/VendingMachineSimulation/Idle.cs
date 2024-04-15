namespace VendingMachineSimulation
{
    public class Idle : VendingMachineState
    {
        public Idle(VendingMachine vendingMachine) : base(vendingMachine)
        {
        }

        public override void SelectProduct(IProduct product)
        {
            vendingMachine.selectedProducts.Add(product);

            vendingMachine.State = new Selecting(vendingMachine);

        }
    }
}

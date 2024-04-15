namespace VendingMachineSimulation
{
    public class Selecting : VendingMachineState
    {
        public Selecting(VendingMachine vendingMachine) : base(vendingMachine)
        {
        }

        public override void SelectProduct(IProduct product)
        {
            vendingMachine.selectedProducts.Add(product);
        }

        public override void ClearSelected()
        {
            if (vendingMachine.IsEmpty())
                throw new InvalidOperationException();

            vendingMachine.selectedProducts.Clear();
            

            vendingMachine.State = new Idle(vendingMachine);
        }

        public override void ConfirmSelected()
        {
            vendingMachine.State = new Checkout(vendingMachine);

        }

        public override void DeleteProduct(IProduct product)
        {
            if (!vendingMachine.selectedProducts.Contains(product))
                throw new InvalidOperationException();

            vendingMachine.selectedProducts.Remove(product);

            if (vendingMachine.IsEmpty())
                vendingMachine.State = new Idle(vendingMachine);
        }

  
    }
}

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

   

    public class VendingMachine
    {
        public VendingMachine()
        {
            State = new Idle(this);
        }

        public VendingMachineState State { get; set; }

        public List<IProduct> selectedProducts = new List<IProduct>();

        public decimal Balance { get; set; } = 0;

        public bool IsEmpty()
        {
            return selectedProducts.Count == 0;
        }

        public decimal TotalPrice => selectedProducts.Sum(p => p.Price);

        public void SelectProduct(IProduct product)
        {
           State.SelectProduct(product);
        }

        public void ConfirmSelected()
        {
            State.ConfirmSelected();
        }

        public void DeleteProduct(IProduct product)
        {
            State.DeleteProduct(product);

          
        }

        public void ClearSelected()
        {
           State.ClearSelected();
        }

        public void Pay(PaymentMethod method, decimal amount)
        {
            State.Pay(method, amount);
        }

        public void ConfirmPayment()
        {
            this.Balance = 0;
            
        }

        public void CancelPayment()
        {
            State.CancelPayment();
        }



    }
}

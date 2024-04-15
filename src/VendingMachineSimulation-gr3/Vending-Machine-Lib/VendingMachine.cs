namespace Vending_Machine_Demo;

public class VendingMachine
{

   


    //public enum State
    //{
    //    Idle, 
    //    ProductSelected, 
    //    AwaitingPayment, 
    //}

    public enum PaymentMethod
    {
        Cash, 
        Card, 
        Blik
    }

    public VendingMachine()
    {
        MachineState = new Idle(this);
        _balance = 0M;
    }

    private decimal _balance;


    public VendingMachineState MachineState { get; set; }

   

    public decimal Balance
    {
        get => _balance;
        set => _balance =  value;
    }

    public void SelectProduct(string  productName)
    {
       MachineState.SelectProduct(productName);
    }

    public void Clear()
    {
        MachineState.Clear();
    }

    public void SelectPaymentMethod(PaymentMethod paymentMethod)
    {
        MachineState.SelectPaymentMethod(paymentMethod);
    }

    public void CancelPayment()
    {
        MachineState.CancelPayment();
    }

    public void InsertCoin(decimal amount)
    {
        MachineState.InsertCoin(amount);
    }

    public void Dispense()
    {
        MachineState.Dispense();
    }
}

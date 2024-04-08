namespace Vending_Machine_Demo;

public class VendingMachine
{
    public enum State
    {
        Idle, 
        ProductSelected, 
        AwaitingPayment, 
    }

    public enum PaymentMethod
    {
        Cash, 
        Card, 
        Blik
    }

    public VendingMachine()
    {
        MachineState = State.Idle;
        _selectedPaymentMethod = null;
        _balance = 0M;
    }

    private decimal _balance;
    private PaymentMethod? _selectedPaymentMethod;

    public State MachineState { get; private set; }
    public decimal Balance => _balance;

    public void SelectProduct(string  productName)
    {
        if (MachineState != State.Idle)
            throw new InvalidOperationException();

        MachineState = State.ProductSelected;
    }

    public void Clear()
    {
        if (MachineState != State.ProductSelected)
            throw new InvalidOperationException();

        MachineState = State.Idle;
    }

    public void SelectPaymentMethod(PaymentMethod paymentMethod)
    {
        if (MachineState != State.ProductSelected)
            throw new InvalidOperationException();

        MachineState = State.AwaitingPayment;
    }

    public void CancelPayment()
    {
        if (MachineState != State.AwaitingPayment)
            throw new InvalidOperationException();
        
        MachineState = State.ProductSelected;
        _balance = 0M;
    }

    public void InsertCoin(decimal amount)
    {
        if (MachineState != State.AwaitingPayment)
            throw new InvalidOperationException();

        _balance += amount;
    }

    public void Dispense()
    {
        if (MachineState != State.AwaitingPayment)
            throw new InvalidOperationException();

        MachineState = State.Idle;
        _balance = 0M;
    }
}

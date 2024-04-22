using Stateless;

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

    public enum Trigger
    {
        SelectProduct,
        SelectPaymentMethod,
        InsertCoin,
        CancelPayment,
        Clear,
        Dispense
    }

    StateMachine<State, Trigger> machine;

    public VendingMachine()
    {

        machine = new StateMachine<State, Trigger>(State.Idle);

        machine.Configure(State.Idle)
            .Permit(Trigger.SelectProduct, State.ProductSelected);

        machine.Configure(State.ProductSelected)
            .Permit(Trigger.SelectPaymentMethod, State.AwaitingPayment)
            .Permit(Trigger.Clear, State.Idle);

        machine.Configure(State.AwaitingPayment)

            .PermitIf(Trigger.InsertCoin, State.Idle, () => Balance > 10m)
             .PermitReentryIf(Trigger.InsertCoin, () => Balance <= 10)
            .Permit(Trigger.CancelPayment, State.ProductSelected)
            .Permit(Trigger.Dispense, State.Idle)
            ;

        _balance = 0M;

        Console.WriteLine(Graph);
    }

    public string Graph => Stateless.Graph.UmlDotGraph.Format(machine.GetInfo());   

    private decimal _balance;


    public State MachineState => machine.State;



    public decimal Balance
    {
        get => _balance;
        set => _balance = value;
    }

    public void SelectProduct(string productName)
    {
        machine.Fire(Trigger.SelectProduct);
    }

    public void Clear()
    {
        machine.Fire(Trigger.Clear);
    }

    public void SelectPaymentMethod(PaymentMethod paymentMethod)
    {
        machine.Fire(Trigger.SelectPaymentMethod);
    }

    public void CancelPayment()
    {
        machine.Fire(Trigger.CancelPayment);
    }

    public void InsertCoin(decimal amount)
    {
        machine.Fire(Trigger.InsertCoin);
    }

    public void Dispense()
    {
        machine.Fire(Trigger.Dispense);
    }
}

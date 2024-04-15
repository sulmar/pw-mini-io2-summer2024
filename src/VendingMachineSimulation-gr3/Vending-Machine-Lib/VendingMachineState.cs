using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Vending_Machine_Demo.VendingMachine;

namespace Vending_Machine_Demo;

// Abstract State
public abstract class VendingMachineState
{
    protected VendingMachine vendingMachine;

    protected VendingMachineState(VendingMachine vendingMachine)
    {
        this.vendingMachine = vendingMachine;
    }

    // Handlers
    public virtual void SelectProduct(string productName)
    {
        throw new InvalidOperationException();
    }
    public virtual void Clear()
    {
        throw new InvalidOperationException();
    }
    public virtual void SelectPaymentMethod(PaymentMethod paymentMethod)
    {
        throw new InvalidOperationException();
    }
    public virtual void CancelPayment()
    {
        throw new InvalidOperationException();
    }
    public virtual void InsertCoin(decimal amount)
    {
        throw new InvalidOperationException();
    }
    public virtual void Dispense()
    {
        throw new InvalidOperationException();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineSimulation
{

    public class AwaitingPayment : VendingMachineState
    {
        public AwaitingPayment(VendingMachine vendingMachine) : base(vendingMachine)
        {
        }

        public override void CancelPayment()
        {
            vendingMachine.Balance = 0;
            vendingMachine.State = new Checkout(vendingMachine);
        }

        public override void ClearSelected()
        {
            throw new NotImplementedException();
        }

        public override void ConfirmSelected()
        {
            throw new NotImplementedException();
        }

        public override void DeleteProduct(IProduct product)
        {
            throw new NotImplementedException();
        }

        public override void Pay(PaymentMethod paymentMethod, decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException();

            vendingMachine.Balance += amount;

            if (vendingMachine.Balance >= vendingMachine.TotalPrice)
            {
                vendingMachine.ConfirmPayment();
                vendingMachine.State = new Idle(vendingMachine);
            }
        }

        public override void SelectProduct(IProduct product)
        {
            throw new NotImplementedException();
        }
    }
}

using Vending_Machine_Demo;

namespace Vending_Machine_Tests;

public class VendingMachineTests
{

    [Fact]
    public void Constructor_WhenCalled_SetIdleState()
    {
        // Arrange

        // Act
        var machine = new VendingMachine();

        // Assert
        Assert.Equal(VendingMachine.State.Idle, machine.MachineState);
    }

    [Fact]
    public void SelectProduct_WhenCalled_SetProductSelectedState()
    {
        // Arrange
        var machine = new VendingMachine();

        // Act
        machine.SelectProduct("A");

        // Assert
        Assert.Equal(VendingMachine.State.ProductSelected, machine.MachineState);
    }

    [Fact]
    public void SelectProduct_WhenTwiceCalled_SetProductSelectedState()
    {
        // Arrange
        var machine = new VendingMachine();
        machine.SelectProduct("A");

        // Act
        machine.SelectProduct("A");

        // Assert
        Assert.Equal(VendingMachine.State.ProductSelected, machine.MachineState);
    }

    [Fact]
    public void Clear_WhenCalledAfterSelectProduct_SetIdleState()
    {
        // Arrange
        var machine = new VendingMachine();
        machine.SelectProduct("A");

        // Act
        machine.Clear();

        // Assert
        Assert.Equal(VendingMachine.State.Idle, machine.MachineState);
    }

    [Fact]
    public void SelectPaymentMethod_WhenCalledAfterSelectProduct_SetAwaitingPaymentState()
    {
        // Arrange
        var machine = new VendingMachine();
        machine.SelectProduct("A");

        // Act
        machine.SelectPaymentMethod(VendingMachine.PaymentMethod.Cash);

        // Assert
        Assert.Equal(VendingMachine.State.AwaitingPayment, machine.MachineState);
    }

    [Fact]
    public void CancelPayment_WhenCalledInAwaitingPaymentState_SetProductSelectedState()
    {
        // Arrange
        var machine = new VendingMachine();
        machine.SelectProduct("A");
        machine.SelectPaymentMethod(VendingMachine.PaymentMethod.Cash);

        // Act
        machine.CancelPayment();

        // Assert
        Assert.Equal(VendingMachine.State.ProductSelected, machine.MachineState);
    }

    [Fact]
    public void InsertCoin_WhenCalledInAwaitingPaymentState_SetAwaitingPaymentState()
    {
        // Arrange
        var machine = new VendingMachine();
        machine.SelectProduct("A");
        machine.SelectPaymentMethod(VendingMachine.PaymentMethod.Cash);

        // Act
        machine.InsertCoin(1M);

        // Assert
        Assert.Equal(VendingMachine.State.AwaitingPayment, machine.MachineState);
    }

    [Fact]
    public void InsertCoin_WhenCalledInAwaitingPaymentState_ReturnsBalance()
    {
        // Arrange
        var machine = new VendingMachine();
        machine.SelectProduct("A");
        machine.SelectPaymentMethod(VendingMachine.PaymentMethod.Cash);

        // Act
        machine.InsertCoin(1M);

        // Assert
        Assert.Equal(1M, machine.Balance);
    }

    [Fact]
    public void InsertCoin_WhenCalledTwiceInAwaitingPaymentState_ReturnsBalance()
    {
        // Arrange
        var machine = new VendingMachine();
        machine.SelectProduct("A");
        machine.SelectPaymentMethod(VendingMachine.PaymentMethod.Cash);

        // Act
        machine.InsertCoin(1M);
        machine.InsertCoin(1M);

        // Assert
        Assert.Equal(2M, machine.Balance);
    }

    [Fact]
    public void Dispense_WhenCalledInAwaitingPaymentState_SetIdleState()
    {
        // Arrange
        var machine = new VendingMachine();
        machine.SelectProduct("A");
        machine.SelectPaymentMethod(VendingMachine.PaymentMethod.Cash);
        machine.InsertCoin(1M);

        // Act
        machine.Dispense();

        // Assert
        Assert.Equal(VendingMachine.State.Idle, machine.MachineState);
    }

    [Fact]
    public void Dispense_WhenCalledInAwaitingPaymentState_Returns0Balance()
    {
        // Arrange
        var machine = new VendingMachine();
        machine.SelectProduct("A");
        machine.SelectPaymentMethod(VendingMachine.PaymentMethod.Cash);
        machine.InsertCoin(1M);

        // Act
        machine.Dispense();

        // Assert
        Assert.Equal(0M, machine.Balance);
    }
}
﻿namespace DiscountCalculatorLibrary;

// Abstract Strategy
public interface IDiscountStrategy
{
    decimal Discount(decimal price);
}

// Concrete Strategy A
public class PercentageDiscountStrategy(decimal _percentage) : IDiscountStrategy
{
    public decimal Discount(decimal price) => price * _percentage;
}
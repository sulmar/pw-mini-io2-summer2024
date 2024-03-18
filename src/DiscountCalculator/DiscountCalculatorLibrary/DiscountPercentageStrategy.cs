using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountCalculatorLibrary
{
    // Abstract Strategy
    public interface IDiscountStrategy
    {
        decimal Discount(decimal price);
    }

    // Concrete Strategy
    public class DiscountPercentageStrategy : IDiscountStrategy
    {
        private readonly decimal _percentage;

        public DiscountPercentageStrategy(decimal percentage)
        {
            _percentage = percentage;
        }

        public decimal Discount(decimal price)
        {
            return price * _percentage;
        }
    }
}

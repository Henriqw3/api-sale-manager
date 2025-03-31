using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.ValueObjects
{
    public class Discount
    {
        public decimal Percentage { get; }

        protected Discount() { } // Construtor privado ou protegido para o EF Core
        public Discount(int quantity)
        {
            if (quantity >= 4 && quantity < 10)
                Percentage = 0.10m;
            else if (quantity >= 10 && quantity <= 20)
                Percentage = 0.20m;
            else if (quantity > 20)
                throw new InvalidOperationException("Cannot sell more than 20 items of the same product.");
            else
                Percentage = 0m;
        }
        public decimal Apply(decimal price) => price * (1 - Percentage);
    }
}

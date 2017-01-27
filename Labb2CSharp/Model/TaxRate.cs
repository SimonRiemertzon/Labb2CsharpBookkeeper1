using System;
namespace Labb2CSharp
{
    public class TaxRate
    {
        public double Percent { get; set; }

        public TaxRate(double tr)
        {
            Percent = tr;
        }
    }
}

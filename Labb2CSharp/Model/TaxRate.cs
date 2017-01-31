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

        public override string ToString()
        {
            return string.Format("{0}%", Percent * 100);
        }
    }
}

using System;
using SQLite;
namespace Labb2CSharp
{
    public class TaxRate : Java.Lang.Object
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; private set; }
        public double Percent { get; set; }


        public override string ToString()
        {
            return string.Format("{0}%", Percent * 100);
        }
    }
}

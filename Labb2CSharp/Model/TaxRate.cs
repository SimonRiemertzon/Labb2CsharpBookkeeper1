using System;
using SQLite;
namespace Labb2CSharp
{
    public class TaxRate : Java.Lang.Object
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; private set; }
        public double Percent { get; set; }


        /* public TaxRate(int id, double tr)
         {
             this.id = id;
             Percent = tr;
         }*/

        public override string ToString()
        {
            return string.Format("{0}%", Percent * 100);
        }
    }
}

using System;
using SQLite;
namespace Labb2CSharp
{
    public class Account : Java.Lang.Object
    {
        [PrimaryKey]
        public int ID { get; set; }
        public string Name { get; set; }
        public string TypeOfAccount { get; set; }

        //public int debet { get; set; }
        //public int credit { get; set; }



        public override string ToString() {
            return string.Format("{1} - {0}", Name, ID);
        }
    }

}



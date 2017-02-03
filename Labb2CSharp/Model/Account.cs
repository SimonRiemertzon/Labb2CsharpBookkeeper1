using System;
namespace Labb2CSharp
{
    public class Account : Java.Lang.Object
    {
        public int ID { get; set; }
        public string Name { get; set; }

        //public int debet { get; set; }
        //public int credit { get; set; }


        public Account(int id, string n)
        {
            ID = id;
            Name = n;

        }

        public override string ToString()
        {
            return string.Format("{0} - {1}", Name, ID);
        }
    }

}

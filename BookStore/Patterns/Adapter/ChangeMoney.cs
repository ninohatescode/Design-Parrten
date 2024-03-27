using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Patterns.Adapter
{
    // Adaptee
    public class ChangeMoney
    {
        public ChangeMoney() { }

        public decimal? ConvertIntital(decimal? intital)
        {
            return intital * 23207.50m;
        }

        public decimal ConvertPri(decimal price)
        {
            return price * 23207.50m;
        }
    }
}
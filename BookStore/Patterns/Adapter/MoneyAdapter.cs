using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Patterns.Adapter
{
    public class MoneyAdapter : IMoney
    {
        private ChangeMoney changeMoney;

        public MoneyAdapter(ChangeMoney changeMoney) 
        {
            this.changeMoney = changeMoney;
        }

        public decimal? ConvertInti(decimal? money)
        {           
            return changeMoney.ConvertIntital(money);
        }

        public decimal ConvertPri(decimal money)
        {
            return changeMoney.ConvertPri(money);
        }
    }
}
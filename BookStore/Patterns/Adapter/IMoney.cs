using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Patterns.Adapter
{
    internal interface IMoney
    {
        decimal? ConvertInti(decimal? money);
        decimal ConvertPri(decimal money);
    }
}

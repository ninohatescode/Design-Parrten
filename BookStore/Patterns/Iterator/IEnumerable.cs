using BookStore.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Patterns.Iterator
{
    public interface IEnumerable<T>
    {
        IEnumerator<T> GetEnumerator();
    }
}
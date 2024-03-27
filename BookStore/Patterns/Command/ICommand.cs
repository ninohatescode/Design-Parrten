using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookStore.Models;

namespace BookStore.Patterns.Command
{
    public interface ICommand
    {
        void Execute();
    }
}
using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Patterns.Command
{
    public class RemoveProductCommand : ICommand
    {
        private CartItem cartItemCommand;
        private List<CartItem> cartCommand;

        public RemoveProductCommand(CartItem cartItemCommand, List<CartItem> cartCommand)
        {
            this.cartItemCommand = cartItemCommand;
            this.cartCommand = cartCommand;
        }

        //thực thi
        public void Execute()
        {
            // Xóa sách khỏi giỏ hàng
            cartCommand.Remove(cartItemCommand);
        }
    }
}
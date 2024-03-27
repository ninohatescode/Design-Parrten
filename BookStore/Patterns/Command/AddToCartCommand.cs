using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Patterns.Command
{
    public class AddToCartCommand : ICommand
    {
        private CartItem cartItemCommand;
        private List<CartItem> cartCommand;

        public AddToCartCommand(CartItem cartItemCommand, List<CartItem> cartCommand)
        {
            this.cartItemCommand = cartItemCommand;
            this.cartCommand = cartCommand;
        }

        //thực thi
        public void Execute()
        {
            // Thêm sách vào giỏ hàng
            cartCommand.Add(cartItemCommand);
        }
    }
}
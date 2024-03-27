using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Patterns.Command
{
    public class UpdateQuantityCommand : ICommand
    {
        private CartItem cartItemCommand;
        private int newQuantityCommand;

        public UpdateQuantityCommand(CartItem cartItemCommand, int newQuantityCommand)
        {
            this.cartItemCommand = cartItemCommand;
            this.newQuantityCommand = newQuantityCommand;
        }

        //thực thi
        public void Execute()
        {
            // Cập nhật số lượng sách trong giỏ hàng
            cartItemCommand.Number = newQuantityCommand;
        }
    }
}
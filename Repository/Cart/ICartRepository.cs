using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcommerceWebApi.Model;

namespace EcommerceWebApi.Repository
{
    public interface ICartRepository
    {
        Task<List<Cart>> GetAllCartsAsync();
        Task<Cart> GetCartByIdAsync(int cartId);
        Task<Cart> CreateCartAsync(Cart cart);
        Task UpdateCartAsync(Cart cart);
        Task DeleteCartAsync(int cartId);
    }

    public interface ICartItemRepository
    {
        Task<List<CartItem>> GetAllCartItemsAsync();
        Task<CartItem> GetCartItemByIdAsync(int cartItemId);
        Task<CartItem> CreateCartItemAsync(CartItem cartItem);
        Task UpdateCartItemAsync(CartItem cartItem);
        Task DeleteCartItemAsync(int cartItemId);
    }
}
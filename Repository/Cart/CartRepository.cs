using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcommerceWebApi.Data;
using EcommerceWebApi.Model;
using Microsoft.EntityFrameworkCore;

namespace EcommerceWebApi.Repository
{
    public class CartRepository : ICartRepository
    {
        private readonly EcommerceDbContext _dbContext;

        public CartRepository(EcommerceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Cart>> GetAllCartsAsync()
        {
            return await _dbContext.Carts.ToListAsync();
        }

        public async Task<Cart> GetCartByIdAsync(int cartId)
        {
            return await _dbContext.Carts.FindAsync(cartId);
        }

        public async Task<Cart> CreateCartAsync(Cart cart)
        {
            _dbContext.Carts.Add(cart);
            await _dbContext.SaveChangesAsync();
            return cart;
        }

        public async Task UpdateCartAsync(Cart cart)
        {
            _dbContext.Entry(cart).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteCartAsync(int cartId)
        {
            var cart = await _dbContext.Carts.FindAsync(cartId);
            _dbContext.Carts.Remove(cart);
            await _dbContext.SaveChangesAsync();
        }
    }

    public class CartItemRepository : ICartItemRepository
    {
        private readonly EcommerceDbContext _dbContext;

        public CartItemRepository(EcommerceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<CartItem>> GetAllCartItemsAsync()
        {
            return await _dbContext.CartItems.ToListAsync();
        }

        public async Task<CartItem> GetCartItemByIdAsync(int cartItemId)
        {
            return await _dbContext.CartItems.FindAsync(cartItemId);
        }

        public async Task<CartItem> CreateCartItemAsync(CartItem cartItem)
        {
            _dbContext.CartItems.Add(cartItem);
            await _dbContext.SaveChangesAsync();
            return cartItem;
        }

        public async Task UpdateCartItemAsync(CartItem cartItem)
        {
            _dbContext.Entry(cartItem).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteCartItemAsync(int cartItemId)
        {
            var cartItem = await _dbContext.CartItems.FindAsync(cartItemId);
            _dbContext.CartItems.Remove(cartItem);
            await _dbContext.SaveChangesAsync();
        }
    }
}
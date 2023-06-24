using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcommerceWebApi.Data;
using EcommerceWebApi.Model;
using Microsoft.EntityFrameworkCore;

namespace EcommerceWebApi.Repository
{
    public class WishListRepository : IWishListRepository
    {
        private readonly EcommerceDbContext _dbContext;

        public WishListRepository(EcommerceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<WishList>> GetAllWishListsAsync()
        {
            return await _dbContext.WishLists.ToListAsync();
        }

        public async Task<WishList> GetWishListByIdAsync(int wishListId)
        {
            return await _dbContext.WishLists.FindAsync(wishListId);
        }

        public async Task<WishList> CreateWishListAsync(WishList wishList)
        {
            _dbContext.WishLists.Add(wishList);
            await _dbContext.SaveChangesAsync();
            return wishList;
        }

        public async Task UpdateWishListAsync(WishList wishList)
        {
            _dbContext.Entry(wishList).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteWishListAsync(int wishListId)
        {
            var wishList = await _dbContext.WishLists.FindAsync(wishListId);
            _dbContext.WishLists.Remove(wishList);
            await _dbContext.SaveChangesAsync();
        }
    }
}
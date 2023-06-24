using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using EcommerceWebApi.Model;

namespace EcommerceWebApi.Repository
{
    public interface IWishListRepository
    {
        Task<List<WishList>> GetAllWishListsAsync();
        Task<WishList> GetWishListByIdAsync(int wishListId);
        Task<WishList> CreateWishListAsync(WishList wishList);
        Task UpdateWishListAsync(WishList wishList);
        Task DeleteWishListAsync(int wishListId);
    }
}
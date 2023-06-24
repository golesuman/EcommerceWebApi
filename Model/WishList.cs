namespace EcommerceWebApi.Model;

public class WishList
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int ProductId { get; set; }
    public DateTime CreatedAt { get; set; }

    public User User { get; set; }
    public Product Product { get; set; }
}
namespace EcommerceWebApi.Model;

public class Cart
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsDeleted { get; set; }

    public User User { get; set; }
}

public class CartItem
{
    public int Id { get; set; }
    public int CartId { get; set; }
    public int ProductId { get; set; }
    public int? Quantity { get; set; }
    public bool IsDeleted { get; set; }

    public Cart Cart { get; set; }
    public Product Product { get; set; }
}
